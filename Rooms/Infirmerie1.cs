using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjetNarratif.Rooms
{
    internal class Infirmerie1 : Room
    {
        internal override string CreateDescription() =>
            @"Vous êtes dans l'infirmerie. 
Tous les patients sont déjà partis, mais il en reste un tout au fond de la salle avec qui vous pouvez parler [1].
Vous pouvez aussi essayer de trouver quelque chose d'utile dans l'armoire [2] ou le bureau [3]. 
Sinon, vous pouvez passer par le couloir ouest [4].";
        internal override void ReceiveChoice(string choice)
        {
            switch (choice)
            {
                case "1":
                    Console.WriteLine("Le dernier patient remue, et se met à parler d'une voix très grave :");
                    Console.ReadKey();
                    Console.WriteLine("<Patient> : C'est les androides qui ont fait ça ! Ils nous volent nos travails !");
                    Console.ReadKey();
                    Console.WriteLine("Vous lui proposez de partir avec vous, mais il ne semble pas vous comprendre.");
                    break;
                case "2":
                    Console.WriteLine("Vous ouvrez l'armoire où se trouve quelques bandages légers");
                    break;
                case "3":
                    Console.WriteLine("Il ne reste rien d'utile sur le bureau, mais vous trouvez un tournevis dans un des tiroirs.");
                    if (inventory.Count <= 5)
                    {
                        inventory.Add("tourne-vis");
                    }
                    else { 
                        Console.WriteLine("Vous n'avez plus de place dans votre inventaire, alors vous le remettez là où vous l'avez trouvé");
                    }
                    break;
                case "4":
                    Console.WriteLine("Vous prenez la porte à votre gauche et rentrez dans le couloir ouest");
                    Game.Transition<SalleExercice>();
                    break;
                default:
                    Console.WriteLine("Commande invalide.");
                    break;
            }
        }
    }
}
