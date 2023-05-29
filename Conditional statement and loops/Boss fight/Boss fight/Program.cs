Random rand = new Random();

int userStartGameHealth = 400;
float userHealth = userStartGameHealth;
float userArmor = 35;
float userAttack = 0;
float userDamageMultiplier = 1.0f;

const int Spell1 = 1;
string spell1Name = "Огненный ливень";
int spell1Attack = 40;
int spell1AccuracyPercent = 75;

const int Spell2 = 2;
string spell2Name = "Ледяной поцелуй";
int spell2Attack = 30;
int spell2AccuracyPercent = 90;

const int Spell3 = 3;
string spell3Name = "Травки-муравки";
float useHealthPointLessThan = 0.5f;
int useHealthPointLessThanPercentage = (int)(useHealthPointLessThan * 100);
float userHealthBoost = 0.5f;
int userHealthBoostPercentage =  (int)(userHealthBoost * 100); 
float userDamageDowngrade = 0.3f;
int userDamageDowngradePercentage = (int)(userDamageDowngrade * 100); 
int useSpell3Times = 3;

const int Spell4 = 4;
string spell4Name = "Силы духов";
float userDamageBoost = 0.5f;
int userDamageBoostPercentage =  (int)(userDamageBoost * 100);   
float userHealthDownGrade = 0.2f;
int userHealthDownGradePercentage = (int)(userHealthDownGrade * 100);

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
    Console.WriteLine($"{Spell1} {spell1Name}: наносит {spell1Attack} урона, точность {spell1AccuracyPercent}%, " +
        $"на 1 ход разрушает броню врага");
    Console.WriteLine($"{Spell2} {spell2Name}: наносит {spell2Attack} урона, точность {spell2AccuracyPercent}%, " +
        $"при разрушенной броне урон проходит в тело врага");
    Console.WriteLine($"{Spell3} {spell3Name}: дает дополнитьльные {userHealthBoostPercentage}% жизни от начального урона," +
        $" но снижает урон на {userDamageDowngradePercentage}%. Можно применить если жизней меньше {useHealthPointLessThanPercentage}%." +
        $"Осталось {useSpell3Times}");
    Console.WriteLine($"{Spell4} {spell4Name}: увеличивает урон на {userDamageBoostPercentage}%, " +
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

    userHitPropability = rand.Next(minAccuracyPercentage, maxAccuracyPercentage + 1);

    isActiveBossArmor = true;

    switch (selectedSpell)
	{
		case Spell1:
			int spell1AttackSpread = Convert.ToInt32(spell1Attack * damageSpread);

            if (userHitPropability <= spell1AccuracyPercent)
            {
				isUserHit = true;
			}
	
			userAttack = ((spell1Attack + rand.Next(-spell1AttackSpread, spell1AttackSpread)) * userDamageMultiplier * Convert.ToInt32(isUserHit));

            break;

		case Spell2:
            int splell2AttackSpread = Convert.ToInt32(spell2Attack * damageSpread);

            if (userHitPropability <= spell2AccuracyPercent)
            {
                isUserHit = true;
            }

            if (previousSpell == Spell1 && isUserHit == true)
			{
				isActiveBossArmor = false;
			}

            userAttack = (spell2Attack + rand.Next(-splell2AttackSpread, splell2AttackSpread)) * userDamageMultiplier * Convert.ToInt32(isUserHit);

            break;

		case Spell3:
            if (useSpell3Times > 0 && userHealth <= userStartGameHealth * useHealthPointLessThan)
            {
                userHealth *= (1 + userHealthBoost);
                userDamageMultiplier = 1 - userDamageDowngrade  ;
                useSpell3Times--;
                continue;
            }
            else if (useSpell3Times == 0)
            {
                Console.BackgroundColor = ConsoleColor.Red;
                Console.WriteLine("А всё... Закончилось!");

                Console.BackgroundColor = ConsoleColor.Black;
            }
            else if (userHealth > userStartGameHealth * useHealthPointLessThan)
            {
                Console.BackgroundColor = ConsoleColor.Red;
                Console.WriteLine("Пока рано");

                Console.BackgroundColor = ConsoleColor.Black;
            }

			break;

        case Spell4:
            userHealth *= (1-userHealthDownGrade);
            userDamageMultiplier = 1 + userDamageBoost;

            break;

		default:
            Console.BackgroundColor = ConsoleColor.Red;
            Console.WriteLine("Неверный ввод.");

            Console.BackgroundColor = ConsoleColor.Black;
            break;
    }

    previousSpell = selectedSpell;

    bossHitPropability = rand.Next(minAccuracyPercentage, maxAccuracyPercentage + 1); 
    int bossAttackSpread = Convert.ToInt32(bossAttackDamage * damageSpread);

    if (bossHitPropability <= bossAttackAccuracyPercent)
    {
        isBossHit = true;
    }

	userHealth -= (bossAttackDamage + rand.Next(-bossAttackSpread, bossAttackSpread)) * (1 - userArmor / 100) * Convert.ToInt32(isBossHit);
	bossHealth -= userAttack - (userAttack  * bossArmor / 100 * Convert.ToInt32(isActiveBossArmor));

    isActiveBossArmor = true;
}

if (userHealth <= 0 && bossHealth <= 0)
{
    Console.BackgroundColor = ConsoleColor.Gray;
    Console.WriteLine("Ничья");
    Console.BackgroundColor = ConsoleColor.Black;
}    
else if (userHealth <= 0 )
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