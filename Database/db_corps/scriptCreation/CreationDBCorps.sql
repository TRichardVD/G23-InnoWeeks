DROP DATABASE db_corps;
CREATE DATABASE db_corps CHARACTER SET utf8 COLLATE utf8_general_ci 



CREATE TABLE t_partieCorps(
   idpartieCorps INT AUTO_INCREMENT,
   parSexe ENUM('Masculin', 'Feminin', 'tous'),
   parNom VARCHAR(25) NOT NULL,
   PRIMARY KEY(idpartieCorps)
);

CREATE TABLE t_exercice(
   idExercice INT AUTO_INCREMENT,
   exeNom VARCHAR(50),
   exeExplication VARCHAR(2000) NOT NULL,
   PRIMARY KEY(idExercice)
);

CREATE TABLE t_remede(
   idRemede INT AUTO_INCREMENT,
   remNom VARCHAR(150) NOT NULL,
   remExplicationSimple VARCHAR(2000) NOT NULL,
   remExplicationDetaillle VARCHAR(3000),
   PRIMARY KEY(idRemede)
);

CREATE TABLE t_lienWeb(
   idLienWeb VARCHAR(50),
   lieType ENUM ('video','article','definition') NOT NULL,
   lieDescription VARCHAR(50),
   PRIMARY KEY(idLienWeb)
);

CREATE TABLE t_soigne(
   fkPartieCorps INT,
   fkRemede INT,
   PRIMARY KEY(fkPartieCorps, fkRemede),
   FOREIGN KEY(fkPartieCorps) REFERENCES t_partieCorps(idpartieCorps),
   FOREIGN KEY(fkRemede) REFERENCES t_remede(idRemede)
);

CREATE TABLE t_faitTravailler(
   fkPartieCorps INT,
   fkExercice INT,
   PRIMARY KEY(fkPartieCorps, fkExercice),
   FOREIGN KEY(fkPartieCorps) REFERENCES t_partieCorps(idpartieCorps),
   FOREIGN KEY(fkExercice) REFERENCES t_exercice(idExercice)
);

CREATE TABLE t_decritExercice(
   fkExercice INT,
   fkLienWeb VARCHAR(50),
   PRIMARY KEY(fkExercice, fkLienWeb),
   FOREIGN KEY(fkExercice) REFERENCES t_exercice(idExercice),
   FOREIGN KEY(fkLienWeb) REFERENCES t_lienWeb(idLienWeb)
);

CREATE TABLE t_decritRemede(
   idRemede_fkRemede INT,
   fkLienWeb VARCHAR(50),
   PRIMARY KEY(idRemede_fkRemede, fkLienWeb),
   FOREIGN KEY(idRemede_fkRemede) REFERENCES t_remede(idRemede),
   FOREIGN KEY(fkLienWeb) REFERENCES t_lienWeb(idLienWeb)
);
