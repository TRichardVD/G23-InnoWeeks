
DROP DATABASE db_maladie;

CREATE DATABASE db_maladie CHARACTER SET utf8 COLLATE utf8_general_ci;
USE db_maladie

   CREATE TABLE t_cause(
   idCause INT AUTO_INCREMENT,
   malNom VARCHAR(50) NOT NULL,
   PRIMARY KEY(idCause)
);

CREATE TABLE t_symptome(
   idSymptome INT AUTO_INCREMENT,
   malNom VARCHAR(50) NOT NULL,
   PRIMARY KEY(idSymptome)
);

CREATE TABLE t_medicament(
   idMedicament INT AUTO_INCREMENT,
   medNom VARCHAR(50) NOT NULL,
   medType ENUM('en vente libre', 'prescription') NOT NULL DEFAULT 'prescription',
   PRIMARY KEY(idMedicament)
);

CREATE TABLE t_conseil(
   idConseil INT AUTO_INCREMENT,
   conType ENUM('médical', 'naturel', 'activité') NOT NULL,
   conTexte VARCHAR(500),
   PRIMARY KEY(idConseil)
);

CREATE TABLE t_partieDuCorps(
   idPartieDuCorps INT AUTO_INCREMENT,
   parNom VARCHAR(50),
   PRIMARY KEY(idPartieDuCorps)
);

CREATE TABLE t_synonymeCause(
   idSynonymeCause INT AUTO_INCREMENT,
   synTexte VARCHAR(255),
   PRIMARY KEY(idSynonymeCause)
);

CREATE TABLE t_synCauses(
   idSynCauses INT AUTO_INCREMENT,
   synTexte VARCHAR(255),
   PRIMARY KEY(idSynCauses)
);

CREATE TABLE t_causer(
   fkMaladie INT,
   fkSymptome INT,
   cauTauxDeRessenti DECIMAL(3,2),
   PRIMARY KEY(fkMaladie, fkSymptome),
   FOREIGN KEY(fkMaladie) REFERENCES t_cause(idCause),
   FOREIGN KEY(fkSymptome) REFERENCES t_symptome(idSymptome)
);

CREATE TABLE t_soigne(
   idCause INT,
   idMedicament INT,
   PRIMARY KEY(idCause, idMedicament),
   FOREIGN KEY(idCause) REFERENCES t_cause(idCause),
   FOREIGN KEY(idMedicament) REFERENCES t_medicament(idMedicament)
);

CREATE TABLE t_soulage(
   idSymptome INT,
   idMedicament INT,
   PRIMARY KEY(idSymptome, idMedicament),
   FOREIGN KEY(idSymptome) REFERENCES t_symptome(idSymptome),
   FOREIGN KEY(idMedicament) REFERENCES t_medicament(idMedicament)
);

CREATE TABLE t_soulager(
   idSymptome INT,
   idConseil INT,
   PRIMARY KEY(idSymptome, idConseil),
   FOREIGN KEY(idSymptome) REFERENCES t_symptome(idSymptome),
   FOREIGN KEY(idConseil) REFERENCES t_conseil(idConseil)
);

CREATE TABLE t_etreSynonymeSymp(
   idSymptome INT,
   idSynonymeCause INT,
   PRIMARY KEY(idSymptome, idSynonymeCause),
   FOREIGN KEY(idSymptome) REFERENCES t_symptome(idSymptome),
   FOREIGN KEY(idSynonymeCause) REFERENCES t_synonymeCause(idSynonymeCause)
);

CREATE TABLE t_etreSynonymeCause(
   idCause INT,
   idSynCauses INT,
   PRIMARY KEY(idCause, idSynCauses),
   FOREIGN KEY(idCause) REFERENCES t_cause(idCause),
   FOREIGN KEY(idSynCauses) REFERENCES t_synCauses(idSynCauses)
);

CREATE TABLE t_etreSynonyme(
   idPartieDuCorps INT,
   idPartieDuCorps_1 INT,
   PRIMARY KEY(idPartieDuCorps, idPartieDuCorps_1),
   FOREIGN KEY(idPartieDuCorps) REFERENCES t_partieDuCorps(idPartieDuCorps),
   FOREIGN KEY(idPartieDuCorps_1) REFERENCES t_partieDuCorps(idPartieDuCorps)
);





