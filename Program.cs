using ProjetNarratif;
using ProjetNarratif.Rooms;

var game = new Game();
Console.WriteLine(@"
This was not meant to happen.
You run through the second floor of the mall, scrambling to find a hiding spot for the night.
Finally, you find a deserted Walmart with an unlocked door and end up in a small storage room.
");
game.Add(new ProjetNarratif.Rooms.Storage());
while (!game.IsGameOver())
{
    Console.WriteLine("--");
    Console.WriteLine(game.CurrentRoomDescription);
    Console.WriteLine(game.CurrentMap);
    string? choice = Console.ReadLine()?.ToLower() ?? "";
    game.ReceiveChoice(choice);
}

Console.WriteLine("FIN");
Console.ReadLine();