using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjetNarratif.Rooms
{
    internal class Phone : Room
    {     
        internal override string CreateDescription() =>
@"Tu te rapproches du téléphone. C'est un vieux filaire comme on n'en voit plus de nos jours.
Tu peux écouter les [messages].
Tu peux essayer de faire un [appel].
Tu peux fouiller le [bureau] au cas où il y ait quelque chose.
Tu peux retourner au milieu de la pièce [blanche]
";
    
    internal override void ReceiveChoice(string choice)
    {
            switch (choice)
            {
                case "messages":
                    Console.WriteLine("<???> : Sbeorp Elro Vtpnx, Orzkz Gzne Ulto, Hfka Qdlwg Xyvtcg Cmige Ulmue");
                    try { choice = Console.ReadLine(); }
                    catch { break; }
                    if (choice == "cheval" || choice == "CHEVAL") 
                    { 
                        Console.WriteLine("<???> : Quatre Cent Vingt, Trois Cent Sept, Huit Mille Quatre Vingt Seize"); 
                    }
                    else
                    {
                        Console.WriteLine("Tu ne comprends pas ces mots, ils sont probablements cryptés");
                        Console.WriteLine("Après quelques instants, le message se coupe.");
                    }
                    break;
                case "appel":
                    num: Console.WriteLine("Quel numéro voulez vous appeler ?");
                    try { choice = Console.ReadLine(); }
                    catch { goto num; }
                    switch (choice) {
                        case "911":
                            Console.WriteLine("Tu parviens à atteindre quelqu'un, mais personne ne peut t'aider.");
                            break;
                        case "420 307 8096":
                        case "(420) 307 8096":
                        case "420 307-8096":
                        case "(420) 307-8096":
                            Console.WriteLine("Tu entends un bruit sec, un des murs se déplace et permet d'accéder à une autre pièce, cette fois complètement rouge.");
                            White.progression++;
                            break;
                        default: Console.WriteLine("Rien ne se passe.");break;
                    }
                    break;
                case "bureau":
                    Console.WriteLine("Il y a un dessin d'un CHEVAL sous le téléphone.");
                    break;
                case "blanche":
                    Console.WriteLine("Tu retournes au milieu de la salle blanche.");
                    Game.Transition<White>();
                    break;
                default:
                    Console.WriteLine("Commande invalide.");
                    break;
            }
        }
    }
}
