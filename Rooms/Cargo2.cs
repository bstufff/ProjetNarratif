using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjetNarratif.Rooms
{
    internal class Cargo2:Room
    {
        internal override string CreateDescription()
        {
            return @"Vous arrivez dans la salle de stockage. Des pirates ont dû passer par là, 
car des caisses sont éparpillées un peu partout, dont une qui est déjà ouverte, ou vous diriger vers le cockpit [3] pour trouver le capitaine des pirates.";
        }
        internal override string CreateOptions() =>
@"[1] Fouiller dans la caisse ouverte
[2] Fouiller le reste de la pièce
[3] Aller vers le cockpit";
        internal override void ReceiveChoice(string choice)
        {
            switch (choice)
            {
                case "1":
                    if (!inventory.Contains(fusil))
                    {
                        Console.WriteLine("Vous trouvez un fusil dans la caisse.");
                        inventory.Add(fusil);
                    }
                    else {
                        Console.WriteLine("Vous ne trouvez rien d'utile dans la caisse.");
                    }
                    break;
                case "2":
                    if (!inventory.Contains(adrénaline))
                    {
                        Console.WriteLine("Vous ouvrez une autre caisse et y trouvez une seringue d'adrénaline.");
                        inventory.Add(adrénaline);
                    }
                    else
                    {
                        Console.WriteLine("Vous ne trouvez rien d'utile dans la caisse.");
                    }
                    break;
                case "3":
                    Console.WriteLine("Vous traversez la salle et arrivez devant le cockpit.");
                    Game.Transition<Cockpit>();
                    break;
                default:
                    Console.WriteLine("Commande invalide.");
                    break;

            }
        }
    }
}
