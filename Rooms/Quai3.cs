using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjetNarratif.Rooms
{
    internal class Quai3:Room
    {
        internal override string CreateDescription()
        {
            return @"Vous entendez plus de pirates arriver de la serre. 
Vous pouvez éteindre les lumières [1] et essayer de les attaquer de derrière, ou bien fuir [2] vers la salle de communications.";
        }
        internal override void ReceiveChoice(string choice)
        {
            switch (choice)
            {
                case "1":
                    Console.WriteLine(@"Vous éteignez les lumières et prenez les pirates par derrière.
L'un a un bras bionique, et l'autre a l'air très résistant.");
                    Enemy pirate, pirate2;
                    pirate.pv = 25;
                    pirate.dmg = 15;
                    pirate.name = "pirate bionique";
                    pirate2.pv = 75;
                    pirate2.dmg = 5;
                    pirate2.name = "pirate résistant";
                    Enemy[] enemies = { pirate,pirate2};
                    if (Combat(true, 50, 15, 10, 3, enemies) == true)
                    {
                        Console.WriteLine("Vous réussissez à assommer les deux pirates, et vous vous dirigez vers la salle des machines.");
                    }
                    else { Game.Transition<Menu>(); }
                    break;
                case "2":
                    Console.WriteLine("Vous décidez de passer par la salle de communications.");
                    Game.Transition<Communications2>();
                    break;
                default:
                    Console.WriteLine("Commande invalide.");
                    break;
            }
        }
    }
}
