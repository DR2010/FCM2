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
-- Table structure for table `rdcodevalue`
--

DROP TABLE IF EXISTS `rdcodevalue`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!40101 SET character_set_client = utf8 */;
CREATE TABLE `rdcodevalue` (
  `FKCodeType` varchar(20) NOT NULL,
  `ID` varchar(20) NOT NULL,
  `Description` varchar(50) DEFAULT NULL,
  `Abbreviation` varchar(10) DEFAULT NULL,
  `ValueExtended` varchar(200) DEFAULT NULL,
  `NotUsedString` varchar(200) DEFAULT NULL,
  `ExtraString` varchar(200) DEFAULT NULL,
  PRIMARY KEY (`FKCodeType`,`ID`),
  KEY `FK_CodeValue_CodeType` (`FKCodeType`),
  CONSTRAINT `FK_CodeValue_CodeType` FOREIGN KEY (`FKCodeType`) REFERENCES `rdcodetype` (`CodeType`) ON DELETE NO ACTION ON UPDATE NO ACTION
) ENGINE=InnoDB DEFAULT CHARSET=latin1;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `rdcodevalue`
--

LOCK TABLES `rdcodevalue` WRITE;
/*!40000 ALTER TABLE `rdcodevalue` DISABLE KEYS */;
INSERT INTO `rdcodevalue` VALUES ('CLIENTOTHERFIELD','ACTIONPLANDATE','Action Plan Date:','COF','DATE',NULL,NULL),('CLIENTOTHERFIELD','DATEPOLICIES','Date to enter on policies.','ABBREV','STRING\r',NULL,NULL),('CLIENTOTHERFIELD','FREQOPERATIONS','Frequency of operations:','FOP','STRING\r',NULL,NULL),('CLIENTOTHERFIELD','PROJECTMEETINGS','Frequency of Project Meetings:','FOP','STRING\r',NULL,NULL),('CLIENTOTHERFIELD','REGIONSOPERATIONS','Regions of operations:','ROP','STRING\r',NULL,NULL),('CLIENTOTHERFIELD','SCOPESERVICES','Scope of Services:','SOS','STRING\r',NULL,NULL),('CLIENTOTHERFIELD','TIMETRADING','Time Trading:','TTR','STRING\r',NULL,NULL),('CLIENTSETSTATUS','COMPLETED','Completed','','\r',NULL,NULL),('CLIENTSETSTATUS','DRAFT','Draft','','\r',NULL,NULL),('CLIENTSETSTATUS','GENERATED','Generated','','\r',NULL,NULL),('CONSTRING','HP','Connection String HP','','Data Source=HPLAPTOP\\SQLEXPRESS;Initial Catalog=management;Persist Security info=false;integrated security=sspi;\r',NULL,NULL),('CONSTRING','HPDESKTOP','Connection String HP Desktop','','Data Source=DESKTOPMACHADO\\SQLEXPRESS;\"Initial Catalog=management;Persist Security info=false;integrated security=sspi;\r',NULL,NULL),('CONSTRING','HPMINI','Connection String HPMINI','','Data Source=HPMINI\\SQLEXPRESS;Initial Catalog=management;Persist Security info=false;integrated security=sspi;\r',NULL,NULL),('CONSTRING','TOSHIBA','Connection String Toshiba','','Data Source=TOSHIBAMACHADO\\SQLEXPRESS;\"Initial Catalog=management;Persist Security info=false;integrated security=sspi;\r',NULL,NULL),('CONTRACTSTATUS','ACTIVE','Active Contract','','\r',NULL,NULL),('CONTRACTSTATUS','CANCELLED','Cancelled','','\r',NULL,NULL),('CONTRACTSTATUS','INACTIVE','Inactive Status','','\r',NULL,NULL),('CONTRACTTYPE','BASIC','Basic contract','','\r',NULL,NULL),('CONTRACTTYPE','EXTENDED','','','\r',NULL,NULL),('ERRORCODE','FCMERR00.00.0001','Invalid User ID or Password.','','\r',NULL,NULL),('ERRORCODE','FCMERR00.00.0002','Error deleting User Role.','','\r',NULL,NULL),('ERRORCODE','FCMERR00.00.0006','Error creating new version. Source file not found.','','\r',NULL,NULL),('ERRORCODE','FCMINF00.00.0001','User added successfully.','','\r',NULL,NULL),('ERRORCODE','FCMINF00.00.0002','User role added successfully.','','\r',NULL,NULL),('ERRORCODE','FCMINF00.00.0003','User role deleted successfully.','','\r',NULL,NULL),('ERRORCODE','FCMINF00.00.0004','User added successfully.','','\r',NULL,NULL),('ERRORCODE','FCMINF00.00.0005','User updated successfully.','','\r',NULL,NULL),('GENERALSETTINGS','INTERNALEMAIL','Internal email address.','','FCMNOREPLY@GMAIL.COM\r',NULL,NULL),('GENERALSETTINGS','INTERNALEMAILPSWD','Internal email password','','grahamc1\r',NULL,NULL),('LASTINFO','CLIENTID','Last client actioned by user','LCID','201300018',NULL,NULL),('LASTINFO','USERID','Last user id logon','','dm0001',NULL,NULL),('PROPERTYCODE','FONTSIZE','Indicates the font size.','','\r',NULL,NULL),('PROPERTYCODE','ICONSIZE','Size of the icon','','\r',NULL,NULL),('PROPSTATUS','AGREEMENT','Agreement to proceed','','\r',NULL,NULL),('PROPSTATUS','ISSUED','Issued','','\r',NULL,NULL),('PROPTYPE','ACPQ','ACT Prequalification ','ACPQ','NULL\r',NULL,NULL),('PROPTYPE','FSC','Federal Safety Commission Accreditation','NULL','NULL\r',NULL,NULL),('ROLETYPE','ADMIN','Administration Person','ADMIN',NULL,NULL,NULL),('ROLETYPE','DIRECTOR','DIRECTOR','DIR','\r',NULL,NULL),('ROLETYPE','HSR1','Health and Safety Rep','HSR','NULL\r',NULL,NULL),('ROLETYPE','LEADHAND1','Leading Hand 1','LH1',NULL,NULL,NULL),('ROLETYPE','LEADHAND2','Leading Hand 2','LH2',NULL,NULL,NULL),('ROLETYPE','MD1','Managing Director','MD1','NULL\r',NULL,NULL),('ROLETYPE','OFMNG','Office Manager','OFMNG','',NULL,NULL),('ROLETYPE','OHSEAUDITOR','OHS&E Auditor','','\r',NULL,NULL),('ROLETYPE','PM1','Project Manager','NULL','NULL\r',NULL,NULL),('ROLETYPE','POHSEREP','Project OHS&E Representative','','\r',NULL,NULL),('ROLETYPE','SM1','Site Manager','SM1','NULL\r',NULL,NULL),('ROLETYPE','SMN1','Systems Manager','SISMAN1','NULL\r',NULL,NULL),('ROLETYPE','SUP1','Supervisor','SUP1','NULL\r',NULL,NULL),('ROLETYPE','WCPERSON','Workers Compensation Person','WCP','',NULL,NULL),('SCREENACTION','ADDNEWCLNTDOCSET','Add new client document set','','\r',NULL,NULL),('SCREENACTION','DELETE','DELETE','','\r',NULL,NULL),('SCREENACTION','EDITDOCUMENT','','','\r',NULL,NULL),('SCREENACTION','GENCLNTDOCBATCH','Generate Client Documents Batch','','\r',NULL,NULL),('SCREENACTION','GENCLNTDOCONLINE','Generate Client Documents Online','','\r',NULL,NULL),('SCREENACTION','OPEN','OPEN','','\r',NULL,NULL),('SCREENACTION','REMOVECLNTDOC','Remove client document from doc set','','\r',NULL,NULL),('SCREENACTION','SAVE','SAVE','','\r',NULL,NULL),('SCREENACTION','VIEWDOCUMENT','View Document','','\r',NULL,NULL),('SCREENCODE','CLNTDOC','Client Document - List of documents for a client.','','\r',NULL,NULL),('SCREENCODE','CLNTDOCSET','Client document set','','\r',NULL,NULL),('SCREENCODE','CLNTLIST','Client List','','\r',NULL,NULL),('SCREENCODE','CLNTREG','Client Registration','','\r',NULL,NULL),('SCREENCODE','DOCIMP','Clients impacted by document change','','\r',NULL,NULL),('SCREENCODE','DOCLINK','Document Link','','\r',NULL,NULL),('SCREENCODE','DOCLIST','Document List','','\r',NULL,NULL),('SCREENCODE','DOCSETLINK','Document Set Link','','\r',NULL,NULL),('SCREENCODE','DOCSETLIST','Document Set List','','\r',NULL,NULL),('SCREENCODE','DOCUMENT','Document Details','','\r',NULL,NULL),('SCREENCODE','IMPACTEDDOCUMENTS','Impacted Documents','','\r',NULL,NULL),('SCREENCODE','PROCESSREQUEST','Process Request','','\r',NULL,NULL),('SCREENCODE','REFERENCEDATA','Reference Data Maintenance','','\r',NULL,NULL),('SCREENCODE','REPORTMETADATA','Report Metadata Maintenance','','\r',NULL,NULL),('SCREENCODE','USERACCESS','User Access ','','\r',NULL,NULL),('SCREENCODE','USERSETTINGS','User Settings View','','\r',NULL,NULL),('SYSTSET','%CLIENTFOLDER%','Client Folder Location','','\\\\MACHADODANIEL\\FCM_Projects\\Shared_T_Drive\\DocumentsClient',NULL,NULL),('SYSTSET','%HOSTIPADDRESS%','Host location 120.146.248.24','HOST','172.16.0.100',NULL,NULL),('SYSTSET','%LOGFILEFOLDER%','Audit Log','ALOG','\\\\MACHADODANIEL\\FCM_Projects\\Shared_T_Drive\\AuditLog\\',NULL,NULL),('SYSTSET','%LOGOFOLDER%','Location where the logo is stored','LOCLOGO','\\\\MACHADODANIEL\\FCM_Projects\\Shared_T_Drive\\Logo\\',NULL,NULL),('SYSTSET','%TEMPLATEFOLDER%','Template Folder','','\\\\MACHADODANIEL\\FCM_Projects\\Shared_T_Drive\\Documents\\MasterTemplate\\',NULL,'C:\\I_Daniel\\Dropbox\\I_Projects\\FCM_Projects\\Shared_T_Drive\\Documents\\MasterTemplate\\'),('SYSTSET','%VERSIONFOLDER%','Location where the versions will be stored','VFL','\\\\MACHADODANIEL\\FCM_Projects\\Shared_T_Drive\\Documents\\Version',NULL,NULL),('SYSTSET','%WEBCLIENTFOLDER%','Web client folder ','','~/fcmclient/\r','%HOSTIPADDRESS%:%WEBPORT%/fcmclient/',NULL),('SYSTSET','%WEBLOGOFOLDER%','Virtual directory for logos ','WEBLOGO','~/fcmlogo/\r','%HOSTIPADDRESS%:%WEBPORT%/fcmlogo/',NULL),('SYSTSET','%WEBPORT%','Port where the application is enabled','WEBPORT','14000',NULL,NULL),('SYSTSET','%WEBTEMPLATEFOLDER%','Web template folder ','','~/fcmtemplate/\r','http://%HOSTIPADDRESS%:%WEBPORT%/fcmtemplate/',NULL),('SYSTSET','%WEBVERSIONFOLDER%','Web version folder ','','~/fcmversion/\r','%HOSTIPADDRESS%:%WEBPORT%/fcmversion/',NULL),('SYSTSET','CONNSTRING','Connection String','NULL','Data Source=TOSHIBAMACHADO\\SQLEXPRESS;\"Initial Catalog=management;Persist Security info=false;integrated security=sspi;\r',NULL,NULL),('SYSTSET','CURRENTENVIRONMENT','Current environment. WEB/ LOCAL','LOCENV','WEB\r',NULL,NULL),('SYSTSET','DB_HPMINI','Connection String HP MINI','DBM','Data Source=HPMINI\\SQLEXPRESS;Initial Catalog=management;Persist Security info=false;integrated security=sspi;\r',NULL,NULL),('SYSTSET','PDFEXEPATH','PDF EXE Path','PDF','C:\\\\Program Files\\\\AdobeReader 9.0\\\\Reader\\\\AcroRd32.exe\r',NULL,NULL),('SYSTSET','PICTUREHOLD','Insert picture in document is on hold','IPH','Y',NULL,NULL),('TABLESHORTCODE','CCO','Client Contract','','CLIENTCONTRACT\r',NULL,NULL),('TABLESHORTCODE','CDO','Client Document','','CLIENTDOCUMENT\r',NULL,NULL),('TABLESHORTCODE','CLT','Client','','CLIENT\r',NULL,NULL),('TABLESHORTCODE','DOC','Document','','DOCUMENT\r',NULL,NULL),('TEMPSET','01','Default Template','TSET','\r',NULL,NULL),('WEBINFO','LOGOLOCATION','Location of the logos (59.167.79.105)','LOGLOC','~/fcmlogo/\r','fcmweb.com.au:<PORT>/fcmlogo/',NULL),('WEBINFO','PORT','Web port used','WEBPORT','14000',NULL,NULL);
/*!40000 ALTER TABLE `rdcodevalue` ENABLE KEYS */;
UNLOCK TABLES;
/*!40103 SET TIME_ZONE=@OLD_TIME_ZONE */;

/*!40101 SET SQL_MODE=@OLD_SQL_MODE */;
/*!40014 SET FOREIGN_KEY_CHECKS=@OLD_FOREIGN_KEY_CHECKS */;
/*!40014 SET UNIQUE_CHECKS=@OLD_UNIQUE_CHECKS */;
/*!40101 SET CHARACTER_SET_CLIENT=@OLD_CHARACTER_SET_CLIENT */;
/*!40101 SET CHARACTER_SET_RESULTS=@OLD_CHARACTER_SET_RESULTS */;
/*!40101 SET COLLATION_CONNECTION=@OLD_COLLATION_CONNECTION */;
/*!40111 SET SQL_NOTES=@OLD_SQL_NOTES */;

-- Dump completed on 2013-10-19 18:09:52
