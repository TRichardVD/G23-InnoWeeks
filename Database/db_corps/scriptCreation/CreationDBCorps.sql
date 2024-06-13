-- Supprimer la base de données existante et créer une nouvelle
DROP DATABASE IF EXISTS db_pcorps;
CREATE DATABASE db_pcorps CHARACTER SET utf8mb4 COLLATE utf8mb4_general_ci;
USE db_pcorps;

-- Créer les tables
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
   exeAvertissement VARCHAR(300),
   ExePersonneConvient VARCHAR(100) NOT NULL,
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
   idLienWeb VARCHAR(255),
   lieType ENUM ('video','article','definition') NOT NULL,
   lieDescription VARCHAR(255),
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
   fkLienWeb VARCHAR(255),
   PRIMARY KEY(fkExercice, fkLienWeb),
   FOREIGN KEY(fkExercice) REFERENCES t_exercice(idExercice),
   FOREIGN KEY(fkLienWeb) REFERENCES t_lienWeb(idLienWeb)
);

CREATE TABLE t_decritRemede(
   fkRemede INT,
   fkLienWeb VARCHAR(255),
   PRIMARY KEY(fkRemede, fkLienWeb),
   FOREIGN KEY(fkRemede) REFERENCES t_remede(idRemede),
   FOREIGN KEY(fkLienWeb) REFERENCES t_lienWeb(idLienWeb)
);



-- Insertion des parties du corps
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
('tous', 'Épaules'),
('tous', 'Poignet'),
('tous', 'Doigts'),
('tous', 'Dos'),
('tous', 'Paume'),
('tous', 'Crâne'),
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

-- Insertion des exercices
INSERT INTO t_exercice (exeNom, exeExplication, exeAvertissement, ExePersonneConvient) VALUES 
('Cercles de la cheville', '1. Asseyez-vous confortablement sur une chaise 🪑. 2. Soulevez un pied du sol 🦶. 3. Faites des cercles avec votre cheville dans le sens des aiguilles d''une montre pendant 20 secondes ⏲️. 4. Changez de direction et faites des cercles dans le sens inverse pendant 20 secondes 🔄.', 'Ne forcez pas si vous ressentez une douleur aiguë. Cet exercice est déconseillé aux personnes ayant des fractures récentes à la cheville.', 'Tous'),
('Étirement des quadriceps', '1. Tenez-vous droit et attrapez votre cheville droite avec votre main droite derrière vous 🦵. 2. Tirez doucement votre pied vers vos fesses jusqu''à sentir un étirement à l''avant de la cuisse 🤲. 3. Maintenez pendant 30 secondes, puis changez de jambe ⏳.', 'Ne pas forcer l''étirement. Déconseillé en cas de blessures récentes aux genoux.', 'Tous'),
('Flexion des genoux', '1. Tenez-vous debout avec les pieds écartés à la largeur des épaules 🚶. 2. Pliez lentement les genoux en descendant comme pour vous asseoir sur une chaise invisible 🪑. 3. Remontez doucement en position debout 🆙.', 'Gardez les genoux alignés avec les orteils. Évitez en cas de douleurs aiguës au genou.', 'Tous'),
('Marches sur place', '1. Tenez-vous droit et marchez sur place en levant les genoux aussi haut que possible 🚶. 2. Faites cela pendant 1 minute 🕐.', 'Faites attention à vos genoux si vous avez des douleurs chroniques.', 'Tous'),
('Étirement des mollets', '1. Placez-vous face à un mur, une jambe en avant et l''autre en arrière 🧍. 2. Pliez le genou avant tout en gardant le talon arrière au sol 🦵. 3. Maintenez pendant 30 secondes et changez de jambe ⏳.', 'Ne forcez pas l''étirement. Déconseillé en cas de tendinite aiguë.', 'Tous'),
('Flexion et extension des orteils', '1. Asseyez-vous et retirez vos chaussures et chaussettes 👟. 2. Étendez et pliez vos orteils autant que possible 👣. 3. Répétez pendant 1 minute 🕐.', 'Ne pas forcer les mouvements. Évitez si vous avez des blessures aux orteils.', 'Tous'),
('Rouler une balle', '1. Asseyez-vous et placez une balle de tennis sous votre pied 🏐. 2. Roulez la balle sous la plante du pied en exerçant une légère pression 🦶. 3. Faites cela pendant 1 minute, puis changez de pied ⏳.', 'Ne pas exercer une pression excessive. Déconseillé en cas de douleur aiguë à la plante.', 'Tous'),
('Étirement du talon', '1. Asseyez-vous et placez une serviette autour de la plante de votre pied 🧴. 2. Tirez doucement les extrémités de la serviette vers vous, en maintenant la jambe tendue 🦵. 3. Maintenez pendant 30 secondes, puis changez de pied ⏳.', 'Ne forcez pas l''étirement. Évitez en cas de douleur aiguë au talon.', 'Tous'),
('Flexion de l''avant-bras', '1. Tendez un bras devant vous avec la paume vers le haut ✋. 2. Avec l''autre main, tirez doucement les doigts vers l''arrière 🖐️. 3. Maintenez pendant 15 secondes, puis changez de bras ⏳.', 'Ne pas forcer. Déconseillé en cas de tendinite aiguë.', 'Tous'),
('Extension du triceps', '1. Levez un bras au-dessus de votre tête et pliez-le pour toucher l''omoplate 🫲. 2. Avec l''autre main, poussez doucement le coude vers le bas 🖐️. 3. Maintenez pendant 15 secondes, puis changez de bras ⏳.', 'Évitez en cas de douleur aiguë au coude.', 'Tous'),
('Roulements d''épaules', '1. Tenez-vous droit et levez les épaules vers vos oreilles 👂. 2. Faites des cercles avec vos épaules vers l''arrière et vers le bas 🌀. 3. Répétez 10 fois, puis changez de direction 🔄.', 'Évitez les mouvements brusques. Déconseillé en cas de blessures à l''épaule.', 'Tous'),
('Flexion du poignet', '1. Tendez un bras devant vous avec la paume vers le bas ✋. 2. Avec l''autre main, tirez doucement les doigts vers vous 👋. 3. Maintenez pendant 15 secondes, puis changez de bras ⏳.', 'Ne pas forcer. Évitez si vous avez des douleurs aiguës au poignet.', 'Tous'),
('Écartement des doigts', '1. Tendez une main devant vous 🤲. 2. Écartez vos doigts autant que possible, puis rapprochez-les 👐. 3. Répétez 10 fois 🕐.', 'Ne forcez pas. Déconseillé en cas de douleurs articulaires aux doigts.', 'Tous'),
('Étirement du dos', '1. Allongez-vous sur le dos, les genoux pliés et les pieds à plat au sol 🛏️. 2. Ramenez vos genoux vers votre poitrine en les tenant avec vos mains 👐. 3. Maintenez pendant 20 secondes, puis relâchez ⏳.', 'Évitez en cas de douleurs aiguës au dos.', 'Tous'),
('Flexion de la paume', '1. Tendez une main devant vous avec la paume vers le haut ✋. 2. Avec l''autre main, tirez doucement les doigts vers l''arrière 🖐️. 3. Maintenez pendant 15 secondes, puis changez de main ⏳.', 'Ne forcez pas. Déconseillé en cas de blessures à la main.', 'Tous'),
('Auto-massage du cuir chevelu', '1. Asseyez-vous confortablement 🪑. 2. Utilisez vos doigts pour masser doucement votre cuir chevelu en mouvements circulaires 👆. 3. Faites cela pendant 2 minutes 🕒.', 'Évitez de presser trop fort. Convient à tous.', 'Tous'),
('Détente du front', '1. Asseyez-vous confortablement 🪑. 2. Utilisez vos doigts pour masser doucement votre front en mouvements circulaires 👆. 3. Faites cela pendant 1 minute 🕒.', 'Convient à tous.', 'Tous'),
('Étirement du cou', '1. Tenez-vous droit et inclinez lentement la tête vers l''arrière pour regarder le plafond 👀. 2. Maintenez pendant 10 secondes, puis revenez à la position de départ ⏳.', 'Ne pas forcer l''étirement. Déconseillé en cas de douleurs cervicales.', 'Tous'),
('Étirement de la nuque', '1. Tenez-vous droit et inclinez lentement la tête sur le côté, en rapprochant l''oreille de l''épaule 🧏. 2. Maintenez pendant 15 secondes, puis changez de côté ⏳.', 'Ne forcez pas. Déconseillé en cas de douleurs cervicales.', 'Tous'),
('Auto-massage des tempes', '1. Asseyez-vous confortablement 🪑. 2. Utilisez vos doigts pour masser doucement vos tempes en mouvements circulaires 👆. 3. Faites cela pendant 1 minute 🕒.', 'Évitez de presser trop fort. Convient à tous.', 'Tous'),
('Étirement des lèvres', '1. Asseyez-vous et souriez aussi largement que possible 😀. 2. Maintenez pendant 10 secondes, puis relâchez 😌. 3. Répétez 5 fois 🕒.', 'Convient à tous.', 'Tous'),
('Gonfler les joues', '1. Asseyez-vous et gonflez vos joues avec de l''air 😲. 2. Maintenez pendant 10 secondes, puis relâchez. 3. Répétez 5 fois 🕒.', 'Convient à tous.', 'Tous'),
('Étirement de la mâchoire', '1. Ouvrez la bouche aussi largement que possible sans ressentir de douleur 😮. 2. Maintenez pendant 10 secondes, puis relâchez 😌. 3. Répétez 5 fois 🕒.', 'Ne forcez pas. Déconseillé en cas de problèmes de TMJ.', 'Tous'),
('Respiration profonde', '1. Asseyez-vous confortablement et inspirez profondément par le nez 🧘. 2. Expirez lentement par la bouche 🌬️. 3. Répétez pendant 1 minute 🕒.', 'Convient à tous.', 'Tous'),
('Massage des oreilles', '1. Asseyez-vous confortablement 🪑. 2. Utilisez vos doigts pour masser doucement le lobe de vos oreilles en mouvements circulaires 👂. 3. Faites cela pendant 1 minute 🕒.', 'Évitez de presser trop fort. Convient à tous.', 'Tous'),
('Respiration abdominale', '1. Asseyez-vous ou allongez-vous confortablement 🛏️. 2. Placez une main sur votre abdomen et respirez profondément en gonflant votre ventre 🌬️. 3. Expirez lentement en contractant les muscles abdominaux. 4. Répétez pendant 1 minute 🕒.', 'Convient à tous.', 'Tous'),
('Bascules pelviennes', '1. Allongez-vous sur le dos, les genoux pliés et les pieds à plat au sol 🛏️. 2. Serrez les muscles abdominaux pour aplatir le bas de votre dos contre le sol 🔄. 3. Maintenez pendant 5 secondes, puis relâchez. 4. Répétez 10 fois 🕒.', 'Convient à tous.', 'Tous'),
('Étirement du chat', '1. Mettez-vous à quatre pattes, les mains sous les épaules et les genoux sous les hanches 🐱. 2. Arrondissez le dos vers le plafond comme un chat 🐈. 3. Maintenez pendant 5 secondes, puis revenez à la position neutre. 4. Répétez 10 fois 🕒.', 'Ne forcez pas les mouvements. Déconseillé en cas de douleurs dorsales aiguës.', 'Tous'),
('Ouverture de la poitrine', '1. Tenez-vous droit et placez vos mains derrière votre tête 🤲. 2. Serrez les omoplates ensemble pour ouvrir la poitrine 👐. 3. Maintenez pendant 10 secondes, puis relâchez. 4. Répétez 5 fois 🕒.', 'Ne forcez pas l''ouverture. Déconseillé en cas de douleurs aux épaules.', 'Tous');

-- Liaison entre les parties du corps et les exercices
INSERT INTO t_faitTravailler (fkPartieCorps, fkExercice) VALUES
((SELECT idpartieCorps FROM t_partieCorps WHERE parNom='Cheville'), (SELECT idExercice FROM t_exercice WHERE exeNom='Cercles de la cheville')),
((SELECT idpartieCorps FROM t_partieCorps WHERE parNom='Cuisses'), (SELECT idExercice FROM t_exercice WHERE exeNom='Étirement des quadriceps')),
((SELECT idpartieCorps FROM t_partieCorps WHERE parNom='Genoux'), (SELECT idExercice FROM t_exercice WHERE exeNom='Flexion des genoux')),
((SELECT idpartieCorps FROM t_partieCorps WHERE parNom='Jambes'), (SELECT idExercice FROM t_exercice WHERE exeNom='Marches sur place')),
((SELECT idpartieCorps FROM t_partieCorps WHERE parNom='Mollet'), (SELECT idExercice FROM t_exercice WHERE exeNom='Étirement des mollets')),
((SELECT idpartieCorps FROM t_partieCorps WHERE parNom='Orteils'), (SELECT idExercice FROM t_exercice WHERE exeNom='Flexion et extension des orteils')),
((SELECT idpartieCorps FROM t_partieCorps WHERE parNom='Plante'), (SELECT idExercice FROM t_exercice WHERE exeNom='Rouler une balle')),
((SELECT idpartieCorps FROM t_partieCorps WHERE parNom='Talon'), (SELECT idExercice FROM t_exercice WHERE exeNom='Étirement du talon')),
((SELECT idpartieCorps FROM t_partieCorps WHERE parNom='Avant-bras'), (SELECT idExercice FROM t_exercice WHERE exeNom='Flexion de l\'avant-bras')),
((SELECT idpartieCorps FROM t_partieCorps WHERE parNom='Coude'), (SELECT idExercice FROM t_exercice WHERE exeNom='Extension du triceps')),
((SELECT idpartieCorps FROM t_partieCorps WHERE parNom='Épaules'), (SELECT idExercice FROM t_exercice WHERE exeNom='Roulements d\'épaules')),
((SELECT idpartieCorps FROM t_partieCorps WHERE parNom='Poignet'), (SELECT idExercice FROM t_exercice WHERE exeNom='Flexion du poignet')),
((SELECT idpartieCorps FROM t_partieCorps WHERE parNom='Doigts'), (SELECT idExercice FROM t_exercice WHERE exeNom='Écartement des doigts')),
((SELECT idpartieCorps FROM t_partieCorps WHERE parNom='Dos'), (SELECT idExercice FROM t_exercice WHERE exeNom='Étirement du dos')),
((SELECT idpartieCorps FROM t_partieCorps WHERE parNom='Paume'), (SELECT idExercice FROM t_exercice WHERE exeNom='Flexion de la paume')),
((SELECT idpartieCorps FROM t_partieCorps WHERE parNom='Crâne'), (SELECT idExercice FROM t_exercice WHERE exeNom='Auto-massage du cuir chevelu')),
((SELECT idpartieCorps FROM t_partieCorps WHERE parNom='Front'), (SELECT idExercice FROM t_exercice WHERE exeNom='Détente du front')),
((SELECT idpartieCorps FROM t_partieCorps WHERE parNom='Gorge'), (SELECT idExercice FROM t_exercice WHERE exeNom='Étirement du cou')),
((SELECT idpartieCorps FROM t_partieCorps WHERE parNom='Nuque'), (SELECT idExercice FROM t_exercice WHERE exeNom='Étirement de la nuque')),
((SELECT idpartieCorps FROM t_partieCorps WHERE parNom='Tempes'), (SELECT idExercice FROM t_exercice WHERE exeNom='Auto-massage des tempes')),
((SELECT idpartieCorps FROM t_partieCorps WHERE parNom='Bouche'), (SELECT idExercice FROM t_exercice WHERE exeNom='Étirement des lèvres')),
((SELECT idpartieCorps FROM t_partieCorps WHERE parNom='Joues'), (SELECT idExercice FROM t_exercice WHERE exeNom='Gonfler les joues')),
((SELECT idpartieCorps FROM t_partieCorps WHERE parNom='Mâchoires'), (SELECT idExercice FROM t_exercice WHERE exeNom='Étirement de la mâchoire')),
((SELECT idpartieCorps FROM t_partieCorps WHERE parNom='Nez'), (SELECT idExercice FROM t_exercice WHERE exeNom='Respiration profonde')),
((SELECT idpartieCorps FROM t_partieCorps WHERE parNom='Oreilles'), (SELECT idExercice FROM t_exercice WHERE exeNom='Massage des oreilles')),
((SELECT idpartieCorps FROM t_partieCorps WHERE parNom='Abdomen'), (SELECT idExercice FROM t_exercice WHERE exeNom='Respiration abdominale')),
((SELECT idpartieCorps FROM t_partieCorps WHERE parNom='Bassin'), (SELECT idExercice FROM t_exercice WHERE exeNom='Bascules pelviennes')),
((SELECT idpartieCorps FROM t_partieCorps WHERE parNom='Colonne'), (SELECT idExercice FROM t_exercice WHERE exeNom='Étirement du chat')),
((SELECT idpartieCorps FROM t_partieCorps WHERE parNom='Poitrine'), (SELECT idExercice FROM t_exercice WHERE exeNom='Ouverture de la poitrine'));
