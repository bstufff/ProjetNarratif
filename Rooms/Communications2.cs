using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjetNarratif.Rooms
{
    internal class Communications2:Room
    {
        internal override string CreateDescription()
        {
            return @"Vous arrivez de justesse dans la salle de communications, qui est remplie de matériel radio.
Il y avait probablement un pirate ici il y a peu, car vous trouvez un pistolet en dessous d'un banc.
Vous pouvez fouiller la salle [1] ou vous diriger vers la salle des machines [2].

";
        }
        internal override void ReceiveChoice(string choice)
        {
            dmg = 35;
            switch (choice)
            {
                case "1":
                    Console.WriteLine("Vous trouvez le lunch de quelqu'un dans une poubelle.");
                    inventory.Add("lunch");
                    break;
                case "2":
                    Console.WriteLine("Vous entrez dans la salle des machines.");
                    Game.Transition<Engine1>();
                    break;
            }
        }
    }
}
