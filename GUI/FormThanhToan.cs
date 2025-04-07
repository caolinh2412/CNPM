using CoffeeShopManagementSystem.BUS;
using QRCoder;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml.Linq;
using System.Net.Http;
using Newtonsoft.Json.Linq;
using DTO;
using System.Diagnostics;
using System.Drawing.Printing;
using System.Drawing.Text;

namespace GUI
{
    public partial class FormThanhToan : Form
    {
        private BUS_DonHang donHangBUS;
        private FormDatHang formDatHang;
        public bool DaThanhToan { get; private set; } = false;
        public FormThanhToan(FormDatHang formDatHang)
        {
            InitializeComponent();
            donHangBUS = new BUS_DonHang();
            this.formDatHang = formDatHang;

            HienThiThongTinHeThong();
            pic_momoLogo.Click += Pic_momoLogo_Click;

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
            string extraData = ""; // có thể mã hóa dữ liệu khách hàng

            // B1: Tạo rawHash
            string rawHash = $"accessKey={accessKey}&amount={amount}&extraData={extraData}&ipnUrl={ipnUrl}" +
                             $"&orderId={orderId}&orderInfo={orderInfo}&partnerCode={partnerCode}" +
                             $"&redirectUrl={redirectUrl}&requestId={requestId}&requestType=captureWallet";

            string signature = CreateSignature(secretKey, rawHash);

            // B2: Gửi JSON request
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

                // B3: Parse và hiển thị mã QR
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

        private string CreateSignature(string key, string data)
        {
            var encoding = new UTF8Encoding();
            byte[] keyByte = encoding.GetBytes(key);
            byte[] messageBytes = encoding.GetBytes(data);
            using (var hmacsha256 = new HMACSHA256(keyByte))
            {
                byte[] hashMessage = hmacsha256.ComputeHash(messageBytes);
                return BitConverter.ToString(hashMessage).Replace("-", "").ToLower();
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
        public string PhuongThucThanhToan { get; set; }
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

