CREATE DATABASE  IF NOT EXISTS `hrm` /*!40100 DEFAULT CHARACTER SET utf8mb4 COLLATE utf8mb4_0900_ai_ci */ /*!80016 DEFAULT ENCRYPTION='N' */;
USE `hrm`;
-- MySQL dump 10.13  Distrib 8.0.30, for Win64 (x86_64)
--
-- Host: localhost    Database: hrm
-- ------------------------------------------------------
-- Server version	8.0.30

/*!40101 SET @OLD_CHARACTER_SET_CLIENT=@@CHARACTER_SET_CLIENT */;
/*!40101 SET @OLD_CHARACTER_SET_RESULTS=@@CHARACTER_SET_RESULTS */;
/*!40101 SET @OLD_COLLATION_CONNECTION=@@COLLATION_CONNECTION */;
/*!50503 SET NAMES utf8 */;
/*!40103 SET @OLD_TIME_ZONE=@@TIME_ZONE */;
/*!40103 SET TIME_ZONE='+00:00' */;
/*!40014 SET @OLD_UNIQUE_CHECKS=@@UNIQUE_CHECKS, UNIQUE_CHECKS=0 */;
/*!40014 SET @OLD_FOREIGN_KEY_CHECKS=@@FOREIGN_KEY_CHECKS, FOREIGN_KEY_CHECKS=0 */;
/*!40101 SET @OLD_SQL_MODE=@@SQL_MODE, SQL_MODE='NO_AUTO_VALUE_ON_ZERO' */;
/*!40111 SET @OLD_SQL_NOTES=@@SQL_NOTES, SQL_NOTES=0 */;

--
-- Table structure for table `departments`
--

DROP TABLE IF EXISTS `departments`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `departments` (
  `id` int NOT NULL AUTO_INCREMENT,
  `name` varchar(40) DEFAULT NULL,
  PRIMARY KEY (`id`)
) ENGINE=InnoDB AUTO_INCREMENT=6 DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `departments`
--

LOCK TABLES `departments` WRITE;
/*!40000 ALTER TABLE `departments` DISABLE KEYS */;
INSERT INTO `departments` VALUES (1,'Human Resources'),(2,'Finance'),(3,'Marketing'),(4,'IT'),(5,'Operations');
/*!40000 ALTER TABLE `departments` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `employees`
--

DROP TABLE IF EXISTS `employees`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `employees` (
  `id` int NOT NULL AUTO_INCREMENT,
  `name` varchar(40) DEFAULT NULL,
  `dateofbirth` date DEFAULT NULL,
  `departmentid` int DEFAULT NULL,
  `salary` double DEFAULT NULL,
  `joiningdate` date DEFAULT NULL,
  PRIMARY KEY (`id`),
  KEY `fk_dept` (`departmentid`),
  CONSTRAINT `fk_dept` FOREIGN KEY (`departmentid`) REFERENCES `departments` (`id`) ON DELETE SET NULL ON UPDATE CASCADE
) ENGINE=InnoDB AUTO_INCREMENT=21 DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `employees`
--

LOCK TABLES `employees` WRITE;
/*!40000 ALTER TABLE `employees` DISABLE KEYS */;
INSERT INTO `employees` VALUES (1,'Aarav Sharma','1990-05-15',1,60000,'2010-07-20'),(2,'Anaya Patel','1985-08-22',2,75000,'2015-02-10'),(3,'Advait Verma','1992-11-30',3,55000,'2018-09-05'),(4,'Aisha Gupta','1988-04-18',4,80000,'2012-11-12'),(5,'Arjun Singh','1995-07-05',5,70000,'2016-08-30'),(6,'Bhavya Reddy','1991-02-14',1,65000,'2014-03-25'),(7,'Bhuvan Joshi','1987-09-28',2,72000,'2019-06-15'),(8,'Bhumi Desai','1994-12-10',3,60000,'2017-04-18'),(9,'Brijesh Kumar','1989-06-25',4,85000,'2013-10-03'),(10,'Bhagya Singh','1996-03-08',5,68000,'2015-12-22'),(11,'Chetan Yadav','1993-08-19',1,62000,'2016-01-08'),(12,'Charvi Mehta','1986-05-12',2,73000,'2018-07-12'),(13,'Chirag Kapoor','1990-11-27',3,58000,'2019-11-30'),(14,'Chhaya Singh','1983-04-05',4,82000,'2014-06-20'),(15,'Chandra Mishra','1997-01-22',5,69000,'2017-09-10'),(16,'Divya Patel','1992-06-18',1,63000,'2013-05-15'),(17,'Dhruv Agarwal','1984-09-09',2,70000,'2015-08-02'),(18,'Deepika Verma','1989-12-03',3,59000,'2018-01-18'),(19,'Darshan Sharma','1987-03-28',4,83000,'2011-04-05'),(20,'Dia Kapoor','1994-10-14',5,67000,'2016-12-10');
/*!40000 ALTER TABLE `employees` ENABLE KEYS */;
UNLOCK TABLES;
/*!40103 SET TIME_ZONE=@OLD_TIME_ZONE */;

/*!40101 SET SQL_MODE=@OLD_SQL_MODE */;
/*!40014 SET FOREIGN_KEY_CHECKS=@OLD_FOREIGN_KEY_CHECKS */;
/*!40014 SET UNIQUE_CHECKS=@OLD_UNIQUE_CHECKS */;
/*!40101 SET CHARACTER_SET_CLIENT=@OLD_CHARACTER_SET_CLIENT */;
/*!40101 SET CHARACTER_SET_RESULTS=@OLD_CHARACTER_SET_RESULTS */;
/*!40101 SET COLLATION_CONNECTION=@OLD_COLLATION_CONNECTION */;
/*!40111 SET SQL_NOTES=@OLD_SQL_NOTES */;

-- Dump completed on 2023-12-02 23:07:33
