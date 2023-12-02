using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjetNarratif.Rooms
{
    internal class Cockpit : Room
    {
        internal override string CreateDescription()
        {
            return @"<MERCURIUS> : Ah, mais QUI avons nous là ? JE ne m'attendais point à ce que QUELQU'UN arrive JUSQU'ICI sans se faire REPÉRER.
<MERCURIUS> : Cependant, tu arrives BIEN TROP TARD, car j'ai déjà pris CONTRÔLE de ce vaisseau. Et je ne compte PAS laisser QUI QUE SE SOIT interférer avec mes plans !
<MERCURIUS> : HÉ ! GÉRARD ! IL EN RESTE UN JUSTE ICI !
Vous voyez un pirate énorme se lever avant de se lancer sur vous.";
        }
        internal override string CreateOptions()
        {
            return @"[1] Affronter Gérard
[2] Fuir";
        }
        internal override void ReceiveChoice(string choice)
        {
            switch (choice) {
                case "1":
                    Enemy gérard;
                    gérard.pv = 150;
                    gérard.accuracy = 95;
                    gérard.maxpv = 150;
                    gérard.dmg = 30;
                    gérard.name = "Gérard";
                    Enemy[] _enemies = { gérard };
                    if (Combat(false, health, dmg, speed, _enemies))
                    {
                        Console.WriteLine("Vous voyez le géant tomber à terre alors que Mercurius s'enfuit vers le réfectoire.");
                        Console.ReadKey();
                        Game.Transition<Réfectoire2>();
                    }
                    break;
                case "2":
                    Console.WriteLine("Vous essayer de fuir mais PERSONNE N'ÉCHAPPE À GÉRARD !");
                    goto case "1";
                default:
                    Console.WriteLine("Commande invalide.");
                    break;
            }
            
        }
    }
}