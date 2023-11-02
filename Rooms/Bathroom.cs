namespace ProjetNarratif.Rooms
{
    internal class Bathroom : Room
    {
        internal override string CreateDescription() =>
@"Dans la toilette, le [bain] est rempli d'eau chaude.
Le [miroir] devant toi affiche ton visage déprimé.
Tu peux revenir dans ta [chambre].
";
        internal static bool bain = false;
        internal override void ReceiveChoice(string choice)

        {
            switch (choice)
            {
                case "bain":
                    Console.WriteLine("Tu te laisses relaxer dans le bain. De la vapeur remplit les toilettes.");
                    bain= true;
                    break;
                case "miroir":
                    if (bain == false)
                    {
                        Console.WriteLine("Tu regardes ton reflet dans le miroir, et tu as une sale mine.");
                    }
                    else if (bain=true) { 
                    Console.WriteLine("Tu aperçois les chiffres 6969 écrits sur la brume sur le miroir.");
                    }
                    break;
                case "chambre":
                    Console.WriteLine("Tu retournes dans ta chambre.");
                    Game.Transition<Bedroom>();
                    break;
                default:
                    Console.WriteLine("Commande invalide.");
                    break;
            }
        }
    }
}
