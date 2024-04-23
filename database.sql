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
--Create Cusromers Table
CREATE TABLE Customers(
    customer_id SERIAL PRIMARY KEY,
    customer_first_name VARCHAR(50) NOT NULL,
    customer_last_name VARCHAR(50),
    customer_email VARCHAR(50) UNIQUE NOT NULL,
    customer_password VARCHAR(50) NOT NULL,
    customer_address VARCHAR(50) NOT NULL
);
