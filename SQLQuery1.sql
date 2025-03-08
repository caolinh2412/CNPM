CREATE TABLE users(
	id INT PRIMARY KEY IDENTITY(1,1),
	username NVARCHAR(255) NULL,
	password NVARCHAR(255) NULL,
	profile_img NVARCHAR(255) NULL,
	vtri NVARCHAR(50) NULL,
	date_signup DATE NULL,
)
SELECT * FROM users

INSERT INTO users (username, password, profile_img, vtri, date_signup)
VALUES (N'manager1', N'pass123','', N'quản lý', '2024-03-08')