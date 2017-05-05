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
-- Table structure for table `reportmetadata`
--

DROP TABLE IF EXISTS `reportmetadata`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!40101 SET character_set_client = utf8 */;
CREATE TABLE `reportmetadata` (
  `UID` bigint(20) NOT NULL,
  `RecordType` varchar(2) NOT NULL,
  `FieldCode` varchar(50) DEFAULT NULL,
  `Description` varchar(200) DEFAULT NULL,
  `ClientType` varchar(10) DEFAULT NULL,
  `ClientUID` bigint(20) DEFAULT NULL,
  `InformationType` varchar(10) NOT NULL,
  `TableNameX` varchar(50) DEFAULT NULL,
  `FieldNameX` varchar(50) DEFAULT NULL,
  `FilePathX` varchar(50) DEFAULT NULL,
  `FileNameX` varchar(50) DEFAULT NULL,
  `ConditionX` varchar(200) DEFAULT NULL,
  `CompareWith` varchar(100) DEFAULT NULL,
  `Enabled` char(1) DEFAULT NULL,
  `UseAsLabel` varchar(1) DEFAULT NULL,
  PRIMARY KEY (`UID`)
) ENGINE=InnoDB DEFAULT CHARSET=latin1;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `reportmetadata`
--

LOCK TABLES `reportmetadata` WRITE;
/*!40000 ALTER TABLE `reportmetadata` DISABLE KEYS */;
INSERT INTO `reportmetadata` VALUES (92,'DF','**FIRM**','Company Name','',0,'FIELD',NULL,NULL,NULL,NULL,'SELECT NAME FROM CLIENT WHERE UID = @UID','CLIENT.UID','Y','N'),(93,'DF','**ADDRESS**','Address','',0,'FIELD',NULL,NULL,NULL,NULL,'SELECT ADDRESS FROM CLIENT WHERE UID = @UID','CLIENT.UID','Y','N'),(94,'DF','**PM**','Project Manager Name','',0,'FIELD',NULL,NULL,NULL,NULL,'select NAME from EMPLOYEE where RoleType = \'PM1\' and FKCompanyUID = @UID','CLIENT.UID','Y','N'),(95,'DF','LOGO1','Logo - small','',0,'IMAGE',NULL,NULL,NULL,NULL,'SELECT Logo1Location FROM CLIENT WHERE UID = @UID','CLIENT.UID','Y','N'),(96,'DF','**MD1**','Managing Director','',0,'FIELD',NULL,NULL,NULL,NULL,'select NAME from EMPLOYEE where RoleType = \'MD1\' and FKCompanyUID = @UID','CLIENT.UID','Y','N'),(97,'DF','[DATE]','Today\'s date','',0,'VARIABLE',NULL,NULL,NULL,NULL,'[DATE]','','Y',NULL),(158,'DF','<<OHSEAUDITOR>>','OHS&E Auditor','',0,'FIELD',NULL,NULL,NULL,NULL,'select NAME from EMPLOYEE where RoleType = \'OHSEAUDITOR\' and FKCompanyUID = @UID','CLIENT.UID','Y','N'),(159,'DF','<<POHSEREP>>','Project OHS&E Representative','',0,'FIELD',NULL,NULL,NULL,NULL,'select NAME from EMPLOYEE where RoleType = \'POHSEREP\' and FKCompanyUID = @UID','CLIENT.UID','Y','N'),(161,'DF','<<TIMETRADING>>','Time Trading','',0,'FIELD',NULL,NULL,NULL,NULL,'SELECT TimeTrading FROM ClientExtraInformation WHERE FKClientUID = @UID','CLIENT.UID','Y','N'),(162,'DF','**OPTTERM**','Operational Meetings Frequency','',0,'FIELD',NULL,NULL,NULL,NULL,'SELECT OperationalMeetingsFrequency FROM ClientExtraInformation WHERE FKClientUID = @UID','CLIENT.UID','Y','N'),(163,'DF','**PROTERM**','Project Meetings Frequency','',0,'FIELD',NULL,NULL,NULL,NULL,'SELECT ProjectMeetingsFrequency FROM ClientExtraInformation WHERE FKClientUID = @UID','CLIENT.UID','Y','N'),(164,'DF','<<POLDATE>>','Date to enter on policies','',0,'FIELD',NULL,NULL,NULL,NULL,'SELECT DATE_FORMAT(DateToEnterOnPolicies, \'%d/%m/%Y\') FROM ClientExtraInformation WHERE FKClientUID = @UID','CLIENT.UID','Y','N'),(165,'DF','<<WCPERSON>>','Workers Comp Person','',0,'FIELD',NULL,NULL,NULL,NULL,'select NAME from EMPLOYEE where RoleType = \'WCPERSON\' and FKCompanyUID = @UID','CLIENT.UID','Y','N'),(166,'DF','**SM**','Systems Manager','',0,'FIELD',NULL,NULL,NULL,NULL,'select NAME from EMPLOYEE where RoleType = \'SMN1\' and FKCompanyUID = @UID','CLIENT.UID','Y','N'),(167,'DF','<<MD1>>','Managing Director','',0,'FIELD',NULL,NULL,NULL,NULL,'select NAME from EMPLOYEE where RoleType = \'MD1\' and FKCompanyUID = @UID','CLIENT.UID','Y','N'),(168,'DF','**SCOPE**','Scope of services','',0,'FIELD',NULL,NULL,NULL,NULL,'SELECT ScopeofServices FROM ClientExtraInformation WHERE FKClientUID = @UID','CLIENT.UID','Y','N'),(169,'DF','**TIMETRADING**','Time Trading','',0,'FIELD',NULL,NULL,NULL,NULL,'SELECT TimeTrading FROM ClientExtraInformation WHERE FKClientUID = @UID','CLIENT.UID','Y','N'),(170,'DF','**REGIONS**','Regions','',0,'FIELD',NULL,NULL,NULL,NULL,'SELECT RegionsOfOperation FROM ClientExtraInformation WHERE FKClientUID = @UID','CLIENT.UID','Y','N'),(171,'DF','**MD**','Managing Director',' ',0,'FIELD',NULL,NULL,NULL,NULL,'select NAME from EMPLOYEE where RoleType = \'MD1\' and FKCompanyUID = @UID','CLIENT.UID','Y','N'),(172,'DF','##ADDRESS##','Address',' ',0,'FIELD',NULL,NULL,NULL,NULL,'SELECT ADDRESS FROM CLIENT WHERE UID = @UID','CLIENT.UID','Y','N'),(173,'DF','##FIRM##','Firm',' ',0,'FIELD',NULL,NULL,NULL,NULL,'SELECT NAME FROM CLIENT WHERE UID = @UID','CLIENT.UID','Y','N'),(174,'DF','##MANAGINGDIRECTOR##','Managing Director',' ',0,'FIELD',NULL,NULL,NULL,NULL,'select NAME from EMPLOYEE where RoleType = \'MD1\' and FKCompanyUID = @UID','CLIENT.UID','Y','N'),(175,'DF','##OPTTERM##','Operational Meetings Frequency',' ',0,'FIELD',NULL,NULL,NULL,NULL,'SELECT OperationalMeetingsFrequency FROM ClientExtraInformation WHERE FKClientUID = @UID','CLIENT.UID','Y','N'),(176,'DF','##PROJECTMANAGER##','Project Manager Name',' ',0,'FIELD',NULL,NULL,NULL,NULL,'select NAME from EMPLOYEE where RoleType = \'PM1\' and FKCompanyUID = @UID','CLIENT.UID','Y','N'),(177,'DF','##PROTERM##','Project Meetings Frequency',' ',0,'FIELD',NULL,NULL,NULL,NULL,'SELECT ProjectMeetingsFrequency FROM ClientExtraInformation WHERE FKClientUID = @UID','CLIENT.UID','Y','N'),(178,'DF','##REGIONS##','Regions','  ',0,'FIELD',NULL,NULL,NULL,NULL,'SELECT RegionsOfOperation FROM ClientExtraInformation WHERE FKClientUID = @UID','CLIENT.UID','Y','N'),(179,'DF','##SCOPE##','Scope of services',' ',0,'FIELD',NULL,NULL,NULL,NULL,'SELECT ScopeofServices FROM ClientExtraInformation WHERE FKClientUID = @UID','CLIENT.UID','Y','N'),(180,'DF','##SYSTEMSMANAGER##','Systems Manager',' ',0,'FIELD',NULL,NULL,NULL,NULL,'select NAME from EMPLOYEE where RoleType = \'SMN1\' and FKCompanyUID = @UID','CLIENT.UID','Y','N'),(181,'DF','##TIMETRADING##','Time Trading',' ',0,'FIELD',NULL,NULL,NULL,NULL,'SELECT TimeTrading FROM ClientExtraInformation WHERE FKClientUID = @UID','CLIENT.UID','Y','N'),(182,'DF','##WCPERSON##','Workers Comp Person',' ',0,'FIELD',NULL,NULL,NULL,NULL,'select NAME from EMPLOYEE where RoleType = \'WCPERSON\' and FKCompanyUID = @UID','CLIENT.UID','Y','N'),(183,'DF','##OHSEAUDITOR##','OHS&E Auditor',' ',0,'FIELD',NULL,NULL,NULL,NULL,'select NAME from EMPLOYEE where RoleType = \'OHSEAUDITOR\' and FKCompanyUID = @UID','CLIENT.UID','Y','N'),(184,'DF','##POHSEREP##','Project OHS&E Representative',' ',0,'FIELD',NULL,NULL,NULL,NULL,'select NAME from EMPLOYEE where RoleType = \'POHSEREP\' and FKCompanyUID = @UID','CLIENT.UID','Y','N'),(185,'DF','##POLDATE##','Date to enter on policies',' ',0,'FIELD',NULL,NULL,NULL,NULL,'SELECT DATE_FORMAT(DateToEnterOnPolicies, \'%d/%m/%Y\') FROM ClientExtraInformation WHERE FKClientUID = @UID','CLIENT.UID','Y','N'),(186,'DF','##TODAY##','Today\'s date',' ',0,'VARIABLE',NULL,NULL,NULL,NULL,'[DATE]',' ','Y','N');
/*!40000 ALTER TABLE `reportmetadata` ENABLE KEYS */;
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
