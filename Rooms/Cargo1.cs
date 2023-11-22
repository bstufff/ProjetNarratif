using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjetNarratif.Rooms
{
    internal class Cargo1 : Room
    {
        internal override string CreateDescription()
        {
            return "Vous êtes dans la salle de stockage. Au fond de la pièce, il y a la porte menant vers le quai de lancement [1]." +
                "Dans la salle, il y a des rangées d'étagères dédiées au stockage de matériel [2] et une porte menant dans une salle réfrigirée [3].";
        }
        internal override void ReceiveChoice(string choice)
        {
            switch (choice)
            {
                case "1":
                    Console.WriteLine("Vous vous dépêchez de traverser la salle pour arriver devant les quais de lancement.");
                    break;
                case "2":
                    Console.WriteLine("En fouillant dans les boîtes, vous trouvez un pistolet à clou qui pourrait servir d'arme si vous l'utilisez correctement.");
                    dmg = 30;
                    break;
                case "3":
                    Console.WriteLine("Dans la salle réfrigirée, vous trouvez beaucoup de nourriture, et vous en mettez dans un petit sac.");
                    if (inventory.Count <= 5)
                    {
                        inventory.Add("nourriture");
                    }
                    else
                    {
                        Console.WriteLine("Vous n'avez plus de place dans votre inventaire, alors vous le remettez là où vous l'avez trouvé");
                    }
                    break;
                default:
                    Console.WriteLine("Commande invalide.");
                    break;
            }
        }
    }
}
