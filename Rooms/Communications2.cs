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
            return @"Vous arrivez de justesse dans la salle des communications, qui est remplie de matériel radio.
Vous pouvez fouiller la salle ou vous diriger vers la salle des machines [2].
";
        }
        internal override string CreateOptions() =>
@"[1] Fouiller la salle
[2] Partir vers la salle des machines";
        internal override void ReceiveChoice(string choice)
        {
            switch (choice)
            {
                case "1":
                    Console.WriteLine("Vous trouvez le lunch de quelqu'un dans une poubelle.");
                    if (!inventory.Contains(lunch))
                    {
                        lunch.name = "Lunch";
                        lunch.description = "Le repas oublié de quelqu'un. Soigne 30 PV.";
                        lunch.id = 1;
                        lunch.quantity = 2;
                        inventory.Add(lunch);
                    }
                    else
                    {
                        Console.WriteLine("Vous ne trouvez rien de plus dans la salle.");
                    }
                    break;
                case "2":
                    Console.WriteLine("Vous entrez dans la salle des machines.");
                    Game.Transition<Engine1>();
                    break;
            }
        }
    }
}
