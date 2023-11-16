﻿using ProjetNarratif;
using ProjetNarratif.Rooms;

var game = new Game();
Console.WriteLine(@"Bienvenue dans le jeu.
");
game.Add(new ProjetNarratif.Rooms.Menu());
game.Add(new Dortoir1());
game.Add(new Réfectoire1());
while (!game.IsGameOver())
{
    
    Console.WriteLine("--");
    Console.WriteLine(game.CurrentRoomDescription);
    string? choice = Console.ReadLine()?.ToLower() ?? "";
    game.ReceiveChoice(choice);
    Console.Clear();
}

Console.WriteLine("FIN");
Console.ReadLine();