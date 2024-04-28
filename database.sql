CREATE DATABASE ecommerce;

--EMTINAN
--Create Categories Table
CREATE TABLE categories(
    category_id INT PRIMARY KEY,
    category_name VARCHAR(100) NOT NULL,
    category_slug VARCHAR(100) UNIQUE NOT NULL,
    category_description TEXT
);

--Insert Categories
INSERT INTO categories(category_id, category_name, category_slug, category_description)
VALUES
(1, 'Computer & Tablets', 'computer-&-tablets', 'This category includes a wide range of devices, including desktop computers, laptops, tablets, and accessories such as keyboards, mice, and styluses. Customers can find products related to computing and mobile productivity in this category.'),
(2, 'Computer Supplies', 'computer-supplies', 'This category focuses on essential supplies and peripherals for computers, including cables, adapters, storage devices (such as USB flash drives and external hard drives), printer supplies (such as ink cartridges and toner), and other accessories needed to enhance or maintain computer systems.'),
(3, 'Smartphones', 'smartphones', 'This category features a variety of smartphones from different manufacturers, including popular brands like Apple, Samsung, Google, and others. Customers can browse through the latest models, compare features, and find the perfect smartphone to meet their needs.'),
(4, 'Smartwatches', 'smartwatches', 'Smartwatches have become increasingly popular as wearable technology, offering features such as fitness tracking, notifications, and access to apps. This category includes a selection of smartwatches from various brands, providing customers with options to stay connected and track their activities conveniently.'),
(5, 'Smartphones Accessories', 'smartphones-accessories', 'This category complements the smartphones category by offering a range of accessories to enhance the functionality and usability of smartphones. Customers can find items such as cases, screen protectors, chargers, cables, wireless headphones, and other accessories to personalize and protect their smartphones.');

--Read Categories
SELECT * FROM categories;
--DROP TABLE Categories;

--ENAS && nouir
--Create user Table
CREATE TABLE users(
user_id SERIAL PRIMARY KEY,
user_name VARCHAR(100) NOT NULL,
user_email varchar(100) UNIQUE NOT NULL,
user_password varchar(255) NOT NULL,
user_address varchar(100) NOT NULL,
user_image VARCHAR(100),
isAdmin BOOLEAN DEFAULT FALSE,
isBanned BOOLEAN DEFAULT FALSE,
createdAt TIMESTAMP DEFAULT CURRENT_TIMESTAMP
);
--Insert USER
INSERT INTO users(user_name, user_email, user_password, user_address, user_image, isAdmin, isBanned)
VALUES
('Yusef_Ahmed', 'Y_Ahmed@gmail.com', '12345', 'Egypt', 'profile.jpg', FALSE, FALSE),
('Mai_Ali', 'maiali@gmail.com', '857302', 'KSA', 'NULL', FALSE, FALSE),
('Fatimah_Mohamed', 'fafmoh@gmail.com', '76321', 'KSA', 'NULL', TRUE, FALSE),
('Enas_Kutbi', 'enaskutbi@gmail.com', '0029837', 'KSA', 'USER.JPG', TRUE, TRUE),
('Emtinan_Maji', 'emtinanmaji@gmail.com', '5476980', 'KSA', 'profile.jpg', TRUE, TRUE);

--Update a  name column
UPDATE users SET user_name = 'Fatima'
    WHERE user_email = 'fafmoh@gmail.com';

--Read USER Table
SELECT * FROM users;

--Delete from user
DELETE FROM users
    WHERE user_address != 'KSA';

--ATHEER 
-- Orders Table
CREATE TABLE orders(
    order_id SERIAL PRIMARY KEY,
    order_date TIMESTAMP DEFAULT CURRENT_TIMESTAMP,
    order_status VARCHAR(20) DEFAULT 'Pending',
    user_id INT, CONSTRAINT fk_users FOREIGN KEY(user_id) REFERENCES users(user_id),
    order_total INT NOT NULL,
    createdAt TIMESTAMP DEFAULT CURRENT_TIMESTAMP
);

--Insert Orders
INSERT INTO orders(order_date, order_status, user_id, order_total)
VALUES
('2042-04-20', 'Processing', 2, 63),
('2042-04-21', 'Canceled', 3, 222),
('2042-04-19', 'Pending', 3, 57),
('2042-04-20', 'Pending', 4, 88),
('2042-04-22', 'Processing', 5, 92);
 
 -- Read Orders Table
 SELECT * FROM orders;

 --Order_Item Table
 CREATE TABLE order_item(
    order_item SERIAL PRIMARY KEY,
    order_item_quantity INT DEFAULT 0,
    order_id INT, CONSTRAINT fk_orders FOREIGN KEY(order_id) REFERENCES orders(order_id),
    product_id INT, CONSTRAINT fk_products FOREIGN KEY(product_id) REFERENCES products(product_id)
);


--nouir && Enas
--create product table
CREATE TABLE products(
    product_id SERIAL PRIMARY KEY,
    product_name varchar(50) NOT NULL,
    product_slug VARCHAR(100) UNIQUE NOT NULL,
    product_image VARCHAR(100),
    product_description  TEXT NOT NULL,
    product_price DECIMAL(10,2) NOT NULL,
    product_quantity INT DEFAULT 0,
    product_sold INT DEFAULT 0,
    shipping DECIMAL(10,2) DEFAULT 0,
    category_id INT, CONSTRAINT fk_categories FOREIGN KEY(category_id) REFERENCES categories(category_id),
    createdAt TIMESTAMP DEFAULT CURRENT_TIMESTAMP
);
--insert product
INSERT INTO products(product_name, product_slug, product_image, product_description, product_price, product_quantity, product_sold, shipping, category_id, createdAt)
VALUES
('iphone14 pro max', 'iphone14-pro-max', 'iphone14.png', '128GB BLACK COLOR 6.1 INCHES',3000.99, 30, 5, 1, 3, NOW()),
('iphone watch', 'iphone-watch', 'iphone_watch.png', 'New Apple Watch SE (2nd Gen, 2023) [GPS + Cellular 40mm] Smartwatch with Starlight Aluminum Case with Starlight Sport Band S/M. Fitness & Sleep Tracker', 1049.00, 50, 10, 1, 4, NOW()),
('usb-c to Lightning Adapter', 'usb-c-to-Lightning-Adapter', 'usb-ctoLightningAdapter.JPG', 'The Apple 20W USB‑C Power Adapter offers fast, efficient charging at home, in the office, or on the go. Pair it with iPhone 8 or later for fast charging — 50 percent battery in around 30 minutes.¹ Or pair it with the iPad Pro and iPad Air for optimal charging performance. Compatible with any USB-C enabled device.',29, 100, 10, 2, 5, NOW()),
('iphone charger', 'iphone-charger', 'iphone_charger.png', 'The Apple 20W USB‑C Power Adapter offers fast, efficient charging at home, in the office, or on the go. Pair it with iPhone 8 or later for fast charging — 50 percent battery in around 30 minutes.¹ Or pair it with the iPad Pro and iPad Air for optimal charging performance. Compatible with any USB-C enabled device.', 39, 40, 5, 4, 2, NOW()),
('Elevation Lab GoStand Adjustable Stand for iphone', 'Elevation-Lab-GoStand-Adjustable-Stand-for-iphone', 'Elevation.JPG', 'ElevationLab GoStand is the adjustable, lightweight stand for iPhone. The clever design lets you position your screen at a wide range of angles and folds flat to fit in your pocket. It features premium composite and silicone construction with a steel hinge. Precision indexable back support adjusts with a low-profile button. Perfect for streaming Apple Fitness+ workouts, travel, group video, watching movies, gaming, and more', 75.95, 66, 12, 5, 5, NOW()),
('Mophie powerstation', 'Mophie-powerstation', 'Mophie.PNG', 'The mophie powerstation provides fast, portable power with dual USB-C PD ports. That means you can charge two devices at once. Get up to 43 extra hours of power.* Tuck the compact powerstation in your bag, and you are ready for any power demands the day throws at you', 300, 40, 2, 0, 2, NOW());

--READ 
select P.product_id, P.product_name, C.category_name 
from products P
inner join categories C
ON P.category_id = C.category_id;




