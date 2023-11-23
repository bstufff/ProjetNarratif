using System.Diagnostics;
using System.Media;
namespace ProjetNarratif
{
    internal abstract class Room
    {
        internal abstract string CreateDescription();
        public static List<string> inventory = new List<string>();
        public int dmg = 15;
        public struct Enemy {
            public int pv;
            public int dmg;
            public string name;
        }



        public bool Combat(bool priority,int _HP, int _DMG, int _heal, int _speed, Enemy[] _enemies)
        {
            SoundPlayer battle = new SoundPlayer(Path.Combine(Environment.CurrentDirectory + @"\battle.wav"));
            battle.PlayLooping();
            
            int MaxHP = _HP;
            int choix, action=0;
            Stopwatch timer = new Stopwatch();
            Random rnd = new Random();
            int alive = _enemies.Length;
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
                if (priority==true) {
                    action = 1;
                }
                Console.WriteLine("Vous avez {0} pv ", _HP);
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
                            Console.WriteLine("Le {0} [{1}] PV:{2} //// ", _enemies[x].name, x + 1, _enemies[x].pv);
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
                        Console.WriteLine("Vous avez {0} secondes pour [attaquer] ou vous [soigner] !", _speed);
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
                        else if (timer.ElapsedMilliseconds <= (1000 * _speed) && entry == "soigner")
                        {
                            if (_heal + _HP > MaxHP)
                            {
                                _HP = MaxHP;
                                Console.WriteLine("Vous récupérez {0} pv !", _heal + _HP - MaxHP);
                            }
                            else
                            {
                                _HP += _heal;
                                Console.WriteLine("Vous récupérez {0} pv !", _heal);
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

        internal abstract void ReceiveChoice(string choice);

    }
}
