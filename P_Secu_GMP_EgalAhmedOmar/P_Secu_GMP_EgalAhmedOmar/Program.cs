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

namespace P_Secu_GMP_EgalAhmedOmar
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Menu menu = new Menu();

            menu.DrawMainMenu();
        }
    }
}