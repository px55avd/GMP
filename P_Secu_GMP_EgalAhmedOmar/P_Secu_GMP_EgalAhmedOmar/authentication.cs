///**************************************************************************************
///ETML
///Auteur : Omar Egal Ahmed
///Date : 19.03.2024
///Description : Création d'un programme de type gestionnaire de mots de passes 
///**************************************************************************************
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace P_Secu_GMP_EgalAhmedOmar
{
    internal class Authentication
    {
        // Propriétés pour les informations d'authentification TODO faire les privates et apres les get set
        public string Password { get; set; }
        public string Username { get; set; }
        public string Website { get; set; }

        // Déclaration d'une liste pour stocker les authentifications
        private List<Authentication> _authenticationsList = new List<Authentication>();

        private const string _fileName = "test.txt";

        string path = $@"E:\MDP\test.txt";

        public Authentication()
        {

        }


        /// <summary>
        ///  Ajoute une nouvelle authentification enregistrée dans un fichier texte.
        /// </summary>
        public void AddAuthentification()
        {


            Authentication authentication = new Authentication(); // Crée une nouvelle instance d'authentification

            // Demande à l'utilisateur d'entrer les informations d'authentification
            Console.WriteLine("Veuillez entrer l'URL du site à ajouter :");
            authentication.Website = Console.ReadLine();

            Console.WriteLine("Veuillez entrer le login du site à ajouter :");
            authentication.Username = Console.ReadLine();

            Console.WriteLine("Veuillez entrer le mot de passe du site à ajouter :");
            authentication.Password = Console.ReadLine();


            try
            {
                // Instancie un StreamWriter pour créer un fichier texte avec le chemin pour stocker les informations d'authentification s'il n'existe pas.
                StreamWriter sr = new StreamWriter(path, true);

                //Ecrire les informations dans le fichier texte TODO: y implémenter l'encrypatage
                sr.WriteLine(ceasarAlgo(authentication.Website));

                sr.WriteLine(ceasarAlgo(authentication.Username));

                sr.WriteLine(ceasarAlgo(authentication.Password));

                sr.Close(); // Ferme le flux de sortie
            }
            catch (Exception e)
            {
                // Gère les exceptions et affiche le message d'erreur
                Console.WriteLine("Exception: " + e.Message);
            }
            finally
            {
                Console.WriteLine("Executing finally block."); // Affiche un message après l'exécution de la section try-catch
            }

            _authenticationsList.Add(authentication); // ajout dans la list 
        }

        /// <summary>
        /// Demande à l'utilisateur le numéro du site à supprimer et retourne cet index.
        /// </summary>
        /// <returns></returns>
        public int RemoveAutehntification()
        {
            Console.WriteLine("Veuillez entrer le numéro du site à supprimer :");
            int websiteNumber = Convert.ToInt32(Console.ReadLine()) - 1;// Soustrait 1 pour correspondre à l'index dans la liste

            //TODO finir d'implémenter la supression de d'indentifiant avec les lignes dans les fichier .txt et plus dans la liste.

            return websiteNumber;
        }

        /// <summary>
        /// Méthode pour ajouter un mot de passe (non implémentée).
        /// </summary>
        /// <param name="addPassword">Mot de passe à ajouter</param>
        public int ChangePassword(string addPassword)
        {
            Console.WriteLine("Veuillez entrer le numéro du site à supprimer :");
            int websiteNumber = Convert.ToInt32(Console.ReadLine()) - 1;// Soustrait 1 pour correspondre à l'index dans la liste

            return websiteNumber;

            // TODO: Ajouter le mot de passes 
        }

        /// <summary>
        /// Méthode pour supprimer un mot de passe (non implémentée).
        /// </summary>
        /// <param name="removePassword">Mot de passe à supprimer</param>
        public void RemovePassword(string removePassword)
        {
            string password = "";

            Console.WriteLine("Veuillez entrer le mot de passe du site à supprimer :");

            password = Console.ReadLine();

            password = removePassword;

            //TODO: supprimer le mots de passe du fichier txt contenant les infos

        }
        /// <summary>
        /// Méthode pour effectuer l'algorithme de César pour chiffrer le login et le mot de passe.
        /// </summary>
        /// <param name="info">Information à chiffrer</param>
        /// <returns>Information chiffrée</returns>
        public string ceasarAlgo(string info)
        {
            //numéro de décalage
            int shift = 2;

            char[] encrypted = new char[info.Length];

            for (int i = 0; i < info.Length; i++)
            {
                char c = info[i];
                int asciiValue = (int)c;

                // Vérifier si le caractère est dans la plage des caractères imprimables
                if (asciiValue >= 32 && asciiValue <= 126)
                {
                    // Appliquer le décalage de César
                    int newAsciiValue = asciiValue + shift;

                    // Gestion du dépassement de la plage des caractères imprimables
                    if (newAsciiValue > 126)
                    {
                        newAsciiValue = 32 + (newAsciiValue - 127);
                    }
                    else if (newAsciiValue < 32)
                    {
                        newAsciiValue = 127 - (32 - newAsciiValue);
                    }

                    encrypted[i] = (char)newAsciiValue;
                }
                else
                {
                    // Si ce n'est pas un caractère imprimable, ne pas le modifier
                    encrypted[i] = c;
                }
            }

            return new string(encrypted);
        }


        public string DeceasarAlgo(string info)
        {
            //numéro de décalage
            int shift = 2;

            char[] encrypted = new char[info.Length];

            for (int i = 0; i < info.Length; i++)
            {
                char c = info[i];
                int asciiValue = (int)c;

                // Vérifier si le caractère est dans la plage des caractères imprimables
                if (asciiValue >= 32 && asciiValue <= 126)
                {
                    // Appliquer le décalage de César
                    int newAsciiValue = asciiValue - shift;

                    // Gestion du dépassement de la plage des caractères imprimables
                    if (newAsciiValue > 126)
                    {
                        newAsciiValue = 32 + (newAsciiValue - 127);
                    }
                    else if (newAsciiValue < 32)
                    {
                        newAsciiValue = 127 - (32 - newAsciiValue);
                    }

                    encrypted[i] = (char)newAsciiValue;
                }
                else
                {
                    // Si ce n'est pas un caractère imprimable, ne pas le modifier
                    encrypted[i] = c;
                }
            }

            return new string(encrypted);
        }
    }
}
