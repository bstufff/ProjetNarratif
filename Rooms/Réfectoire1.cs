using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjetNarratif.Rooms
{
    internal class Réfectoire1 : Room
    {
        internal override string CreateDescription() {
            Console.WriteLine("Après avoir fini de manger, une alarme retentit : ");
            Console.ReadKey();
            Console.WriteLine(@"   _     _____   _____   ___   _  _   _____   ___    ___    _  _     _    
  /_\   |_   _| |_   _| | __| | \| | |_   _| |_ _|  / _ \  | \| |   (_)   
 / _ \    | |     | |   | _|  | .` |   | |    | |  | (_) | | .` |    _    
/_/ \_\   |_|     |_|   |___| |_|\_|   |_|   |___|  \___/  |_|\_|   (_)   

 _      ___    __   __    _     ___   ___   ___   ___     _     _   _     ___   ___   _____   
| |    | __|   \ \ / /   /_\   |_ _| / __| / __| | __|   /_\   | | | |   | __| / __| |_   _|  
| |__  | _|     \ V /   / _ \   | |  \__ \ \__ \ | _|   / _ \  | |_| |   | _|  \__ \   | |    
|____| |___|     \_/   /_/ \_\ |___| |___/ |___/ |___| /_/ \_\  \___/    |___| |___/   |_|    

   _     _____   _____     _      ___    _   _    __       __   __  ___   _   _   ___   _      _      ___   ____ 
  /_\   |_   _| |_   _|   /_\    / _ \  | | | |  /_/       \ \ / / | __| | | | | |_ _| | |    | |    | __| |_  / 
 / _ \    | |     | |    / _ \  | (_) | | |_| | | -<  _     \ V /  | _|  | |_| |  | |  | |__  | |__  | _|   / /  
/_/ \_\   |_|     |_|   /_/ \_\  \__\_\  \___/  |__< (_)     \_/   |___|  \___/  |___| |____| |____| |___| /___|  

  __ __   __    _      ___   _   _   ___   ___     ___   __  __   __  __    __  ___    ___     _     _____   ___       
 /_/ \ \ / /   /_\    / __| | | | | | __| | _ \   |_ _| |  \/  | |  \/  |  /_/ |   \  |_ _|   /_\   |_   _| | __| 
| -<  \ V /   / _ \  | (__  | |_| | | _|  |   /    | |  | |\/| | | |\/| | | -< | |) |  | |   / _ \    | |   | _|   ***
|__<   \_/   /_/ \_\  \___|  \___/  |___| |_|_\   |___| |_|  |_| |_|  |_| |__< |___/  |___| /_/ \_\   |_|   |___|  
");
            Console.ReadKey();
            return @"
Le message se coupe, et une musique enfantine se met à jouer.
<???> : BONJOUR ! BONJOUR ! 

<???> : Si vous entendez CECI, c'est que votre message d'urgence BEAUCOUP TROP BRUYANT vient de se faire INTERROMPRE,
et que CE vaisseau sera en MA possession dans QUELQUES MINUTES ! 

<???> : ET OUI, vous aurez aujourd'hui le BONHEUR de vous faire ABORDER par 
le pirate le plus CHARISMATIQUE du secteur, MERCURIUS !
<???> : À TOUT DE SUITE !

Il y a probablement des nacelles de secours dans le quai de lancement.
Pour y aller, vous pouvez essayer de passer par la salle des communications, l'infirmerie, le couloir ouest, ou le dortoir.";
        }
        internal override string CreateOptions() =>
@"[1] Retourner au dortoir
[2] Passer par la salle des communications
[3] Passer par l'infirmerie
[4] Passer par le couloir ouest";



        internal override void ReceiveChoice(string choice)
        {
            switch (choice)
            {
                case "2":
                    Console.WriteLine("La porte de la salle des communications nécessite un code : ");
                    int code;
                    try { code = Convert.ToInt32(Console.ReadLine()); }
                    catch { Console.WriteLine("Le code est invalide !"); }
                    if (choice == "3952")
                    {
                        Console.WriteLine("Vous rentrez le code et entrez dans la pièce.");
                        Game.Transition<Communications>();
                    }
                    else { Console.WriteLine("Vous entrez le code, mais il est incorrect et la porte reste fermée. "); }
                    break;
                case "1":
                    Console.WriteLine("Vous retournez sur vos pas et entrez dans le dortoir.");
                    Game.Transition<Dortoir2>();
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
