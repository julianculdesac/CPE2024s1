using LiTL;
using System.Collections.Generic;
using System.ComponentModel.Design;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Game
{
    public class Encounters
    // Encounterss
    {
        static Random rand = new Random();

        public static void  FirstEncounter()
        {
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine("Grabbing a nearby Weapon, You Prepare for Battle");
            Console.WriteLine("Beginner Monster is Preparing to Fight\n");
            Console.ReadKey();
            Combat(false, "Beginner Monster", 1, 5);
        }

        public static void BasicFightEncounter()
        {
            Console.Clear();
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine("As you walk around this seamlessly endless place you Encountered....");
            Console.ReadKey();
            Combat(true, "", 0, 0);
        }
        public static void GhostEncounter()
        {
            Console.Clear();
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine("A strong monster...");
            Console.WriteLine("\nA ghostly gigure with strong animosity charges at you");
            Console.WriteLine("Prepare for a strong Monster");
            Console.ReadLine();
            Combat(false, "Strong Battle Mage", 6, 8);
        }



        public static void BossEncounter()
        {
            Console.Clear();
            Console.ForegroundColor = ConsoleColor.DarkRed;
            Console.WriteLine("You sense something Big");
            Console.ReadLine();
            Console.WriteLine("\nPrepare.... ");
            Console.ReadLine();
            Console.WriteLine("A Boss Appears");
            Console.ReadLine();
            Combat(false, "DRAGON", 10, 10);

        }




        //Encounter Tool RANDOMMMM
        public static void RandomEncounter()
        {
            if (Program.currentPlayer.coins < 100)
            {
                switch (rand.Next(0, 10))
                {
                    case 0:
                        BasicFightEncounter();
                        break;
                    case 1:
                        BasicFightEncounter();
                        break;
                    case 2:
                        GhostEncounter();
                        break;
                    case 3:
                        GhostEncounter();
                        break;
                    case 4:
                        BasicFightEncounter();
                        break;
                    case 5:
                        BasicFightEncounter();
                        break;
                    case 6:
                        BasicFightEncounter();
                        break;
                    case 7:
                        BasicFightEncounter();
                        break;
                    case 8:
                        GhostEncounter();
                        break;
                    case 9:
                        BasicFightEncounter();
                        break;
                    default:
                        BasicFightEncounter();
                        break;
                }

            }


            else if (Program.currentPlayer.coins > 100)
            {
                switch (rand.Next(0, 5))
                {
                    case 0:
                        GhostEncounter();
                        break;
                    case 1:
                        BossEncounter();
                        break;
                    case 2:
                        BossEncounter();
                        break;
                    case 3:
                        GhostEncounter();
                        break;
                    case 4:
                        GhostEncounter();
                        break;
                    case 5:
                        BasicFightEncounter();
                        break;

                }

            }


            else if (Program.currentPlayer.coins > 300)
            {
                switch (rand.Next(0, 5))
                {
                    case 0:
                        GhostEncounter();
                        break;
                    case 1:
                        BossEncounter();
                        break;
                    case 2:
                        BossEncounter();
                        break;
                    case 3:
                        GhostEncounter();
                        break;
                    case 4:
                        GhostEncounter();
                        break;
                    case 5:
                        GhostEncounter();
                        break;

                }

            }


            else if (Program.currentPlayer.coins > 500)
            {
                switch (rand.Next(0, 5))
                {
                    case 0:
                        BossEncounter();
                        break;
                    case 1:
                        BossEncounter();
                        break;
                    case 2:
                        BossEncounter();
                        break;
                    case 3:
                        BossEncounter();
                        break;
                    case 4:
                        GhostEncounter();
                        break;
                    case 5:
                        GhostEncounter();
                        break;

                }

            }







        }
        public static void Combat(bool random, string name, int power, int health)
        {
            string n = "";
            int p = Program.currentPlayer.GetPower();
            int h = Program.currentPlayer.GetHealth();
           
            if (random)
            {
                n = GetName();
                p = rand.Next(1, 4);
                h = rand.Next(1, 8);

            }
            else
            {
                n = name;
                p = power;
                h = health;
            }
            while (h > 0)

            {
                //UI
                Console.Clear();
                Console.WriteLine(n);
                Console.WriteLine("\t\t\t\t\tATK:(" + p + ")/HP:(" + h + ")");
                Console.WriteLine("\t\t\t\t\t==================");
                Console.WriteLine("\t\t\t\t\t:|A|tack |D|efend:");
                Console.WriteLine("\t\t\t\t\t: |R|un   |H|eal: ");
                Console.WriteLine("\t\t\t\t\t==================");
                Console.WriteLine("\t\t\t\t\tPotions: " + Program.currentPlayer.potion + " Health: " + Program.currentPlayer.health);
                string input = Console.ReadLine();

                //DEF
                if (input.ToLower() == "d" || input.ToLower() == "defend")
                {
                    
                    Console.WriteLine("As the " + n + " Stikes you , you ready yourself for an attack");
                    int damage = p - Program.currentPlayer.armorValue;
                    if (damage < 0)

                        damage = 0;
                    int attack = rand.Next(0, Program.currentPlayer.weaponValue) / 2;
                    Console.WriteLine("You Lose " + damage/2 + " health and deal " + attack + " damage\n");
                    Program.currentPlayer.health -= damage/ 2;
                    h -= attack;
                    
                    Console.ReadKey();
                }
                //ATK
                else if (input.ToLower() == "a" || input.ToLower() == "attack")
                {
                   
                    Console.WriteLine("\nWith your weapon you attack, the " + n + " strikes you ");
                    int damage = (p / 2) - Program.currentPlayer.armorValue;
                    int attack = rand.Next(0, Program.currentPlayer.weaponValue) + rand.Next(1, 3);
                    Console.WriteLine("You Lose " + damage + " health and deal " + attack + " damage");
                    Program.currentPlayer.health -= damage;
                    h -= attack;
                    
                    Console.ReadKey();
                }
                //RUN
                else if (input.ToLower() == "r" || input.ToLower() == "run")
                {
                    if (rand.Next(0, 2) == 0)
                    {
                        Console.WriteLine("You Try to Sprint Away from the " + n + ", it tries to stike you in the back");
                        int damage = p - Program.currentPlayer.armorValue;
                        if (damage < 0)
                            damage = 0;
                        Console.WriteLine("You Lose " + damage/2 + " and are unable to run away");
                        damage = p - Program.currentPlayer.armorValue;
                        Program.currentPlayer.health -= damage / 2;
                        
                        Console.ReadKey();
                    }
                    else
                    {
                        Console.Write("You managed to run away from the " + n + ".. and lived another day");
                        Console.ReadKey();
                        
                        SHOP.LoadShop(Program.currentPlayer);
                    }

                    //HEAL
                }
                else if (input.ToLower() == "h" || input.ToLower() == "heal")
                {
                    if (Program.currentPlayer.potion == 0)
                    {
                        Console.WriteLine("You have no potions Available.... sad");

                        int damage = p - Program.currentPlayer.armorValue;
                        if (damage < 0)
                            damage = 0;
                         Console.ReadKey();
                    }
                    else
                    {
                        Console.WriteLine("You have a potion available, And chug a bottle of it");

                        Console.WriteLine("You gain health");
                        Program.currentPlayer.health += Program.currentPlayer.potion;
                        Program.currentPlayer.potion--;
                    }
                    
                    Console.ReadKey();
                }
                if (Program.currentPlayer.health <= 0)
                {
                    //DIEE
                    Console.Clear();
                    Console.WriteLine("You were Defeated. What a waste being slain by a " + n);
    

                    Program.currentPlayer.armorValue = 0;
                    Program.currentPlayer.weaponValue = 2;
                    Program.currentPlayer.coins = 0;

                    Program.currentPlayer.health = 10;
                    Program.currentPlayer.potion = 2;

                    Program.Quit();
                    break;

                }
                Console.ReadKey();
            }

            //ADD COINS STUFF
            int c = rand.Next(10, 15);
            int x = 2;
            Console.WriteLine("\nVICTORY!!!\n");
            Console.WriteLine("You have defeated the " + n + ", You quickly looted the corpse you found " + c + " coins!");
            Program.currentPlayer.coins += c;
            Console.ReadKey();
        }
        public static string GetName()
        {
            switch (rand.Next(0, 6))
            {

                case 0:
                    return "Ghoul";
                    break;
                case 1:
                    return "A Strange Faceless Head";
                    break;


                case 2:
                    return "Undead Warrior";
                    break;
                case 3:
                    return "Slime";
                    break;

                case 4:
                    return "Cannibals";
                    break;

            }
            return "Zombie";
        }

    }
}
