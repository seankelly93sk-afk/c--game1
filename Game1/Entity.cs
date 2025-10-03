using System;

namespace Game1
{
    public class Entity
    {
        public string Name;
        public int Health;
        public int Defense;
        public bool Alive = true;
        
        public void TakeDamage()
        {
            --Health;
            Console.WriteLine($"You hit {Name}!");
            Console.WriteLine($"{Name} now has {Health} health!");
            if (Health <= 0)
            {
                Alive = false;
                Console.WriteLine($"{Name} has died!");
            }
        }
        public Entity()
        {
            Health = 5;
        }
    }
    
    public class Enemy : Entity
    {
        public void Attack(Entity target, int attackGuess)
        {
            Random attRand = new Random();
            attackGuess = attRand.Next(1, 10);

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
        
        public void RollNewDefense()
        {
            Random defRand = new Random();
            Defense =  defRand.Next(1, 10);
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
            else
            {
                Console.WriteLine("You missed!");
                Console.WriteLine("It's " + target.Name + "'s turn!");
            }
        }
        public Player()
        {
            Defense = 10;
        }
    }
}