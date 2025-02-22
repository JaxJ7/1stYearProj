using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Jao_Project.Classes
{
    public class Voids
    {
        public void Attacking(Character c)
        {

        }
        public void Crafting(Character c, Items I, Potions CI)
        {

        }
        public void Shop()
        {

        }
        public void Sell()
        {

        }

        public void Gatcha()
        {


        }
        public void LevelUp(Character c)
        {
            c.Level += 1;
            c.MaxHealth += 100;
            c.Health = c.MaxHealth;
            c.MaxAttack += 10;
            c.MaxMana += 50;
            c.Mana = c.MaxMana;
            c.Expirence = 0;
            c.MaxExpirence += 500;
        }
    }
    /*class Program
    {
        static int pullCount = 0;
        static int pity4Count = 0;
        static int pity5Count = 0;

        static void Main(string[] args)
        {
            Console.WriteLine("Welcome to the Gacha!");
            Console.WriteLine("Press enter to pull an item.");
            Console.WriteLine("Press Q to quit.");

            while (true)
            {
                ConsoleKeyInfo key = Console.ReadKey();
                if (key.Key == ConsoleKey.Enter)
                {
                    Console.WriteLine();
                    Console.WriteLine("You got: " + PullItem());
                }
                else if (key.Key == ConsoleKey.Q)
                {
                    break;
                }
            }
        }

        static string PullItem()
        {
            pullCount++;

            if (pullCount == 70)
            {
                pity5Count = 0;
                pity4Count = 0;
                pullCount = 0;
                return "Five-Star Item";
            }
            else if (pullCount % 10 == 0)
            {
                pity4Count = 0;
                return "Four-Star Item";
            }
            else if (pity5Count == 89)
            {
                pity5Count = 0;
                return "Five-Star Item";
            }
            else if (pity4Count == 9)
            {
                pity4Count = 0;
                return "Four-Star Item";
            }
            else
            {
                Random rnd = new Random();
                int chance = rnd.Next(1, 101);

                if (chance <= 85)
                    return "Three-Star Item";
                else if (chance <= 98)
                {
                    pity4Count++;
                    return "Four-Star Item";
                }
                else
                {
                    pity5Count++;
                    return "Five-Star Item";
                }
            }
        }
    }*/
}
