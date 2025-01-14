﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace ProjetNarratif.Rooms
{
    internal class Réfectoire1 : Room
    {
        internal override string CreateDescription() {
            
            Console.WriteLine("Après avoir fini de manger, une alarme retentit : ");
            if (intro == false) {Console.ReadKey();}
            Console.WriteLine(@"
          _   _             _   _                  
     /\  | | | |           | | (_)                _  
    /  \ | |_| |_ ___ _ __ | |_ _  ___  _ __     (_) 
   / /\ \| __| __/ _ \ '_ \| __| |/ _ \| '_ \      
  / ____ \ |_| ||  __/ | | | |_| | (_) | | | |    _  
 /_/    \_\__|\__\___|_| |_|\__|_|\___/|_| |_|   (_)       
  _                          _                                          _    
 | |                        (_)                                        | |   
 | |     ___     __   ____ _ _ ___ ___  ___  __ _ _   _        ___  ___| |_  
 | |    / _ \    \ \ / / _` | / __/ __|/ _ \/ _` | | | |      / _ \/ __| __| 
 | |___|  __/     \ V / (_| | \__ \__ \  __/ (_| | |_| |     |  __/\__ \ |_  
 |______\___|      \_/ \__,_|_|___/___/\___|\__,_|\__,_|      \___||___/\__|                                                     
        _   _                      __                         _ _ _          
       | | | |                    /_/                        (_) | |         
   __ _| |_| |_ __ _  __ _ _   _  ___        __   _____ _   _ _| | | ___ ____
  / _` | __| __/ _` |/ _` | | | |/ _ \       \ \ / / _ \ | | | | | |/ _ \_  /
 | (_| | |_| || (_| | (_| | |_| |  __/_       \ V /  __/ |_| | | | |  __// / 
  \__,_|\__|\__\__,_|\__, |\__,_|\___( )       \_/ \___|\__,_|_|_|_|\___/___|                          
    __                  | |          |/    _                       __     _ _       _                       
   /_/                  |_|               (_)                     /_/    | (_)     | |                      
   _____   ____ _  ___ _   _  ___ _ __     _ _ __ ___  _ __ ___   ___  __| |_  __ _| |_ ___ _ __ ___ ______ 
  / _ \ \ / / _` |/ __| | | |/ _ \ '__|   | | '_ ` _ \| '_ ` _ \ / _ \/ _` | |/ _` | __/ _ \ '_ ` _ \______|
 |  __/\ V / (_| | (__| |_| |  __/ |      | | | | | | | | | | | |  __/ (_| | | (_| | ||  __/ | | | | |      
  \___| \_/ \__,_|\___|\__,_|\___|_|      |_|_| |_| |_|_| |_| |_|\___|\__,_|_|\__,_|\__\___|_| |_| |_|      
");
            
            
            Console.WriteLine("Le message se coupe, et une musique enfantine se met à jouer.");
            if (intro == false) { Console.ReadKey(); }
            Console.ForegroundColor = ConsoleColor.Green;
            Console.Clear();
            Console.WriteLine(@"<???> : BONJOUR ! BONJOUR ! 

<???> : Si vous entendez CECI, c'est que votre message d'urgence BEAUCOUP TROP BRUYANT vient de se faire INTERROMPRE,
et que CE vaisseau sera en MA possession dans QUELQUES MINUTES ! 

<Mercurius> : ET OUI, vous aurez aujourd'hui le BONHEUR de vous faire ABORDER par 
le pirate le plus CHARISMATIQUE du secteur, le fameux MERCURIUS !
<Mercurius> : À TOUT DE SUITE !");
            Console.ResetColor();
            return @"Il y a probablement des nacelles de secours au niveau du quai de lancement.
Pour y aller, vous pouvez essayer de passer par la salle des communications, l'infirmerie, le À couloir ouest, ou le dortoir.";
        }
        internal override string CreateOptions() =>
@"[1] Retourner au dortoir
[2] Passer par la salle des communications
[3] Passer par l'infirmerie
[4] Passer par le couloir ouest";


        
        internal override void ReceiveChoice(string choice)
        {
            Room.intro = true;
            switch (choice)
            {
                case "1":
                    Console.WriteLine("Vous retournez sur vos pas et entrez dans le dortoir.");
                    Game.Transition<Dortoir2>();
                    break;
                case "2":
                    Console.WriteLine("La porte de la salle des communications nécessite un code : ");
                    int code=0;
                    try { code = Convert.ToInt32(Console.ReadLine()); }
                    catch { Console.WriteLine("Le code est invalide !"); }
                    if (code == 3952)
                    {
                        Console.WriteLine("Vous rentrez le code et entrez dans la pièce.");
                        Game.Transition<Communications>();
                    }
                    else { Console.WriteLine("Vous entrez le code, mais il est incorrect et la porte reste fermée. "); }
                    break;
                case "3":
                    Console.WriteLine("Vous vous dirigez vers l'infirmerie.");
                    Game.Transition<Infirmerie1>();
                    break;
                case "4":
                    Console.WriteLine("Vous vous dirigez vers le couloir ouest. ");
                    Game.Transition<CouloirO>();
                    break;
                default:
                    Console.WriteLine("Commande invalide.");
                    break;
            }
        }
    }
}
