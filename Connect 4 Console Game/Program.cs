using System;

namespace Connect_4_Console_Game
{
	internal class Program
	{
		private static void Main(string[] args)
		{
			char player1Char = '\0';
			char player2Char = '\0';

			Console.WriteLine("Enter the character to be used for");

			// player 1 choosing char
			Console.Write("Player 1: ");
			player1Char = ChooseCharacter();

			Console.Write("Player 2: ");
			player2Char = ChooseCharacter();
			while (player1Char == player2Char)
			{
				Console.WriteLine("Player characters must be different!");
				Console.Write("Player 2: ");
				player2Char = ChooseCharacter();
			}

			Console.WriteLine();
			Console.WriteLine("Player 1 using character '{0}', Player 2 using character '{1}'", player1Char, player2Char);
			Console.WriteLine();


			DataSet dataSet = new DataSet();
			Console.WriteLine(dataSet);
			
		}

		private static char ChooseCharacter()
		{
			char retVal = '\0';
			string readedFromConsole;

			do
			{
				readedFromConsole = Console.ReadLine();
				if (readedFromConsole.Length == 1)
				{
					retVal = readedFromConsole[0];
				}
				else
				{
					Console.WriteLine("Invalid character!");
					Console.WriteLine("Try again.");
				}
			} while (retVal == '\0');

			return retVal;
		}
	}
}
