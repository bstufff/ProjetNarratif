namespace ProjetNarratif.Rooms
{
    internal class White : Room
    {
        internal static int progression = 0;
        internal override string CreateDescription() {
            switch (progression) {
                case 1:
                    {
                        return @"Tu te situes dans une salle complètement blanche.
Un [téléphone] est sur un bureau devant toi. 
Un mur s'est déplacé et permet l'accès à une salle [rouge]";

                    }
                default:
                    {
                        return @"Tu te situes dans une salle complètement blanche.
Un [téléphone] est sur un bureau devant toi. ";
                    }
            }


}
        
        internal override void  ReceiveChoice(string choice)
        {
            switch (choice)
            {
                case "téléphone":
                    Game.Transition<Phone>();
                    break;
                case "rouge":
                    if (White.progression >= 1) {
                        Console.WriteLine("");
                    }
                    break;
                case "grenier":
                    Console.WriteLine("Tu montes dans le grenier.");
                    Game.Transition<AtticRoom>();
                    break;
                default:
                    Console.WriteLine("Commande invalide.");
                    break;
            }
        }
    }
}
