using System.Net.Http;
using Newtonsoft.Json.Linq;
using System.Security.Cryptography;
using System.Text;
using QRCoder;
using System;
using System.Collections.Generic;
using Newtonsoft.Json;
using CoffeeShopManagementSystem.BUS;

namespace GUI
{
    public partial class FormThanhToan : Form
    {
        private BUS_DonHang donHangBUS;
        private UC_DatHang formDatHang;
        public bool DaThanhToan { get; private set; } = false;
        public string PhuongThucThanhToan { get; set; }

        public FormThanhToan(UC_DatHang formDatHang)
        {
            InitializeComponent();
            donHangBUS = new BUS_DonHang();
            this.formDatHang = formDatHang;

            HienThiThongTinHeThong();
            pic_momoLogo.Click += Pic_momoLogo_Click;
            pic_zaloLogo.Click += Pic_zaloLogo_Click;

            lb_Tong.Text = formDatHang.TongTien.ToString("N0") + " VNĐ";
        }

        private void HienThiThongTinHeThong()
        {
            lb_MaDH.Text = donHangBUS.GetNextMaDH();
        }

        private async void Pic_momoLogo_Click(object sender, EventArgs e)
        {
            string endpoint = "https://test-payment.momo.vn/v2/gateway/api/create";
            string partnerCode = "MOMO";
            string accessKey = "F8BBA842ECF85";
            string secretKey = "K951B6PE1waDMi640xX08PD3vg6EkVlz";
            string orderInfo = "Thanh toán đơn hàng quán cà phê 24/7";
            string redirectUrl = "https://momo.vn/return";
            string ipnUrl = "https://momo.vn/notify";
            string amount = ((int)formDatHang.TongTien).ToString();
            string orderId = Guid.NewGuid().ToString();
            string requestId = Guid.NewGuid().ToString();
            string extraData = "";

            string rawHash = $"accessKey={accessKey}&amount={amount}&extraData={extraData}&ipnUrl={ipnUrl}" +
                             $"&orderId={orderId}&orderInfo={orderInfo}&partnerCode={partnerCode}" +
                             $"&redirectUrl={redirectUrl}&requestId={requestId}&requestType=captureWallet";

            string signature = CreateSignature(secretKey, rawHash);

            var jsonRequest = new
            {
                partnerCode,
                accessKey,
                requestId,
                amount,
                orderId,
                orderInfo,
                redirectUrl,
                ipnUrl,
                extraData,
                requestType = "captureWallet",
                signature,
                lang = "vi"
            };

            using (HttpClient client = new HttpClient())
            {
                var content = new StringContent(Newtonsoft.Json.JsonConvert.SerializeObject(jsonRequest), Encoding.UTF8, "application/json");
                var response = await client.PostAsync(endpoint, content);
                string responseContent = await response.Content.ReadAsStringAsync();

                var json = JObject.Parse(responseContent);
                string payUrl = json["payUrl"]?.ToString();

                if (!string.IsNullOrEmpty(payUrl))
                {
                    ShowQRCode(payUrl);
                }
                else
                {
                    MessageBox.Show("Không tạo được mã QR từ MoMo!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private async void Pic_zaloLogo_Click(object sender, EventArgs e)
        {
            try
            {
                string endpoint = "https://sb-openapi.zalopay.vn/v2/create";
                string appId = "2553"; // Valid Sandbox AppID
                string key1 = "PcY4iZIKFCIdgZvA6ueMcMHHUbRLYjPL"; // Valid Sandbox Key1

                int totalAmount = (int)formDatHang.TongTien;
                if (totalAmount <= 0)
                {
                    MessageBox.Show("Số tiền phải lớn hơn 0!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                Random rnd = new Random();
                string appUser = "CoffeeShopUser";
                long appTime = DateTimeOffset.Now.ToUnixTimeMilliseconds();
                string appTransId = DateTime.Now.ToString("yyMMdd") + "_" + rnd.Next(1000000);
                var embedData = new { };
                var items = new[] { new { } };
                string description = $"Thanh toán đơn hàng quán cà phê 24/7 #{appTransId}";
                string bankCode = "zalopayapp";

                // Create data for HMAC signature
                string data = $"{appId}|{appTransId}|{appUser}|{totalAmount}|{appTime}|{JsonConvert.SerializeObject(embedData)}|{JsonConvert.SerializeObject(items)}";
                string mac = CreateSignature(key1, data);

                var param = new Dictionary<string, string>
                {
                    { "app_id", appId },
                    { "app_user", appUser },
                    { "app_time", appTime.ToString() },
                    { "amount", totalAmount.ToString() },
                    { "app_trans_id", appTransId },
                    { "embed_data", JsonConvert.SerializeObject(embedData) },
                    { "item", JsonConvert.SerializeObject(items) },
                    { "description", description },
                    { "bank_code", bankCode },
                    { "mac", mac }
                };

                using (HttpClient client = new HttpClient())
                {
                    var content = new FormUrlEncodedContent(param);
                    var response = await client.PostAsync(endpoint, content);
                    string responseContent = await response.Content.ReadAsStringAsync();

                    var json = JObject.Parse(responseContent);
                    int returnCode = json["return_code"]?.ToObject<int>() ?? -1;

                    if (returnCode == 1)
                    {
                        string qrCodeUrl = json["order_url"]?.ToString();
                        if (!string.IsNullOrEmpty(qrCodeUrl))
                        {
                            ShowQRCode(qrCodeUrl);
                        }
                        else
                        {
                            MessageBox.Show("Không nhận được URL thanh toán từ ZaloPay!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                    }
                    else
                    {
                        string errorMessage = json["return_message"]?.ToString() ?? "Unknown error";
                        string subReturnMessage = json["sub_return_message"]?.ToString() ?? "N/A";
                        MessageBox.Show($"Lỗi ZaloPay: {errorMessage}\nChi tiết: {subReturnMessage}", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Đã xảy ra lỗi: {ex.Message}", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private string CreateSignature(string key, string data)
        {
            using (var hmac = new HMACSHA256(Encoding.UTF8.GetBytes(key)))
            {
                byte[] hash = hmac.ComputeHash(Encoding.UTF8.GetBytes(data));
                return BitConverter.ToString(hash).Replace("-", "").ToLower();
            }
        }

        private void ShowQRCode(string url)
        {
            QRCodeGenerator qrGenerator = new QRCodeGenerator();
            QRCodeData qrCodeData = qrGenerator.CreateQrCode(url, QRCodeGenerator.ECCLevel.Q);
            QRCode qrCode = new QRCode(qrCodeData);
            qr_ThanhToan.Image = qrCode.GetGraphic(5);
        }

        private void guna2Button1_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btn_thanhToan_Click(object sender, EventArgs e)
        {
            if (rdoTienMat.Checked)
                PhuongThucThanhToan = "Tiền mặt";
            else if (rdoChuyenKhoan.Checked)
                PhuongThucThanhToan = "Chuyển khoản";
            else
            {
                MessageBox.Show("Vui lòng chọn phương thức thanh toán!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            DaThanhToan = true;
            this.Close();
        }
    }
}