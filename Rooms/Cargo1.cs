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
            return @"Vous êtes dans la salle de stockage. Dans la salle on retrouve des rangées d'étagères 
dédiées au stockage de matériel, une salle réfrigirée et une porte menant au quai de lancement.";
        }
        internal override string CreateOptions() =>
@"[1] Partir vers le quai de lancement
[2] Fouiller les étagères
[3] Salle réfrigirée";
        
        internal override void ReceiveChoice(string choice)
        {
            switch (choice)
            {
                case "1":
                    Console.WriteLine("Vous vous dépêchez de traverser la salle pour arriver devant les quais de lancement.");
                    Game.Transition<Quai1>();
                    break;
                case "2":
                    if (!inventory.Contains(pistoletclou))
                    {
                        Console.WriteLine("En fouillant dans les boîtes, vous trouvez un pistolet à clou qui pourrait servir d'arme si vous l'utilisez correctement.");
                        pistoletclou.name = "Pistolet à clou";
                        pistoletclou.description = "Un pistolet à clou. 30 DMG 3 Munitions.";
                        pistoletclou.id = 6;
                        pistoletclou.quantity = 3;
                        inventory.Add(pistoletclou);
                    }
                    else {
                        Console.WriteLine("Vous ne trouvez rien de plus dans la salle.");
                    }
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
