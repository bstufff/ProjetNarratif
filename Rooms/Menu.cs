using System.Media;

namespace ProjetNarratif.Rooms
{
    internal class Menu : Room
    {
        internal override string CreateDescription()
        {
            return @"
 _______ _     _ _______             _______ _______ _______      _______ _______  _____   _____ 
    |    |_____| |______      |      |_____| |______    |         |______    |    |     | |_____]
    |    |     | |______      |_____ |     | ______|    |         ______|    |    |_____| |      
                                                                                                 
Vous êtes un soldat qui vient de finir son service, et qui retourne enfin chez lui.
Pour rentrer chez vous, vous avez pris une navette spatiale, et il ne reste que quelques jours avant votre arrivée.
Vous pouvez lancer le jeu [1], configurer les options [2] ou quitter [3] : ";

        }

        internal override void  ReceiveChoice(string choice)
        {
            
            switch (choice)
            {
                case "1":
                    Console.WriteLine("Bon jeu !");
                    Game.Transition<Dortoir1>();
                    break;
                case "2":
                    Game.Transition<Options>();
                    break;
                case "3":
                    Game.Finish();
                    break;
                case "4":
                    Game.Transition<Quai1>();
                    lunch.name = "Lunch";
                    lunch.description = "Le repas oublié de quelqu'un. Soigne 30 PV.";
                    lunch.id = 1;
                    lunch.quantity = 2;
                    inventory.Add(lunch);
                    break;
                default:
                    Console.WriteLine("Commande invalide.");
                    break;
            }
        }
    }
}
