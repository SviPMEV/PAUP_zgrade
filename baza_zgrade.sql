CREATE DATABASE  IF NOT EXISTS `zgrade_db` /*!40100 DEFAULT CHARACTER SET utf8 */;
USE `zgrade_db`;
-- MySQL dump 10.13  Distrib 5.7.17, for Win64 (x86_64)
--
-- Host: localhost    Database: zgrade_db
-- ------------------------------------------------------
-- Server version	5.7.18-log

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
-- Table structure for table `financije`
--

DROP TABLE IF EXISTS `financije`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!40101 SET character_set_client = utf8 */;
CREATE TABLE `financije` (
  `idfinancije` int(11) NOT NULL AUTO_INCREMENT,
  `datumFinancije` date NOT NULL,
  `vrijednostFinancije` decimal(10,2) NOT NULL,
  `zgradaFinancija` int(11) NOT NULL,
  `opisFinancije` varchar(255) COLLATE cp1250_croatian_ci NOT NULL,
  `obavljenPosao` tinyint(4) NOT NULL DEFAULT '1',
  PRIMARY KEY (`idfinancije`)
) ENGINE=InnoDB AUTO_INCREMENT=10 DEFAULT CHARSET=cp1250 COLLATE=cp1250_croatian_ci;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `financije`
--

LOCK TABLES `financije` WRITE;
/*!40000 ALTER TABLE `financije` DISABLE KEYS */;
INSERT INTO `financije` VALUES (1,'2015-12-22',155.44,1,'Placanje pricuve Mirko Markec 12/2015',1),(2,'2016-11-10',-200.00,1,'Kupljena žarulja',1),(3,'2016-11-11',155.44,1,'Placanje pricuve Mirko Markec 11/2016',1),(4,'2016-12-23',-12550.00,2,'Reparatura fasade',1),(5,'2013-12-26',155.44,2,'Pricuva Ankica 12/2013',0),(6,'2017-01-05',10000.00,2,'Donacija EU',1),(7,'2017-01-31',345.00,2,'test',1),(8,'2016-01-31',435.44,2,'test2',0),(9,'2016-11-01',343.33,1,'samo test radio buttona',1);
/*!40000 ALTER TABLE `financije` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `obavijesti`
--

DROP TABLE IF EXISTS `obavijesti`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!40101 SET character_set_client = utf8 */;
CREATE TABLE `obavijesti` (
  `idobavijesti` int(11) NOT NULL AUTO_INCREMENT,
  `temaObavijest` longtext COLLATE cp1250_croatian_ci NOT NULL,
  `tekstObavijest` longtext COLLATE cp1250_croatian_ci NOT NULL,
  `datumObavijest` date NOT NULL,
  PRIMARY KEY (`idobavijesti`)
) ENGINE=InnoDB AUTO_INCREMENT=4 DEFAULT CHARSET=cp1250 COLLATE=cp1250_croatian_ci;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `obavijesti`
--

LOCK TABLES `obavijesti` WRITE;
/*!40000 ALTER TABLE `obavijesti` DISABLE KEYS */;
INSERT INTO `obavijesti` VALUES (1,'Napravljena nova zgrada u Varaždinu','Obavještavamo građane republike Hrvatske da je napravljena nova zgrada z Varaždinu, te slobno cijeli puk kupi stan po volji, cijene će varirati od 20€ po kvadratu za politicare i clanove crveno zelenih stranaka pa sve do 2000€ po kvadratu za opći narod sa prosjećnim primanjima ukoliko par mjeseci uplate neko mito prvotno navedenima','2016-12-02'),(2,'Zamijenjena žarulja u Čakovcu','Obještavamo stanare zgrade u Čakovcu da im je zamijenjena žarulja na drugom katu, s 60W modelom, ovo će uvelike doprinijeti uštedi toplinske energije pošto smo pri uštedi kupili žarulju sa žarnom niti umjesto LED varijante tako da grije pošteno i stanari na određenom katu mogu smanjiti grijanje za 0.2 stupnjeva na svojim šparhetima na drva.','2016-12-23'),(3,'Vjetar otpuhnuo predstavnika zgrade','Prilikom jakog vjetra u srijedu predstvanik zgrade se naginjao kroz prozor zajedničkog hodnika i otpuhnuo ga je do susjedne zgrade koja je u vlasništvu konkurentske tvrtke koji pa ga žele otkupiti za vođenje svoje zgrade, trenutačno smo u pregovorima s konkuretntskom tvrtkom i čekamo bolje uvjete. do daljnjega predstavnik zgrade je nedostupan','2017-01-11');
/*!40000 ALTER TABLE `obavijesti` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `poruka`
--

DROP TABLE IF EXISTS `poruka`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!40101 SET character_set_client = utf8 */;
CREATE TABLE `poruka` (
  `idporuka` int(11) NOT NULL AUTO_INCREMENT,
  `posiljateljPoruke` varchar(255) COLLATE cp1250_croatian_ci NOT NULL,
  `temaPoruke` longtext COLLATE cp1250_croatian_ci NOT NULL,
  `tijeloPoruke` longtext COLLATE cp1250_croatian_ci NOT NULL,
  `datumPoruke` date NOT NULL,
  PRIMARY KEY (`idporuka`)
) ENGINE=InnoDB AUTO_INCREMENT=4 DEFAULT CHARSET=cp1250 COLLATE=cp1250_croatian_ci;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `poruka`
--

LOCK TABLES `poruka` WRITE;
/*!40000 ALTER TABLE `poruka` DISABLE KEYS */;
INSERT INTO `poruka` VALUES (1,'Marko','Treba zarulju promenit','V mojem holu zarulja krepala i ne vidim nist dok hodam','2016-12-23'),(2,'Bobo','Probno','Samo testiram kak funkcionira','2015-01-30'),(3,'Bobo','Jos jedan test','Samo sprobavam','2016-03-30');
/*!40000 ALTER TABLE `poruka` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `stanar`
--

DROP TABLE IF EXISTS `stanar`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!40101 SET character_set_client = utf8 */;
CREATE TABLE `stanar` (
  `idstanar` int(255) NOT NULL,
  `Ime` varchar(45) COLLATE cp1250_croatian_ci NOT NULL,
  `Prezime` varchar(45) COLLATE cp1250_croatian_ci NOT NULL,
  `OIB` varchar(12) COLLATE cp1250_croatian_ci NOT NULL,
  `email` varchar(255) COLLATE cp1250_croatian_ci NOT NULL,
  `telefon` int(11) DEFAULT NULL,
  `mobitel` int(11) DEFAULT NULL,
  `zgrada` int(11) NOT NULL,
  `password_stanara` varchar(255) COLLATE cp1250_croatian_ci NOT NULL,
  `IsActive` bit(1) NOT NULL,
  PRIMARY KEY (`idstanar`)
) ENGINE=InnoDB DEFAULT CHARSET=cp1250 COLLATE=cp1250_croatian_ci;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `stanar`
--

LOCK TABLES `stanar` WRITE;
/*!40000 ALTER TABLE `stanar` DISABLE KEYS */;
INSERT INTO `stanar` VALUES (1,'Marko','Markić','5151561651','mark.markic@gmail.com',4004655,92123457,1,'test1','\0'),(2,'Ana','Anić','1234567891','ankich@hotmail.com',420000546,951234555,2,'test2','\0'),(3,'Boskan','Blajbek','1234567892','blajbo@gmx.net',100065646,925446587,3,'test3','\0'),(4,'Ivica','Blulu','1234567895','blubuulu@gmail.com',40655466,92444512,1,'test4','\0'),(5,'blablab','blalsbl','1234567888','sgmas@gmai.com',92144156,92154666,1,'test5','\0'),(10,'Upravite','Upraviteljko','1233656564','upravitelj_zgradara@gmail.com',45534358,87378387,1,'upravitelj','\0');
/*!40000 ALTER TABLE `stanar` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `zgrada`
--

DROP TABLE IF EXISTS `zgrada`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!40101 SET character_set_client = utf8 */;
CREATE TABLE `zgrada` (
  `idzgrada` int(11) NOT NULL AUTO_INCREMENT,
  `ulica` varchar(255) COLLATE cp1250_croatian_ci NOT NULL,
  `grad` varchar(45) COLLATE cp1250_croatian_ci NOT NULL,
  `postanskibroj` int(6) DEFAULT NULL,
  PRIMARY KEY (`idzgrada`)
) ENGINE=InnoDB AUTO_INCREMENT=4 DEFAULT CHARSET=cp1250 COLLATE=cp1250_croatian_ci;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `zgrada`
--

LOCK TABLES `zgrada` WRITE;
/*!40000 ALTER TABLE `zgrada` DISABLE KEYS */;
INSERT INTO `zgrada` VALUES (1,'Zagrebacka 11','Varazdin',42000),(2,'Besna 12','Čakovec',40000),(3,'Mocna 23','Zagreb',10000);
/*!40000 ALTER TABLE `zgrada` ENABLE KEYS */;
UNLOCK TABLES;
/*!40103 SET TIME_ZONE=@OLD_TIME_ZONE */;

/*!40101 SET SQL_MODE=@OLD_SQL_MODE */;
/*!40014 SET FOREIGN_KEY_CHECKS=@OLD_FOREIGN_KEY_CHECKS */;
/*!40014 SET UNIQUE_CHECKS=@OLD_UNIQUE_CHECKS */;
/*!40101 SET CHARACTER_SET_CLIENT=@OLD_CHARACTER_SET_CLIENT */;
/*!40101 SET CHARACTER_SET_RESULTS=@OLD_CHARACTER_SET_RESULTS */;
/*!40101 SET COLLATION_CONNECTION=@OLD_COLLATION_CONNECTION */;
/*!40111 SET SQL_NOTES=@OLD_SQL_NOTES */;

-- Dump completed on 2017-08-30 21:27:06
