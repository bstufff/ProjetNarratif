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
            return @"Après avoir fini de manger, une alarme retentit : 
ATTENTION : LE VAISSEAU EST ATTAQUÉ. VEUILLEZ ÉVACUER IMMÉDIATE-
Le message se coupe, et une musique enfantine se met à jouer.
<???> : BONJOUR ! BONJOUR ! 

Si vous entendez CECI, c'est que votre message d'urgence BEAUCOUP TROP BRUYANT vient de se faire INTERROMPRE,
et que CE vaisseau sera en MA possession dans QUELQUES MINUTES ! 

ET OUI, vous auriez aujourd'hui le BONHEUR de vous faire ABORDER par 
le pirate le plus CHARISMATIQUE du secteur, le FOU !
<???> : À TOUT DE SUITE !

Il y a probablement des nacelles de secours dans le quai de lancement.
Pour y aller, vous pouvez essayer de passer par la salle de communications [1],
retourner au dortoir [2], aller dans l'infirmerie [3],
ou bien passer par le couloir ouest [4] ";
        }
            


        internal override void ReceiveChoice(string choice)
        {
            switch (choice)
            {
                case "1":
                    Console.WriteLine("La porte de la salle de communications nécessite un code : ");
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
                case "2":
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
