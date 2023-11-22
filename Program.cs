using ProjetNarratif;
using ProjetNarratif.Rooms;

var game = new Game();
Console.WriteLine(@"Bienvenue dans le jeu.
");
game.Add(new ProjetNarratif.Rooms.Menu());
game.Add(new Dortoir1());
game.Add(new Réfectoire1());
game.Add(new Infirmerie1());
game.Add(new SalleExercice());
game.Add(new Dortoir2());
game.Add(new Cargo1());
game.Add(new CouloirO());
game.Add(new Observatoire());
game.Add(new Quai1());
game.Add(new Serre());
game.Add(new Quai2());
game.Add(new Quai3());

while (!game.IsGameOver())
{
    
    Console.WriteLine("--");
    Console.WriteLine(game.CurrentRoomDescription);
    string? choice = Console.ReadLine()?.ToLower() ?? "";
    game.ReceiveChoice(choice);
    Console.ReadKey();
    Console.Clear();
}

Console.WriteLine("FIN");
Console.ReadLine();