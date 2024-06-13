-- phpMyAdmin SQL Dump
-- version 4.5.4.1
-- http://www.phpmyadmin.net
--
-- Client :  localhost
-- Généré le :  Jeu 13 Juin 2024 à 08:39
-- Version du serveur :  5.7.11
-- Version de PHP :  5.6.18

SET SQL_MODE = "NO_AUTO_VALUE_ON_ZERO";
SET time_zone = "+00:00";


/*!40101 SET @OLD_CHARACTER_SET_CLIENT=@@CHARACTER_SET_CLIENT */;
/*!40101 SET @OLD_CHARACTER_SET_RESULTS=@@CHARACTER_SET_RESULTS */;
/*!40101 SET @OLD_COLLATION_CONNECTION=@@COLLATION_CONNECTION */;
/*!40101 SET NAMES utf8mb4 */;

--
-- Base de données :  `db_pcorps`
--
CREATE DATABASE IF NOT EXISTS `db_pcorps` DEFAULT CHARACTER SET utf8mb4 COLLATE utf8mb4_general_ci;
USE `db_pcorps`;

-- --------------------------------------------------------

--
-- Structure de la table `t_decritexercice`
--

CREATE TABLE `t_decritexercice` (
  `fkExercice` int(11) NOT NULL,
  `fkLienWeb` varchar(255) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4;

-- --------------------------------------------------------

--
-- Structure de la table `t_decritremede`
--

CREATE TABLE `t_decritremede` (
  `fkRemede` int(11) NOT NULL,
  `fkLienWeb` varchar(255) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4;

-- --------------------------------------------------------

--
-- Structure de la table `t_exercice`
--

CREATE TABLE `t_exercice` (
  `idExercice` int(11) NOT NULL,
  `exeNom` varchar(50) DEFAULT NULL,
  `exeExplication` varchar(2000) NOT NULL,
  `exeAvertissement` varchar(300) DEFAULT NULL,
  `ExePersonneConvient` varchar(100) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4;

--
-- Contenu de la table `t_exercice`
--

INSERT INTO `t_exercice` (`idExercice`, `exeNom`, `exeExplication`, `exeAvertissement`, `ExePersonneConvient`) VALUES
(1, 'Cercles de la cheville', '1. Asseyez-vous confortablement sur une chaise ?. 2. Soulevez un pied du sol ?. 3. Faites des cercles avec votre cheville dans le sens des aiguilles d\'une montre pendant 20 secondes ??. 4. Changez de direction et faites des cercles dans le sens inverse pendant 20 secondes ?.', 'Ne forcez pas si vous ressentez une douleur aiguë. Cet exercice est déconseillé aux personnes ayant des fractures récentes à la cheville.', 'Tous'),
(2, 'Étirement des quadriceps', '1. Tenez-vous droit et attrapez votre cheville droite avec votre main droite derrière vous ?. 2. Tirez doucement votre pied vers vos fesses jusqu\'à sentir un étirement à l\'avant de la cuisse ?. 3. Maintenez pendant 30 secondes, puis changez de jambe ?.', 'Ne pas forcer l\'étirement. Déconseillé en cas de blessures récentes aux genoux.', 'Tous'),
(3, 'Flexion des genoux', '1. Tenez-vous debout avec les pieds écartés à la largeur des épaules ?. 2. Pliez lentement les genoux en descendant comme pour vous asseoir sur une chaise invisible ?. 3. Remontez doucement en position debout ?.', 'Gardez les genoux alignés avec les orteils. Évitez en cas de douleurs aiguës au genou.', 'Tous'),
(4, 'Marches sur place', '1. Tenez-vous droit et marchez sur place en levant les genoux aussi haut que possible ?. 2. Faites cela pendant 1 minute ?.', 'Faites attention à vos genoux si vous avez des douleurs chroniques.', 'Tous'),
(5, 'Étirement des mollets', '1. Placez-vous face à un mur, une jambe en avant et l\'autre en arrière ?. 2. Pliez le genou avant tout en gardant le talon arrière au sol ?. 3. Maintenez pendant 30 secondes et changez de jambe ?.', 'Ne forcez pas l\'étirement. Déconseillé en cas de tendinite aiguë.', 'Tous'),
(6, 'Flexion et extension des orteils', '1. Asseyez-vous et retirez vos chaussures et chaussettes ?. 2. Étendez et pliez vos orteils autant que possible ?. 3. Répétez pendant 1 minute ?.', 'Ne pas forcer les mouvements. Évitez si vous avez des blessures aux orteils.', 'Tous'),
(7, 'Rouler une balle', '1. Asseyez-vous et placez une balle de tennis sous votre pied ?. 2. Roulez la balle sous la plante du pied en exerçant une légère pression ?. 3. Faites cela pendant 1 minute, puis changez de pied ?.', 'Ne pas exercer une pression excessive. Déconseillé en cas de douleur aiguë à la plante.', 'Tous'),
(8, 'Étirement du talon', '1. Asseyez-vous et placez une serviette autour de la plante de votre pied ?. 2. Tirez doucement les extrémités de la serviette vers vous, en maintenant la jambe tendue ?. 3. Maintenez pendant 30 secondes, puis changez de pied ?.', 'Ne forcez pas l\'étirement. Évitez en cas de douleur aiguë au talon.', 'Tous'),
(9, 'Flexion de l\'avant-bras', '1. Tendez un bras devant vous avec la paume vers le haut ?. 2. Avec l\'autre main, tirez doucement les doigts vers l\'arrière ??. 3. Maintenez pendant 15 secondes, puis changez de bras ?.', 'Ne pas forcer. Déconseillé en cas de tendinite aiguë.', 'Tous'),
(10, 'Extension du triceps', '1. Levez un bras au-dessus de votre tête et pliez-le pour toucher l\'omoplate ?. 2. Avec l\'autre main, poussez doucement le coude vers le bas ??. 3. Maintenez pendant 15 secondes, puis changez de bras ?.', 'Évitez en cas de douleur aiguë au coude.', 'Tous'),
(11, 'Roulements d\'épaules', '1. Tenez-vous droit et levez les épaules vers vos oreilles ?. 2. Faites des cercles avec vos épaules vers l\'arrière et vers le bas ?. 3. Répétez 10 fois, puis changez de direction ?.', 'Évitez les mouvements brusques. Déconseillé en cas de blessures à l\'épaule.', 'Tous'),
(12, 'Flexion du poignet', '1. Tendez un bras devant vous avec la paume vers le bas ?. 2. Avec l\'autre main, tirez doucement les doigts vers vous ?. 3. Maintenez pendant 15 secondes, puis changez de bras ?.', 'Ne pas forcer. Évitez si vous avez des douleurs aiguës au poignet.', 'Tous'),
(13, 'Écartement des doigts', '1. Tendez une main devant vous ?. 2. Écartez vos doigts autant que possible, puis rapprochez-les ?. 3. Répétez 10 fois ?.', 'Ne forcez pas. Déconseillé en cas de douleurs articulaires aux doigts.', 'Tous'),
(14, 'Étirement du dos', '1. Allongez-vous sur le dos, les genoux pliés et les pieds à plat au sol ??. 2. Ramenez vos genoux vers votre poitrine en les tenant avec vos mains ?. 3. Maintenez pendant 20 secondes, puis relâchez ?.', 'Évitez en cas de douleurs aiguës au dos.', 'Tous'),
(15, 'Flexion de la paume', '1. Tendez une main devant vous avec la paume vers le haut ?. 2. Avec l\'autre main, tirez doucement les doigts vers l\'arrière ??. 3. Maintenez pendant 15 secondes, puis changez de main ?.', 'Ne forcez pas. Déconseillé en cas de blessures à la main.', 'Tous'),
(16, 'Auto-massage du cuir chevelu', '1. Asseyez-vous confortablement ?. 2. Utilisez vos doigts pour masser doucement votre cuir chevelu en mouvements circulaires ?. 3. Faites cela pendant 2 minutes ?.', 'Évitez de presser trop fort. Convient à tous.', 'Tous'),
(17, 'Détente du front', '1. Asseyez-vous confortablement ?. 2. Utilisez vos doigts pour masser doucement votre front en mouvements circulaires ?. 3. Faites cela pendant 1 minute ?.', 'Convient à tous.', 'Tous'),
(18, 'Étirement du cou', '1. Tenez-vous droit et inclinez lentement la tête vers l\'arrière pour regarder le plafond ?. 2. Maintenez pendant 10 secondes, puis revenez à la position de départ ?.', 'Ne pas forcer l\'étirement. Déconseillé en cas de douleurs cervicales.', 'Tous'),
(19, 'Étirement de la nuque', '1. Tenez-vous droit et inclinez lentement la tête sur le côté, en rapprochant l\'oreille de l\'épaule ?. 2. Maintenez pendant 15 secondes, puis changez de côté ?.', 'Ne forcez pas. Déconseillé en cas de douleurs cervicales.', 'Tous'),
(20, 'Auto-massage des tempes', '1. Asseyez-vous confortablement ?. 2. Utilisez vos doigts pour masser doucement vos tempes en mouvements circulaires ?. 3. Faites cela pendant 1 minute ?.', 'Évitez de presser trop fort. Convient à tous.', 'Tous'),
(21, 'Étirement des lèvres', '1. Asseyez-vous et souriez aussi largement que possible ?. 2. Maintenez pendant 10 secondes, puis relâchez ?. 3. Répétez 5 fois ?.', 'Convient à tous.', 'Tous'),
(22, 'Gonfler les joues', '1. Asseyez-vous et gonflez vos joues avec de l\'air ?. 2. Maintenez pendant 10 secondes, puis relâchez. 3. Répétez 5 fois ?.', 'Convient à tous.', 'Tous'),
(23, 'Étirement de la mâchoire', '1. Ouvrez la bouche aussi largement que possible sans ressentir de douleur ?. 2. Maintenez pendant 10 secondes, puis relâchez ?. 3. Répétez 5 fois ?.', 'Ne forcez pas. Déconseillé en cas de problèmes de TMJ.', 'Tous'),
(24, 'Respiration profonde', '1. Asseyez-vous confortablement et inspirez profondément par le nez ?. 2. Expirez lentement par la bouche ??. 3. Répétez pendant 1 minute ?.', 'Convient à tous.', 'Tous'),
(25, 'Massage des oreilles', '1. Asseyez-vous confortablement ?. 2. Utilisez vos doigts pour masser doucement le lobe de vos oreilles en mouvements circulaires ?. 3. Faites cela pendant 1 minute ?.', 'Évitez de presser trop fort. Convient à tous.', 'Tous'),
(26, 'Respiration abdominale', '1. Asseyez-vous ou allongez-vous confortablement ??. 2. Placez une main sur votre abdomen et respirez profondément en gonflant votre ventre ??. 3. Expirez lentement en contractant les muscles abdominaux. 4. Répétez pendant 1 minute ?.', 'Convient à tous.', 'Tous'),
(27, 'Bascules pelviennes', '1. Allongez-vous sur le dos, les genoux pliés et les pieds à plat au sol ??. 2. Serrez les muscles abdominaux pour aplatir le bas de votre dos contre le sol ?. 3. Maintenez pendant 5 secondes, puis relâchez. 4. Répétez 10 fois ?.', 'Convient à tous.', 'Tous'),
(28, 'Étirement du chat', '1. Mettez-vous à quatre pattes, les mains sous les épaules et les genoux sous les hanches ?. 2. Arrondissez le dos vers le plafond comme un chat ?. 3. Maintenez pendant 5 secondes, puis revenez à la position neutre. 4. Répétez 10 fois ?.', 'Ne forcez pas les mouvements. Déconseillé en cas de douleurs dorsales aiguës.', 'Tous'),
(29, 'Ouverture de la poitrine', '1. Tenez-vous droit et placez vos mains derrière votre tête ?. 2. Serrez les omoplates ensemble pour ouvrir la poitrine ?. 3. Maintenez pendant 10 secondes, puis relâchez. 4. Répétez 5 fois ?.', 'Ne forcez pas l\'ouverture. Déconseillé en cas de douleurs aux épaules.', 'Tous');

-- --------------------------------------------------------

--
-- Structure de la table `t_faittravailler`
--

CREATE TABLE `t_faittravailler` (
  `fkPartieCorps` int(11) NOT NULL,
  `fkExercice` int(11) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4;

--
-- Contenu de la table `t_faittravailler`
--

INSERT INTO `t_faittravailler` (`fkPartieCorps`, `fkExercice`) VALUES
(1, 1),
(2, 2),
(3, 3),
(4, 4),
(5, 5),
(6, 6),
(7, 7),
(8, 8),
(9, 9),
(10, 10),
(11, 11),
(12, 12),
(13, 13),
(14, 14),
(15, 15),
(16, 16),
(17, 17),
(18, 18),
(19, 19),
(20, 20),
(21, 21),
(22, 22),
(23, 23),
(24, 24),
(25, 25),
(26, 26),
(27, 27),
(28, 28),
(29, 29);

-- --------------------------------------------------------

--
-- Structure de la table `t_lienweb`
--

CREATE TABLE `t_lienweb` (
  `idLienWeb` varchar(255) NOT NULL,
  `lieType` enum('video','article','definition') NOT NULL,
  `lieDescription` varchar(255) DEFAULT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4;

-- --------------------------------------------------------

--
-- Structure de la table `t_partiecorps`
--

CREATE TABLE `t_partiecorps` (
  `idpartieCorps` int(11) NOT NULL,
  `parSexe` enum('Masculin','Feminin','tous') DEFAULT NULL,
  `parNom` varchar(25) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4;

--
-- Contenu de la table `t_partiecorps`
--

INSERT INTO `t_partiecorps` (`idpartieCorps`, `parSexe`, `parNom`) VALUES
(1, 'tous', 'Cheville'),
(2, 'tous', 'Cuisses'),
(3, 'tous', 'Genoux'),
(4, 'tous', 'Jambes'),
(5, 'tous', 'Mollet'),
(6, 'tous', 'Orteils'),
(7, 'tous', 'Plante'),
(8, 'tous', 'Talon'),
(9, 'tous', 'Avant-bras'),
(10, 'tous', 'Coude'),
(11, 'tous', 'Épaules'),
(12, 'tous', 'Poignet'),
(13, 'tous', 'Doigts'),
(14, 'tous', 'Dos'),
(15, 'tous', 'Paume'),
(16, 'tous', 'Crâne'),
(17, 'tous', 'Front'),
(18, 'tous', 'Gorge'),
(19, 'tous', 'Nuque'),
(20, 'tous', 'Tempes'),
(21, 'tous', 'Bouche'),
(22, 'tous', 'Joues'),
(23, 'tous', 'Mâchoires'),
(24, 'tous', 'Nez'),
(25, 'tous', 'Oreilles'),
(26, 'tous', 'Abdomen'),
(27, 'tous', 'Bassin'),
(28, 'tous', 'Colonne'),
(29, 'tous', 'Poitrine');

-- --------------------------------------------------------

--
-- Structure de la table `t_remede`
--

CREATE TABLE `t_remede` (
  `idRemede` int(11) NOT NULL,
  `remNom` varchar(150) NOT NULL,
  `remExplicationSimple` varchar(2000) NOT NULL,
  `remExplicationDetaillle` varchar(3000) DEFAULT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4;

-- --------------------------------------------------------

--
-- Structure de la table `t_soigne`
--

CREATE TABLE `t_soigne` (
  `fkPartieCorps` int(11) NOT NULL,
  `fkRemede` int(11) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4;

--
-- Index pour les tables exportées
--

--
-- Index pour la table `t_decritexercice`
--
ALTER TABLE `t_decritexercice`
  ADD PRIMARY KEY (`fkExercice`,`fkLienWeb`),
  ADD KEY `fkLienWeb` (`fkLienWeb`);

--
-- Index pour la table `t_decritremede`
--
ALTER TABLE `t_decritremede`
  ADD PRIMARY KEY (`fkRemede`,`fkLienWeb`),
  ADD KEY `fkLienWeb` (`fkLienWeb`);

--
-- Index pour la table `t_exercice`
--
ALTER TABLE `t_exercice`
  ADD PRIMARY KEY (`idExercice`);

--
-- Index pour la table `t_faittravailler`
--
ALTER TABLE `t_faittravailler`
  ADD PRIMARY KEY (`fkPartieCorps`,`fkExercice`),
  ADD KEY `fkExercice` (`fkExercice`);

--
-- Index pour la table `t_lienweb`
--
ALTER TABLE `t_lienweb`
  ADD PRIMARY KEY (`idLienWeb`);

--
-- Index pour la table `t_partiecorps`
--
ALTER TABLE `t_partiecorps`
  ADD PRIMARY KEY (`idpartieCorps`);

--
-- Index pour la table `t_remede`
--
ALTER TABLE `t_remede`
  ADD PRIMARY KEY (`idRemede`);

--
-- Index pour la table `t_soigne`
--
ALTER TABLE `t_soigne`
  ADD PRIMARY KEY (`fkPartieCorps`,`fkRemede`),
  ADD KEY `fkRemede` (`fkRemede`);

--
-- AUTO_INCREMENT pour les tables exportées
--

--
-- AUTO_INCREMENT pour la table `t_exercice`
--
ALTER TABLE `t_exercice`
  MODIFY `idExercice` int(11) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=30;
--
-- AUTO_INCREMENT pour la table `t_partiecorps`
--
ALTER TABLE `t_partiecorps`
  MODIFY `idpartieCorps` int(11) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=30;
--
-- AUTO_INCREMENT pour la table `t_remede`
--
ALTER TABLE `t_remede`
  MODIFY `idRemede` int(11) NOT NULL AUTO_INCREMENT;
--
-- Contraintes pour les tables exportées
--

--
-- Contraintes pour la table `t_decritexercice`
--
ALTER TABLE `t_decritexercice`
  ADD CONSTRAINT `t_decritexercice_ibfk_1` FOREIGN KEY (`fkExercice`) REFERENCES `t_exercice` (`idExercice`),
  ADD CONSTRAINT `t_decritexercice_ibfk_2` FOREIGN KEY (`fkLienWeb`) REFERENCES `t_lienweb` (`idLienWeb`);

--
-- Contraintes pour la table `t_decritremede`
--
ALTER TABLE `t_decritremede`
  ADD CONSTRAINT `t_decritremede_ibfk_1` FOREIGN KEY (`fkRemede`) REFERENCES `t_remede` (`idRemede`),
  ADD CONSTRAINT `t_decritremede_ibfk_2` FOREIGN KEY (`fkLienWeb`) REFERENCES `t_lienweb` (`idLienWeb`);

--
-- Contraintes pour la table `t_faittravailler`
--
ALTER TABLE `t_faittravailler`
  ADD CONSTRAINT `t_faittravailler_ibfk_1` FOREIGN KEY (`fkPartieCorps`) REFERENCES `t_partiecorps` (`idpartieCorps`),
  ADD CONSTRAINT `t_faittravailler_ibfk_2` FOREIGN KEY (`fkExercice`) REFERENCES `t_exercice` (`idExercice`);

--
-- Contraintes pour la table `t_soigne`
--
ALTER TABLE `t_soigne`
  ADD CONSTRAINT `t_soigne_ibfk_1` FOREIGN KEY (`fkPartieCorps`) REFERENCES `t_partiecorps` (`idpartieCorps`),
  ADD CONSTRAINT `t_soigne_ibfk_2` FOREIGN KEY (`fkRemede`) REFERENCES `t_remede` (`idRemede`);

/*!40101 SET CHARACTER_SET_CLIENT=@OLD_CHARACTER_SET_CLIENT */;
/*!40101 SET CHARACTER_SET_RESULTS=@OLD_CHARACTER_SET_RESULTS */;
/*!40101 SET COLLATION_CONNECTION=@OLD_COLLATION_CONNECTION */;
