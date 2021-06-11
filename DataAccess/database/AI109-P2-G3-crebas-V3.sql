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
INSERT INTO `cloture_par_race` VALUES (1,1),(1,2),(2,2),(1,3),(3,3),(1,4),(4,4);
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
-- Table structure for table `distance_villes`
--

DROP TABLE IF EXISTS `distance_villes`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `distance_villes` (
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
-- Dumping data for table `distance_villes`
--

LOCK TABLES `distance_villes` WRITE;
/*!40000 ALTER TABLE `distance_villes` DISABLE KEYS */;
INSERT INTO `distance_villes` VALUES (1,2,20.5),(1,3,46.6),(1,4,32.5),(1,5,50.2),(1,6,38.2),(1,7,30.7),(1,8,19.2),(1,9,198),(1,10,43.4),(1,11,73.9),(1,12,83.2),(1,13,78.8),(1,14,64.5),(1,15,38.1),(1,16,110),(2,3,43.4),(2,4,27),(2,5,51.3),(2,6,47.4),(2,7,49.6),(2,8,38.3),(2,9,195),(2,10,67),(2,11,97.7),(2,12,107),(2,13,88.2),(2,14,83.4),(2,15,61.4),(2,16,110),(3,4,74),(3,5,91.3),(3,6,78.5),(3,7,74.2),(3,8,62.9),(3,9,161),(3,10,41.2),(3,11,94),(3,12,127),(3,13,119),(3,14,108),(3,15,82.4),(3,16,47.3),(4,5,24.9),(4,6,37.9),(4,7,46.7),(4,8,39.3),(4,9,225),(4,10,77.8),(4,11,108),(4,12,105),(4,13,80.8),(4,14,74.5),(4,15,72.1),(4,16,132),(5,6,34.9),(5,7,57.6),(5,8,50.2),(5,9,243),(5,10,95.4),(5,11,119),(5,12,115),(5,13,58.5),(5,14,85.4),(5,15,83.2),(5,16,148),(6,7,21.3),(6,8,17.2),(6,9,229),(6,10,70.2),(6,11,83.3),(6,12,73.5),(6,13,36.7),(6,14,45.1),(6,15,47),(6,16,145),(7,8,10),(7,9,225),(7,10,69.7),(7,11,63.8),(7,12,66.7),(7,13,64.5),(7,14,35.6),(7,15,27.5),(7,16,130),(8,9,214),(8,10,58.2),(8,11,71.9),(8,12,74.9),(8,13,60.6),(8,14,43.8),(8,15,35.6),(8,16,129),(9,10,198),(9,11,250),(9,12,283),(9,13,287),(9,14,260),(9,15,238),(9,16,146),(10,11,56.8),(10,12,89.7),(10,13,114),(10,14,74.6),(10,15,44.5),(10,16,62.7),(11,12,33.3),(11,13,105),(11,14,54.9),(11,15,35.8),(11,16,117),(12,13,71.8),(12,14,34.6),(12,15,45.1),(12,16,150),(13,14,48.8),(13,15,74.7),(13,16,184),(14,15,32.3),(14,16,137),(15,16,107);
/*!40000 ALTER TABLE `distance_villes` ENABLE KEYS */;
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
) ENGINE=InnoDB AUTO_INCREMENT=3 DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `evaluation`
--

LOCK TABLES `evaluation` WRITE;
/*!40000 ALTER TABLE `evaluation` DISABLE KEYS */;
INSERT INTO `evaluation` VALUES (1,1,1,5,'Charles-Henri est un homme admirable, il m\'a déjà vendu deux concepts avec sa start-up et sa moustache est impeccable. Quel bel homme !'),(2,1,2,5,'Très satisfait du professionnalisme des moutons de Robert, ils ont l\'esprit start-up nation ! Robert, si un jour l\'un d\'eux cherche un stage dans la tech, passe-moi un coup de bigot.');
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
) ENGINE=InnoDB AUTO_INCREMENT=6 DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `motif_annulation_prestation`
--

LOCK TABLES `motif_annulation_prestation` WRITE;
/*!40000 ALTER TABLE `motif_annulation_prestation` DISABLE KEYS */;
INSERT INTO `motif_annulation_prestation` VALUES (1,'Problème technique'),(2,'Indisponibilité à ces dates'),(3,'J\'ai trouvé mieux'),(4,'Désaccord avec mon partenaire'),(5,'Autre');
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
) ENGINE=InnoDB AUTO_INCREMENT=6 DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `motif_demande_intervention`
--

LOCK TABLES `motif_demande_intervention` WRITE;
/*!40000 ALTER TABLE `motif_demande_intervention` DISABLE KEYS */;
INSERT INTO `motif_demande_intervention` VALUES (1,'Une clôture est endommagée'),(2,'L\'abri est endommagé'),(3,'Un ou plusieurs abreuvoirs sont endommagés'),(4,'Une ou plusieurs bêtes se sont échappées'),(5,'Une ou plusieurs bêtes semblent malades');
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
) ENGINE=InnoDB AUTO_INCREMENT=5 DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `motif_refus_prestation`
--

LOCK TABLES `motif_refus_prestation` WRITE;
/*!40000 ALTER TABLE `motif_refus_prestation` DISABLE KEYS */;
INSERT INTO `motif_refus_prestation` VALUES (1,'J\'ai un imprévu'),(2,'Votre demande ne me correspond pas'),(3,'J\'ai déjà accepté une autre offre'),(4,'Autre');
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
  `id_nouvelle_prestation` int DEFAULT NULL,
  PRIMARY KEY (`id_negociation`),
  KEY `FK_Association_23` (`id_prestation`),
  KEY `FK_Association_24` (`id_offre`),
  KEY `FK_negociation_prestation_idx` (`id_nouvelle_prestation`),
  CONSTRAINT `FK_Association_23` FOREIGN KEY (`id_prestation`) REFERENCES `prestation` (`id_prestation`) ON DELETE RESTRICT ON UPDATE RESTRICT,
  CONSTRAINT `FK_Association_24` FOREIGN KEY (`id_offre`) REFERENCES `offre` (`id_offre`) ON DELETE RESTRICT ON UPDATE RESTRICT,
  CONSTRAINT `FK_negociation_prestation` FOREIGN KEY (`id_nouvelle_prestation`) REFERENCES `prestation` (`id_prestation`)
) ENGINE=InnoDB AUTO_INCREMENT=2 DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `negociation`
--

LOCK TABLES `negociation` WRITE;
/*!40000 ALTER TABLE `negociation` DISABLE KEYS */;
INSERT INTO `negociation` VALUES (1,1,NULL,'2020-10-08 00:00:00','2020-10-10 00:00:00',NULL);
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
  `id_condition` int NOT NULL,
  `nom_offre` varchar(254) DEFAULT NULL,
  `date_ajout` datetime DEFAULT NULL,
  `date_debut` datetime DEFAULT NULL,
  `date_fin` datetime DEFAULT NULL,
  `description_offre` varchar(254) DEFAULT NULL,
  `type_installation` tinyint(1) DEFAULT NULL,
  `prix_km` float DEFAULT NULL,
  `coef_installation` float DEFAULT NULL,
  `coef_intervention` float DEFAULT NULL,
  `prix_bete_jour` float DEFAULT NULL,
  `zone_couverture` int DEFAULT NULL,
  `adresse_offre` varchar(254) DEFAULT NULL,
  `date_annulation_offre` datetime DEFAULT NULL,
  PRIMARY KEY (`id_offre`),
  KEY `FK_Association_14` (`id_type`),
  KEY `FK_Association_31` (`id_frequence`),
  KEY `FK_Association_41` (`id_condition`),
  KEY `FK_Association_6` (`id_troupeau`),
  CONSTRAINT `FK_Association_14` FOREIGN KEY (`id_type`) REFERENCES `type_tonte` (`id_type`) ON DELETE RESTRICT ON UPDATE RESTRICT,
  CONSTRAINT `FK_Association_31` FOREIGN KEY (`id_frequence`) REFERENCES `frequence_intervention` (`id_frequence`) ON DELETE RESTRICT ON UPDATE RESTRICT,
  CONSTRAINT `FK_Association_41` FOREIGN KEY (`id_condition`) REFERENCES `condition_annulation` (`id_condition`) ON DELETE RESTRICT ON UPDATE RESTRICT,
  CONSTRAINT `FK_Association_6` FOREIGN KEY (`id_troupeau`) REFERENCES `troupeau` (`id_troupeau`) ON DELETE RESTRICT ON UPDATE RESTRICT
) ENGINE=InnoDB AUTO_INCREMENT=9 DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `offre`
--

LOCK TABLES `offre` WRITE;
/*!40000 ALTER TABLE `offre` DISABLE KEYS */;
INSERT INTO `offre` VALUES (1,3,1,4,3,'Fiers moutons cherchent vertes étendues','2020-09-06 00:00:00','2020-09-07 00:00:00','2021-08-15 00:00:00','Mes moutons n\'attendent plus que votre herbe pour trouver le bonheur.',1,0.25,90,7.1,2,50,'1, rue de Tart-le-Haut',NULL),(2,2,2,4,2,'Je lâche les biquettes','2020-09-09 00:00:00','2020-09-12 00:00:00','2021-12-30 00:00:00','Laissez-vous tenter par cette offre réalisée sur-mesure chez-vous par ces splendides chèvres des Fossés dont 1 sataniste. Peu importe le rythme de tonte, le terrain, rien n\'est trop dur pour mes biquettes.',1,0.21,80,5.7,1.3,60,'15 rue Picon-Bière',NULL),(3,3,3,4,1,'Oh les vaches !','2020-09-10 00:00:00','2020-09-11 00:00:00','2021-10-31 00:00:00','Si grand-mère sait faire du bon café, moi mon truc c\'est le lait, et pour ça mes vaches ont besoin de VOTRE herbe ! Conditions flex, tonte ajustable, vaches tout-terrain... Qu\'est-ce que vous attendez quoi ?',1,0.22,75,5.3,1.7,70,NULL,NULL),(4,4,4,1,3,'Quatre amis en cavale','2020-09-13 00:00:00','2020-09-14 00:00:00','2023-01-01 00:00:00','Quatre, nombre magique, nombre d\'angles dans un carré, nombre de filles du docteur March, nombre de saisons... Et nombre de chevaux que vous aurez sur votre terrain, mes petites tondeuses à gazon sur pattes !',1,NULL,71,6.2,1.6,80,NULL,NULL),(8,2,8,1,1,'Une offre qui vous rendra chèvre','2020-09-16 00:00:00','2020-09-17 00:00:00','2021-10-31 00:00:00','Derrière ce nom audacieux se cache une offre que vous ne pourrez refuser. 15 biquettes prêtes à en découdre avec vos herbes. Vous appelez ça de la mauvaise herbe, elles n\'en voient que des bons côtés.',1,0.21,82,6.6,NULL,40,NULL,NULL);
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
  `id_offre` int DEFAULT NULL,
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
  `nb_betes` int NOT NULL,
  PRIMARY KEY (`id_prestation`),
  KEY `FK_Association_15` (`id_troupeau`),
  KEY `FK_Association_16` (`id_terrain`),
  KEY `FK_Association_26` (`id_motif`),
  KEY `FK_Association_27` (`Mot_id_motif`),
  KEY `FK_offre_prestation_idx` (`id_offre`),
  CONSTRAINT `FK_Association_15` FOREIGN KEY (`id_troupeau`) REFERENCES `troupeau` (`id_troupeau`) ON DELETE RESTRICT ON UPDATE RESTRICT,
  CONSTRAINT `FK_Association_16` FOREIGN KEY (`id_terrain`) REFERENCES `terrain` (`id_terrain`) ON DELETE RESTRICT ON UPDATE RESTRICT,
  CONSTRAINT `FK_Association_26` FOREIGN KEY (`id_motif`) REFERENCES `motif_annulation_prestation` (`id_motif`) ON DELETE RESTRICT ON UPDATE RESTRICT,
  CONSTRAINT `FK_Association_27` FOREIGN KEY (`Mot_id_motif`) REFERENCES `motif_refus_prestation` (`id_motif`) ON DELETE RESTRICT ON UPDATE RESTRICT,
  CONSTRAINT `FK_offre_prestation` FOREIGN KEY (`id_offre`) REFERENCES `offre` (`id_offre`)
) ENGINE=InnoDB AUTO_INCREMENT=3 DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `prestation`
--

LOCK TABLES `prestation` WRITE;
/*!40000 ALTER TABLE `prestation` DISABLE KEYS */;
INSERT INTO `prestation` VALUES (1,NULL,1,1,1,NULL,'2020-10-01 00:00:00','2020-10-02 00:00:00',NULL,NULL,'2020-10-10 00:00:00',NULL,846.51,'2020-10-15 00:00:00','2020-10-30 00:00:00',1,10),(2,NULL,1,1,1,NULL,NULL,'2020-10-10 00:00:00',NULL,NULL,NULL,NULL,846.51,'2020-10-17 00:00:00','2020-11-01 00:00:00',1,10);
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
  `id_utilisateur` int DEFAULT NULL,
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
  KEY `FK_id_utilisateur_idx` (`id_utilisateur`),
  CONSTRAINT `FK_Association_25` FOREIGN KEY (`id_negociation`) REFERENCES `negociation` (`id_negociation`) ON DELETE RESTRICT ON UPDATE RESTRICT,
  CONSTRAINT `FK_id_utilisateur` FOREIGN KEY (`id_utilisateur`) REFERENCES `utilisateur` (`id_utilisateur`)
) ENGINE=InnoDB AUTO_INCREMENT=3 DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `proposition`
--

LOCK TABLES `proposition` WRITE;
/*!40000 ALTER TABLE `proposition` DISABLE KEYS */;
INSERT INTO `proposition` VALUES (1,1,1,'2020-10-08 00:00:00',NULL,NULL,'2020-10-09 00:00:00','Bonjour Robert, serait-il possible de reculer la date au lendemain ? J\'ai un petit imprévu.','2020-10-16 00:00:00','2020-10-31 00:00:00',NULL,NULL),(2,1,2,'2020-10-09 00:00:00',NULL,'2020-10-10 00:00:00',NULL,'Bonjour Charles-Henri, je ne suis pas disponible le 16, on peut commencer le 17 si vous voulez.','2020-10-17 00:00:00','2020-11-01 00:00:00',NULL,NULL);
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
  `coef_installation` float DEFAULT NULL,
  `coef_intervention` float DEFAULT NULL,
  `prix_bete_jour` float DEFAULT NULL,
  PRIMARY KEY (`id_tarif`)
) ENGINE=InnoDB AUTO_INCREMENT=3 DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `seuil_tarification`
--

LOCK TABLES `seuil_tarification` WRITE;
/*!40000 ALTER TABLE `seuil_tarification` DISABLE KEYS */;
INSERT INTO `seuil_tarification` VALUES (1,'Bas',0.15,70,4,1),(2,'Haut',0.3,120,8,3);
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
) ENGINE=InnoDB AUTO_INCREMENT=7 DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `terrain`
--

LOCK TABLES `terrain` WRITE;
/*!40000 ALTER TABLE `terrain` DISABLE KEYS */;
INSERT INTO `terrain` VALUES (1,1,1,1,1,'Le garden conceptéen',0.012,'Notre jardin de 1200 mètres carrés s\'inscrit dans la pure veine des jardins dijonnais : baobabs et couscoussières côtoient une herbe qui n\'en finit plus de pousser !','2020-09-05',0,NULL,NULL,'3 bis rue de la Flexisécurité',NULL,NULL,NULL,NULL,NULL,NULL,1,0),(2,12,1,12,2,'Jardin de l\'hôtel des Impôts',0.2,'Notre jardinier Hubert étant parti plus tôt que prévu à la retraite, nous devons entretenir ce magnifique jardin à la Versailles financé par nos braves contribuables.','2020-09-11',1,NULL,NULL,'1250 impasse Morose',NULL,NULL,NULL,NULL,NULL,NULL,1,1),(3,13,2,13,8,'L\'ACAB vert',1.3,'Notre association s\'est dotée d\'un joli terrain acheté avec les fonds récoltés lors de la vente aux enchères de notre sculptures du vieux clocher de l\'église de Perrancey-les-Vieux-Moulins réalisée en allumettes.','2020-09-16',0,NULL,NULL,'14 rue Ouaille-Foux',NULL,NULL,NULL,NULL,NULL,NULL,0,0),(4,14,1,14,2,'Jardin de la Mairie',0.6,'La présence d\'un troupeau permettrait non seulement à notre ville de doubler sa population, elle créerait sans doute assez d\'animation pour attirer les villages environnements qui viendraient découvrir une pelouse parfaitement entretenue.','2020-09-18',1,NULL,NULL,'30 rue du Colonel Moutarde',NULL,NULL,NULL,NULL,NULL,NULL,1,1),(5,15,6,15,9,'La Megaforest©',3.5,'Notre Megaforest© est l\'élément central de notre écosystème Megasoft. Parsemée d\'arbres binaires, tapissée de feuilles de style, c\'est l\'endroit parfait pour se balader et rerouver ses racines de dossiers.','2020-09-19',0,NULL,NULL,'1 rue Rougemont',NULL,NULL,NULL,NULL,NULL,NULL,0,0),(6,16,3,16,7,'Domaine Clos-Béber',2.2,'J\'y fais pousser mon vin réputé dans toute la région. J\'avais des chèvres mais on me les a volées et j\'ai une petite idée de qui c\'est.','2020-09-25',0,NULL,NULL,'2 rue de la Cigale',NULL,NULL,NULL,NULL,NULL,NULL,0,0);
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
) ENGINE=InnoDB AUTO_INCREMENT=9 DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `troupeau`
--

LOCK TABLES `troupeau` WRITE;
/*!40000 ALTER TABLE `troupeau` DISABLE KEYS */;
INSERT INTO `troupeau` VALUES (1,1,2,2,40,'Les moumoutes à Robert','Les moumoutes à Robert, c\'est 40 bêtes avec un coeur gros comme ça, prêtes à manger l\'herbe de vos terrains pour votre plus grand paisir.','1, rue de Tart-le-Haut',NULL,NULL,'2020-09-04 00:00:00','2020-09-05 00:00:00','2021-08-31 00:00:00',NULL,NULL,NULL,NULL,NULL,NULL,1),(2,4,3,3,15,'Mes biquettes','Mes biquettes, mes fiertés, mes bébés ! Faites pas attention à la petite grise elle fait des tours de tête complets et marche sur ses deux pattes arrières mais c\'est ma meilleure gagneuse.','15 rue Picon-Bière',NULL,NULL,'2020-09-15 00:00:00','2020-09-16 00:00:00','2021-12-31 00:00:00',NULL,NULL,NULL,NULL,NULL,NULL,1),(3,8,4,5,8,'Mes vachettes','Mes bretonnes Pie Noir sont les plus heureuses du monde, et comme on dit chez moi, vache qui rit, vache à moitié dans... non.','5, chemin Marguerite',NULL,NULL,'2020-09-05 00:00:00','2020-09-09 00:00:00','2021-12-31 00:00:00',NULL,NULL,NULL,NULL,NULL,NULL,0),(4,12,5,5,4,'Mes quatre chevaux','\"Maman regarde les zolis sevaux !\" Ca fait toujours son petit effet.','27 route du Manège',NULL,NULL,'2020-09-12 00:00:00','2020-09-12 00:00:00','2022-12-31 00:00:00',NULL,NULL,NULL,NULL,NULL,NULL,0),(5,2,6,8,16,'16 moutons bien roulés','Ils sont frais mes Solognot !','16 rue Nabilla',NULL,NULL,'2020-09-13 00:00:00','2020-09-14 00:00:00','2022-01-06 00:00:00',NULL,NULL,NULL,NULL,NULL,NULL,1),(6,7,7,2,7,'Les biquettes de la Stacy','Mes 7 chèvres naines sont nommées comme dans le film de Pixar : Prof, Grincheuse, Atchoum, Dormeuse, Timide, Simplette et Joyeuse. Ce sont mes meilleures amies','15, avenue de la Macronie',NULL,NULL,'2020-09-18 00:00:00','2020-09-19 00:00:00',NULL,NULL,NULL,NULL,NULL,NULL,NULL,0),(7,9,8,8,12,'Les meuh-meuh d\'Homère','12 belles Nantaises bien gaulées et affamées d\'herbe, qui dit meuh ?','31 rue du Champ de Printemps',NULL,NULL,'2020-09-19 00:00:00','2020-09-20 00:00:00',NULL,NULL,NULL,NULL,NULL,NULL,NULL,0),(8,6,9,9,17,'Vous les aurez mes lorraines','Des chèvres un peu capricieuses ahahah vous me suivez. Mais niveau tonte on reconnait bien le rigorisme stakhanoviste populairement attribué à nos voisins d\'outre-Rhin.','165 boulevard Johnny Halliday',NULL,NULL,'2020-09-20 00:00:00','2020-09-21 00:00:00',NULL,NULL,NULL,NULL,NULL,NULL,NULL,1);
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
) ENGINE=InnoDB AUTO_INCREMENT=7 DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `type_cloture`
--

LOCK TABLES `type_cloture` WRITE;
/*!40000 ALTER TABLE `type_cloture` DISABLE KEYS */;
INSERT INTO `type_cloture` VALUES (1,'Clôture complète'),(2,'Clôture ovine'),(3,'Clôture caprine'),(4,'Clôture bovine'),(5,'Clôture équine'),(6,'Aucune');
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
) ENGINE=InnoDB AUTO_INCREMENT=5 DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `type_tonte`
--

LOCK TABLES `type_tonte` WRITE;
/*!40000 ALTER TABLE `type_tonte` DISABLE KEYS */;
INSERT INTO `type_tonte` VALUES (1,'Lente',20),(2,'Modérée',50),(3,'Rapide',80),(4,'Toutes tontes',0);
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
  `presentation` varchar(1000) DEFAULT NULL,
  PRIMARY KEY (`id_utilisateur`),
  KEY `FK_Association_11` (`id_type_client`),
  KEY `FK_Association_37` (`id_ville`),
  CONSTRAINT `FK_Association_11` FOREIGN KEY (`id_type_client`) REFERENCES `type_client` (`id_type_client`) ON DELETE RESTRICT ON UPDATE RESTRICT,
  CONSTRAINT `FK_Association_37` FOREIGN KEY (`id_ville`) REFERENCES `ville` (`id_ville`) ON DELETE RESTRICT ON UPDATE RESTRICT
) ENGINE=InnoDB AUTO_INCREMENT=17 DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `utilisateur`
--

LOCK TABLES `utilisateur` WRITE;
/*!40000 ALTER TABLE `utilisateur` DISABLE KEYS */;
INSERT INTO `utilisateur` VALUES (1,1,2,'charlypichon@yahoo.fr','e643362c03534c952554fd6ebfffeb585db472c8001b2c8be00c5a8edda3946192c06c1dd9eb3b3b70289f3ed552f1fbedda3d7fff49473297b3c1bc288caf64','1986-04-01 00:00:00','2020-09-01 00:00:00',NULL,'Pichon','Charles-Henri','Concepteo','23, rue du Labrador',NULL,NULL,5131428266662121,'2023-08-01 00:00:00',123,NULL,NULL,'charlypichon@yahoo.fr','Nous sommes une jeune pousse qui propose des idées de concepts à ses partenaire afin de rejoindre avec nous la formidable aventure de la startup nation ! \"Fake it until you make it !\"'),(2,2,NULL,'rmaillette@wanadoo.fr','e643362c03534c952554fd6ebfffeb585db472c8001b2c8be00c5a8edda3946192c06c1dd9eb3b3b70289f3ed552f1fbedda3d7fff49473297b3c1bc288caf64','1935-08-01 00:00:00','2020-09-02 00:00:00',NULL,'Maillette','Robert',NULL,'1, rue de Tart-le-Haut',NULL,NULL,NULL,NULL,NULL,'FR6612345678909876543212345','BANKSTER666',NULL,'Présente dans notre beau petit village de Marliens depuis des générations, notre famille s\'est spécialisée dans l\'\'élevage de bétails. Nous avons absorbé notre dernier concurrent en lui faisant une offre qu\'il n\'a pas pu refuser.'),(3,3,NULL,'gbouchard@wanadoo.fr','e643362c03534c952554fd6ebfffeb585db472c8001b2c8be00c5a8edda3946192c06c1dd9eb3b3b70289f3ed552f1fbedda3d7fff49473297b3c1bc288caf64','1951-09-15 00:00:00','2020-09-03 00:00:00',NULL,'Bouchard','Gérard',NULL,'15 rue Picon-Bière',NULL,NULL,NULL,NULL,NULL,'FR6612345678909876543212345','BANKSTER666',NULL,'Gérard de mon prénom, les chèvres, c\'est ma grande passion.'),(4,4,NULL,'aposteur@wanadoo.fr','e643362c03534c952554fd6ebfffeb585db472c8001b2c8be00c5a8edda3946192c06c1dd9eb3b3b70289f3ed552f1fbedda3d7fff49473297b3c1bc288caf64','1955-02-20 00:00:00','2020-09-04 00:00:00',NULL,'Posteur','Alain',NULL,'20, place de la Vérité',NULL,NULL,NULL,NULL,NULL,'FR6612345678909876543212345','BANKSTER666',NULL,'Bonjour moi c\'est Alain, j\'aime l\'élevage, le jardinage, le kung-fu et ma collection de figurine My Little Poney. N\'hésitez pas à me contacter pour une prestation ou pour discuter MLP.'),(5,5,NULL,'jjrenard@wanadoo.fr','e643362c03534c952554fd6ebfffeb585db472c8001b2c8be00c5a8edda3946192c06c1dd9eb3b3b70289f3ed552f1fbedda3d7fff49473297b3c1bc288caf64','1964-12-05 00:00:00','2020-09-05 00:00:00',NULL,'Renard','Jean-Jacques',NULL,'3, rue du Poulailler',NULL,NULL,NULL,NULL,NULL,'FR6612345678909876543212345','BANKSTER666',NULL,'Appelez-moi JJ ou Renard, pour un éleveur de chèvres qui vit rue du Poulailler c\'est une drôle de coïncidence non ? On va bien s\'amuser.'),(6,6,NULL,'srabiot@wanadoo.fr','e643362c03534c952554fd6ebfffeb585db472c8001b2c8be00c5a8edda3946192c06c1dd9eb3b3b70289f3ed552f1fbedda3d7fff49473297b3c1bc288caf64','1992-03-29 00:00:00','2020-09-06 00:00:00',NULL,'Rabiot','Stacy',NULL,'15, avenue de la Macronie',NULL,NULL,5131428266662121,'2023-08-01 00:00:00',123,'FR6612345678909876543212345','BANKSTER666',NULL,'Salut les loulous, bienvenue sur ma Tontapage ! Je possède des moutons et des chèvres que j\'envoie en paturages chez mes clients partout en Bourgogne !'),(7,7,NULL,'bgiscard@wanadoo.fr','e643362c03534c952554fd6ebfffeb585db472c8001b2c8be00c5a8edda3946192c06c1dd9eb3b3b70289f3ed552f1fbedda3d7fff49473297b3c1bc288caf64','1993-06-02 00:00:00','2020-09-07 00:00:00',NULL,'Giscard','Brandon',NULL,'68 bis boulevard Cyril Hanouna',NULL,NULL,NULL,NULL,NULL,'FR6612345678909876543212345','BANKSTER666',NULL,'bonjour moi c\'est brandon giscard éleveur collectionneur ami de la nature et des animaux envoyez-moi des propositions s\'il vous plait j\'accepte tout tant que vous dites bonjour s\'il vous plait merci merci'),(8,8,NULL,'hdupre@wanadoo.fr','e643362c03534c952554fd6ebfffeb585db472c8001b2c8be00c5a8edda3946192c06c1dd9eb3b3b70289f3ed552f1fbedda3d7fff49473297b3c1bc288caf64','1963-01-21 00:00:00','2020-09-08 00:00:00',NULL,'Dupré','Homère',NULL,'31 rue du Champ de Printemps',NULL,NULL,NULL,NULL,NULL,'FR6612345678909876543212345','BANKSTER666',NULL,'Je n\'ai pas choisi la vie de la campagne, c\'est la vie de la campagne qui m\'a choisi.'),(9,9,NULL,'bpicatchou@wanadoo.fr','e643362c03534c952554fd6ebfffeb585db472c8001b2c8be00c5a8edda3946192c06c1dd9eb3b3b70289f3ed552f1fbedda3d7fff49473297b3c1bc288caf64','1976-05-29 00:00:00','2020-09-09 00:00:00',NULL,'Picatchou','Bartholomé',NULL,'165 boulevard Johnny Halliday',NULL,NULL,NULL,NULL,NULL,'FR6612345678909876543212345','BANKSTER666',NULL,'Bien le bonjour, je m\'inscris sur ce réseau social sur conseil d\'un cousin l\'autre fois on discutait et il me dit écoute Bartho (il m\'appelle Bartho) je connais ce site internet où tu peux mettre ton troupeau pour l\'envoyer chez les citadins et gagner de l\'argent dessus moi je lui réponds mon Jacquot c\'est une super idée ça envoie moi un SMS avec l\'adresse et je m\'inscrirai c\'était tout à l\'heure et me voilà'),(10,10,NULL,'mbigard@wanadoo.fr','e643362c03534c952554fd6ebfffeb585db472c8001b2c8be00c5a8edda3946192c06c1dd9eb3b3b70289f3ed552f1fbedda3d7fff49473297b3c1bc288caf64','1995-11-05 00:00:00','2020-09-10 00:00:00',NULL,'Bigard','Matthéo',NULL,'78 chemin des Copains',NULL,NULL,NULL,NULL,NULL,'FR6612345678909876543212345','BANKSTER666',NULL,'Amis de la verdure et des grandes étendues dégagées, mes salutations ! J\'ai tout ce qu\'il vous faut : des chèvres, des vaches, des moutons... Mes bêtes ne veulent qu\'une seule chose : votre herbe !'),(11,11,NULL,'jgrosjean@wanadoo.fr','e643362c03534c952554fd6ebfffeb585db472c8001b2c8be00c5a8edda3946192c06c1dd9eb3b3b70289f3ed552f1fbedda3d7fff49473297b3c1bc288caf64','1983-01-18 00:00:00','2020-09-11 00:00:00',NULL,'Grosjean','Jean',NULL,'20 rue des Gens',NULL,NULL,NULL,NULL,NULL,'FR6612345678909876543212345','BANKSTER666',NULL,'Vous aimez les chèvres ? Vous n\'aimez pas tondre la pelouse ? Vous allez m\'adorer.'),(12,12,3,'josianelabute@impots.gouv.fr','e643362c03534c952554fd6ebfffeb585db472c8001b2c8be00c5a8edda3946192c06c1dd9eb3b3b70289f3ed552f1fbedda3d7fff49473297b3c1bc288caf64','1967-11-01 00:00:00','2020-09-11 00:00:00',NULL,'Labute','Josiane','Centre des impôts','1255 impasse Morose',NULL,NULL,5131428266662121,'2023-08-01 00:00:00',123,'FR6612345678909876543212345','BANKSTER666',NULL,'(Voix monocorde) Bonjour, je représente le centre communal de traitement des demandes d\'imposition de Châtillon-sur-Seine. Notre bon Hubert étant parti à la retraite le chef m\'a chargé de trouver un prestataire original et écoresponsable. Où est-ce que j\'ai mis mon agrapheuse ? Je ne vais quand même pas devoir recommander une agrapheuse. '),(13,13,4,'acab@voila.fr','e643362c03534c952554fd6ebfffeb585db472c8001b2c8be00c5a8edda3946192c06c1dd9eb3b3b70289f3ed552f1fbedda3d7fff49473297b3c1bc288caf64','1991-10-01 00:00:00','2020-09-12 00:00:00',NULL,'Brigand','Gilbert','Amicale des Collectionneurs d\'Allumettes Bicéphales','71 rue des Abris Côtiers',NULL,NULL,5131428266662121,'2023-08-01 00:00:00',123,'FR6612345678909876543212345','BANKSTER666',NULL,'Créée en 1991, notre association regroupe les passionnés d\'allumettes à deux têtes de Langres mais aussi de Perrancey-les-Vieux-Moulins, Celles-en-Bassigny, certains membres viennent même de Champigny-sous-Varennes.'),(14,14,3,'mairieterrefondree@wanadoo.fr','e643362c03534c952554fd6ebfffeb585db472c8001b2c8be00c5a8edda3946192c06c1dd9eb3b3b70289f3ed552f1fbedda3d7fff49473297b3c1bc288caf64','1970-01-01 00:00:00','2020-09-13 00:00:00',NULL,'Barratier','Gilles','Mairie de Terrefondrée','30 rue du Colonel Moutarde',NULL,NULL,5131428266662121,'2023-08-01 00:00:00',123,'',NULL,NULL,'Commune dynamique de 61 habitants, Terrefondrée souhaite doter les jardins de sa prestigieuse mairie d\'un troupeau qui viendra entretenir sa pelouse. Le troupeau ainsi que son propriétaire pourra remporter un séjour d\'une semaine dans la chambre d\'hôtes de la belle-soeur de l\'adjoint au maire.'),(15,15,2,'ecopaturing@megasoft.com','e643362c03534c952554fd6ebfffeb585db472c8001b2c8be00c5a8edda3946192c06c1dd9eb3b3b70289f3ed552f1fbedda3d7fff49473297b3c1bc288caf64','2019-01-01 00:00:00','2020-09-14 00:00:00',NULL,'Guetz','Jean-Billou',NULL,'1 rue Rougemont',NULL,NULL,5131428266662121,'2023-08-01 00:00:00',123,'FR6612345678909876543212345','BANKSTER666',NULL,'Megasoft, la petite boite d\'informatique qui va détrôner les petits joueurs de la Silicon Valley, souhaite déjà impressionner ses voisins de Chanceaux avec de fiers moutons pour se délecter de nos verts pâturages.'),(16,16,1,'beberfontaine@voila.fr','e643362c03534c952554fd6ebfffeb585db472c8001b2c8be00c5a8edda3946192c06c1dd9eb3b3b70289f3ed552f1fbedda3d7fff49473297b3c1bc288caf64','2019-01-01 00:00:00','2020-09-15 00:00:00',NULL,'Fontaine','Bernard',NULL,'2 rue de la Cigale',NULL,NULL,5131428266662121,'2023-08-01 00:00:00',123,'',NULL,NULL,'eul\'tondeuse l\'est cassée et vu l\'prix du gasole j\'vais po la réparer donc ramène-moi tes bébêtes sur l\'jardin d\'moué qu\'ça raccourcisse eul\'plouse !');
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
INSERT INTO `vegetation_toxique_sur_terrain` VALUES (1,1),(2,3),(1,4),(4,7),(2,8),(5,9),(4,10),(5,12),(3,13),(1,16),(2,18);
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
) ENGINE=InnoDB AUTO_INCREMENT=17 DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `ville`
--

LOCK TABLES `ville` WRITE;
/*!40000 ALTER TABLE `ville` DISABLE KEYS */;
INSERT INTO `ville` VALUES (1,'Dijon',21000),(2,'Marliens',21110),(3,'Beaune',21200),(4,'Pontailler-sur-Saône',21270),(5,'Gray',70100),(6,'Orville',21260),(7,'Saulx-le-Duc',21120),(8,'Chaignay',21120),(9,'Francheville',21440),(10,'Pouilly-en-Auxois',21320),(11,'Montbard',21500),(12,'Châtillon-sur-Seine',21400),(13,'Langres',52200),(14,'Terrefondrée',21290),(15,'Chanceaux',21440),(16,'Le Creusot',71200);
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

-- Dump completed on 2021-06-11 20:33:24
