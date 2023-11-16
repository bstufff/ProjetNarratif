namespace ProjetNarratif.Rooms
{
    internal class Menu : Room
    {
        internal override string CreateDescription() =>
            @"Vous êtes un soldat qui vient de finir son service, et qui retourne enfin chez lui.
Pour rentrer chez vous, vous avez pris une navette spatiale, qui est à quelques jours de votre planète natale.
Vous pouvez [lancer] le jeu ou [quitter] : ";

        internal override void  ReceiveChoice(string choice)
        {
            switch (choice)
            {
                case "lancer":
                    Game.Transition<Dortoir1>();
                    break;
                case "quitter":
                    Game.Finish();
                    break;
                default:
                    Console.WriteLine("Commande invalide.");
                    break;
            }
        }
    }
}
