using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BossFight
{
    internal class BossFight
    {
        static void Main(string[] args)
        {
            float bossHealth = 1000;
            float bossDamage = 50;
            int bossShield = 3;
            float userHealth = 500;
            int userDamage = 50;
            int userShield = 0;

            float curseSpell = 0.2f;
            int fireballSpell = 100;
            int healSpell = 100;
            int shieldSpell = 1;

            int minShieldActivationChance = 20;
            int maxShieldActivationChance = 101;

            Random randomNumber = new Random();
            int bossShieldActivationChance = randomNumber.Next(minShieldActivationChance, maxShieldActivationChance);
            string userInput;
            bool isGaming = true;
            int turnCounter = 0;

            Console.WriteLine("Бой начинается!");
            Console.WriteLine("Первый удар за вами. Выберите опцию: ");
            Console.WriteLine("1 - Простой удар\n" +
                "2 - Проклятие (после проклятия можно использовать только простую атаку)\n" +
                "3 - Огненный шар (восстановление 2 хода)\n" +
                "4 - Лечение (нельзя использовать после щита)\n" +
                "5 - Активировать щит (игрок игнорирует следующий входящий урон\n");

            while (isGaming)
            {
                turnCounter++;
                userInput = Console.ReadLine();

                switch (userInput)
                {
                    case "1":
                        Console.WriteLine($"Вы нанесли удар {userDamage}");
                        Console.WriteLine(bossHealth -= userDamage);
                        Console.WriteLine($"Враг нанес удар {bossDamage}");
                        Console.WriteLine(userHealth -= bossDamage);
                        break;
                    case "2":
                        Console.WriteLine("Вы проклинаете врага на 2 хода (-80% урона)");
                        Console.WriteLine($"Враг нанес удар {(bossDamage * curseSpell)}");
                        Console.WriteLine(userHealth -= bossDamage * curseSpell);
                        Console.WriteLine("Автоатака после проклятия");
                        Console.WriteLine($"Вы нанесли удар {userDamage}");
                        Console.WriteLine(bossHealth -= userDamage);
                        Console.WriteLine($"Враг нанес удар {(bossDamage * curseSpell)}");
                        Console.WriteLine(userHealth -= bossDamage * curseSpell);
                        break;
                }

                if (userHealth > 0 && bossHealth > 0)
                {
                    isGaming = true;
                }
                else
                {
                    isGaming = false;
                }
            } 
        }
    }
}
