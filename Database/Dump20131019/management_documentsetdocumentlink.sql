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
-- Table structure for table `documentsetdocumentlink`
--

DROP TABLE IF EXISTS `documentsetdocumentlink`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!40101 SET character_set_client = utf8 */;
CREATE TABLE `documentsetdocumentlink` (
  `UID` bigint(20) NOT NULL,
  `FKDocumentSetUID` bigint(20) NOT NULL,
  `FKParentDocumentUID` bigint(20) NOT NULL,
  `FKChildDocumentUID` bigint(20) NOT NULL,
  `LinkType` varchar(10) NOT NULL,
  `IsVoid` char(1) NOT NULL,
  PRIMARY KEY (`UID`),
  KEY `FK_Parent_DSDL_DSD` (`FKParentDocumentUID`),
  KEY `FK_Child_DSDL_DSD` (`FKChildDocumentUID`),
  CONSTRAINT `FK_Child_DSDL_DSD` FOREIGN KEY (`FKChildDocumentUID`) REFERENCES `documentsetdocument` (`UID`),
  CONSTRAINT `FK_Parent_DSDL_DSD` FOREIGN KEY (`FKParentDocumentUID`) REFERENCES `documentsetdocument` (`UID`)
) ENGINE=InnoDB DEFAULT CHARSET=latin1;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `documentsetdocumentlink`
--

LOCK TABLES `documentsetdocumentlink` WRITE;
/*!40000 ALTER TABLE `documentsetdocumentlink` DISABLE KEYS */;
/*!40000 ALTER TABLE `documentsetdocumentlink` ENABLE KEYS */;
UNLOCK TABLES;
/*!40103 SET TIME_ZONE=@OLD_TIME_ZONE */;

/*!40101 SET SQL_MODE=@OLD_SQL_MODE */;
/*!40014 SET FOREIGN_KEY_CHECKS=@OLD_FOREIGN_KEY_CHECKS */;
/*!40014 SET UNIQUE_CHECKS=@OLD_UNIQUE_CHECKS */;
/*!40101 SET CHARACTER_SET_CLIENT=@OLD_CHARACTER_SET_CLIENT */;
/*!40101 SET CHARACTER_SET_RESULTS=@OLD_CHARACTER_SET_RESULTS */;
/*!40101 SET COLLATION_CONNECTION=@OLD_COLLATION_CONNECTION */;
/*!40111 SET SQL_NOTES=@OLD_SQL_NOTES */;

-- Dump completed on 2013-10-19 18:09:45
