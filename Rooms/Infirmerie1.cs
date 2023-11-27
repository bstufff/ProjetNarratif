using System;
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
Tous les patients sont déjà partis, mais il en reste un tout au fond de la salle qui n'a pas l'air d'avoir remarqué votre présence.
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
                    Console.ReadKey();
                    Console.WriteLine("<Patient> : C'est les androides qui ont fait ça ! Ils nous volent nos travails !");
                    Console.ReadKey();
                    Console.WriteLine("Vous lui proposez de partir avec vous, mais il ne semble pas vous comprendre.");
                    break;
                case "2":
                    if (!inventory.Contains(bandages))
                    {
                        Console.WriteLine("Vous ouvrez l'armoire où se trouve quelques bandages légers.");
                        bandages.name = "Bandages";
                        bandages.description = "Bon pour les petites blessures. Soigne 15 PV.";
                        bandages.id = 5;
                        bandages.quantity = 5;
                        inventory.Add(bandages);
                    }
                    else
                    {
                        Console.WriteLine("Vous ne trouvez rien de plus dans la salle.");
                    }
                    break;
                case "3":
                    if (!inventory.Contains(tournevis))
                    {
                        Console.WriteLine("Il ne reste rien d'utile sur le bureau, mais vous trouvez un tournevis dans un des tiroirs.");
                        tournevis.name = "Tournevis";
                        tournevis.description = "Un outil bien utile pour tout ce qui concerne des vis. Fait 10 DMG";
                        tournevis.id = 2;
                        tournevis.quantity = 1;
                        inventory.Add(tournevis);
                    }
                    else
                    {
                        Console.WriteLine("Vous ne trouvez rien de plus dans la salle.");
                    }
                    break;
                case "4":
                    Console.WriteLine("Vous prenez la porte à votre gauche et rentrez dans le couloir ouest.");
                    Game.Transition<CouloirO>();
                    break;
                default:
                    Console.WriteLine("Commande invalide.");
                    break;
            }
        }
    }
}
