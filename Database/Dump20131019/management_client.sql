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
-- Table structure for table `client`
--

DROP TABLE IF EXISTS `client`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!40101 SET character_set_client = utf8 */;
CREATE TABLE `client` (
  `UID` bigint(20) NOT NULL,
  `Name` varchar(200) NOT NULL,
  `LegalName` varchar(200) DEFAULT NULL,
  `Address` varchar(200) DEFAULT NULL,
  `Mobile` varchar(50) DEFAULT NULL,
  `Phone` varchar(50) DEFAULT NULL,
  `Fax` varchar(50) DEFAULT NULL,
  `MainContactPersonName` varchar(50) DEFAULT NULL,
  `EmailAddress` varchar(200) DEFAULT NULL,
  `ABN` varchar(20) DEFAULT NULL,
  `FKUserID` varchar(50) DEFAULT NULL,
  `FKDocumentSetUID` bigint(20) DEFAULT NULL,
  `CreationDateTime` datetime NOT NULL,
  `UpdateDateTime` datetime NOT NULL,
  `UserIdCreatedBy` char(10) NOT NULL,
  `UserIdUpdatedBy` char(10) NOT NULL,
  `IsVoid` char(1) DEFAULT NULL,
  `RecordVersion` bigint(20) DEFAULT NULL,
  `Logo1Location` varchar(200) DEFAULT NULL,
  `Logo2Location` varchar(200) DEFAULT NULL,
  `Logo3Location` varchar(200) DEFAULT NULL,
  `DisplayLogo` char(1) DEFAULT 'Y',
  PRIMARY KEY (`UID`),
  KEY `Client_idx` (`IsVoid`),
  KEY `FK_Client_FCMUser` (`FKUserID`)
) ENGINE=InnoDB DEFAULT CHARSET=latin1;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `client`
--

LOCK TABLES `client` WRITE;
/*!40000 ALTER TABLE `client` DISABLE KEYS */;
INSERT INTO `client` VALUES (201200012,'DANIEL CLIENT TEST 12 ','DANIEL CLIENT TEST 12 ','Shorts Avenue','22222222222','3939393','11111111111','DANIEL CLIENT TEST 12 CONTACT PERSON','danieltestclient12@email.com','093493204','dm0040',1,'2012-02-25 11:55:59','2013-05-22 21:06:15','DM0001','dm0001','N',50,'%LOGOFOLDER%Colgate.png','','','Y'),(201200015,'CAPPELLO COMMERCIAL HYDRAULICS & CIVIL PTY LTD','CAPPELLO COMMERCIAL HYDRAULICS & CIVIL PTY LTD','16 VICTORIA STREET, HALL ACT 2618','0407 419 405','02 6230 9862','02 6230 9863','','ryan@cappelloplumbing.com.au','79 149 790 634',NULL,1,'2012-03-22 21:33:43','2013-01-27 00:00:00','DM0001','DM0001','N',3,'%LOGOFOLDER%Capello.jpg',NULL,NULL,'Y'),(201300018,'Design Landscapes Pty Ltd','Design Landscapes Pty Ltd','586 Willoughby Road \r\nWILLOUGHBY NSW 2068\r\n\r\nPO Box 995\r\nNEUTRAL BAY NSW 2089','0410 319 121 ','02 9958 9400','02 9958 8400','Melinda Watson','info@designls.com','82 003 660 491','',1,'2013-01-03 21:41:04','2013-01-03 22:29:36','DM0001','DM0001','N',5,'%LOGOFOLDER%DesignLandscapes.png','','','Y'),(201300027,'LOCAL NAME TEST','LEGAL NAME TESTE','YYYYYY','23423423','32423423','23423423','','email@gmail.com','25324243242','',1,'2013-02-12 00:00:00','2013-06-11 00:00:00','dm0001','dm0001','N',4,'%LOGOFOLDER%DownArrow2.jpg','','',''),(201300028,'Icon Building Group Pty Ltd ','Icon Building Group Pty Ltd ','13/332 Hoxton Park Road  Prestons  NSW  2170','0418 525 027','02 9607 3577','02 9607 3588','Gino Gigliotti','gino@iconbuilding.com.au','89 104 892 346',NULL,1,'2013-02-12 00:00:00','2013-02-14 00:00:00','GC0001','dm0001','N',2,NULL,NULL,NULL,NULL),(201300030,'Barmco Mana Partnership','Barmco Mana Partnership','4/25 Manuka Circle Forrest ACT 2603','0412 176 473 ','02 6295 9005','02 6295 9005','Steve Wheelhouse','stevew@barmcomana.com ','15994613360',NULL,1,'2013-03-07 00:00:00','2013-03-07 00:00:00','GC0001','GC0001','N',1,NULL,NULL,NULL,NULL),(201300032,'Complete Fixset Plastering Pty Ltd','Complete Fixset Plastering Pty Ltd','Po Box 507 Gungahlin ACT 2912','0418 212 897, 0412 615 547','6253 8053','6242 7686','Ronald Rawson','di@completefixset.com.au','20740871702',NULL,1,'2013-03-07 00:00:00','2013-03-07 00:00:00','GC0001','GC0001','N',1,NULL,NULL,NULL,NULL),(201300033,'A+P Leemhuis','A+P Leemhuis','PO Box 433 Dickson ACT 2602','0418 888 388','(02) 6286 6257','(02) 6286 6855','Darrell Leemhuis','ap.leemhuisbuilders@bigpond.com.au','70748593845',NULL,1,'2013-03-07 00:00:00','2013-03-07 00:00:00','GC0001','GC0001','N',1,'A+P Leemhuis',NULL,NULL,NULL),(201300050,'Euca Constructions Pty Ltd','Euca Constructions Pty Ltd',NULL,NULL,NULL,NULL,NULL,NULL,NULL,NULL,1,'2013-04-10 00:00:00','2013-04-10 00:00:00','GC0001','GC0001','N',1,NULL,NULL,NULL,'Y'),(201300051,'Asset Construction Hire','Asset Construction Hire',NULL,NULL,NULL,NULL,NULL,NULL,NULL,NULL,1,'2013-04-10 00:00:00','2013-04-10 00:00:00','GC0001','GC0001','N',1,NULL,NULL,NULL,'Y'),(201300052,'Bowman Building Services','Bowman Building Services',NULL,NULL,NULL,NULL,NULL,NULL,NULL,NULL,1,'2013-04-10 00:00:00','2013-04-10 00:00:00','GC0001','GC0001','N',1,NULL,NULL,NULL,'Y'),(201300054,'daniel test','dfgd','ddfsfsd',NULL,'32432423',NULL,'',NULL,'343432',NULL,1,'2013-04-10 00:00:00','2013-04-10 00:00:00','dm0001','dm0001','Y',1,NULL,NULL,NULL,NULL),(201300055,'daniel asdsad','dfgd','13/332 Hoxton Park Road  Prestons  NSW  2170','0418 525 027','02 9607 3577','02 9607 3588','Contact person daniel','email@email.com','343432',NULL,1,'2013-04-10 00:00:00','2013-04-10 00:00:00','dm0001','dm0001','Y',1,NULL,NULL,NULL,NULL),(201300056,'daniel test 434','dfgd','FDSFDS','3433','432342','324324','Contact person daniel','email@email.com','343432',NULL,1,'2013-04-10 00:00:00','2013-04-10 00:00:00','dm0001','dm0001','Y',1,NULL,NULL,NULL,NULL),(201300057,'daniel teste 34345435435','dfgd','13/332 Hoxton Park Road  Prestons  NSW  2170','0418 525 027','02 9607 3577','324324','Contact person daniel','email@email.com','343432',NULL,1,'2013-04-10 00:00:00','2013-04-10 00:00:00','dm0001','dm0001','Y',1,NULL,NULL,NULL,NULL),(201300058,'daniel asdasdasdasdasdasd 232','dfgd','13/332 Hoxton Park Road  Prestons  NSW  2170','0418 525 027','02 9607 3577','02 9607 3588','Contact person daniel','email@email.com','343432',NULL,1,'2013-04-10 00:00:00','2013-04-10 00:00:00','dm0001','dm0001','Y',1,NULL,NULL,NULL,NULL),(201300059,'daniel','Legal Name Test','20 ksdksdks st','00000000001','23343433','222222','cperspn','email@email.com','10000000000000000','dm0100',1,'2013-04-15 21:10:24','0001-01-01 00:00:00','dm0100','DM0100','N',2,NULL,NULL,NULL,NULL),(201300060,'daniel','Legal Name Test','20 ksdksdks st','00000000001','23343433','222222','cperspn','email@email.com','10000000000000000','dm0200',1,'2013-04-15 22:58:12','2013-04-15 22:58:12','dm0200','dm0200','N',2,NULL,NULL,NULL,NULL),(201300061,'Dig-It Landscapes Pty Ltd','Dig-It Landscapes Pty Ltd','60 Baxter Street Fortitude Valley, Brisbane',NULL,'07 3257 3970','07 3257 3720','Stewart Brooks','info@digit.com.au','64 010 813 597',NULL,1,'2013-04-16 00:00:00','2013-04-17 00:00:00','GC0001','dm0001','N',2,NULL,NULL,NULL,NULL),(201300062,'daniel test ADMIN','Legal Name Test','20 ksdksdks st','00000000001','23343433','222222','cperspn','email@email.com','10000000000000000',NULL,1,'2013-04-17 00:00:00','2013-04-17 00:00:00','dm0001','dm0001','N',1,NULL,NULL,NULL,NULL),(201300063,'DANIEL 0300','Legal Name Test','20 ksdksdks st','00000000001','23343433','222222','cperspn','email@email.com','10000000000000000','DM0300',1,'2013-04-17 07:37:16','2013-04-17 07:37:16','DM0300','dm0300','N',2,NULL,NULL,NULL,NULL),(201300064,'daniel 0400','Legal Name Test','20 ksdksdks st','00000000001','23343433','222222','cperspn','email@email.com','10000000000000000','dm0400',1,'2013-04-17 07:40:48','2013-04-17 07:40:48','dm0400','dm0400','N',2,NULL,NULL,NULL,NULL),(201300065,'BARMCO',NULL,'',NULL,NULL,NULL,'',NULL,NULL,'BARMCO',0,'2013-05-22 21:07:57','2013-05-22 21:07:57','BARMCO','BARMCO','N',1,NULL,NULL,NULL,NULL),(201300066,'CLIENT01','Legal Name Test','20 ksdksdks st','00000000001','23343433','222222','Stewart Brooks','email@email.com','19292929','CLIENT01',1,'2013-05-22 21:11:28','2013-05-22 21:11:28','CLIENT01','CLIENT01','N',2,NULL,NULL,NULL,NULL),(201300067,'xvxcvcxv','34543WE','20 ksdksdks st','00000000001','23343433','222222','cperspn','email@email.com','324234242',NULL,1,'2013-05-22 00:00:00','2013-05-22 00:00:00','DM0001','DM0001','N',1,NULL,NULL,NULL,NULL),(201300068,'John Skurr Consulting Engineers Pty Ltd','John Skurr Consulting Engineers Pty Ltd','2/23 Bentham Street  Yarralumla ACT 2600','0402 130 163','62824620','N/A','Jason Fulton','john@johnskurr.com.au','121 0098 748 56',NULL,1,'2013-05-26 00:00:00','2013-05-26 00:00:00','GC0001','GC0001','N',1,NULL,NULL,NULL,NULL),(201300069,'TEST 50','LEGAL NAME TEST 50','83 JFDFD','0393938','03939393','393939','CONTACT NAME','EMAIL50@TEST.COM','27272727',NULL,1,'2013-07-25 00:00:00','2013-07-25 00:00:00','dm0001','dm0001','N',1,NULL,NULL,NULL,NULL),(201300070,'Pyramid Corporation PL','Pyramid Corporation PL','9 Deloraine Street Lyons ACT 2606','0418667777','02 62605331','02 62325020','','gclarkepyramidcorp@bigpond.com','67099641871',NULL,1,'2013-07-31 00:00:00','2013-07-31 00:00:00','dm0001','dm0001','N',1,NULL,NULL,NULL,NULL),(201300071,'StratAust CRE Solutions','StratAust Pty Ltd','PO Box 309 Deakin West ACT 2600','0417 001 097','02 6282 6079','N/A','Leanne Aust','leanne.aust@strataust.com.au','34 098 807 428',NULL,1,'2013-08-08 00:00:00','2013-08-08 00:00:00','GC0001','GC0001','N',1,NULL,NULL,NULL,NULL),(201300072,'Aris Building Services Pty Ltd','Aris Building Services Pty Ltd','83 Kendall Avenue, Queanbeyan 2620','0414627608','62996299','62977393','','contact@arisbuilding.com.au','70063338456',NULL,1,'2013-08-24 00:00:00','2013-08-24 00:00:00','dm0001','dm0001','N',1,NULL,NULL,NULL,NULL),(201300073,'Frank O’Sullivan Electrical','FG and S O’Sullivan','111 Woodburn lane Wallaroo Hall ACT 2618','0418622533','0418622533',NULL,'Frank O’Sullivan','melmarmi@gmail.com','28790237625',NULL,1,'2013-09-01 00:00:00','2013-09-01 00:00:00','GC0001','GC0001','N',1,NULL,NULL,NULL,NULL),(201300074,'ADN Builders','AD Schimizzi & MD Schimizzi T/A ADN Builders','8 Freehill Street EVATT ACT 2617','0417 424 408','6258 8604',NULL,'Anthony Schimizzi','adnbuilders@gmail.com','96 675 868 760',NULL,1,'2013-09-17 00:00:00','2013-09-17 00:00:00','GC0001','GC0001','N',1,NULL,NULL,NULL,NULL);
/*!40000 ALTER TABLE `client` ENABLE KEYS */;
UNLOCK TABLES;
/*!40103 SET TIME_ZONE=@OLD_TIME_ZONE */;

/*!40101 SET SQL_MODE=@OLD_SQL_MODE */;
/*!40014 SET FOREIGN_KEY_CHECKS=@OLD_FOREIGN_KEY_CHECKS */;
/*!40014 SET UNIQUE_CHECKS=@OLD_UNIQUE_CHECKS */;
/*!40101 SET CHARACTER_SET_CLIENT=@OLD_CHARACTER_SET_CLIENT */;
/*!40101 SET CHARACTER_SET_RESULTS=@OLD_CHARACTER_SET_RESULTS */;
/*!40101 SET COLLATION_CONNECTION=@OLD_COLLATION_CONNECTION */;
/*!40111 SET SQL_NOTES=@OLD_SQL_NOTES */;

-- Dump completed on 2013-10-19 18:09:48
