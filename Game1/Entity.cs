using System;
using System.Threading;

namespace Game1
{
    public class Entity
    {
        public string Name;
        public int Health;
        public int Defense;
        public int MinDefense;
        public int MaxDefense;
        public bool Damaged = false;
        public bool Alive = true;

        public void TakeDamage()
        {
            --Health;
            Damaged = true;
            Console.WriteLine($"{Name} now has {Health} health!");
            if (Health <= 0)
            {
                Alive = false;
                Console.WriteLine($"{Name} has died!");
            }
        }

        public void RollNewDefense()
        {
            Random defRand = new Random();
            Defense = defRand.Next(MinDefense, MaxDefense);
        }

        public Entity()
        {
            Health = 5;
            MinDefense = 1;
            MaxDefense = 10;
        }
    }

    public class Enemy : Entity
    {
        public void Attack(Entity target, int attackGuess)
        {
            Random attRand = new Random();
            attackGuess = attRand.Next(1, 10);
            Console.WriteLine($"{Name} guessed {attackGuess}!");
            Thread.Sleep(2000);

            if (attackGuess == target.Defense)
            {
                Console.WriteLine("Direct hit!");
                Console.WriteLine($"{target.Name} now has {target.Health} health!");
                target.TakeDamage();
            }
            else
            {
                Console.WriteLine($"{Name} missed!");
            }
        }

        public Enemy()
        {
            RollNewDefense();
        }
    }

    public class Player : Entity
    {
        public void Attack(Entity target, int attackGuess)
        {
            if (attackGuess == target.Defense)
            {
                Console.WriteLine("Direct hit!");
                target.TakeDamage();
            }

            else if (attackGuess < target.Defense)
            {
                Console.WriteLine($"{Name} missed!");
                Console.WriteLine($"{Name}'s guess is too low!");
            }

            else if (attackGuess > target.Defense)
            {
                Console.WriteLine($"{Name} missed!");
                Console.WriteLine($"{Name}'s guess is too high!");
            }
            else
            {
                Console.WriteLine("You missed!");
                Console.WriteLine("It's " + target.Name + "'s turn!");
            }
        }

        public Player()
        {
        }
    }
}



