using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjetNarratif.Rooms
{
    internal class Quai1 : Room
    {
        internal override string CreateDescription()
        {
            
            return @"Vous arrivez enfin devant le quai de lancement juste à temps pour voir la dernière nacelle s'enfuir vers la planète la plus proche.

Les pirates de ce secteur ne sont pas des plus cléments, alors le seul moyen d'arriver sain et sauf à votre destination est de reprendre contrôle du vaisseau.

Vous récupérez un briquet utilisable dans une poubelle quand tout à coup, vous entendez un pirate arriver de la salle des machines. 
Vous pouvez essayer de l'éliminer rapidement ou vous cacher.";
            
        }
        internal override string CreateOptions() =>
@"[1] Attaquer le pirate
[2] Vous cacher";
        internal override void ReceiveChoice(string choice)
        {
            
            switch (choice)
            {
                case "1":
                    Console.WriteLine("Vous sautez sur le pirate et vous commencez à l'attaquer !");
                    Enemy pirate;
                    pirate.pv = 50;
                    pirate.maxpv = 50;
                    pirate.dmg = 10;
                    pirate.name = "pirate";
                    Enemy[] enemies = {pirate};
                    if (Combat(false,100, health, speed, enemies)==true)
                    {
                        Console.WriteLine("Vous réussissez à éliminer le pirate sans qu'il ne sonne l'alarme.");
                        Game.Transition<Quai3>();
                    }
                    else { Game.Transition<Menu>(); }
                    break;
                case "2":
                    Console.WriteLine("Vous vous cachez derrière une pile de caisses sans que le pirate ne vous remarque.");
                    Game.Transition<Quai3>();
                    break;
                default:
                    Console.WriteLine("Commande invalide.");
                    break;
            }
        }
    }
}
