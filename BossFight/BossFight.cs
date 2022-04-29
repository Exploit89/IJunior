using System;

namespace BossFight
{
    internal class BossFight
    {
        static void Main(string[] args)
        {
            float bossHealth = 1000;
            float bossDamage = 50;
            float bossShield;
            float maxUserHealth = 500;
            float userHealth = maxUserHealth;
            int userDamage = 50;

            float curseSpell = 0.2f;
            int fireballSpell = 150;
            int healSpell = 100;

            int minShieldActivationChance = 20;
            int maxShieldActivationChance = 101;
            int shieldActivationSuccess = 65;

            Random randomNumber = new Random();
            int bossShieldActivationChance;

            string userInput;
            bool isGaming = true;
            int turnCounter = 0;
            int lastUsedFireball = -1;
            int lastUsedCurse = -1;
            int lastUsedHeal = -1;
            int lastUsedShield = -1;
            int fireballCooldown = 2;
            int curseCooldown = 1;
            int healCooldown = 2;
            int shieldCooldown = 2;

            int userGreenHitPoints = 399;
            int userYellowHitPoints = 249;
            int userOrangeHitPoints = 99;

            Console.WriteLine("Бой начинается!");
            Console.WriteLine("Первый удар за вами. Выберите опцию: ");

            while (isGaming)
            {
                turnCounter++;
                bossShieldActivationChance = randomNumber.Next(minShieldActivationChance, maxShieldActivationChance);

                if (bossShieldActivationChance >= shieldActivationSuccess)
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("Внимание! Босс активирует поглощающий щит!");
                    bossShield = 0.5f;
                }
                else
                {
                    bossShield = 1;
                }

                Console.ForegroundColor = ConsoleColor.Magenta;
                Console.WriteLine("ХП Босса: " + bossHealth);

                if (userHealth > userGreenHitPoints)
                {
                    Console.ForegroundColor = ConsoleColor.Green;
                }
                else if(userHealth < userGreenHitPoints && userHealth > userYellowHitPoints)
                {
                    Console.ForegroundColor = ConsoleColor.Yellow;
                }
                else if(userHealth < userYellowHitPoints && userHealth > userOrangeHitPoints)
                {
                    Console.ForegroundColor = ConsoleColor.DarkYellow;
                }
                else
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                }

                Console.WriteLine("ХП Героя: " + userHealth);
                Console.ForegroundColor = ConsoleColor.White;
                Console.WriteLine("\n1 - Простой удар\n" +
                    "2 - Проклятие (после проклятия автоатака; восстановление 1 ход)\n" +
                    "3 - Огненный шар (восстановление 2 хода)\n" +
                    "4 - Лечение (нельзя использовать сразу после щита; восстановление 2 хода)\n" +
                    "5 - Активировать щит (игрок игнорирует следующий входящий урон)\n");

                userInput = Console.ReadLine();

                switch (userInput)
                {
                    case "1":
                        Console.WriteLine($"Вы нанесли удар {userDamage * bossShield}");
                        bossHealth -= userDamage * bossShield;
                        Console.WriteLine($"Враг нанес удар {bossDamage}");
                        userHealth -= bossDamage;
                        break;
                    case "2":
                        if (lastUsedCurse + curseCooldown < turnCounter)
                        {
                            lastUsedCurse = turnCounter;
                            Console.WriteLine("Вы проклинаете врага на 2 хода (-80% урона)");
                            Console.WriteLine($"Враг нанес удар {(bossDamage * curseSpell)}");
                            userHealth -= bossDamage * curseSpell;
                            Console.WriteLine("Автоатака после проклятия");
                            Console.WriteLine($"Вы нанесли удар {userDamage * bossShield}");
                            bossHealth -= userDamage * bossShield;
                            Console.WriteLine($"Враг нанес удар {(bossDamage * curseSpell)}");
                            userHealth -= bossDamage * curseSpell;
                            break;
                        }
                        else
                        {
                            Console.WriteLine("Вы не можете использовать это заклинание сейчас");
                            turnCounter--;
                            break;
                        }
                    case "3":
                        if(lastUsedFireball + fireballCooldown < turnCounter)
                        {
                            lastUsedFireball = turnCounter;
                            Console.WriteLine($"Вы запустили огненный шар {fireballSpell * bossShield}");
                            bossHealth -= fireballSpell * bossShield;
                            Console.WriteLine($"Враг нанес удар {bossDamage}");
                            userHealth -= bossDamage;
                            break;
                        }
                        else
                        {
                            Console.WriteLine("Вы не можете использовать это заклинание сейчас");
                            turnCounter--;
                            break;
                        }
                    case "4":
                        if (lastUsedHeal + healCooldown < turnCounter && (lastUsedShield + 1) < turnCounter)
                        {
                            lastUsedHeal = turnCounter;

                            if(userHealth <= maxUserHealth)
                            {
                                if (userHealth + healSpell >= maxUserHealth)
                                {
                                    Console.WriteLine($"Вы исцеляетесь до максимума {maxUserHealth}");
                                    userHealth = maxUserHealth;
                                    Console.WriteLine($"Враг нанес удар {bossDamage}");
                                    userHealth -= bossDamage;
                                }
                                else
                                {
                                    Console.WriteLine($"Вы исцеляетесь на {healSpell}");
                                    userHealth += healSpell;
                                    Console.WriteLine($"Враг нанес удар {bossDamage}");
                                    userHealth -= bossDamage;
                                }
                            }
                            break;
                        }
                        else
                        {
                            Console.WriteLine("Вы не можете использовать это заклинание сейчас");
                            turnCounter--;
                            break;
                        }
                    case "5":
                        if (lastUsedShield + shieldCooldown < turnCounter)
                        {
                            lastUsedShield = turnCounter;
                            Console.WriteLine($"Вы создаете щит");
                            Console.WriteLine($"Враг не наносит урона");
                            break;
                        }
                        else
                        {
                            Console.WriteLine("Вы не можете использовать это заклинание сейчас");
                            turnCounter--;
                            break;
                        }
                }

                if (userHealth > 0 && bossHealth > 0)
                {
                    isGaming = true;
                }
                else
                {
                    isGaming = false;
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("ХП Босса: " + bossHealth);

                    Console.ForegroundColor = ConsoleColor.Green;
                    Console.WriteLine("ХП Героя: " + userHealth);

                    Console.ForegroundColor = ConsoleColor.White;
                    if(userHealth <= 0 && bossHealth <= 0)
                    {
                        Console.WriteLine("Ничья! Два трупа по цене одного!\n");
                    }
                    else if(userHealth <= 0)
                    {
                        Console.WriteLine("Вы проиграли...\n");
                    }
                    else
                    {
                        Console.WriteLine("Вы победили!!!\n");
                    }
                }
            } 
        }
    }
}
