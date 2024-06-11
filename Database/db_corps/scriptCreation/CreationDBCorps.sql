-- Supprimer la base de données existante et créer une nouvelle
DROP DATABASE IF EXISTS db_pcorps;
CREATE DATABASE db_pcorps CHARACTER SET utf8 COLLATE utf8_general_ci;
USE db_pcorps;

-- Créer les tables
CREATE TABLE t_partieCorps (
    idpartieCorps INT AUTO_INCREMENT,
    parSexe ENUM('Masculin', 'Feminin', 'tous'),
    parNom VARCHAR(25) NOT NULL,
    PRIMARY KEY(idpartieCorps)
);

CREATE TABLE t_exercice (
    idExercice INT AUTO_INCREMENT,
    exeNom VARCHAR(50),
    exeExplication VARCHAR(2000) NOT NULL,
    PRIMARY KEY(idExercice)
);

CREATE TABLE t_remede (
    idRemede INT AUTO_INCREMENT,
    remNom VARCHAR(150) NOT NULL,
    remExplicationSimple VARCHAR(2000) NOT NULL,
    remExplicationDetaillee VARCHAR(3000),
    PRIMARY KEY(idRemede)
);

CREATE TABLE t_lienWeb (
    idLienWeb VARCHAR(255),
    lieType ENUM ('video', 'article', 'definition') NOT NULL,
    lieDescription VARCHAR(255),
    PRIMARY KEY(idLienWeb)
);

CREATE TABLE t_soigne (
    fkPartieCorps INT,
    fkRemede INT,
    PRIMARY KEY(fkPartieCorps, fkRemede),
    FOREIGN KEY(fkPartieCorps) REFERENCES t_partieCorps(idpartieCorps),
    FOREIGN KEY(fkRemede) REFERENCES t_remede(idRemede)
);

CREATE TABLE t_faitTravailler (
    fkPartieCorps INT,
    fkExercice INT,
    PRIMARY KEY(fkPartieCorps, fkExercice),
    FOREIGN KEY(fkPartieCorps) REFERENCES t_partieCorps(idpartieCorps),
    FOREIGN KEY(fkExercice) REFERENCES t_exercice(idExercice)
);

CREATE TABLE t_decritExercice (
    fkExercice INT,
    fkLienWeb VARCHAR(255),
    PRIMARY KEY(fkExercice, fkLienWeb),
    FOREIGN KEY(fkExercice) REFERENCES t_exercice(idExercice),
    FOREIGN KEY(fkLienWeb) REFERENCES t_lienWeb(idLienWeb)
);

CREATE TABLE t_decritRemede (
    fkRemede INT,
    fkLienWeb VARCHAR(255),
    PRIMARY KEY(fkRemede, fkLienWeb),
    FOREIGN KEY(fkRemede) REFERENCES t_remede(idRemede),
    FOREIGN KEY(fkLienWeb) REFERENCES t_lienWeb(idLienWeb)
);

-- Charger les données
LOAD DATA INFILE 'C:/Users/pw57drg/Desktop/DATA/t_partieCorps.csv'
INTO TABLE t_partieCorps
FIELDS TERMINATED BY ';'
LINES TERMINATED BY '\n'
IGNORE 1 ROWS
(parSexe, parNom);

LOAD DATA INFILE 'C:/Users/pw57drg/Desktop/DATA/t_exercice.csv'
INTO TABLE t_exercice
FIELDS TERMINATED BY ';'
LINES TERMINATED BY '\n'
IGNORE 1 ROWS
(exeNom, exeExplication);

LOAD DATA INFILE 'C:/Users/pw57drg/Desktop/DATA/t_remede.csv'
INTO TABLE t_remede
FIELDS TERMINATED BY ';'
LINES TERMINATED BY '\n'
IGNORE 1 ROWS
(remNom, remExplicationSimple, remExplicationDetaillee);

LOAD DATA INFILE 'C:/Users/pw57drg/Desktop/DATA/t_lienWeb.csv'
INTO TABLE t_lienWeb
FIELDS TERMINATED BY ';'
LINES TERMINATED BY '\n'
IGNORE 1 ROWS
(idLienWeb, lieType, lieDescription);

LOAD DATA INFILE 'C:/Users/pw57drg/Desktop/DATA/t_soigne.csv'
INTO TABLE t_soigne
FIELDS TERMINATED BY ';'
LINES TERMINATED BY '\n'
IGNORE 1 ROWS
(fkPartieCorps, fkRemede);

LOAD DATA INFILE 'C:/Users/pw57drg/Desktop/DATA/t_faitTravailler.csv'
INTO TABLE t_faitTravailler
FIELDS TERMINATED BY ';'
LINES TERMINATED BY '\n'
IGNORE 1 ROWS
(fkPartieCorps, fkExercice);

LOAD DATA INFILE 'C:/Users/pw57drg/Desktop/DATA/t_decritExercice.csv'
INTO TABLE t_decritExercice
FIELDS TERMINATED BY ';'
LINES TERMINATED BY '\n'
IGNORE 1 ROWS
(fkExercice, fkLienWeb);

LOAD DATA INFILE 'C:/Users/pw57drg/Desktop/DATA/t_decritRemede.csv'
INTO TABLE t_decritRemede
FIELDS TERMINATED BY ';'
LINES TERMINATED BY '\n'
IGNORE 1 ROWS
(fkRemede, fkLienWeb);
