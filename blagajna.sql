-- phpMyAdmin SQL Dump
-- version 4.5.1
-- http://www.phpmyadmin.net
--
-- Gostitelj: 127.0.0.1
-- Čas nastanka: 28. apr 2016 ob 12.43
-- Različica strežnika: 10.1.9-MariaDB
-- Različica PHP: 7.0.0

SET SQL_MODE = "NO_AUTO_VALUE_ON_ZERO";
SET time_zone = "+00:00";


/*!40101 SET @OLD_CHARACTER_SET_CLIENT=@@CHARACTER_SET_CLIENT */;
/*!40101 SET @OLD_CHARACTER_SET_RESULTS=@@CHARACTER_SET_RESULTS */;
/*!40101 SET @OLD_COLLATION_CONNECTION=@@COLLATION_CONNECTION */;
/*!40101 SET NAMES utf8mb4 */;

--
-- Zbirka podatkov: `blagajna`
--

DELIMITER $$
--
-- Procedure
--
CREATE DEFINER=`root`@`localhost` PROCEDURE `dodajizdelek` (IN `idracuna` INT, `idizdelka` INT)  BEGIN

  insert into postavke (izdelek, kol, racun) values (idizdelka, 1, idracuna);

  select i.ime, i.cena, i.cena * (1 + i.ddv / 100) from postavke p inner join izdelki i on p.izdelek = i.id where p.racun = idracuna;

END$$

CREATE DEFINER=`root`@`localhost` PROCEDURE `novracun` ()  begin
  insert into racuni (zaplacilo) values (0);
  
  update racuni set stevilka = lpad (convert (LAST_INSERT_ID(), char(50)), 6, '0') where id = LAST_INSERT_ID();
  
  select id, stevilka from racuni where id = LAST_INSERT_ID();
END$$

DELIMITER ;

-- --------------------------------------------------------

--
-- Struktura tabele `izdelki`
--

CREATE TABLE `izdelki` (
  `id` int(11) NOT NULL,
  `sifra` varchar(50) COLLATE utf8_slovenian_ci NOT NULL,
  `ime` varchar(250) COLLATE utf8_slovenian_ci NOT NULL,
  `cena` decimal(10,2) NOT NULL,
  `ddv` decimal(10,2) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8 COLLATE=utf8_slovenian_ci;

--
-- Odloži podatke za tabelo `izdelki`
--

INSERT INTO `izdelki` (`id`, `sifra`, `ime`, `cena`, `ddv`) VALUES
(1, '562145', 'mleko 3,5', '2.50', '9.50'),
(2, '246778', 'mleko 0,9', '2.90', '9.50'),
(3, '35618', 'kruh', '2.80', '9.50'),
(4, '63247', 'slusalke', '35.00', '22.00'),
(5, '93248', 'mikrofon', '50.00', '22.00');

-- --------------------------------------------------------

--
-- Struktura tabele `postavke`
--

CREATE TABLE `postavke` (
  `id` int(11) NOT NULL,
  `racun` int(11) NOT NULL,
  `izdelek` int(11) NOT NULL,
  `kol` decimal(10,0) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8 COLLATE=utf8_slovenian_ci;

--
-- Odloži podatke za tabelo `postavke`
--

INSERT INTO `postavke` (`id`, `racun`, `izdelek`, `kol`) VALUES
(1, 6, 1, '1'),
(2, 9, 5, '1'),
(3, 9, 2, '1'),
(4, 10, 5, '1'),
(5, 10, 1, '1'),
(6, 10, 4, '1'),
(10, 14, 3, '1'),
(11, 14, 1, '1'),
(12, 15, 1, '1'),
(13, 15, 5, '1');

--
-- Sprožilci `postavke`
--
DELIMITER $$
CREATE TRIGGER `zaplacilo` AFTER INSERT ON `postavke` FOR EACH ROW BEGIN

update racuni set zaplacilo =
  (select SUM(i.cena * (1 + i.ddv / 100)) from postavke p inner join izdelki i on p.izdelek = i.id
   where p.racun = NEW.racun)
where id = NEW.racun;

END
$$
DELIMITER ;

-- --------------------------------------------------------

--
-- Struktura tabele `racuni`
--

CREATE TABLE `racuni` (
  `id` int(11) NOT NULL,
  `stevilka` varchar(50) COLLATE utf8_slovenian_ci NOT NULL,
  `zaplacilo` decimal(10,2) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8 COLLATE=utf8_slovenian_ci;

--
-- Odloži podatke za tabelo `racuni`
--

INSERT INTO `racuni` (`id`, `stevilka`, `zaplacilo`) VALUES
(5, '000005', '0.00'),
(6, '000006', '0.00'),
(7, '000007', '0.00'),
(8, '000008', '0.00'),
(9, '000009', '0.00'),
(10, '000010', '0.00'),
(11, '000011', '0.00'),
(12, '000012', '0.00'),
(13, '000013', '0.00'),
(14, '000014', '5.80'),
(15, '000015', '63.74');

--
-- Indeksi zavrženih tabel
--

--
-- Indeksi tabele `izdelki`
--
ALTER TABLE `izdelki`
  ADD PRIMARY KEY (`id`);

--
-- Indeksi tabele `postavke`
--
ALTER TABLE `postavke`
  ADD PRIMARY KEY (`id`);

--
-- Indeksi tabele `racuni`
--
ALTER TABLE `racuni`
  ADD PRIMARY KEY (`id`);

--
-- AUTO_INCREMENT zavrženih tabel
--

--
-- AUTO_INCREMENT tabele `postavke`
--
ALTER TABLE `postavke`
  MODIFY `id` int(11) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=14;
--
-- AUTO_INCREMENT tabele `racuni`
--
ALTER TABLE `racuni`
  MODIFY `id` int(11) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=16;
/*!40101 SET CHARACTER_SET_CLIENT=@OLD_CHARACTER_SET_CLIENT */;
/*!40101 SET CHARACTER_SET_RESULTS=@OLD_CHARACTER_SET_RESULTS */;
/*!40101 SET COLLATION_CONNECTION=@OLD_COLLATION_CONNECTION */;
