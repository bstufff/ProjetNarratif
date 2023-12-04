using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjetNarratif.Rooms
{
    internal class Quai2:Room
    {
        internal override string CreateDescription()
        {
            return @"Vous arrivez devant le quai de lancement, où la dernière nacelle se prépare à partir.
Vous pouvez aussi rester et essayer de reprendre le vaisseau aux pirates, mais cela ne sera pas facile.";
        }
        internal override string CreateOptions() =>
            @"[1] Fuir le vaisseau
[2] Rester";
            
        internal override void ReceiveChoice(string choice)
        {
            switch (choice)
            {
                case "1":
                    Console.WriteLine(@"Vous réussissez à grimper dans la nacelle juste avant son départ, en sachant
très bien que tous ceux qui n'ont pas pu fuir finiront réduits à la servitude, voire exécutés. 
Vous auriez probablement pu les sauver, mais au moins vous êtes sain et sauf.


FIN 3");
                    Game.Finish();
                    break;
                case "2":
                    Console.WriteLine("Vous décidez de rester pour essayer de reprendre contrôle du vaisseau.");
                    Game.Transition<Quai3>();
                    break;
                default:
                    Console.WriteLine("Commande invalide.");
                    break;
            }
        }
    }
}
