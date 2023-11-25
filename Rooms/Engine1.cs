using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjetNarratif.Rooms
{
    internal class Engine1:Room
    {
        internal override string CreateDescription()
        {
            return @"On retrouve dans la salle des machines toutes les différents circuits et tuyaux nécéssaires au fonctionnement du vaisseau.
On n'y trouve générallement personne, mais vous apercevez 4 pirates assez costauds accompagnés de ce que vous imaginez être un lieutenant.

Votre arrivée n'a pas encore été remarquée, mais affronter tous les pirates en même temps ne serait pas la meilleure des idées.
Vous pouvez essayer de les affronter directement [1], ou essayer de lancer quelque chose dans votre inventaire [2].";
        }
        internal override void ReceiveChoice(string choice)
        {
            switch (choice)
            {
                case "1":
                    Console.WriteLine("Vous vous lancez sur le groupe de pirates !");
                    Enemy pirate, pirate2, pirate3, pirate4, souschef;
                    pirate.pv = 50;
                    pirate.maxpv = 50;
                    pirate.dmg = 10;
                    pirate.name = "garde pirate";
                    pirate2.pv = 50;
                    pirate2.maxpv = 50;
                    pirate2.dmg = 10;
                    pirate2.name = "garde pirate";
                    pirate3.pv = 50;
                    pirate3.maxpv = 50;
                    pirate3.dmg = 10;
                    pirate3.name = "garde pirate";
                    pirate4.pv = 50;
                    pirate4.maxpv = 50;
                    pirate4.dmg = 10;
                    pirate4.name = "garde pirate";
                    souschef.pv = 120;
                    souschef.maxpv = 120;
                    souschef.dmg = 30;
                    souschef.name = "lieutenant";
                    Enemy[] enemies = { pirate, pirate2, pirate3, pirate4, souschef};
                    if (Combat(true, 75, dmg, 20, 4, enemies) == true)
                    {
                        Console.WriteLine("Au moment où le dernier pirate s'écroule, vous remarquez que le réservoire de carburant est dévérouillé.");
                        Console.WriteLine("Vous pouvez aller vers le cockpit en passant par la salle de stockage et affronter le chef des pirates [1], ou essayer de saboter les moteurs du vaisseau [2].");
                        choice = Console.ReadLine();
                        switch (choice)
                        {
                            case "1":
                                Console.WriteLine("Vous entrez dans la salle de stockage.");
                                Console.WriteLine("FIN DÉMO");
                                Game.Finish();
                                break;
                            case "2":
                                Console.WriteLine("Vous réussissez à dévisser le tuyau de refroidissement du réacteur. ");
                                Console.ReadKey();
                                Console.WriteLine("Quelques minutes après, le réacteur surchauffe et coupe l'électricité.");
                                Console.ReadKey();
                                Console.WriteLine("Dans la confusion qui ensuit, vous réussissez à fuir sur un des vaisseaux des pirates.");
                                Console.ReadKey();
                                Console.WriteLine("Peu après votre départ, le système de recyclage d'oxygène s'arrête, asphyxiant rapidement tous ses occupants, pirates inclus.");
                                Console.ReadKey();
                                Console.WriteLine("Quand à vous, vous réussissez à rentrer chez vous sans embûches.");
                                Console.ReadKey();
                                Console.WriteLine("Merci d'avoir joué !");
                                Console.ReadKey();
                                Console.WriteLine("FIN 2");
                                Console.ReadKey();
                                Game.Finish();
                                break;
                        }
                    }
                    break;
                default:
                    Console.WriteLine("Commande invalide.");
                    break;
            }
        }
    }
}
