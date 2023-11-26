using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjetNarratif.Rooms
{
    internal class Cargo2:Room
    {
        internal override string CreateDescription()
        {
            return @"Vous arrivez dans la salle de stockage. Des pirates ont dû passer par là, 
car il y a une caisse ouverte au milieu de la salle [1] que vous pouvez fouiller.
Vous pouvez aussi chercher dans les autres caisses [2], ou vous diriger vers le cockpit [3] où se trouve probablement le reste des pirates.";
        }
        internal override void ReceiveChoice(string choice)
        {
            switch (choice)
            {
                case "1":
                    if (!inventory.Contains(fusil))
                    {
                        Console.WriteLine("Vous trouvez un fusil dans la caisse.");
                        fusil.name = "Fusil";
                        fusil.description = "Votre attaque principale fait maintenant le double des dégats.";
                        fusil.id = 8;
                        fusil.quantity = 2;
                        inventory.Add(fusil);
                    }
                    else {
                        Console.WriteLine("Vous ne trouvez rien d'utile dans la caisse.");
                    }
                    break;
                case "2":
                    if (!inventory.Contains(fusil))
                    {
                        Console.WriteLine("Vous trouvez un fusil dans la caisse.");
                        fusil.name = "Fusil";
                        fusil.description = "Fait 30 dégats.";
                        fusil.id = 8;
                        fusil.quantity = 2;
                        inventory.Add(fusil);
                    }
                    else
                    {
                        Console.WriteLine("Vous ne trouvez rien d'utile dans la caisse.");
                    }
                    break;
                    

            }
        }
    }
}
