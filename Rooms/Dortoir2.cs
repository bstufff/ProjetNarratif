﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjetNarratif.Rooms
{
    internal class Dortoir2 : Room
    {
        internal override string CreateDescription()
        {
            return @"Les occupants du dortoirs sont tous déjà partis, mais certains ont laissé leurs affaires dans la salle.
Il y a sur la droite les différents lits des passagers, et sur la gauche un couloir menant directement à l'infirmerie.";
        }
        internal override string CreateOptions() =>
@"[1] Fouiller la salle
[2] Partir vers l'infirmerie";
        internal override void ReceiveChoice(string choice)
        {
            switch (choice)
            {
                case "1":
                    if (!inventory.Contains(badge))
                    {
                        Console.WriteLine("Vous trouvez sous un lit un badge d'accès qui vous permettra d'aller dans des zones normalement réservées à l'équipage.");
                        badge.name = "Badge";
                        badge.id = 0;
                        badge.quantity = 1;
                        badge.description = "Un badge permettant d'accéder aux zones réservées à l'équipage.";
                        inventory.Add(badge);
                    }
                    else
                    {
                        Console.WriteLine("Vous ne trouvez rien de plus dans la salle.");
                    }
                    break;
                case "2":
                    Console.WriteLine("Vous prenez le couloir et entrez dans l'infirmerie.");
                    Game.Transition<Infirmerie1>();
                    break;
                default:
                    Console.WriteLine("Commande invalide.");
                    break;
            }
        }
    }
}
