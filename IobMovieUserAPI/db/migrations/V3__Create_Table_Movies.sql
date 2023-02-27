CREATE TABLE `movies` (
  `id` INT(10) AUTO_INCREMENT PRIMARY KEY,
  `director` longtext,
  `release_date` datetime(6) NOT NULL,
  `year` year NOT NULL,
  `title` longtext
) ENGINE=InnoDB DEFAULT CHARSET=latin1;
