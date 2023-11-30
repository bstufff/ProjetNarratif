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
            return @"Vous êtes dans la salle de stockage : on y retrouve des rangées d'étagères 
dédiées au stockage de matériel, une salle réfrigérée et une porte menant au quai de lancement.";
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
                    Console.WriteLine("Vous vous dépêchez de traverser la salle pour arriver devant le quai de lancement.");
                    Game.Transition<Quai1>();
                    break;
                case "2":
                    if (!inventory.Contains(pistoletclou))
                    {
                        Console.WriteLine("En fouillant dans les boîtes, vous trouvez un pistolet à clou qui pourrait servir d'arme si vous l'utilisez correctement.");
                        inventory.Add(pistoletclou);
                    }
                    else {
                        Console.WriteLine("Vous ne trouvez rien de plus dans la salle.");
                    }
                    break;
                case "3":
                    Console.WriteLine("Vous trouvez 3 seringues d'adrénaline dans la salle réfrigirée.");
                    break;
                default:
                    Console.WriteLine("Commande invalide.");
                    break;
            }
        }
    }
}
