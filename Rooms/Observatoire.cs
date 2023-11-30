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
Tout au fond, vous apercevez une porte qui mène probablement à la serre du vaisseau.
Vous pouvez aussi fouiller la salle ou juste profiter de la vue.";
        }
        internal override string CreateOptions() =>
@"[1] Partir vers la serre
[2] Fouiller la salle
[3] Profiter de la vue";
        internal override void ReceiveChoice(string choice)
        {
            switch (choice)
            {
                case "1":
                    Console.WriteLine("Vous traversez la salle pour atteindre la porte de la serre, que vous arrivez à ouvrir ");
                    Game.Transition<Serre>();
                    break;
                case "2":
                    if (!inventory.Contains(briquet))
                    {
                        Console.WriteLine("Vous trouvez un briquet sous un siège.");

                        inventory.Add(briquet);
                    }
                    else
                    {
                        Console.WriteLine("Vous ne trouvez rien de plus dans la salle.");
                    }
                    
                    break;
                case "3":
                    Console.WriteLine(@"Pendant quelques instants, vous observez le panorama incroyable sous vos yeux. 
Vous remarquez un avis destiné à l'équipage derrière une porte :
                    AVIS
Le code de la salle des communications a été changé. 
    La bonne combinaison est maintenant 3952.");
                    break;
                default:
                    Console.WriteLine("Commande invalide.");
                    break;
            }
        }
    }
}
