using ProjetNarratif;
using ProjetNarratif.Rooms;

var game = new Game();
Console.WriteLine(@"Bienvenue dans le jeu.
");
game.Add(new ProjetNarratif.Rooms.Menu());
game.Add(new Dortoir1());
while (!game.IsGameOver())
{
    Console.WriteLine("--");
    Console.WriteLine(game.CurrentRoomDescription);
    string? choice = Console.ReadLine()?.ToLower() ?? "";
    game.ReceiveChoice(choice);
}

Console.WriteLine("FIN");
Console.ReadLine();