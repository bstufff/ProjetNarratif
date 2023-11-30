using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjetNarratif.Rooms
{
    internal class Réfectoire2:Room
    {
        internal override string CreateDescription()
        {
            return @"Vous arrivez dans le réfectoire où vous voyez Mercurius avec un fusil laser capable de vous abbattre en quelques tirs.";
        }
        internal override string CreateOptions()
        {
            return "[1] Affronter Mercurius";
        }
        internal override void ReceiveChoice(string choice)
        {
            switch (choice) {
                case "1":
                    Enemy Mercurius;
                    Mercurius.pv = 100;
                    Mercurius.accuracy = 100;
                    Mercurius.maxpv = 100;
                    Mercurius.dmg = 40;
                    Mercurius.name = "Mercurius";
                    Enemy[] enemies = { Mercurius };
                    if (Combat(true, 100, dmg, speed, enemies) == true)
                    {
                        Console.WriteLine(@"Vous réussissez à reprendre contrôle du vaisseau et de sauver les passagers toujours présents.
Quelques jours après, vous atterrissez enfin sur votre planète, couvert d'honneur et de gratitude.

FIN 1");
                        Game.Finish();
                    }
                    break;
                default:
                    Console.WriteLine("Commande invalide.");
                    break;
            }
 
        }
    }
}
