using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace MoveIT
{
    public class Model
    {
        public Controller Controller { get; set; }

        List<User> Users { get; set; }

        /// <summary>
        /// Stocke les données de l'utilisateur dans un fichier texte
        /// </summary>
        public void InsertIntoDB(User currentUser)
        {
            string connStr = "server=localhost;user=root;database=moveit;port=3306;password=root";
            using (MySqlConnection conn = new MySqlConnection(connStr))
            {
                try
                {
                    conn.Open();

                    string sql = "INSERT INTO t_user (Mail, Name, Password, Age, Height, Weight, Sex) " +
                                 "VALUES(@Mail, @Name, @Password, @Age, @Height, @Weight, @Sex)";

                    using (MySqlCommand cmd = new MySqlCommand(sql, conn))
                    {
                        cmd.Parameters.AddWithValue("@Mail", currentUser.Mail);
                        cmd.Parameters.AddWithValue("@Name", currentUser.Name);
                        cmd.Parameters.AddWithValue("@Password", currentUser.Password);
                        cmd.Parameters.AddWithValue("@Age", currentUser.Age);
                        cmd.Parameters.AddWithValue("@Height", currentUser.Height);
                        cmd.Parameters.AddWithValue("@Weight", currentUser.Weight);
                        cmd.Parameters.AddWithValue("@Sex", currentUser.Sex);

                        cmd.ExecuteNonQuery();
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.ToString());
                }
            }
        }

        public List<User> ListUsers()
        {
            List<User> users = new List<User>();

            string connStr = "server=localhost;user=root;database=moveit;port=3306;password=root";

            using (MySqlConnection conn = new MySqlConnection(connStr))
            {
                try
                {
                    conn.Open();
                    string sql = "SELECT Mail, Name, Password, Age, Height, Weight, Sex FROM t_user";

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
                                    Age = Convert.ToInt32(rdr["Age"]),
                                    Height = Convert.ToInt32(rdr["Height"]),
                                    Weight = Convert.ToInt32(rdr["Weight"]),
                                    Sex = rdr["Sex"].ToString()
                                };

                                users.Add(user);
                            }
                        }
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.ToString());
                }
            }

            return users;
        }

        /// <summary>
        /// Supprime l'utilisateur
        /// </summary>
        /// <param name="user">Utilisateur actuel</param>
        public void DeleteFromDB(User user)
        {
            string connStr = "server=localhost;user=root;database=moveit;port=3306;password=root";

            string deleteQuery = "DELETE FROM Users WHERE Mail = @Mail";

            // Utilisation d'une connexion à la base de données
            using (SqlConnection connection = new SqlConnection(connStr))
            {
                try
                {
                    // Ouvre la connexion
                    connection.Open();

                    // Prépare la commande SQL avec la requête et la connexion
                    using (SqlCommand command = new SqlCommand(deleteQuery, connection))
                    {
                        // Ajoute les paramètres à la commande
                        command.Parameters.AddWithValue("@Mail", user.Mail);

                        // Exécute la commande
                        int rowsAffected = command.ExecuteNonQuery();

                        // Vérifie si une ligne a été affectée (suppression réussie)
                        if (rowsAffected > 0)
                        {
                            MessageBox.Show("Utilisateur supprimé de la base de données", "Succès", MessageBoxButtons.OK);
                        }
                        else
                        {
                            MessageBox.Show("Utilisateur non trouvé dans la base de données", "Erreur", MessageBoxButtons.OK);
                        }
                    }
                }
                catch (Exception ex)
                {
                    // Gère les exceptions éventuelles
                    MessageBox.Show($"Erreur lors de la suppression de l'utilisateur : {ex.Message}", "Erreur", MessageBoxButtons.OK);
                }
            }
        }
    }
}
