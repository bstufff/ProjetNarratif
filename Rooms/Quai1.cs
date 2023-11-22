﻿using System;
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
            
            return @"Vous arrivez enfin devant les quais de lancement juste à temps pour voir la dernière nacelle partir vers la planète la plus proche.

Les pirates de ce secteur ne sont pas des plus cléments, alors le seul moyen d'arriver sain et sauf à votre destination est de reprendre contrôle du vaisseau.

Vous récupérez un briquet utilisable dans une poubelle quand tout à coup, vous entendez un pirate arriver de la salle des machines. 
Vous pouvez essayer de l'éliminer rapidement [1] ou de vous cacher [2].";
            
        }
        internal override void ReceiveChoice(string choice)
        {
            inventory.Add("briquet");
            switch (choice)
            {
                case "1":
                    Console.WriteLine("Vous sautez sur le pirate et vous commencez à l'attaquer !");
                    Enemy pirate;
                    pirate.pv = 25;
                    pirate.dmg = 10;
                    pirate.name = "pirate";
                    Enemy[] enemies = {pirate};
                    if (Combat(false,50, 15, 10, 3, enemies)==true)
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