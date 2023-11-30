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
                    inventory.Add(pistoletclou);
                    Game.Transition<Quai1>();
                    break;
                default:
                    Console.WriteLine("Commande invalide.");
                    break;
            }
        }
    }
}
