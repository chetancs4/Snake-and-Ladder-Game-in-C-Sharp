namespace SnakeAndLadder
{
    using System;
    using System.Collections.Generic;

    class SnakeAndLadderGame
    {
        static void Main(string[] args)
        {
            int currentPlayer = 1; // Represents the current player
            int playerPosition = 0; // Represents the position of the current player
            bool gameEnded = false; // Flag to check if the game has ended

            Console.WriteLine("Welcome to Snake and Ladder Game!");

            // Define the snakes and ladders using a dictionary
            Dictionary<int, int> snakesAndLadders = new Dictionary<int, int>()
        {
            { 3, 22 },   // Ladder: from 3 to 22
            { 5, 8 },    // Ladder: from 5 to 8
            { 11, 26 },  // Ladder: from 11 to 26
            { 17, 4 },   // Snake: from 17 to 4
            { 19, 7 },   // Snake: from 19 to 7
            { 20, 29 },  // Ladder: from 20 to 29
            { 27, 1 },   // Snake: from 27 to 1
            { 31, 9 }    // Snake: from 31 to 9
        };

            while (!gameEnded)
            {
                Console.WriteLine("Player {0}'s turn. Press Enter to roll the dice.", currentPlayer);
                Console.ReadLine();

                // Generate a random number between 1 and 6 (inclusive) to simulate dice roll
                Random random = new Random();
                int diceRoll = random.Next(1, 7);

                Console.WriteLine("Player {0} rolled a {1}.", currentPlayer, diceRoll);

                // Update player position based on the dice roll
                playerPosition += diceRoll;

                // Check if the player landed on a ladder or a snake
                if (snakesAndLadders.ContainsKey(playerPosition))
                {
                    int newPosition = snakesAndLadders[playerPosition];
                    if (newPosition > playerPosition)
                    {
                        Console.WriteLine("Player {0} climbed a ladder! New position: {1}", currentPlayer, newPosition);
                    }
                    else
                    {
                        Console.WriteLine("Player {0} got bitten by a snake! New position: {1}", currentPlayer, newPosition);
                    }

                    playerPosition = newPosition;
                }

                // Check if the player has won
                if (playerPosition >= 100)
                {
                    Console.WriteLine("Player {0} has won the game!", currentPlayer);
                    gameEnded = true;
                }
                else
                {
                    Console.WriteLine("Player {0}'s current position: {1}", currentPlayer, playerPosition);
                    Console.WriteLine("----------------------------------");

                    // Switch to the next player
                    currentPlayer = currentPlayer == 1 ? 2 : 1;
                }
            }

            Console.WriteLine("Press Enter to exit.");
            Console.ReadLine();
        }
    }
}