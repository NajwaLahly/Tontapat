CREATE DATABASE  IF NOT EXISTS `tontapat` /*!40100 DEFAULT CHARACTER SET utf8mb4 COLLATE utf8mb4_0900_ai_ci */ /*!80016 DEFAULT ENCRYPTION='N' */;
USE `tontapat`;
-- MySQL dump 10.13  Distrib 8.0.25, for Win64 (x86_64)
--
-- Host: localhost    Database: tontapat
-- ------------------------------------------------------
-- Server version	8.0.25

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
-- Table structure for table `cloture_par_race`
--

DROP TABLE IF EXISTS `cloture_par_race`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `cloture_par_race` (
  `id_cloture` int NOT NULL,
  `id_race` int NOT NULL,
  PRIMARY KEY (`id_cloture`,`id_race`),
  KEY `FK_compatible` (`id_race`),
  CONSTRAINT `FK_compatible` FOREIGN KEY (`id_race`) REFERENCES `race` (`id_race`) ON DELETE RESTRICT ON UPDATE RESTRICT,
  CONSTRAINT `FK_compatible0` FOREIGN KEY (`id_cloture`) REFERENCES `type_cloture` (`id_cloture`) ON DELETE RESTRICT ON UPDATE RESTRICT
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `cloture_par_race`
--

LOCK TABLES `cloture_par_race` WRITE;
/*!40000 ALTER TABLE `cloture_par_race` DISABLE KEYS */;
/*!40000 ALTER TABLE `cloture_par_race` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `condition_annulation`
--

DROP TABLE IF EXISTS `condition_annulation`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `condition_annulation` (
  `id_condition` int NOT NULL AUTO_INCREMENT,
  `nom_condition` varchar(254) DEFAULT NULL,
  `delai_jour` int DEFAULT NULL,
  `pourcentage_facturation` int DEFAULT NULL,
  PRIMARY KEY (`id_condition`)
) ENGINE=InnoDB AUTO_INCREMENT=4 DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `condition_annulation`
--

LOCK TABLES `condition_annulation` WRITE;
/*!40000 ALTER TABLE `condition_annulation` DISABLE KEYS */;
INSERT INTO `condition_annulation` VALUES (1,'Flexibles',3,20),(2,'Modérées',7,50),(3,'Strict',10,70);
/*!40000 ALTER TABLE `condition_annulation` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `distance_ville`
--

DROP TABLE IF EXISTS `distance_ville`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `distance_ville` (
  `id_ville` int NOT NULL,
  `vil_id_ville` int NOT NULL,
  `distance` float DEFAULT NULL,
  PRIMARY KEY (`id_ville`,`vil_id_ville`),
  KEY `FK_Association_44` (`vil_id_ville`),
  CONSTRAINT `FK_Association_43` FOREIGN KEY (`id_ville`) REFERENCES `ville` (`id_ville`) ON DELETE RESTRICT ON UPDATE RESTRICT,
  CONSTRAINT `FK_Association_44` FOREIGN KEY (`vil_id_ville`) REFERENCES `ville` (`id_ville`) ON DELETE RESTRICT ON UPDATE RESTRICT
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `distance_ville`
--

LOCK TABLES `distance_ville` WRITE;
/*!40000 ALTER TABLE `distance_ville` DISABLE KEYS */;
/*!40000 ALTER TABLE `distance_ville` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `espece`
--

DROP TABLE IF EXISTS `espece`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `espece` (
  `id_espece` int NOT NULL AUTO_INCREMENT,
  `nom_espece` varchar(254) DEFAULT NULL,
  PRIMARY KEY (`id_espece`)
) ENGINE=InnoDB AUTO_INCREMENT=5 DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `espece`
--

LOCK TABLES `espece` WRITE;
/*!40000 ALTER TABLE `espece` DISABLE KEYS */;
INSERT INTO `espece` VALUES (1,'Ovins'),(2,'Caprins'),(3,'Bovins'),(4,'Equins');
/*!40000 ALTER TABLE `espece` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `evaluation`
--

DROP TABLE IF EXISTS `evaluation`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `evaluation` (
  `id_evaluation` int NOT NULL AUTO_INCREMENT,
  `id_prestation` int NOT NULL,
  `id_utilisateur` int NOT NULL,
  `note_evaluation` int DEFAULT NULL,
  `commentaire_evaluation` varchar(254) DEFAULT NULL,
  PRIMARY KEY (`id_evaluation`),
  KEY `FK_Association_34` (`id_prestation`),
  KEY `FK_Association_35` (`id_utilisateur`),
  CONSTRAINT `FK_Association_34` FOREIGN KEY (`id_prestation`) REFERENCES `prestation` (`id_prestation`) ON DELETE RESTRICT ON UPDATE RESTRICT,
  CONSTRAINT `FK_Association_35` FOREIGN KEY (`id_utilisateur`) REFERENCES `utilisateur` (`id_utilisateur`) ON DELETE RESTRICT ON UPDATE RESTRICT
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `evaluation`
--

LOCK TABLES `evaluation` WRITE;
/*!40000 ALTER TABLE `evaluation` DISABLE KEYS */;
/*!40000 ALTER TABLE `evaluation` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `frequence_intervention`
--

DROP TABLE IF EXISTS `frequence_intervention`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `frequence_intervention` (
  `id_frequence` int NOT NULL AUTO_INCREMENT,
  `valeur_frequence` int DEFAULT NULL,
  PRIMARY KEY (`id_frequence`)
) ENGINE=InnoDB AUTO_INCREMENT=8 DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `frequence_intervention`
--

LOCK TABLES `frequence_intervention` WRITE;
/*!40000 ALTER TABLE `frequence_intervention` DISABLE KEYS */;
INSERT INTO `frequence_intervention` VALUES (1,1),(2,2),(3,3),(4,4),(5,5),(6,6),(7,7);
/*!40000 ALTER TABLE `frequence_intervention` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `intervention`
--

DROP TABLE IF EXISTS `intervention`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `intervention` (
  `id_intervention` int NOT NULL AUTO_INCREMENT,
  `id_motif` int NOT NULL,
  `id_prestation` int NOT NULL,
  `date_demande` datetime DEFAULT NULL,
  `description_demande` varchar(254) DEFAULT NULL,
  `date_validation_demande` datetime DEFAULT NULL,
  `date_refus_demande` datetime DEFAULT NULL,
  `date_intervention` datetime DEFAULT NULL,
  `date_validation_intervention` datetime DEFAULT NULL,
  `description_validation` varchar(254) DEFAULT NULL,
  PRIMARY KEY (`id_intervention`),
  KEY `FK_Association_29` (`id_prestation`),
  KEY `FK_Association_30` (`id_motif`),
  CONSTRAINT `FK_Association_29` FOREIGN KEY (`id_prestation`) REFERENCES `prestation` (`id_prestation`) ON DELETE RESTRICT ON UPDATE RESTRICT,
  CONSTRAINT `FK_Association_30` FOREIGN KEY (`id_motif`) REFERENCES `motif_demande_intervention` (`id_motif`) ON DELETE RESTRICT ON UPDATE RESTRICT
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `intervention`
--

LOCK TABLES `intervention` WRITE;
/*!40000 ALTER TABLE `intervention` DISABLE KEYS */;
/*!40000 ALTER TABLE `intervention` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `motif_annulation_prestation`
--

DROP TABLE IF EXISTS `motif_annulation_prestation`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `motif_annulation_prestation` (
  `id_motif` int NOT NULL AUTO_INCREMENT,
  `nom_motif` varchar(254) DEFAULT NULL,
  PRIMARY KEY (`id_motif`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `motif_annulation_prestation`
--

LOCK TABLES `motif_annulation_prestation` WRITE;
/*!40000 ALTER TABLE `motif_annulation_prestation` DISABLE KEYS */;
/*!40000 ALTER TABLE `motif_annulation_prestation` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `motif_demande_intervention`
--

DROP TABLE IF EXISTS `motif_demande_intervention`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `motif_demande_intervention` (
  `id_motif` int NOT NULL AUTO_INCREMENT,
  `nom_motif` varchar(254) DEFAULT NULL,
  PRIMARY KEY (`id_motif`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `motif_demande_intervention`
--

LOCK TABLES `motif_demande_intervention` WRITE;
/*!40000 ALTER TABLE `motif_demande_intervention` DISABLE KEYS */;
/*!40000 ALTER TABLE `motif_demande_intervention` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `motif_reclamation`
--

DROP TABLE IF EXISTS `motif_reclamation`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `motif_reclamation` (
  `id_motif` int NOT NULL AUTO_INCREMENT,
  `nom_motif` varchar(254) DEFAULT NULL,
  PRIMARY KEY (`id_motif`)
) ENGINE=InnoDB AUTO_INCREMENT=8 DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `motif_reclamation`
--

LOCK TABLES `motif_reclamation` WRITE;
/*!40000 ALTER TABLE `motif_reclamation` DISABLE KEYS */;
INSERT INTO `motif_reclamation` VALUES (1,'Prestation non conforme à l’offre'),(2,'Non-respect du contrat'),(3,'Défaut de service'),(4,'Insécurité'),(5,'Violence envers les animaux'),(6,'Désaccord sur la prestation'),(7,'Autre (à préciser)');
/*!40000 ALTER TABLE `motif_reclamation` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `motif_refus_prestation`
--

DROP TABLE IF EXISTS `motif_refus_prestation`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `motif_refus_prestation` (
  `id_motif` int NOT NULL AUTO_INCREMENT,
  `nom_motif` varchar(254) DEFAULT NULL,
  PRIMARY KEY (`id_motif`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `motif_refus_prestation`
--

LOCK TABLES `motif_refus_prestation` WRITE;
/*!40000 ALTER TABLE `motif_refus_prestation` DISABLE KEYS */;
/*!40000 ALTER TABLE `motif_refus_prestation` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `negociation`
--

DROP TABLE IF EXISTS `negociation`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `negociation` (
  `id_negociation` int NOT NULL AUTO_INCREMENT,
  `id_prestation` int DEFAULT NULL,
  `id_offre` int DEFAULT NULL,
  `date_ouverture` datetime DEFAULT NULL,
  `date_fermeture` datetime DEFAULT NULL,
  PRIMARY KEY (`id_negociation`),
  KEY `FK_Association_23` (`id_prestation`),
  KEY `FK_Association_24` (`id_offre`),
  CONSTRAINT `FK_Association_23` FOREIGN KEY (`id_prestation`) REFERENCES `prestation` (`id_prestation`) ON DELETE RESTRICT ON UPDATE RESTRICT,
  CONSTRAINT `FK_Association_24` FOREIGN KEY (`id_offre`) REFERENCES `offre` (`id_offre`) ON DELETE RESTRICT ON UPDATE RESTRICT
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `negociation`
--

LOCK TABLES `negociation` WRITE;
/*!40000 ALTER TABLE `negociation` DISABLE KEYS */;
/*!40000 ALTER TABLE `negociation` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `offre`
--

DROP TABLE IF EXISTS `offre`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `offre` (
  `id_offre` int NOT NULL AUTO_INCREMENT,
  `id_frequence` int NOT NULL,
  `id_troupeau` int NOT NULL,
  `id_type` int NOT NULL,
  `id_prestation` int DEFAULT NULL,
  `id_tarif` int NOT NULL,
  `id_condition` int NOT NULL,
  `nom_offre` varchar(254) DEFAULT NULL,
  `date_ajout` datetime DEFAULT NULL,
  `date_debut` datetime DEFAULT NULL,
  `date_fin` datetime DEFAULT NULL,
  `description_offre` varchar(254) DEFAULT NULL,
  `type_installation` tinyint(1) DEFAULT NULL,
  `prix_km` float DEFAULT NULL,
  `prix_installation` float DEFAULT NULL,
  `prix_intervention` float DEFAULT NULL,
  `prix_bete_jour` float DEFAULT NULL,
  `zone_couverture` int DEFAULT NULL,
  `adresse_offre` varchar(254) DEFAULT NULL,
  `Date_annulation_offre` datetime DEFAULT NULL,
  PRIMARY KEY (`id_offre`),
  KEY `FK_Association_14` (`id_type`),
  KEY `FK_Association_28` (`id_tarif`),
  KEY `FK_Association_31` (`id_frequence`),
  KEY `FK_Association_32` (`id_prestation`),
  KEY `FK_Association_41` (`id_condition`),
  KEY `FK_Association_6` (`id_troupeau`),
  CONSTRAINT `FK_Association_14` FOREIGN KEY (`id_type`) REFERENCES `type_tonte` (`id_type`) ON DELETE RESTRICT ON UPDATE RESTRICT,
  CONSTRAINT `FK_Association_28` FOREIGN KEY (`id_tarif`) REFERENCES `seuil_tarification` (`id_tarif`) ON DELETE RESTRICT ON UPDATE RESTRICT,
  CONSTRAINT `FK_Association_31` FOREIGN KEY (`id_frequence`) REFERENCES `frequence_intervention` (`id_frequence`) ON DELETE RESTRICT ON UPDATE RESTRICT,
  CONSTRAINT `FK_Association_32` FOREIGN KEY (`id_prestation`) REFERENCES `prestation` (`id_prestation`) ON DELETE RESTRICT ON UPDATE RESTRICT,
  CONSTRAINT `FK_Association_41` FOREIGN KEY (`id_condition`) REFERENCES `condition_annulation` (`id_condition`) ON DELETE RESTRICT ON UPDATE RESTRICT,
  CONSTRAINT `FK_Association_6` FOREIGN KEY (`id_troupeau`) REFERENCES `troupeau` (`id_troupeau`) ON DELETE RESTRICT ON UPDATE RESTRICT
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `offre`
--

LOCK TABLES `offre` WRITE;
/*!40000 ALTER TABLE `offre` DISABLE KEYS */;
/*!40000 ALTER TABLE `offre` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `prestation`
--

DROP TABLE IF EXISTS `prestation`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `prestation` (
  `id_prestation` int NOT NULL AUTO_INCREMENT,
  `id_motif` int DEFAULT NULL,
  `id_terrain` int NOT NULL,
  `id_troupeau` int NOT NULL,
  `Mot_id_motif` int DEFAULT NULL,
  `date_demande` datetime DEFAULT NULL,
  `date_validation` datetime DEFAULT NULL,
  `date_refus` datetime DEFAULT NULL,
  `description_refus` varchar(254) DEFAULT NULL,
  `date_annulation` datetime DEFAULT NULL,
  `description_annulation` varchar(254) DEFAULT NULL,
  `prix_convenu` float DEFAULT NULL,
  `date_debut` datetime DEFAULT NULL,
  `date_fin` datetime DEFAULT NULL,
  `type_installation_final` tinyint(1) DEFAULT NULL,
  PRIMARY KEY (`id_prestation`),
  KEY `FK_Association_15` (`id_troupeau`),
  KEY `FK_Association_16` (`id_terrain`),
  KEY `FK_Association_26` (`id_motif`),
  KEY `FK_Association_27` (`Mot_id_motif`),
  CONSTRAINT `FK_Association_15` FOREIGN KEY (`id_troupeau`) REFERENCES `troupeau` (`id_troupeau`) ON DELETE RESTRICT ON UPDATE RESTRICT,
  CONSTRAINT `FK_Association_16` FOREIGN KEY (`id_terrain`) REFERENCES `terrain` (`id_terrain`) ON DELETE RESTRICT ON UPDATE RESTRICT,
  CONSTRAINT `FK_Association_26` FOREIGN KEY (`id_motif`) REFERENCES `motif_annulation_prestation` (`id_motif`) ON DELETE RESTRICT ON UPDATE RESTRICT,
  CONSTRAINT `FK_Association_27` FOREIGN KEY (`Mot_id_motif`) REFERENCES `motif_refus_prestation` (`id_motif`) ON DELETE RESTRICT ON UPDATE RESTRICT
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `prestation`
--

LOCK TABLES `prestation` WRITE;
/*!40000 ALTER TABLE `prestation` DISABLE KEYS */;
/*!40000 ALTER TABLE `prestation` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `proposition`
--

DROP TABLE IF EXISTS `proposition`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `proposition` (
  `id_proposition` int NOT NULL AUTO_INCREMENT,
  `id_negociation` int NOT NULL,
  `date_creation` datetime DEFAULT NULL,
  `date_annulation` datetime DEFAULT NULL,
  `date_validation` datetime DEFAULT NULL,
  `date_refus` datetime DEFAULT NULL,
  `description` varchar(254) DEFAULT NULL,
  `date_debut_prestation` datetime DEFAULT NULL,
  `date_fin_prestation` datetime DEFAULT NULL,
  `prix_propose` int DEFAULT NULL,
  `type_installation` tinyint(1) DEFAULT NULL,
  PRIMARY KEY (`id_proposition`),
  KEY `FK_Association_25` (`id_negociation`),
  CONSTRAINT `FK_Association_25` FOREIGN KEY (`id_negociation`) REFERENCES `negociation` (`id_negociation`) ON DELETE RESTRICT ON UPDATE RESTRICT
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `proposition`
--

LOCK TABLES `proposition` WRITE;
/*!40000 ALTER TABLE `proposition` DISABLE KEYS */;
/*!40000 ALTER TABLE `proposition` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `race`
--

DROP TABLE IF EXISTS `race`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `race` (
  `id_race` int NOT NULL AUTO_INCREMENT,
  `id_espece` int NOT NULL,
  `nom_race` varchar(254) DEFAULT NULL,
  PRIMARY KEY (`id_race`),
  KEY `FK_Association_3` (`id_espece`),
  CONSTRAINT `FK_Association_3` FOREIGN KEY (`id_espece`) REFERENCES `espece` (`id_espece`) ON DELETE RESTRICT ON UPDATE RESTRICT
) ENGINE=InnoDB AUTO_INCREMENT=16 DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `race`
--

LOCK TABLES `race` WRITE;
/*!40000 ALTER TABLE `race` DISABLE KEYS */;
INSERT INTO `race` VALUES (1,1,'Mouton d\'Ouessant'),(2,1,'Solognot'),(3,1,'Landes de Bretagne'),(4,2,'Chèvre des Fossés'),(5,2,'Poitevine'),(6,2,'Chèvre de Lorraine'),(7,2,'Chèvre naine'),(8,3,'Bretonne Pie Noir'),(9,3,'Nantaise'),(10,3,'Highland Cattle'),(11,4,'Âne du Cotentin'),(12,4,'Grand Noir du Berry'),(13,4,'Camargue'),(14,4,'Landais'),(15,4,'Trait Poitevin');
/*!40000 ALTER TABLE `race` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `reclamation`
--

DROP TABLE IF EXISTS `reclamation`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `reclamation` (
  `id_reclamation` int NOT NULL AUTO_INCREMENT,
  `id_prestation` int NOT NULL,
  `id_motif` int NOT NULL,
  `date_reclamation` datetime DEFAULT NULL,
  `description_reclamation` varchar(254) DEFAULT NULL,
  `date_traitement` datetime DEFAULT NULL,
  `date_fermeture` datetime DEFAULT NULL,
  PRIMARY KEY (`id_reclamation`),
  KEY `FK_Association_38` (`id_prestation`),
  KEY `FK_Association_39` (`id_motif`),
  CONSTRAINT `FK_Association_38` FOREIGN KEY (`id_prestation`) REFERENCES `prestation` (`id_prestation`) ON DELETE RESTRICT ON UPDATE RESTRICT,
  CONSTRAINT `FK_Association_39` FOREIGN KEY (`id_motif`) REFERENCES `motif_reclamation` (`id_motif`) ON DELETE RESTRICT ON UPDATE RESTRICT
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `reclamation`
--

LOCK TABLES `reclamation` WRITE;
/*!40000 ALTER TABLE `reclamation` DISABLE KEYS */;
/*!40000 ALTER TABLE `reclamation` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `seuil_tarification`
--

DROP TABLE IF EXISTS `seuil_tarification`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `seuil_tarification` (
  `id_tarif` int NOT NULL AUTO_INCREMENT,
  `nom_seuil` varchar(254) DEFAULT NULL,
  `prix_km` float DEFAULT NULL,
  `prix_bete_jour` float DEFAULT NULL,
  `coef_intervention` float DEFAULT NULL,
  `coef_installation` float DEFAULT NULL,
  PRIMARY KEY (`id_tarif`)
) ENGINE=InnoDB AUTO_INCREMENT=3 DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `seuil_tarification`
--

LOCK TABLES `seuil_tarification` WRITE;
/*!40000 ALTER TABLE `seuil_tarification` DISABLE KEYS */;
INSERT INTO `seuil_tarification` VALUES (1,'Bas',0.15,1,4,70),(2,'Haut',0.3,3,8,120);
/*!40000 ALTER TABLE `seuil_tarification` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `terrain`
--

DROP TABLE IF EXISTS `terrain`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `terrain` (
  `id_terrain` int NOT NULL AUTO_INCREMENT,
  `id_ville` int NOT NULL,
  `id_cloture` int DEFAULT NULL,
  `id_utilisateur` int NOT NULL,
  `id_type_terrain` int NOT NULL,
  `nom_terrain` varchar(254) DEFAULT NULL,
  `superficie_terrain` float DEFAULT NULL,
  `description` varchar(254) DEFAULT NULL,
  `date_ajout` varchar(254) DEFAULT NULL,
  `acces_public` tinyint(1) DEFAULT NULL,
  `adresse_lat` float DEFAULT NULL,
  `adresse_long` float DEFAULT NULL,
  `adresse_voie` varchar(254) DEFAULT NULL,
  `photo1` varchar(254) DEFAULT NULL,
  `photo2` varchar(254) DEFAULT NULL,
  `photo3` varchar(254) DEFAULT NULL,
  `photo4` varchar(254) DEFAULT NULL,
  `photo5` varchar(254) DEFAULT NULL,
  `date_retrait_terrain` datetime DEFAULT NULL,
  `presence_camera` tinyint(1) DEFAULT NULL,
  `presence_service_securite` tinyint(1) DEFAULT NULL,
  PRIMARY KEY (`id_terrain`),
  KEY `FK_Association_1` (`id_utilisateur`),
  KEY `FK_Association_33` (`id_cloture`),
  KEY `FK_Association_36` (`id_ville`),
  KEY `FK_Association_40` (`id_type_terrain`),
  CONSTRAINT `FK_Association_1` FOREIGN KEY (`id_utilisateur`) REFERENCES `utilisateur` (`id_utilisateur`) ON DELETE RESTRICT ON UPDATE RESTRICT,
  CONSTRAINT `FK_Association_33` FOREIGN KEY (`id_cloture`) REFERENCES `type_cloture` (`id_cloture`) ON DELETE RESTRICT ON UPDATE RESTRICT,
  CONSTRAINT `FK_Association_36` FOREIGN KEY (`id_ville`) REFERENCES `ville` (`id_ville`) ON DELETE RESTRICT ON UPDATE RESTRICT,
  CONSTRAINT `FK_Association_40` FOREIGN KEY (`id_type_terrain`) REFERENCES `type_terrain` (`id_type_terrain`) ON DELETE RESTRICT ON UPDATE RESTRICT
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `terrain`
--

LOCK TABLES `terrain` WRITE;
/*!40000 ALTER TABLE `terrain` DISABLE KEYS */;
/*!40000 ALTER TABLE `terrain` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `troupeau`
--

DROP TABLE IF EXISTS `troupeau`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `troupeau` (
  `id_troupeau` int NOT NULL AUTO_INCREMENT,
  `id_race` int NOT NULL,
  `id_utilisateur` int NOT NULL,
  `id_ville` int NOT NULL,
  `nombre_betes` int DEFAULT NULL,
  `nom_troupeau` varchar(254) DEFAULT NULL,
  `description` varchar(254) DEFAULT NULL,
  `adresse_voie` varchar(254) DEFAULT NULL,
  `adresse_long` float DEFAULT NULL,
  `adresse_lat` float DEFAULT NULL,
  `date_ajout` datetime DEFAULT NULL,
  `date_disponibilite` datetime DEFAULT NULL,
  `date_indisponibilite` datetime DEFAULT NULL,
  `photo1` varchar(254) DEFAULT NULL,
  `photo2` varchar(254) DEFAULT NULL,
  `photo3` varchar(254) DEFAULT NULL,
  `photo4` varchar(254) DEFAULT NULL,
  `photo5` varchar(254) DEFAULT NULL,
  `date_retrait_troup` datetime DEFAULT NULL,
  `divisibilite` tinyint(1) DEFAULT NULL,
  PRIMARY KEY (`id_troupeau`),
  KEY `FK_Association_2` (`id_utilisateur`),
  KEY `FK_Association_4` (`id_race`),
  KEY `FK_Association_42` (`id_ville`),
  CONSTRAINT `FK_Association_2` FOREIGN KEY (`id_utilisateur`) REFERENCES `utilisateur` (`id_utilisateur`) ON DELETE RESTRICT ON UPDATE RESTRICT,
  CONSTRAINT `FK_Association_4` FOREIGN KEY (`id_race`) REFERENCES `race` (`id_race`) ON DELETE RESTRICT ON UPDATE RESTRICT,
  CONSTRAINT `FK_Association_42` FOREIGN KEY (`id_ville`) REFERENCES `ville` (`id_ville`) ON DELETE RESTRICT ON UPDATE RESTRICT
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `troupeau`
--

LOCK TABLES `troupeau` WRITE;
/*!40000 ALTER TABLE `troupeau` DISABLE KEYS */;
/*!40000 ALTER TABLE `troupeau` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `type_client`
--

DROP TABLE IF EXISTS `type_client`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `type_client` (
  `id_type_client` int NOT NULL AUTO_INCREMENT,
  `nom_type_client` varchar(254) DEFAULT NULL,
  PRIMARY KEY (`id_type_client`)
) ENGINE=InnoDB AUTO_INCREMENT=5 DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `type_client`
--

LOCK TABLES `type_client` WRITE;
/*!40000 ALTER TABLE `type_client` DISABLE KEYS */;
INSERT INTO `type_client` VALUES (1,'Particulier'),(2,'Entreprise'),(3,'Collectivité locale'),(4,'Association');
/*!40000 ALTER TABLE `type_client` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `type_cloture`
--

DROP TABLE IF EXISTS `type_cloture`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `type_cloture` (
  `id_cloture` int NOT NULL AUTO_INCREMENT,
  `nom_cloture` varchar(254) DEFAULT NULL,
  PRIMARY KEY (`id_cloture`)
) ENGINE=InnoDB AUTO_INCREMENT=6 DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `type_cloture`
--

LOCK TABLES `type_cloture` WRITE;
/*!40000 ALTER TABLE `type_cloture` DISABLE KEYS */;
INSERT INTO `type_cloture` VALUES (1,'Clôture complète'),(2,'Clôture ovine'),(3,'Clôture caprine'),(4,'Clôture bovine'),(5,'Clôture équine');
/*!40000 ALTER TABLE `type_cloture` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `type_terrain`
--

DROP TABLE IF EXISTS `type_terrain`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `type_terrain` (
  `id_type_terrain` int NOT NULL AUTO_INCREMENT,
  `nom_type_terrain` varchar(254) DEFAULT NULL,
  PRIMARY KEY (`id_type_terrain`)
) ENGINE=InnoDB AUTO_INCREMENT=10 DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `type_terrain`
--

LOCK TABLES `type_terrain` WRITE;
/*!40000 ALTER TABLE `type_terrain` DISABLE KEYS */;
INSERT INTO `type_terrain` VALUES (1,'Jardin privé'),(2,'Jardin public'),(3,'Pré ou prairie'),(4,'Talus'),(5,'Champ'),(6,'Verger'),(7,'Vignoble'),(8,'Friche'),(9,'Bois ou forêt');
/*!40000 ALTER TABLE `type_terrain` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `type_tonte`
--

DROP TABLE IF EXISTS `type_tonte`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `type_tonte` (
  `id_type` int NOT NULL AUTO_INCREMENT,
  `nom_type` varchar(254) DEFAULT NULL,
  `coef_rapidite` int DEFAULT NULL,
  PRIMARY KEY (`id_type`)
) ENGINE=InnoDB AUTO_INCREMENT=4 DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `type_tonte`
--

LOCK TABLES `type_tonte` WRITE;
/*!40000 ALTER TABLE `type_tonte` DISABLE KEYS */;
INSERT INTO `type_tonte` VALUES (1,'Rapide',80),(2,'Modérée',50),(3,'Lente',20);
/*!40000 ALTER TABLE `type_tonte` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `type_vegetation_toxique`
--

DROP TABLE IF EXISTS `type_vegetation_toxique`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `type_vegetation_toxique` (
  `id_vegetation` int NOT NULL AUTO_INCREMENT,
  `nom_vegetation` varchar(254) DEFAULT NULL,
  PRIMARY KEY (`id_vegetation`)
) ENGINE=InnoDB AUTO_INCREMENT=19 DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `type_vegetation_toxique`
--

LOCK TABLES `type_vegetation_toxique` WRITE;
/*!40000 ALTER TABLE `type_vegetation_toxique` DISABLE KEYS */;
INSERT INTO `type_vegetation_toxique` VALUES (1,'Grande ciguë'),(2,'Colchique d\'automne'),(3,'Digitale pourpre'),(4,'Euphorbes épurge et characias'),(5,'Galéga officinal'),(6,'Glycérie aquatique'),(7,'Gui'),(8,'Houx'),(9,'Lauriers'),(10,'Mercuriale annuelle'),(11,'Milopertuis'),(12,'Morelle noire'),(13,'Moutarde noire'),(14,'Nielle des blés'),(15,'Prêle des champs'),(16,'Renoncules'),(17,'Séneçon jacobée'),(18,'Thuyas');
/*!40000 ALTER TABLE `type_vegetation_toxique` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `utilisateur`
--

DROP TABLE IF EXISTS `utilisateur`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `utilisateur` (
  `id_utilisateur` int NOT NULL AUTO_INCREMENT,
  `id_ville` int NOT NULL,
  `id_type_client` int DEFAULT NULL,
  `email` varchar(254) DEFAULT NULL,
  `mot_de_passe` varchar(254) DEFAULT NULL,
  `date_naissance` datetime DEFAULT NULL,
  `date_inscription` datetime DEFAULT NULL,
  `photo_profil` varchar(254) DEFAULT NULL,
  `nom` varchar(254) DEFAULT NULL,
  `prenom` varchar(254) DEFAULT NULL,
  `raison_sociale` varchar(254) DEFAULT NULL,
  `adresse_voie` varchar(254) DEFAULT NULL,
  `adresse_long` float DEFAULT NULL,
  `adresse_lat` float DEFAULT NULL,
  `carte_numero` bigint DEFAULT NULL,
  `carte_expiration` datetime DEFAULT NULL,
  `carte_cvc` int DEFAULT NULL,
  `virement_iban` varchar(254) DEFAULT NULL,
  `virement_bic` varchar(254) DEFAULT NULL,
  `paypal_email` varchar(254) DEFAULT NULL,
  PRIMARY KEY (`id_utilisateur`),
  KEY `FK_Association_11` (`id_type_client`),
  KEY `FK_Association_37` (`id_ville`),
  CONSTRAINT `FK_Association_11` FOREIGN KEY (`id_type_client`) REFERENCES `type_client` (`id_type_client`) ON DELETE RESTRICT ON UPDATE RESTRICT,
  CONSTRAINT `FK_Association_37` FOREIGN KEY (`id_ville`) REFERENCES `ville` (`id_ville`) ON DELETE RESTRICT ON UPDATE RESTRICT
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `utilisateur`
--

LOCK TABLES `utilisateur` WRITE;
/*!40000 ALTER TABLE `utilisateur` DISABLE KEYS */;
/*!40000 ALTER TABLE `utilisateur` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `vegetation_toxique_par_espece`
--

DROP TABLE IF EXISTS `vegetation_toxique_par_espece`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `vegetation_toxique_par_espece` (
  `id_espece` int NOT NULL,
  `id_vegetation` int NOT NULL,
  PRIMARY KEY (`id_espece`,`id_vegetation`),
  KEY `FK_Association_72_idx` (`id_vegetation`),
  CONSTRAINT `FK_Association_71` FOREIGN KEY (`id_espece`) REFERENCES `espece` (`id_espece`),
  CONSTRAINT `FK_Association_72` FOREIGN KEY (`id_vegetation`) REFERENCES `type_vegetation_toxique` (`id_vegetation`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `vegetation_toxique_par_espece`
--

LOCK TABLES `vegetation_toxique_par_espece` WRITE;
/*!40000 ALTER TABLE `vegetation_toxique_par_espece` DISABLE KEYS */;
INSERT INTO `vegetation_toxique_par_espece` VALUES (1,1),(2,1),(3,1),(4,1),(1,2),(3,2),(4,2),(1,3),(2,3),(3,3),(4,3),(1,4),(3,4),(4,4),(1,5),(2,5),(3,5),(4,5),(1,6),(3,6),(4,6),(1,7),(2,7),(3,7),(4,7),(1,8),(2,8),(3,8),(4,8),(1,9),(2,9),(3,9),(4,9),(1,10),(2,10),(3,10),(4,10),(1,11),(3,11),(4,11),(1,12),(2,12),(3,12),(4,12),(1,13),(2,13),(3,13),(4,13),(3,14),(4,14),(3,15),(4,15),(1,16),(2,16),(3,16),(4,16),(3,17),(4,17),(1,18),(2,18),(3,18),(4,18);
/*!40000 ALTER TABLE `vegetation_toxique_par_espece` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `vegetation_toxique_sur_terrain`
--

DROP TABLE IF EXISTS `vegetation_toxique_sur_terrain`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `vegetation_toxique_sur_terrain` (
  `id_terrain` int NOT NULL,
  `id_vegetation` int NOT NULL,
  PRIMARY KEY (`id_terrain`,`id_vegetation`),
  KEY `FK_Association_10` (`id_vegetation`),
  CONSTRAINT `FK_Association_10` FOREIGN KEY (`id_vegetation`) REFERENCES `type_vegetation_toxique` (`id_vegetation`) ON DELETE RESTRICT ON UPDATE RESTRICT,
  CONSTRAINT `FK_Association_100` FOREIGN KEY (`id_terrain`) REFERENCES `terrain` (`id_terrain`) ON DELETE RESTRICT ON UPDATE RESTRICT
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `vegetation_toxique_sur_terrain`
--

LOCK TABLES `vegetation_toxique_sur_terrain` WRITE;
/*!40000 ALTER TABLE `vegetation_toxique_sur_terrain` DISABLE KEYS */;
/*!40000 ALTER TABLE `vegetation_toxique_sur_terrain` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `ville`
--

DROP TABLE IF EXISTS `ville`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `ville` (
  `id_ville` int NOT NULL AUTO_INCREMENT,
  `nom_ville` varchar(254) DEFAULT NULL,
  `Code_postal` int DEFAULT NULL,
  PRIMARY KEY (`id_ville`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `ville`
--

LOCK TABLES `ville` WRITE;
/*!40000 ALTER TABLE `ville` DISABLE KEYS */;
/*!40000 ALTER TABLE `ville` ENABLE KEYS */;
UNLOCK TABLES;
/*!40103 SET TIME_ZONE=@OLD_TIME_ZONE */;

/*!40101 SET SQL_MODE=@OLD_SQL_MODE */;
/*!40014 SET FOREIGN_KEY_CHECKS=@OLD_FOREIGN_KEY_CHECKS */;
/*!40014 SET UNIQUE_CHECKS=@OLD_UNIQUE_CHECKS */;
/*!40101 SET CHARACTER_SET_CLIENT=@OLD_CHARACTER_SET_CLIENT */;
/*!40101 SET CHARACTER_SET_RESULTS=@OLD_CHARACTER_SET_RESULTS */;
/*!40101 SET COLLATION_CONNECTION=@OLD_COLLATION_CONNECTION */;
/*!40111 SET SQL_NOTES=@OLD_SQL_NOTES */;

-- Dump completed on 2021-06-10 11:50:58
