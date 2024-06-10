
DROP DATABASE db_client;

CREATE db_client CHARACTER SET utf8 COLLATE utf8_general_ci



CREATE TABLE t_utilisateur(
   idUtilisateur INT AUTO_INCREMENT,
   utiDateNaissance DATE NOT NULL,
   PRIMARY KEY(idUtilisateur)
);

CREATE TABLE t_taille(
   idTaille INT AUTO_INCREMENT,
   taiValeur TINYINT NOT NULL,
   taiDate DATE NOT NULL,
   fkUtilisateur INT NOT NULL,
   PRIMARY KEY(idTaille),
   FOREIGN KEY(fkUtilisateur) REFERENCES t_utilisateur(idUtilisateur)
);

CREATE TABLE t_poids(
   idPoids INT AUTO_INCREMENT,
   poiValeur TINYINT NOT NULL,
   poiDate DATE NOT NULL,
   fkUtilisateur INT NOT NULL,
   PRIMARY KEY(idPoids),
   FOREIGN KEY(fkUtilisateur) REFERENCES t_utilisateur(idUtilisateur)
);

CREATE TABLE t_message(
   idMessage INT AUTO_INCREMENT,
   msgEntre VARCHAR(500) NOT NULL,
   msgCreated_at DATETIME NOT NULL DEFAULT CURRENT_TIMESTAMP,
   msgUpdated_at DATETIME NOT NULL DEFAULT CURRENT_TIMESTAMP ON UPDATE CURRENT_TIMESTAMP,
   PRIMARY KEY(idMessage)
);

CREATE TABLE t_ecrit(
   fkUtilisateur INT,
   fkMessage INT,
   PRIMARY KEY(fkUtilisateur, fkMessage),
   FOREIGN KEY(fkUtilisateur) REFERENCES t_utilisateur(idUtilisateur),
   FOREIGN KEY(fkMessage) REFERENCES t_message(idMessage)
);







 
DELIMITER //

CREATE TRIGGER before_insert_votre_table
BEFORE INSERT ON votre_table
FOR EACH ROW
BEGIN
    SET NEW.created_at = NOW();
    SET NEW.updated_at = NOW();
END;
//

CREATE TRIGGER before_update_votre_table
BEFORE UPDATE ON votre_table
FOR EACH ROW
BEGIN
    SET NEW.updated_at = NOW();
END;
//

DELIMITER ;
