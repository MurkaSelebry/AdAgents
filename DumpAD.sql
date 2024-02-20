CREATE DATABASE  IF NOT EXISTS `addb` /*!40100 DEFAULT CHARACTER SET utf8mb4 COLLATE utf8mb4_0900_ai_ci */ /*!80016 DEFAULT ENCRYPTION='N' */;
USE `addb`;
-- MySQL dump 10.13  Distrib 8.0.34, for Win64 (x86_64)
--
-- Host: 127.0.0.1    Database: addb
-- ------------------------------------------------------
-- Server version	8.0.35

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
-- Table structure for table `advertisements`
--

DROP TABLE IF EXISTS `advertisements`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `advertisements` (
  `AdCode` int NOT NULL,
  `TransmissionCode` int DEFAULT NULL,
  `ClientCode` int DEFAULT NULL,
  `DateConclusion` date DEFAULT NULL,
  `Duration` int DEFAULT NULL,
  `AgentCode` int DEFAULT NULL,
  PRIMARY KEY (`AdCode`),
  KEY `TransmissionCode` (`TransmissionCode`),
  KEY `AgentCode` (`AgentCode`),
  KEY `ClientCode` (`ClientCode`),
  CONSTRAINT `advertisements_ibfk_1` FOREIGN KEY (`TransmissionCode`) REFERENCES `transmissions` (`TransmissionCode`),
  CONSTRAINT `advertisements_ibfk_2` FOREIGN KEY (`AgentCode`) REFERENCES `agents` (`AgentCode`),
  CONSTRAINT `advertisements_ibfk_3` FOREIGN KEY (`ClientCode`) REFERENCES `clients` (`ClientCode`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `advertisements`
--

LOCK TABLES `advertisements` WRITE;
/*!40000 ALTER TABLE `advertisements` DISABLE KEYS */;
INSERT INTO `advertisements` VALUES (1,1,1,'2024-02-20',30,1),(2,2,2,'2024-02-21',45,2),(3,NULL,3,'2024-02-22',60,3),(4,4,298981,'2024-01-20',30,4),(5,5,298981,'2024-02-12',45,5),(6,6,298981,'2024-02-19',60,6),(7,7,1,'2024-01-15',30,7),(8,8,2,'2024-02-20',45,8),(9,9,3,'2024-03-10',60,9),(10,10,4,'2024-04-05',30,10),(11,11,5,'2024-05-12',45,11),(12,12,6,'2024-06-20',60,12),(13,13,7,'2024-07-25',30,13),(14,14,8,'2024-08-10',45,14),(15,15,9,'2024-09-05',60,15),(16,16,10,'2024-10-15',30,16),(17,17,11,'2024-11-20',45,17),(18,18,12,'2024-12-10',60,18),(19,19,13,'2025-01-05',30,19),(20,20,14,'2025-02-12',45,20),(21,21,15,'2025-03-20',60,21),(22,22,16,'2025-04-25',30,22),(23,23,17,'2025-05-10',45,23),(24,24,18,'2025-06-05',60,24),(25,25,19,'2025-07-15',30,25),(26,26,20,'2025-08-20',45,26),(27,27,21,'2025-09-10',60,3),(28,28,22,'2025-10-05',30,2),(29,29,23,'2025-11-12',45,1),(30,4,24,'2025-12-20',60,26),(100,1,298981,'2024-02-20',1,1),(210801,2,2,'2024-03-01',2,2),(612334,2,2,'2024-03-01',2,2);
/*!40000 ALTER TABLE `advertisements` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `agents`
--

DROP TABLE IF EXISTS `agents`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `agents` (
  `AgentCode` int NOT NULL,
  `Name` varchar(255) DEFAULT NULL,
  `BankDetails` varchar(255) DEFAULT NULL,
  `Phone` varchar(15) DEFAULT NULL,
  `ContactPerson` varchar(255) DEFAULT NULL,
  `CommissionRate` decimal(5,2) DEFAULT NULL,
  PRIMARY KEY (`AgentCode`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `agents`
--

LOCK TABLES `agents` WRITE;
/*!40000 ALTER TABLE `agents` DISABLE KEYS */;
INSERT INTO `agents` VALUES (1,'fdsf','1','1','1',1.00),(2,'Johnson Marketing','2345678901','555-2222','Emily Johnson',8.75),(3,'Anderson Promotions','3456789012','555-3333','Michael Anderson',9.25),(4,'Brown Advertisements','4567890123','555-4444','Jessica Brown',11.00),(5,'Williams Media','5678901234','555-5555','David Williams',9.00),(6,'Wilson Agency','6789012345','555-6666','Sarah Wilson',10.00),(7,'Taylor Marketing','7890123456','555-7777','Chris Taylor',8.50),(8,'Miller Promotions','8901234567','555-8888','Amanda Miller',9.75),(9,'Martinez Advertisements','9012345678','555-9999','Steven Martinez',10.25),(10,'Clark Media','0123456789','555-1010','Laura Clark',9.50),(11,'Lewis Agency','1234567890','555-2020','Mark Lewis',11.50),(12,'Hall Marketing','2345678901','555-3030','Jennifer Hall',10.75),(13,'Allen Promotions','3456789012','555-4040','Kevin Allen',8.25),(14,'Young Advertisements','4567890123','555-5050','Michelle Young',9.25),(15,'Scott Media','5678901234','555-6060','Ryan Scott',10.50),(16,'Harris Agency','6789012345','555-7070','Emily Harris',8.75),(17,'Green Marketing','7890123456','555-8080','Matthew Green',11.00),(18,'Baker Promotions','8901234567','555-9090','Stephanie Baker',9.00),(19,'King Advertisements','9012345678','555-1112','Jonathan King',10.00),(20,'Carter Media','0123456789','555-2223','Nicole Carter',8.50),(21,'Adams Agency','1234567890','555-3334','Brandon Adams',9.75),(22,'White Marketing','2345678901','555-4445','Amy White',10.25),(23,'Walker Promotions','3456789012','555-5556','David Walker',9.50),(24,'Peterson Advertisements','4567890123','555-6667','Jessica Peterson',10.75),(25,'Stewart Media','5678901234','555-7777','Rachel Stewart',8.25),(26,'Smith Agency','1234567890','555-1111','John Smith',10.50);
/*!40000 ALTER TABLE `agents` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `clients`
--

DROP TABLE IF EXISTS `clients`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `clients` (
  `ClientCode` int NOT NULL,
  `Name` varchar(255) DEFAULT NULL,
  `BankDetails` varchar(255) DEFAULT NULL,
  `Phone` varchar(15) DEFAULT NULL,
  `ContactPerson` varchar(255) DEFAULT NULL,
  PRIMARY KEY (`ClientCode`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `clients`
--

LOCK TABLES `clients` WRITE;
/*!40000 ALTER TABLE `clients` DISABLE KEYS */;
INSERT INTO `clients` VALUES (2,'Johnson Enterprises','2468013579','555-2222','Jessica Johnson'),(3,'Anderson Co.','9870123456','555-3333','David Anderson'),(4,'Brown Industries','8765432109','555-4444','Sarah Brown'),(5,'Williams Group','0123456789','555-5555','Chris Williams'),(6,'Wilson Corporation','9876543210','555-6666','Amanda Wilson'),(7,'Taylor Holdings','8765432109','555-7777','Steven Taylor'),(8,'Miller Enterprises','0123456789','555-8888','Laura Miller'),(9,'Martinez Corporation','1357924680','555-9999','Daniel Martinez'),(10,'Clark & Co.','2468013579','555-1010','Karen Clark'),(11,'Lewis Group','1234567890','555-2020','Mark Lewis'),(12,'Hall Industries','9876543210','555-3030','Jennifer Hall'),(13,'Allen Enterprises','1357902468','555-4040','Kevin Allen'),(14,'Young Corporation','9870123456','555-5050','Michelle Young'),(15,'Scott Holdings','8765432109','555-6060','Ryan Scott'),(16,'Harris & Sons','0123456789','555-7070','Emily Harris'),(17,'Green Co.','2468013579','555-8080','Matthew Green'),(18,'Baker Group','1357924680','555-9090','Stephanie Baker'),(19,'King Industries','1234567890','555-1112','Jonathan King'),(20,'Carter Corporation','9876543210','555-2223','Nicole Carter'),(21,'Adams Enterprises','8765432109','555-3334','Brandon Adams'),(22,'White Holdings','0123456789','555-4445','Amy White'),(23,'Walker & Sons','1357902468','555-5556','David Walker'),(24,'Peterson Co.','2468013579','555-6667','Jessica Peterson'),(25,'Smith & Sons','1357902468','555-1111','Michael Smith'),(83331,'test','1234','1234','test'),(169082,'qwe','123','123','qwer'),(172831,'ty','123','123','dsa'),(280777,'test','1234','1234','test'),(298981,'zxcvb','12345678901','1234567890','zxcvbnm'),(928375,'qwerty','123','123','qwerty');
/*!40000 ALTER TABLE `clients` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `transmissions`
--

DROP TABLE IF EXISTS `transmissions`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `transmissions` (
  `TransmissionCode` int NOT NULL,
  `Title` varchar(255) DEFAULT NULL,
  `Rating` int DEFAULT NULL,
  `CostPerMinute` decimal(5,2) DEFAULT NULL,
  PRIMARY KEY (`TransmissionCode`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `transmissions`
--

LOCK TABLES `transmissions` WRITE;
/*!40000 ALTER TABLE `transmissions` DISABLE KEYS */;
INSERT INTO `transmissions` VALUES (1,'Название передачи 1',5,10.50),(2,'Название передачи 2',4,8.75),(4,'Название передачи 4',5,10.50),(5,'Название передачи 5',4,8.75),(6,'Название передачи 6',3,7.90),(7,'Утренние новости',4,8.50),(8,'Шоу ужасов',3,7.75),(9,'Кулинарный мастер-класс',5,9.25),(10,'Путешествие вокруг света',4,8.75),(11,'Увлекательные документальные фильмы',3,7.90),(12,'Хит-парад топ-40',4,8.25),(13,'Спортивные новости',5,9.00),(14,'Медицинские ток-шоу',3,7.50),(15,'Драматические сериалы',4,8.00),(16,'Шоу смешанных жанров',5,9.50),(17,'Психологические ток-шоу',4,8.60),(18,'Утренняя гимнастика',3,7.80),(19,'Комедийные сериалы',5,9.75),(20,'Приключенческие фильмы',4,8.85),(21,'Исторические документальные фильмы',3,7.95),(22,'Ток-шоу о животных',4,8.15),(23,'Психологические триллеры',5,9.10),(24,'Уроки кулинарии',4,8.35),(25,'Приключения в мире природы',3,7.65),(26,'Ночные новости',4,8.90),(27,'Концертная программа',5,9.15),(28,'Детективные сериалы',4,8.40),(29,'Ток-шоу о политике',3,7.70),(30,'Утренние разминки',5,9.20),(180490,'das',1,1.00);
/*!40000 ALTER TABLE `transmissions` ENABLE KEYS */;
UNLOCK TABLES;
/*!40103 SET TIME_ZONE=@OLD_TIME_ZONE */;

/*!40101 SET SQL_MODE=@OLD_SQL_MODE */;
/*!40014 SET FOREIGN_KEY_CHECKS=@OLD_FOREIGN_KEY_CHECKS */;
/*!40014 SET UNIQUE_CHECKS=@OLD_UNIQUE_CHECKS */;
/*!40101 SET CHARACTER_SET_CLIENT=@OLD_CHARACTER_SET_CLIENT */;
/*!40101 SET CHARACTER_SET_RESULTS=@OLD_CHARACTER_SET_RESULTS */;
/*!40101 SET COLLATION_CONNECTION=@OLD_COLLATION_CONNECTION */;
/*!40111 SET SQL_NOTES=@OLD_SQL_NOTES */;

-- Dump completed on 2024-02-21  0:59:12
