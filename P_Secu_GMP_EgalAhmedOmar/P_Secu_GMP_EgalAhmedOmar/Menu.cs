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
    internal class Menu
    {
        // Création d'une instance de la classe Authentication
        public Authentication A = new Authentication();
        string path = @"d:\MDP";
        string pathSpe = $@"d:\MDP\test.txt";// chemin du répertoire à manipuler



        /// <summary>
        /// 
        /// </summary>
        public Menu()
        {
            //Vérifie que lw fichier soit créer
            try
            {
                if (File.Exists(pathSpe))
                {
                    Console.WriteLine("Ce fichier existe déjà");
                    return;
                }
                using (FileStream fs = File.Create(pathSpe))
                {
                    byte[] info = new UTF8Encoding(true).GetBytes("");
                    fs.Write(info, 0, info.Length);
                }
            }
            catch(Exception e)
            {
                Console.WriteLine("The process failed: {0}", e.ToString());
            }


            //Vérifie qûe le dossier soit créer.
            try
            {
                // Determine whether the directory exists.
                if (Directory.Exists(path))
                {
                    Console.WriteLine("That path exists already.");
                    return;
                }

                // Try to create the directory.
                DirectoryInfo di = Directory.CreateDirectory(path);
                Console.WriteLine("The directory was created successfully at {0}.", Directory.GetCreationTime(path));

            }
            catch (Exception e)
            {
                Console.WriteLine("The process failed: {0}", e.ToString());
            }
            
        }
        
        
        
        /// <summary>
        /// Méthode principale pour afficher et gérer le menu principal
        /// </summary>
        public void DrawMainMenu()
        {
            string choice;
            do
            {
                Console.Clear();
                Console.WriteLine("******************************************************************");
                Console.WriteLine("Sélectionnez une action");
                Console.WriteLine("1. Consulter un mot de passe");
                Console.WriteLine("2. Ajouter un mot de passe");
                Console.WriteLine("3. Supprimer un mot de passe");
                Console.WriteLine("4. Quitter le programme");
                Console.WriteLine("******************************************************************");
                Console.WriteLine("Faites votre choix : ");

                choice = Console.ReadLine();

                switch (choice)
                {   // Afficher le sous-menu pour consulter un mot de passe
                    case "1":

                        DrawPasswordMenu();
                        break;
                    // Appeler la méthode pour ajouter un mot de passe et l'ajouter à la liste
                    case "2":

                        A.AddAuthentification();
                        //authenticationsList.Add(A.AddAuthentification());
                        break;
                    // Appeler la méthode pour supprimer un mot de passe et le retirer de la liste
                    case "3":
                        A.RemoveAutehntification();
                        //authenticationsList.RemoveAt(A.RemoveAutehntification());
                        break;
                    // Quitter le programme
                    case "4":
                        Environment.Exit(0);
                        break;
                    default:
                        Console.WriteLine("Choix invalide, veuillez réessayer.");
                        break;
                }
            } while (choice != "4");
        }
        /// <summary>
        /// Méthode pour afficher et gérer le sous-menu pour consulter un mot de passe
        /// </summary>
        private void DrawPasswordMenu()
        {

            string choice;
            string line;
            int i = 0;
            int j = 1;


                Console.Clear();
                Console.WriteLine("******************************************************************");
                Console.WriteLine("Consulter un mot de passe");
                Console.WriteLine("1. Retour au menu principal");

            do{ 
                    //Ouvre un lecteur pour lire le fichier txt
                    using ( StreamReader sr = new StreamReader(pathSpe))
                     {
                        try
                        {
                            //Vérifie si le fichier n'existe pas 
                            if (!File.Exists(pathSpe))
                            {
                                Console.WriteLine("Le fichier n'a pas été trouvé !");
                            }

                            //TODO: créer un modulo 3 pour récuper seulemt le nom du site et ensuite les récupérer pour les voir ou les modifier.
                        


                            // Read and display lines from the file until the end of
                            // the file is reached.
                            while ((line = sr.ReadLine()) != null)
                            {

                                if(i % 3== 0)
                                {
                                    //
                                    j++;

                                    //
                                    Console.WriteLine($"{j}. {A.DeceasarAlgo(line)}");

                                }

                                i++;
                            }
                        
                        }
                        catch (Exception e)
                        {
                            Console.WriteLine("The process failed: {0}", e.ToString());
                        }

                    }
                    Console.WriteLine("******************************************************************");
                    Console.WriteLine("Faites votre choix : ");

                    choice = Console.ReadLine();


                    if(choice == "1" )
                    {
                        return;
                    }


                switch (choice)
                {
                    case "1":
                        // Retourner au menu principal
                        return;
                    default:
                            DrawPasswordMenuWith(choice);
                        //Console.WriteLine("Choix invalide, veuillez réessayer.");
                        break;
                }
             } while (choice != "1");
        }



        private void DrawPasswordMenuWith(string num)
        {

            
            string line;
            int count = 0;
            int Rightindex = (Convert.ToInt32(num )-1);

            Console.Clear();
            Console.WriteLine("******************************************************************");
            Console.WriteLine("1. Retour au menu principal");

            //Ouvre un lecteur pour lire le fichier txt
            using (StreamReader sr = new StreamReader(pathSpe))
            {
                try
                {
                    //Vérifie si le fichier n'existe pas 
                    if (!File.Exists(pathSpe))
                    {
                        Console.WriteLine("Le fichier n'a pas été trouvé !");
                    }

                    //TODO: créer un modulo 3 pour récuper seulemt le nom du site et ensuite les récupérer pour les voir ou les modifier.

                    // Read and display lines from the file until the end of
                    // the file is reached.
                    if(Rightindex == 1)
                    {
                        while ((line = sr.ReadLine()) != null )
                        {

                            if (Rightindex *3  +1 >= count - 1 || count !> (Rightindex * 3 + 1) + 2)
                            {
                                Console.WriteLine($"{A.DeceasarAlgo(line)}");

                            }

                            count++;
                        }
                    }
                    else
                    {
                        while ((line = sr.ReadLine()) != null || count > (Rightindex + 2))
                        {

                            if (Rightindex >= count - 1)
                            {
                                Console.WriteLine($"{A.DeceasarAlgo(line)}");

                            }

                            count++;
                        }
                    }
                }
                catch (Exception e)
                {
                    Console.WriteLine("The process failed: {0}", e.ToString());
                }
            }
        }
    }
}
