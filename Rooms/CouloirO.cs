using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjetNarratif.Rooms
{
    internal class CouloirO : Room
    {
        internal override string CreateDescription()
        {
            return @"Dans le couloir, vous remarquez qu'il y a un conduit de ventilation relié à la salle de stockage 
et l'entrée de la salle d'exercice au fond.";
        }
        internal override string CreateOptions() =>
@"[1] Examiner le conduit
[2] Partir vers la salle d'exercice";
        internal override void ReceiveChoice(string choice)
        {
            
            switch (choice)
            {
                case "1":
                    if (inventory.Contains(tournevis) ==true)
                    {
                        Console.WriteLine("Vous retirez la plaque avec le tournevis et entrez dans la salle de stockage.");
                        Game.Transition<Cargo1>();
                    }
                    else
                    {
                        Console.WriteLine("Vous essayez d'enlever la plaque de ventilation, mais elle résiste à vos efforts et reste en place.");
                    }
                    break;
                case "2":
                    Console.WriteLine("Vous ouvrez la porte au bout du couloir et rentrez dans la salle d'exercice.");
                    Game.Transition<SalleExercice>();
                    break;
                default:
                    Console.WriteLine("Commande invalide.");
                    break;
            }
        }
    }
}
