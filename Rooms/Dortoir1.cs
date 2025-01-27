﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjetNarratif.Rooms
{
    internal class Dortoir1 : Room
    {
        internal override string CreateDescription() =>
            @"Vous vous réveillez dans le dortoir à cause de votre estomac vide. 
Vous pouvez aller manger au réfectoire ou discuter avec les autres passagers.";
        internal override string CreateOptions() =>
@"[1] Aller manger au réfectoire
[2] Parler avec les autres passagers";
        internal override void ReceiveChoice(string choice)
        {
            switch (choice)
            {
                case "1": 
                    Console.WriteLine("Vous sortez du dortoir et arrivez dans la zone commune où se trouve le réfectoire.");
                    Game.Transition<Réfectoire1>();
                    break;
                case "2":
                    Console.WriteLine("Eh bah non, vous avez faim.");
                    Game.Transition<Réfectoire1>();
                    break;
                default:
                    Console.WriteLine("Commande invalide.");
                    break;
            }
        }
    }
}
