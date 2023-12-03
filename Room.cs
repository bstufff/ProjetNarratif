using System.Diagnostics;
using System.Media;
using static ProjetNarratif.Room;

namespace ProjetNarratif
{
    internal abstract class Room
    {
        internal abstract string CreateDescription();
        public static List<Item> inventory = new List<Item>();
        public static int dmg = 15, health=100;
        public static byte speed = 4;
        public static bool intro = false, first = true;
        public static Item badge = new Item(0, 1, "Badge", "Un badge permettant d'accéder aux zones réservées à l'équipage.");
        public static Item tournevis = new Item(2, 1, "Tournevis", "Un outil bien utile pour tout ce qui concerne des vis. Fait 15 DMG");
        public static Item briquet = new Item(3,1,"Briquet", "Produit une flammèche.");
        public static Item pistoletclou = new Item(6, 6, "Pistolet à clou", "Un pistolet à clou. 25 DMG 6 Munitions.");
        public static Item lunch = new Item(1, 2, "Lunch", "Le repas oublié de quelqu'un. Soigne 30 PV.");
        public static Item détergent = new Item(4,1, "Désinfectant", "Liquide normalement utilisé pour se nettoyer les mains. Très inflammable.");
        public static Item bandages = new Item(5,5, "Bandages", "Bon pour les petites blessures. Soigne 15 PV.");
        public static Item pistoletneut = new Item(7,2, "Pistolet neutralisant", "Permet de paralyser un ennemi, faisant 10 dégats et réduisant les dégats du receveur.");
        public static Item fusil = new Item(8, 10, "Fusil", "Une arme très efficace, 30 DMG 10 munitions.");
        public static Item adrénaline = new Item(9, 1, "Seringue d'adrénaline", "Augmente la puissance de vos tirs mais réduit vos PV.");
        public struct Enemy {
            public int accuracy;
            public int pv;
            public int maxpv;
            public int dmg;
            public string name;
        }
        public class Item {
            public int id;
            public int quantity;
            public string name="NoName";
            public string description="";
            public Item(int id1, int quantity1, string name1, string description1)
            {
                id=id1;
                quantity=quantity1;
                name=name1;
                description=description1;
            }
            public void SetQuantity(int newQuantity) { 
                quantity = newQuantity;
            }
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
                Console.WriteLine("Vous prenez l'ennemi par suprise et vous attaquez en premier !");
            }
            while (alive > 0)
            {
                choix:
                if (_HP <= 0)
                {
                    Console.WriteLine("Vous êtes mort !");
                    Mort();
                    battle.Stop();
                    return false;
                }
                timer.Reset();
                string entry; 
                
                HPBar(_HP, MaxHP, 0);
                
                switch (action)
                {
                    case 0:
                        int ind;
                        do
                        {
                            ind = rnd.Next(0, _enemies.Length);
                        }
                        while (_enemies[ind].pv == 0);
                        timer.Start();
                        string[] ripostes = {"rouler","esquiver", "plonger", "bloquer" };
                        string current = ripostes[rnd.Next(0,4)];
                        Console.WriteLine("Le {0} attaque ! \nVous avez {1} secondes pour [{2}] !", _enemies[ind].name, _speed,current);
                        entry = Console.ReadLine();
                        timer.Stop();

                        if (timer.ElapsedMilliseconds <= (1000 * _speed) && entry == current)
                        {
                            Console.WriteLine("Vous évitez son attaque !");
                        }
                        else if (rnd.Next(0, 100) > _enemies[ind].accuracy) {
                            Console.WriteLine($"Le {_enemies[ind].name} attaque, mais il vous manque !");
                        }
                        else
                        {
                            Console.WriteLine("L'attaque vous a touché ! Vous avez perdu {0} pv", _enemies[ind].dmg);
                            _HP = _HP - _enemies[ind].dmg;
                        }
                        action = 1;
                        break;
                    case 1:
                        if (_enemies.Length == 1) {
                            choix = 1;
                            Console.Write("[1] Le {0} ", _enemies[0].name);
                            HPBar(_enemies[0].pv, _enemies[0].maxpv, 1);
                            goto skip;
                        }
                        Console.WriteLine("Quel ennemi voulez vous cibler ?");
                        int x = 0;
                        foreach (Enemy enemy in _enemies)
                        {
                            Console.Write("[{0}] Le {1} ", x+1,_enemies[x].name);
                            HPBar(enemy.pv, enemy.maxpv, 1);
                            x++;
                        }
                        try { choix = Convert.ToInt32(Console.ReadLine()); }
                        catch { Console.WriteLine("Valeur invalide !");
                            Console.ReadKey();
                            Console.Clear();
                            goto choix;
                        }
                        if (_enemies[choix - 1].pv <= 0)
                        {
                            Console.WriteLine("Cet ennemi est déja hors de combat !");
                            Console.ReadKey();
                            Console.Clear();
                            goto choix;
                        }
                        timer.Restart();
                        timer.Start();
                        skip: Console.WriteLine("Vous avez {0} secondes pour [attaquer] ou utiliser un [objet] !", _speed);
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
                            if (Room.inventory.Count == 0) { 
                                Console.WriteLine("Vous n'avez pas d'objets sur vous !");
                            }
                            else { 
                            Console.WriteLine("Inventaire : \n====================");
                            
                            foreach (Item item in inventory)
                            {
                                if (item.quantity > 0) {
                                    Console.WriteLine($"[{item.name}] x {item.quantity} : {item.description}");
                                }
                            }
                            Console.Write("\nQuel objet voulez-vous utiliser ? "); 
                            Console.ForegroundColor = ConsoleColor.Red;
                            Console.WriteLine("(Vous n'êtes pas limité par le temps)");
                            Console.ResetColor();
                            string chosen = Console.ReadLine();
                                switch (chosen)
                                {
                                    case "badge":
                                    case "Badge":
                                        Console.WriteLine($"Vous montrez le badge au {_enemies[choix - 1].name}, mais rien ne se passe.");
                                        break;
                                    case "lunch":
                                    case "Lunch":
                                        _HP += Heal(_HP, MaxHP, 10, "Vous mangez la moitié du lunch et regagnez {0} PV.");
                                        lunch.SetQuantity(lunch.quantity - 1);
                                        if (lunch.quantity == 0)
                                        {
                                            Room.inventory.Remove(lunch);
                                        }
                                        break;
                                    case "tournevis":
                                    case "Tournevis":
                                        Console.WriteLine($"Vous frappez le {_enemies[choix - 1].name} et il perd 15 PV !");
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
                                        if (désinfectant == true)
                                        {
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
                                        détergent.SetQuantity(détergent.quantity - 1);
                                        désinfectant = true;
                                        if (détergent.quantity == 0)
                                        {
                                            Room.inventory.Remove(détergent);
                                        }
                                        break;
                                    case "Bandages":
                                    case "bandages":
                                    case "bandage":
                                    case "Bandage":
                                        _HP += Heal(_HP, MaxHP, 15, "Vous utilisez un bandage et regagnez {0} PV.");
                                        bandages.SetQuantity(bandages.quantity - 1);
                                        if (bandages.quantity == 0)
                                        {
                                            Room.inventory.Remove(bandages);
                                        }
                                        break;
                                    case "Pistolet à clou":
                                    case "Pistolet a clou":
                                    case "pistolet à clou":
                                    case "pistolet a clou":
                                        Console.WriteLine($"Vous tirez un clou sur le {_enemies[choix - 1].name} et il perd 25 PV !");
                                        _enemies[choix - 1].pv -= 25;
                                        if (_enemies[choix - 1].pv <= 0)
                                        {
                                            _enemies[choix - 1].pv = 0;
                                            Console.WriteLine("");
                                            alive--;
                                        }
                                        pistoletclou.SetQuantity(pistoletclou.quantity-1);
                                        if (pistoletclou.quantity == 0) {
                                            Room.inventory.Remove(pistoletclou);
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
                                        Console.WriteLine($"Le {_enemies[choix - 1].name} est affaibli !");
                                        _enemies[choix - 1].dmg -= 10;
                                        if (_enemies[choix - 1].dmg <= 0)
                                        {
                                            _enemies[choix - 1].dmg = 0;
                                            Console.WriteLine("");
                                        }
                                        pistoletneut.SetQuantity(pistoletneut.quantity - 1);
                                        if (pistoletneut.quantity == 0)
                                        {
                                            Room.inventory.Remove(pistoletneut);
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
                                        fusil.SetQuantity(fusil.quantity - 1);
                                        if (fusil.quantity == 0)
                                        {
                                            Room.inventory.Remove(fusil);
                                        }
                                        break;
                                    case "adrénaline":
                                    case "Adrénaline":
                                    case "adrenaline":
                                    case "Adrenaline":
                                        Console.WriteLine($"Vous utilisez la seringue !");
                                        dmg = 35;
                                        _HP = _HP - 50;
                                        adrénaline.SetQuantity(adrénaline.quantity - 1);
                                        if (adrénaline.quantity == 0)
                                        {
                                            Room.inventory.Remove(adrénaline);
                                        }
                                        break;

                                }
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
            Console.WriteLine("Vous avez remporté le combat !");
            battle.Stop();
            health = _HP;
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
        static void Mort() {
            inventory.Clear();
            dmg = 15;
            health = 100;
            intro = false;
            first = true;
        }
        internal abstract void ReceiveChoice(string choice);

        internal abstract string CreateOptions();

    }
}
