
/*
 Navicat Premium Data Transfer

 Source Server         : virutal
 Source Server Type    : MariaDB
 Source Server Version : 110202 (11.2.2-MariaDB-1:11.2.2+maria~ubu2204)
 Source Host           : localhost:3306
 Source Schema         : AMA

 Target Server Type    : MariaDB
 Target Server Version : 110202 (11.2.2-MariaDB-1:11.2.2+maria~ubu2204)
 File Encoding         : 65001

 Date: 19/01/2024 20:06:14
*/
use ama;

SET NAMES utf8mb4;
SET FOREIGN_KEY_CHECKS = 0;

-- ----------------------------
-- Table structure for __EFMigrationsHistory
-- ----------------------------
DROP TABLE IF EXISTS `__EFMigrationsHistory`;
CREATE TABLE `__EFMigrationsHistory`  (
  `MigrationId` varchar(150) CHARACTER SET utf8mb4 COLLATE utf8mb4_general_ci NOT NULL,
  `ProductVersion` varchar(32) CHARACTER SET utf8mb4 COLLATE utf8mb4_general_ci NOT NULL,
  PRIMARY KEY (`MigrationId`) USING BTREE
) ENGINE = InnoDB CHARACTER SET = utf8mb4 COLLATE = utf8mb4_general_ci;

-- ----------------------------
-- Records of __EFMigrationsHistory
-- ----------------------------
BEGIN;
INSERT INTO `__EFMigrationsHistory` (`MigrationId`, `ProductVersion`) VALUES ('20240106042140_inicio', '7.0.14'), ('20240107210733_autinreet', '7.0.14'), ('20240108054113_fix_user_temp_code', '7.0.14'), ('20240109011700_cabio tipo nticacin', '7.0.14'), ('20240110040103_aumento de tamaño de la columna name', '7.0.14'), ('20240114223956_agregar donacion', '7.0.14'), ('20240114232947_agregar colummna cantidad', '7.0.14'), ('20240117014713_actividades seeder', '7.0.14');
COMMIT;

-- ----------------------------
-- Table structure for ActivityType
-- ----------------------------
DROP TABLE IF EXISTS `ActivityType`;
CREATE TABLE `ActivityType`  (
  `Id` int(11) NOT NULL AUTO_INCREMENT,
  `CompanyId` int(11) NULL DEFAULT NULL,
  `Name` char(60) CHARACTER SET utf8mb4 COLLATE utf8mb4_general_ci NULL DEFAULT NULL,
  `Status` longtext CHARACTER SET utf8mb4 COLLATE utf8mb4_general_ci NOT NULL DEFAULT '',
  `CreatedAt` datetime(6) NOT NULL,
  `CreatedBy` int(11) NOT NULL,
  `UpdatedAt` datetime(6) NULL DEFAULT NULL,
  `UpdatedBy` int(11) NULL DEFAULT NULL,
  `Active` tinyint(1) NOT NULL,
  PRIMARY KEY (`Id`) USING BTREE
) ENGINE = InnoDB AUTO_INCREMENT = 2 CHARACTER SET = utf8mb4 COLLATE = utf8mb4_general_ci;

-- ----------------------------
-- Records of ActivityType
-- ----------------------------
BEGIN;
INSERT INTO `ActivityType` (`Id`, `CompanyId`, `Name`, `Status`, `CreatedAt`, `CreatedBy`, `UpdatedAt`, `UpdatedBy`, `Active`) VALUES (1, NULL, 'PRUEBA DE ACTIVIDAD', 'A', '2024-01-16 20:47:13.000000', 0, NULL, NULL, 1);
COMMIT;

-- ----------------------------
-- Table structure for Beneficiaries
-- ----------------------------
DROP TABLE IF EXISTS `Beneficiaries`;
CREATE TABLE `Beneficiaries`  (
  `PersonId` int(11) NOT NULL,
  `Description` char(10) CHARACTER SET utf8mb4 COLLATE utf8mb4_general_ci NULL DEFAULT NULL,
  `Status` longtext CHARACTER SET utf8mb4 COLLATE utf8mb4_general_ci NOT NULL DEFAULT '',
  `CreatedAt` datetime(6) NOT NULL,
  `CreatedBy` int(11) NOT NULL,
  `UpdatedAt` datetime(6) NULL DEFAULT NULL,
  `UpdatedBy` int(11) NULL DEFAULT NULL,
  `Active` tinyint(1) NOT NULL,
  PRIMARY KEY (`PersonId`) USING BTREE,
  CONSTRAINT `FK_Beneficiaries_Persons` FOREIGN KEY (`PersonId`) REFERENCES `Persons` (`Id`) ON DELETE RESTRICT ON UPDATE RESTRICT
) ENGINE = InnoDB CHARACTER SET = utf8mb4 COLLATE = utf8mb4_general_ci;

-- ----------------------------
-- Records of Beneficiaries
-- ----------------------------
BEGIN;
COMMIT;

-- ----------------------------
-- Table structure for BeneficiaryType
-- ----------------------------
DROP TABLE IF EXISTS `BeneficiaryType`;
CREATE TABLE `BeneficiaryType`  (
  `Id` int(11) NOT NULL AUTO_INCREMENT,
  `Name` char(10) CHARACTER SET utf8mb4 COLLATE utf8mb4_general_ci NULL DEFAULT NULL,
  `Status` longtext CHARACTER SET utf8mb4 COLLATE utf8mb4_general_ci NOT NULL DEFAULT '',
  `CreatedAt` datetime(6) NOT NULL,
  `CreatedBy` int(11) NOT NULL,
  `UpdatedAt` datetime(6) NULL DEFAULT NULL,
  `UpdatedBy` int(11) NULL DEFAULT NULL,
  `Active` tinyint(1) NOT NULL,
  PRIMARY KEY (`Id`) USING BTREE
) ENGINE = InnoDB AUTO_INCREMENT = 1 CHARACTER SET = utf8mb4 COLLATE = utf8mb4_general_ci;

-- ----------------------------
-- Records of BeneficiaryType
-- ----------------------------
BEGIN;
COMMIT;

-- ----------------------------
-- Table structure for BrigadeBeneficiaries
-- ----------------------------
DROP TABLE IF EXISTS `BrigadeBeneficiaries`;
CREATE TABLE `BrigadeBeneficiaries`  (
  `Id` int(11) NOT NULL AUTO_INCREMENT,
  `BrigadeId` int(11) NOT NULL,
  `BeneficiaryId` int(11) NOT NULL,
  `BeneficiaryTypeId` int(11) NOT NULL,
  `Description` char(10) CHARACTER SET utf8mb4 COLLATE utf8mb4_general_ci NULL DEFAULT NULL,
  `Status` longtext CHARACTER SET utf8mb4 COLLATE utf8mb4_general_ci NOT NULL DEFAULT '',
  `CreatedAt` datetime(6) NOT NULL,
  `CreatedBy` int(11) NOT NULL,
  `UpdatedAt` datetime(6) NULL DEFAULT NULL,
  `UpdatedBy` int(11) NULL DEFAULT NULL,
  `Active` tinyint(1) NOT NULL,
  PRIMARY KEY (`Id`) USING BTREE,
  INDEX `IX_BrigadeBeneficiaries_BeneficiaryId`(`BeneficiaryId`) USING BTREE,
  INDEX `IX_BrigadeBeneficiaries_BeneficiaryTypeId`(`BeneficiaryTypeId`) USING BTREE,
  INDEX `IX_BrigadeBeneficiaries_BrigadeId`(`BrigadeId`) USING BTREE,
  CONSTRAINT `FK_BrigadeBeneficiaries_Beneficiaries` FOREIGN KEY (`BeneficiaryId`) REFERENCES `Beneficiaries` (`PersonId`) ON DELETE RESTRICT ON UPDATE RESTRICT,
  CONSTRAINT `FK_BrigadeBeneficiaries_BeneficiaryType` FOREIGN KEY (`BeneficiaryTypeId`) REFERENCES `BeneficiaryType` (`Id`) ON DELETE RESTRICT ON UPDATE RESTRICT,
  CONSTRAINT `FK_BrigadeBeneficiaries_Brigades` FOREIGN KEY (`BrigadeId`) REFERENCES `Brigades` (`Id`) ON DELETE RESTRICT ON UPDATE RESTRICT
) ENGINE = InnoDB AUTO_INCREMENT = 1 CHARACTER SET = utf8mb4 COLLATE = utf8mb4_general_ci;

-- ----------------------------
-- Records of BrigadeBeneficiaries
-- ----------------------------
BEGIN;
COMMIT;

-- ----------------------------
-- Table structure for Brigades
-- ----------------------------
DROP TABLE IF EXISTS `Brigades`;
CREATE TABLE `Brigades`  (
  `Id` int(11) NOT NULL AUTO_INCREMENT,
  `CompanyId` int(11) NULL DEFAULT NULL,
  `PersonId` int(11) NOT NULL,
  `Name` varchar(250) CHARACTER SET utf8mb4 COLLATE utf8mb4_general_ci NOT NULL,
  `Description` varchar(500) CHARACTER SET utf8mb4 COLLATE utf8mb4_general_ci NULL DEFAULT NULL,
  `Start` date NOT NULL,
  `End` date NOT NULL,
  `Status` longtext CHARACTER SET utf8mb4 COLLATE utf8mb4_general_ci NOT NULL DEFAULT '',
  `CreatedAt` datetime NOT NULL,
  `CreatedBy` int(11) NOT NULL,
  `UpdatedAt` datetime NULL DEFAULT NULL,
  `UpdatedBy` int(11) NULL DEFAULT NULL,
  `Active` tinyint(1) NOT NULL,
  PRIMARY KEY (`Id`) USING BTREE,
  INDEX `IX_Brigades_CompanyId`(`CompanyId`) USING BTREE,
  INDEX `IX_Brigades_PersonId`(`PersonId`) USING BTREE,
  CONSTRAINT `FK_Brigades_Company` FOREIGN KEY (`CompanyId`) REFERENCES `Company` (`Id`) ON DELETE RESTRICT ON UPDATE RESTRICT,
  CONSTRAINT `FK_Brigades_Persons` FOREIGN KEY (`PersonId`) REFERENCES `Persons` (`Id`) ON DELETE RESTRICT ON UPDATE RESTRICT
) ENGINE = InnoDB AUTO_INCREMENT = 3 CHARACTER SET = utf8mb4 COLLATE = utf8mb4_general_ci;

-- ----------------------------
-- Records of Brigades
-- ----------------------------
BEGIN;
INSERT INTO `Brigades` (`Id`, `CompanyId`, `PersonId`, `Name`, `Description`, `Start`, `End`, `Status`, `CreatedAt`, `CreatedBy`, `UpdatedAt`, `UpdatedBy`, `Active`) VALUES (1, NULL, 2, 'Brigada 1', 'qwertyty', '2024-01-17', '2024-01-24', 'A', '2024-01-17 01:51:27', 0, NULL, NULL, 1), (2, NULL, 2, 'asd', 'asd', '2024-01-23', '2024-01-22', 'A', '2024-01-19 04:55:57', 0, '2024-01-19 05:01:05', NULL, 0);
COMMIT;

-- ----------------------------
-- Table structure for BrigadeVoluntareers
-- ----------------------------
DROP TABLE IF EXISTS `BrigadeVoluntareers`;
CREATE TABLE `BrigadeVoluntareers`  (
  `BrigadeId` int(11) NOT NULL,
  `VolunteerId` int(11) NOT NULL,
  `Status` longtext CHARACTER SET utf8mb4 COLLATE utf8mb4_general_ci NOT NULL DEFAULT '',
  `CreatedAt` datetime NOT NULL,
  `CreatedBy` int(11) NOT NULL,
  `UpdatedAt` datetime NULL DEFAULT NULL,
  `UpdatedBy` int(11) NULL DEFAULT NULL,
  `Active` tinyint(1) NOT NULL,
  PRIMARY KEY (`BrigadeId`, `VolunteerId`) USING BTREE,
  INDEX `IX_BrigadeVoluntareers_VolunteerId`(`VolunteerId`) USING BTREE,
  CONSTRAINT `FK_BrigadeVoluntareers_Brigades` FOREIGN KEY (`BrigadeId`) REFERENCES `Brigades` (`Id`) ON DELETE RESTRICT ON UPDATE RESTRICT,
  CONSTRAINT `FK_BrigadeVoluntareers_Volunteers` FOREIGN KEY (`VolunteerId`) REFERENCES `Volunteers` (`PersonId`) ON DELETE RESTRICT ON UPDATE RESTRICT
) ENGINE = InnoDB CHARACTER SET = utf8mb4 COLLATE = utf8mb4_general_ci;

-- ----------------------------
-- Records of BrigadeVoluntareers
-- ----------------------------
BEGIN;
COMMIT;

-- ----------------------------
-- Table structure for Company
-- ----------------------------
DROP TABLE IF EXISTS `Company`;
CREATE TABLE `Company`  (
  `Id` int(11) NOT NULL AUTO_INCREMENT,
  `Identificacion` char(10) CHARACTER SET utf8mb4 COLLATE utf8mb4_general_ci NOT NULL,
  `Nombre` char(10) CHARACTER SET utf8mb4 COLLATE utf8mb4_general_ci NULL DEFAULT NULL,
  `Status` longtext CHARACTER SET utf8mb4 COLLATE utf8mb4_general_ci NOT NULL DEFAULT '',
  `CreatedAt` datetime(6) NOT NULL,
  `CreatedBy` int(11) NOT NULL,
  `UpdatedAt` datetime(6) NULL DEFAULT NULL,
  `UpdatedBy` int(11) NULL DEFAULT NULL,
  `Active` tinyint(1) NOT NULL,
  PRIMARY KEY (`Id`) USING BTREE
) ENGINE = InnoDB AUTO_INCREMENT = 1 CHARACTER SET = utf8mb4 COLLATE = utf8mb4_general_ci;

-- ----------------------------
-- Records of Company
-- ----------------------------
BEGIN;
COMMIT;

-- ----------------------------
-- Table structure for CompanyUsers
-- ----------------------------
DROP TABLE IF EXISTS `CompanyUsers`;
CREATE TABLE `CompanyUsers`  (
  `UserId` int(11) NOT NULL,
  `CompanyId` int(11) NOT NULL,
  `CreatedAt` datetime(6) NOT NULL,
  `CreatedBy` int(11) NOT NULL,
  `UpdatedAt` datetime(6) NULL DEFAULT NULL,
  `UpdatedBy` int(11) NULL DEFAULT NULL,
  `Active` tinyint(1) NOT NULL,
  PRIMARY KEY (`UserId`, `CompanyId`) USING BTREE,
  INDEX `IX_CompanyUsers_CompanyId`(`CompanyId`) USING BTREE,
  CONSTRAINT `FK_CompanyUsers_Company` FOREIGN KEY (`CompanyId`) REFERENCES `Company` (`Id`) ON DELETE RESTRICT ON UPDATE RESTRICT,
  CONSTRAINT `FK_CompanyUsers_Users` FOREIGN KEY (`UserId`) REFERENCES `Users` (`Id`) ON DELETE RESTRICT ON UPDATE RESTRICT
) ENGINE = InnoDB CHARACTER SET = utf8mb4 COLLATE = utf8mb4_general_ci;

-- ----------------------------
-- Records of CompanyUsers
-- ----------------------------
BEGIN;
COMMIT;

-- ----------------------------
-- Table structure for ConsultVolunteers
-- ----------------------------
DROP TABLE IF EXISTS `ConsultVolunteers`;
CREATE TABLE `ConsultVolunteers`  (
  `consult` int(11) NOT NULL AUTO_INCREMENT,
  `volunteer_id` int(11) NULL DEFAULT NULL,
  `CreatedAt` datetime(6) NOT NULL,
  `CreatedBy` int(11) NOT NULL,
  `UpdatedAt` datetime(6) NULL DEFAULT NULL,
  `UpdatedBy` int(11) NULL DEFAULT NULL,
  `Active` tinyint(1) NOT NULL,
  PRIMARY KEY (`consult`) USING BTREE,
  INDEX `IX_ConsultVolunteers_volunteer_id`(`volunteer_id`) USING BTREE,
  CONSTRAINT `FK__ConsultVo__volun__70DDC3D8` FOREIGN KEY (`volunteer_id`) REFERENCES `RegistrationVolunteer` (`volunteer_id`) ON DELETE RESTRICT ON UPDATE RESTRICT
) ENGINE = InnoDB AUTO_INCREMENT = 1 CHARACTER SET = utf8mb4 COLLATE = utf8mb4_general_ci;

-- ----------------------------
-- Records of ConsultVolunteers
-- ----------------------------
BEGIN;
COMMIT;

-- ----------------------------
-- Table structure for Donations
-- ----------------------------
DROP TABLE IF EXISTS `Donations`;
CREATE TABLE `Donations`  (
  `Id` int(11) NOT NULL AUTO_INCREMENT,
  `Name` char(60) CHARACTER SET utf8mb4 COLLATE utf8mb4_general_ci NULL DEFAULT NULL,
  `DonationTypeId` int(11) NULL DEFAULT NULL,
  `Price` decimal(18, 0) NULL DEFAULT NULL,
  `Total` decimal(18, 0) NULL DEFAULT NULL,
  `PersonId` int(11) NULL DEFAULT NULL,
  `BrigadeId` int(11) NULL DEFAULT NULL,
  `Status` longtext CHARACTER SET utf8mb4 COLLATE utf8mb4_general_ci NOT NULL DEFAULT '',
  `AssignedAt` datetime NOT NULL,
  `CreatedAt` datetime(6) NOT NULL,
  `CreatedBy` int(11) NOT NULL,
  `UpdatedAt` datetime(6) NULL DEFAULT NULL,
  `UpdatedBy` int(11) NULL DEFAULT NULL,
  `Active` tinyint(1) NOT NULL,
  `Amount` int(11) NOT NULL DEFAULT 0,
  PRIMARY KEY (`Id`) USING BTREE,
  INDEX `IX_Donations_BrigadeId`(`BrigadeId`) USING BTREE,
  INDEX `IX_Donations_DonationTypeId`(`DonationTypeId`) USING BTREE,
  INDEX `IX_Donations_PersonId`(`PersonId`) USING BTREE,
  CONSTRAINT `FK_Donations_Brigades` FOREIGN KEY (`BrigadeId`) REFERENCES `Brigades` (`Id`) ON DELETE RESTRICT ON UPDATE RESTRICT,
  CONSTRAINT `FK_Donations_DonationType` FOREIGN KEY (`DonationTypeId`) REFERENCES `DonationType` (`Id`) ON DELETE RESTRICT ON UPDATE RESTRICT,
  CONSTRAINT `FK_Donations_Donors` FOREIGN KEY (`PersonId`) REFERENCES `Donors` (`PersonId`) ON DELETE RESTRICT ON UPDATE RESTRICT
) ENGINE = InnoDB AUTO_INCREMENT = 5 CHARACTER SET = utf8mb4 COLLATE = utf8mb4_general_ci;

-- ----------------------------
-- Records of Donations
-- ----------------------------
BEGIN;
INSERT INTO `Donations` (`Id`, `Name`, `DonationTypeId`, `Price`, `Total`, `PersonId`, `BrigadeId`, `Status`, `AssignedAt`, `CreatedAt`, `CreatedBy`, `UpdatedAt`, `UpdatedBy`, `Active`, `Amount`) VALUES (1, 'donacion qwertty', 7, 123, 123, 2, 1, 'A', '2024-01-17 01:51:33', '2024-01-17 01:52:02.862680', 0, NULL, NULL, 1, 1), (2, 'qwerert', 2, 1111, 136653, NULL, NULL, 'A', '2024-01-18 04:19:22', '2024-01-18 04:19:37.542463', 0, NULL, NULL, 1, 123), (3, 'qwerert', 2, 1111, 136653, NULL, NULL, 'A', '2024-01-18 04:19:22', '2024-01-18 04:19:37.542451', 0, NULL, NULL, 1, 123), (4, 'vxcvxcv', 1, 3, 6, NULL, NULL, 'A', '2024-01-19 05:31:51', '2024-01-19 05:32:12.766539', 0, NULL, NULL, 1, 2);
COMMIT;

-- ----------------------------
-- Table structure for DonationType
-- ----------------------------
DROP TABLE IF EXISTS `DonationType`;
CREATE TABLE `DonationType`  (
  `Id` int(11) NOT NULL AUTO_INCREMENT,
  `CompanyId` int(11) NULL DEFAULT NULL,
  `Name` char(30) CHARACTER SET utf8mb4 COLLATE utf8mb4_general_ci NOT NULL,
  `Status` longtext CHARACTER SET utf8mb4 COLLATE utf8mb4_general_ci NOT NULL DEFAULT '',
  `CreatedAt` datetime(6) NOT NULL,
  `CreatedBy` int(11) NOT NULL,
  `UpdatedAt` datetime(6) NULL DEFAULT NULL,
  `UpdatedBy` int(11) NULL DEFAULT NULL,
  `Active` tinyint(1) NOT NULL,
  PRIMARY KEY (`Id`) USING BTREE
) ENGINE = InnoDB AUTO_INCREMENT = 8 CHARACTER SET = utf8mb4 COLLATE = utf8mb4_general_ci;

-- ----------------------------
-- Records of DonationType
-- ----------------------------
BEGIN;
INSERT INTO `DonationType` (`Id`, `CompanyId`, `Name`, `Status`, `CreatedAt`, `CreatedBy`, `UpdatedAt`, `UpdatedBy`, `Active`) VALUES (1, NULL, 'viveres', 'A', '2024-01-16 20:47:13.000000', 0, NULL, NULL, 1), (2, NULL, 'medicina', 'A', '2024-01-16 20:47:13.000000', 0, NULL, NULL, 1), (3, NULL, 'vestimenta', 'A', '2024-01-16 20:47:13.000000', 0, NULL, NULL, 1), (4, NULL, 'monetario', 'A', '2024-01-16 20:47:13.000000', 0, NULL, NULL, 1), (5, NULL, 'tecnologia', 'A', '2024-01-16 20:47:13.000000', 0, NULL, NULL, 1), (6, NULL, 'suministros', 'A', '2024-01-16 20:47:13.000000', 0, NULL, NULL, 1), (7, NULL, 'varios', 'A', '2024-01-16 20:47:13.000000', 0, NULL, NULL, 1);
COMMIT;

-- ----------------------------
-- Table structure for Donors
-- ----------------------------
DROP TABLE IF EXISTS `Donors`;
CREATE TABLE `Donors`  (
  `PersonId` int(11) NOT NULL,
  `Status` longtext CHARACTER SET utf8mb4 COLLATE utf8mb4_general_ci NOT NULL DEFAULT '',
  `CreatedAt` datetime(6) NOT NULL,
  `CreatedBy` int(11) NOT NULL,
  `UpdatedAt` datetime(6) NULL DEFAULT NULL,
  `UpdatedBy` int(11) NULL DEFAULT NULL,
  `Active` tinyint(1) NOT NULL,
  PRIMARY KEY (`PersonId`) USING BTREE,
  CONSTRAINT `FK_Persons_Donors` FOREIGN KEY (`PersonId`) REFERENCES `Persons` (`Id`) ON DELETE RESTRICT ON UPDATE RESTRICT
) ENGINE = InnoDB CHARACTER SET = utf8mb4 COLLATE = utf8mb4_general_ci;

-- ----------------------------
-- Records of Donors
-- ----------------------------
BEGIN;
INSERT INTO `Donors` (`PersonId`, `Status`, `CreatedAt`, `CreatedBy`, `UpdatedAt`, `UpdatedBy`, `Active`) VALUES (1, 'A', '2024-01-17 01:49:58.185563', 0, NULL, NULL, 1), (2, 'A', '2024-01-17 01:50:41.763977', 0, NULL, NULL, 1);
COMMIT;

-- ----------------------------
-- Table structure for IdentificationType
-- ----------------------------
DROP TABLE IF EXISTS `IdentificationType`;
CREATE TABLE `IdentificationType`  (
  `Id` smallint(6) NOT NULL AUTO_INCREMENT,
  `CompanyId` int(11) NULL DEFAULT NULL,
  `Code` varchar(10) CHARACTER SET utf8mb4 COLLATE utf8mb4_general_ci NOT NULL,
  `Description` varchar(50) CHARACTER SET utf8mb4 COLLATE utf8mb4_general_ci NOT NULL,
  `Status` longtext CHARACTER SET utf8mb4 COLLATE utf8mb4_general_ci NOT NULL DEFAULT '',
  `CreatedAt` datetime(6) NOT NULL,
  `CreatedBy` int(11) NOT NULL,
  `UpdatedAt` datetime(6) NULL DEFAULT NULL,
  `UpdatedBy` int(11) NULL DEFAULT NULL,
  `Active` tinyint(1) NOT NULL,
  PRIMARY KEY (`Id`) USING BTREE
) ENGINE = InnoDB AUTO_INCREMENT = 2 CHARACTER SET = utf8mb4 COLLATE = utf8mb4_general_ci;

-- ----------------------------
-- Records of IdentificationType
-- ----------------------------
BEGIN;
INSERT INTO `IdentificationType` (`Id`, `CompanyId`, `Code`, `Description`, `Status`, `CreatedAt`, `CreatedBy`, `UpdatedAt`, `UpdatedBy`, `Active`) VALUES (1, NULL, 'CC', 'Cédula de ciudadanía', 'A', '2024-01-16 20:47:13.000000', 0, NULL, NULL, 1);
COMMIT;

-- ----------------------------
-- Table structure for Persons
-- ----------------------------
DROP TABLE IF EXISTS `Persons`;
CREATE TABLE `Persons`  (
  `Id` int(11) NOT NULL AUTO_INCREMENT,
  `CompanyId` int(11) NULL DEFAULT NULL,
  `FirstName` longtext CHARACTER SET utf8mb4 COLLATE utf8mb4_general_ci NOT NULL,
  `SecondName` longtext CHARACTER SET utf8mb4 COLLATE utf8mb4_general_ci NULL DEFAULT NULL,
  `LastName` longtext CHARACTER SET utf8mb4 COLLATE utf8mb4_general_ci NOT NULL,
  `SecondLastName` longtext CHARACTER SET utf8mb4 COLLATE utf8mb4_general_ci NULL DEFAULT NULL,
  `NameCompleted` longtext CHARACTER SET utf8mb4 COLLATE utf8mb4_general_ci NOT NULL,
  `Email` longtext CHARACTER SET utf8mb4 COLLATE utf8mb4_general_ci NULL DEFAULT NULL,
  `IdentificationTypeId` smallint(6) NULL DEFAULT NULL,
  `Identification` varchar(22) CHARACTER SET utf8mb4 COLLATE utf8mb4_general_ci NOT NULL,
  `Phone` char(10) CHARACTER SET utf8mb4 COLLATE utf8mb4_general_ci NULL DEFAULT NULL,
  `UserId` int(11) NULL DEFAULT NULL,
  `Volunteer` tinyint(1) NOT NULL DEFAULT 0,
  `Donor` tinyint(1) NOT NULL DEFAULT 0,
  `Status` longtext CHARACTER SET utf8mb4 COLLATE utf8mb4_general_ci NOT NULL DEFAULT '',
  `CreatedAt` datetime(6) NOT NULL,
  `CreatedBy` int(11) NOT NULL,
  `UpdatedAt` datetime(6) NULL DEFAULT NULL,
  `UpdatedBy` int(11) NULL DEFAULT NULL,
  `Active` tinyint(1) NOT NULL,
  PRIMARY KEY (`Id`) USING BTREE,
  UNIQUE INDEX `IX_Persons_Id`(`Id`) USING BTREE,
  INDEX `IX_Persons_IdentificationTypeId`(`IdentificationTypeId`) USING BTREE,
  INDEX `IX_Persons_UserId`(`UserId`) USING BTREE,
  CONSTRAINT `FK_Persons_IdentificationType` FOREIGN KEY (`IdentificationTypeId`) REFERENCES `IdentificationType` (`Id`) ON DELETE RESTRICT ON UPDATE RESTRICT,
  CONSTRAINT `FK_Persons_Users` FOREIGN KEY (`UserId`) REFERENCES `Users` (`Id`) ON DELETE RESTRICT ON UPDATE RESTRICT
) ENGINE = InnoDB AUTO_INCREMENT = 3 CHARACTER SET = utf8mb4 COLLATE = utf8mb4_general_ci;

-- ----------------------------
-- Records of Persons
-- ----------------------------
BEGIN;
INSERT INTO `Persons` (`Id`, `CompanyId`, `FirstName`, `SecondName`, `LastName`, `SecondLastName`, `NameCompleted`, `Email`, `IdentificationTypeId`, `Identification`, `Phone`, `UserId`, `Volunteer`, `Donor`, `Status`, `CreatedAt`, `CreatedBy`, `UpdatedAt`, `UpdatedBy`, `Active`) VALUES (1, 1, 'qwerty', 'qwerty', 'qwerty', 'qwerty', 'qwerty qwerty qwerty qwerty', 'qwet@qwertt.qq', 1, '0923811442', '0989548582', NULL, 0, 0, 'A', '2024-01-17 01:49:58.185539', 1, '2024-01-17 01:50:19.280326', NULL, 1), (2, 1, 'qwerrt', 'qwerty', 'qweerrt', 'qweetr', 'qwerrt qwerty qweerrt qwerty', 'qaqweqw@qweqwe.qq', 1, '0923811444', '0454554', NULL, 1, 0, 'A', '2024-01-17 01:50:41.763967', 1, '2024-01-17 02:01:46.542062', NULL, 1);
COMMIT;

-- ----------------------------
-- Table structure for RegistrationVolunteer
-- ----------------------------
DROP TABLE IF EXISTS `RegistrationVolunteer`;
CREATE TABLE `RegistrationVolunteer`  (
  `volunteer_id` int(11) NOT NULL AUTO_INCREMENT,
  `donor_id` int(11) NULL DEFAULT NULL,
  `name` varchar(45) CHARACTER SET utf8mb4 COLLATE utf8mb4_general_ci NULL DEFAULT NULL,
  `lastname` varchar(45) CHARACTER SET utf8mb4 COLLATE utf8mb4_general_ci NULL DEFAULT NULL,
  `gender` varchar(45) CHARACTER SET utf8mb4 COLLATE utf8mb4_general_ci NULL DEFAULT NULL,
  `address` varchar(60) CHARACTER SET utf8mb4 COLLATE utf8mb4_general_ci NULL DEFAULT NULL,
  `telephone` int(11) NULL DEFAULT NULL,
  `mail` varchar(45) CHARACTER SET utf8mb4 COLLATE utf8mb4_general_ci NULL DEFAULT NULL,
  `availability` varchar(60) CHARACTER SET utf8mb4 COLLATE utf8mb4_general_ci NULL DEFAULT NULL,
  `start_date` date NULL DEFAULT NULL,
  `end_date` date NULL DEFAULT NULL,
  `activity` varchar(50) CHARACTER SET utf8mb4 COLLATE utf8mb4_general_ci NULL DEFAULT NULL,
  `CreatedAt` datetime(6) NOT NULL,
  `CreatedBy` int(11) NOT NULL,
  `UpdatedAt` datetime(6) NULL DEFAULT NULL,
  `UpdatedBy` int(11) NULL DEFAULT NULL,
  `Active` tinyint(1) NOT NULL,
  PRIMARY KEY (`volunteer_id`) USING BTREE
) ENGINE = InnoDB AUTO_INCREMENT = 1 CHARACTER SET = utf8mb4 COLLATE = utf8mb4_general_ci;

-- ----------------------------
-- Records of RegistrationVolunteer
-- ----------------------------
BEGIN;
COMMIT;

-- ----------------------------
-- Table structure for SmtpConfigurations
-- ----------------------------
DROP TABLE IF EXISTS `SmtpConfigurations`;
CREATE TABLE `SmtpConfigurations`  (
  `Id` int(11) NOT NULL AUTO_INCREMENT,
  `CompanyId` int(11) NOT NULL,
  `Profile` int(11) NOT NULL,
  `Mail` longtext CHARACTER SET utf8mb4 COLLATE utf8mb4_general_ci NOT NULL,
  `DisplayName` longtext CHARACTER SET utf8mb4 COLLATE utf8mb4_general_ci NOT NULL,
  `Password` longtext CHARACTER SET utf8mb4 COLLATE utf8mb4_general_ci NOT NULL,
  `Host` longtext CHARACTER SET utf8mb4 COLLATE utf8mb4_general_ci NOT NULL,
  `Port` int(11) NOT NULL,
  `Authenticate` tinyint(1) NOT NULL,
  `Status` longtext CHARACTER SET utf8mb4 COLLATE utf8mb4_general_ci NOT NULL DEFAULT '',
  `CreatedAt` datetime(6) NOT NULL,
  `CreatedBy` int(11) NOT NULL,
  `UpdatedAt` datetime(6) NULL DEFAULT NULL,
  `UpdatedBy` int(11) NULL DEFAULT NULL,
  `Active` tinyint(1) NOT NULL,
  PRIMARY KEY (`Id`) USING BTREE,
  INDEX `IX_SmtpConfigurations_CompanyId`(`CompanyId`) USING BTREE,
  CONSTRAINT `FK_SmtpConfigurations_Company` FOREIGN KEY (`CompanyId`) REFERENCES `Company` (`Id`) ON DELETE CASCADE ON UPDATE RESTRICT
) ENGINE = InnoDB AUTO_INCREMENT = 4 CHARACTER SET = utf8mb4 COLLATE = utf8mb4_general_ci;

-- ----------------------------
-- Records of SmtpConfigurations
-- ----------------------------
BEGIN;
COMMIT;

-- ----------------------------
-- Table structure for Users
-- ----------------------------
DROP TABLE IF EXISTS `Users`;
CREATE TABLE `Users`  (
  `Id` int(11) NOT NULL AUTO_INCREMENT,
  `Identification` varchar(21) CHARACTER SET utf8mb4 COLLATE utf8mb4_general_ci NOT NULL,
  `Name` varchar(255) CHARACTER SET utf8mb4 COLLATE utf8mb4_general_ci NOT NULL,
  `Email` varchar(150) CHARACTER SET utf8mb4 COLLATE utf8mb4_general_ci NOT NULL,
  `Password` longtext CHARACTER SET utf8mb4 COLLATE utf8mb4_general_ci NOT NULL,
  `Salt` longtext CHARACTER SET utf8mb4 COLLATE utf8mb4_general_ci NOT NULL DEFAULT '',
  `Status` longtext CHARACTER SET utf8mb4 COLLATE utf8mb4_general_ci NOT NULL DEFAULT '',
  `TempCode` longtext CHARACTER SET utf8mb4 COLLATE utf8mb4_general_ci NULL DEFAULT NULL,
  `TempCodeCreateAt` datetime(6) NULL DEFAULT NULL,
  `CreatedAt` datetime(6) NOT NULL,
  `CreatedBy` int(11) NOT NULL,
  `UpdatedAt` datetime(6) NULL DEFAULT NULL,
  `UpdatedBy` int(11) NULL DEFAULT NULL,
  `Active` tinyint(1) NOT NULL,
  PRIMARY KEY (`Id`) USING BTREE
) ENGINE = InnoDB AUTO_INCREMENT = 24 CHARACTER SET = utf8mb4 COLLATE = utf8mb4_general_ci;

-- ----------------------------
-- Records of Users
-- ----------------------------
BEGIN;
INSERT INTO `Users` (`Id`, `Identification`, `Name`, `Email`, `Password`, `Salt`, `Status`, `TempCode`, `TempCodeCreateAt`, `CreatedAt`, `CreatedBy`, `UpdatedAt`, `UpdatedBy`, `Active`) VALUES (1, '9999999999999', 'System', 'system@email.com', 'hx7w741jRKptsZJYyBjLQfz4agjKMGEJoK0kVwbbthI=', 'UhfyKxRscxd78Aoj0WOzigBOnis+fUNtHEc8kfQkOCg=', 'A', 'f4d97b19-451b-4c1f-9254-9cb4d1cbc0cf', NULL, '2024-01-16 20:47:13.000000', 0, NULL, NULL, 0), (2, '0923811442', 'fabian qwert', 'fabian@gmail.com', 'TbKwtiKo+WkWsTvh1dHS0gS1e4scCe5iioVyeqB+RPQ=', '2vPofD8P5JjgaHTC3Bj835qxG47v/oUhgxJ9n57WvzQ=', 'A', NULL, NULL, '2024-01-19 03:28:50.735154', 1, '2024-01-19 08:47:36.667015', 1, 1), (21, '0923811441', 'a', 'asdas@asda.aa', '7Ggqit58TjfO0DnWdryRgdz69PjtERaztg4iq+yiNzo=', 'kmdQqVQWthutEON66sYiD/EvjL+w9HyZAQb+GdqFIP4=', 'A', NULL, NULL, '2024-01-19 03:33:33.236277', 1, '2024-01-19 08:47:45.997994', 1, 1), (22, 'qqq', 'qwerty', 'prueba', '2eMM+ZQIONacnCZKy5CR0slh4aJu8Bi+LbJKCPdTTjc=', '/BcQVpPwNfOQpXPP+plOlFx6eQwNXIL4ASGirvMJN/w=', 'A', NULL, NULL, '2024-01-19 03:34:40.905335', 1, '2024-01-19 08:47:51.718844', 1, 0), (23, 'tt', 'qwertaaa', '@aaa', 'quH5lqwlSYOyRAIw1FByATXZ8KEQpkZTqwOHH1uAph4=', '8M3JulRnCM1KxQ406kfG5BvZ2pTQliudJOfNgbxmZmM=', 'A', NULL, NULL, '2024-01-19 03:34:55.792900', 1, '2024-01-19 08:48:02.378615', 1, 1);
COMMIT;

-- ----------------------------
-- Table structure for Volunteers
-- ----------------------------
DROP TABLE IF EXISTS `Volunteers`;
CREATE TABLE `Volunteers`  (
  `PersonId` int(11) NOT NULL,
  `Gender` varchar(45) CHARACTER SET utf8mb4 COLLATE utf8mb4_general_ci NOT NULL,
  `Address` varchar(60) CHARACTER SET utf8mb4 COLLATE utf8mb4_general_ci NOT NULL,
  `Status` longtext CHARACTER SET utf8mb4 COLLATE utf8mb4_general_ci NOT NULL DEFAULT '',
  `Availability` tinyint(1) NOT NULL,
  `StartDate` date NOT NULL,
  `EndDate` date NOT NULL,
  `ActivityTypeId` int(11) NOT NULL,
  `CreatedAt` datetime(6) NOT NULL,
  `CreatedBy` int(11) NOT NULL,
  `UpdatedAt` datetime(6) NULL DEFAULT NULL,
  `UpdatedBy` int(11) NULL DEFAULT NULL,
  `Active` tinyint(1) NOT NULL,
  PRIMARY KEY (`PersonId`) USING BTREE,
  INDEX `IX_Volunteers_ActivityTypeId`(`ActivityTypeId`) USING BTREE,
  CONSTRAINT `FK_Volunteers_ActivityType` FOREIGN KEY (`ActivityTypeId`) REFERENCES `ActivityType` (`Id`) ON DELETE RESTRICT ON UPDATE RESTRICT,
  CONSTRAINT `FK_Volunteers_Persons` FOREIGN KEY (`PersonId`) REFERENCES `Persons` (`Id`) ON DELETE RESTRICT ON UPDATE RESTRICT
) ENGINE = InnoDB CHARACTER SET = utf8mb4 COLLATE = utf8mb4_general_ci;

-- ----------------------------
-- Records of Volunteers
-- ----------------------------
BEGIN;
COMMIT;

SET FOREIGN_KEY_CHECKS = 1;