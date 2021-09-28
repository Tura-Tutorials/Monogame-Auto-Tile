-- --------------------------------------------------------
-- Host:                         127.0.0.1
-- Server version:               10.4.17-MariaDB - mariadb.org binary distribution
-- Server OS:                    Win64
-- HeidiSQL Version:             11.2.0.6213
-- --------------------------------------------------------

/*!40101 SET @OLD_CHARACTER_SET_CLIENT=@@CHARACTER_SET_CLIENT */;
/*!40101 SET NAMES utf8 */;
/*!50503 SET NAMES utf8mb4 */;
/*!40014 SET @OLD_FOREIGN_KEY_CHECKS=@@FOREIGN_KEY_CHECKS, FOREIGN_KEY_CHECKS=0 */;
/*!40101 SET @OLD_SQL_MODE=@@SQL_MODE, SQL_MODE='NO_AUTO_VALUE_ON_ZERO' */;
/*!40111 SET @OLD_SQL_NOTES=@@SQL_NOTES, SQL_NOTES=0 */;


-- Dumping database structure for endorblast
CREATE DATABASE IF NOT EXISTS `endorblast` /*!40100 DEFAULT CHARACTER SET utf8mb4 */;
USE `endorblast`;

-- Dumping structure for table endorblast.accounts
CREATE TABLE IF NOT EXISTS `accounts` (
  `id` int(11) NOT NULL AUTO_INCREMENT,
  `Email` varchar(50) NOT NULL,
  `Username` varchar(50) NOT NULL,
  KEY `id` (`id`)
) ENGINE=InnoDB AUTO_INCREMENT=2 DEFAULT CHARSET=utf8mb4;

-- Dumping data for table endorblast.accounts: ~0 rows (approximately)
DELETE FROM `accounts`;
/*!40000 ALTER TABLE `accounts` DISABLE KEYS */;
INSERT INTO `accounts` (`id`, `Email`, `Username`) VALUES
	(1, 'test@test.com', 'zyro');
/*!40000 ALTER TABLE `accounts` ENABLE KEYS */;

-- Dumping structure for table endorblast.accounts_information
CREATE TABLE IF NOT EXISTS `accounts_information` (
  `id` int(11) NOT NULL AUTO_INCREMENT,
  `AccountID` int(11) NOT NULL,
  `LastOnline` datetime NOT NULL,
  `LastIP` varchar(50) NOT NULL,
  `PremiumCurrency` int(11) NOT NULL DEFAULT 0,
  KEY `id` (`id`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4;

-- Dumping data for table endorblast.accounts_information: ~0 rows (approximately)
DELETE FROM `accounts_information`;
/*!40000 ALTER TABLE `accounts_information` DISABLE KEYS */;
/*!40000 ALTER TABLE `accounts_information` ENABLE KEYS */;

-- Dumping structure for table endorblast.accounts_password
CREATE TABLE IF NOT EXISTS `accounts_password` (
  `id` int(11) NOT NULL AUTO_INCREMENT,
  `AccountID` int(11) DEFAULT NULL,
  `Password` varchar(255) NOT NULL DEFAULT '0',
  KEY `Column 1` (`id`)
) ENGINE=InnoDB AUTO_INCREMENT=2 DEFAULT CHARSET=utf8mb4;

-- Dumping data for table endorblast.accounts_password: ~0 rows (approximately)
DELETE FROM `accounts_password`;
/*!40000 ALTER TABLE `accounts_password` DISABLE KEYS */;
INSERT INTO `accounts_password` (`id`, `AccountID`, `Password`) VALUES
	(1, 1, '$2a$11$QmkjKgdJ/SheaS82V9cFc.IPjPvKi.AoHw7rpBsbpvyU.aYPFWcmG');
/*!40000 ALTER TABLE `accounts_password` ENABLE KEYS */;

-- Dumping structure for table endorblast.accounts_permission
CREATE TABLE IF NOT EXISTS `accounts_permission` (
  `id` int(11) NOT NULL,
  `AccountID` int(11) NOT NULL,
  `GameRole` int(11) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4;

-- Dumping data for table endorblast.accounts_permission: ~0 rows (approximately)
DELETE FROM `accounts_permission`;
/*!40000 ALTER TABLE `accounts_permission` DISABLE KEYS */;
/*!40000 ALTER TABLE `accounts_permission` ENABLE KEYS */;

-- Dumping structure for table endorblast.characters
CREATE TABLE IF NOT EXISTS `characters` (
  `id` int(11) NOT NULL,
  `AccountID` int(11) NOT NULL,
  `CharacterName` varchar(255) NOT NULL,
  PRIMARY KEY (`id`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4;

-- Dumping data for table endorblast.characters: ~2 rows (approximately)
DELETE FROM `characters`;
/*!40000 ALTER TABLE `characters` DISABLE KEYS */;
INSERT INTO `characters` (`id`, `AccountID`, `CharacterName`) VALUES
	(1, 1, 'Zyro'),
	(2, 1, 'Maikatura');
/*!40000 ALTER TABLE `characters` ENABLE KEYS */;

-- Dumping structure for table endorblast.characters_cosmetic
CREATE TABLE IF NOT EXISTS `characters_cosmetic` (
  `id` int(10) NOT NULL AUTO_INCREMENT,
  `HairID` int(10) NOT NULL,
  `HairColor` varchar(8) NOT NULL,
  `SkinColor` varchar(8) DEFAULT NULL,
  `EyeColor` varchar(8) NOT NULL,
  `WeaponCosmID` int(11) NOT NULL DEFAULT 0,
  `HelmetCosmID` int(11) NOT NULL DEFAULT 0,
  `ArmorCosmID` int(11) NOT NULL DEFAULT 0,
  `ShoesCosmID` int(11) NOT NULL DEFAULT 0,
  KEY `id` (`id`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4;

-- Dumping data for table endorblast.characters_cosmetic: ~0 rows (approximately)
DELETE FROM `characters_cosmetic`;
/*!40000 ALTER TABLE `characters_cosmetic` DISABLE KEYS */;
/*!40000 ALTER TABLE `characters_cosmetic` ENABLE KEYS */;

-- Dumping structure for table endorblast.characters_currency
CREATE TABLE IF NOT EXISTS `characters_currency` (
  `id` int(11) NOT NULL AUTO_INCREMENT,
  `CharacterID` int(11) NOT NULL,
  `InvGold` int(11) NOT NULL DEFAULT 0,
  `StorageGold` int(11) NOT NULL DEFAULT 0,
  KEY `id` (`id`)
) ENGINE=InnoDB AUTO_INCREMENT=2 DEFAULT CHARSET=utf8mb4;

-- Dumping data for table endorblast.characters_currency: ~0 rows (approximately)
DELETE FROM `characters_currency`;
/*!40000 ALTER TABLE `characters_currency` DISABLE KEYS */;
INSERT INTO `characters_currency` (`id`, `CharacterID`, `InvGold`, `StorageGold`) VALUES
	(1, 2, 921, 1231);
/*!40000 ALTER TABLE `characters_currency` ENABLE KEYS */;

-- Dumping structure for table endorblast.characters_equipment
CREATE TABLE IF NOT EXISTS `characters_equipment` (
  `id` int(11) NOT NULL AUTO_INCREMENT,
  `CharacterID` int(11) NOT NULL DEFAULT 0,
  `HeadItemID` int(11) NOT NULL DEFAULT 0,
  `ArmorItemID` int(11) NOT NULL DEFAULT 0,
  `LegsItemID` int(11) NOT NULL DEFAULT 0,
  `ShoesArmorID` int(11) NOT NULL DEFAULT 0,
  `WeaponItemID` int(11) NOT NULL DEFAULT 0,
  `SubWeaponItemID` int(11) NOT NULL DEFAULT 0,
  `PetItemID` int(11) NOT NULL DEFAULT 0,
  KEY `id` (`id`)
) ENGINE=InnoDB AUTO_INCREMENT=2 DEFAULT CHARSET=utf8mb4;

-- Dumping data for table endorblast.characters_equipment: ~1 rows (approximately)
DELETE FROM `characters_equipment`;
/*!40000 ALTER TABLE `characters_equipment` DISABLE KEYS */;
INSERT INTO `characters_equipment` (`id`, `CharacterID`, `HeadItemID`, `ArmorItemID`, `LegsItemID`, `ShoesArmorID`, `WeaponItemID`, `SubWeaponItemID`, `PetItemID`) VALUES
	(1, 1, 1, 1, 1, 1, 1, 1, 1);
/*!40000 ALTER TABLE `characters_equipment` ENABLE KEYS */;

-- Dumping structure for table endorblast.characters_information
CREATE TABLE IF NOT EXISTS `characters_information` (
  `id` int(11) NOT NULL AUTO_INCREMENT,
  `CharacterID` int(11) NOT NULL,
  `InventorySlots` int(11) NOT NULL DEFAULT 24,
  `BankSlots` int(11) NOT NULL DEFAULT 12,
  KEY `id` (`id`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4;

-- Dumping data for table endorblast.characters_information: ~0 rows (approximately)
DELETE FROM `characters_information`;
/*!40000 ALTER TABLE `characters_information` DISABLE KEYS */;
/*!40000 ALTER TABLE `characters_information` ENABLE KEYS */;

-- Dumping structure for table endorblast.characters_positions
CREATE TABLE IF NOT EXISTS `characters_positions` (
  `id` int(11) NOT NULL,
  `CharacterID` int(11) NOT NULL,
  `WorldID` int(11) NOT NULL DEFAULT 0,
  `X` float NOT NULL,
  `Y` float NOT NULL,
  KEY `id` (`id`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4;

-- Dumping data for table endorblast.characters_positions: ~1 rows (approximately)
DELETE FROM `characters_positions`;
/*!40000 ALTER TABLE `characters_positions` DISABLE KEYS */;
INSERT INTO `characters_positions` (`id`, `CharacterID`, `WorldID`, `X`, `Y`) VALUES
	(1, 2, 0, 3.3, 1.4);
/*!40000 ALTER TABLE `characters_positions` ENABLE KEYS */;

-- Dumping structure for table endorblast.characters_stats
CREATE TABLE IF NOT EXISTS `characters_stats` (
  `id` int(11) NOT NULL AUTO_INCREMENT,
  `CharacterID` int(11) NOT NULL,
  `Level` int(11) NOT NULL DEFAULT 1,
  `Exp` int(11) NOT NULL DEFAULT 0,
  KEY `id` (`id`)
) ENGINE=InnoDB AUTO_INCREMENT=4 DEFAULT CHARSET=utf8mb4;

-- Dumping data for table endorblast.characters_stats: ~2 rows (approximately)
DELETE FROM `characters_stats`;
/*!40000 ALTER TABLE `characters_stats` DISABLE KEYS */;
INSERT INTO `characters_stats` (`id`, `CharacterID`, `Level`, `Exp`) VALUES
	(2, 2, 100, 12),
	(1, 1, 144, 0);
/*!40000 ALTER TABLE `characters_stats` ENABLE KEYS */;

-- Dumping structure for table endorblast.chat_commands
CREATE TABLE IF NOT EXISTS `chat_commands` (
  `id` int(11) NOT NULL AUTO_INCREMENT,
  KEY `id` (`id`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4;

-- Dumping data for table endorblast.chat_commands: ~0 rows (approximately)
DELETE FROM `chat_commands`;
/*!40000 ALTER TABLE `chat_commands` DISABLE KEYS */;
/*!40000 ALTER TABLE `chat_commands` ENABLE KEYS */;

-- Dumping structure for table endorblast.gameobject
CREATE TABLE IF NOT EXISTS `gameobject` (
  `Id` int(11) NOT NULL AUTO_INCREMENT,
  `Type` int(11) NOT NULL,
  `TransformId` int(11) NOT NULL,
  `Experiance` decimal(18,0) NOT NULL,
  `InteractItemType` int(11) NOT NULL,
  `RespawnMilliseconds` int(11) NOT NULL,
  `Static` bit(1) NOT NULL,
  PRIMARY KEY (`Id`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4;

-- Dumping data for table endorblast.gameobject: ~0 rows (approximately)
DELETE FROM `gameobject`;
/*!40000 ALTER TABLE `gameobject` DISABLE KEYS */;
/*!40000 ALTER TABLE `gameobject` ENABLE KEYS */;

-- Dumping structure for table endorblast.inventoryitem
CREATE TABLE IF NOT EXISTS `inventoryitem` (
  `Id` int(11) NOT NULL AUTO_INCREMENT,
  `PlayerId` int(11) NOT NULL DEFAULT 0,
  `ItemId` int(11) NOT NULL DEFAULT 0,
  `Amount` int(11) NOT NULL DEFAULT 0,
  `Equipped` bit(1) NOT NULL DEFAULT b'0',
  PRIMARY KEY (`Id`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4;

-- Dumping data for table endorblast.inventoryitem: ~0 rows (approximately)
DELETE FROM `inventoryitem`;
/*!40000 ALTER TABLE `inventoryitem` DISABLE KEYS */;
/*!40000 ALTER TABLE `inventoryitem` ENABLE KEYS */;

-- Dumping structure for table endorblast.item
CREATE TABLE IF NOT EXISTS `item` (
  `Id` int(11) NOT NULL,
  `Name` varchar(50) NOT NULL DEFAULT '',
  `Stackable` bit(1) NOT NULL DEFAULT b'0',
  `Equippable` bit(1) NOT NULL DEFAULT b'0',
  `Consumable` bit(1) NOT NULL DEFAULT b'0',
  `IconSheetId` int(11) NOT NULL DEFAULT 0,
  `IconId` int(11) NOT NULL DEFAULT 0,
  `Value` int(11) NOT NULL DEFAULT 0,
  PRIMARY KEY (`Id`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4;

-- Dumping data for table endorblast.item: ~0 rows (approximately)
DELETE FROM `item`;
/*!40000 ALTER TABLE `item` DISABLE KEYS */;
INSERT INTO `item` (`Id`, `Name`, `Stackable`, `Equippable`, `Consumable`, `IconSheetId`, `IconId`, `Value`) VALUES
	(1, 'Super Armor', b'0', b'1', b'0', 1, 1, 10);
/*!40000 ALTER TABLE `item` ENABLE KEYS */;

-- Dumping structure for table endorblast.itemdrop
CREATE TABLE IF NOT EXISTS `itemdrop` (
  `Id` int(11) NOT NULL AUTO_INCREMENT,
  `EntityId` int(11) NOT NULL DEFAULT 0,
  `EntityType` int(11) NOT NULL DEFAULT 0,
  `ItemId` int(11) NOT NULL DEFAULT 0,
  `DropChance` float NOT NULL DEFAULT 0,
  PRIMARY KEY (`Id`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4;

-- Dumping data for table endorblast.itemdrop: ~0 rows (approximately)
DELETE FROM `itemdrop`;
/*!40000 ALTER TABLE `itemdrop` DISABLE KEYS */;
/*!40000 ALTER TABLE `itemdrop` ENABLE KEYS */;

-- Dumping structure for table endorblast.items
CREATE TABLE IF NOT EXISTS `items` (
  `id` int(10) NOT NULL AUTO_INCREMENT,
  `Name` varchar(30) NOT NULL,
  `ImagePath` varchar(250) NOT NULL,
  `MaxStack` int(11) NOT NULL,
  `Active` bit(1) NOT NULL DEFAULT b'1',
  KEY `id` (`id`)
) ENGINE=InnoDB AUTO_INCREMENT=8 DEFAULT CHARSET=utf8mb4;

-- Dumping data for table endorblast.items: ~6 rows (approximately)
DELETE FROM `items`;
/*!40000 ALTER TABLE `items` DISABLE KEYS */;
INSERT INTO `items` (`id`, `Name`, `ImagePath`, `MaxStack`, `Active`) VALUES
	(1, 'Super Armor', 'Content/Textures/Items/Armor/Armor1.png', 0, b'1'),
	(2, 'Super Armor 2', 'Content/Textures/Items/Armor/Armor2.png', 0, b'1'),
	(3, 'Super Weapon', 'Content/Textures/Items/Weapons/Weapon1.png', 0, b'1'),
	(4, 'Super Legs', 'Content/Textures/Items/Legs/Leg1.png', 0, b'1'),
	(5, 'Super Helmet', 'Content/Textures/Items/Helmets/helmet1.png', 0, b'1'),
	(6, 'Super Shield', 'Content/Textures/Items/Offhands/Offhand1.png', 0, b'1'),
	(7, 'Super Shoes', 'Content/Textures/Items/Shoes/shoe1.png', 0, b'1');
/*!40000 ALTER TABLE `items` ENABLE KEYS */;

-- Dumping structure for table endorblast.items_equipment
CREATE TABLE IF NOT EXISTS `items_equipment` (
  `id` int(11) NOT NULL AUTO_INCREMENT,
  `ItemID` int(11) NOT NULL,
  `ItemFolder` varchar(50) NOT NULL DEFAULT '',
  `Attack` int(11) NOT NULL,
  `Armor` int(11) NOT NULL,
  `Strength` int(11) NOT NULL,
  KEY `id` (`id`)
) ENGINE=InnoDB AUTO_INCREMENT=2 DEFAULT CHARSET=utf8mb4;

-- Dumping data for table endorblast.items_equipment: ~0 rows (approximately)
DELETE FROM `items_equipment`;
/*!40000 ALTER TABLE `items_equipment` DISABLE KEYS */;
INSERT INTO `items_equipment` (`id`, `ItemID`, `ItemFolder`, `Attack`, `Armor`, `Strength`) VALUES
	(1, 1, '', 1, 10, 100);
/*!40000 ALTER TABLE `items_equipment` ENABLE KEYS */;

-- Dumping structure for table endorblast.roles
CREATE TABLE IF NOT EXISTS `roles` (
  `id` int(11) NOT NULL AUTO_INCREMENT,
  `Permission` int(11) NOT NULL,
  `RankName` varchar(50) NOT NULL DEFAULT '',
  `RankTag` varchar(50) DEFAULT '',
  `Active` tinyint(1) NOT NULL DEFAULT 1,
  KEY `id` (`id`)
) ENGINE=InnoDB AUTO_INCREMENT=31 DEFAULT CHARSET=utf8mb4;

-- Dumping data for table endorblast.roles: ~5 rows (approximately)
DELETE FROM `roles`;
/*!40000 ALTER TABLE `roles` DISABLE KEYS */;
INSERT INTO `roles` (`id`, `Permission`, `RankName`, `RankTag`, `Active`) VALUES
	(22, 10, 'Default', 'Default', 1),
	(23, 50, 'Moderator', 'Mod', 1),
	(24, 1000, 'Developer', 'Dev', 1),
	(25, 0, 'BANNED', 'BANNED', 1),
	(30, 100, 'Administrator', 'Admin', 1);
/*!40000 ALTER TABLE `roles` ENABLE KEYS */;

-- Dumping structure for table endorblast.roles_users
CREATE TABLE IF NOT EXISTS `roles_users` (
  `id` int(11) NOT NULL AUTO_INCREMENT,
  `AccountID` int(11) NOT NULL,
  `roleID` int(11) NOT NULL DEFAULT 0,
  KEY `id` (`id`)
) ENGINE=InnoDB AUTO_INCREMENT=3 DEFAULT CHARSET=utf8mb4;

-- Dumping data for table endorblast.roles_users: ~1 rows (approximately)
DELETE FROM `roles_users`;
/*!40000 ALTER TABLE `roles_users` DISABLE KEYS */;
INSERT INTO `roles_users` (`id`, `AccountID`, `roleID`) VALUES
	(1, 1, 22);
/*!40000 ALTER TABLE `roles_users` ENABLE KEYS */;

-- Dumping structure for table endorblast.server_info
CREATE TABLE IF NOT EXISTS `server_info` (
  `id` int(11) NOT NULL AUTO_INCREMENT,
  `secret` int(11) NOT NULL,
  KEY `id` (`id`)
) ENGINE=InnoDB AUTO_INCREMENT=2 DEFAULT CHARSET=utf8mb4;

-- Dumping data for table endorblast.server_info: ~0 rows (approximately)
DELETE FROM `server_info`;
/*!40000 ALTER TABLE `server_info` DISABLE KEYS */;
INSERT INTO `server_info` (`id`, `secret`) VALUES
	(1, 2147483647);
/*!40000 ALTER TABLE `server_info` ENABLE KEYS */;

/*!40101 SET SQL_MODE=IFNULL(@OLD_SQL_MODE, '') */;
/*!40014 SET FOREIGN_KEY_CHECKS=IFNULL(@OLD_FOREIGN_KEY_CHECKS, 1) */;
/*!40101 SET CHARACTER_SET_CLIENT=@OLD_CHARACTER_SET_CLIENT */;
/*!40111 SET SQL_NOTES=IFNULL(@OLD_SQL_NOTES, 1) */;
