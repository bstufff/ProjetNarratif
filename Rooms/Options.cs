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
Vous pouvez ajuster la vitesse des combats, plus précisément la limite de temps pour attaquer ou esquiver, ou retourner au menu.";
        }
        internal override string CreateOptions() =>
@"[1] Changer la vitesse
[2] Retour au menu";
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
                    Game.Transition<Menu>();
                    break;
                case "2":
                    Game.Transition<Menu>();
                    break;
            }
        }
    }
}
