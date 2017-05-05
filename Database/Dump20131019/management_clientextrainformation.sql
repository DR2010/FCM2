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
-- Table structure for table `clientextrainformation`
--

DROP TABLE IF EXISTS `clientextrainformation`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!40101 SET character_set_client = utf8 */;
CREATE TABLE `clientextrainformation` (
  `UID` bigint(20) NOT NULL,
  `FKClientUID` bigint(20) DEFAULT NULL,
  `DateToEnterOnPolicies` date DEFAULT NULL,
  `ScopeOfServices` varchar(200) DEFAULT NULL,
  `ActionPlanDate` date DEFAULT NULL,
  `CertificationTargetDate` date DEFAULT NULL,
  `TimeTrading` varchar(200) DEFAULT NULL,
  `RegionsOfOperation` varchar(200) DEFAULT NULL,
  `OperationalMeetingsFrequency` varchar(50) DEFAULT NULL,
  `ProjectMeetingsFrequency` varchar(50) DEFAULT NULL,
  `RecordVersion` bigint(20) DEFAULT NULL,
  `IsVoid` varchar(1) DEFAULT NULL,
  `UpdateDateTime` datetime DEFAULT NULL,
  `UserIdUpdatedBy` varchar(50) DEFAULT NULL,
  `CreationDateTime` datetime DEFAULT NULL,
  `UserIdCreatedBy` varchar(50) DEFAULT NULL,
  PRIMARY KEY (`UID`),
  KEY `FK_CLIENT` (`FKClientUID`),
  CONSTRAINT `FK_CLIENT` FOREIGN KEY (`FKClientUID`) REFERENCES `client` (`UID`) ON DELETE NO ACTION ON UPDATE NO ACTION
) ENGINE=InnoDB DEFAULT CHARSET=latin1;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `clientextrainformation`
--

LOCK TABLES `clientextrainformation` WRITE;
/*!40000 ALTER TABLE `clientextrainformation` DISABLE KEYS */;
INSERT INTO `clientextrainformation` VALUES (1,201200012,'2012-03-22','DANIEL CLIENT TEST 12 SCOPE','2012-03-22','2012-03-22','DANIEL CLIENT TEST 12 TRADING','DANIEL CLIENT TEST 12 REGIONS','DANIEL CLIENT TEST 12 OPERATIONAL','DANIEL CLIENT TEST 12 PROJECT',37,'N','2013-05-22 21:06:53','dm0001','2012-02-25 11:55:59','DM0001'),(4,201200015,'2012-03-22','','2012-03-22','2012-03-22','','','','',2,'N','2012-07-15 22:05:21','DM0001','2012-03-22 21:33:43','DM0001'),(7,201300018,'2013-01-02','Design and construction of comercial landscape projects','2012-12-17','2013-01-11','25 years','NSW, ACT, QLD','Fortnightly ','Fortnightly ',5,'N','2013-01-03 22:32:47','DM0001','2013-01-03 21:41:04','DM0001'),(17,201300027,'2012-10-10','','2014-10-10','2014-10-12','','OPERATIONS','OPERATIONAL','PROJECT',4,'N','2013-06-11 20:27:37','dm0001','2013-02-12 00:00:00','dm0001'),(18,201300028,'2013-02-12','Design and Construction Services for Residential, Commercial and Industrial Projects','2013-02-11','2013-11-01','Since 2000','NSW','Weekly ','Weekly ',2,'N','2013-02-14 21:38:14','dm0001','2013-02-12 00:00:00','GC0001'),(19,201300030,'2013-03-14','specialist building  experienced in all forms of project deliver','2013-03-14','2013-04-30','15 years','ACT, NSW  and International for Commonwealth owned Buildings ','Monthly','Monthly',1,'N','2013-03-07 00:00:00','GC0001','2013-03-07 00:00:00','GC0001'),(21,201300032,'2013-03-07','Plasterboard, Ceilings and Partitions ','2013-03-07','2013-12-16','8 years','ACT and NSW','Monthly','Monthly',1,'N','2013-03-07 00:00:00','GC0001','2013-03-07 00:00:00','GC0001'),(22,201300033,'2013-03-07','Construction of commercial industrial and residential projects','2013-03-07','2013-12-16','20 years','ACT and NSW','Monthly','Monthly',1,'N','2013-03-07 00:00:00','GC0001','2013-03-07 00:00:00','GC0001'),(43,201300054,'2013-02-12','scope of','2013-02-11','2013-11-01','Since 2000','NSW',NULL,NULL,1,'N','2013-04-10 00:00:00','dm0001','2013-04-10 00:00:00','dm0001'),(44,201300055,'2013-02-12','scope of','2013-02-11','2013-11-01','Since 2000','NSW','Weekly ','Weekly ',1,'N','2013-04-10 00:00:00','dm0001','2013-04-10 00:00:00','dm0001'),(45,201300056,'2013-02-12','scope of','2013-02-11','2013-11-01','Since 2000','NSW','Weekly ','Weekly ',1,'N','2013-04-10 00:00:00','dm0001','2013-04-10 00:00:00','dm0001'),(46,201300057,'2013-02-12','scope of','2013-02-11','2013-11-01','Since 2000','NSW, ACT','Weekly  SS','Weekly ',1,'N','2013-04-10 00:00:00','dm0001','2013-04-10 00:00:00','dm0001'),(47,201300058,'2013-02-12','scope of','2013-02-11','2013-11-01','Since 2000','NSW','Weekly ','Weekly ',1,'N','2013-04-10 00:00:00','dm0001','2013-04-10 00:00:00','dm0001'),(48,201300059,'2013-04-15','Replace by scope of services','2013-04-15','2013-04-15','Replace by time trading','Replace by Regions','Weekly','Weekly',1,'N','2013-04-15 21:10:24','dm0100','2013-04-15 21:10:24','dm0100'),(49,201300060,'2013-04-15','Replace by scope of services','2013-04-15','2013-04-15','Replace by time trading','Replace by Regions','Weekly','Weekly',1,'N','2013-04-15 22:58:12','dm0200','2013-04-15 22:58:12','dm0200'),(50,201300061,'2013-04-16','Landscape Construction','2014-04-16','2013-12-15','22 Years','Queensland, South Australia and  ACT','Weekly','Weekly',1,'N','2013-04-16 00:00:00','GC0001','2013-04-16 00:00:00','GC0001'),(51,201300062,'2013-04-15','Replace by scope of services','2013-04-15','2013-04-15','Replace by time trading','Replace by Regions','Weekly','Weekly',1,'N','2013-04-17 00:00:00','dm0001','2013-04-17 00:00:00','dm0001'),(52,201300063,'2013-04-17','Replace by scope of services','2013-04-17','2013-04-17','Replace by time trading','Replace by Regions','Weekly','Weekly',1,'N','2013-04-17 07:37:16','DM0300','2013-04-17 07:37:16','DM0300'),(53,201300064,'2013-04-17','Replace by scope of services','2013-04-17','2013-04-17','Replace by time trading','Replace by Regions','Weekly','Weekly',1,'N','2013-04-17 07:40:48','dm0400','2013-04-17 07:40:48','dm0400'),(54,201300065,'2013-05-22','Replace by scope of services','2013-05-22','2013-05-22','Replace by time trading','Replace by Regions','Weekly','Weekly',1,'N','2013-05-22 21:07:57','BARMCO','2013-05-22 21:07:57','BARMCO'),(55,201300066,'2013-05-22','Replace by scope of services','2013-05-22','2013-05-22','Replace by time trading','Replace by Regions','Weekly','Weekly',1,'N','2013-05-22 21:11:28','CLIENT01','2013-05-22 21:11:28','CLIENT01'),(56,201300067,'2013-04-15','Landscape Construction','2013-04-17','2013-04-17','Replace by time trading','Replace by Regions','Weekly','Weekly',1,'N','2013-05-22 00:00:00','DM0001','2013-05-22 00:00:00','DM0001'),(57,201300068,'2013-05-27','Civil and Structural Engineering','2013-05-27','2013-06-21','Over 15 years','ACT, NSW, QLD, WA','Monthly','Monthly',1,'N','2013-05-26 00:00:00','GC0001','2013-05-26 00:00:00','GC0001'),(58,201300069,'2010-04-01','SCOPE','2012-10-10','2012-10-10','COMP','REGIONS','FREQ','PROJE',1,'N','2013-07-25 00:00:00','dm0001','2013-07-25 00:00:00','dm0001'),(59,201300070,'2013-07-31','N/A','2013-07-31','2013-07-31','21 years','ACT','Weekly','Weekly',1,'N','2013-07-31 00:00:00','dm0001','2013-07-31 00:00:00','dm0001'),(60,201300071,'2013-01-15','Consulting Services','2013-01-15','2014-01-01','12 Years','ACT, NSW','Weekly','Weekly',1,'N','2013-08-08 00:00:00','GC0001','2013-08-08 00:00:00','GC0001'),(61,201300072,'2013-08-24','N/A','2013-08-24','2013-08-24','19 years','ACT','Weekly','Weekly',1,'N','2013-08-24 00:00:00','dm0001','2013-08-24 00:00:00','dm0001'),(62,201300073,'2013-08-31','Electrical & Communications Services','2013-08-31','2014-06-30','30 + years','A.C.T & N.S.W','Weekly and as required','Weekly and as required',1,'N','2013-09-01 00:00:00','GC0001','2013-09-01 00:00:00','GC0001'),(63,201300074,'2013-09-17','Residential, Extensions and Renovations','2014-06-01','2014-06-01','10 years','ACT','Monthly','Monthly',1,'N','2013-09-17 00:00:00','GC0001','2013-09-17 00:00:00','GC0001');
/*!40000 ALTER TABLE `clientextrainformation` ENABLE KEYS */;
UNLOCK TABLES;
/*!40103 SET TIME_ZONE=@OLD_TIME_ZONE */;

/*!40101 SET SQL_MODE=@OLD_SQL_MODE */;
/*!40014 SET FOREIGN_KEY_CHECKS=@OLD_FOREIGN_KEY_CHECKS */;
/*!40014 SET UNIQUE_CHECKS=@OLD_UNIQUE_CHECKS */;
/*!40101 SET CHARACTER_SET_CLIENT=@OLD_CHARACTER_SET_CLIENT */;
/*!40101 SET CHARACTER_SET_RESULTS=@OLD_CHARACTER_SET_RESULTS */;
/*!40101 SET COLLATION_CONNECTION=@OLD_COLLATION_CONNECTION */;
/*!40111 SET SQL_NOTES=@OLD_SQL_NOTES */;

-- Dump completed on 2013-10-19 18:09:50
