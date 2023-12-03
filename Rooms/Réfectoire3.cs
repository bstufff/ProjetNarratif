using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjetNarratif.Rooms
{
    internal class Réfectoire3:Room
    {
        internal override string CreateDescription()
        {
            return @"Ceux qui étaient en train de manger dans le réfectoire il y a quelques instants sont tous partis.
Pour aller vers le quai de lancement, vous pouvez essayer de passer par la salle des communications, l'infirmerie, ou le couloir ouest.";
        }
        internal override string CreateOptions()
        {
            return @"[1] Passer par la salle des communications
[2] Passer par l'infirmerie
[3] Passer par le couloir ouest";
        }
        internal override void ReceiveChoice(string choice)
        {
            switch (choice)
            {
                case "1":
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
                case "2":
                    Console.WriteLine("Vous vous dirigez vers l'infirmerie.");
                    Game.Transition<Infirmerie1>();
                    break;
                case "3":
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
