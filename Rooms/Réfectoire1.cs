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
            Console.WriteLine("ATTENTION : LE VAISSEAU EST ATTAQUÉ. VEUILLEZ ÉVACUER IMMÉDIATE-.\r\n");
            Console.ReadKey();
            Console.WriteLine("Le message se coupe, et une musique enfantine se met à jouer.");
            Console.ReadKey();
            Console.WriteLine(@"<???> : BONJOUR ! BONJOUR ! 

Si vous entendez CECI, c'est que votre message d'urgence BEAUCOUP TROP BRUYANT vient de se faire INTERROMPRE,
et que CE vaisseau sera en MA possession dans QUELQUES MINUTES ! 

ET OUI, vous auriez aujourd'hui le BONHEUR de vous faire ABORDER par 
le pirate le plus CHARISMATIQUE du secteur, le GRAND CHAOTIQUE !
<???> : À TOUT DE SUITE !");
            Console.ReadKey();
            Console.WriteLine(@"
Il y a probablement des nacelles de secours dans le quai de lancement.
Pour y aller, vous pouvez essayer de passer par la salle de communications [1],
retourner au dortoir [2], aller à l'infirmerie [3],
ou bien passer par le couloir ouest [4] ");
            return "";
        }
            


        internal override void ReceiveChoice(string choice)
        {
            switch (choice)
            {
                case "1":
                    Console.WriteLine("Vous essayer d'ouvrir la porte, mais le code a été changé par les pirates ");
                    break;
                case "2":
                    Console.WriteLine("Pas implémenté");
                    break;
                case "3":
                    Console.WriteLine("Vous vous dirigez vers l'infirmerie. ");
                    break;
                case "4":
                    Console.WriteLine("Vous vous dirigez vers le couloir ouest. ");
                    break;
            }
        }
    }
}
