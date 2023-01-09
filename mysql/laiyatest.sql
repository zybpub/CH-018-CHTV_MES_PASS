-- phpMyAdmin SQL Dump
-- version 4.6.4
-- https://www.phpmyadmin.net/
--
-- Host: 127.0.0.1
-- Generation Time: 2019-08-07 02:35:22
-- 服务器版本： 5.7.14
-- PHP Version: 5.6.25

SET SQL_MODE = "NO_AUTO_VALUE_ON_ZERO";
SET time_zone = "+00:00";


/*!40101 SET @OLD_CHARACTER_SET_CLIENT=@@CHARACTER_SET_CLIENT */;
/*!40101 SET @OLD_CHARACTER_SET_RESULTS=@@CHARACTER_SET_RESULTS */;
/*!40101 SET @OLD_COLLATION_CONNECTION=@@COLLATION_CONNECTION */;
/*!40101 SET NAMES utf8mb4 */;

--
-- Database: `jczx_mysql_db`
--

-- --------------------------------------------------------

--
-- 表的结构 `laiyatest`
--

CREATE TABLE `laiyatest` (
  `tid` int(8) NOT NULL COMMENT '自增主键',
  `tdatetime` varchar(200) NOT NULL COMMENT '测试时间',
  `sn` varchar(200) DEFAULT NULL COMMENT '产品序列号',
  `vol1` varchar(20) NOT NULL,
  `curr` varchar(20) NOT NULL,
  `time1` varchar(20) NOT NULL,
  `vol2` varchar(20) NOT NULL,
  `res` varchar(20) NOT NULL,
  `time2` varchar(20) NOT NULL,
  `result` varchar(200) DEFAULT NULL COMMENT '测试结果',
  `uploaddatetime` datetime DEFAULT NULL COMMENT '上传服务器时间',
  `memo` varchar(200) DEFAULT NULL COMMENT '备注'
) ENGINE=InnoDB DEFAULT CHARSET=utf8;

--
-- 转存表中的数据 `laiyatest`
--

INSERT INTO `laiyatest` (`tid`, `tdatetime`, `sn`, `vol1`, `curr`, `time1`, `vol2`, `res`, `time2`, `result`, `uploaddatetime`, `memo`) VALUES
(1, '2019-8-6 19:20:01', 'sdfadf', '', '', '', '', '', '', 'PASS', NULL, NULL),
(2, '2019-8-6 19:20:02', 'ghdfgdsfg', '', '', '', '', '', '', 'PASS', NULL, NULL),
(3, '2019-9-6', 'fsdfasdfa', '', '', '', '', '', '', 'Fail', NULL, 'sfda'),
(4, '', '', '', '', '', '', '', '', '', NULL, '');

--
-- Indexes for dumped tables
--

--
-- Indexes for table `laiyatest`
--
ALTER TABLE `laiyatest`
  ADD PRIMARY KEY (`tid`);

--
-- 在导出的表使用AUTO_INCREMENT
--

--
-- 使用表AUTO_INCREMENT `laiyatest`
--
ALTER TABLE `laiyatest`
  MODIFY `tid` int(8) NOT NULL AUTO_INCREMENT COMMENT '自增主键', AUTO_INCREMENT=5;
/*!40101 SET CHARACTER_SET_CLIENT=@OLD_CHARACTER_SET_CLIENT */;
/*!40101 SET CHARACTER_SET_RESULTS=@OLD_CHARACTER_SET_RESULTS */;
/*!40101 SET COLLATION_CONNECTION=@OLD_COLLATION_CONNECTION */;
