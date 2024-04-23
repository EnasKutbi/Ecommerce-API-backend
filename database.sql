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
--Create Customers Table
CREATE TABLE Customers(
    customer_id SERIAL PRIMARY KEY,
    customer_first_name VARCHAR(50) NOT NULL,
    customer_last_name VARCHAR(50),
    customer_email VARCHAR(50) UNIQUE NOT NULL,
    customer_password VARCHAR(50) NOT NULL,
    customer_address VARCHAR(50) NOT NULL
);

--Insert Customers
INSERT INTO Customers(customer_first_name, customer_last_name, customer_email, customer_password, customer_address)
VALUES
('Yusef', 'Ahmed', 'Y_Ahmed@gmail.com', '12345', 'Egypt'),
('Mai', 'Ali', 'maiali@gmail.com', '857302', 'KSA'),
('Fatimah', 'Mohamed', 'fafmoh@gmail.com', '76321', 'KSA'),
('Enas', 'Kutbi', 'enaskutbi@gmail.com', '0029837', 'KSA'),
('Emtinan', 'Maji', 'emtinanmaji@gmail.com', '5476980', 'KSA');

--Read Customers Table
SELECT * FROM Customers;

--Delete from customers
DELETE FROM Customers
    WHERE customer_address != 'KSA';



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


