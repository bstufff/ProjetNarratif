using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjetNarratif.Rooms
{
    internal class Quai2:Room
    {
        internal override string CreateDescription()
        {
            return @"Vous arrivez à rentrer dans la dernière nacelle avant qu'elle parte, laissant la majorité des occupants du vaisseau 
à la merci des pirates. Ce n'était peut-être pas l'option la plus honorable, mais au moins vous êtes vivant.

FIN 3";
        }
        internal override void ReceiveChoice(string choice)
        {
            Console.WriteLine("Merci d'avoir joué !");
            Console.ReadKey();
            Game.Transition<Menu>();
        }
    }
}
