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
            return @"Vous êtes dans la salle de stockage. Au fond de la pièce, il y a la porte menant vers le quai de lancement [1].
               Dans la salle, il y a des rangées d'étagères dédiées au stockage de matériel [2] et une porte menant dans une salle réfrigirée [3].";
        }
        internal override void ReceiveChoice(string choice)
        {
            switch (choice)
            {
                case "1":
                    Console.WriteLine("Vous vous dépêchez de traverser la salle pour arriver devant les quais de lancement.");
                    Game.Transition<Quai1>();
                    break;
                case "2":
                    Console.WriteLine("En fouillant dans les boîtes, vous trouvez un pistolet à clou qui pourrait servir d'arme si vous l'utilisez correctement.");
                    Item pistoletclou;
                     pistoletclou.name = "Lunch";
                    pistoletclou.description = "Le repas oublié de quelqu'un. Soigne 30 PV.";
                    pistoletclou.id = 1;
                    pistoletclou.quantity = 2;
                    inventory.Add(lunch);
                    break;
                case "3":
                    Console.WriteLine("Vous ne trouvez rien d'utile dans la salle réfrigirée.");
                    break;
                default:
                    Console.WriteLine("Commande invalide.");
                    break;
            }
        }
    }
}
