using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace MoveIT
{
    public class Model
    {
        public Controller Controller { get; set; }

        // Connexion à la base de données MySQL
        private string connStr = "server=localhost;user=root;database=moveit;port=3306;password=root";

        public Dictionary<string, string> PartBodyAndMessage { get; set; }

        public Model()
        {
            PartBodyAndMessage = new Dictionary<string, string>
            {
                // Tête
                {"tête", "Soyez plus précis (cou, crâne, front, gorge, nuque, tempes)" },
                {"cou", "Massez doucement votre cou pour détendre les muscles\nFaites des étirements pour soulager la tension\nAppliquez une compresse chaude si nécessaire" },
                {"crâne", "Massez doucement votre crâne pour apaiser la tension\nPratiquez des exercices de relaxation\nUtilisez une compresse froide pour soulager les maux de tête" },
                {"front", "Reposez-vous et dormez un peu\nAppliquez une compresse froide sur votre front\nPratiquez des exercices de respiration pour vous détendre" },
                {"gorge", "Prenez un Doliprane pour soulager la douleur\nBuvez des tisanes chaudes avec du miel\nGargarisez-vous avec de l'eau salée" },
                {"nuque", "Massez votre nuque pour détendre les muscles\nFaites des étirements de la nuque\nUtilisez une compresse chaude pour apaiser la douleur" },
                {"tempes", "Relaxez-vous et évitez de trop réfléchir\nMassez doucement vos tempes\nUtilisez des techniques de méditation pour vous détendre" },

                // Visage
                {"visage", "Soyez plus précis (bouche, joues, mâchoire, nez, oreilles, yeux)" },
                {"bouche", "Évitez de parler trop pour reposer votre bouche\nFaites des exercices de relaxation de la mâchoire\nBuvez de l'eau froide pour soulager la douleur" },
                {"joues", "Réduisez l'intensité de votre rire pour éviter les tensions\nMassez doucement vos joues\nPratiquez des exercices de relaxation faciale" },
                {"mâchoire", "Détendez votre mâchoire et faites des étirements\nÉvitez de mâcher des aliments durs\nAppliquez une compresse chaude pour soulager la tension" },
                {"nez", "Mouchez-vous pour vous sentir mieux\nUtilisez un spray nasal si nécessaire\nFaites des inhalations de vapeur pour dégager vos voies nasales" },
                {"oreilles", "Faites des rotations de cheville pour vous distraire\nÉvitez les bruits forts\nUtilisez des bouchons d'oreilles si nécessaire" },
                {"yeux", "Reposez vos yeux en fermant les paupières quelques minutes\nUtilisez des gouttes ophtalmiques si nécessaire\nÉvitez les écrans pour réduire la fatigue oculaire" },

                // Tronc
                {"tronc", "Soyez plus précis (abdomen, bassin, clavicule, colonne, côtes, dos, fessier, pelvis, poitrine, trapèzes)" },
                {"abdomen", "Faites des exercices doux pour votre abdomen\nMassez doucement votre ventre\nBuvez beaucoup d'eau pour faciliter la digestion" },
                {"bassin", "Étirez doucement votre bassin\nFaites des exercices de renforcement des hanches\nUtilisez une compresse chaude pour apaiser la douleur" },
                {"clavicule", "Massez doucement votre clavicule pour détendre les muscles\nÉvitez les mouvements brusques\nAppliquez une compresse chaude si nécessaire" },
                {"colonne", "Faites des étirements pour votre colonne vertébrale\nUtilisez un coussin lombaire\nMaintenez une bonne posture" },
                {"côtes", "Évitez les mouvements brusques\nUtilisez une compresse froide pour réduire la douleur\nConsultez un médecin si la douleur persiste" },
                {"dos", "Massez votre dos ou utilisez un rouleau de massage\nFaites des étirements du dos comme le cat-cow\nAppliquez une compresse chaude pour détendre les muscles" },
                {"fessier", "Faites des squats pour renforcer vos fessiers\nPratiquez des étirements comme le fessier stretch\nÉvitez de rester assis trop longtemps" },
                {"pelvis", "Faites des étirements doux pour votre pelvis\nPratiquez des exercices de renforcement pour les hanches\nUtilisez une compresse chaude pour soulager la douleur" },
                {"poitrine", "Faites des exercices de respiration profonde\nMassez doucement votre poitrine\nReposez-vous et évitez les efforts intenses" },
                {"trapèzes", "Faites des étirements pour soulager la tension\nMassez vos trapèzes\nUtilisez une compresse chaude" },

                // Jambes
                {"jambes", "Soyez plus précis (chevilles, cuisse, genoux, mollets, pieds, quadriceps, talons, tibias)" },
                {"chevilles", "Faites des rotations de cheville pour l'assouplir\nAppliquez une compresse froide pour réduire l'enflure\nÉvitez de trop solliciter votre cheville" },
                {"cuisse", "Faites des squats pour renforcer vos cuisses\nEssayez des étirements comme le quadriceps stretch\nFaites du vélo pour travailler vos cuisses sans trop de pression" },
                {"genoux", "Essayez des exercices de Nordic curl ou de pistol squat\nUtilisez une genouillère pour maintenir le genou\nReposez-vous si vous ressentez une douleur intense" },
                {"mollets", "Massez votre mollet pour soulager la tension\nFaites des étirements de mollet comme le calf stretch\nAppliquez de la glace pour réduire l'inflammation" },
                {"pieds", "Massez vos pieds pour soulager la fatigue\nFaites des étirements pour les pieds\nPortez des chaussures confortables" },
                {"quadriceps", "Faites des squats pour renforcer vos quadriceps\nEssayez des étirements pour les quadriceps\nFaites du vélo pour travailler vos quadriceps sans trop de pression" },
                {"talons", "Ne forcez pas trop dessus, reposez-vous si nécessaire\nUtilisez une talonnette pour absorber les chocs\nFaites des étirements du tendon d'Achille" },
                {"tibias", "Massez vos tibias pour soulager la douleur\nFaites des étirements pour les tibias\nAppliquez une compresse froide pour réduire l'inflammation" },

                // Bras
                {"bras", "Soyez plus précis (avant-bras, biceps, coudes, épaules, mains, paumes, poignet, triceps)" },
                {"avant-bras", "Faites des étirements pour vos avant-bras\nUtilisez un rouleau de massage pour détendre les muscles\nAppliquez une compresse chaude pour soulager la douleur" },
                {"biceps", "Faites des exercices de renforcement pour les biceps\nMassez vos biceps après l'exercice\nFaites des étirements pour éviter les courbatures" },
                {"coudes", "Patience et évitez les mouvements brusques\nUtilisez une bande de compression\nFaites des exercices de renforcement des muscles du bras" },
                {"épaules", "Massez vos épaules pour détendre les muscles\nFaites des étirements comme le shoulder stretch\nUtilisez une compresse chaude pour apaiser la douleur" },
                {"mains", "Faites des exercices de flexion et d'extension des doigts\nUtilisez une balle anti-stress pour renforcer les muscles\nMassez vos mains avec une lotion apaisante" },
                {"paumes", "Un bisou magique pour votre paume\nFaites des exercices de flexion et d'extension de la paume\nMassez doucement votre paume avec une lotion apaisante" },
                {"poignet", "Faites des rotations de poignet pour soulager la douleur\nUtilisez une attelle de poignet si nécessaire\nFaites des étirements des fléchisseurs et extenseurs" },
                {"triceps", "Faites des exercices de renforcement pour les triceps\nMassez vos triceps après l'exercice\nFaites des étirements pour éviter les courbatures" }
            };
        }

        /// <summary>
        /// Insère les données de l'utilisateur dans la base de données
        /// </summary>
        public void InsertIntoDB(User currentUser)
        {
            using (MySqlConnection conn = new MySqlConnection(connStr))
            {
                try
                {
                    conn.Open();

                    string sql = "INSERT INTO t_user (Mail, Name, Password, BirthDate, Height, Weight, Sex) " +
                                 "VALUES(@Mail, @Name, @Password, @BirthDate, @Height, @Weight, @Sex)";

                    using (MySqlCommand cmd = new MySqlCommand(sql, conn))
                    {
                        cmd.Parameters.AddWithValue("@Mail", currentUser.Mail);
                        cmd.Parameters.AddWithValue("@Name", currentUser.Name);
                        cmd.Parameters.AddWithValue("@Password", currentUser.Password);
                        cmd.Parameters.AddWithValue("@BirthDate", currentUser.BirthDate);
                        cmd.Parameters.AddWithValue("@Height", currentUser.Height);
                        cmd.Parameters.AddWithValue("@Weight", currentUser.Weight);
                        cmd.Parameters.AddWithValue("@Sex", currentUser.Sex);

                        cmd.ExecuteNonQuery();

                        MessageBox.Show("Le nouveau compte a été créé", "Réussite", MessageBoxButtons.OK);
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Erreur lors de l'insertion de l'utilisateur dans la base de données : {ex.Message}", "Erreur", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }


        /// <summary>
        /// Récupère la liste des utilisateurs de la base de données
        /// </summary>
        public List<User> ListUsers()
        {
            List<User> users = new List<User>();

            using (MySqlConnection conn = new MySqlConnection(connStr))
            {
                try
                {
                    conn.Open();
                    string sql = "SELECT Mail, Name, Password, BirthDate, Height, Weight, Sex FROM t_user";

                    using (MySqlCommand cmd = new MySqlCommand(sql, conn))
                    {
                        using (MySqlDataReader rdr = cmd.ExecuteReader())
                        {
                            while (rdr.Read())
                            {
                                User user = new User
                                {
                                    Mail = rdr["Mail"].ToString(),
                                    Name = rdr["Name"].ToString(),
                                    Password = rdr["Password"].ToString(),
                                    BirthDate = Convert.ToDateTime(rdr["BirthDate"]),
                                    Height = Convert.ToInt32(rdr["Height"]),
                                    Weight = Convert.ToDouble(rdr["Weight"]),
                                    Sex = rdr["Sex"].ToString(),
                                };

                                user.Age = Controller.CalculateAge(user.BirthDate);
                                Controller.Age = user.Age.ToString();

                                users.Add(user);
                            }
                        }
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Erreur lors de la récupération des utilisateurs de la base de données : {ex.Message}", "Erreur", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }

            return users;
        }


        /// <summary>
        /// Met à jour les informations de l'utilisateur dans la base de données
        /// </summary>
        /// <param name="user">Utilisateur actuel</param>
        public void UpdateInDB(User user)
        {
            using (MySqlConnection conn = new MySqlConnection(connStr))
            {
                try
                {
                    conn.Open();

                    string sql = "UPDATE t_user SET Name = @Name, Password = @Password, BirthDate = @BirthDate, Height = @Height, Weight = @Weight, Sex = @Sex " +
                                 "WHERE Mail = @Mail";

                    using (MySqlCommand cmd = new MySqlCommand(sql, conn))
                    {
                        cmd.Parameters.AddWithValue("@Name", user.Name);
                        cmd.Parameters.AddWithValue("@Password", user.Password);
                        cmd.Parameters.AddWithValue("@BirthDate", user.BirthDate);
                        cmd.Parameters.AddWithValue("@Height", user.Height);
                        cmd.Parameters.AddWithValue("@Weight", user.Weight);
                        cmd.Parameters.AddWithValue("@Sex", user.Sex);
                        cmd.Parameters.AddWithValue("@Mail", user.Mail);

                        user.Age = Controller.CalculateAge(user.BirthDate);
                        Controller.Age = user.Age.ToString();

                        cmd.ExecuteNonQuery();
                    }

                    // Affichage d'un message de confirmation
                    MessageBox.Show("Les informations ont été modifiées avec succès.", "Modification réussie", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Erreur lors de la mise à jour de l'utilisateur dans la base de données : {ex.Message}", "Erreur", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }


        /// <summary>
        /// Supprime l'utilisateur de la base de données
        /// </summary>
        /// <param name="user">Utilisateur actuel</param>
        public void DeleteFromDB(User user)
        {
            string deleteUserQuery = "DELETE FROM t_user WHERE Mail = @Mail";
            string deleteWeightQuery = "DELETE FROM t_weight WHERE Mail = @Mail";

            using (MySqlConnection conn = new MySqlConnection(connStr))
            {
                try
                {
                    conn.Open();

                    // Commencez une transaction pour garantir l'intégrité des suppressions
                    using (MySqlTransaction transaction = conn.BeginTransaction())
                    {
                        try
                        {
                            // Supprimer les données de poids associées
                            using (MySqlCommand cmd = new MySqlCommand(deleteWeightQuery, conn, transaction))
                            {
                                cmd.Parameters.AddWithValue("@Mail", user.Mail);
                                cmd.ExecuteNonQuery();
                            }

                            // Supprimer l'utilisateur
                            using (MySqlCommand cmd = new MySqlCommand(deleteUserQuery, conn, transaction))
                            {
                                cmd.Parameters.AddWithValue("@Mail", user.Mail);
                                cmd.ExecuteNonQuery();
                            }

                            // Validez la transaction
                            transaction.Commit();

                            MessageBox.Show("L'utilisateur et ses données associées ont été supprimés avec succès.", "Suppression réussie", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        }
                        catch (Exception ex)
                        {
                            // Annulez la transaction en cas d'erreur
                            transaction.Rollback();

                            MessageBox.Show($"Erreur lors de la suppression de l'utilisateur de la base de données : {ex.Message}", "Erreur", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Erreur lors de la connexion à la base de données : {ex.Message}", "Erreur", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        public void AddWeightInDb(User currentUser)
        {
            using (MySqlConnection conn = new MySqlConnection(connStr))
            {
                try
                {
                    conn.Open();

                    // Vérifier si un poids existe déjà pour l'utilisateur aujourd'hui
                    string checkSql = "SELECT COUNT(*) FROM t_weight WHERE Date = @Date AND Mail = @Mail";
                    using (MySqlCommand checkCmd = new MySqlCommand(checkSql, conn))
                    {
                        checkCmd.Parameters.AddWithValue("@Date", DateTime.Today);
                        checkCmd.Parameters.AddWithValue("@Mail", currentUser.Mail); // Assurez-vous d'avoir l'ID de l'utilisateur ici

                        int count = Convert.ToInt32(checkCmd.ExecuteScalar());

                        if (count > 0)
                        {
                            // Demander à l'utilisateur s'il veut modifier le poids existant
                            DialogResult result = MessageBox.Show("Vous avez déjà ajouté un poids aujourd'hui. Voulez-vous le modifier?", "Modification de poids", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

                            if (result == DialogResult.Yes)
                            {
                                // S'il y a déjà un enregistrement, mettre à jour le poids existant
                                string updateSql = "UPDATE t_weight SET Weight = @Weight WHERE Date = @Date AND Mail = @Mail";
                                using (MySqlCommand updateCmd = new MySqlCommand(updateSql, conn))
                                {
                                    updateCmd.Parameters.AddWithValue("@Weight", currentUser.Weight);
                                    updateCmd.Parameters.AddWithValue("@Date", DateTime.Today);
                                    updateCmd.Parameters.AddWithValue("@Mail", currentUser.Mail);

                                    updateCmd.ExecuteNonQuery();

                                    MessageBox.Show("Le poids pour aujourd'hui a été mis à jour", "Réussite", MessageBoxButtons.OK);
                                }
                            }
                        }
                        else
                        {
                            // S'il n'y a pas d'enregistrement, insérer un nouveau poids
                            string insertSql = "INSERT INTO t_weight (Mail, Weight, Date) " +
                                               "VALUES(@Mail, @Weight, @Date)";
                            using (MySqlCommand insertCmd = new MySqlCommand(insertSql, conn))
                            {
                                insertCmd.Parameters.AddWithValue("@Mail", currentUser.Mail);
                                insertCmd.Parameters.AddWithValue("@Weight", currentUser.Weight);
                                insertCmd.Parameters.AddWithValue("@Date", DateTime.Today);

                                insertCmd.ExecuteNonQuery();

                                MessageBox.Show("Le poids pour aujourd'hui a été ajouté", "Réussite", MessageBoxButtons.OK);
                            }
                        }
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Erreur lors de l'interaction avec la base de données : {ex.Message}", "Erreur", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        public List<(DateTime Date, double Weight)> GetWeightsForUser(string mail)
        {
            List<(DateTime Date, double Weight)> weights = new List<(DateTime Date, double Weight)>();

            using (MySqlConnection conn = new MySqlConnection(connStr))
            {
                try
                {
                    conn.Open();

                    string sql = "SELECT Date, Weight FROM t_weight WHERE Mail = @Mail ORDER BY Date";
                    using (MySqlCommand cmd = new MySqlCommand(sql, conn))
                    {
                        cmd.Parameters.AddWithValue("@Mail", mail);

                        using (MySqlDataReader rdr = cmd.ExecuteReader())
                        {
                            while (rdr.Read())
                            {
                                DateTime date = rdr.GetDateTime("Date");
                                double weight = rdr.GetDouble("Weight");
                                weights.Add((date, weight));
                            }
                        }
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Erreur lors de la récupération des poids : {ex.Message}", "Erreur", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }

            return weights;
        }
    }
}
