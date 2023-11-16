using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjetNarratif.Rooms
{
    internal class Dortoir1 : Room
    {
        internal override string CreateDescription() => 
            @"Vous vous réveillez dans le dortoir du vaisseau par votre estomac vide. 
Vous pouvez aller manger au réfectoire [1] ou rester [2] et peut être discuter avec les autres passagers";
        internal override void ReceiveChoice(string choice)
        {
            switch (choice)
            {
                case "1": 
                    Console.WriteLine("Vous sortez du dortoir et arrivez dans la zone commune où se trouve le réfectoire.");
                    Console.ReadKey();
                    Console.WriteLine("Après avoir mangé, une alarme retentit : ");
                    Console.ReadKey();

                    break;
            }
        }
    }
}
