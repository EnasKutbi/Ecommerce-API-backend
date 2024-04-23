CREATE DATABASE ecommerce;

CREATE TABLE Customers(
    customer_id SERIAL PRIMARY KEY,
    customer_first_name VARCHAR(50) NOT NULL,
    customer_last_name VARCHAR(50),
    customer_email VARCHAR(50) UNIQUE NOT NULL,
    customer_password VARCHAR(50) NOT NULL,
    customer_address VARCHAR(50) NOT NULL
);