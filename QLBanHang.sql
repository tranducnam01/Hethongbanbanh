create table NhanVien
(MaNhanVien nvarchar(50) primary key,
 TenNhanVien nvarchar(50),
 GioiTinh nvarchar(10),
 NgaySinh date,
 SoDienThoai varchar(20),
 DiaChi nvarchar(50), 
 Email varchar(50))

create table TaiKhoan
(TenDangNhap nvarchar(20) primary key,
 MatKhau nvarchar(20))

ALTER TABLE TaiKhoan
ADD ChucVu varchar(50);



create table LoaiSanPham
(MaLoaiSP nvarchar(50) primary key,
 TenLoaiSP nvarchar(50),)

create table SanPham
(MaSanPham nvarchar(50) primary key,
 TenSanPham nvarchar(50),
 GiaTien bigint,
 MoTa nvarchar(50),
 MaLoaiSP nvarchar(50) foreign key references LoaiSanPham(MaLoaiSP))

create table HoaDon
(MaHoaDon nvarchar(50) primary key,
 MaNhanVien nvarchar(50) foreign key references NhanVien(MaNhanVien),
 NgayLap date,
 TongTien bigint)

create table CTHoaDon
(MaHoaDon nvarchar(50) foreign key references HoaDon(MaHoaDon),
 MaSanPham nvarchar(50) foreign key references SanPham(MaSanPham),
 SoLuong bigint,
 DonGia bigint,
 ThanhTien bigint,
 primary key(MaHoaDon, MaSanPham))

--create table NguyenLieu
--(MaNguyenLieu nvarchar(50) primary key,
--TenNguyenLieu nvarchar(50))

/*create table Kho
(MaKho nvarchar(50) primary key,
 MaNguyenLieu nvarchar(50) foreign key NguyenLieu(MaNguyenLieu)),*/


 
select CTHoaDon.MaSanPham, SanPham.TenSanPham, CTHoaDon.SoLuong, SanPham.GiaTien, CTHoaDon.GiamGia, CTHoaDon.ThanhTien 
from CTHoaDon, SanPham 
where CTHoaDon.MaSanPham = SanPham.MaSanPham

select * from CTHoaDon
select * from HoaDon

select CTHoaDon.MaSanPham, TenSanPham, SoLuong, DonGia, ThanhTien 
from CTHoaDon, SanPham, HoaDon
where CTHoaDon.MaSanPham = SanPham.MaSanPham
and CTHoaDon.MaHoaDon = HoaDon.MaHoaDon
and CTHoaDon.MaHoaDon like N'HD02'

insert into HoaDon (MaHoaDon, MaNhanVien, NgayLap)
values ('HD03', 'Nv01', '4/4/2023')

insert into CTHoaDon 
values ('SP01', 'HD04', '2', '320000', '0', '320000')

INSERT INTO HoaDon (MaHoaDon, MaNhanVien, NgayLap) VALUES (N'{0}', N'{1}', '{2}')

select * from HoaDon where MaHoaDon like N'HD01'

use QLBanHang
create proc procThanhTien 

CREATE TRIGGER CalculateThanhTien
ON CTHoaDon
AFTER INSERT, UPDATE
AS
BEGIN
    UPDATE CTHoaDon
    SET ThanhTien = (inserted.SoLuong * inserted.DonGia)
    FROM CTHoaDon
    INNER JOIN inserted ON CTHoaDon.MaHoaDon = inserted.MaHoaDon AND CTHoaDon.MaSanPham = inserted.MaSanPham
END;

-- Cập nhật tổng tiền trong bảng HoaDon
UPDATE HoaDon
SET TongTien = (
    SELECT SUM(ThanhTien)
    FROM CTHoaDon
    WHERE CTHoaDon.MaHoaDon = HoaDon.MaHoaDon
);

-- Câu lệnh trên tính tổng giá trị ThanhTien cho mỗi hóa đơn trong bảng HoaDon và cập nhật cột TongTien trong bảng HoaDon với giá trị tính toán.

select * from CTHoaDon where MaHoaDon = 'HD01'

SELECT * FROM CTHoaDon WHERE MaHoaDon = '" + selectedMaHoaDon + "'

INSERT INTO HoaDon VALUES (N'HD05', N'NV01', '2/10/2022', 9)
UPDATE HoaDon SET MaNhanVien = N'nv01', NgayLap = '1/1/2023' WHERE MaHoaDon = N'hd04'

select * from HoaDon
select * from CTHoaDon

INSERT INTO CTHoaDon VALUES (N'HD03', N'SP02', '1', '1', '1')
UPDATE HoaDon SET TongTien = '5' WHERE MaHoaDon = 'hd05'

SELECT TongTien FROM HoaDon WHERE MaHoaDon = 'hd01'

select * from TaiKhoan

insert into NhanVien values (N'nv03', N'my', 'nu', '11/2/2001', N'111', N'hn', N'aa')
select * from NhanVien
select * from SanPham
select * from HoaDon
select * from CTHoaDon
insert into SanPham values (N'sp03', N'bento', '11', N'aa', 'ml01')
select * from SanPham inner join LoaiSanPham on SanPham.MaLoaiSP = LoaiSanPham.MaLoaiSP where TenLoaiSP like N'%bánh%'
UPDATE HoaDon SET MaNhanVien = 'nv01', NgayLap = '1/1/2022' WHERE MaHoaDon = N'HD08'
UPDATE CTHoaDon SET MaSanPham = N'sp01', SoLuong = '6', DonGia = '6', ThanhTien = '6' WHERE MaHoaDon = N'hd08' 

use QLBanHang