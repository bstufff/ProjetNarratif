﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjetNarratif.Rooms
{
    internal class Infirmerie1 : Room
    {
        internal override string CreateDescription() =>
            @"Vous êtes dans l'infirmerie. 
Tous les patients ont déjà été évacués, mais il en reste un tout au fond de la salle qui n'a pas l'air d'avoir remarqué votre présence.
Vous pouvez aussi essayer de trouver quelque chose d'utile dans l'armoire ou le bureau, ou de passer par le couloir ouest.";
        internal override string CreateOptions() =>
@"[1] Parler au patient
[2] Fouiller l'armoire
[3] Fouiller le bureau
[4] Partir vers le couloir ouest";
        internal override void ReceiveChoice(string choice)
        {
            switch (choice)
            {
                case "1":

                    Console.WriteLine("Le dernier patient remue, et se met à parler d'une voix très grave :");
                    Console.ForegroundColor = ConsoleColor.Green;
                    Console.ReadKey();
                    Console.WriteLine("<Patient> : Ce sont les androides qui ont fait ça ! Ils nous volent nos emplois !");
                    Console.ReadKey();
                    Console.ResetColor();
                    Console.WriteLine("Vous lui proposez de partir avec vous, mais il ne semble pas vous comprendre.");
                    Console.ForegroundColor = ConsoleColor.Green;
                    Console.ReadKey();
                    Console.WriteLine("Vous, très cher, j'aurais une charade pour vous. ");
                    int guess = 1;
                    while (guess <= 3)
                    {
                        Console.WriteLine("\nMon premier est le plus fort, plus que n'importe qui d'autre.\r\nMon deuxième signifie l'excès, comme il y en a trop.\r\nMon troisième est un chiffre, qui influence le futur des élèves.\r\nMon tout est un voyageur de l'espace. \r\nQui suis-je ?");
                        Console.ResetColor();
                        string entry = Console.ReadLine().ToLower();
                        if (entry == "astronaute")
                        {
                            Console.WriteLine($"Bravo, vous avez trouvé ! En {guess} essais !");
                            Console.WriteLine("Bien joué.");
                        }
                        else
                        {
                            Console.WriteLine("Mauvaise réponse !");
                            switch (guess)
                            {
                                case 1:
                                    Console.WriteLine("Mon troisième est aussi utilisé pour décrire une musique.");
                                    break;
                                case 2:
                                    Console.WriteLine("Mon premier est aussi présent dans un jeu de cartes.");
                                    break;
                            }
                            Console.ReadKey();
                            guess++;
                        }
                    }

                    break;
                case "2":
                    if (!inventory.Contains(bandages))
                    {
                        Console.WriteLine("Vous ouvrez l'armoire où se trouve quelques bandages légers.");
                        inventory.Add(bandages);
                    }
                    else
                    {
                        Console.WriteLine("Vous ne trouvez rien de plus dans l'armoire.");
                    }
                    break;
                case "3":
                    if (!inventory.Contains(tournevis))
                    {
                        Console.WriteLine("Il ne reste rien d'utile sur le bureau, mais vous trouvez un tournevis dans un des tiroirs.");
                        inventory.Add(tournevis);
                    }
                    else
                    {
                        Console.WriteLine("Vous ne trouvez rien de plus dans le bureau.");
                    }
                    break;
                case "4":
                    Console.WriteLine("vous prenez la porte à votre gauche et entrez dans le couloir ouest");
                    Game.Transition<CouloirO>();
                    break;
                default:
                    Console.WriteLine("Commande invalide.");
                    break;
            }
        }
    }
}
