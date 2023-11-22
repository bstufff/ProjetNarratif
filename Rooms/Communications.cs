using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjetNarratif.Rooms
{
    internal class Communications : Room
    {
        internal override string CreateDescription()
        {
            return @"La salle de communications est remplie d'ordinateurs et de matériel radio.
Vous pouvez essayer de fouiller la salle [1], ou de partir directement vers le quai de lancement. [2]";
        }
        internal override void ReceiveChoice(string choice)
        {
            switch (choice)
            {
                case "1":
                    Console.WriteLine("Vous ne trouvez rien d'utile dans la salle.");
                    break;
                case "2":
                    Console.WriteLine("Vous passez par le couloir au fond de la salle et arrivez devant les nacelles de sauvetage.");
                    Game.Transition<Quai2>();
                    break;
            }
        }
    }
}
