-- phpMyAdmin SQL Dump
-- version 4.5.4.1
-- http://www.phpmyadmin.net
--
-- Client :  localhost
-- Généré le :  Mar 25 Juin 2024 à 06:56
-- Version du serveur :  5.7.11
-- Version de PHP :  5.6.18

SET SQL_MODE = "NO_AUTO_VALUE_ON_ZERO";
SET time_zone = "+00:00";


/*!40101 SET @OLD_CHARACTER_SET_CLIENT=@@CHARACTER_SET_CLIENT */;
/*!40101 SET @OLD_CHARACTER_SET_RESULTS=@@CHARACTER_SET_RESULTS */;
/*!40101 SET @OLD_COLLATION_CONNECTION=@@COLLATION_CONNECTION */;
/*!40101 SET NAMES utf8mb4 */;

--
-- Base de données :  `moveit`
--
CREATE DATABASE IF NOT EXISTS `moveit` DEFAULT CHARACTER SET utf8 COLLATE utf8_general_ci;
USE `moveit`;

-- --------------------------------------------------------

--
-- Structure de la table `t_user`
--

CREATE TABLE `t_user` (
  `idUser` int(11) NOT NULL,
  `Mail` varchar(50) NOT NULL,
  `Name` varchar(50) NOT NULL,
  `Password` varchar(256) NOT NULL,
  `BirthDate` date NOT NULL,
  `Height` int(11) NOT NULL,
  `Weight` double NOT NULL,
  `Sex` varchar(50) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=latin1;

--
-- Contenu de la table `t_user`
--

INSERT INTO `t_user` (`idUser`, `Mail`, `Name`, `Password`, `BirthDate`, `Height`, `Weight`, `Sex`) VALUES
(20, 'felix.sierro@gmail.com', 'Félix', 'fccbada696b65b249b2dab0d3664d50123662b8e85635f1a4b6978801729d6916283953477663175028251491753735951871989', '1998-04-07', 192, 80, 'M'),
(22, 'pg43msk@eduvaud.ch', 'Kaeno', '6998541c00d687d72ee862bb4b0d9e51f7970b9143d8ae4d5937dd12c13b58f08376542759493214208037072987905973998664', '2005-02-06', 185, 69, 'M');

-- --------------------------------------------------------

--
-- Structure de la table `t_weight`
--

CREATE TABLE `t_weight` (
  `idWeight` int(11) NOT NULL,
  `Mail` varchar(50) NOT NULL,
  `Weight` double NOT NULL,
  `Date` date NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=latin1;

--
-- Contenu de la table `t_weight`
--

INSERT INTO `t_weight` (`idWeight`, `Mail`, `Weight`, `Date`) VALUES
(1, 'felix.sierro@gmail.com', 80, '2024-06-14'),
(3, 'felix.sierro@gmail.com', 79, '2024-06-23'),
(6, 'pg43msk@eduvaud.ch', 69, '2024-06-24');

--
-- Index pour les tables exportées
--

--
-- Index pour la table `t_user`
--
ALTER TABLE `t_user`
  ADD PRIMARY KEY (`idUser`);

--
-- Index pour la table `t_weight`
--
ALTER TABLE `t_weight`
  ADD PRIMARY KEY (`idWeight`);

--
-- AUTO_INCREMENT pour les tables exportées
--

--
-- AUTO_INCREMENT pour la table `t_user`
--
ALTER TABLE `t_user`
  MODIFY `idUser` int(11) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=27;
--
-- AUTO_INCREMENT pour la table `t_weight`
--
ALTER TABLE `t_weight`
  MODIFY `idWeight` int(11) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=8;
/*!40101 SET CHARACTER_SET_CLIENT=@OLD_CHARACTER_SET_CLIENT */;
/*!40101 SET CHARACTER_SET_RESULTS=@OLD_CHARACTER_SET_RESULTS */;
/*!40101 SET COLLATION_CONNECTION=@OLD_COLLATION_CONNECTION */;
