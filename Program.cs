using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace bikari
{
    class Unit
    {
        public Unit(int t)
        {
            type = t;
            turn = true;
            set();
        }
        public int type { get; set; }
        public string name { get; set; }
        public double health { get; set; }
        public double damage { get; set; }
        public double defence { get; set; }
        private int extra_damage_percent { get; set; }
        public int gold_requierd { get; set; }
        public bool turn { get; set; }
        public double extra_damage()
        {
            Random random = new Random();
            int ran = random.Next(extra_damage_percent+10);
            if (ran <= 10)
            {
                return 0;
            }
            else
            {
                return damage * ((ran-10) / 100);
            }
        }
        private void set()
        {
            switch (type)
            {
                case 0:
                    name = "King";
                    health = 20000;
                    damage = 25;
                    defence = 50;
                    extra_damage_percent = 0;
                    gold_requierd = 0;
                    break;
                case 1:
                    name = "Archer";
                    health = 100;
                    damage = 20;
                    defence = 2;
                    extra_damage_percent = 10;
                    gold_requierd = 12;
                    break;
                case 2:
                    name = "Knight";
                    health = 1000;
                    damage = 35;
                    defence = 20;
                    extra_damage_percent = 37;
                    gold_requierd = 80;
                    break;
                case 3:
                    name = "Pikeman";
                    health = 650;
                    damage = 31;
                    defence = 15;
                    extra_damage_percent = 15;
                    gold_requierd = 35;
                    break;
                case 4:
                    name = "Sowrdman";
                    health = 800;
                    damage = 28;
                    defence = 25;
                    extra_damage_percent = 30;
                    gold_requierd = 60;
                    break;
                case 5:
                    name = "Crossbowman";
                    health = 300;
                    damage = 27;
                    defence = 4;
                    extra_damage_percent = 40;
                    gold_requierd = 30;
                    break;
                case 6:
                    name = "Spearman";
                    health = 200;
                    damage = 18;
                    defence = 5;
                    extra_damage_percent = 5;
                    gold_requierd = 8;
                    break;
            }
        }
        public bool attack(Unit defender)
        {
            var ex = this.extra_damage();
            var dam = (this.damage + ex);
            //Console.WriteLine("damage:" + damage);
            //Console.WriteLine("ext damage: " + ex);
            //Console.WriteLine("defence : " + defender.defence);
            //Console.WriteLine("alldamage: "+dam);
            defender.health -= dam-(dam*defender.defence/100);
            if (defender.health <= 0)
                return true;
            return false;
        }

    }
    class Army
    {
        public List<Unit> units;
        public double health { get; set; }
        public double damage { get; set; }
        public double defence { get; set; }
        public Army()
        {
            units = new List<Unit>();
        }
        public void refresh()
        {
            health = units.Sum<Unit>(un => un.health);
            damage = units.Sum<Unit>(un => un.damage);
            defence = units.Average<Unit>(un => un.defence);
        }
        public void next_turn()
        {
            for(int i = 0; i < this.units.Count; i++)
            {
                this.units[i].turn = true;
            }
        }
    }
    static class print
    {

        public static void All_unit()
        {
            Console.WriteLine("    King       Archer     Kinight    Pikeman    Swordman  Crossbowman  Spearman  ");
            Console.WriteLine("  type :(0)   type :(1)  type :(2)  type :(3)  type :(4)   type :(5)   type :(6) ");
            Console.WriteLine(" ð  ð  ð  ð      |\\         ____         A          ║         /|\\          \\/     ");
            Console.WriteLine(" | /\\  /\\ |      |-)->      \\§§/       (¶|          ║       <(-╬-}--       /\\     ");
            Console.WriteLine(" |/__\\/__\\|      |/          \\/          |         ╚╬╝        \\|/         /  \\    ");
            Console.WriteLine(" cannot train  Gold:(12)  Gold:(80)  Gold:(35)   Gold:(60)  Gold:(30)    Gold:(8) ");
            
        }
        public static void All_unit(player player)
        {
            king(player.king.health);
            for(int i = 1; i < 7; i++)
            {
                List<int> index = new List<int>();
                List<double> health = new List<double>();
                int counter = 0;
                for (int j = 0; j < player.army.units.Count;j++)
                {
                    if (player.army.units[j].type == i)
                    {
                        index.Add(j);
                        health.Add(player.army.units[j].health);
                        counter++;
                    }
                }
                if (counter != 0)
                    switch (i)
                    {

                        case 1:
                            Archers(counter, index, health);
                            break;
                        case 2:
                            Knights(counter, index, health);
                            break;
                        case 3:
                            Pikemen(counter, index, health);
                            break;
                        case 4:
                            Swordmen(counter, index, health);
                            break;
                        case 5:
                            Crossbowmen(counter, index, health);
                            break;
                        case 6:
                            Spearmen(counter, index, health);
                            break;

                    }
            }
        }
        public static void Archers(int No, List<int> index, List<double> health)
        {
            for (int i = 0; i < No; i++)

                Console.Write($" ({index[i]})   ");
            Console.WriteLine("\n");

            for (int i = 0; i < No; i++)
                Console.Write(" |\\    ");
            Console.WriteLine();

            for (int i = 0; i < No; i++)
                Console.Write(" |-)-> ");
            Console.WriteLine();

            for (int i = 0; i < No; i++)
                Console.Write(" |/    ");
            Console.WriteLine();
            for (int i = 0; i < No; i++)
                Console.Write($"H:{(int)health[i]}  ");
            Console.WriteLine("\n");
            print.line(1);
        }
        public static void Swordmen(int No, List<int> index, List<double> health)
        {
            for (int i = 0; i < No; i++)

                Console.Write($"  ({index[i]})  ");
            Console.WriteLine("\n");

            for (int i = 0; i < No; i++)
                Console.Write("   ║   ");
            Console.WriteLine();

            for (int i = 0; i < No; i++)
                Console.Write("   ║   ");
            Console.WriteLine();

            for (int i = 0; i < No; i++)
                Console.Write("  ╚╬╝  ");
            Console.WriteLine();
            for (int i = 0; i < No; i++)
                Console.Write($" H:{(int)health[i]} ");
            Console.WriteLine("\n");
            print.line(1);
        }
        public static void Knights(int No, List<int> index, List<double> health)
        {
            for (int i = 0; i < No; i++)

                Console.Write($"    ({index[i]})   ");
            Console.WriteLine("\n");

            for (int i = 0; i < No; i++)
                Console.Write("   ____   ");
            Console.WriteLine();

            for (int i = 0; i < No; i++)
                Console.Write("   \\§§/   ");
            Console.WriteLine();

            for (int i = 0; i < No; i++)
                Console.Write("    \\/    ");
            Console.WriteLine();
            for (int i = 0; i < No; i++)
                Console.Write($"  H:{(int)health[i]}  ");
            Console.WriteLine("\n");
            print.line(1);
        }
        public static void Pikemen(int No, List<int> index, List<double> health)
        {
            for (int i = 0; i < No; i++)

                Console.Write($"  ({index[i]})  ");
            Console.WriteLine("\n");

            for (int i = 0; i < No; i++)
                Console.Write("   A   ");
            Console.WriteLine();

            for (int i = 0; i < No; i++)
                Console.Write(" (¶|   ");
            Console.WriteLine();

            for (int i = 0; i < No; i++)
                Console.Write("   |   ");
            Console.WriteLine();
            for (int i = 0; i < No; i++)
                Console.Write($"H:{(int)health[i]}  ");
            Console.WriteLine("\n");
            print.line(1);
        }
        public static void Crossbowmen(int No, List<int> index, List<double> health)
        {
            for (int i = 0; i < No; i++)

                Console.Write($"  ({index[i]})   ");
            Console.WriteLine("\n");

            for (int i = 0; i < No; i++)
                Console.Write("  /|\\    ");
            Console.WriteLine();

            for (int i = 0; i < No; i++)
                Console.Write("<(-╬-}-- ");
            Console.WriteLine();

            for (int i = 0; i < No; i++)
                Console.Write("  \\|/    ");
            Console.WriteLine();
            for (int i = 0; i < No; i++)
                Console.Write($" H:{(int)health[i]}  ");
            Console.WriteLine("\n");
            print.line(1);
        }
        public static void Spearmen(int No, List<int> index, List<double> health)
        {
            for (int i = 0; i < No; i++)

                Console.Write($"   ({index[i]})  ");
            Console.WriteLine("\n");

            for (int i = 0; i < No; i++)
                Console.Write("    \\/   ");
            Console.WriteLine();

            for (int i = 0; i < No; i++)
                Console.Write("    /\\   ");
            Console.WriteLine();

            for (int i = 0; i < No; i++)
                Console.Write("   /  \\  ");
            Console.WriteLine();
            for (int i = 0; i < No; i++)
                Console.Write($"  H:{(int)health[i]}  ");
            Console.WriteLine("\n");
            print.line(1);
        }
        public static void print_Archer()
        {
            Console.WriteLine("  Archer ");
            Console.WriteLine(" type :(1)");
            Console.WriteLine("   |\\   ");
            Console.WriteLine("   |-)->");
            Console.WriteLine("   |/   ");
            Console.WriteLine(" Gold:(12)");
            
        }
        public static void Knight()
        {
            Console.WriteLine("  Kinight ");
            Console.WriteLine(" type :(2)");
            Console.WriteLine("   ____   ");
            Console.WriteLine("   \\§§/   ");
            Console.WriteLine("    \\/    ");
            Console.WriteLine(" Gold:(80)");

        }
        public static void Pikeman()
        {
            Console.WriteLine("  Pikeman  ");
            Console.WriteLine(" type :(3) ");
            Console.WriteLine("     A     ");
            Console.WriteLine("   (¶|     ");
            Console.WriteLine("     |     ");
            Console.WriteLine(" Gold:(35) ");

        }
        public static void Crossbowman()
        {
            Console.WriteLine(" Crossbowman ");
            Console.WriteLine("  type :(5)  ");
            Console.WriteLine("    /|\\      ");
            Console.WriteLine("  <(-╬-}--   ");
            Console.WriteLine("    \\|/      ");
            Console.WriteLine("  Gold:(30)  ");

        }
        public static void Spearman()
        {
            Console.WriteLine(" Spearman  ");
            Console.WriteLine(" type :(6) ");
            Console.WriteLine("    \\/     ");
            Console.WriteLine("    /\\     ");
            Console.WriteLine("   /  \\    ");
            Console.WriteLine("  Gold:(8) ");

        }
        public static void print_Swordman()
        {
            Console.WriteLine("  Swordman ");
            Console.WriteLine(" type :(4) ");
            Console.WriteLine("     ║     ");
            Console.WriteLine("     ║     ");
            Console.WriteLine("    ╚╬╝    ");
            Console.WriteLine(" Gold:(60) ");
        } 
        public static void king()
        {
            Console.WriteLine("   King     ");
            Console.WriteLine(" type :(0)  ");
            Console.WriteLine("ð  ð  ð  ð   ");
            Console.WriteLine("| /\\  /\\ |   ");
            Console.WriteLine("|/__\\/__\\|   ");
            Console.WriteLine("cannot train ");
        }
        public static void king(double health)
        {
            Console.WriteLine("   King    ");
            Console.WriteLine("   (-1)    ");
            Console.WriteLine("ð  ð  ð  ð ");
            Console.WriteLine("| /\\  /\\ |");
            Console.WriteLine("|/__\\/__\\|");
            Console.WriteLine($"  H:{(int)health}  ");
            line(1);
        }
        public static void line(int No)
        {
            for (int i = 0; i < No; i++)
            {
                for (int j = 0; j < 100; j++)
                    Console.Write("-");
                Console.WriteLine();
            }
        }
    }
    class player
    {
        public ConsoleColor ConsoleColor;
        
        public Unit king;
        public Army army;
        public string name { get; set; }
        public int gold_balance { get; set; }
        public int gold_turn { get; set; }
        public player()
        {
            king = new Unit(0);
            army = new Army();
        }
        
        public void train(int flag=0)
        {
            if (flag == 1)
            {
                chooseT();
            }
            else
            {
                //Ai select
            }
        }
        public bool attack(player defender, int flag = 0)
        {
            if (flag == 1)
            {
                return chooseA(defender);
            }
            else
            {
                ///
            }
            return Convert.ToBoolean(flag);
        }

        private void chooseT()
        {
            Console.WriteLine("choose unit to train :");
            Unit unit;
            for (int i = 1; i < 7; i++)
            {
                unit = new Unit(i);
                Console.Write(i + $".{unit.name}");
                for (int j = 0; j < 20 - unit.name.Length; j++)
                    Console.Write(" ");
                Console.Write($"({unit.gold_requierd})  ");
                if (this.gold_balance < unit.gold_requierd)
                    Console.Write("-not enough Gold-");
                Console.WriteLine();
            }
            bool flag = true;
            while (flag)
            {

                var input = Console.ReadLine();
                int comm;
                if (!Int32.TryParse(input, out comm) || comm < 1 || comm > 6)
                {
                    Console.WriteLine("wrong input please try again!");
                }
                else if (this.gold_balance < new Unit(comm).gold_requierd)
                {
                    Console.WriteLine("you dont have enough Gold choose another unit!");
                }
                else
                {

                    unit = new Unit(comm);
                    this.gold_balance -= unit.gold_requierd;
                    this.army.units.Add(unit);
                    flag = false;
                    Console.WriteLine(unit.name + " trained!!");
                }

            }
        }
        private bool chooseA(player defender)
        {
            int att = 0;
            int def = 0;
            while (true)
            {
                Console.WriteLine("choose one of your unit (index) (king cannot attack):");
                print.All_unit(this);
                bool check = Int32.TryParse(Console.ReadLine(), out att);
                if (att >= 0 && att < this.army.units.Count && check &&this.army.units[att].turn)
                {
                    break;
                }
                else if (att >= 0 && att < this.army.units.Count && check)
                {

                    Console.WriteLine("this unit have been attacked in current tuen");
                }
                else
                {
                    Console.WriteLine("wrong input please try again");
                }
            }
            Console.ForegroundColor = defender.ConsoleColor;
            print.All_unit(defender);
            Console.ForegroundColor = this.ConsoleColor;
            while (true)
            {
                Console.WriteLine("choose one of enemy unit to attack (index):");
                Console.WriteLine("you can attack king when all the unit was dead");
                bool check = Int32.TryParse(Console.ReadLine(), out def);
                if (check && def == -1 && defender.army.units.Count !=0)
                {
                    Console.WriteLine("enemy have unit , you must defeat them first!!");
                    Console.WriteLine("try again please");
                }
                else if (def >= -1 && def < defender.army.units.Count && check)
                {
                    break;
                }
                else
                {
                    Console.WriteLine("wrong input please try again");
                }
            }
            bool requset;
            if (def == -1)
            {
                requset = this.army.units[att].attack(defender.king);
            }
            else
            {
                requset = this.army.units[att].attack(defender.army.units[def]);
            }
            this.army.units[att].turn = false;
            if (requset)
            {
                Console.ForegroundColor = defender.ConsoleColor;
                Console.WriteLine($"{defender.name} {defender.army.units[def].name} killed");
                Console.ForegroundColor = this.ConsoleColor;

                defender.army.units.RemoveAt(def);
            }
            return requset;
            ///
        }


    }
    class Game
    {
        private player player1;
        private player player2;
        public Game(string p1name="AI-1",string p2name = "AI-2", int start_gold = 50,int start_turn_gold = 10,ConsoleColor color1=ConsoleColor.Blue,ConsoleColor color2=ConsoleColor.Red)
        {
            player1 = new player();
            player2 = new player();
            player1.gold_balance = player2.gold_balance = start_gold;
            player2.gold_turn = player1.gold_turn = start_turn_gold;
            player1.ConsoleColor = color1;
            player2.ConsoleColor = color2;
            player1.name = p1name;
            player2.name = p2name;
        }
        public void turn(player Current_player,player enemy)
        {
            Console.ForegroundColor = Current_player.ConsoleColor;
            Console.WriteLine(" --- " + Current_player.name + " turn ---");
            Console.WriteLine($"Gold: {Current_player.gold_balance}     Income Gold :{Current_player.gold_turn}     King Health :{Current_player.king.health}");
            while (true)
            {
                Console.WriteLine("Do you want to attack or train troops ? (T/A)");
                Console.WriteLine("You can pass the turn by enter P and get 2X Gold and 1.5X Gold income !!!! (p)");
                var comm = Console.ReadLine();
                if (comm == "T" || comm == "t")
                {
                    
                    Current_player.train(1);
                    Current_player.gold_balance += Current_player.gold_turn;

                    break;
                }
                else if (comm == "A" || comm == "a")
                {
                    if (Current_player.army.units.Count == 0)
                    {
                        Console.WriteLine("you have no unit to attack choose another option");
                    }
                    else
                    {
                        for (int i = 0; i < Current_player.army.units.Count; i++)
                            Current_player.attack(enemy, 1);
                        Current_player.gold_balance += Current_player.gold_turn;
                        Current_player.army.next_turn();

                        break;
                    }
                }
                else if (comm == "P" || comm == "p")
                {
                    Current_player.gold_balance += Current_player.gold_turn * 2;
                    Current_player.gold_turn = 3 * Current_player.gold_turn/2;
                    break;
                }
                else
                {
                    Console.WriteLine("wrong command please try again!");
                }
            }


        }
        public void playerVSplayer()
        {
            Console.Title = "Game Mode: PVP";
            while (!end())
            {
                turn(player1, player2);
                if (end())
                    break;
                turn(player2, player1);
            }
            Console.ForegroundColor = ConsoleColor.Yellow;
            if (player1.king.health <= 0)
            {

                Console.WriteLine(player1.name + " Win!!!!");
            }
            else 
            {
                Console.WriteLine(player2.name + " Win!!!!");
            }
            Program.Main_Menu();
        }
        public void AI_VS_AI()
        {
            Console.Title = "Game Mode: EVE";
            {
                
            }
        }
        public void player_VS_AI()
        {
            Console.Title = "Game Mode: PVE";

        }
        public bool end()
        {
            if (player1.king.health <= 0 || player2.king.health <= 0)
                return true;
            return false;
        }
        public void victory(player champion) 
        {

        }
        
    }
    
    class Program
    {
        static void Main(string[] args)
        {

            Main_Menu();
            Console.ReadLine();

        }
        public static void Main_Menu()
        {
            Console.Title="Main Menu";
            Console.WriteLine("welcom to my Game😊");

            var flag = true;
            while (flag)
            {
                Console.WriteLine("choose game mode ");
                Console.WriteLine("1. PvP ");
                Console.WriteLine("2. PvE   (comming soon)");
                Console.WriteLine("3. EvE   I know you say \"WTF!\" (comming soon)");
                Console.WriteLine("4. Guidance (recommend to read once at least)");
                Console.WriteLine("5. Exit");
                var comm = Console.ReadLine();

                switch (comm)
                {
                    case "1":
                        Console.WriteLine("we only have default option now , custom play will be in next update");
                        Console.WriteLine("enter player 1 name:");
                        var name1 = Console.ReadLine();
                        Console.WriteLine("enter player 2 name:");
                        var name2 = Console.ReadLine();
                        Console.ForegroundColor = ConsoleColor.Yellow;
                        Console.WriteLine("Game started-->");
                        Game game = new Game(p1name: name1, p2name: name2);
                        game.playerVSplayer();
                        break;
                    case "2":
                        Console.WriteLine("not availabe yet");
                        break;
                    case "3":
                        Console.WriteLine("not availabe yet");
                        break;
                    case "4":
                        print.All_unit();
                        break;
                    case "5":
                        flag = false;
                        break;
                    default:
                        Console.WriteLine("wrong command please try again!");
                        break;
                }
            }
            Console.WriteLine("Thanks for playing my Game 😘");
        }
    }
}
