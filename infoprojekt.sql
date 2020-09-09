-- phpMyAdmin SQL Dump
-- version 5.0.2
-- https://www.phpmyadmin.net/
--
-- Host: 127.0.0.1
-- Erstellungszeit: 26. Jun 2020 um 18:03
-- Server-Version: 10.4.11-MariaDB
-- PHP-Version: 7.4.5

SET SQL_MODE = "NO_AUTO_VALUE_ON_ZERO";
START TRANSACTION;
SET time_zone = "+00:00";


/*!40101 SET @OLD_CHARACTER_SET_CLIENT=@@CHARACTER_SET_CLIENT */;
/*!40101 SET @OLD_CHARACTER_SET_RESULTS=@@CHARACTER_SET_RESULTS */;
/*!40101 SET @OLD_COLLATION_CONNECTION=@@COLLATION_CONNECTION */;
/*!40101 SET NAMES utf8mb4 */;

--
-- Datenbank: `infoprojekt`
--

-- --------------------------------------------------------

--
-- Tabellenstruktur für Tabelle `temperatur`
--

CREATE TABLE `temperatur` (
  `temperaturID` int(11) NOT NULL,
  `temperatur` double NOT NULL,
  `zeitstempel` datetime NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4;

--
-- Daten für Tabelle `temperatur`
--

INSERT INTO `temperatur` (`temperaturID`, `temperatur`, `zeitstempel`) VALUES
(1, 14, '2020-06-19 15:06:11'),
(2, 8, '2020-06-19 15:06:13'),
(3, 8, '2020-06-19 15:06:14'),
(4, 29, '2020-06-19 15:06:15'),
(5, 2, '2020-06-19 15:06:16'),
(6, 14, '2020-06-19 15:06:17'),
(7, 15, '2020-06-19 15:06:18'),
(8, 22, '2020-06-19 15:06:19'),
(9, 6, '2020-06-19 15:06:20'),
(10, 24, '2020-06-19 15:06:21'),
(11, 15, '2020-06-19 15:06:22'),
(12, 3, '2020-06-19 15:06:23'),
(13, 18, '2020-06-19 15:06:24'),
(14, 19, '2020-06-19 15:06:25'),
(15, 19, '2020-06-19 15:06:26'),
(16, 30, '2020-06-19 15:06:27'),
(17, 19, '2020-06-19 15:06:28'),
(18, 15, '2020-06-19 15:06:29'),
(19, 30, '2020-06-19 15:06:30'),
(20, 3, '2020-06-19 15:06:31'),
(21, 23, '2020-06-19 15:06:32'),
(22, 27, '2020-06-19 15:06:33'),
(23, 8, '2020-06-19 15:06:34'),
(24, 18, '2020-06-19 15:06:35'),
(25, 10, '2020-06-19 15:06:36'),
(26, 19, '2020-06-19 15:06:37'),
(27, 14, '2020-06-19 15:06:38'),
(28, 5, '2020-06-19 15:06:39'),
(29, 2, '2020-06-19 15:06:40'),
(30, 10, '2020-06-19 15:06:41'),
(31, 15, '2020-06-19 15:06:42'),
(32, 22, '2020-06-19 15:06:43'),
(33, 11, '2020-06-19 15:06:44'),
(34, 10, '2020-06-19 15:06:45'),
(35, 30, '2020-06-19 15:06:46'),
(36, 30, '2020-06-19 15:06:47'),
(37, 0, '2020-06-19 15:06:48'),
(38, 20, '2020-06-19 15:06:49'),
(39, 26, '2020-06-19 15:06:50'),
(40, 24, '2020-06-19 15:06:51');

--
-- Indizes der exportierten Tabellen
--

--
-- Indizes für die Tabelle `temperatur`
--
ALTER TABLE `temperatur`
  ADD PRIMARY KEY (`temperaturID`);

--
-- AUTO_INCREMENT für exportierte Tabellen
--

--
-- AUTO_INCREMENT für Tabelle `temperatur`
--
ALTER TABLE `temperatur`
  MODIFY `temperaturID` int(11) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=41;
COMMIT;

/*!40101 SET CHARACTER_SET_CLIENT=@OLD_CHARACTER_SET_CLIENT */;
/*!40101 SET CHARACTER_SET_RESULTS=@OLD_CHARACTER_SET_RESULTS */;
/*!40101 SET COLLATION_CONNECTION=@OLD_COLLATION_CONNECTION */;
