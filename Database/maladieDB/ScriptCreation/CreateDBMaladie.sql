
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
   PRIMARY KEY(idMedicament)
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


