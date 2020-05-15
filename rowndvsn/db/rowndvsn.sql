-- phpMyAdmin SQL Dump
-- version 4.5.1
-- http://www.phpmyadmin.net
--
-- Host: 127.0.0.1
-- Generation Time: 30 Jan 2020 pada 13.41
-- Versi Server: 10.1.10-MariaDB
-- PHP Version: 5.6.19

SET SQL_MODE = "NO_AUTO_VALUE_ON_ZERO";
SET time_zone = "+00:00";


/*!40101 SET @OLD_CHARACTER_SET_CLIENT=@@CHARACTER_SET_CLIENT */;
/*!40101 SET @OLD_CHARACTER_SET_RESULTS=@@CHARACTER_SET_RESULTS */;
/*!40101 SET @OLD_COLLATION_CONNECTION=@@COLLATION_CONNECTION */;
/*!40101 SET NAMES utf8mb4 */;

--
-- Database: `rowndvsn`
--

-- --------------------------------------------------------

--
-- Struktur dari tabel `purchase`
--

CREATE TABLE `purchase` (
  `nofak` int(11) NOT NULL,
  `tanggal` date NOT NULL,
  `tottal_item` int(9) NOT NULL,
  `tottal_bayar` int(24) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=latin1;

-- --------------------------------------------------------

--
-- Struktur dari tabel `tbldetilin`
--

CREATE TABLE `tbldetilin` (
  `nofak_in` varchar(20) NOT NULL,
  `id_barang` varchar(30) NOT NULL,
  `ukuran` varchar(10) NOT NULL,
  `jumlah` int(11) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=latin1;

--
-- Dumping data untuk tabel `tbldetilin`
--

INSERT INTO `tbldetilin` (`nofak_in`, `id_barang`, `ukuran`, `jumlah`) VALUES
('BK0001', '1.444.777', 'X', 15),
('BK0002', '1.444.777', 'L', 15),
('BK0003', '222', 'XL', 4),
('BK0004', '444', 'XL', 10),
('BK0005', '444', 'L', 10),
('BK0006', '444', 'L', 20),
('BK0007', '444', 'L', 10),
('BK0008', '444', 'XL', 10),
('BK0009', '444', 'L', 20),
('BK0010', '444', 'L', 100),
('BK0011', '546456', 'xl', 40),
('BK0012', '001', 'L', 10),
('BK0013', '444', 'XL', 10);

-- --------------------------------------------------------

--
-- Struktur dari tabel `tbldetilout`
--

CREATE TABLE `tbldetilout` (
  `nofak_out` varchar(20) NOT NULL,
  `id_barang` varchar(20) NOT NULL,
  `ukuran` varchar(10) NOT NULL,
  `jumlah` int(20) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=latin1;

--
-- Dumping data untuk tabel `tbldetilout`
--

INSERT INTO `tbldetilout` (`nofak_out`, `id_barang`, `ukuran`, `jumlah`) VALUES
('BK0001', '1.444.777', 'X', 4785),
('BK0002', '1.444.777', 'L', 785),
('BK0003', '1.444.777', 'X', 85),
('BK0004', '1.444.777', 'X', 5),
('BK0005', '444', 'XL', 20),
('BK0006', '444', 'L', 20),
('BK0007', '444', 'L', 10),
('BK0008', '444', 'L', 200),
('BK0009', '546456', 'xl', 50),
('BK0010', '001', 'L', 20),
('BK0011', '444', 'XL', 20),
('BK0012', '555', 'XL', 5),
('BK0013', '444', 'XL', 2);

-- --------------------------------------------------------

--
-- Struktur dari tabel `tbl_barang`
--

CREATE TABLE `tbl_barang` (
  `id_barang` varchar(11) NOT NULL,
  `nama_barang` varchar(50) NOT NULL,
  `id_jenis` int(11) NOT NULL,
  `id_tipe` int(11) NOT NULL,
  `sex` varchar(10) NOT NULL,
  `id_warna` int(11) NOT NULL,
  `ukuran` varchar(20) NOT NULL,
  `stok` int(9) NOT NULL,
  `harga_barang` int(11) NOT NULL,
  `tgl_input` date NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=latin1;

--
-- Dumping data untuk tabel `tbl_barang`
--

INSERT INTO `tbl_barang` (`id_barang`, `nama_barang`, `id_jenis`, `id_tipe`, `sex`, `id_warna`, `ukuran`, `stok`, `harga_barang`, `tgl_input`) VALUES
('12.001.221', 'WAIST BAG', 4, 3, 'MALE', 3, 'XL', 2, 150000, '2019-02-10'),
('444', 'ROWNSTAR 1ST', 2, 2, 'MALE', 2, 'XXL', 8, 300000, '2018-08-26'),
('555', 'ROWN GALAXY1', 5, 2, 'MALE', 2, 'XXL', 15, 200000, '2018-09-03');

-- --------------------------------------------------------

--
-- Struktur dari tabel `tbl_in`
--

CREATE TABLE `tbl_in` (
  `nofak_in` varchar(20) NOT NULL,
  `tgl_in` date NOT NULL,
  `tottal_item` int(20) NOT NULL,
  `tottal_bayar` int(20) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=latin1;

--
-- Dumping data untuk tabel `tbl_in`
--

INSERT INTO `tbl_in` (`nofak_in`, `tgl_in`, `tottal_item`, `tottal_bayar`) VALUES
('BK0001', '2018-06-21', 15, 450000),
('BK0002', '2018-06-21', 15, 450000),
('BK0003', '2018-07-01', 4, 400000),
('BK0004', '2018-07-01', 10, 2000000),
('BK0005', '2018-07-01', 10, 2000000),
('BK0006', '2018-07-01', 20, 4000000),
('BK0007', '2018-07-01', 10, 2000000),
('BK0008', '2018-07-01', 10, 2000000),
('BK0009', '2018-07-01', 20, 4000000),
('BK0010', '2018-07-01', 100, 20000000),
('BK0011', '2018-08-08', 40, 8000000),
('BK0012', '2018-08-13', 10, 1000000),
('BK0013', '2018-08-26', 10, 3000000);

-- --------------------------------------------------------

--
-- Struktur dari tabel `tbl_jenis`
--

CREATE TABLE `tbl_jenis` (
  `id_jenis` int(11) NOT NULL,
  `nama_jenis` varchar(50) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=latin1;

--
-- Dumping data untuk tabel `tbl_jenis`
--

INSERT INTO `tbl_jenis` (`id_jenis`, `nama_jenis`) VALUES
(1, 'tsrhit'),
(2, 'TANK-TOP'),
(3, 'BLOUSE'),
(4, 'oblong'),
(5, 'TIE');

-- --------------------------------------------------------

--
-- Struktur dari tabel `tbl_out`
--

CREATE TABLE `tbl_out` (
  `nofak_out` varchar(20) NOT NULL,
  `tgl_out` date NOT NULL,
  `tottal_item` int(20) NOT NULL,
  `tottal_bayar` int(20) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=latin1;

--
-- Dumping data untuk tabel `tbl_out`
--

INSERT INTO `tbl_out` (`nofak_out`, `tgl_out`, `tottal_item`, `tottal_bayar`) VALUES
('BK0001', '2018-06-21', 4785, 143550000),
('BK0002', '2018-06-21', 785, 23550000),
('BK0003', '2018-06-21', 85, 2550000),
('BK0004', '2018-06-21', 5, 150000),
('BK0005', '2018-07-01', 20, 4000000),
('BK0006', '2018-07-01', 20, 4000000),
('BK0007', '2018-07-01', 10, 2000000),
('BK0008', '2018-07-01', 200, 40000000),
('BK0009', '2018-08-08', 50, 10000000),
('BK0010', '2018-08-13', 20, 2000000),
('BK0011', '2018-08-26', 20, 6000000),
('BK0012', '2018-09-03', 5, 1000000),
('BK0013', '2020-01-30', 2, 600000);

-- --------------------------------------------------------

--
-- Struktur dari tabel `tbl_tipe`
--

CREATE TABLE `tbl_tipe` (
  `id_tipe` int(11) NOT NULL,
  `tipe` varchar(50) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=latin1;

--
-- Dumping data untuk tabel `tbl_tipe`
--

INSERT INTO `tbl_tipe` (`id_tipe`, `tipe`) VALUES
(1, 'oblonk'),
(2, 'COTTON'),
(3, 'GRAN'),
(4, 'cardigan');

-- --------------------------------------------------------

--
-- Struktur dari tabel `tbl_user`
--

CREATE TABLE `tbl_user` (
  `id_user` int(11) NOT NULL,
  `nama_user` varchar(50) NOT NULL,
  `username` varchar(50) NOT NULL,
  `password` varchar(50) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=latin1;

--
-- Dumping data untuk tabel `tbl_user`
--

INSERT INTO `tbl_user` (`id_user`, `nama_user`, `username`, `password`) VALUES
(2, 'ADIT', 'adit', 'adit'),
(1234, 'DWI PRIHTAPAMBUDI', 'prihta', 'prihta123');

-- --------------------------------------------------------

--
-- Struktur dari tabel `tbl_warna`
--

CREATE TABLE `tbl_warna` (
  `id_warna` int(11) NOT NULL,
  `warna` varchar(20) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=latin1;

--
-- Dumping data untuk tabel `tbl_warna`
--

INSERT INTO `tbl_warna` (`id_warna`, `warna`) VALUES
(1, 'biru'),
(2, 'HITAM'),
(3, 'MAROON');

-- --------------------------------------------------------

--
-- Stand-in structure for view `v_barang`
--
CREATE TABLE `v_barang` (
`id_barang` varchar(11)
,`nama_barang` varchar(50)
,`nama_jenis` varchar(50)
,`tipe` varchar(50)
,`sex` varchar(10)
,`warna` varchar(20)
,`ukuran` varchar(20)
,`stok` int(9)
,`harga_barang` int(11)
,`tgl_input` date
);

-- --------------------------------------------------------

--
-- Stand-in structure for view `v_in`
--
CREATE TABLE `v_in` (
`nofak_in` varchar(20)
,`nama_barang` varchar(50)
,`sex` varchar(10)
,`warna` varchar(20)
,`ukuran` varchar(10)
,`stok` int(9)
,`tgl_in` date
,`tottal_item` int(20)
,`tottal_bayar` int(20)
);

-- --------------------------------------------------------

--
-- Stand-in structure for view `v_out`
--
CREATE TABLE `v_out` (
`nofak_out` varchar(20)
,`nama_barang` varchar(50)
,`sex` varchar(10)
,`warna` varchar(20)
,`ukuran` varchar(10)
,`stok` int(9)
,`tgl_out` date
,`tottal_item` int(20)
,`tottal_bayar` int(20)
);

-- --------------------------------------------------------

--
-- Struktur untuk view `v_barang`
--
DROP TABLE IF EXISTS `v_barang`;

CREATE ALGORITHM=UNDEFINED DEFINER=`root`@`localhost` SQL SECURITY DEFINER VIEW `v_barang`  AS  select `a`.`id_barang` AS `id_barang`,`a`.`nama_barang` AS `nama_barang`,`b`.`nama_jenis` AS `nama_jenis`,`c`.`tipe` AS `tipe`,`a`.`sex` AS `sex`,`d`.`warna` AS `warna`,`a`.`ukuran` AS `ukuran`,`a`.`stok` AS `stok`,`a`.`harga_barang` AS `harga_barang`,`a`.`tgl_input` AS `tgl_input` from (((`tbl_barang` `a` join `tbl_jenis` `b`) join `tbl_tipe` `c`) join `tbl_warna` `d`) where ((`a`.`id_jenis` = `b`.`id_jenis`) and (`a`.`id_tipe` = `c`.`id_tipe`) and (`a`.`id_warna` = `d`.`id_warna`)) ;

-- --------------------------------------------------------

--
-- Struktur untuk view `v_in`
--
DROP TABLE IF EXISTS `v_in`;

CREATE ALGORITHM=UNDEFINED DEFINER=`root`@`localhost` SQL SECURITY DEFINER VIEW `v_in`  AS  select `a`.`nofak_in` AS `nofak_in`,`b`.`nama_barang` AS `nama_barang`,`b`.`sex` AS `sex`,`b`.`warna` AS `warna`,`c`.`ukuran` AS `ukuran`,`b`.`stok` AS `stok`,`a`.`tgl_in` AS `tgl_in`,`a`.`tottal_item` AS `tottal_item`,`a`.`tottal_bayar` AS `tottal_bayar` from ((`tbl_in` `a` join `v_barang` `b`) join `tbldetilin` `c`) where ((`c`.`id_barang` = `b`.`id_barang`) and (`a`.`nofak_in` = `c`.`nofak_in`)) ;

-- --------------------------------------------------------

--
-- Struktur untuk view `v_out`
--
DROP TABLE IF EXISTS `v_out`;

CREATE ALGORITHM=UNDEFINED DEFINER=`root`@`localhost` SQL SECURITY DEFINER VIEW `v_out`  AS  select `a`.`nofak_out` AS `nofak_out`,`b`.`nama_barang` AS `nama_barang`,`b`.`sex` AS `sex`,`b`.`warna` AS `warna`,`c`.`ukuran` AS `ukuran`,`b`.`stok` AS `stok`,`a`.`tgl_out` AS `tgl_out`,`a`.`tottal_item` AS `tottal_item`,`a`.`tottal_bayar` AS `tottal_bayar` from ((`tbl_out` `a` join `v_barang` `b`) join `tbldetilout` `c`) where ((`c`.`id_barang` = `b`.`id_barang`) and (`a`.`nofak_out` = `c`.`nofak_out`)) ;

--
-- Indexes for dumped tables
--

--
-- Indexes for table `purchase`
--
ALTER TABLE `purchase`
  ADD PRIMARY KEY (`nofak`);

--
-- Indexes for table `tbl_barang`
--
ALTER TABLE `tbl_barang`
  ADD PRIMARY KEY (`id_barang`),
  ADD KEY `id_tipe` (`id_tipe`),
  ADD KEY `id_jenis` (`id_jenis`),
  ADD KEY `id_warna` (`id_warna`);

--
-- Indexes for table `tbl_in`
--
ALTER TABLE `tbl_in`
  ADD PRIMARY KEY (`nofak_in`);

--
-- Indexes for table `tbl_jenis`
--
ALTER TABLE `tbl_jenis`
  ADD PRIMARY KEY (`id_jenis`);

--
-- Indexes for table `tbl_out`
--
ALTER TABLE `tbl_out`
  ADD PRIMARY KEY (`nofak_out`);

--
-- Indexes for table `tbl_tipe`
--
ALTER TABLE `tbl_tipe`
  ADD PRIMARY KEY (`id_tipe`);

--
-- Indexes for table `tbl_user`
--
ALTER TABLE `tbl_user`
  ADD PRIMARY KEY (`id_user`);

--
-- Indexes for table `tbl_warna`
--
ALTER TABLE `tbl_warna`
  ADD PRIMARY KEY (`id_warna`);

--
-- AUTO_INCREMENT for dumped tables
--

--
-- AUTO_INCREMENT for table `purchase`
--
ALTER TABLE `purchase`
  MODIFY `nofak` int(11) NOT NULL AUTO_INCREMENT;
--
-- AUTO_INCREMENT for table `tbl_jenis`
--
ALTER TABLE `tbl_jenis`
  MODIFY `id_jenis` int(11) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=6;
--
-- AUTO_INCREMENT for table `tbl_tipe`
--
ALTER TABLE `tbl_tipe`
  MODIFY `id_tipe` int(11) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=5;
--
-- AUTO_INCREMENT for table `tbl_user`
--
ALTER TABLE `tbl_user`
  MODIFY `id_user` int(11) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=1235;
--
-- AUTO_INCREMENT for table `tbl_warna`
--
ALTER TABLE `tbl_warna`
  MODIFY `id_warna` int(11) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=4;
--
-- Ketidakleluasaan untuk tabel pelimpahan (Dumped Tables)
--

--
-- Ketidakleluasaan untuk tabel `tbl_barang`
--
ALTER TABLE `tbl_barang`
  ADD CONSTRAINT `tbl_barang_ibfk_1` FOREIGN KEY (`id_jenis`) REFERENCES `tbl_jenis` (`id_jenis`) ON DELETE CASCADE ON UPDATE CASCADE,
  ADD CONSTRAINT `tbl_barang_ibfk_3` FOREIGN KEY (`id_tipe`) REFERENCES `tbl_tipe` (`id_tipe`) ON DELETE CASCADE ON UPDATE CASCADE,
  ADD CONSTRAINT `tbl_barang_ibfk_4` FOREIGN KEY (`id_warna`) REFERENCES `tbl_warna` (`id_warna`) ON DELETE CASCADE ON UPDATE CASCADE;

/*!40101 SET CHARACTER_SET_CLIENT=@OLD_CHARACTER_SET_CLIENT */;
/*!40101 SET CHARACTER_SET_RESULTS=@OLD_CHARACTER_SET_RESULTS */;
/*!40101 SET COLLATION_CONNECTION=@OLD_COLLATION_CONNECTION */;
