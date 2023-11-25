-- Active: 1696576841746@@127.0.0.1@3306@hrm

DROP DATABASE IF EXISTS HRM;
CREATE DATABASE  HRM;

USE HRM;
CREATE TABLE
    departments (
        id INT PRIMARY KEY AUTO_INCREMENT,
        name varchar(40)
    );

CREATE TABLE
    employees(
        id INT PRIMARY KEY AUTO_INCREMENT,
        name VARCHAR (40),
        dateofbirth DATE,
        departmentid INT,
        salary DOUBLE ,
        joiningdate DATE,
        CONSTRAINT fk_dept FOREIGN KEY (departmentid) REFERENCES departments(id) ON UPDATE CASCADE ON DELETE SET NULL
    );


INSERT INTO departments (name) VALUES
    ('Human Resources'),
    ('Finance'),
    ('Marketing'),
    ('IT'),
    ('Operations');

INSERT INTO employees (name, dateofbirth, departmentid, salary, joiningdate) VALUES
    ('Aarav Sharma', '1990-05-15', 1, 60000.00, '2010-07-20'),
    ('Anaya Patel', '1985-08-22', 2, 75000.00, '2015-02-10'),
    ('Advait Verma', '1992-11-30', 3, 55000.00, '2018-09-05'),
    ('Aisha Gupta', '1988-04-18', 4, 80000.00, '2012-11-12'),
    ('Arjun Singh', '1995-07-05', 5, 70000.00, '2016-08-30'),
    
    ('Bhavya Reddy', '1991-02-14', 1, 65000.00, '2014-03-25'),
    ('Bhuvan Joshi', '1987-09-28', 2, 72000.00, '2019-06-15'),
    ('Bhumi Desai', '1994-12-10', 3, 60000.00, '2017-04-18'),
    ('Brijesh Kumar', '1989-06-25', 4, 85000.00, '2013-10-03'),
    ('Bhagya Singh', '1996-03-08', 5, 68000.00, '2015-12-22'),
    
    ('Chetan Yadav', '1993-08-19', 1, 62000.00, '2016-01-08'),
    ('Charvi Mehta', '1986-05-12', 2, 73000.00, '2018-07-12'),
    ('Chirag Kapoor', '1990-11-27', 3, 58000.00, '2019-11-30'),
    ('Chhaya Singh', '1983-04-05', 4, 82000.00, '2014-06-20'),
    ('Chandra Mishra', '1997-01-22', 5, 69000.00, '2017-09-10'),
    
    ('Divya Patel', '1992-06-18', 1, 63000.00, '2013-05-15'),
    ('Dhruv Agarwal', '1984-09-09', 2, 70000.00, '2015-08-02'),
    ('Deepika Verma', '1989-12-03', 3, 59000.00, '2018-01-18'),
    ('Darshan Sharma', '1987-03-28', 4, 83000.00, '2011-04-05'),
    ('Dia Kapoor', '1994-10-14', 5, 67000.00, '2016-12-10');
