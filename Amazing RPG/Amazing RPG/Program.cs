namespace Amazing_RPG
{
    internal class Program
    {
        static void Main(string[] args)
        {
            while (true)
            {
                // Character selection
                Console.WriteLine("Choose your character: 1. Warrior 2. Mage 3. Archer");
                string characterChoice = Console.ReadLine();
                int playerHp = 0, playerAttack = 0, playerCriticalChance = 0;

                switch (characterChoice)
                {
                    case "1":
                        playerHp = 50;
                        playerAttack = 7;
                        playerCriticalChance = 10; // 10% chance
                        break;
                    case "2":
                        playerHp = 40;
                        playerAttack = 10;
                        playerCriticalChance = 20; // 20% chance
                        break;
                    case "3":
                        playerHp = 45;
                        playerAttack = 8;
                        playerCriticalChance = 15; // 15% chance
                        break;
                    default:
                        Console.WriteLine("Invalid choice, defaulting to Warrior.");
                        playerHp = 50;
                        playerAttack = 7;
                        playerCriticalChance = 10;
                        break;
                }

                // Enemy selection
                Random random = new Random();
                int enemyHp = random.Next(30, 51); // Random HP between 30 and 50
                int enemyAttack = random.Next(5, 11); // Random attack between 5 and 10
                int enemyCriticalChance = random.Next(5, 21); // Random critical chance between 5% and 20%

                while (playerHp > 0 && enemyHp > 0)
                {
                    Console.Clear();

                    // Display health
                    Console.WriteLine("-- Battle --");
                    Console.Write("Player HP: ");
                    Console.ForegroundColor = ConsoleColor.Green;
                    Console.WriteLine(playerHp);
                    Console.ResetColor();
                    Console.Write("Enemy HP: ");
                    Console.ForegroundColor = ConsoleColor.Green;
                    Console.WriteLine(enemyHp);
                    Console.ResetColor();

                    // Player's turn
                    Console.WriteLine("-- Player's Turn --");
                    Console.WriteLine("Choose your move: 1. Attack 2. Heal");
                    string choice = Console.ReadLine();

                    if (choice == "1")
                    {
                        int damage = playerAttack;
                        if (random.Next(0, 100) < playerCriticalChance)
                        {
                            damage *= 2;
                            Console.ForegroundColor = ConsoleColor.Red;
                            Console.WriteLine("Critical hit!");
                            Console.ResetColor();
                        }
                        enemyHp -= damage;
                        Console.ForegroundColor = ConsoleColor.Blue;
                        Console.WriteLine("You attacked the enemy for " + damage + " damage");
                        Console.ResetColor();
                    }
                    else if (choice == "2")
                    {
                        playerHp += 10;
                        Console.ForegroundColor = ConsoleColor.Blue;
                        Console.WriteLine("You healed yourself for 10 HP");
                        Console.ResetColor();
                    }

                    // Enemy's turn
                    if (enemyHp > 0)
                    {
                        Console.WriteLine("-- Enemy's Turn --");
                        int enemyChoice = random.Next(0, 2);

                        if (enemyChoice == 0)
                        {
                            int damage = enemyAttack;
                            if (random.Next(0, 100) < enemyCriticalChance)
                            {
                                damage *= 2;
                                Console.ForegroundColor = ConsoleColor.Red;
                                Console.WriteLine("Enemy critical hit!");
                                Console.ResetColor();
                            }
                            playerHp -= damage;
                            Console.WriteLine("The enemy attacked you for " + damage + " damage");
                        }
                        else
                        {
                            enemyHp += 5;
                            Console.WriteLine("The enemy healed for 5 HP");
                        }
                    }

                    // Pause to see enemy's actions
                    Console.WriteLine("Press any key to continue...");
                    Console.ReadKey();
                }

                if (playerHp > 0)
                {
                    Console.ForegroundColor = ConsoleColor.Green;
                    Console.WriteLine("Congrats! You have won this game.");
                    Console.ResetColor();
                }
                else
                {
                    Console.WriteLine("You have lost the game.");
                }

                Console.WriteLine("Do you want to play again? (Y/N)");
                if (Console.ReadLine().ToUpper() != "Y")
                {
                    break;
                }
            }
        }
    }
}
