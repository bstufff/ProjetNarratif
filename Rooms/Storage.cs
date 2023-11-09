namespace ProjetNarratif.Rooms
{
    internal class Storage : Room
    {
        internal static int progression = 0;
        internal override string CreateDescription() =>
            @"This storage room doesn't have much left, since most of the essential ressources were vandalized at the start of the crisis.";
        internal override string GetMap() =>
@"
|=======================|
|                       |
|                       |
|        [shelf2]       |
|                       |
|  [shelf1]             |
|              [freezer]|
|=======[door]==========|
";

        internal override void  ReceiveChoice(string choice)
        {
            switch (choice)
            {
                case "shelf1":
                    Console.WriteLine("You manage to find a few granola bars laying on a shelf. ");
                    Console.WriteLine("Enter E to show the inventory");
                    break;
                case "rouge":
                    if (Storage.progression >= 1) {
                        Console.WriteLine("Vous rentrez dans la salle rouge.");
                    }
                    break;
                default:
                    Console.WriteLine("Commande invalide.");
                    break;
            }
        }
    }
}
