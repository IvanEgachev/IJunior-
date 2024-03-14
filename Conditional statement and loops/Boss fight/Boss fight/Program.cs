using System;
using System.Collections.Generic;

namespace BossFight
{     
     class Program
     {
        static void Main(string[] args)
        {
            const int SpellRainFire = 1;
            const int SpellIceKiss = 2;
            const int SpellMagicHerb = 3;
            const int SpellSpiritPower = 4;

            Random random = new Random();

            int userStartGameHealth = 400;
            float userHealth = userStartGameHealth;
            float userArmor = 35;
            float userAttack = 0;
            float userDamageMultiplier = 1.0f;

            string spellRainFireName = "Огненный ливень";
            int spellRainFireAttack = 40;
            int spellRainFireAccuracyPercent = 75;

            string spellSpellIceKissName = "Ледяной поцелуй";
            int spellIceKissAttack = 30;
            int spellIceKissAccuracyPercent = 90;

            string spellMagicHerbName = "Травки-муравки";
            float healthPointMax = 0.5f;
            int healthPointMaxPercentage = (int)(healthPointMax * 100);
            float userHealthBoost = 0.5f;
            int userHealthBoostPercentage = (int)(userHealthBoost * 100);
            float userDamageDowngrade = 0.3f;
            int userDamageDowngradePercentage = (int)(userDamageDowngrade * 100);
            int useSpellMagicHerbTimes = 3;

            string spellSpellSpiritPowerName = "Силы духов";
            float userDamageBoost = 0.5f;
            int userDamageBoostPercentage = (int)(userDamageBoost * 100);
            float userHealthDowngrade = 0.2f;
            int userHealthDownGradePercentage = (int)(userHealthDowngrade * 100);

            int selectedSpell = 0;
            int previousSpell = 0;
            int userHitPropability = 100;
            bool isUserHit = false;

            int bossStartGameHealth = 550;
            float bossHealth = bossStartGameHealth;
            float bossArmor = 40;
            bool isActiveBossArmor = true;
            float bossAttackDamage = 35;
            int bossAttackAccuracyPercent = 80;
            int bossHitPropability = 100;
            bool isBossHit = false;

            float damageSpread = 0.25f;

            int minAccuracyPercentage = 0;
            int maxAccuracyPercentage = 100;

            while (userHealth > 0 && bossHealth > 0)
            {
                Console.BackgroundColor = ConsoleColor.Blue;
                Console.WriteLine($"Твое здоровье: {userHealth}");
                Console.WriteLine($"Здоровье врага: {bossHealth}");

                Console.BackgroundColor = ConsoleColor.DarkGray;
                Console.WriteLine("\nВыберите одну из способностей:");
                Console.WriteLine($"{SpellRainFire} {spellRainFireName}: наносит {spellRainFireAttack} урона, точность {spellRainFireAccuracyPercent}%, " +
                    $"на 1 ход разрушает броню врага");
                Console.WriteLine($"{SpellIceKiss} {spellSpellIceKissName}: наносит {spellIceKissAttack} урона, точность {spellIceKissAccuracyPercent}%, " +
                    $"при разрушенной броне урон проходит в тело врага");
                Console.WriteLine($"{SpellMagicHerb} {spellMagicHerbName}: дает дополнитьльные {userHealthBoostPercentage}% жизни от начального урона," +
                    $" но снижает урон на {userDamageDowngradePercentage}%. Можно применить если жизней меньше {healthPointMaxPercentage}%." +
                    $"Осталось {useSpellMagicHerbTimes}");
                Console.WriteLine($"{SpellSpiritPower} {spellSpellSpiritPowerName}: увеличивает урон на {userDamageBoostPercentage}%, " +
                    $"при этом количество жизней уменьшается на {userHealthDownGradePercentage}%");

                Console.BackgroundColor = ConsoleColor.Black;

                bool isValidInput = int.TryParse(Console.ReadLine(), out selectedSpell);

                if (isValidInput == false)
                {
                    Console.BackgroundColor = ConsoleColor.Red;
                    Console.WriteLine("Неверный ввод.");

                    Console.BackgroundColor = ConsoleColor.Black;
                    continue;
                }

                userHitPropability = random.Next(minAccuracyPercentage, maxAccuracyPercentage + 1);

                isActiveBossArmor = true;

                switch (selectedSpell)
                {
                    case SpellRainFire:
                        int spellRainFireAttackSpread = Convert.ToInt32(spellRainFireAttack * damageSpread);

                        if (userHitPropability <= spellRainFireAccuracyPercent)
                        {
                            isUserHit = true;
                        }

                        userAttack = ((spellRainFireAttack + random.Next(-spellRainFireAttackSpread, spellRainFireAttackSpread)) * userDamageMultiplier * Convert.ToInt32(isUserHit));

                        break;

                    case SpellIceKiss:
                        int spellIceKissAttackSpread = Convert.ToInt32(spellIceKissAttack * damageSpread);

                        if (userHitPropability <= spellIceKissAccuracyPercent)
                        {
                            isUserHit = true;
                        }

                        if (previousSpell == SpellRainFire && isUserHit == true)
                        {
                            isActiveBossArmor = false;
                        }

                        userAttack = (spellIceKissAttack + random.Next(-spellIceKissAttackSpread, spellIceKissAttackSpread)) * userDamageMultiplier * Convert.ToInt32(isUserHit);

                        break;

                    case SpellMagicHerb:
                        if (useSpellMagicHerbTimes > 0 && userHealth <= userStartGameHealth * healthPointMax)
                        {
                            userHealth *= (1 + userHealthBoost);
                            userDamageMultiplier = 1 - userDamageDowngrade;
                            useSpellMagicHerbTimes--;

                            continue;
                        }
                        else if (useSpellMagicHerbTimes == 0)
                        {
                            Console.BackgroundColor = ConsoleColor.Red;
                            Console.WriteLine("А всё... Закончилось!");
                            Console.BackgroundColor = ConsoleColor.Black;

                            continue;
                        }
                        else if (userHealth > userStartGameHealth * healthPointMax)
                        {
                            Console.BackgroundColor = ConsoleColor.Red;
                            Console.WriteLine("Пока рано");

                            Console.BackgroundColor = ConsoleColor.Black;

                            continue;
                        }

                        break;

                    case SpellSpiritPower:
                        userHealth *= (1 - userHealthDowngrade);
                        userDamageMultiplier = 1 + userDamageBoost;

                        continue;

                    default:
                        Console.BackgroundColor = ConsoleColor.Red;
                        Console.WriteLine("Неверный ввод.");

                        Console.BackgroundColor = ConsoleColor.Black;
                        break;
                }

                previousSpell = selectedSpell;

                bossHitPropability = random.Next(minAccuracyPercentage, maxAccuracyPercentage + 1);
                int bossAttackSpread = Convert.ToInt32(bossAttackDamage * damageSpread);

                if (bossHitPropability <= bossAttackAccuracyPercent)
                {
                    isBossHit = true;
                }

                userHealth -= (bossAttackDamage + random.Next(-bossAttackSpread, bossAttackSpread)) * (1 - userArmor / 100) * Convert.ToInt32(isBossHit);
                bossHealth -= userAttack - (userAttack * bossArmor / 100 * Convert.ToInt32(isActiveBossArmor));

                isActiveBossArmor = true;
            }

            if (userHealth <= 0 && bossHealth <= 0)
            {
                Console.BackgroundColor = ConsoleColor.Gray;
                Console.WriteLine("Ничья");
                Console.BackgroundColor = ConsoleColor.Black;
            }
            else if (userHealth <= 0)
            {
                Console.BackgroundColor = ConsoleColor.Red;
                Console.WriteLine("ПОМЕР");
                Console.BackgroundColor = ConsoleColor.Black;
            }
            else if (bossHealth <= 0)
            {
                Console.BackgroundColor = ConsoleColor.Green;
                Console.WriteLine("Босс одолен");
                Console.BackgroundColor = ConsoleColor.Black;
            }
        }
    }
}
