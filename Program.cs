using ProjetNarratif;
using ProjetNarratif.Rooms;

var game = new Game();
Console.WriteLine(@" __   __  _______  ______    _______  __   __  __   __  _______    _______  _______  ___      _______  ______   
|  |_|  ||       ||    _ |  |       ||  | |  ||  | |  ||       |  |       ||       ||   |    |       ||    _ |  
|       ||   _   ||   | ||  |_     _||  | |  ||  | |  ||  _____|  |       ||   _   ||   |    |   _   ||   | ||  
|       ||  | |  ||   |_||_   |   |  |  |_|  ||  |_|  || |_____   |       ||  | |  ||   |    |  | |  ||   |_||_ 
|       ||  |_|  ||    __  |  |   |  |       ||       ||_____  |  |      _||  |_|  ||   |___ |  |_|  ||    __  |
| ||_|| ||       ||   |  | |  |   |  |       ||       | _____| |  |     |_ |       ||       ||       ||   |  | |
|_|   |_||_______||___|  |_|  |___|  |_______||_______||_______|  |_______||_______||_______||_______||___|  |_|
"

    );
game.Add(new ProjetNarratif.Rooms.White());
game.Add(new Bathroom());
game.Add(new AtticRoom());
game.Add(new LivingRoom());
game.Add(new Phone());

while (!game.IsGameOver())
{
    Console.WriteLine("--");
    Console.WriteLine(game.CurrentRoomDescription);
    string? choice = Console.ReadLine()?.ToLower() ?? "";
    game.ReceiveChoice(choice);
}

Console.WriteLine("FIN");
Console.ReadLine();