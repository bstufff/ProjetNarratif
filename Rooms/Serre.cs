using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Media;

namespace ProjetNarratif.Rooms
{
    internal class Serre : Room
    {
        internal override string CreateDescription()
        {
            return @"Vous arrivez dans la serre où les aliments frais sont cultivés à bord. 
Il n'y a pas grand chose à faire ici, mais vous pouvez essayer de fouiller la salle pour quelque chose d'utile.
Sinon, derrière une rangée de légumes se trouve un couloir menant au quai de lancement.";
        }
        internal override string CreateOptions() =>
@"[1] Fouiller la salle
[2] Aller dans le quai de lancement";
        internal override void ReceiveChoice(string choice)
        {
            switch (choice)
            {
                case "1":
                    if (!inventory.Contains(détergent))
                    {
                        Console.WriteLine("Dans un chariot contenant des produits ménagers, vous trouvez du désinfectant pour les mains.");
                        inventory.Add(détergent);
                    }
                    else
                    {
                        Console.WriteLine("Vous ne trouvez rien de plus dans la salle.");
                    }
                    
                    break;
                case "2":
                    Console.WriteLine("Vous entrez dans le quai de lancement.");
                    Game.Transition<Quai1>();
                    break;
                default:
                    Console.WriteLine("Commande invalide.");
                    break;
            }
        }
    }
}
