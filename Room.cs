using System.Diagnostics;
using System.Media;
using static ProjetNarratif.Room;

namespace ProjetNarratif
{
    internal abstract class Room
    {
        internal abstract string CreateDescription();
        public static List<Item> inventory = new List<Item>();
        public static int dmg = 15;
        public static byte speed = 3;
        public static Item badge,lunch,tournevis,briquet,détergent,bandages,pistoletclou,pistoletneut,fusil;
        public struct Enemy {
            public int pv;
            public int maxpv;
            public int dmg;
            public string name;
        }
        public struct Item {
            public int id;
            public int quantity;
            public string name;
            public string description;
        }

        static void HPBar(int hp, int maxhp, int type) {
            Console.Write("PV : [");
            for (int i = 0; i < maxhp; i = i + 10)
            {
                if (hp > i)
                {
                    switch (type) {
                        case 0:
                            Console.ForegroundColor = ConsoleColor.Green;
                            break;
                        case 1:
                            Console.ForegroundColor = ConsoleColor.Red;
                            break;
                    }
                }
                Console.Write("\u25A0");
                Console.ForegroundColor = ConsoleColor.Gray;
            }
            Console.WriteLine($"] {hp} / {maxhp}");
        }
        public bool Combat(bool priority,int _HP, int _DMG, int _speed, Enemy[] _enemies)
        {
            Console.Clear();
            SoundPlayer battle = new SoundPlayer(Path.Combine(Environment.CurrentDirectory + @"\battle.wav"));
            battle.PlayLooping();
            int MaxHP = _HP;
            bool désinfectant = false;
            int choix, action=0;
            Stopwatch timer = new Stopwatch();
            Random rnd = new Random();
            int alive = _enemies.Length;
            if (priority == true)
            {
                action = 1;
                Console.WriteLine("Vous prenez l'ennemi par suprise et vous attaquez en premier.");
            }
            while (alive > 0)
            {
                if (_HP <= 0)
                {
                    Console.WriteLine("Vous êtes mort !");
                    battle.Stop();
                    return false;
                }
                timer.Reset();
                string entry;
                
                HPBar(_HP, MaxHP, 0);
                
                switch (action)
                {
                    case 0:
                        int ind = rnd.Next(0, _enemies.Length);
                        timer.Start();
                        Console.WriteLine("Le {0} attaque ! \nVous avez {1} secondes pour faire une [roulade] pour éviter !", _enemies[ind].name, _speed);
                        entry = Console.ReadLine();
                        timer.Stop();
                        if (timer.ElapsedMilliseconds <= (1000 * _speed) && entry == "roulade")
                        {
                            Console.WriteLine("Attaque évitée !");
                        }
                        else
                        {
                            Console.WriteLine("L'attaque vous a touché ! Vous avez perdu {0} pv", _enemies[ind].dmg);
                            _HP = _HP - _enemies[ind].dmg;
                        }
                        action = 1;
                        break;
                    case 1:
                        Console.WriteLine("Quel ennemi voulez vous cibler ?");
                    choix: int x = 0;
                        foreach (Enemy enemy in _enemies)
                        {
                            Console.Write("Le {0} [{1}] PV: ", _enemies[x].name, x + 1);
                            HPBar(enemy.pv, enemy.maxpv, 1);
                            x++;
                        }
                        try { choix = Convert.ToInt32(Console.ReadLine()); }
                        catch { Console.WriteLine("Valeur invalide !"); goto choix; }
                        if (_enemies[choix - 1].pv <= 0)
                        {
                            Console.WriteLine("Cet ennemi est déja hors de combat !");
                            goto choix;
                        }
                        timer.Restart();
                        timer.Start();
                        Console.WriteLine("Vous avez {0} secondes pour [attaquer] ou utiliser un [objet] !", _speed);
                        entry = Console.ReadLine();
                        timer.Stop();
                        if (timer.ElapsedMilliseconds <= (1000 * _speed) && entry == "attaquer")
                        {
                            Console.WriteLine("Votre attaque a touché l'ennemi et a fait {0} dégats !", _DMG);
                            _enemies[choix - 1].pv -= _DMG;
                            if (_enemies[choix - 1].pv <= 0)
                            {
                                _enemies[choix - 1].pv = 0;
                                Console.WriteLine("");
                                alive--;
                            }
                        }
                        else if (timer.ElapsedMilliseconds <= (1000 * _speed) && entry == "objet")
                        {
                            Console.WriteLine("Inventaire : \n====================");
                            foreach (Room.Item item in Room.inventory)
                            {
                                Console.WriteLine($"[{item.name}] x {item.quantity} : {item.description}");
                            }
                            Console.WriteLine("Quel objet voulez-vous utiliser ?");
                            string chosen = Console.ReadLine();
                            switch (chosen)
                            {
                                case "badge":
                                case "Badge":
                                    Console.WriteLine($"Vous montrez le badge au {_enemies[choix-1].name}, mais rien ne se passe.");
                                    break;
                                case "lunch":
                                case "Lunch":
                                    _HP += Heal(_HP, MaxHP, 10, "Vous mangez la moitié du lunch et regagnez {0} PV.");
                                    break;
                                case "tournevis":
                                case "Tournevis":
                                    Console.WriteLine($"Vous frappez le {_enemies[choix-1].name} et il perd 15 PV !");
                                    _enemies[choix - 1].pv -= 15;
                                    if (_enemies[choix - 1].pv <= 0)
                                    {
                                        _enemies[choix - 1].pv = 0;
                                        Console.WriteLine("");
                                        alive--;
                                    }
                                    break;
                                case "briquet":
                                case "Briquet":
                                    if (désinfectant == true) {
                                        Console.WriteLine($"Vous brûlez le liquide en dessous du {_enemies[choix - 1].name}, lui infligant 60 dégats!");
                                        _enemies[choix - 1].pv -= 60;
                                        if (_enemies[choix - 1].pv <= 0)
                                        {
                                            _enemies[choix - 1].pv = 0;
                                            Console.WriteLine("");
                                            alive--;
                                        }
                                    }
                                    else
                                    {
                                        Console.WriteLine($"Vous réussissez à créer une flammèche qui brûle le {_enemies[choix - 1].name} et il perd 10 pv");
                                        _enemies[choix - 1].pv -= 10;
                                        if (_enemies[choix - 1].pv <= 0)
                                        {
                                            _enemies[choix - 1].pv = 0;
                                            Console.WriteLine("");
                                            alive--;
                                        }
                                    }
                                    break;
                                case "Désinfectant":
                                case "désinfectant":
                                    Console.WriteLine("Vous répandez le liquide sur le sol en dessous de vos ennemis.");
                                    break;
                                case "Bandages":
                                case "bandages":
                                case "bandage":
                                case "Bandage":
                                    _HP += Heal(_HP, MaxHP, 15, "Vous utilisez un bandage et regagnez {0} PV.");
                                    break;
                                case "Pistolet à clou":
                                case "Pistolet a clou":
                                case "pistolet à clou":
                                case "pistolet a clou":
                                    Console.WriteLine($"Vous tirez un clou sur le {_enemies[choix - 1].name} et il perd 30 PV !");
                                    _enemies[choix - 1].pv -= 30;
                                    if (_enemies[choix - 1].pv <= 0)
                                    {
                                        _enemies[choix - 1].pv = 0;
                                        Console.WriteLine("");
                                        alive--;
                                    }
                                    break;
                                case "Pistolet Neutralisant":
                                case "pistolet neutralisant":
                                case "Pistolet neutralisant":
                                case "pistolet Neutralisant":
                                    Console.WriteLine($"Vous tirez sur le {_enemies[choix - 1].name} et il perd 10 PV !");
                                    _enemies[choix - 1].pv -= 10;
                                    if (_enemies[choix - 1].pv <= 0)
                                    {
                                        _enemies[choix - 1].pv = 0;
                                        Console.WriteLine("");
                                        alive--;
                                    }
                                    Console.WriteLine($"Le {_enemies[choix - 1  ].name} est affaibli !");
                                    _enemies[choix - 1].dmg -= 10;
                                    if (_enemies[choix - 1].dmg <= 0)
                                    {
                                        _enemies[choix - 1].dmg = 0;
                                        Console.WriteLine("");
                                    }
                                    break;
                                case "fusil":
                                case "Fusil":
                                    Console.WriteLine($"Vous tirez sur le {_enemies[choix - 1].name} et il perd 30 PV !");
                                    _enemies[choix - 1].pv -= 30;
                                    if (_enemies[choix - 1].pv <= 0)
                                    {
                                        _enemies[choix - 1].pv = 0;
                                        Console.WriteLine("");
                                        alive--;
                                    }
                                    break;
                            }
                        }
                        else
                        {
                            Console.WriteLine("L'ennemi a profité de votre erreur pour attaquer et fait {0} dégats !", _enemies[choix - 1].dmg);
                            _HP -= _enemies[choix - 1].dmg;
                        }
                        action = 0;
                        break;
                }
                Thread.Sleep(rnd.Next(500, 1000));
                Console.Clear();
            }
            Console.WriteLine("Vous avez gagné !");
            battle.Stop();
            SoundPlayer player = new SoundPlayer(Path.Combine(Environment.CurrentDirectory + @"\ost.wav"));
            player.PlayLooping();
            return true;
        }
        static int Heal(int HP, int Max, int heal, string message) {
            if (HP + heal <= Max)
            {
                Console.WriteLine(message,heal);
                return heal;
            }
            else if (HP <= Max)
            {
                Console.WriteLine(message, Max - HP);
                return Max-HP;
            }
            else
            {
                Console.WriteLine("Vous ne pouvez pas vous soigner plus que ça !");
                return 0;
            }
        }
        internal abstract void ReceiveChoice(string choice);

    }
}
