
    DROP DATABASE db_maladie;

    CREATE DATABASE db_maladie CHARACTER SET utf8 COLLATE utf8_general_ci;
    USE db_maladie

    CREATE TABLE t_maladie(
    idMaladie INT AUTO_INCREMENT,
    malNom VARCHAR(50) NOT NULL,
    PRIMARY KEY(idMaladie)
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

    CREATE TABLE t_cause(
    fkMaladie INT,
    fkSymptome INT,
    cauTauxDeRessenti DECIMAL(3,2),
    PRIMARY KEY(fkMaladie, fkSymptome),
    FOREIGN KEY(fkMaladie) REFERENCES t_maladie(idMaladie),
    FOREIGN KEY(fkSymptome) REFERENCES t_symptome(idSymptome)
    );

    CREATE TABLE t_soigne(
    idMaladie INT,
    idMedicament INT,
    PRIMARY KEY(idMaladie, idMedicament),
    FOREIGN KEY(idMaladie) REFERENCES t_maladie(idMaladie),
    FOREIGN KEY(idMedicament) REFERENCES t_medicament(idMedicament)
    );

    CREATE TABLE t_soulage(
    idSymptome INT,
    idMedicament INT,
    PRIMARY KEY(idSymptome, idMedicament),
    FOREIGN KEY(idSymptome) REFERENCES t_symptome(idSymptome),
    FOREIGN KEY(idMedicament) REFERENCES t_medicament(idMedicament)
    );


    LOAD DATA
        INFILE 'C:/Users/pw57drg/Documents/GitHub/G23-InnoWeeks/Database/maladieDB/DATA/t_cause.csv'
        INTO TABLE t_cause
        IGNORE 1 LINES;

    LOAD DATA
        INFILE 'C:/Users/pw57drg/Documents/GitHub/G23-InnoWeeks/Database/maladieDB/DATA/t_maladie.csv'
        INTO TABLE t_maladie
        IGNORE 1 LINES;

    LOAD DATA
        INFILE 'C:/Users/pw57drg/Documents/GitHub/G23-InnoWeeks/Database/maladieDB/DATA/t_medicament.csv'
        INTO TABLE t_medicament
        IGNORE 1 LINES;

    LOAD DATA
        INFILE 'C:/Users/pw57drg/Documents/GitHub/G23-InnoWeeks/Database/maladieDB/DATA/t_soigne.csv'
        INTO TABLE t_soigne
        IGNORE 1 LINES;

    LOAD DATA
        INFILE 'C:/Users/pw57drg/Documents/GitHub/G23-InnoWeeks/Database/maladieDB/DATA/t_soulage.csv'
        INTO TABLE t_soulage
        IGNORE 1 LINES;

    LOAD DATA
        INFILE 'C:/Users/pw57drg/Documents/GitHub/G23-InnoWeeks/Database/maladieDB/DATA/t_symptome.csv'
        INTO TABLE t_symptome
        IGNORE 1 LINES;