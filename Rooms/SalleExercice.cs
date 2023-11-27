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
@"Vous rentrez dans la salle d'exercice, où on retrouve tout l'équipement nécessaire pour
garder la forme lors d'un très long voyage. Il y a aussi des vestiaires et un couloir vers la serre,
contenant aussi un accès à la salle de stockage réservé à l'équipage.";

        internal override string CreateOptions() =>
@"[1] Fouiller les vestiaires
[2] Aller dans l'observatoire
[3] Aller dans la salle de stockage";
        internal override void ReceiveChoice(string choice)
        {
            switch (choice)
            {
                case "1":
                    Console.WriteLine("Vous trouvez dans un des casiers un pistolet paralysant, qui n'est pas très nocif mais permet d'immobiliser un ennemi. ");
                    if (!inventory.Contains(pistoletneut))
                    {
                        pistoletneut.name = "Pistolet neutralisant";
                        pistoletneut.description = "Permet de paralyser un ennemi, faisant 10 dégats et réduisant les dégats du receveur.";
                        pistoletneut.id = 7;
                        pistoletneut.quantity = 2;
                        inventory.Add(pistoletneut);
                    }
                    else
                    {
                        Console.WriteLine("Vous ne trouvez rien de plus dans les casiers.");
                    }
                    break;
                case "2":
                    Console.WriteLine("Vous passez par la porte devant vous et arrivez dans l'observatoire.");
                    Game.Transition<Observatoire>();
                    break;
                case "3":
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