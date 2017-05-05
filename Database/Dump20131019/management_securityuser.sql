CREATE DATABASE  IF NOT EXISTS `management` /*!40100 DEFAULT CHARACTER SET utf8 */;
USE `management`;
-- MySQL dump 10.13  Distrib 5.6.13, for Win32 (x86)
--
-- Host: localhost    Database: management
-- ------------------------------------------------------
-- Server version	5.5.32-MariaDB

/*!40101 SET @OLD_CHARACTER_SET_CLIENT=@@CHARACTER_SET_CLIENT */;
/*!40101 SET @OLD_CHARACTER_SET_RESULTS=@@CHARACTER_SET_RESULTS */;
/*!40101 SET @OLD_COLLATION_CONNECTION=@@COLLATION_CONNECTION */;
/*!40101 SET NAMES utf8 */;
/*!40103 SET @OLD_TIME_ZONE=@@TIME_ZONE */;
/*!40103 SET TIME_ZONE='+00:00' */;
/*!40014 SET @OLD_UNIQUE_CHECKS=@@UNIQUE_CHECKS, UNIQUE_CHECKS=0 */;
/*!40014 SET @OLD_FOREIGN_KEY_CHECKS=@@FOREIGN_KEY_CHECKS, FOREIGN_KEY_CHECKS=0 */;
/*!40101 SET @OLD_SQL_MODE=@@SQL_MODE, SQL_MODE='NO_AUTO_VALUE_ON_ZERO' */;
/*!40111 SET @OLD_SQL_NOTES=@@SQL_NOTES, SQL_NOTES=0 */;

--
-- Table structure for table `securityuser`
--

DROP TABLE IF EXISTS `securityuser`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!40101 SET character_set_client = utf8 */;
CREATE TABLE `securityuser` (
  `UserID` varchar(50) NOT NULL,
  `Password` varchar(50) NOT NULL,
  `Salt` varchar(50) NOT NULL,
  `UserName` varchar(50) DEFAULT NULL,
  `LogonAttempts` int(11) DEFAULT NULL,
  PRIMARY KEY (`UserID`)
) ENGINE=InnoDB DEFAULT CHARSET=latin1;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `securityuser`
--

LOCK TABLES `securityuser` WRITE;
/*!40000 ALTER TABLE `securityuser` DISABLE KEYS */;
INSERT INTO `securityuser` VALUES ('CLIENT01','136','21','CLIENT01',0),('DAN','113','8','DAN',5),('DAN2','163','20','Dan2',0),('DanielLuiz','113','19','Daniel Luiz',0),('DM0001','163','19','Daniel Machado',0),('DM0022','113','17','Daniel Machado User',0),('dm0023','113','17','Daniel Machado User',0),('dm0024','113','17','Daniel Machado',0),('dm0025','113','17','daniel machado',0),('dm0027','113','17','daniel machado',0),('dm0030','113','19','Daniel',0),('dm0031','113','19','daniel',0),('dm0040','113','19','Daniel 40',0),('dm0041','113','19','Daniel',0),('dm0042','113','19','daniel',0),('dm0043','113','19','daniel',0),('dm0044','113','19','daniel',0),('dm0045','113','19','daniel',0),('dm0046','113','20','daniel',0),('dm0050','113','20','daniel',0),('dm0060','113','20','daniel',0),('dm0070','113','20','daniel',0),('dm0100','113','21','daniel',0),('dm0200','113','22','daniel',0),('DM0300','113','7','DANIEL 0300',0),('dm0400','113','7','daniel 0400',0),('GC0001','134','23','Graham Coyle',0);
/*!40000 ALTER TABLE `securityuser` ENABLE KEYS */;
UNLOCK TABLES;
/*!40103 SET TIME_ZONE=@OLD_TIME_ZONE */;

/*!40101 SET SQL_MODE=@OLD_SQL_MODE */;
/*!40014 SET FOREIGN_KEY_CHECKS=@OLD_FOREIGN_KEY_CHECKS */;
/*!40014 SET UNIQUE_CHECKS=@OLD_UNIQUE_CHECKS */;
/*!40101 SET CHARACTER_SET_CLIENT=@OLD_CHARACTER_SET_CLIENT */;
/*!40101 SET CHARACTER_SET_RESULTS=@OLD_CHARACTER_SET_RESULTS */;
/*!40101 SET COLLATION_CONNECTION=@OLD_COLLATION_CONNECTION */;
/*!40111 SET SQL_NOTES=@OLD_SQL_NOTES */;

-- Dump completed on 2013-10-19 18:09:53
