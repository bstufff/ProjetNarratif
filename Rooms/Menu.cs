using System.Media;

namespace ProjetNarratif.Rooms
{
    internal class Menu : Room
    {
        internal override string CreateDescription()
        {
            return @"Vous êtes un soldat qui vient de finir son service, et qui retourne enfin chez lui.
Pour rentrer chez vous, vous avez pris une navette spatiale, et il ne reste que quelques jours avant votre arrivée.
Vous pouvez lancer le jeu [1] ou quitter [2] : ";

        }

        internal override void  ReceiveChoice(string choice)
        {
            
            switch (choice)
            {
                case "1":
                    Game.Transition<Dortoir1>();
                    break;
                case "2":
                    Game.Finish();
                    break;
                case "3":
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
