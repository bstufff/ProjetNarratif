using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjetNarratif.Rooms
{
    internal class Observatoire : Room
    {
        internal override string CreateDescription()
        {
            return @"Vous arrivez dans l'observatoire. C'est une grande salle avec une énorme baie vitrée qui permet de voir facilement les astres autour du vaisseau.
Tout au fond, vous apercevez une porte [1] qui mène probablement à la serre du vaisseau.
Vous pouvez aussi fouiller la salle [2], ou profiter de la vue avant de continuer [2].";
        }
        internal override void ReceiveChoice(string choice)
        {
            switch (choice)
            {
                case "1":
                    Console.WriteLine("Vous traversez la salle pour atteindre la porte de la serre, que vous arrivez à ouvrir ");
                    Game.Transition<Serre>();
                    break;
                case "2":
                    Console.WriteLine("Vous trouvez un briquet sous un siège.");
                    briquet.name = "Briquet";
                    briquet.description = "Produit une flammèche.";
                    briquet.id = 3;
                    briquet.quantity = 1;
                    inventory.Add(briquet);
                    break;
                case "3":
                    Console.WriteLine(@"Pendant quelques instants, vous observez le panorama incroyable sous vos yeux. 
Vous remarquez un avis destiné à l'équipage derrière une porte :
                    AVIS
Le code de la salle de communications a été changé. 
    La bonne combinaison est maintenant 3952.");
                    break;
                default:
                    Console.WriteLine("Commande invalide.");
                    break;
            }
        }
    }
}
