using ProjetNarratif;
using ProjetNarratif.Rooms;
using System.Media;
var game = new Game();
Console.WriteLine(@"
 _______ _     _ _______             _______ _______ _______      _______ _______  _____   _____ 
    |    |_____| |______      |      |_____| |______    |         |______    |    |     | |_____]
    |    |     | |______      |_____ |     | ______|    |         ______|    |    |_____| |      
                                                                                                 
");
SoundPlayer player = new SoundPlayer(Path.Combine(Environment.CurrentDirectory + @"\ost.wav"));
player.PlayLooping();
game.Add(new ProjetNarratif.Rooms.Menu());
game.Add(new Dortoir1());
game.Add(new Réfectoire1());
game.Add(new Infirmerie1());
game.Add(new Communications());
game.Add(new SalleExercice());
game.Add(new Dortoir2());
game.Add(new Cargo1());
game.Add(new CouloirO());
game.Add(new Observatoire());
game.Add(new Quai1());
game.Add(new Serre());
game.Add(new Quai2());
game.Add(new Quai3());
game.Add(new Engine1());
game.Add(new Communications2());
while (!game.IsGameOver())
{
    Game.DisplayInv();
    Console.WriteLine(game.CurrentRoomDescription);
    string? choice = Console.ReadLine()?.ToLower() ?? "";
    game.ReceiveChoice(choice);
    Console.ReadKey();
    Console.Clear();
}

Console.WriteLine("FIN");
Console.ReadLine();