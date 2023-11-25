using System;
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
Sur la droite [1], il y a les différents lits des passagers, et sur la gauche [2] il y a un couloir menant directement à l'infirmerie.";
        }
        internal override void ReceiveChoice(string choice)
        {
            switch (choice)
            {
                case "1":
                    Console.WriteLine("Vous trouvez sous un lit un badge d'accès qui vous permettra d'aller dans les salles normalement réservées à l'équipage.");
                    badge.name = "Badge";
                    badge.id = 0;
                    badge.quantity = 1;
                    badge.description = "Un badge permettant d'accéder aux zones réservées à l'équipage.";
                    inventory.Add(badge);
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
