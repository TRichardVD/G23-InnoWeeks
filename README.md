# Move IT : Assistant médical InnoWeeks 2024

## Tâches développeurs
### Base de données
- [x] Mise à jour des scripts de création de la base de données
- [x] Finalisation des boucles (looping)
- [x] Création de données fonctionnelles et valides
- [x] Exportation des bases de données

### Code de l'application
- [ ] Création du script d'analyse de texte et d'utilisation de la base de données
- [ ] Ajout des paramètres et conditions d'utilisation

### Tests
- [ ] Définir les scénarios de test
- [ ] Mettre en place les tests unitaires
- [ ] Effectuer des tests de performance

### Documentation
- [x] Rédaction du Pitch
- [ ] Rédaction de la documentation technique
- [ ] Élaboration du guide d'utilisation

## Version
- v0.1 (version initiale)

## Pitch

### Introduction 
Bonjour à tous. Imaginez un monde où chacun peut soulager ses douleurs corporelles de manière simple, personnalisée et confidentielle. C'est la vision de "Move IT", l'assistant médical intelligent que nous avons développé durant les InnoWeeks 2024 à l'ETML. Move IT révolutionne la façon dont nous gérons nos douleurs au quotidien.
### Problème à résoudre 
Nous avons tous déjà ressenti des douleurs qui impactent notre qualité de vie. Pourtant, trouver des solutions adaptées peut être un véritable défi. Les informations en ligne sont souvent génériques, peu fiables et ne respectent pas toujours notre vie privée. Il est temps de changer cela.
### Solution proposée 
Move IT est la réponse à ce problème. Notre application analyse les descriptions de vos douleurs grâce à des techniques avancées de traitement du langage. Que vous ayez mal au dos, aux épaules ou aux genoux, Move IT vous fournit des recommandations personnalisées. Par exemple, si vous souffrez de douleurs lombaires, l'application pourra vous suggérer des étirements ciblés et des exercices de renforcement musculaire adaptés à votre condition.
### Fonctionnalités clés 
Avec Move IT, prendre soin de votre corps devient un jeu d'enfant. Notre interface intuitive vous permet d'indiquer vos douleurs en quelques clics, soit par une description, soit en utilisant un schéma interactif du corps humain. Move IT analyse ensuite ces informations localement, garantissant ainsi une confidentialité totale de vos données. Vous obtenez alors des suggestions d'exercices et de remèdes personnalisés, accessibles à tout moment.
### Avantages compétitifs
Move IT se distingue par son engagement envers la confidentialité, son accessibilité et sa personnalisation poussée. Là où d'autres solutions se contentent de conseils génériques, notre application s'adapte à chaque utilisateur. Move IT prend en compte de nombreux facteurs tels que votre âge, votre condition physique, vos antécédents médicaux et l'intensité de vos douleurs pour vous fournir des recommandations sur-mesure. Que vous soyez un athlète expérimenté ou une personne âgée souffrant de douleurs chroniques, Move IT vous accompagne de manière unique et adaptée. De plus, en effectuant toutes les analyses localement, nous garantissons qu'aucune donnée sensible ne quitte votre appareil. Move IT est conçu pour être utilisé par tous, quels que soient vos compétences techniques ou votre profil.
### Étapes futures
Nous avons de grandes ambitions pour Move IT. Nous prévoyons d'intégrer un mode chat pour une expérience encore plus naturelle, d'affiner nos recommandations grâce à des données enrichies et de conduire des tests approfondis pour garantir les meilleures performances. Notre objectif est de faire de Move IT votre compagnon santé incontournable.
### Conclusion
Avec Move IT, nous avons à cœur d'améliorer votre bien-être au quotidien. Plus qu'une simple application, Move IT est un véritable partenaire pour votre santé. Rejoignez-nous dans cette révolution et découvrez dès maintenant comment Move IT peut vous aider à soulager vos douleurs. Votre corps vous remerciera.
Merci de votre attention.




## Roadmap
### En Revue
- En attente de révision par l'équipe

### Planifié
- Implémentation du mode chat
- Amélioration de l'interface utilisateur

### En cours
- Développement du script d'analyse de texte

### Implémenté
- Création de données fonctionnelles et valides
- Base de l'interface avec:
  - gestion des comptes
  - Mode Schéma
  - Mode "case à cocher"

## Présentation brève
Ce projet a été réalisé durant les InnoWeeks 2024 à l'[ETML](https://www.etml.ch) par le groupe n°23. Il s'agit d'un assistant médical qui extrait les informations importantes d'un texte en entrée et qui répond en fournissant des conseils ou des suppositions.

## Présentation complète
Ce projet est une application Windows programmée en C# avec l'utilisation de Windows Forms pour l'interface graphique. L'application fonctionne uniquement en local pour le moment. Elle a pour but de proposer à l'utilisateur des remèdes et/ou des exercices physiques pour soulager une douleur corporelle. Pour permettre d'afficher des conseils personnalisés à l'utilisateur, il existe actuellement deux modes d'entrée d'informations :
- **Mode Schématique** : Cliquer sur la partie du corps où vous avez mal.
- **Mode "case à cocher"** : Cocher les cases correspondant à la partie du corps où vous avez mal.
- ~~**Mode Chat** :~~ (sera ajouté peut-être plus tard)

## Exemple d'utilisation
### Création d'un compte
Explication sur comment créer un compte dans l'application.

### Modification du compte
Guide pour modifier les informations de son compte.

### Recherche d'informations grâce au schéma
Instructions pour utiliser le mode schématique pour rechercher des informations.

~~### Recherche d'informations grâce au mode chat~~
(Sera ajouté dans l'application peut-être plus tard)

## Fonctionnalités
- Identification des douleurs corporelles
- Suggestions de remèdes et exercices physiques
- Interface utilisateur intuitive et interactive
- Fonctionnement local pour la confidentialité des données

## Prérequis
- Windows 10 ou plus récent
- .NET Framework 4.7.2 ou supérieur

## Installation
1. Télécharger le fichier d'installation depuis le dépôt.
2. Exécuter le fichier d'installation et suivre les instructions à l'écran.

## Utilisation
1. Lancer l'application.
2. Créer un compte ou se connecter.
3. Utiliser les modes d'entrée pour identifier la douleur.
4. Recevoir des conseils personnalisés.

## Avertissement
Move IT est une application qui fournit des conseils généraux pour soulager les douleurs corporelles courantes. Cependant, il est essentiel de noter que les informations proposées ne remplacent en aucun cas l'avis d'un professionnel de santé. Si vous souffrez d'une maladie grave, d'un problème cardiovasculaire, d'un handicap ou de toute autre condition médicale sérieuse, veuillez consulter votre médecin avant de suivre les conseils de l'application.
Les exercices physiques et les remèdes suggérés peuvent ne pas convenir à tous les utilisateurs. Il est donc fortement recommandé de vérifier auprès d'un spécialiste si les conseils prodigués sont adaptés à votre situation personnelle. Move IT décline toute responsabilité en cas de dommage ou de préjudice résultant de l'utilisation de l'application sans avis médical préalable.
Votre santé est notre priorité, mais la prudence reste de mise. Utilisez Move IT comme un outil complémentaire et non comme un substitut à un suivi médical approprié.

En utilisant l'application Move IT, vous acceptez les présentes [Conditions d'utilisation](./ConditionsUtilisation.md) et reconnaissez avoir lu et compris l'intégralité de leur contenu.

## Annexes
- [Conditions d'utilisation](./ConditionsUtilisation.md)

## Outils utilisés
- C#
- Windows Forms
- .NET Framework

## Licence
(Chez vous de choisir une licence appropriée, par exemple, MIT, GPL, etc.)
