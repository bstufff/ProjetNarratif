using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjetNarratif.Rooms
{
    internal class Options:Room
    {
        internal override string CreateDescription()
        {
            return @"Bienvenue dans les options.
Vous pouvez ajuster la vitesse des combats [1]
ou quitter [2].";
        }
        internal override void ReceiveChoice(string choice)
        {
            switch (choice)
            {
                case "1":
                    entry: Console.WriteLine("Vitesse actuelle : {0} secondes",speed);
                    Console.Write("Vitesse désirée : ");
                    try {speed = Convert.ToByte(Console.ReadLine()); }
                    catch { Console.WriteLine("Cette valeur est invalide. La vitesse peut être entre 0 et 255, et ne peut pas avoir de virgule."); goto entry; }
                    Console.WriteLine("La vitesse est maintenant de {0} secondes", speed);
                    break;
                case "2":
                    Game.Transition<Menu>();
                    break;
            }
        }
    }
}
