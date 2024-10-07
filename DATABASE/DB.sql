USE MASTER
CREATE DATABASE db_BanDoAnNhanh
GO
USE db_BanDoAnNhanh
GO

CREATE TABLE Roles (
    id INT IDENTITY(1,1) PRIMARY KEY,
    name NVARCHAR(50) NOT NULL UNIQUE,
    description NVARCHAR(MAX),
    created_at DATETIME DEFAULT GETDATE(),
    updated_at DATETIME DEFAULT GETDATE()
);
GO

-- Tạo bảng Users
CREATE TABLE Users (
    id INT IDENTITY(1,1) PRIMARY KEY,
    role_id INT,
    name NVARCHAR(255) NOT NULL,
    email NVARCHAR(255) UNIQUE NOT NULL,
    password NVARCHAR(255) NOT NULL,
    phone NVARCHAR(15),
    address NVARCHAR(MAX),
    created_at DATETIME DEFAULT GETDATE(),
    updated_at DATETIME DEFAULT GETDATE(),
    FOREIGN KEY (role_id) REFERENCES Roles(id)
);
GO

-- Tạo bảng Categories
CREATE TABLE Categories (
    id INT IDENTITY(1,1) PRIMARY KEY,
    name NVARCHAR(255) NOT NULL,
    description NVARCHAR(MAX),
    created_at DATETIME DEFAULT GETDATE(),
    updated_at DATETIME DEFAULT GETDATE()
);
GO

-- Tạo bảng Products
CREATE TABLE Products (
    id INT IDENTITY(1,1) PRIMARY KEY,
    category_id INT,
    name NVARCHAR(255) NOT NULL,
    description NVARCHAR(MAX),
    price DECIMAL(10,2) NOT NULL,
    image NVARCHAR(255),
    stock INT NOT NULL DEFAULT 0,
    created_at DATETIME DEFAULT GETDATE(),
    updated_at DATETIME DEFAULT GETDATE(),
    FOREIGN KEY (category_id) REFERENCES Categories(id)
);
GO

-- Tạo bảng Orders
CREATE TABLE Orders (
    id INT IDENTITY(1,1) PRIMARY KEY,
    user_id INT,
    total DECIMAL(10,2) NOT NULL,
    status NVARCHAR(20) DEFAULT 'pending',
    created_at DATETIME DEFAULT GETDATE(),
    updated_at DATETIME DEFAULT GETDATE(),
    FOREIGN KEY (user_id) REFERENCES Users(id)
);
GO

-- Tạo bảng Order_Items
CREATE TABLE Order_Items (
    id INT IDENTITY(1,1) PRIMARY KEY,
    order_id INT,
    product_id INT,
    quantity INT NOT NULL,
    price DECIMAL(10,2) NOT NULL,
    created_at DATETIME DEFAULT GETDATE(),
    updated_at DATETIME DEFAULT GETDATE(),
    FOREIGN KEY (order_id) REFERENCES Orders(id),
    FOREIGN KEY (product_id) REFERENCES Products(id)
);
GO

-- Tạo bảng Cart
CREATE TABLE Cart (
    id INT IDENTITY(1,1) PRIMARY KEY,
    user_id INT,
    product_id INT,
    quantity INT NOT NULL,
    created_at DATETIME DEFAULT GETDATE(),
    updated_at DATETIME DEFAULT GETDATE(),
    FOREIGN KEY (user_id) REFERENCES Users(id),
    FOREIGN KEY (product_id) REFERENCES Products(id)
);
GO
