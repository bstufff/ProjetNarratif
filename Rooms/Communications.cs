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
            return @"La salle des communications est remplie d'ordinateurs et de matériel radio.
Vous pouvez fouiller la salle, ou partir directement vers le quai de lancement.";
        }
        internal override string CreateOptions() =>
@"[1] Fouiller la salle
[2] Partir vers le quai de lancement";
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
