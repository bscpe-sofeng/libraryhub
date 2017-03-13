-- phpMyAdmin SQL Dump
-- version 3.3.9
-- http://www.phpmyadmin.net
--
-- Host: localhost
-- Generation Time: Feb 15, 2017 at 05:07 AM
-- Server version: 5.5.8
-- PHP Version: 5.3.5

SET SQL_MODE="NO_AUTO_VALUE_ON_ZERO";


/*!40101 SET @OLD_CHARACTER_SET_CLIENT=@@CHARACTER_SET_CLIENT */;
/*!40101 SET @OLD_CHARACTER_SET_RESULTS=@@CHARACTER_SET_RESULTS */;
/*!40101 SET @OLD_COLLATION_CONNECTION=@@COLLATION_CONNECTION */;
/*!40101 SET NAMES utf8 */;

--
-- Database: `libraryhub`
--

-- --------------------------------------------------------

--
-- Table structure for table `account`
--

CREATE TABLE IF NOT EXISTS `account` (
  `id` int(255) NOT NULL AUTO_INCREMENT,
  `type` varchar(255) NOT NULL,
  `fname` varchar(255) NOT NULL,
  `lname` varchar(255) NOT NULL,
  `user` varchar(255) NOT NULL,
  `pass` varchar(255) NOT NULL,
  PRIMARY KEY (`id`)
) ENGINE=InnoDB  DEFAULT CHARSET=latin1 AUTO_INCREMENT=5 ;

--
-- Dumping data for table `account`
--

INSERT INTO `account` (`id`, `type`, `fname`, `lname`, `user`, `pass`) VALUES
(1, 'Admin', 'johl', 'santos', 'johl', 'santos'),
(4, 'SUBADMIN', 'chedd', 'lupena', 'admin', 'admin');

-- --------------------------------------------------------

--
-- Table structure for table `book`
--

CREATE TABLE IF NOT EXISTS `book` (
  `bookID` int(255) NOT NULL AUTO_INCREMENT,
  `title` varchar(9999) NOT NULL,
  `author` varchar(9999) NOT NULL,
  `category` varchar(9999) NOT NULL,
  `pub` varchar(9999) NOT NULL,
  `stock` int(255) NOT NULL,
  PRIMARY KEY (`bookID`)
) ENGINE=InnoDB  DEFAULT CHARSET=latin1 AUTO_INCREMENT=18 ;

--
-- Dumping data for table `book`
--

INSERT INTO `book` (`bookID`, `title`, `author`, `category`, `pub`, `stock`) VALUES
(1, 'test123', 'test1', 'test2', '', 1),
(3, 'Title123123', 'Author', 'Category', 'Publisher', 0),
(6, 'Title', 'Author', '1', 'Publisher', 0),
(7, 'Title1', 'Author', '1', 'Publisher', 0),
(8, 'Title2', 'Author', '1', 'Publisher', 0),
(9, 'Title3', 'Author', '1', 'Publisher', 0),
(10, 'Title123', 'Author', '2', 'Publisher', 0),
(11, 'Title12313', 'Author', '2', 'Publisher', 0),
(12, 'Title123133', 'Author', '3', 'Publisher', 0),
(13, 'qwe', 'qwe', 'Category', 'Publisher', 0),
(14, 'qweqweqwe', 'weqweqwe', 'Category', 'wewqew', 0),
(15, 'qwe1', 'we', '3', 'we', 0),
(16, '123123', '123123', '3', 'we', 0),
(17, 'qweeqq', '1231q23', '3', 'we', 0);

-- --------------------------------------------------------

--
-- Table structure for table `log`
--

CREATE TABLE IF NOT EXISTS `log` (
  `id` int(11) NOT NULL AUTO_INCREMENT,
  `fname` varchar(255) NOT NULL,
  `lname` varchar(255) NOT NULL,
  `school` varchar(255) NOT NULL,
  `intent` varchar(255) NOT NULL,
  `timein` varchar(255) NOT NULL,
  `timeout` varchar(255) NOT NULL,
  PRIMARY KEY (`id`)
) ENGINE=InnoDB  DEFAULT CHARSET=latin1 AUTO_INCREMENT=30 ;

--
-- Dumping data for table `log`
--

INSERT INTO `log` (`id`, `fname`, `lname`, `school`, `intent`, `timein`, `timeout`) VALUES
(1, 'Name', '', 'School', 'Intent', '0000-00-00 00:00:00', '0000-00-00 00:00:00'),
(2, 'School', '', 'School', 'Intent', '1/26/2017 8:30:07 PM', '11:41:58 PM 26-41-2017'),
(3, 'School', '', 'sti', 'tehsis', '1/26/2017 8:30:17 PM', '1/26/2017 8:57:42 PM'),
(4, 'School', '', 'School', 'Intent', '1/26/2017 8:31:21 PM', '11:42:01 PM 26-42-2017'),
(5, 'Name', '', 'School', 'Intent', '1/26/2017 8:31:29 PM', 'Pending'),
(6, 'Name', '', 'School', 'Intent', '1/26/2017 8:32:05 PM', 'Pending'),
(7, 'School', '', 'School', 'Intent', '1/26/2017 8:32:06 PM', '1/26/2017 8:58:29 PM'),
(8, 'School', '', 'qwe', 'we', '1/26/2017 8:33:47 PM', '1/26/2017 8:58:26 PM'),
(9, 'School', '', 'qwe', 'we', '1/26/2017 8:34:12 PM', '1/26/2017 8:57:37 PM'),
(10, 'School', 'Last Name', 'School', 'Intent', '09:42:PM 2017-42-26', '09:42:51 2017-42-26'),
(11, 'Name', 'Last Name', 'School', 'Intent', '09:42:55 2017-42-26', 'Pending'),
(12, 'Name', 'Last Name', 'School', 'Intent', '09:43:24 PM 2017-43-26', 'Pending'),
(13, 'School', 'Last Name', 'School', 'Intent', '09:44:08 PM 26-44-2017', '10:18:23 PM 26-18-2017'),
(14, 'School', 'Last Name', 'School', 'Intent', '10:14:06 PM 26-14-2017', '10:16:29 PM 26-16-2017'),
(15, 'School', 'Last Name', 'School', 'Intent', '10:20:51 PM 26-20-2017', '12:59:20 AM 03-59-2017'),
(16, 'School', 'Last Name', 'School', 'Intent', '10:24:57 PM 26-24-2017', '12:59:28 AM 03-59-2017'),
(17, 'School', 'Last Name', 'School', 'Intent', '10:27:15 PM 26-27-2017', '10:27:18 PM 26-27-2017'),
(18, 'School', 'Last Name', 'School', 'Intent', '10:27:20 PM 26-27-2017', '10:27:23 PM 26-27-2017'),
(19, 'School', 'Last Name', 'School', 'Intent', '10:27:55 PM 26-27-2017', '11:02:00 PM 26-02-2017'),
(20, 'Name', 'Last Name', 'School', 'Intent', '11:01:57 PM 26-01-2017', 'Pending'),
(21, 'School', 'Last Name', 'School', 'Intent', '11:02:52 PM 26-02-2017', '11:03:54 PM 26-03-2017'),
(22, 'School', 'Last Name', 'School', 'Intent', '11:17:22 PM 26-17-2017', '11:27:09 PM 26-27-2017'),
(23, 'Name', 'Last Name', 'School', 'Intent', '11:22:15 PM 26-22-2017', 'Pending'),
(24, 'School', '', '', '', '11:15:39 PM 02-15-2017', '11:23:29 PM 02-23-2017'),
(25, 'School', 'Last Name', 'School', 'Intent', '11:23:17 PM 02-23-2017', '01:04:07 AM 03-04-2017'),
(26, 'School', 'lomeda', 'sti', 'thesis', '11:23:46 PM 02-23-2017', '12:59:17 AM 03-59-2017'),
(27, 'School', 'Last Name', 'School', 'Intent', '12:59:34 AM 03-59-2017', '01:02:48 AM 03-02-2017'),
(28, 'School', 'Last Name', 'School', 'Intent', '01:02:42 AM 03-02-2017', '01:02:45 AM 03-02-2017'),
(29, 'School', 'Last Name', 'School', 'Intent', '01:03:36 AM 03-03-2017', '01:10:15 AM 03-10-2017');
