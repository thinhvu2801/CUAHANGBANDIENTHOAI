Create database CHBHDT_63131330
go
use CHBHDT_63131330
go

/*TÀI KHOẢN*/
Create table TaiKhoan
(MaNguoiDung int IDENTITY(1,1) NOT NULL,
	HoTen nvarchar(50) NULL,
	Email varchar(50) NULL,
	Dienthoai varchar(50) NULL,
	Matkhau varchar(50) NULL,
	IDQuyen int NULL,
	Diachi nvarchar(100) NULL,
	primary key(MaNguoiDung));

/*PHÂN QUYỀN*/
Create table PhanQuyen
(IDQuyen int IDENTITY(1,1) NOT NULL,
	TenQuyen nvarchar(20) NULL,
	primary key(IDQuyen));

/*NHÀ CUNG CẤP*/
Create table NhaCungCap
(MaNCC int IDENTITY(1,1) NOT NULL, 
	TenNCC nvarchar(100) NULL, 
	primary key(MaNCC));

/*LOẠI HÀNG*/
Create table LoaiHang
(MaLoai int IDENTITY(1,1) NOT NULL,
	TenLoai nvarchar(100) DEFAULT NULL,
	Primary key(MaLoai));

/*SẢN PHẨM*/
CREATE TABLE SanPham(
	MaSP int IDENTITY(1,1) NOT NULL,
	TenSP nvarchar (100) NULL,
	GiaBan decimal(18,0) NULL,	
	Soluong int NULL,
	MoTa ntext NULL,
	MaLoai int NULL,
	MaNCC int NULL,
	AnhSP nvarchar(100) NULL,
	Primary key(MaSP));


/*ĐƠN HÀNG*/
CREATE TABLE DonHang(
	Madon int IDENTITY(1,1) NOT NULL,	
	NgayDat  datetime NULL,
	TinhTrang  int NULL,
	ThanhToan int NULL,
	DiaChiNhanHang Nvarchar(100) NULL,
	MaNguoiDung int NULL,
	TongTien decimal(18,0),
	Primary key(Madon));

/*CT ĐƠN HÀNG*/
CREATE TABLE ChiTietDonHang(
	CTMaDon int IDENTITY(1,1) NOT NULL,
	MaDon int NOT NULL,
	MaSP int NOT NULL,
	SoLuong int NULL,
	DonGia decimal(18,0) NULL,
	ThanhTien decimal(18,0)  NULL,
	PhuongThucThanhToan int Null,
	Primary key(CTMaDon));

CREATE TABLE TinTuc(
	MaTT int IDENTITY(1,1) NOT NULL,
	TieuDe nvarchar(100),
	NoiDung ntext,
	Primary key(MaTT));


/*Ràng buộc TÀI KHOẢN*/
alter table TaiKhoan
add constraint FK_tk_pq foreign key(IDQuyen) references PhanQuyen(IDQuyen);

/*Ràng buộc SẢN PHẨM*/
alter table SanPham
add constraint FK_sp_ncc foreign key(MaNCC) references NhaCungCap(MaNCC);
alter table SanPham
add constraint FK_sp_loai foreign key(MaLoai) references LoaiHang(Maloai);

/*Ràng buộc ĐƠN HÀNG*/
alter table DonHang
add constraint FK_hd_tk foreign key(MaNguoiDung) references taikhoan(MaNguoiDung);

/*Ràng buộc CHI TIẾT ĐƠN HÀNG*/
alter table ChiTietDonHang
add constraint FK_cthd_hd foreign key(MaDon) references DonHang(MaDon);
alter table ChiTietDonHang
add constraint FK_cthd_sp foreign key(MaSP) references SanPham(MaSP);

/*Phân quyền*/
insert into PhanQuyen values ('Adminstrator');
insert into PhanQuyen values ('Member');
	GO
/*Tài khoản*/
insert into TaiKhoan (HoTen, Email, Dienthoai, Matkhau, IDQuyen, Diachi)
values 
  (N'Nguyen Van A', 'nguyenvana@email.com', '123456789', '123456', 1, N'Hanoi'),
  (N'Tran Thi B', 'tranthib@email.com', '987654321', '123456', 2, N'Ho Chi Minh City'),
  (N'Le Van C', 'levanc@email.com', '456123789', '123456', 1, N'Da Nang'),
  (N'Pham Van D', 'phamvand@email.com', '789123456', '123456', 2, N'Can Tho'),
  (N'Tran Van E', 'tranve@email.com', '321654987', '123456', 1, N'Haiphong'),
  (N'Hoang Thi F', 'hoangthif@email.com', '654789321', '123456', 2, N'Quang Ninh');
  	GO

/*Loại hàng*/
-- Insert data into LoaiHang table
INSERT INTO LoaiHang (TenLoai)
VALUES
  (N'Apple'),
  (N'Samsung'),
  (N'Google'),
  (N'Huawei'),
  (N'OnePlus'),
  (N'Xiaomi'),
  (N'Oppo'),
  (N'Vivo'),
  (N'Sony'),
  (N'LG'),
  (N'Motorola'),
  (N'Nokia'),
  (N'Asus'),
  (N'BlackBerry'),
  (N'HTC'),
  (N'Lenovo'),
  (N'ZTE'),
  (N'Alcatel'),
  (N'Realme'),
  (N'Infinix'),
  (N'Tecno'),
  (N'Sony'),
  (N'Fairphone'),
  (N'Sharp'),
  (N'Caterpillar'),
  (N'Razer'),
  (N'Meizu'),
  (N'Ulefone'),
  (N'Doogee'),
  (N'Poco');
  	GO

/*Nhà cung cấp*/
INSERT INTO NhaCungCap (TenNCC)
VALUES
  (N'Thinh Mobile'),
  (N'Minh Mobile'),
  (N'Vũ Mobile'),
  (N'Thái Mobile'),
  (N'Hà Mobile');
  	GO

/*Sản phẩm*/
-- Insert data into SanPham table
INSERT INTO SanPham (TenSP, GiaBan, Soluong, MoTa, MaLoai, MaNCC, AnhSP)
VALUES
  (N'Google Pixel 6', 15000000, 10, N'Pixel 6 là sản phẩm mới nhất của Google, với camera thông minh, trải nghiệm Android gốc và tính năng trí tuệ nhân tạo.', 3, 3, N'Image/iphone.jpg'),
  (N'Samsung Galaxy S21', 17500000, 70, N'Galaxy S21 là một chiếc điện thoại Android hàng đầu với màn hình đẹp, camera nâng cao và tính năng đa phương tiện mạnh mẽ.', 2, 1, N'Image/iphone.jpg'),
  (N'iPhone 13 Pro', 23000000, 12, N'iPhone 13 Pro là một chiếc điện thoại cao cấp của Apple, với camera tiên tiến, hiệu suất mạnh mẽ và hệ điều hành iOS.', 1, 2, N'Image/iphone.jpg'),
  (N'Huawei P40 Pro', 20000000, 12, N'P40 Pro là một chiếc điện thoại chụp ảnh mạnh mẽ từ Huawei, với camera Leica và khả năng kết nối 5G.', 4, 1, N'Image/iphone.jpg'),
  (N'OnePlus 9', 15500000, 30, N'OnePlus 9 là một chiếc điện thoại hiệu suất cao với màn hình 120Hz, camera hợp tác với Hasselblad và sạc nhanh Warp Charge.', 5, 1, N'Image/iphone.jpg'),
  (N'Xiaomi Mi 11', 14500000, 25, N'Xiaomi Mi 11 là một chiếc điện thoại Android cao cấp với màn hình AMOLED, camera đa chức năng và sạc nhanh.', 6, 4, N'Image/iphone.jpg'),
  (N'Oppo Find X3 Pro', 18000000, 64, N'Oppo Find X3 Pro là một chiếc điện thoại cao cấp với camera mạnh mẽ và màn hình 120Hz.', 7, 2, N'Image/iphone.jpg'),
  (N'Vivo V23', 13000000, 18, N'Vivo V23 là một chiếc điện thoại trung cấp với thiết kế mỏng nhẹ và camera selfie chất lượng cao.', 8, 1, N'Image/iphone.jpg'),
  (N'Sony Xperia 5 III', 16000000, 30, N'Xperia 5 III là một chiếc điện thoại Sony chuyên nghiệp với màn hình OLED, camera chất lượng và khả năng quay video chuyên nghiệp.', 9, 1, N'Image/iphone.jpg'),
  (N'LG G8 ThinQ', 10500000, 45, N'LG G8 ThinQ là một chiếc điện thoại với công nghệ âm thanh độc đáo, camera 3D và màn hình OLED.', 10, 4, N'Image/iphone.jpg'),
  (N'Motorola Moto G Power (2021)', 7500000, 32, N'Moto G Power (2021) là một chiếc điện thoại tầm trung với pin khủng, phù hợp cho người dùng muốn sử dụng lâu dài.', 11, 4, N'Image/iphone.jpg'),
  (N'Nokia 8.3 5G', 12000000, 63, N'Nokia 8.3 5G là chiếc điện thoại hỗ trợ kết nối 5G với camera Zeiss và thiết kế chắc chắn từ Nokia.', 12, 2, N'Image/iphone.jpg'),
  (N'Asus ROG Phone 6', 20000000, 51, N'ROG Phone 6 là một chiếc điện thoại chơi game mạnh mẽ với tốc độ làm mới màn hình cao và hệ thống làm mát hiệu quả.', 13, 1, N'Image/iphone.jpg'),
  (N'BlackBerry KEY2', 8500000, 41, N'KEY2 là chiếc điện thoại BlackBerry với bàn phím vật lý, tập trung vào tính năng bảo mật và quản lý công việc.', 14, 1, N'Image/iphone.jpg'),
  (N'HTC U20 5G', 11000000, 35, N'HTC U20 5G là chiếc điện thoại hỗ trợ kết nối 5G với camera đa chức năng và âm thanh chất lượng cao.', 15, 1, N'Image/iphone.jpg'),
  (N'Lenovo Legion Phone Duel 2', 18500000, 45, N'Legion Phone Duel 2 là một chiếc điện thoại gaming với cấu hình mạnh mẽ, màn hình 144Hz và các tính năng chuyên dành cho game thủ.', 16, 1, N'Image/iphone.jpg'),
  (N'ZTE Axon 30 Ultra', 15000000, 30, N'Axon 30 Ultra là một chiếc điện thoại ZTE cao cấp với camera đa chức năng và màn hình AMOLED.', 17, 1, N'Image/iphone.jpg'),
  (N'Alcatel 3L (2022)', 6000000, 12, N'Alcatel 3L là một chiếc điện thoại tầm trung với camera đa chức năng và màn hình lớn.', 18, 1, N'Image/iphone.jpg'),
  (N'Realme GT', 9500000, 62, N'Realme GT là chiếc điện thoại tầm trung với hiệu suất cao và camera đa chức năng.', 19, 1, N'Image/iphone.jpg'),
  (N'Infinix Hot 11', 4500000, 62, N'Infinix Hot 11 là một chiếc điện thoại giá rẻ với màn hình lớn và pin dung lượng cao.', 20, 1, N'Image/iphone.jpg'),
  (N'Tecno Camon 18 Premier', 7200000, 66, N'Camon 18 Premier là chiếc điện thoại Tecno chuyên về chụp ảnh với camera trước và sau đều độ phân giải cao.', 21, 1, N'Image/iphone.jpg'),
  (N'Sony Xperia Compact 5', 10000000, 23, N'Xperia Compact 5 là một chiếc điện thoại nhỏ gọn từ Sony với hiệu suất ổn định và camera chất lượng.', 22, 1, N'Image/iphone.jpg'),
  (N'Fairphone 4', 15000000, 12, N'Fairphone 4 là chiếc điện thoại được thiết kế để tối ưu hóa tính bảo vệ môi trường, với linh kiện dễ thay thế và tái chế.', 23, 1, N'Image/iphone.jpg'),
  (N'Sharp Aquos R6', 14800000, 21, N'Aquos R6 là chiếc điện thoại từ Sharp với màn hình IGZO OLED và camera 1 inch.', 24, 3, N'Image/iphone.jpg'),
  (N'CAT S62 Pro', 11500000, 10, N'CAT S62 Pro là chiếc điện thoại chống sốc và chịu nước từ Caterpillar, được thiết kế để làm việc trong môi trường khắc nghiệt.', 25, 1, N'Image/iphone.jpg'),
  (N'Razer Phone 3', 17500000, 20, N'Razer Phone 3 là chiếc điện thoại chơi game với màn hình 120Hz và âm thanh độc đáo từ Razer.', 26, 1, N'Image/iphone.jpg'),
  (N'Meizu 18 Pro', 13000000, 25, N'Meizu 18 Pro là chiếc điện thoại cao cấp với màn hình AMOLED và camera chất lượng.', 27, 5, N'Image/iphone.jpg'),
  (N'Ulefone Armor 10', 8000000, 12, N'Ulefone Armor 10 là chiếc điện thoại chống sốc với khả năng kết nối 5G và camera đa chức năng.', 28, 1, N'Image/iphone.jpg'),
  (N'Doogee S96 Pro', 6500000, 41, N'Doogee S96 Pro là chiếc điện thoại chống sốc với pin khủng và camera đa chức năng.', 29, 1, N'Image/iphone.jpg'),
  (N'Poco X4 Pro', 9200000, 19, N'Poco X4 Pro là một chiếc điện thoại tầm trung với hiệu suất cao và camera đa chức năng.', 30, 4,N'Image/iphone.jpg');
  	GO
/*ĐƠN HÀNG*/
INSERT INTO DonHang (NgayDat, TinhTrang, ThanhToan, DiaChiNhanHang, MaNguoiDung, TongTien)
VALUES
    ('2023-02-07', 1, 1, N'test', 2, 15000000),
    ('2023-02-07', 1, 1, N'test', 2, 27000000),
    ('2023-12-25', 1, 2, N'aaa st', 3, 23000000),
    ('2023-12-21', 1, 2, N'bbb st', 4, 20000000),
    ('2023-12-01', 1, 1, N'ccc st', 5, 18000000),
    ('2023-12-08', 1, 2, N'ddd st', 6, 22000000),
    ('2023-12-18', 1, 2, N'eee st', 7, 19000000),
    ('2023-12-06', 1, 1, N'fff st', 8, 21000000),
    ('2023-12-19', 1, 1, N'ggg st', 9, 24000000);
		GO
/*CT Đơn Hàng*/
INSERT INTO ChiTietDonHang (MaDon, MaSP, SoLuong, DonGia, ThanhTien, PhuongThucThanhToan)
VALUES
    (1, 2, 1, 5000, 5000, 1),
    (1, 3, 1, 22000, 22000, 1),
    (2, 1, 1, 18000, 18000, 1),
    (3, 3, 1, 23000000, 23000000, 1),
    (3, 2, 1, 20000, 20000, 1),
    (4, 1, 2, 4000, 8000, 1);
		GO

/*Tin Tức*/
INSERT INTO TinTuc (TieuDe, NoiDung)
VALUES
    (N'Samsung Giới Thiệu Dòng S22 Mới', N'Samsung vừa ra mắt dòng điện thoại Galaxy S22 với camera cải tiến, màn hình độ phân giải cao và sạc siêu nhanh.'),
    (N'iPhone 14 Ra Mắt: Thiết Kế Hoàn Toàn Mới', N'Apple chính thức giới thiệu iPhone 14 với thiết kế mới lạ, camera đỉnh cao và bản cập nhật iOS đầy ấn tượng.'),
    (N'Xiaomi Mi 12 Sẽ Hỗ Trợ Sạc Siêu Nhanh 200W', N'Xiaomi tiếp tục định đạng thị trường với dòng điện thoại Mi 12 hỗ trợ sạc siêu nhanh, đưa trải nghiệm sử dụng lên một tầm cao mới.'),
    (N'Google Pixel 7 Ra Mắt: Tích Hợp AI Mạnh Mẽ', N'Pixel 7 của Google được trang bị trí tuệ nhân tạo mạnh mẽ, giúp cải thiện hiệu suất camera và trải nghiệm người dùng.'),
    (N'OnePlus 10 Lite: Hiệu Suất Cao, Giá Phải Chăng', N'OnePlus chính thức giới thiệu mẫu điện thoại mới trong dòng 10 Lite với hiệu suất ấn tượng và mức giá phải chăng.'),
    (N'Sony Xperia Fold: Smartphone Gập Màn Hình Đầu Tiên Của Sony', N'Sony đang phát triển một chiếc điện thoại có khả năng gập màn hình, mở đầu cho xu hướng mới trong ngành công nghiệp di động.'),
    (N'Nokia 10: Camera 108MP và Kết Nối 5G', N'HMD Global sẽ cho ra mắt Nokia 10 với camera lên đến 108MP và hỗ trợ kết nối 5G, đưa người dùng vào thế giới chụp ảnh và trải nghiệm internet nhanh chóng.');
		GO
select * from PhanQuyen;
select * from TaiKhoan; 
select * from LoaiHang where TenLoai <> 'Apple';
select * from NhaCungCap;	

select * from DonHang;
select * 
from DonHang,ChiTietDonHang 
where DonHang.MaDon=ChiTietDonHang.MaDon and DonHang.MaDon = 1 

select * from TinTuc


/*Ràng buộc ĐƠN HÀNG*/
alter table Course
add constraint FK_c_u foreign key(LecturerId) references AspNetUsers(Id);


ALTER TABLE TaiKhoan
ADD Quyen nvarchar(20) NULL;
ALTER TABLE TaiKhoan
DROP COLUMN Quyen;

UPDATE TaiKhoan
SET IDQuyen = 1
WHERE Email = 'Admin@gmail.com';
 select * from TaiKhoan;