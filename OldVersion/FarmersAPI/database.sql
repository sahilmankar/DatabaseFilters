-- MySQL dump 10.13  Distrib 8.0.30, for Win64 (x86_64)
--
-- Host: localhost    Database: eagroservicesdb
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
-- Table structure for table `billing`
--

DROP TABLE IF EXISTS `billing`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `billing` (
  `id` int NOT NULL AUTO_INCREMENT,
  `collectionid` int NOT NULL,
  `labourcharges` double DEFAULT '0',
  `totalamount` double DEFAULT '0',
  `date` datetime NOT NULL DEFAULT CURRENT_TIMESTAMP,
  PRIMARY KEY (`id`),
  KEY `fk_collectionid` (`collectionid`),
  CONSTRAINT `fk_collectionid` FOREIGN KEY (`collectionid`) REFERENCES `collections` (`id`) ON DELETE CASCADE ON UPDATE CASCADE
) ENGINE=InnoDB AUTO_INCREMENT=64 DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `billing`
--

LOCK TABLES `billing` WRITE;
/*!40000 ALTER TABLE `billing` DISABLE KEYS */;
INSERT INTO `billing` VALUES (1,1,240,3600,'2022-01-05 13:30:00'),(2,2,250,4190,'2022-01-03 10:00:00'),(3,3,480,10752,'2022-02-02 09:45:00'),(4,4,375,5565,'2022-02-07 14:00:00'),(5,5,180,2988,'2022-03-04 11:15:00'),(6,6,400,8480,'2022-03-09 15:00:00'),(7,7,300,5604,'2022-04-05 10:30:00'),(8,8,270,3834,'2022-04-08 13:45:00'),(9,9,320,6592,'2022-05-02 09:00:00'),(10,10,325,6227,'2022-05-09 12:15:00'),(11,11,330,4950,'2022-06-03 08:30:00'),(12,12,600,11280,'2022-06-08 11:45:00'),(13,13,425,6919,'2022-07-05 14:00:00'),(14,14,420,6132,'2022-07-08 17:15:00'),(15,15,800,14560,'2022-08-02 10:30:00'),(16,16,550,8954,'2022-08-09 13:45:00'),(17,17,540,8748,'2022-09-05 08:00:00'),(18,18,250,4550,'2022-09-08 11:15:00'),(19,19,480,10464,'2022-10-03 14:30:00'),(20,20,375,5745,'2022-10-06 17:45:00'),(21,21,360,6120,'2022-11-02 10:00:00'),(22,22,360,7848,'2022-11-07 13:15:00'),(23,23,400,7472,'2022-12-05 09:30:00'),(24,24,600,8040,'2022-12-08 12:45:00'),(25,25,600,12000,'2023-01-03 08:00:00'),(26,26,325,5915,'2023-01-06 11:15:00'),(27,27,270,4374,'2023-02-02 14:30:00'),(28,28,320,6784,'2023-02-07 17:45:00'),(29,29,550,8426,'2023-03-07 10:00:00'),(30,30,570,8322,'2023-03-10 13:15:00'),(31,31,800,15520,'2023-04-03 09:30:00'),(32,32,375,5565,'2023-04-06 12:45:00'),(33,33,300,4980,'2023-05-02 08:00:00'),(34,34,480,10464,'2023-05-05 11:15:00');
/*!40000 ALTER TABLE `billing` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `collections`
--

DROP TABLE IF EXISTS `collections`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `collections` (
  `id` int NOT NULL AUTO_INCREMENT,
  `farmerid` int NOT NULL,
  `cropid` int NOT NULL,
  `containertype` enum('crates','bags','lenobags') DEFAULT NULL,
  `quantity` int NOT NULL,
  `grade` enum('A','B','C','D') DEFAULT NULL,
  `totalweight` double NOT NULL,
  `tareweight` double NOT NULL,
  `netweight` double GENERATED ALWAYS AS ((`totalweight` - `tareweight`)) VIRTUAL,
  `rateperkg` double NOT NULL,
  `date` datetime NOT NULL DEFAULT CURRENT_TIMESTAMP ON UPDATE CURRENT_TIMESTAMP,
  PRIMARY KEY (`id`),
  KEY `fk_farmerid` (`farmerid`),
  KEY `fk_cropid` (`cropid`),
  CONSTRAINT `fk_cropid` FOREIGN KEY (`cropid`) REFERENCES `crops` (`id`) ON DELETE CASCADE ON UPDATE CASCADE,
  CONSTRAINT `fk_farmerid` FOREIGN KEY (`farmerid`) REFERENCES `users` (`id`) ON DELETE CASCADE ON UPDATE CASCADE
) ENGINE=InnoDB AUTO_INCREMENT=35 DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `collections`
--

LOCK TABLES `collections` WRITE;
/*!40000 ALTER TABLE `collections` DISABLE KEYS */;
INSERT INTO `collections` (`id`, `farmerid`, `cropid`, `containertype`, `quantity`, `grade`, `totalweight`, `tareweight`, `rateperkg`, `date`) VALUES (1,3,2,'bags',40,'B',200,8,20,'2022-01-05 13:30:00'),(2,3,1,'crates',50,'A',250,10,18.5,'2022-01-03 10:00:00'),(3,3,3,'lenobags',120,'C',600,24,19.5,'2022-02-02 09:45:00'),(4,3,4,'crates',75,'D',375,15,16.5,'2022-02-07 14:00:00'),(5,3,5,'bags',30,'A',150,6,22,'2022-03-04 11:15:00'),(6,3,1,'lenobags',100,'B',500,20,18.5,'2022-03-09 15:00:00'),(7,3,2,'crates',60,'C',300,12,20.5,'2022-04-05 10:30:00'),(8,3,3,'bags',45,'D',225,9,19,'2022-04-08 13:45:00'),(9,3,4,'lenobags',80,'A',400,16,18,'2022-05-02 09:00:00'),(10,3,5,'crates',65,'B',325,13,21,'2022-05-09 12:15:00'),(11,3,1,'bags',55,'C',275,11,20,'2022-06-03 08:30:00'),(12,3,2,'lenobags',150,'D',750,30,16.5,'2022-06-08 11:45:00'),(13,3,3,'crates',85,'A',425,17,18,'2022-07-05 14:00:00'),(14,3,4,'bags',70,'B',350,14,19.5,'2022-07-08 17:15:00'),(15,3,5,'lenobags',200,'C',1000,40,16,'2022-08-02 10:30:00'),(16,3,1,'crates',110,'D',550,22,18,'2022-08-09 13:45:00'),(17,3,2,'bags',90,'A',450,18,21.5,'2022-09-05 08:00:00'),(18,3,3,'crates',50,'B',250,10,20,'2022-09-08 11:15:00'),(19,3,4,'lenobags',120,'C',600,24,19,'2022-10-03 14:30:00'),(20,3,5,'crates',75,'D',375,15,17,'2022-10-06 17:45:00'),(21,3,1,'bags',60,'A',300,12,22.5,'2022-11-02 10:00:00'),(22,3,2,'lenobags',90,'B',450,18,19,'2022-11-07 13:15:00'),(23,3,3,'crates',80,'C',400,16,20.5,'2022-12-05 09:30:00'),(24,3,4,'bags',100,'D',500,20,18,'2022-12-08 12:45:00'),(25,3,5,'lenobags',150,'A',750,30,17.5,'2023-01-03 08:00:00'),(26,3,1,'crates',65,'B',325,13,20,'2023-01-06 11:15:00'),(27,3,2,'bags',45,'C',225,9,21.5,'2023-02-02 14:30:00'),(28,3,3,'lenobags',80,'D',400,16,18.5,'2023-02-07 17:45:00'),(29,3,4,'crates',110,'A',550,22,17,'2023-03-07 10:00:00'),(30,3,5,'bags',95,'B',475,19,19.5,'2023-03-10 13:15:00'),(31,4,1,'lenobags',200,'C',1000,40,17,'2023-04-03 09:30:00'),(32,4,2,'crates',75,'D',375,15,16.5,'2023-04-06 12:45:00'),(33,4,3,'bags',50,'A',250,10,22,'2023-05-02 08:00:00'),(34,4,4,'lenobags',120,'B',600,24,19,'2023-05-05 11:15:00');
/*!40000 ALTER TABLE `collections` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `crops`
--

DROP TABLE IF EXISTS `crops`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `crops` (
  `id` int NOT NULL AUTO_INCREMENT,
  `title` varchar(20) NOT NULL,
  `imageurl` varchar(30) NOT NULL,
  `rate` double NOT NULL DEFAULT '0',
  PRIMARY KEY (`id`),
  UNIQUE KEY `title` (`title`)
) ENGINE=InnoDB AUTO_INCREMENT=9 DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `crops`
--

LOCK TABLES `crops` WRITE;
/*!40000 ALTER TABLE `crops` DISABLE KEYS */;
INSERT INTO `crops` VALUES (1,'Potato','/assets/images/potato.jpeg',32),(2,'Tomato','/assets/images/tomato.jpeg',12),(3,'Cabbage','/assets/images/cabbage.jpeg',21),(4,'Onion','/assets/images/onion.jpg',22),(5,'Bitroot','/assets/images/beetroot.jpeg',30),(6,'Beans','/assets/images/beans.jpeg',29),(7,'Brinjal','/assets/images/Brinjal.jpeg',29),(8,'wheat','/assets/images/wheat.jpeg',29);
/*!40000 ALTER TABLE `crops` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `freightrates`
--

DROP TABLE IF EXISTS `freightrates`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `freightrates` (
  `id` int NOT NULL AUTO_INCREMENT,
  `fromdestination` varchar(50) NOT NULL,
  `todestination` varchar(50) NOT NULL,
  `kilometers` int NOT NULL,
  `rateperkm` double NOT NULL,
  `billid` int NOT NULL,
  PRIMARY KEY (`id`),
  KEY `fk_billid` (`billid`),
  CONSTRAINT `fk_billid` FOREIGN KEY (`billid`) REFERENCES `sellsbilling` (`id`) ON DELETE CASCADE ON UPDATE CASCADE
) ENGINE=InnoDB AUTO_INCREMENT=35 DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `freightrates`
--

LOCK TABLES `freightrates` WRITE;
/*!40000 ALTER TABLE `freightrates` DISABLE KEYS */;
INSERT INTO `freightrates` VALUES (1,'Mumbai','Pune',150,10.5,1),(2,'Mumbai','Nagpur',800,20.2,2),(3,'Mumbai','Nashik',170,11.3,3),(4,'Mumbai','Kolhapur',380,15.8,4),(5,'Mumbai','Aurangabad',350,14.6,5),(6,'Mumbai','Solapur',440,17.3,6),(7,'Mumbai','Amravati',790,20,7),(8,'Mumbai','Jalgaon',420,16.5,8),(9,'Mumbai','Akola',660,19.8,9),(10,'Mumbai','Ratnagiri',340,14.2,10),(11,'Mumbai','Dhule',370,15.5,11),(12,'Mumbai','Ahmednagar',280,12.6,12),(13,'Mumbai','Sangli',410,16,13),(14,'Mumbai','Mumbai',0,0,14),(15,'Mumbai','Thane',30,5,15),(16,'Mumbai','Nagpur',800,20.2,16),(17,'Mumbai','Pune',150,10.5,17),(18,'Mumbai','Nashik',170,11.3,18),(19,'Mumbai','Kolhapur',380,15.8,19),(20,'Mumbai','Aurangabad',350,14.6,20),(21,'Mumbai','Solapur',440,17.3,21),(22,'Mumbai','Amravati',790,20,22),(23,'Mumbai','Jalgaon',420,16.5,23),(24,'Mumbai','Akola',660,19.8,24),(25,'Mumbai','Ratnagiri',340,14.2,25),(26,'Mumbai','Dhule',370,15.5,26),(27,'Mumbai','Ahmednagar',280,12.6,27),(28,'Mumbai','Sangli',410,16,28),(29,'Mumbai','Mumbai',0,0,29),(30,'Mumbai','Thane',30,5,30),(31,'Mumbai','Nagpur',800,20.2,31),(32,'Mumbai','Pune',150,10.5,32),(33,'Mumbai','Nashik',170,11.3,33),(34,'Mumbai','Kolhapur',380,15.8,34);
/*!40000 ALTER TABLE `freightrates` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `labourrates`
--

DROP TABLE IF EXISTS `labourrates`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `labourrates` (
  `containertype` enum('crates','bags','lenobags') NOT NULL,
  `rate` double NOT NULL,
  PRIMARY KEY (`containertype`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `labourrates`
--

LOCK TABLES `labourrates` WRITE;
/*!40000 ALTER TABLE `labourrates` DISABLE KEYS */;
INSERT INTO `labourrates` VALUES ('crates',5),('bags',6),('lenobags',4);
/*!40000 ALTER TABLE `labourrates` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `payments`
--

DROP TABLE IF EXISTS `payments`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `payments` (
  `id` int NOT NULL AUTO_INCREMENT,
  `date` datetime DEFAULT NULL,
  `paymentmode` enum('by cash','by bank transaction') DEFAULT NULL,
  `transactionid` int NOT NULL,
  `billid` int NOT NULL,
  PRIMARY KEY (`id`),
  KEY `fk_bill1id` (`billid`),
  CONSTRAINT `fk_bill1id` FOREIGN KEY (`billid`) REFERENCES `collections` (`id`) ON DELETE CASCADE ON UPDATE CASCADE
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `payments`
--

LOCK TABLES `payments` WRITE;
/*!40000 ALTER TABLE `payments` DISABLE KEYS */;
/*!40000 ALTER TABLE `payments` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `roles`
--

DROP TABLE IF EXISTS `roles`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `roles` (
  `id` int NOT NULL AUTO_INCREMENT,
  `name` varchar(20) DEFAULT NULL,
  PRIMARY KEY (`id`)
) ENGINE=InnoDB AUTO_INCREMENT=6 DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `roles`
--

LOCK TABLES `roles` WRITE;
/*!40000 ALTER TABLE `roles` DISABLE KEYS */;
INSERT INTO `roles` VALUES (1,'admin'),(2,'farmer'),(3,'employee'),(4,'transport'),(5,'merchant');
/*!40000 ALTER TABLE `roles` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `sells`
--

DROP TABLE IF EXISTS `sells`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `sells` (
  `id` int NOT NULL AUTO_INCREMENT,
  `collectionid` int NOT NULL,
  `merchantid` int DEFAULT NULL,
  `vehicleid` int DEFAULT NULL,
  `quantity` int NOT NULL,
  `netweight` double NOT NULL,
  `rateperkg` double NOT NULL DEFAULT '0',
  `date` datetime NOT NULL DEFAULT CURRENT_TIMESTAMP ON UPDATE CURRENT_TIMESTAMP,
  PRIMARY KEY (`id`),
  KEY `fk_collectionid2` (`collectionid`),
  KEY `fk_merchantid` (`merchantid`),
  KEY `fk_vehicleid` (`vehicleid`),
  CONSTRAINT `fk_collectionid2` FOREIGN KEY (`collectionid`) REFERENCES `collections` (`id`) ON DELETE CASCADE ON UPDATE CASCADE,
  CONSTRAINT `fk_merchantid` FOREIGN KEY (`merchantid`) REFERENCES `users` (`id`) ON DELETE CASCADE ON UPDATE CASCADE,
  CONSTRAINT `fk_vehicleid` FOREIGN KEY (`vehicleid`) REFERENCES `vehicles` (`id`) ON DELETE CASCADE ON UPDATE CASCADE
) ENGINE=InnoDB AUTO_INCREMENT=35 DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `sells`
--

LOCK TABLES `sells` WRITE;
/*!40000 ALTER TABLE `sells` DISABLE KEYS */;
INSERT INTO `sells` VALUES (1,1,14,1,10,50,5.5,'2022-03-15 00:00:00'),(2,2,15,2,15,75,6.2,'2022-05-21 00:00:00'),(3,3,16,3,8,40,4.8,'2022-07-07 00:00:00'),(4,4,14,4,12,60,5.6,'2022-08-12 00:00:00'),(5,5,15,5,5,25,5,'2022-09-29 00:00:00'),(6,6,16,6,20,100,6.8,'2022-10-16 00:00:00'),(7,7,14,1,18,90,5.2,'2022-11-25 00:00:00'),(8,8,15,2,7,35,6,'2022-12-03 00:00:00'),(9,9,16,3,14,70,4.5,'2022-12-21 00:00:00'),(10,10,14,4,9,45,5.9,'2023-01-08 00:00:00'),(11,11,15,5,11,55,5.3,'2023-02-14 00:00:00'),(12,12,16,6,6,30,6.5,'2023-03-02 00:00:00'),(13,13,14,1,13,65,5.7,'2023-03-19 00:00:00'),(14,14,15,2,16,80,6.3,'2023-04-06 00:00:00'),(15,15,16,3,4,20,4.2,'2023-04-23 00:00:00'),(16,16,14,4,19,95,5.1,'2023-05-10 00:00:00'),(17,17,15,5,8,40,5.4,'2023-05-27 00:00:00'),(18,18,16,6,11,55,6.7,'2023-06-13 00:00:00'),(19,19,14,1,7,35,4.9,'2023-06-30 00:00:00'),(20,20,15,2,15,75,5.8,'2023-07-17 00:00:00'),(21,21,16,3,10,50,4.4,'2023-08-03 00:00:00'),(22,22,14,4,12,60,6.1,'2023-08-20 00:00:00'),(23,23,15,5,9,45,5.5,'2023-09-06 00:00:00'),(24,24,16,6,6,30,4.7,'2023-09-23 00:00:00'),(25,25,14,1,16,80,6.4,'2023-10-10 00:00:00'),(26,26,15,2,5,25,4.3,'2023-10-27 00:00:00'),(27,27,16,3,18,90,6.6,'2023-11-13 00:00:00'),(28,28,14,4,10,50,5,'2023-11-30 00:00:00'),(29,29,15,5,13,65,5.6,'2023-12-17 00:00:00'),(30,30,16,6,8,40,6.9,'2023-12-31 00:00:00'),(31,31,14,1,11,55,5.2,'2022-01-15 00:00:00'),(32,32,15,2,14,70,6,'2022-02-01 00:00:00'),(33,33,16,3,7,35,4.8,'2022-02-18 00:00:00'),(34,34,14,4,20,100,5.8,'2022-03-05 00:00:00');
/*!40000 ALTER TABLE `sells` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `sellsbilling`
--

DROP TABLE IF EXISTS `sellsbilling`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `sellsbilling` (
  `id` int NOT NULL AUTO_INCREMENT,
  `sellid` int NOT NULL,
  `freightcharges` double DEFAULT '0',
  `labourcharges` double NOT NULL DEFAULT '0',
  `totalcharges` double GENERATED ALWAYS AS ((`freightcharges` + `labourcharges`)) VIRTUAL,
  `totalAmount` double DEFAULT '0',
  `date` datetime NOT NULL DEFAULT CURRENT_TIMESTAMP,
  PRIMARY KEY (`id`),
  KEY `fk_sellid` (`sellid`),
  CONSTRAINT `fk_sellid` FOREIGN KEY (`sellid`) REFERENCES `sells` (`id`) ON DELETE CASCADE ON UPDATE CASCADE
) ENGINE=InnoDB AUTO_INCREMENT=64 DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `sellsbilling`
--

LOCK TABLES `sellsbilling` WRITE;
/*!40000 ALTER TABLE `sellsbilling` DISABLE KEYS */;
INSERT INTO `sellsbilling` (`id`, `sellid`, `freightcharges`, `labourcharges`, `totalAmount`, `date`) VALUES (1,1,1575,240,2090,'2022-03-15 00:00:00'),(2,2,16160,250,16875,'2022-05-21 00:00:00'),(3,3,1921.0000000000002,480,2593,'2022-07-07 00:00:00'),(4,4,6004,375,6715,'2022-08-12 00:00:00'),(5,5,5110,180,5415,'2022-09-29 00:00:00'),(6,6,7612,400,8692,'2022-10-16 00:00:00'),(7,7,15800,300,16568,'2022-11-25 00:00:00'),(8,8,6930,270,7410,'2022-12-03 00:00:00'),(9,9,13068,320,13703,'2022-12-21 00:00:00'),(10,10,4828,325,5418.5,'2023-01-08 00:00:00'),(11,11,5735,330,6356.5,'2023-02-14 00:00:00'),(12,12,3528,600,4323,'2023-03-02 00:00:00'),(13,13,6560,425,7355.5,'2023-03-19 00:00:00'),(14,14,0,420,924,'2023-04-06 00:00:00'),(15,15,150,800,1034,'2023-04-23 00:00:00'),(16,16,16160,550,17194.5,'2023-05-10 00:00:00'),(17,17,1575,540,2331,'2023-05-27 00:00:00'),(18,18,1921.0000000000002,250,2539.5,'2023-06-13 00:00:00'),(19,19,6004,480,6655.5,'2023-06-30 00:00:00'),(20,20,5110,375,5920,'2023-07-17 00:00:00'),(21,21,7612,360,8192,'2023-08-03 00:00:00'),(22,22,15800,360,16526,'2023-08-20 00:00:00'),(23,23,6930,400,7577.5,'2023-09-06 00:00:00'),(24,24,13068,600,13809,'2023-09-23 00:00:00'),(25,25,4828,600,5940,'2023-10-10 00:00:00'),(26,26,5735,325,6167.5,'2023-10-27 00:00:00'),(27,27,3528,270,4392,'2023-11-13 00:00:00'),(28,28,6560,320,7130,'2023-11-30 00:00:00'),(29,29,0,550,914,'2023-12-17 00:00:00'),(30,30,150,570,996,'2023-12-31 00:00:00'),(31,31,16160,800,17246,'2022-01-15 00:00:00'),(32,32,1575,375,2370,'2022-02-01 00:00:00'),(33,33,1921.0000000000002,300,2389,'2022-02-18 00:00:00'),(34,34,6004,480,7064,'2022-03-05 00:00:00');
/*!40000 ALTER TABLE `sellsbilling` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `userroles`
--

DROP TABLE IF EXISTS `userroles`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `userroles` (
  `id` int NOT NULL AUTO_INCREMENT,
  `userid` int NOT NULL,
  `roleid` int NOT NULL,
  PRIMARY KEY (`id`),
  KEY `fk_userid` (`userid`),
  KEY `fk_roleid` (`roleid`),
  CONSTRAINT `fk_roleid` FOREIGN KEY (`roleid`) REFERENCES `roles` (`id`) ON DELETE CASCADE ON UPDATE CASCADE,
  CONSTRAINT `fk_userid` FOREIGN KEY (`userid`) REFERENCES `users` (`id`) ON DELETE CASCADE ON UPDATE CASCADE
) ENGINE=InnoDB AUTO_INCREMENT=17 DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `userroles`
--

LOCK TABLES `userroles` WRITE;
/*!40000 ALTER TABLE `userroles` DISABLE KEYS */;
INSERT INTO `userroles` VALUES (1,1,1),(2,2,1),(3,3,2),(4,4,2),(5,5,2),(6,6,2),(7,7,3),(8,8,3),(9,9,3),(10,10,4),(11,11,4),(12,12,4),(13,13,4),(14,14,5),(15,15,5),(16,16,5);
/*!40000 ALTER TABLE `userroles` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `users`
--

DROP TABLE IF EXISTS `users`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `users` (
  `id` int NOT NULL AUTO_INCREMENT,
  `contactnumber` varchar(15) NOT NULL,
  `firstname` varchar(30) NOT NULL,
  `lastname` varchar(30) NOT NULL,
  `location` varchar(20) NOT NULL,
  `password` varchar(15) NOT NULL,
  PRIMARY KEY (`id`),
  UNIQUE KEY `contactnumber` (`contactnumber`)
) ENGINE=InnoDB AUTO_INCREMENT=18 DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `users`
--

LOCK TABLES `users` WRITE;
/*!40000 ALTER TABLE `users` DISABLE KEYS */;
INSERT INTO `users` VALUES (1,'9078678767','Sahil','Mankar','Pargaon','password'),(2,'9898909090','Anuja','Waghule','Chakan','password'),(3,'9000909807','Shubham','Teli','Bhavadi','password'),(4,'7448022740','Urmila','Toke','Chas','password'),(5,'9090890890','Dipali','Toke','Chas','password'),(6,'9000989899','Akshay','Tanpure','Wada','password'),(7,'8788664324','Rohit','Gore','Satara','password'),(8,'7898090989','Vedant','Yadav','Ratnagiri','password'),(9,'8887654567','Akash','Ajab','Walati','password'),(10,'8989098909','Pragati','Bangar','Pimpalgaon','password'),(11,'8789889098','Pratik','Karale','Karegaon','password'),(12,'9643235646','Akash','More','Bhavadi','password'),(13,'8975321245','Jayesh','Erande','Thugaon','password'),(14,'9765321245','Prajwal','Erande','Thugaon','password'),(15,'8987765456','Rushi','Chikane','Pargaon','password'),(16,'9908999878','Sunny','Teli','BHavadi','password'),(17,'9788788777','Bhushan','Erande','Thugaon','password');
/*!40000 ALTER TABLE `users` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `vehicles`
--

DROP TABLE IF EXISTS `vehicles`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `vehicles` (
  `id` int NOT NULL AUTO_INCREMENT,
  `vendorid` int NOT NULL,
  `vehiclenumber` varchar(15) NOT NULL,
  PRIMARY KEY (`id`),
  UNIQUE KEY `vehiclenumber` (`vehiclenumber`),
  KEY `fk_transportid` (`vendorid`),
  CONSTRAINT `fk_transportid` FOREIGN KEY (`vendorid`) REFERENCES `vendors` (`id`) ON DELETE CASCADE ON UPDATE CASCADE
) ENGINE=InnoDB AUTO_INCREMENT=9 DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `vehicles`
--

LOCK TABLES `vehicles` WRITE;
/*!40000 ALTER TABLE `vehicles` DISABLE KEYS */;
INSERT INTO `vehicles` VALUES (1,1,'MH14RE3456'),(2,1,'MH14RE3455'),(3,2,'MH14RE3465'),(4,2,'MH14RE3476'),(5,3,'MH14RE3856'),(6,3,'MH14RE4656'),(7,4,'MH14RE1234'),(8,4,'MH14RE2345');
/*!40000 ALTER TABLE `vehicles` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `vendors`
--

DROP TABLE IF EXISTS `vendors`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `vendors` (
  `id` int NOT NULL AUTO_INCREMENT,
  `companyname` varchar(20) DEFAULT NULL,
  `transportid` int NOT NULL,
  PRIMARY KEY (`id`),
  KEY `fk_userid3` (`transportid`),
  CONSTRAINT `fk_userid3` FOREIGN KEY (`transportid`) REFERENCES `users` (`id`) ON DELETE CASCADE ON UPDATE CASCADE
) ENGINE=InnoDB AUTO_INCREMENT=5 DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `vendors`
--

LOCK TABLES `vendors` WRITE;
/*!40000 ALTER TABLE `vendors` DISABLE KEYS */;
INSERT INTO `vendors` VALUES (1,'OM Transports',10),(2,'Navale Transport',11),(3,'Karale Transport',12),(4,'Sakore Transport',13);
/*!40000 ALTER TABLE `vendors` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Dumping events for database 'eagroservicesdb'
--

--
-- Dumping routines for database 'eagroservicesdb'
--
/*!50003 DROP PROCEDURE IF EXISTS `ApplyFreightCharges` */;
/*!50003 SET @saved_cs_client      = @@character_set_client */ ;
/*!50003 SET @saved_cs_results     = @@character_set_results */ ;
/*!50003 SET @saved_col_connection = @@collation_connection */ ;
/*!50003 SET character_set_client  = utf8mb4 */ ;
/*!50003 SET character_set_results = utf8mb4 */ ;
/*!50003 SET collation_connection  = utf8mb4_unicode_ci */ ;
/*!50003 SET @saved_sql_mode       = @@sql_mode */ ;
/*!50003 SET sql_mode              = 'IGNORE_SPACE,STRICT_TRANS_TABLES,NO_ENGINE_SUBSTITUTION' */ ;
DELIMITER ;;
CREATE DEFINER=`root`@`localhost` PROCEDURE `ApplyFreightCharges`(IN billId INT)
BEGIN 

	DECLARE totalFreightCharges DOUBLE;

	SELECT freightrates.kilometers * freightrates.rateperkm INTO totalFreightCharges

	FROM freightrates WHERE freightrates.billid = billId  ;

	UPDATE sellsbilling

	SET freightcharges = totalFreightCharges

	WHERE sellsbilling.id = billId;

END ;;
DELIMITER ;
/*!50003 SET sql_mode              = @saved_sql_mode */ ;
/*!50003 SET character_set_client  = @saved_cs_client */ ;
/*!50003 SET character_set_results = @saved_cs_results */ ;
/*!50003 SET collation_connection  = @saved_col_connection */ ;
/*!50003 DROP PROCEDURE IF EXISTS `ApplyLabourCharges` */;
/*!50003 SET @saved_cs_client      = @@character_set_client */ ;
/*!50003 SET @saved_cs_results     = @@character_set_results */ ;
/*!50003 SET @saved_col_connection = @@collation_connection */ ;
/*!50003 SET character_set_client  = utf8mb4 */ ;
/*!50003 SET character_set_results = utf8mb4 */ ;
/*!50003 SET collation_connection  = utf8mb4_unicode_ci */ ;
/*!50003 SET @saved_sql_mode       = @@sql_mode */ ;
/*!50003 SET sql_mode              = 'IGNORE_SPACE,STRICT_TRANS_TABLES,NO_ENGINE_SUBSTITUTION' */ ;
DELIMITER ;;
CREATE DEFINER=`root`@`localhost` PROCEDURE `ApplyLabourCharges`(IN billId INT)
BEGIN 

	DECLARE labourRate DOUBLE DEFAULT 0;

	DECLARE Quantity INT DEFAULT 0;

	DECLARE collection_Id INT ;

	SELECT collectionid INTO collection_Id FROM billing WHERE id = billId;

    SELECT rate INTO labourRate FROM labourrates,collections WHERE  collections.id= collection_Id AND labourrates.containertype=collections.containertype;

    SELECT collections.quantity INTO Quantity  FROM collections WHERE collections.id = collection_Id;

    UPDATE billing SET labourcharges = labourRate * Quantity WHERE id = billId;

END ;;
DELIMITER ;
/*!50003 SET sql_mode              = @saved_sql_mode */ ;
/*!50003 SET character_set_client  = @saved_cs_client */ ;
/*!50003 SET character_set_results = @saved_cs_results */ ;
/*!50003 SET collation_connection  = @saved_col_connection */ ;
/*!50003 DROP PROCEDURE IF EXISTS `ApplyLabourChargesToBilling` */;
/*!50003 SET @saved_cs_client      = @@character_set_client */ ;
/*!50003 SET @saved_cs_results     = @@character_set_results */ ;
/*!50003 SET @saved_col_connection = @@collation_connection */ ;
/*!50003 SET character_set_client  = utf8mb4 */ ;
/*!50003 SET character_set_results = utf8mb4 */ ;
/*!50003 SET collation_connection  = utf8mb4_unicode_ci */ ;
/*!50003 SET @saved_sql_mode       = @@sql_mode */ ;
/*!50003 SET sql_mode              = 'IGNORE_SPACE,STRICT_TRANS_TABLES,NO_ENGINE_SUBSTITUTION' */ ;
DELIMITER ;;
CREATE DEFINER=`root`@`localhost` PROCEDURE `ApplyLabourChargesToBilling`(IN billId INT)
BEGIN 

UPDATE 

    sellsbilling 

    INNER JOIN sells ON sellsbilling.sellid = sells.id

    INNER JOIN collections ON sells.collectionid = collections.id

    INNER JOIN labourrates ON collections.containertype = labourrates.containertype 

SET 

    sellsbilling.labourcharges = collections.quantity * labourrates.rate

WHERE 

    sellsbilling.id =billId;

END ;;
DELIMITER ;
/*!50003 SET sql_mode              = @saved_sql_mode */ ;
/*!50003 SET character_set_client  = @saved_cs_client */ ;
/*!50003 SET character_set_results = @saved_cs_results */ ;
/*!50003 SET collation_connection  = @saved_col_connection */ ;
/*!50003 DROP PROCEDURE IF EXISTS `ApplyTotalAmount` */;
/*!50003 SET @saved_cs_client      = @@character_set_client */ ;
/*!50003 SET @saved_cs_results     = @@character_set_results */ ;
/*!50003 SET @saved_col_connection = @@collation_connection */ ;
/*!50003 SET character_set_client  = utf8mb4 */ ;
/*!50003 SET character_set_results = utf8mb4 */ ;
/*!50003 SET collation_connection  = utf8mb4_unicode_ci */ ;
/*!50003 SET @saved_sql_mode       = @@sql_mode */ ;
/*!50003 SET sql_mode              = 'IGNORE_SPACE,STRICT_TRANS_TABLES,NO_ENGINE_SUBSTITUTION' */ ;
DELIMITER ;;
CREATE DEFINER=`root`@`localhost` PROCEDURE `ApplyTotalAmount`(billId INT)
BEGIN 

	DECLARE total_charges DOUBLE DEFAULT 0 ;

    DECLARE totalAmount DOUBLE DEFAULT 0;

    DECLARE sell_id INT;

	SELECT sellid INTO sell_id FROM sellsbilling WHERE id = billId;

    SELECT totalcharges INTO total_charges FROM sellsbilling WHERE id = billId;

	SELECT sells.netweight * sells.rateperkg INTO totalAmount

	FROM sells WHERE id = sell_id;

	UPDATE sellsbilling

	SET totalamount = totalAmount + total_charges

	WHERE id = billId;

END ;;
DELIMITER ;
/*!50003 SET sql_mode              = @saved_sql_mode */ ;
/*!50003 SET character_set_client  = @saved_cs_client */ ;
/*!50003 SET character_set_results = @saved_cs_results */ ;
/*!50003 SET collation_connection  = @saved_col_connection */ ;
/*!50003 DROP PROCEDURE IF EXISTS `call_procedures` */;
/*!50003 SET @saved_cs_client      = @@character_set_client */ ;
/*!50003 SET @saved_cs_results     = @@character_set_results */ ;
/*!50003 SET @saved_col_connection = @@collation_connection */ ;
/*!50003 SET character_set_client  = utf8mb4 */ ;
/*!50003 SET character_set_results = utf8mb4 */ ;
/*!50003 SET collation_connection  = utf8mb4_unicode_ci */ ;
/*!50003 SET @saved_sql_mode       = @@sql_mode */ ;
/*!50003 SET sql_mode              = 'IGNORE_SPACE,STRICT_TRANS_TABLES,NO_ENGINE_SUBSTITUTION' */ ;
DELIMITER ;;
CREATE DEFINER=`root`@`localhost` PROCEDURE `call_procedures`(IN records INT)
BEGIN

  DECLARE i INT DEFAULT 1;

  WHILE i <= records DO

    CALL ApplyLabourCharges(i);

    CALL DeductLabourChargesFromRevenue(i);

    SET i = i + 1;

  END WHILE;

END ;;
DELIMITER ;
/*!50003 SET sql_mode              = @saved_sql_mode */ ;
/*!50003 SET character_set_client  = @saved_cs_client */ ;
/*!50003 SET character_set_results = @saved_cs_results */ ;
/*!50003 SET collation_connection  = @saved_col_connection */ ;
/*!50003 DROP PROCEDURE IF EXISTS `call_proceduresofsells` */;
/*!50003 SET @saved_cs_client      = @@character_set_client */ ;
/*!50003 SET @saved_cs_results     = @@character_set_results */ ;
/*!50003 SET @saved_col_connection = @@collation_connection */ ;
/*!50003 SET character_set_client  = utf8mb4 */ ;
/*!50003 SET character_set_results = utf8mb4 */ ;
/*!50003 SET collation_connection  = utf8mb4_unicode_ci */ ;
/*!50003 SET @saved_sql_mode       = @@sql_mode */ ;
/*!50003 SET sql_mode              = 'IGNORE_SPACE,STRICT_TRANS_TABLES,NO_ENGINE_SUBSTITUTION' */ ;
DELIMITER ;;
CREATE DEFINER=`root`@`localhost` PROCEDURE `call_proceduresofsells`(IN records INT)
BEGIN

  DECLARE i INT DEFAULT 1;

  WHILE i <= records DO

    CALL ApplyFreightCharges(i);

    CALL ApplyLabourChargesToBilling(i);

    CALL ApplyTotalAmount(i);

    SET i = i + 1;

  END WHILE;

END ;;
DELIMITER ;
/*!50003 SET sql_mode              = @saved_sql_mode */ ;
/*!50003 SET character_set_client  = @saved_cs_client */ ;
/*!50003 SET character_set_results = @saved_cs_results */ ;
/*!50003 SET collation_connection  = @saved_col_connection */ ;
/*!50003 DROP PROCEDURE IF EXISTS `DeductLabourChargesFromRevenue` */;
/*!50003 SET @saved_cs_client      = @@character_set_client */ ;
/*!50003 SET @saved_cs_results     = @@character_set_results */ ;
/*!50003 SET @saved_col_connection = @@collation_connection */ ;
/*!50003 SET character_set_client  = utf8mb4 */ ;
/*!50003 SET character_set_results = utf8mb4 */ ;
/*!50003 SET collation_connection  = utf8mb4_unicode_ci */ ;
/*!50003 SET @saved_sql_mode       = @@sql_mode */ ;
/*!50003 SET sql_mode              = 'IGNORE_SPACE,STRICT_TRANS_TABLES,NO_ENGINE_SUBSTITUTION' */ ;
DELIMITER ;;
CREATE DEFINER=`root`@`localhost` PROCEDURE `DeductLabourChargesFromRevenue`(billId INT)
BEGIN 

	DECLARE revenue DOUBLE DEFAULT 0 ;

    	DECLARE labour_Charges DOUBLE DEFAULT 0;

	DECLARE collection_Id INT;

	SELECT collectionid INTO collection_Id FROM billing WHERE id = billId;

    SELECT labourcharges INTO labour_Charges FROM billing WHERE id = billId;

	SELECT collections.netweight * collections.rateperkg INTO revenue

	FROM collections WHERE id = collection_Id;

	UPDATE billing

	SET totalamount = revenue - labour_Charges

	WHERE id = billId;

END ;;
DELIMITER ;
/*!50003 SET sql_mode              = @saved_sql_mode */ ;
/*!50003 SET character_set_client  = @saved_cs_client */ ;
/*!50003 SET character_set_results = @saved_cs_results */ ;
/*!50003 SET collation_connection  = @saved_col_connection */ ;
/*!40103 SET TIME_ZONE=@OLD_TIME_ZONE */;

/*!40101 SET SQL_MODE=@OLD_SQL_MODE */;
/*!40014 SET FOREIGN_KEY_CHECKS=@OLD_FOREIGN_KEY_CHECKS */;
/*!40014 SET UNIQUE_CHECKS=@OLD_UNIQUE_CHECKS */;
/*!40101 SET CHARACTER_SET_CLIENT=@OLD_CHARACTER_SET_CLIENT */;
/*!40101 SET CHARACTER_SET_RESULTS=@OLD_CHARACTER_SET_RESULTS */;
/*!40101 SET COLLATION_CONNECTION=@OLD_COLLATION_CONNECTION */;
/*!40111 SET SQL_NOTES=@OLD_SQL_NOTES */;

-- Dump completed on 2023-06-12 22:06:50
