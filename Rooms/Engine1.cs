﻿using System;
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
On n'y trouve généralement personne, mais vous apercevez 2 pirates assez costauds accompagnés de ce que vous imaginez être un lieutenant.

Votre arrivée n'a pas encore été remarquée, mais affronter tous les pirates en même temps ne serait pas la meilleure des idées.
Vous pouvez essayer de les affronter directement ou essayer de trouver quelque chose pour améliorer vos chances.";
        }
        internal override string CreateOptions() =>
@"[1] Affronter les pirates 
[2] Fouiller la salle";
        internal override void ReceiveChoice(string choice)
        {
            switch (choice)
            {
                case "1":
                     Console.WriteLine("Vous vous lancez sur le groupe de pirates !");
                     Enemy pirate, pirate2, souschef;
                     pirate.pv = 50;
                     pirate.accuracy = 85;
                     pirate.maxpv = 50;
                        pirate.dmg = 15;
                        pirate.name = "garde pirate de droite";
                        pirate2.pv = 50;
                        pirate2.accuracy = 85;
                        pirate2.maxpv = 50;
                        pirate2.dmg = 15;
                        pirate2.name = "garde pirate de droite";
                        souschef.pv = 120;
                        souschef.accuracy = 100;
                        souschef.maxpv = 120;
                        souschef.dmg = 25;
                        souschef.name = "lieutenant";
                        Enemy[] enemies = { pirate, pirate2, souschef };
                    if (Combat(true, health, dmg, speed, enemies) == true)
                    {
                        skip: Console.WriteLine("Au moment où le dernier pirate s'écroule, vous remarquez que le réservoire de carburant est dévérouillé.");
                        Console.WriteLine("Vous pouvez aller vers le cockpit en passant par la salle de stockage et affronter le chef des pirates [1], ou essayer de saboter les moteurs du vaisseau [2].");
                        choice = Console.ReadLine();
                        switch (choice)
                        {
                            case "1":
                                Console.WriteLine("Vous entrez dans la salle de stockage.");
                                Game.Transition<Cargo2>();
                                Game.Finish();
                                break;
                            case "2":
                                Console.WriteLine("Vous réussissez à dévisser le tuyau de refroidissement du réacteur. ");
                                Console.ReadKey();
                                Console.WriteLine("Quelques minutes après, le réacteur surchauffe et coupe l'électricité.");
                                Console.ReadKey();
                                Console.WriteLine("Dans la confusion qui s'en suit, vous réussissez à fuir sur un des vaisseaux des pirates.");
                                Console.ReadKey();
                                Console.WriteLine("Quand à vous, vous réussissez à rentrer chez vous sans embûche, mais tous ceux qui sont restés à bord n'ont probablement pas survécu.");
                                Console.ReadKey();
                                Console.WriteLine("Cette histoire aurait pu mieux se finir.");
                                Console.ReadKey();
                                Console.WriteLine("Merci d'avoir joué !");
                                Console.ReadKey();
                                Console.WriteLine("FIN 2");
                                Console.ReadKey();
                                Game.Finish();
                                break;
                            default:
                                Console.WriteLine("Valeur invalide");
                                goto skip;
                        }
                    }
                    else { Game.Transition<Menu>(); }
                    break;
                case "2":
                    Console.WriteLine("Vous trouvez un fumigène dans une caisse, et vous l'utilisez pour répandre de la fumée de la salle avant d'attaquer le groupe.");
                    Console.ReadKey();
                    pirate.pv = 50;
                    pirate.accuracy = 50;
                    pirate.maxpv = 50;
                    pirate.dmg = 15;
                    pirate.name = "garde pirate de droite";
                    pirate2.pv = 50;
                    pirate2.accuracy = 50;
                    pirate2.maxpv = 50;
                    pirate2.dmg = 15;
                    pirate2.name = "garde pirate de gauche";
                    souschef.pv = 120;
                    souschef.accuracy = 75;
                    souschef.maxpv = 120;
                    souschef.dmg = 25;
                    souschef.name = "lieutenant";
                    Enemy[] enemies2 = { pirate, pirate2, souschef };
                    if (Combat(true, health, dmg, speed, enemies2) == true)
                    {
                    skip: Console.WriteLine("Au moment où le dernier pirate s'écroule, vous remarquez que le réservoire de carburant est dévérouillé.");
                        Console.WriteLine("Vous pouvez aller vers le cockpit en passant par la salle de stockage et affronter le chef des pirates [1], ou essayer de saboter les moteurs du vaisseau [2].");
                        choice = Console.ReadLine();
                        switch (choice)
                        {
                            case "1":
                                Console.WriteLine("Vous entrez dans la salle de stockage.");
                                Game.Transition<Cargo2>();
                                break;
                            case "2":
                                Console.WriteLine("Vous réussissez à dévisser le tuyau de refroidissement du réacteur. ");
                                Console.ReadKey();
                                Console.WriteLine("Quelques minutes après, le réacteur surchauffe et coupe l'électricité.");
                                Console.ReadKey();
                                Console.WriteLine("Dans la confusion qui s'en suit, vous réussissez à fuir sur un des vaisseaux des pirates.");
                                Console.ReadKey();
                                Console.WriteLine("Quand à vous, vous réussissez à rentrer chez vous sans embûche, mais tous ceux qui sont restés à bord n'ont probablement pas survécu.");
                                Console.ReadKey();
                                Console.WriteLine("Cette histoire aurait pu mieux se finir.");
                                Console.ReadKey();
                                Console.WriteLine("Merci d'avoir joué !");
                                Console.ReadKey();
                                Console.WriteLine("FIN 2");
                                Console.ReadKey();
                                Game.Finish();
                                break;
                            default:
                                Console.WriteLine("Valeur invalide");
                                goto skip;
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
