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
Vous pouvez éteindre les lumières et essayer de les attaquer par derrière, ou bien fuir vers la salle de communications.";
        }
        internal override string CreateOptions() =>
@"[1] Éteindre les lumières
[2] Fuir";
        internal override void ReceiveChoice(string choice)
        {
            switch (choice)
            {
                case "1":
                    Console.WriteLine(@"Vous éteignez les lumières et prenez les pirates par derrière.
L'un a un bras bionique, et l'autre a l'air très résistant.");
                    Enemy pirate, pirate2;
                    pirate.pv = 25;
                    pirate.maxpv = 25;
                    pirate.dmg = 35;
                    pirate.name = "pirate bionique";
                    pirate2.pv = 75;
                    pirate2.maxpv = 75;
                    pirate2.dmg = 15;
                    pirate2.name = "pirate résistant";
                    Enemy[] enemies = { pirate,pirate2};
                    if (Combat(true, health, dmg, speed, enemies) == true)
                    {
                        Console.WriteLine("Vous avez réussi à éliminer les deux pirates, et maintenant vous vous dirigez vers la salle des machines.");
                        Game.Transition<Engine1>();
                    }
                    else { Game.Transition<Menu>(); }
                    break;
                case "2":
                    Console.WriteLine("Vous décidez de passer par la salle des communications.");
                    Game.Transition<Communications2>();
                    break;
                default:
                    Console.WriteLine("Commande invalide.");
                    break;
            }
        }
    }
}
