using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjetNarratif.Rooms
{
    internal class SalleExercice : Room
    {
        
        internal override string CreateDescription() =>
@"Vous rentrez dans la salle d'exercice et trouvez les affaires d'un membre de l'équipage sur un banc.
Vous trouvez un pistolet neutralisant dans une des poches du pantalon.
Vous avez le choix de partir vers l'observatoire [1], ou vers la salle de stockage [2], 
mais entrer dans la salle de stockage nécessite un badge.";   

        
        internal override void ReceiveChoice(string choice)
        {
            dmg = 25;
            switch (choice)
            {
                case "1":
                    Console.WriteLine("Vous passez par la porte devant vous et arrivez dans l'observatoire.");
                    Game.Transition<Observatoire>();
                    break;
                case "2":
                    if (inventory.Contains(badge) == true)
                    {
                        Console.WriteLine("Vous utilisez le badge et arrivez dans la salle de stockage.");
                        Game.Transition<Cargo1>();
                    }
                    else
                    {
                        Console.WriteLine("Vous essayez d'ouvrir la porte, mais vous n'avez pas le badge permettant de l'ouvrir.");
                    }
                    break;
                default:
                    Console.WriteLine("Commande invalide.");
                    break;
            }
        }
    }
}