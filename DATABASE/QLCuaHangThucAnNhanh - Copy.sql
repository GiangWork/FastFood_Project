use master
go
create database QLCuaHangThucAnNhanh
go
use QLCuaHangThucAnNhanh
go

create table [Role]
(
	roleId int primary key,
	roleName nvarchar(50),
	CreateBy nvarchar(50),
	CreateTime datetime,
	lastUpdateBy nvarchar(50),
	lastUpdateTime datetime,
	deleteBy nvarchar(50),
	deleteTime datetime
)

create table [User]
(
	userId int primary key,
	userName nvarchar(50),
	password nvarchar(200),
	email nvarchar(200),
	roleId int,
	CreateBy nvarchar(50),
	CreateTime datetime,
	lastUpdateBy nvarchar(50),
	lastUpdateTime datetime,
	deleteBy nvarchar(50),
	deleteTime datetime,
	constraint fk_u_r foreign key (roleId) references [Role](roleId)
)

create table UserInfo
(
	userInfoId int primary key,
	userId int,
	fullName nvarchar(50),
	phone nvarchar(11),
	gender nvarchar(5),
	address nvarchar(100),
	CreateBy nvarchar(50),
	CreateTime datetime,
	lastUpdateBy nvarchar(50),
	lastUpdateTime datetime,
	deleteBy nvarchar(50),
	deleteTime datetime,
	constraint fk_ui_u foreign key (userId) references [User](userId) 
)

create table Product
(
	productId int primary key, 
	productName nvarchar(50),
	description nvarchar(200),
	price decimal,
	categoryId int,
	CreateBy nvarchar(50),
	CreateTime datetime,
	lastUpdateBy nvarchar(50),
	lastUpdateTime datetime,
	deleteBy nvarchar(50),
	deleteTime datetime
)

create table Cart
(
	cartId int primary key,
	userId int,
	CreateBy nvarchar(50),
	CreateTime datetime,
	lastUpdateBy nvarchar(50),
	lastUpdateTime datetime,
	deleteBy nvarchar(50),
	deleteTime datetime,
	constraint fk_c_u foreign key(userId) references [User](userId)
)

create table CartItem
(
	cartItemId int primary key,
	cartId int,
	productId int,
	quantity int,
	price decimal,
	CreateBy nvarchar(50),
	CreateTime datetime,
	lastUpdateBy nvarchar(50),
	lastUpdateTime datetime,
	deleteBy nvarchar(50),
	deleteTime datetime,
	constraint fk_ci_c foreign key (cartId) references Cart(cartId),
	constraint fk_ci_p foreign key (productId) references Product(productId)
)

create table [Order]
(
	orderId int primary key,
	userId int,
	totalPrice decimal,
	paymentStatus nvarchar(30),
	shippingAddress nvarchar(200),
	orderStatus nvarchar(20),
	CreateBy nvarchar(50),
	CreateTime datetime,
	lastUpdateBy nvarchar(50),
	lastUpdateTime datetime,
	deleteBy nvarchar(50),
	deleteTime datetime,
	constraint fk_o_u foreign key (userId) references [User](userId)
)

create table OrderDetail
(
	orderDetailId int primary key,
	orderId int,
	productId int,
	quantity int,
	price decimal,
	totalPrice decimal,
	CreateBy nvarchar(50),
	CreateTime datetime,
	lastUpdateBy nvarchar(50),
	lastUpdateTime datetime,
	deleteBy nvarchar(50),
	deleteTime datetime,
	constraint fk_od_o foreign key (orderId) references [Order](orderId),
	constraint fk_o_p foreign key (productId) references Product(productId)
)

create table Category
(
	categoryId int primary key,
	categoryName nvarchar(50),
	CreateBy nvarchar(50),
	CreateTime datetime,
	lastUpdateBy nvarchar(50),
	lastUpdateTime datetime,
	deleteBy nvarchar(50),
	deleteTime datetime
)

create table ProductImage
(
	productImageId int primary key,
	productId int, 
	urlImage nvarchar(200),
	primaryImage bit,
	altText nvarchar(200),
	CreateBy nvarchar(50),
	CreateTime datetime,
	lastUpdateBy nvarchar(50),
	lastUpdateTime datetime,
	deleteBy nvarchar(50),
	deleteTime datetime,
	constraint fk_pi_p foreign key (productId) references Product(productId)
)