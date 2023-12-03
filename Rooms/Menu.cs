using System.Media;
using System.Security.Cryptography.X509Certificates;

namespace ProjetNarratif.Rooms
{
    internal class Menu : Room
    {
        internal override string CreateDescription()
        {
            Console.WriteLine(@"
_________ _______  _______  _______ _________ _                 _______ 
\__   __/(  ____ \(  ____ )(       )\__   __/( (    /||\     /|(  ____ \
   ) (   | (    \/| (    )|| () () |   ) (   |  \  ( || )   ( || (    \/
   | |   | (__    | (____)|| || || |   | |   |   \ | || |   | || (_____ 
   | |   |  __)   |     __)| |(_)| |   | |   | (\ \) || |   | |(_____  )
   | |   | (      | (\ (   | |   | |   | |   | | \   || |   | |      ) |
   | |   | (____/\| ) \ \__| )   ( |___) (___| )  \  || (___) |/\____) |
   )_(   (_______/|/   \__/|/     \|\_______/|/    )_)(_______)\_______)

Présenté par Arthur Bohn 
                                                                                                                                                                        
Vous êtes un soldat qui vient de finir son service et qui retourne enfin chez lui.
Pour rentrer chez vous, vous avez pris une navette spatiale, et il ne reste que quelques jours avant votre arrivée.");
            return "";

        }
        internal override string CreateOptions() =>
@"[1] Lancer le jeu
[2] Options
[3] Quitter";
        internal override void  ReceiveChoice(string choice)
        {
            
            switch (choice)
            {
                case "1":
                    if (first == true)
                    {
                        byte option;
                        setting: Console.Clear();
                        Console.WriteLine("Avant de commencer, les combats dans ce jeu ont des limites de temps.");
                        Console.WriteLine("Vous pouvez mettre une valeur très grande (max 255) pour ne pas avoir le stress de ces limites.");
                        Console.WriteLine($"La valeur actuelle est {speed} secondes. Quelle devrait être la longueur des limites de temps ?");
                        try { option = Convert.ToByte(Console.ReadLine()); }
                        catch { Console.WriteLine("Cette valeur n'est pas valide !"); Console.ReadKey(); ; goto setting; }
                        speed = option;
                        Console.WriteLine($"La vitesse de jeu est maintenant de {option}. Vous pouvez la changer dans les options.");
                        first= false;
                    }
                    Console.WriteLine("Le jeu va maintenant commencer, appuyez sur entrée pour continuer.");
                    Game.Transition<Dortoir1>();
                    break;
                case "2":
                    Console.WriteLine("Ouverture des options, appuyez sur entrée pour continuer");
                    Game.Transition<Options>();
                    break;
                case "3":
                    Console.WriteLine("Merci d'avoir joué !");
                    Game.Finish();
                    break;
                case "4":
                    inventory.Add(détergent);
                    inventory.Add(briquet);
                    inventory.Add(fusil);
                    Game.Transition<Engine1>();
                    break;
                default:
                    Console.WriteLine("Commande invalide.");
                    break;
            }
        }
    }
}
