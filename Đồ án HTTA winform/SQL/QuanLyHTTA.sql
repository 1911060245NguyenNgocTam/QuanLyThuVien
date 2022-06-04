CREATE DATABASE QuanLyHTTA

USE QuanLyHTTA

GO

----------BẢNG ĐĂNG NHẬP-----------
 CREATE TABLE DANGNHAP
(
	ID int primary key,
	USERNAME varchar (10) not null,
	PASSWORD varchar (5) not null	
)
GO

----------BẢNG ĐỘC GIẢ-----------
CREATE TABLE DOCGIA
(
	MADOCGIA varchar (5) primary key,
	HOTENDOCGIA nvarchar (30) not null, 
	SDTDOCGIA varchar(15) null
)
GO

----------BẢNG NHÂN VIÊN-----------
CREATE TABLE NHANVIEN
(
	MANHANVIEN varchar (5) not null primary key,
	HOTENNHANVIEN nvarchar (30) ,
	SDTNHANVIEN varchar (11) not null,
	DIACHI nvarchar (70) not null,
	PHAI nvarchar (5) not null,
	CHUCVU nvarchar (20) not null,
	ID int not null,
	foreign key (ID) references dbo.DANGNHAP(ID)
)
GO

----------BẢNG TÁC GIẢ-----------
CREATE TABLE TACGIA
(
	MATACGIA varchar (5) not null primary key,
	TENTACGIA nvarchar (30) not null,
)
GO

----------BẢNG NHÀ XUẤT BẢN-----------
CREATE TABLE NHAXUATBAN
(
	MANHAXUATBAN varchar (5) not null primary key,
	TENNHAXUATBAN nvarchar (30) not null,
	SODTNHAXUATBAN varchar (11) not null,
	DIACHI nvarchar (70) not null 
)
GO
DROP TABLE NHAXUATBAN

----------BẢNG THỂ LOẠI-----------
CREATE TABLE THELOAI
(
	MATHELOAI varchar (5) not null primary key,
	TENTHELOAI nvarchar (20) not null,
)
GO

----------BẢNG SÁCH-----------
CREATE TABLE SACH
(
	MASACH varchar (5) not null primary key,
	TENSACH nvarchar (70) not null,
	NAMXUATBAN date not null,
	SOLUONG int not null,
	MANHAXUATBAN varchar(5) not null,
	MATHELOAI varchar (5) not null,
	SOTRANG int not null, 
	MATACGIA varchar (5) not null,
    foreign key (MANHAXUATBAN) references dbo.NHAXUATBAN(MANHAXUATBAN), 
	foreign key (MATHELOAI) references dbo.THELOAI(MATHELOAI),
	foreign key (MATACGIA) references dbo.TACGIA(MATACGIA)
)
GO
DROP TABLE SACH
----------BẢNG CHI TIẾT VIẾT-----------
/* CREATE TABLE CHITIETVIET
(
	MASACH varchar(5) not null,
	MATACGIA varchar (5) not null,
	VAITRO nvarchar (200) not null,
	foreign key (MASACH) references dbo.SACH(MASACH),
	foreign key (MATACGIA) references dbo.TACGIA(MATACGIA)
)
GO
*/
----------BẢNG PHIẾU MƯỢN SÁCH-----------
CREATE TABLE PHIEUMUONSACH
(
	MAMUONSACH varchar (5) not null primary key,
	NGAYCAP date not null,
	NGAYMUON datetime not null,
	MADOCGIA varchar (5) not null,
	MANHANVIEN varchar (5) not null,
	foreign key (MADOCGIA) references dbo.DOCGIA(MADOCGIA),
	foreign key (MANHANVIEN) references dbo.NHANVIEN(MANHANVIEN)
)
ALTER TABLE PHIEUMUONSACH
ALTER COLUMN NGAYMUON date not null
GO
-- alter table dbo.PHIEUMUONSACH add constraint fk_NV foreign key (MANHANVIEN) references dbo.NHANVIEN(MANHANVIEN)
----------BẢNG CHI TIẾT PHIẾU MƯỢN SÁCH-----------
CREATE TABLE CTPHIEUMUONSACH
(
	NGAYTRA datetime not null,
	MASACH varchar(5) not null,
	MAMUONSACH varchar(5) not null,
	foreign key (MASACH) references dbo.SACH(MASACH),
	foreign key (MAMUONSACH) references dbo.PHIEUMUONSACH(MAMUONSACH)
)
ALTER TABLE CTPHIEUMUONSACH
ALTER COLUMN NGAYTRA date not null
GO
----------BẢNG PHIẾU PHẠT-----------
CREATE TABLE PHIEUPHAT
(
	MAPHIEUPHAT varchar (5) not null primary key,
	NGAYPHAT date not null,
	LYDOPHAT nvarchar (50) not null,
	HINHTHUCPHAT nvarchar (50) ,
	MADOCGIA varchar(5) not null,
	MANHANVIEN varchar (5) not null,
	MASACH varchar(5) not null,
	MAMUONSACH varchar(5) not null,
	foreign key (MADOCGIA) references dbo.DOCGIA(MADOCGIA),
	foreign key (MANHANVIEN) references dbo.NHANVIEN(MANHANVIEN),
	foreign key (MASACH) references dbo.SACH(MASACH),
	foreign key (MAMUONSACH) references dbo.PHIEUMUONSACH(MAMUONSACH)
)
GO
----------BẢNG LỆ PHÍ-----------


----------BẢNG CHI TIẾT PHIẾU PHẠT-----------
CREATE TABLE CTPHIEUPHAT
(
	MAPHIEUPHAT varchar (5) not null,
	MAMUONSACH varchar (5) not null,
	SOTIENPHAIDONG int,
	foreign key (MAPHIEUPHAT) references dbo.PHIEUPHAT(MAPHIEUPHAT),
	foreign key (MAMUONSACH) references dbo.PHIEUMUONSACH(MAMUONSACH)
)
GO
INSERT DANGNHAP
VALUES (1,N'QUANLY','1')
INSERT DANGNHAP
VALUES (2,N'THUTHU','1')
INSERT DANGNHAP
VALUES (3,N'THUTHU1','1')
delete DANGNHAP where ID = 0
select *from DANGNHAP

INSERT NHANVIEN
VALUES ('NV1',N'Nguyễn Ngọc Tâm',N'0909099000',N'Quận 12','Nam', N'Quản lý',1)
INSERT NHANVIEN
VALUES ('NV2',N'Phạm Huỳnh Tuấn Anh',N'0909099021',N'Quận Gò Vấp','Nam', N'Thủ thư',2)
INSERT NHANVIEN
VALUES ('NV3',N'Nguyễn Việt Hưng',N'0933999122',N'Quận Bình Thạnh','Nam', N'Thủ thư',3)
select *from NHANVIEN

INSERT DOCGIA
VALUES (N'DG1',N'Trần Văn Dương', N'0906111222')
INSERT DOCGIA
VALUES (N'DG2',N'Trần Văn Bình', N'0906156222')
INSERT DOCGIA
VALUES (N'DG3',N'Trần Văn Bỉnh', N'0906156452')
INSERT DOCGIA
VALUES (N'DG4',N'Trần Thị Nở', N'0906123652')
INSERT DOCGIA
VALUES (N'DG5',N'Nguyễn Thị Bình',N'0776156222')
INSERT DOCGIA
VALUES (N'DG6',N'Lý Thức', N'0766156222')
INSERT DOCGIA
VALUES (N'DG7',N'Trần Chí Phèo', N'0776912222')
INSERT DOCGIA
VALUES (N'DG8',N'Nguyễn Ngọc Hân', N'0763321123')
INSERT DOCGIA
VALUES (N'DG9',N'Trần Văn Lượng', N'0776123123')
INSERT DOCGIA
VALUES (N'DG10',N'Trần Tiến', N'0763321123')
delete DOCGIA 
select *from DOCGIA

INSERT TACGIA
VALUES (N'TG1', N'Nguyễn Nhật Ánh')
INSERT TACGIA
VALUES (N'TG2', N'Hạ Vũ')
INSERT TACGIA
VALUES (N'TG3', N'Nam Cao')
INSERT TACGIA
VALUES (N'TG4', N' Fujiko F. Fujio')
INSERT TACGIA
VALUES (N'TG5', N'Ngô Tất Tố')
INSERT TACGIA
VALUES (N'TG6', N'Vũ Trọng Phụng')
INSERT TACGIA
VALUES (N'TG7', N'Trần Minh Thái')
INSERT TACGIA
VALUES (N'TG8', N'Thạch Lam')
INSERT TACGIA
VALUES (N'TG9', N'Hồng Nương Tử')
INSERT TACGIA
VALUES (N'TG10', N'Sái Tuấn')
INSERT TACGIA
VALUES (N'TG11', N'Dan Ariely')
INSERT TACGIA
VALUES (N'TG12', N'Daniel Gilbert')
INSERT TACGIA
VALUES (N'TG13', N'Barry Schwartz')
INSERT TACGIA
VALUES (N'TG14', N'Viktor Emil Frankl')
INSERT TACGIA
VALUES (N'TG15', N'TS. David J. Lieberman')
INSERT TACGIA
VALUES (N'TG16', N'Nhà văn Nguyễn Quang Lập')
INSERT TACGIA
VALUES (N'TG17', N'Trần Đăng Khoa')
INSERT TACGIA
VALUES (N'TG18', N'Vương Trí Nhàn')
INSERT TACGIA
VALUES (N'TG19', N'Hector Malot')
INSERT TACGIA
VALUES (N'TG20', N'Lewis Carrol')
INSERT TACGIA
VALUES (N'TG21', N'Aesop')
INSERT TACGIA
VALUES (N'TG22', N'Harper Lee')
INSERT TACGIA
VALUES (N'TG23', N'Phùng Quán')
INSERT TACGIA
VALUES (N'TG24', N'Colleen McCullough')
INSERT TACGIA
VALUES (N'TG25', N'Tolkien')
INSERT TACGIA
VALUES (N'TG26', N'Hector Malot')
INSERT TACGIA
VALUES (N'TG27', N'Phạm Văn Ất')
INSERT TACGIA
VALUES (N'TG28', N'Nguyễn Hiển')
INSERT TACGIA
VALUES (N'TG29', N'James Wallace')
INSERT TACGIA
VALUES (N'TG30', N'Simon Cheshire')
INSERT TACGIA
VALUES (N'TG31', N'Rob Hansen')
INSERT TACGIA
VALUES (N'TG32', N'GreenStar - Thuỳ Dương')
INSERT TACGIA
VALUES (N'TG33', N'Nguyễn Đông Thức')
INSERT TACGIA
VALUES (N'TG34', N'Erin Gruwell')
INSERT TACGIA
VALUES (N'TG35', N'Đông Giang')
INSERT TACGIA
VALUES (N'TG36', N'Lê Hoàng')
delete TACGIA
select *from TACGIA

INSERT NHAXUATBAN
VALUES (N'NXB1', N'Nhà Xuất Bản Trẻ', N'0773122311', N'Lý Chính Thắng Quận 3 TPHCM')
INSERT NHAXUATBAN
VALUES (N'NXB2', N'Nhà Xuất Bản Giáo Dục', N'0777566611', N'Phan Huy Ích Quận Tân Bình TPHCM')
INSERT NHAXUATBAN
VALUES (N'NXB3', N'Nhà Xuất Bản Thống Kê', N'0776122012', N'Nam Kì Khởi Nghĩa Quận 1 TPHCM')
INSERT NHAXUATBAN
VALUES (N'NXB4', N'Nhà Xuất Bản Văn Học', N'0776323122', N'Nguyễn Ảnh Thủ Quận 12 TPHCM')
INSERT NHAXUATBAN
VALUES (N'NXB5', N'Nhà xuất bản Kim Đồng', N'1900571595', N'Số 55 Quang Trung, Nguyễn Du, Hai Bà Trưng, Hà Nội')
INSERT NHAXUATBAN
VALUES (N'NXB6', N'Nhà xuất bản Lý luận chính trị', N'02437472541', N'56B Quốc Tử Giám, Đống Đa, Hà Nội')
delete NHAXUATBAN
select *from NHAXUATBAN


INSERT THELOAI
VALUES (N'TL1', N'Ngôn Tình')
INSERT THELOAI
VALUES (N'TL2', N'Công Nghệ Thông Tin')
INSERT THELOAI
VALUES (N'TL3', N'Tâm Lý')
INSERT THELOAI
VALUES (N'TL4', N'Chính Trị')
INSERT THELOAI
VALUES (N'TL5', N'Truyện Ngắn')
INSERT THELOAI
VALUES (N'TL6', N'Truyện Ngụ Ngôn')
INSERT THELOAI
VALUES (N'TL7', N'Văn Học')
INSERT THELOAI
VALUES (N'TL8', N'Truyện Dài')
select *from THELOAI

INSERT INTO PHIEUMUONSACH
VALUES (N'PMS1', '2018-3-15', '2020-2-14', N'DG1', N'NV2')
INSERT INTO PHIEUMUONSACH
VALUES (N'PMS2', '2018-4-13', '2019-4-20', N'DG2', N'NV2')
INSERT INTO PHIEUMUONSACH
VALUES (N'PMS3', '2016-1-12', '2019-7-19', N'DG3', N'NV2')
INSERT INTO PHIEUMUONSACH
VALUES (N'PMS4', '2014-12-1', '2018-12-3', N'DG4', N'NV3')
INSERT INTO PHIEUMUONSACH
VALUES (N'PMS5', '2018-1-3', '2019-4-12', N'DG5', N'NV3')
INSERT INTO PHIEUMUONSACH
VALUES (N'PMS6', '2015-2-4', '2017-12-3', N'DG6', N'NV3')
INSERT INTO PHIEUMUONSACH
VALUES (N'PMS7', '2019-9-6', '2019-12-9', N'DG7', N'NV2')
INSERT INTO PHIEUMUONSACH
VALUES (N'PMS8', '2019-8-12', '2020-4-1', N'DG8', N'NV3')
INSERT INTO PHIEUMUONSACH
VALUES (N'PMS9', '2019-12-5', '2020-4-12', N'DG9', N'NV2')
INSERT INTO PHIEUMUONSACH
VALUES (N'PMS10', '2020-4-12', '2020-5-12', N'DG10', N'NV3')
delete PHIEUMUONSACH
select *from PHIEUMUONSACH

insert into CTPHIEUMUONSACH
values ('2020-2-18','MS1','PMS1')
insert into CTPHIEUMUONSACH
values ('2019-5-1','MS5','PMS2')
insert into CTPHIEUMUONSACH
values ('2019-7-21','MS9','PMS3')
insert into CTPHIEUMUONSACH
values ('2018-12-9','MS10','PMS4')
insert into CTPHIEUMUONSACH
values ('2019-4-22','MS11','PMS5')
insert into CTPHIEUMUONSACH
values ('2017-12-9','MS12','PMS6')
insert into CTPHIEUMUONSACH
values ('2019-12-22','MS2','PMS7')
insert into CTPHIEUMUONSACH
values ('2020-4-11','MS10','PMS8')
insert into CTPHIEUMUONSACH
values ('2020-4-29','MS5','PMS9')
insert into CTPHIEUMUONSACH
values ('2020-5-20','MS2','PMS10')

Delete CTPHIEUMUONSACH
Select *from CTPHIEUMUONSACH

insert into SACH 
values(N'MS1',N'Nhập môn công nghệ phần mềm','2007-4-14',10,N'NXB1',N'TL2',200,'TG7')
insert into SACH 
values(N'MS2',N'Hôm nay tôi thất tình','2015-12-4',15,N'NXB3',N'TL1',350,'TG2')
insert into SACH 
values(N'MS3',N'Kĩ thuật lập trình','2009-1-12',8,N'NXB1',N'TL2',300,'TG7' )
insert into SACH 
values(N'MS4',N'Tôi thấy hoa vàng trên cỏ xanh','2012-11-10',10,N'NXB1',N'TL8', 400,'TG1')
insert into SACH 
values(N'MS5',N'Tắt đèn','1939-4-12',20,N'NXB4',N'TL7',500,'TG5')
insert into SACH 
values(N'MS6',N'Số đỏ','2009-3-15',8,N'NXB4',N'TL7', 700,'TG6')
insert into SACH 
values(N'MS7',N'Gió đầu mùa','1969-11-12',10,N'NXB4',N'TL7', 400,'TG8')
insert into SACH 
values(N'MS8',N'Đi qua hoa cúc','2001-4-12',10,N'NXB1',N'TL8', 500,'TG1')
insert into SACH 
values(N'MS9',N'Cấu trúc dữ liệu và giải thuật','2014-4-12',9,N'NXB1',N'TL2', 300,'TG7')
insert into SACH 
values(N'MS10',N'Tấm vải đỏ','2004-6-22',9,N'NXB1',N'TL3', 700,'TG9')
insert into SACH 
values(N'MS11',N'Địa ngục tầng thứ 19','2001-12-4',10,N'NXB1',N'TL3', 800,'TG10')
insert into SACH 
values(N'MS12',N'Phi Lý Trí','2014-09-4',50,N'NXB6',N'TL3',399,'TG11')
insert into SACH 
values(N'MS13',N'Tình Cờ Gặp Hạnh Phúc','2019-10-23',50,N'NXB6',N'TL3',399,'TG12')
insert into SACH 
values(N'MS14',N'Nghịch Lý Của Sự Lựa Chọn','2020-12-21',2,N'NXB6',N'TL3',502,'TG13')
insert into SACH 
values(N'MS15',N'Đi Tìm Lẽ Sống','2021-02-23',6,N'NXB6',N'TL3',321,'TG14')
insert into SACH 
values(N'MS16',N'Đọc Vị Bất Kỳ Ai','2011-03-26',0,N'NXB6',N'TL3',334,'TG15')
insert into SACH 
values(N'MS17',N'Kính Vạn Hoa','2021-09-16',13,N'NXB5',N'TL4',98,'TG16')
insert into SACH 
values(N'MS18',N'Góc Sân và Khoảng Trời','2020-09-22',15,N'NXB5',N'TL4',24,'TG17')
insert into SACH 
values(N'MS19',N'Tuổi Thơ Im Lặng','2017-09-11',5,N'NXB5',N'TL4',67,'TG18')
insert into SACH 
values(N'MS20',N'Không gia đình','2016-09-01',11,N'NXB5',N'TL4',63,'TG19')
insert into SACH 
values(N'MS21',N'Alice ở xứ sở diệu kỳ','2014-09-09',22,N'NXB5',N'TL4',76,'TG20')
insert into SACH 
values(N'MS22',N'Rùa và thỏ','2014-4-14',10,N'NXB5',N'TL6',54,'TG21')
insert into SACH 
values(N'MS23',N'Cậu bé chăn cừu','2013-5-7',10,N'NXB5',N'TL6',34,'TG21')
insert into SACH 
values(N'MS24',N'Con cáo và chùm nho','2015-7-21',10,N'NXB5',N'TL6',60,'TG21')
insert into SACH 
values(N'MS25',N'Chuyện cổ Grim','2012-6-20',10,N'NXB5',N'TL6',72,'TG21')
insert into SACH 
values(N'MS26',N'Rùa và Thỏ','2014-4-14',10,N'NXB5',N'TL6',54,'TG21')
insert into SACH 
values(N'MS27',N'Sư tử và chuột','2013-6-12',10,N'NXB5',N'TL6',24,'TG21')
insert into SACH 
values(N'MS28',N'Giết con chim nhại','2007-5-11',8,N'NXB4',N'TL7',140,'TG22')
insert into SACH 
values(N'MS29',N'Tuổi thơ dữ dội','2009-6-24',20,N'NXB5',N'TL7',122,'TG23')
insert into SACH 
values(N'MS30',N'Tiếng chim hót trong bụi mận gai','2012-7-20',15,N'NXB4',N'TL7',260,'TG24')
insert into SACH 
values(N'MS31',N'Anh chàng Hobbits','2013-8-20',15,N'NXB4',N'TL7',146,'TG25')
insert into SACH 
values(N'MS32',N'Không gia đình','2012-7-14',15,N'NXB4',N'TL7',241,'TG26')
INSERT INTO SACH
VALUES (N'MS33', N'Anh chính là thanh xuân của em','2018-07-5', 20, N'NXB1', N'TL1',200, N'TG2')
INSERT INTO SACH
VALUES (N'MS34', N'Anh không thương em','2019-08-25', 10,N'NXB1',N'TL1',250, N'TG2')
INSERT INTO SACH
VALUES (N'MS35', N'Mùa hạ thoáng qua','2016-04-30',20, N'NXB1', N'TL1',299, N'TG2')
INSERT INTO SACH
VALUES (N'MS36', N'Có một người từng là tất cả','2016-09-23',10, N'NXB1', N'TL1',300, N'TG2')
INSERT INTO SACH
VALUES (N'MS37', N'Nữ sinh','2019-09-10',12, N'NXB1', N'TL1',150, N'TG1')
INSERT INTO SACH
VALUES (N'MS38', N'GIAO TRINH C++','2020-03-5',50, N'NXB2', N'TL2',200, N'TG21')
INSERT INTO SACH
VALUES (N'MS39', N'DevUP','2019-03-7',10, N'NXB2', N'TL2',201, N'TG22')
INSERT INTO SACH
VALUES (N'MS40', N'BILL GATE','2010-03-29',14, N'NXB2', N'TL2',299, N'TG23')
INSERT INTO SACH
VALUES (N'MS41', N'CODE COMPLETE','2017-05-18',10, N'NXB2', N'TL2',300, N'TG24')
INSERT INTO SACH
VALUES (N'MS42', N'Lập trình ngầu hết sẩy','2018-07-5', 10,N'NXB2', N'TL2',250, N'TG25')
INSERT INTO SACH
VALUES (N'MS43', N'Yêu người không nên yêu','2012-01-5', 8,N'NXB4', N'TL5',150, N'TG32')
INSERT INTO SACH
VALUES (N'MS44', N'Vĩnh biệt Facebook','2001-04-1', 7,N'NXB1', N'TL5',100, N'TG33')
INSERT INTO SACH
VALUES (N'MS45', N'Viết lên hy vọng','1999-02-27', 12,N'NXB3', N'TL5',200, N'TG34')
INSERT INTO SACH
VALUES (N'MS46', N'Thất tình tạm thời','2012-06-12', 3,N'NXB4', N'TL5',100, N'TG35')
INSERT INTO SACH
VALUES (N'MS47', N'Anh không là con chó của em','2011-09-09', 2,N'NXB2', N'TL5',100, N'TG36')
INSERT INTO SACH
VALUES (N'MS48', N'Chú khủng long của Nobita','1980-03-01', 10,N'NXB5', N'TL5',200, N'TG4')
INSERT INTO SACH
VALUES (N'MS49', N'Nobita và hành tinh muông thú','1989-03-06', 10,N'NXB5', N'TL5',200, N'TG4')
INSERT INTO SACH
VALUES (N'MS50', N'Nobita và nước Nhật thời nguyên thủy','1988-10-01', 10,N'NXB5', N'TL5',150, N'TG4')
INSERT INTO SACH
VALUES (N'MS51', N'Nobita và mê cung thiếc','1992-09-01', 10,N'NXB5', N'TL5',150, N'TG4')
INSERT INTO SACH
VALUES (N'MS52', N'Nobita và vương quốc trên mây','1991-10-01', 10,N'NXB5', N'TL5',200, N'TG4')
delete SACH
Select *from SACH

insert into PHIEUPHAT
values(N'PP1','2021-08-24',N'Không trả sách đúng hạn',N'Đóng phạt 10000',N'DG1','NV2',N'MS1','PMS1')
insert into PHIEUPHAT
values(N'PP2','2021-09-01',N'Không trả sách đúng hạn lần 2 ',N'Đóng phạt 30000',N'DG2','NV2',N'MS10','PMS2')
insert into PHIEUPHAT
values(N'PP3','2021-09-04',N'Làm rách sách',N'Đóng phạt 50000',N'DG3','NV2',N'MS5','PMS3')
insert into PHIEUPHAT
values(N'PP4','2021-09-08',N'Không trả sách đúng hạn',N'Đóng phạt 10000',N'DG4','NV3',N'MS1','PMS4')
insert into PHIEUPHAT
values(N'PP5','2021-09-17',N'Làm rách sách',N'Đóng phạt 50000',N'DG5','NV3',N'MS7','PMS5')
insert into PHIEUPHAT
values(N'PP6','2021-09-21',N'Không trả sách đúng hạn lần 3',N'Đóng 10000 và bị cấm mượn sách 30 ngày',N'DG6','NV3',N'MS1','PMS6')
insert into PHIEUPHAT
values(N'PP7','2021-09-23',N'Làm nhăn sách',N'Đóng phạt 20000',N'DG7','NV2',N'MS4','PMS7')
insert into PHIEUPHAT
values(N'PP8','2021-09-26',N'Làm rách sách',N'Đóng phạt 50000',N'DG8','NV3',N'MS1','PMS8')
insert into PHIEUPHAT
values(N'PP9','2021-09-27',N'Không trả sách đúng hạn',N'Đóng phạt 10000',N'DG9','NV2',N'MS6','PMS9')
insert into PHIEUPHAT
values(N'PP10','2021-08-27',N'Làm rách sách',N'Đóng phạt 50000',N'DG10','NV2',N'MS6','PMS10')

Delete PHIEUPHAT
Select *from PHIEUPHAT

insert into CTPHIEUPHAT
values (N'PP1',N'PMS1', 10000)
insert into CTPHIEUPHAT
values (N'PP2',N'PMS2', 30000)
insert into CTPHIEUPHAT
values (N'PP3',N'PMS3', 50000)
insert into CTPHIEUPHAT
values (N'PP4',N'PMS4', 10000)
insert into CTPHIEUPHAT
values (N'PP5',N'PMS5', 50000)
insert into CTPHIEUPHAT
values (N'PP6',N'PMS6', 10000)
insert into CTPHIEUPHAT
values (N'PP7',N'PMS7', 20000)
insert into CTPHIEUPHAT
values (N'PP8',N'PMS8', 50000)
insert into CTPHIEUPHAT
values (N'PP9',N'PMS9', 10000)
insert into CTPHIEUPHAT
values (N'PP10',N'PMS10',50000)
delete CTPHIEUPHAT
Select *from CTPHIEUPHAT