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

-- Insérer les parties du corps
INSERT INTO t_partieCorps (parSexe, parNom) VALUES
('tous', 'Cheville'),
('tous', 'Cuisses'),
('tous', 'Genoux'),
('tous', 'Jambes'),
('tous', 'Mollet'),
('tous', 'Orteils'),
('tous', 'Plante'),
('tous', 'Talon'),
('tous', 'Avant-bras'),
('tous', 'Coude'),
('tous', 'Epaules'),
('tous', 'Poignet'),
('tous', 'Doigts'),
('tous', 'Dos'),
('tous', 'Paume'),
('tous', 'Crane'),
('tous', 'Front'),
('tous', 'Gorge'),
('tous', 'Nuque'),
('tous', 'Tempes'),
('tous', 'Bouche'),
('tous', 'Joues'),
('tous', 'Mâchoires'),
('tous', 'Nez'),
('tous', 'Oreilles'),
('tous', 'Abdomen'),
('tous', 'Bassin'),
('tous', 'Colonne'),
('tous', 'Poitrine');

-- Insérer les exercices
INSERT INTO t_exercice (exeNom, exeExplication) VALUES
('Flexion plantaire et dorsale', 'Asseyez-vous sur une chaise avec les pieds à plat sur le sol. Soulevez lentement l\'avant du pied en gardant le talon au sol, puis ramenez le pied à la position de départ. Répétez 10-15 fois pour chaque pied.'),
('Squats', 'Tenez-vous debout avec les pieds écartés à la largeur des épaules. Pliez les genoux en gardant le dos droit, comme si vous alliez vous asseoir sur une chaise invisible. Revenez à la position de départ.'),
('Extensions de jambes assis', 'Asseyez-vous sur une chaise avec les pieds à plat sur le sol. Soulevez une jambe jusqu\'à ce qu\'elle soit droite, puis abaissez-la lentement. Répétez 10-15 fois pour chaque jambe.'),
('Fentes', 'Tenez-vous debout avec les pieds écartés à la largeur des hanches. Avancez une jambe et pliez les deux genoux jusqu\'à ce que le genou arrière touche presque le sol. Revenez à la position de départ et alternez les jambes.'),
('Montées sur les orteils', 'Tenez-vous debout près d\'un mur ou d\'une chaise pour vous soutenir. Levez-vous sur la pointe des pieds, puis redescendez lentement. Répétez 15-20 fois.'),
('Flexion et extension des orteils', 'Asseyez-vous confortablement. Pliez et étendez les orteils plusieurs fois. Répétez 20-30 fois.'),
('Roulement de balle', 'Asseyez-vous et placez une petite balle sous votre pied. Roulez la balle sous la plante du pied pendant 2-3 minutes. Répétez avec l\'autre pied.'),
('Étirement du mollet', 'Tenez-vous face à un mur. Appuyez vos mains contre le mur et étirez une jambe en arrière, en gardant le talon au sol. Maintenez la position pendant 30 secondes.'),
('Flexion des poignets', 'Asseyez-vous avec l\'avant-bras sur une table, la paume vers le haut. Soulevez lentement la main vers le haut, puis redescendez. Répétez 15-20 fois.'),
('Extension du triceps', 'Tenez-vous debout avec une main tenant un poids léger derrière la tête. Étendez le bras vers le haut, puis revenez lentement. Répétez 10-15 fois pour chaque bras.'),
('Roulement des épaules', 'Asseyez-vous ou tenez-vous debout confortablement. Levez les épaules vers les oreilles, puis roulez-les en arrière et en bas. Répétez 10-15 fois.'),
('Roulement des poignets', 'Tendez les bras devant vous. Faites tourner les poignets en cercles, d\'abord dans un sens, puis dans l\'autre. Répétez 10-15 fois.'),
('Flexion et extension des doigts', 'Étirez les doigts en les écartant le plus possible. Fermez lentement la main en poing, puis étirez à nouveau. Répétez 10-15 fois.'),
('Chat-vache', 'Mettez-vous à quatre pattes. Creusez le dos en levant la tête (position "vache"). Arrondissez le dos en baissant la tête (position "chat"). Répétez 10-15 fois.'),
('Étirement des paumes', 'Tendez un bras devant vous, paume vers le haut. Tirez doucement les doigts vers vous avec l\'autre main. Maintenez pendant 15-20 secondes.'),
('Massage du crâne', 'Utilisez le bout des doigts pour masser doucement le crâne en mouvements circulaires. Faites cela pendant 5-10 minutes.'),
('Relaxation du front', 'Fermez les yeux et détendez-vous. Utilisez vos doigts pour masser doucement le front en mouvements circulaires. Répétez pendant 2-3 minutes.'),
('Étirement de la gorge', 'Levez la tête vers le plafond. Ouvrez la bouche pour sentir un léger étirement. Maintenez pendant 15-20 secondes.'),
('Étirement de la nuque', 'Inclinez la tête vers l\'épaule gauche, en utilisant la main gauche pour un léger étirement. Maintenez pendant 15-20 secondes, puis changez de côté. Répétez 3-5 fois.'),
('Massage des tempes', 'Utilisez le bout des doigts pour masser doucement les tempes en mouvements circulaires. Faites cela pendant 2-3 minutes.'),
('Étirement de la mâchoire', 'Ouvrez la bouche aussi largement que possible sans douleur. Maintenez pendant 5 secondes, puis relâchez. Répétez 10-15 fois.'),
('Gonflement des joues', 'Gonflez les joues avec de l\'air. Maintenez pendant 5 secondes, puis relâchez. Répétez 10-15 fois.'),
('Mastication simulée', 'Ouvrez et fermez la bouche comme si vous mâchiez. Répétez 10-15 fois.'),
('Respiration profonde', 'Asseyez-vous confortablement. Inspirez profondément par le nez, puis expirez lentement par la bouche. Répétez 10-15 fois.'),
('Étirement des oreilles', 'Tirez doucement le lobe de l\'oreille vers le bas. Maintenez pendant 5-10 secondes. Répétez 5-10 fois.'),
('Crunchs abdominaux', 'Allongez-vous sur le dos, les genoux pliés. Soulevez lentement les épaules du sol en contractant les abdominaux. Répétez 10-15 fois.'),
('Ponts', 'Allongez-vous sur le dos, les genoux pliés. Soulevez le bassin vers le haut en contractant les fessiers. Répétez 10-15 fois.'),
('Étirement du chat', 'Mettez-vous à quatre pattes. Creusez et arrondissez le dos alternativement. Répétez 10-15 fois.'),
('Étirement de la poitrine', 'Tenez-vous debout avec les bras levés sur les côtés. Tirez les bras vers l\'arrière pour ouvrir la poitrine. Maintenez pendant 20-30 secondes.');

-- Associer les exercices aux parties du corps
INSERT INTO t_faitTravailler (fkPartieCorps, fkExercice) VALUES
((SELECT idpartieCorps FROM t_partieCorps WHERE parNom = 'Cheville'), (SELECT idExercice FROM t_exercice WHERE exeNom = 'Flexion plantaire et dorsale')),
((SELECT idpartieCorps FROM t_partieCorps WHERE parNom = 'Cuisses'), (SELECT idExercice FROM t_exercice WHERE exeNom = 'Squats')),
((SELECT idpartieCorps FROM t_partieCorps WHERE parNom = 'Genoux'), (SELECT idExercice FROM t_exercice WHERE exeNom = 'Extensions de jambes assis')),
((SELECT idpartieCorps FROM t_partieCorps WHERE parNom = 'Jambes'), (SELECT idExercice FROM t_exercice WHERE exeNom = 'Fentes')),
((SELECT idpartieCorps FROM t_partieCorps WHERE parNom = 'Mollet'), (SELECT idExercice FROM t_exercice WHERE exeNom = 'Montées sur les orteils')),
((SELECT idpartieCorps FROM t_partieCorps WHERE parNom = 'Orteils'), (SELECT idExercice FROM t_exercice WHERE exeNom = 'Flexion et extension des orteils')),
((SELECT idpartieCorps FROM t_partieCorps WHERE parNom = 'Plante'), (SELECT idExercice FROM t_exercice WHERE exeNom = 'Roulement de balle')),
((SELECT idpartieCorps FROM t_partieCorps WHERE parNom = 'Talon'), (SELECT idExercice FROM t_exercice WHERE exeNom = 'Étirement du mollet')),
((SELECT idpartieCorps FROM t_partieCorps WHERE parNom = 'Avant-bras'), (SELECT idExercice FROM t_exercice WHERE exeNom = 'Flexion des poignets')),
((SELECT idpartieCorps FROM t_partieCorps WHERE parNom = 'Coude'), (SELECT idExercice FROM t_exercice WHERE exeNom = 'Extension du triceps')),
((SELECT idpartieCorps FROM t_partieCorps WHERE parNom = 'Epaules'), (SELECT idExercice FROM t_exercice WHERE exeNom = 'Roulement des épaules')),
((SELECT idpartieCorps FROM t_partieCorps WHERE parNom = 'Poignet'), (SELECT idExercice FROM t_exercice WHERE exeNom = 'Roulement des poignets')),
((SELECT idpartieCorps FROM t_partieCorps WHERE parNom = 'Doigts'), (SELECT idExercice FROM t_exercice WHERE exeNom = 'Flexion et extension des doigts')),
((SELECT idpartieCorps FROM t_partieCorps WHERE parNom = 'Dos'), (SELECT idExercice FROM t_exercice WHERE exeNom = 'Chat-vache')),
((SELECT idpartieCorps FROM t_partieCorps WHERE parNom = 'Paume'), (SELECT idExercice FROM t_exercice WHERE exeNom = 'Étirement des paumes')),
((SELECT idpartieCorps FROM t_partieCorps WHERE parNom = 'Crane'), (SELECT idExercice FROM t_exercice WHERE exeNom = 'Massage du crâne')),
((SELECT idpartieCorps FROM t_partieCorps WHERE parNom = 'Front'), (SELECT idExercice FROM t_exercice WHERE exeNom = 'Relaxation du front')),
((SELECT idpartieCorps FROM t_partieCorps WHERE parNom = 'Gorge'), (SELECT idExercice FROM t_exercice WHERE exeNom = 'Étirement de la gorge')),
((SELECT idpartieCorps FROM t_partieCorps WHERE parNom = 'Nuque'), (SELECT idExercice FROM t_exercice WHERE exeNom = 'Étirement de la nuque')),
((SELECT idpartieCorps FROM t_partieCorps WHERE parNom = 'Tempes'), (SELECT idExercice FROM t_exercice WHERE exeNom = 'Massage des tempes')),
((SELECT idpartieCorps FROM t_partieCorps WHERE parNom = 'Bouche'), (SELECT idExercice FROM t_exercice WHERE exeNom = 'Étirement de la mâchoire')),
((SELECT idpartieCorps FROM t_partieCorps WHERE parNom = 'Joues'), (SELECT idExercice FROM t_exercice WHERE exeNom = 'Gonflement des joues')),
((SELECT idpartieCorps FROM t_partieCorps WHERE parNom = 'Mâchoires'), (SELECT idExercice FROM t_exercice WHERE exeNom = 'Mastication simulée')),
((SELECT idpartieCorps FROM t_partieCorps WHERE parNom = 'Nez'), (SELECT idExercice FROM t_exercice WHERE exeNom = 'Respiration profonde')),
((SELECT idpartieCorps FROM t_partieCorps WHERE parNom = 'Oreilles'), (SELECT idExercice FROM t_exercice WHERE exeNom = 'Étirement des oreilles')),
((SELECT idpartieCorps FROM t_partieCorps WHERE parNom = 'Abdomen'), (SELECT idExercice FROM t_exercice WHERE exeNom = 'Crunchs abdominaux')),
((SELECT idpartieCorps FROM t_partieCorps WHERE parNom = 'Bassin'), (SELECT idExercice FROM t_exercice WHERE exeNom = 'Ponts')),
((SELECT idpartieCorps FROM t_partieCorps WHERE parNom = 'Colonne'), (SELECT idExercice FROM t_exercice WHERE exeNom = 'Étirement du chat')),
((SELECT idpartieCorps FROM t_partieCorps WHERE parNom = 'Poitrine'), (SELECT idExercice FROM t_exercice WHERE exeNom = 'Étirement de la poitrine'));