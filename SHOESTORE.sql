 use Store_api 
 drop database SHOESTORE

create database SHOESTORE
use SHOESTORE

CREATE TABLE [Brands] (
  [brand_id] int PRIMARY KEY,
  [brand_name] nvarchar(100),
  [hide] int
)
GO

CREATE TABLE [Category] (
  [category_id] int PRIMARY KEY,
  [category_name] nvarchar(100),
  [hide] int
)
GO

CREATE TABLE [Products] (
  [product_id] varchar(255) PRIMARY KEY,
  [product_name] nvarchar(255),
  [productimage_url] ntext,
  [description] ntext,
  [detail] ntext,
  [hide] int,
  [category_id] int,
  [brand_id] int
)
GO

CREATE TABLE [Inventory] (
  [inventory_id] int PRIMARY KEY,
  [size] varchar(50),
  [price] decimal(10,2),
  [quantity] int,
  [product_id] varchar(255)
)
GO

CREATE TABLE [Cart] (
  [cart_id] nvarchar(255) PRIMARY KEY,
  [size] varchar(50),
  [quantity] int,
  [price] decimal(10,2),
  [product_id] varchar(255),
  [user_id] varchar(255)
)
GO

CREATE TABLE [OrderStatus] (
  [status_id] int PRIMARY KEY,
  [status] varchar(255),
  [hide] int
)
GO

CREATE TABLE [ProductReviews] (
  [product_review_id] varchar(255) PRIMARY KEY,
  [rating] int,
  [comment] ntext,
  [review_date] datetime,
  [product_id] varchar(255),
  [user_id] varchar(255)
)
GO

CREATE TABLE [Orders] (
  [orders_id] varchar(255) PRIMARY KEY,
  [user_phone] varchar(20),
  [orders_date] datetime,
  [shipping_address] ntext,
  [delivery_date] datetime,
  [total_amount] decimal(10,2),
  [user_id] varchar(255),
  [status_id] int
)
GO

CREATE TABLE [OrderDetails] (
  [order_details_id] varchar(255) PRIMARY KEY,
  [price_oder] decimal(10,2),
  [quantity] int,
  [size] varchar(50),
  [product_id] varchar(255),
  [order_id] varchar(255)
)
GO

CREATE TABLE [Role] (
  [role_id] varchar(100) PRIMARY KEY,
  [role_name] varchar(255)
)
GO

CREATE TABLE [Users] (
  [user_id] varchar(255) PRIMARY KEY,
  [name] nvarchar(255),
  [phonenumber] varchar(20),
  [address] ntext,
  [email] varchar(255),
  [password] varchar(20),
  [role_id] varchar(100)
)
GO

CREATE TABLE [Coupons] (
  [coupon_id] varchar(255) PRIMARY KEY,
  [coupon_code] varchar(20),
  [discount_amount] decimal(10,2),
  [expiration_date] datetime,
  [minimum_order_amount] decimal(10,2),
  [description] ntext,
  [hide] int
)
GO

CREATE TABLE [OrdersCoupons] (
  [order_coupon_id] int PRIMARY KEY,
  [order_id] varchar(255),
  [coupon_id] varchar(255)
)
GO

ALTER TABLE [Products] ADD FOREIGN KEY ([category_id]) REFERENCES [Category] ([category_id])
GO

ALTER TABLE [Products] ADD FOREIGN KEY ([brand_id]) REFERENCES [Brands] ([brand_id])
GO

ALTER TABLE [ProductReviews] ADD FOREIGN KEY ([product_id]) REFERENCES [Products] ([product_id])
GO

ALTER TABLE [Inventory] ADD FOREIGN KEY ([product_id]) REFERENCES [Products] ([product_id])
GO

ALTER TABLE [Cart] ADD FOREIGN KEY ([product_id]) REFERENCES [Products] ([product_id])
GO

ALTER TABLE [Cart] ADD FOREIGN KEY ([user_id]) REFERENCES [Users] ([user_id])
GO

ALTER TABLE [ProductReviews] ADD FOREIGN KEY ([user_id]) REFERENCES [Users] ([user_id])
GO

ALTER TABLE [Users] ADD FOREIGN KEY ([role_id]) REFERENCES [Role] ([role_id])
GO

ALTER TABLE [OrderDetails] ADD FOREIGN KEY ([order_id]) REFERENCES [Orders] ([orders_id])
GO

ALTER TABLE [OrderDetails] ADD FOREIGN KEY ([product_id]) REFERENCES [Products] ([product_id])
GO

ALTER TABLE [Orders] ADD FOREIGN KEY ([status_id]) REFERENCES [OrderStatus] ([status_id])
GO

ALTER TABLE [Orders] ADD FOREIGN KEY ([user_id]) REFERENCES [Users] ([user_id])
GO

ALTER TABLE [OrdersCoupons] ADD FOREIGN KEY ([coupon_id]) REFERENCES [Coupons] ([coupon_id])
GO

ALTER TABLE [OrdersCoupons] ADD FOREIGN KEY ([order_id]) REFERENCES [Orders] ([orders_id])
GO

INSERT INTO Brands (brand_id, brand_name, hide)
VALUES
(1, 'Nike', 1),
(2, 'Adidas', 1),
(3, 'Puma', 1),
(4, 'Under Armour', 1),
(5, 'Reebok', 1);

INSERT INTO Category (category_id, category_name, hide)
VALUES
(1, 'Football Shoes', 1),
(2, 'Running Shoes', 1),
(3, 'Basketball Shoes', 1);

INSERT INTO Products (product_id, product_name, productimage_url, description, detail, hide, category_id, brand_id)
VALUES
('P001', 'Nike Mercurial', 'url_to_image1', 'High performance football shoes.', 'Detailed description of Nike Mercurial.', 1, 1, 1),
('P002', 'Adidas Predator', 'url_to_image2', 'Control the game with Predator.', 'Detailed description of Adidas Predator.', 1, 1, 2),
('P003', 'Puma Future', 'url_to_image3', 'Play with style and comfort.', 'Detailed description of Puma Future.', 1, 1, 3),
('P004', 'Under Armour Magnetico', 'url_to_image4', 'Superior fit and feel.', 'Detailed description of Under Armour Magnetico.', 1, 1, 4),
('P005', 'Reebok Royal', 'url_to_image5', 'Classic football shoes.', 'Detailed description of Reebok Royal.', 1, 1, 5),
('P006', 'Nike Phantom', 'url_to_image6', 'Engineered for precision.', 'Detailed description of Nike Phantom.', 1, 1, 1),
('P007', 'Adidas X', 'url_to_image7', 'Fast and lightweight.', 'Detailed description of Adidas X.', 1, 1, 2),
('P008', 'Puma One', 'url_to_image8', 'Perfect balance of speed and comfort.', 'Detailed description of Puma One.', 1, 1, 3),
('P009', 'Under Armour Spotlight', 'url_to_image9', 'Stand out on the field.', 'Detailed description of Under Armour Spotlight.', 1, 1, 4),
('P010', 'Reebok Zig', 'url_to_image10', 'Innovative design for performance.', 'Detailed description of Reebok Zig.', 1, 1, 5);

INSERT INTO Inventory (inventory_id, size, price, quantity, product_id)
VALUES
(1, '8', 99.99, 50, 'P001'),
(2, '9', 99.99, 60, 'P001'),
(3, '8', 89.99, 40, 'P002'),
(4, '9', 89.99, 55, 'P002'),
(5, '8', 79.99, 30, 'P003'),
(6, '9', 79.99, 45, 'P003'),
(7, '8', 109.99, 50, 'P004'),
(8, '9', 109.99, 60, 'P004'),
(9, '8', 69.99, 20, 'P005'),
(10, '9', 69.99, 35, 'P005'),
(11, '8', 119.99, 50, 'P006'),
(12, '9', 119.99, 60, 'P006'),
(13, '8', 129.99, 70, 'P007'),
(14, '9', 129.99, 80, 'P007'),
(15, '8', 139.99, 50, 'P008'),
(16, '9', 139.99, 60, 'P008'),
(17, '8', 149.99, 50, 'P009'),
(18, '9', 149.99, 60, 'P009'),
(19, '8', 159.99, 50, 'P010'),
(20, '9', 159.99, 60, 'P010');

INSERT INTO Cart (cart_id, size, quantity, price, product_id, user_id)
VALUES
('C001', '8', 1, 99.99, 'P001', 'U001'),
('C002', '9', 2, 89.99, 'P002', 'U002');

INSERT INTO OrderStatus (status_id, status, hide)
VALUES
(1, 'Pending', 1),
(2, 'Shipped', 1),
(3, 'Delivered', 1),
(4, 'Cancelled', 1);

INSERT INTO ProductReviews (product_review_id, rating, comment, review_date, product_id, user_id)
VALUES
('PR001', 5, 'Great shoes, very comfortable.', '2023-05-01', 'P001', 'U001'),
('PR002', 4, 'Good quality but a bit pricey.', '2023-06-01', 'P002', 'U002');

INSERT INTO Orders (orders_id, user_phone, orders_date, shipping_address, delivery_date, total_amount, user_id, status_id)
VALUES
('O001', '123456789', '2023-05-01', '123 Street, City', '2023-05-05', 199.98, 'U001', 1),
('O002', '987654321', '2023-06-01', '456 Avenue, City', '2023-06-05', 179.98, 'U002', 2);

INSERT INTO OrderDetails (order_details_id, price_oder, quantity, size, product_id, order_id)
VALUES
('OD001', 99.99, 1, '8', 'P001', 'O001'),
('OD002', 99.99, 1, '9', 'P001', 'O001'),
('OD003', 89.99, 2, '8', 'P002', 'O002');

INSERT INTO Role (role_id, role_name)
VALUES
('R001', 'Admin'),
('R002', 'Customer');

INSERT INTO Users (user_id, name, phonenumber, address, email, password, role_id)
VALUES
('U001', 'John Doe', '123456789', '123 Street, City', 'john@example.com', 'password1', 'R001'),
('U002', 'Jane Smith', '987654321', '456 Avenue, City', 'jane@example.com', 'password2', 'R002');

INSERT INTO Coupons (coupon_id, coupon_code, discount_amount, expiration_date, minimum_order_amount, description, hide)
VALUES
('CP001', 'SAVE10', 10.00, '2024-12-31', 50.00, 'Save $10 on orders over $50', 1),
('CP002', 'FREEDEL', 5.00, '2024-12-31', 30.00, 'Free delivery on orders over $30', 1);

INSERT INTO OrdersCoupons (order_coupon_id, order_id, coupon_id)
VALUES
(1, 'O001', 'CP001'),
(2, 'O002', 'CP002');

