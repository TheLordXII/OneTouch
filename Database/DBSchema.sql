CREATE TABLE `Benutzer` (
  `id` int PRIMARY KEY AUTO_INCREMENT,
  `LastName` varchar(255),
  `FirstName` varchar(255),
  `Username` varchar(255),
  `password` varchar(255),
  `GebDatum` date,
  `is_Admin` boolean,
  `DrinksTaken` int,
  `friends` int
);

CREATE TABLE `Drinks` (
  `id` int PRIMARY KEY AUTO_INCREMENT,
  `DrinkName` varchar(255),
  `Description` varchar(255),
  `Ingredients` int,
  `TimesTaken` int,
  `creator` int
);

CREATE TABLE `DToI` (
  `DID` int,
  `IID` int,
  PRIMARY KEY (`DID`, `IID`)
);

CREATE TABLE `Ingredients` (
  `id` int PRIMARY KEY AUTO_INCREMENT,
  `Name` varchar(255),
  `PumpNr` int
);

CREATE TABLE `Friends` (
  `friend1` int,
  `friend2` int,
  PRIMARY KEY (`friend1`, `friend2`)
);

ALTER TABLE `Friends` ADD FOREIGN KEY (`friend1`) REFERENCES `Benutzer` (`friends`);

ALTER TABLE `Friends` ADD FOREIGN KEY (`friend2`) REFERENCES `Benutzer` (`friends`);

ALTER TABLE `DToI` ADD FOREIGN KEY (`DID`) REFERENCES `Drinks` (`Ingredients`);

ALTER TABLE `Drinks` ADD FOREIGN KEY (`creator`) REFERENCES `Benutzer` (`id`);

ALTER TABLE `DToI` ADD FOREIGN KEY (`IID`) REFERENCES `Ingredients` (`id`);
