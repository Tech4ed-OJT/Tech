-- phpMyAdmin SQL Dump
-- version 4.9.0.1
-- https://www.phpmyadmin.net/
--
-- Host: 127.0.0.1
-- Generation Time: Feb 13, 2020 at 01:06 PM
-- Server version: 10.4.6-MariaDB
-- PHP Version: 7.3.8

SET SQL_MODE = "NO_AUTO_VALUE_ON_ZERO";
SET AUTOCOMMIT = 0;
START TRANSACTION;
SET time_zone = "+00:00";


/*!40101 SET @OLD_CHARACTER_SET_CLIENT=@@CHARACTER_SET_CLIENT */;
/*!40101 SET @OLD_CHARACTER_SET_RESULTS=@@CHARACTER_SET_RESULTS */;
/*!40101 SET @OLD_COLLATION_CONNECTION=@@COLLATION_CONNECTION */;
/*!40101 SET NAMES utf8mb4 */;

--
-- Database: `netcafedatabase`
--

-- --------------------------------------------------------

--
-- Table structure for table `accounttable`
--

CREATE TABLE `accounttable` (
  `AcountID` int(11) NOT NULL,
  `UserName1` varchar(75) NOT NULL,
  `Password1` varchar(75) NOT NULL,
  `UserType` varchar(50) NOT NULL,
  `CID` int(11) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=latin1;

--
-- Dumping data for table `accounttable`
--

INSERT INTO `accounttable` (`AcountID`, `UserName1`, `Password1`, `UserType`, `CID`) VALUES
(1, 'ken', 'kenken', 'Client', 0),
(2, 'lore', 'lore', 'Admin', 0),
(9, '123', '123', 'Client', 0),
(25, 'lore', '123', '', 0);

-- --------------------------------------------------------

--
-- Table structure for table `customerlogtable`
--

CREATE TABLE `customerlogtable` (
  `TransactNo` int(11) NOT NULL,
  `AccountID` int(11) NOT NULL,
  `CurrentTime1` timestamp NOT NULL DEFAULT current_timestamp() ON UPDATE current_timestamp(),
  `Status` varchar(5) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=latin1;

--
-- Dumping data for table `customerlogtable`
--

INSERT INTO `customerlogtable` (`TransactNo`, `AccountID`, `CurrentTime1`, `Status`) VALUES
(1, 1, '2020-01-28 00:47:26', 'IN'),
(2, 1, '2020-01-28 00:54:41', 'IN'),
(3, 1, '2020-01-28 00:55:46', 'IN'),
(4, 1, '2020-01-28 00:56:13', 'IN'),
(5, 1, '2020-01-28 00:56:30', 'OUT'),
(6, 1, '2020-01-28 00:56:36', 'IN'),
(7, 1, '2020-01-28 00:56:40', 'OUT'),
(8, 1, '2020-01-28 00:56:47', 'IN'),
(9, 1, '2020-01-28 00:56:50', 'OUT'),
(10, 1, '2020-01-28 00:56:57', 'IN'),
(11, 1, '2020-01-28 01:00:28', 'IN'),
(12, 1, '2020-01-28 01:00:32', 'OUT'),
(13, 1, '2020-01-28 01:01:26', 'IN'),
(14, 1, '2020-01-28 01:02:09', 'IN'),
(15, 1, '2020-01-28 01:02:24', 'OUT'),
(16, 1, '2020-01-28 01:02:37', 'IN'),
(17, 1, '2020-01-28 01:04:30', 'IN'),
(18, 1, '2020-01-28 01:06:29', 'IN'),
(19, 1, '2020-01-28 01:24:11', 'IN'),
(20, 1, '2020-01-28 01:28:03', 'IN'),
(21, 1, '2020-01-28 01:32:50', 'IN'),
(22, 9, '2020-01-28 02:42:18', 'IN'),
(23, 1, '2020-01-28 02:54:07', 'IN'),
(24, 1, '2020-01-28 02:55:09', 'OUT'),
(25, 1, '2020-01-28 02:55:24', 'IN'),
(26, 1, '2020-01-28 02:57:42', 'IN'),
(27, 1, '2020-01-28 04:26:33', 'IN'),
(28, 1, '2020-01-28 04:26:54', 'OUT'),
(29, 1, '2020-01-28 04:27:05', 'IN'),
(30, 1, '2020-01-28 04:27:11', 'OUT'),
(31, 1, '2020-01-28 04:27:20', 'IN'),
(32, 1, '2020-01-28 04:27:51', 'IN'),
(33, 1, '2020-01-28 04:28:52', 'IN'),
(34, 1, '2020-01-28 04:29:19', 'IN'),
(35, 1, '2020-01-28 04:31:44', 'IN'),
(36, 1, '2020-01-28 04:31:54', 'IN'),
(37, 1, '2020-01-28 04:34:35', 'IN'),
(38, 1, '2020-01-28 04:44:20', 'IN'),
(39, 1, '2020-01-28 04:44:33', 'OUT'),
(40, 1, '2020-01-28 04:44:52', 'IN'),
(41, 1, '2020-01-28 04:46:03', 'IN'),
(42, 1, '2020-01-28 04:48:05', 'IN'),
(43, 1, '2020-01-28 04:50:20', 'OUT'),
(44, 1, '2020-01-28 05:29:41', 'IN'),
(45, 1, '2020-01-28 05:33:42', 'IN'),
(46, 1, '2020-01-28 05:34:28', 'IN'),
(47, 1, '2020-01-28 05:34:43', 'IN'),
(48, 1, '2020-01-28 05:38:58', 'IN'),
(49, 1, '2020-01-31 06:26:39', 'IN'),
(50, 1, '2020-01-31 06:28:42', 'IN'),
(51, 1, '2020-01-31 06:39:46', 'IN'),
(52, 1, '2020-01-31 06:41:44', 'IN'),
(53, 1, '2020-01-31 06:43:23', 'IN'),
(54, 1, '2020-01-31 06:45:24', 'IN'),
(55, 1, '2020-01-31 06:45:52', 'IN'),
(56, 1, '2020-01-31 06:51:09', 'IN'),
(57, 1, '2020-02-04 04:42:49', 'IN');

-- --------------------------------------------------------

--
-- Table structure for table `customertable`
--

CREATE TABLE `customertable` (
  `CustomerID` int(11) NOT NULL,
  `LastName` varchar(50) NOT NULL,
  `FirstName` varchar(50) NOT NULL,
  `Gender` varchar(6) NOT NULL,
  `Birthdate` varchar(50) NOT NULL,
  `Province` varchar(50) NOT NULL,
  `City` varchar(50) NOT NULL,
  `Barangay` varchar(100) NOT NULL,
  `EMail` varchar(75) NOT NULL,
  `CelNO` varchar(25) NOT NULL,
  `CustomerType` varchar(50) NOT NULL,
  `PID` int(11) NOT NULL,
  `EID` int(11) NOT NULL,
  `SID` int(11) NOT NULL,
  `TID` int(11) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=latin1;

--
-- Dumping data for table `customertable`
--

INSERT INTO `customertable` (`CustomerID`, `LastName`, `FirstName`, `Gender`, `Birthdate`, `Province`, `City`, `Barangay`, `EMail`, `CelNO`, `CustomerType`, `PID`, `EID`, `SID`, `TID`) VALUES
(6, 'lore', '123', '123', '31/2 /', '13', '313', '3123', '312', '0', '312', 0, 0, 0, 0),
(7, 'kesww', '12312', '3123', '12/3 /', '123', '12', '321', '321', '0', '123123', 0, 0, 0, 0),
(8, 'lsdjfl', 'lkafj', 'lka', '13/1 /', '7', '98', '7', '98', '0', '98', 0, 0, 0, 0),
(9, 'lore', 'lrel', 'oe', '12/3 /', '12312', '123', '123', '098', '0', '098080', 0, 0, 0, 0),
(10, 'Lore', 'Virginia', 'Female', '11/05/1972', 'Cagayan', 'Tuguegarao', 'San Isidro', 'None', '0', 'Indigenous People', 0, 0, 0, 0),
(11, 's', 'q', 'qsqs', ' 1/  /', 'ss', 'q', '1', 'sw', '0', 'd', 0, 0, 0, 0),
(12, 'lkh', 'klhlkj', 'hlkjh', '76/78/6967', 'lkhj978', '898', '79', '79', '0', '9798', 0, 0, 0, 0),
(13, '698', '69', '86', '98/  /', '689', '69', '86', '986', '0', '6', 0, 0, 0, 0),
(14, '809', '8', '098', '09/  /', '8', '09', '8', '098', '0', '09809', 0, 0, 0, 0),
(15, '9879', '7798', '7', '98/7 /', '98', '7', '89', '7', '0', '7', 0, 0, 0, 0),
(16, '7097', '097', '097', '09/  /', '7', '0790', '7', '907', '(097) 999-', '09', 0, 0, 0, 0),
(17, '0809', '8908', '098', '09/  /', '8', '908', '098', '098', '(098)    -', 'Teacher', 0, 0, 0, 0),
(18, '809', '8', '098', '09/8 /', '09', '8', '09', '8', '(09 )    -', 'Teacher', 0, 0, 0, 0),
(19, '09', '09', '-09', '0 /  /', '9-09', '-09', '-0', '9', '(0  )    -', 'Teacher', 0, 0, 0, 0),
(20, '089', '0980', '098', '09/8 /', '098', '089', '080', '0980', '(809)    -', 'Student', 0, 0, 0, 0),
(21, '80980', '98', '098', '09/8 /', '098', '09809', '8098', '098', '(098) 908-9080', 'Entrepreneurs', 0, 0, 0, 0),
(22, '908', '0980', '98', '09/8 /', '908', '098', '09', '8098', '(080)    -', 'PWD', 0, 0, 0, 0),
(23, 'Laviña', 'Ken', 'Male', '11/11/1998', 'Laguna', 'Biñan', 'San Isidro', 'ken@yahoo.com', '(999) 999-9999', 'OFW', 0, 0, 0, 0),
(24, '123', '123', '12', '31/2 /', '3', '123', '12', '31', '(231) 23 -', '123', 0, 0, 0, 0),
(25, 'mama', 'papa', 'Male', '12/02/3344', 'd;lfk', 'okay', '5', '545', '(545) 454-5454', 'OSYA', 0, 0, 0, 0);

-- --------------------------------------------------------

--
-- Table structure for table `disabilitytable`
--

CREATE TABLE `disabilitytable` (
  `disNo` int(11) NOT NULL,
  `DisabilityType` varchar(100) NOT NULL,
  `Reason` varchar(50) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=latin1;

--
-- Dumping data for table `disabilitytable`
--

INSERT INTO `disabilitytable` (`disNo`, `DisabilityType`, `Reason`) VALUES
(1, 'lagbu', 'aywan');

-- --------------------------------------------------------

--
-- Table structure for table `entreptable`
--

CREATE TABLE `entreptable` (
  `BusiNo` int(11) NOT NULL,
  `BusiName` varchar(100) NOT NULL,
  `BusinessType` varchar(100) NOT NULL,
  `BusiOwnership` varchar(75) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=latin1;

--
-- Dumping data for table `entreptable`
--

INSERT INTO `entreptable` (`BusiNo`, `BusiName`, `BusinessType`, `BusiOwnership`) VALUES
(1, '123', '321', '123');

-- --------------------------------------------------------

--
-- Table structure for table `serverlogtable`
--

CREATE TABLE `serverlogtable` (
  `TransactNo` int(11) NOT NULL,
  `TransactionType` varchar(100) NOT NULL,
  `Date` timestamp NOT NULL DEFAULT current_timestamp() ON UPDATE current_timestamp(),
  `Id1` int(11) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=latin1;

-- --------------------------------------------------------

--
-- Table structure for table `tblstudent`
--

CREATE TABLE `tblstudent` (
  `StudentID` int(11) NOT NULL,
  `SchoolName` varchar(150) NOT NULL,
  `SchoolAddress` varchar(150) NOT NULL,
  `EducationalLevel` varchar(50) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=latin1;

--
-- Dumping data for table `tblstudent`
--

INSERT INTO `tblstudent` (`StudentID`, `SchoolName`, `SchoolAddress`, `EducationalLevel`) VALUES
(1, 'sad', 'sad', 'sad');

-- --------------------------------------------------------

--
-- Table structure for table `tblteacher`
--

CREATE TABLE `tblteacher` (
  `TeacherID` int(11) NOT NULL,
  `SchoolName` varchar(150) NOT NULL,
  `SchoolAddress` varchar(150) NOT NULL,
  `Department` varchar(100) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=latin1;

--
-- Dumping data for table `tblteacher`
--

INSERT INTO `tblteacher` (`TeacherID`, `SchoolName`, `SchoolAddress`, `Department`) VALUES
(1, 'ASD', 'ASD', 'ASD');

-- --------------------------------------------------------

--
-- Table structure for table `timetable`
--

CREATE TABLE `timetable` (
  `AccountID` int(11) NOT NULL,
  `H` int(11) NOT NULL,
  `M` int(11) NOT NULL,
  `S` int(11) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=latin1;

--
-- Dumping data for table `timetable`
--

INSERT INTO `timetable` (`AccountID`, `H`, `M`, `S`) VALUES
(1, 1, 0, 0);

-- --------------------------------------------------------

--
-- Table structure for table `transactiontable`
--

CREATE TABLE `transactiontable` (
  `TransactNo` int(11) NOT NULL,
  `TransactionType` varchar(100) NOT NULL,
  `Type` varchar(100) NOT NULL,
  `CurrentTime1` timestamp NOT NULL DEFAULT current_timestamp() ON UPDATE current_timestamp()
) ENGINE=InnoDB DEFAULT CHARSET=latin1;

--
-- Dumping data for table `transactiontable`
--

INSERT INTO `transactiontable` (`TransactNo`, `TransactionType`, `Type`, `CurrentTime1`) VALUES
(1, 'PC ACCESS', 'Research', '2020-02-09 05:35:50'),
(2, 'PRINTING', 'LONG', '2020-02-09 05:35:50'),
(3, 'PRINTING', 'LEGAL', '2020-02-09 05:37:06'),
(4, 'SCANNING', 'LEGAL', '2020-02-11 01:31:06'),
(5, 'SCANNING', 'LEGAL', '2020-02-11 01:31:15'),
(8, 'PC ACCESS', 'Use of MS Word', '2020-02-11 01:31:55'),
(9, 'PC ACCESS', 'Seminar and Training', '2020-02-11 01:32:03'),
(10, 'PRINTING', 'LONG', '2020-02-11 01:32:38'),
(11, 'PRINTING', 'SHORT', '2020-02-11 01:32:46'),
(12, 'PRINTING', 'A4', '2020-02-11 01:32:52'),
(13, 'PRINTING', 'A4', '2020-02-11 01:32:55'),
(14, 'SCANNING', 'A4', '2020-02-11 01:33:19'),
(15, 'SCANNING', 'A4', '2020-02-11 01:33:22'),
(16, 'SCANNING', 'A4', '2020-02-11 01:33:23'),
(17, 'SCANNING', 'LONG', '2020-02-11 01:33:29'),
(18, 'SCANNING', 'SHORT', '2020-02-11 01:33:36'),
(19, 'SCANNING', 'SHORT', '2020-02-11 01:33:38'),
(20, 'PC ACCESS', 'Seminar and Training', '2020-02-11 01:33:51'),
(21, 'PC ACCESS', 'Seminar and Training', '2020-02-11 01:33:53'),
(22, 'PC ACCESS', 'Research', '2020-02-11 01:33:58'),
(23, 'PC ACCESS', 'Use of MS Excel', '2020-02-11 01:34:05'),
(24, 'PC ACCESS', 'Use of MS Excel', '2020-02-11 01:34:07'),
(25, 'PC ACCESS', 'Use of MS PowerPoint', '2020-02-11 01:34:13'),
(26, 'PC ACCESS', 'Use of MS PowerPoint', '2020-02-11 01:34:14'),
(27, 'PC ACCESS', 'Use of MS Word', '2020-02-11 01:34:19');

--
-- Indexes for dumped tables
--

--
-- Indexes for table `accounttable`
--
ALTER TABLE `accounttable`
  ADD PRIMARY KEY (`AcountID`),
  ADD KEY `CID` (`CID`);

--
-- Indexes for table `customerlogtable`
--
ALTER TABLE `customerlogtable`
  ADD PRIMARY KEY (`TransactNo`),
  ADD KEY `AccountID` (`AccountID`);

--
-- Indexes for table `customertable`
--
ALTER TABLE `customertable`
  ADD PRIMARY KEY (`CustomerID`),
  ADD KEY `PID` (`PID`,`EID`),
  ADD KEY `SID` (`SID`,`TID`);

--
-- Indexes for table `disabilitytable`
--
ALTER TABLE `disabilitytable`
  ADD PRIMARY KEY (`disNo`);

--
-- Indexes for table `entreptable`
--
ALTER TABLE `entreptable`
  ADD PRIMARY KEY (`BusiNo`);

--
-- Indexes for table `serverlogtable`
--
ALTER TABLE `serverlogtable`
  ADD PRIMARY KEY (`TransactNo`),
  ADD KEY `Id1` (`Id1`);

--
-- Indexes for table `tblstudent`
--
ALTER TABLE `tblstudent`
  ADD PRIMARY KEY (`StudentID`);

--
-- Indexes for table `tblteacher`
--
ALTER TABLE `tblteacher`
  ADD PRIMARY KEY (`TeacherID`);

--
-- Indexes for table `timetable`
--
ALTER TABLE `timetable`
  ADD UNIQUE KEY `AccountID` (`AccountID`);

--
-- Indexes for table `transactiontable`
--
ALTER TABLE `transactiontable`
  ADD PRIMARY KEY (`TransactNo`);

--
-- AUTO_INCREMENT for dumped tables
--

--
-- AUTO_INCREMENT for table `accounttable`
--
ALTER TABLE `accounttable`
  MODIFY `AcountID` int(11) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=26;

--
-- AUTO_INCREMENT for table `customerlogtable`
--
ALTER TABLE `customerlogtable`
  MODIFY `TransactNo` int(11) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=58;

--
-- AUTO_INCREMENT for table `customertable`
--
ALTER TABLE `customertable`
  MODIFY `CustomerID` int(11) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=26;

--
-- AUTO_INCREMENT for table `disabilitytable`
--
ALTER TABLE `disabilitytable`
  MODIFY `disNo` int(11) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=2;

--
-- AUTO_INCREMENT for table `entreptable`
--
ALTER TABLE `entreptable`
  MODIFY `BusiNo` int(11) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=2;

--
-- AUTO_INCREMENT for table `serverlogtable`
--
ALTER TABLE `serverlogtable`
  MODIFY `TransactNo` int(11) NOT NULL AUTO_INCREMENT;

--
-- AUTO_INCREMENT for table `tblstudent`
--
ALTER TABLE `tblstudent`
  MODIFY `StudentID` int(11) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=2;

--
-- AUTO_INCREMENT for table `tblteacher`
--
ALTER TABLE `tblteacher`
  MODIFY `TeacherID` int(11) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=2;

--
-- AUTO_INCREMENT for table `transactiontable`
--
ALTER TABLE `transactiontable`
  MODIFY `TransactNo` int(11) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=28;
COMMIT;

/*!40101 SET CHARACTER_SET_CLIENT=@OLD_CHARACTER_SET_CLIENT */;
/*!40101 SET CHARACTER_SET_RESULTS=@OLD_CHARACTER_SET_RESULTS */;
/*!40101 SET COLLATION_CONNECTION=@OLD_COLLATION_CONNECTION */;
