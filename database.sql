CREATE DATABASE ecommerce;

--EMTINAN
--Create Categories Table
CREATE TABLE Categories(
    Category_id INT PRIMARY KEY,
    Category_name VARCHAR(50) UNIQUE NOT NULL,
    Category_description TEXT
);

--Insert Categories
INSERT INTO Categories(Category_id,Category_name,Category_description)
VALUES
(1, 'Computer & Tablets' ,'This category includes a wide range of devices, including desktop computers, laptops, tablets, and accessories such as keyboards, mice, and styluses. Customers can find products related to computing and mobile productivity in this category.'),
(2, 'Computer Supplies', ' This category focuses on essential supplies and peripherals for computers, including cables, adapters, storage devices (such as USB flash drives and external hard drives), printer supplies (such as ink cartridges and toner), and other accessories needed to enhance or maintain computer systems.'),
(3, 'Smartphones','This category features a variety of smartphones from different manufacturers, including popular brands like Apple, Samsung, Google, and others. Customers can browse through the latest models, compare features, and find the perfect smartphone to meet their needs.'),
(4, 'Smartwatches','Smartwatches have become increasingly popular as wearable technology, offering features such as fitness tracking, notifications, and access to apps. This category includes a selection of smartwatches from various brands, providing customers with options to stay connected and track their activities conveniently.'),
(5, 'Smartphones Accessories','This category complements the smartphones category by offering a range of accessories to enhance the functionality and usability of smartphones. Customers can find items such as cases, screen protectors, chargers, cables, wireless headphones, and other accessories to personalize and protect their smartphones.');

--Read Categories
SELECT * FROM Categories;

--ENAS
--Create user Table

CREATE TABLE users(
user_id SERIAL PRIMARY KEY,
user_name VARCHAR(100) NOT NULL,
user_email varchar(100) UNIQUE NOT NULL,
user_password varchar(255) NOT NULL,
user_address varchar(100) NOT NULL,
isAdmin BOOLEAN DEFAULT FALSE,
isBanned BOOLEAN DEFAULT FALSE,
createdAt TIMESTAMP DEFAULT CURRENT_TIMESTAMP
);
--Insert USER
INSERT INTO users(user_name ,user_email, user_password, user_address,user_image,isAdmin,isBanned)
VALUES
('Yusef Ahmed', 'Y_Ahmed@gmail.com', '12345', 'Egypt','profile.jpg',TRUE,FALSE),
('Mai Ali', 'maiali@gmail.com', '857302', 'KSA','NULL',TRUE,FALSE),
('Fatimah Mohamed', 'fafmoh@gmail.com', '76321', 'KSA','NULL',FALSE,FALSE),
('Enas Kutbi', 'enaskutbi@gmail.com', '0029837', 'KSA','USER.JPG',TRUE,FALSE),
('Emtinan Maji', 'emtinanmaji@gmail.com', '5476980', 'KSA','NULL',FALSE,TRUE);

--Update a  name column
UPDATE users SET Customer_first_name = 'Fatima'
    WHERE Customer_email = 'fafmoh@gmail.com';

--Read USER Table
SELECT * FROM users;

--Delete from user
DELETE FROM users
    WHERE user_address != 'KSA';

--ATHEER 
-- Orders Table
CREATE TABLE Orders(
    Order_id SERIAL PRIMARY KEY,
    Order_Date TIMESTAMP DEFAULT CURRENT_TIMESTAMP,
    Order_Status VARCHAR(20) NOT NULL,
    Order_Total INT NOT NULL,
    customer_id INT, CONSTRAINT fk_Customers FOREIGN KEY(customer_id) REFERENCES Customers(Customer_id)
);

--Insert Orders
INSERT INTO Orders(Order_Status, Order_Total)
VALUES
('Processing', 63),
('Canceled', 222),
('Pending', 57),
('Pending', 88),
('Processing', 92);
 
 -- Read Orders Table
 SELECT * FROM Orders;

 --Order_Item Table
 CREATE TABLE Order_Item(
    Order_Item SERIAL PRIMARY KEY,
    order_id INT, CONSTRAINT fk_Orders FOREIGN KEY(order_id) REFERENCES Orders(Order_id),
    product_id INT, CONSTRAINT fk_Products FOREIGN KEY(product_id) REFERENCES Products(Product_id)
);


--nouir 
--create product table
CREATE TABLE PRODUCTS(
    product_id INT PRIMARY KEY,
    product_name varchar(50) NOT NULL,
    product_price FLOAT NOT NULL,
    product_description  TEXT NOT NULL,
    category_id INT ,FOREIGN KEY  (category_id) REFERENCES Categories(Category_id)
);
--insert product
INSERT INTO PRODUCTS(product_id,product_name,product_price,product_description ,category_id)
VALUES
(1011,'iphone14 pro max',3000.100,'128GB BLACK COLOR 6.1 INCHES',3),
(1022,'iphone watch',1049.00,'New Apple Watch SE (2nd Gen, 2023) [GPS + Cellular 40mm] Smartwatch with Starlight Aluminum Case with Starlight Sport Band S/M. Fitness & Sleep Tracker',4),
(1033,'usb-c to Lightning Adapter',29,'The Apple 20W USB‑C Power Adapter offers fast, efficient charging at home, in the office, or on the go. Pair it with iPhone 8 or later for fast charging — 50 percent battery in around 30 minutes.¹ Or pair it with the iPad Pro and iPad Air for optimal charging performance. Compatible with any USB-C enabled device.',2),
(1044,'iphone charger',39,'The Apple 20W USB‑C Power Adapter offers fast, efficient charging at home, in the office, or on the go. Pair it with iPhone 8 or later for fast charging — 50 percent battery in around 30 minutes.¹ Or pair it with the iPad Pro and iPad Air for optimal charging performance. Compatible with any USB-C enabled device.',2),
(1055,'Elevation Lab GoStand Adjustable Stand for iphone',75.95,'ElevationLab GoStand is the adjustable, lightweight stand for iPhone. The clever design lets you position your screen at a wide range of angles and folds flat to fit in your pocket. It features premium composite and silicone construction with a steel hinge. Precision indexable back support adjusts with a low-profile button. Perfect for streaming Apple Fitness+ workouts, travel, group video, watching movies, gaming, and more',5),
(1066,'Mophie powerstation',300,'The mophie powerstation provides fast, portable power with dual USB-C PD ports. That means you can charge two devices at once. Get up to 43 extra hours of power.* Tuck the compact powerstation in your bag, and you are ready for any power demands the day throws at you',2);

--READ 
select P.product_id , P.product_name , C.Category_name 
from PRODUCTS P
inner join Categories C
ON P.Category_id=C.Category_id;




