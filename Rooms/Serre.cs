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
Il n'y a pas grand chose à faire ici, mais vous pouvez essayer de fouiller la salle pour quelque chose d'utile [1].
Sinon, derrière une rangée de légumes se trouve un couloir menant au quai de lancement [2].";
        }
        internal override void ReceiveChoice(string choice)
        {
            switch (choice)
            {
                case "1":
                    Console.WriteLine("Dans un chariot contenant des produits ménagers, vous trouvez un liquide détergent très inflammable.");
                    if (inventory.Count <= 5)
                    {
                        inventory.Add("détergent");
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
