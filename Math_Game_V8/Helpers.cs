using Math_Game_V8.Models;
using System.Security.AccessControl;
using static System.Formats.Asn1.AsnWriter;

namespace Math_Game_V8
{
    internal class Helpers
    {
        // A1 Function
        internal static string GetName()
        {
            Console.WriteLine("Please type your name");
            string? name = Console.ReadLine() ?? " ";

            while (string.IsNullOrEmpty(name))
            {
                Console.WriteLine("Name can't be empty");
                name = Console.ReadLine();
            }

            return name;
        }

        // A4 Print Game Result
        internal static void PrintFinalScore(GameType gameType, int levelInput, int questionsInput, int gameScore, string totalTime)
        {
            Console.Clear();
            Console.WriteLine();
            Console.WriteLine($"Final:\tDate\t\tType\t\tLevel\t#Questions\tScore\tTime(Sec)");
            Console.WriteLine($"\t--------------------------------------");
            Console.WriteLine($"\t{DateTime.Now}\t{gameType}\t{levelInput}\t{questionsInput}\t{gameScore}\t{totalTime}");
        }

        // A5 Add To Database
        internal static void AddToDatabase(GameType gameType, int levelInput, int questionsInput, int gameScore, string totalTime)
        {
            games.Add(new Game
            {
                Date = DateTime.Now,
                Type = gameType,
                Level = levelInput,
                Questions = questionsInput,
                Score = gameScore,
                Time = totalTime
            });

        }

        // A6 Display Introduction
        internal static void DisplayIntroduction(string name, DateTime date)
        {
            Console.Clear();
            Console.WriteLine("---------------------------------------------------------------------------------------------------------------------");
            Console.WriteLine($"Hello {name.ToUpper()}. It's {date.DayOfWeek}. This is your math's game. That's great that you're working on improving yourself.");
            Console.WriteLine("---------------------------------------------------------------------------------------------------------------------");
            Console.WriteLine("Press any key to show menu");
            Console.ReadKey();
            Console.WriteLine("\n");

        }

        // A7 Display Main Menu
        internal static string DisplayMainMenu(string name)
        {
            Console.Clear();
            Console.WriteLine();
            Console.WriteLine("--------------------------------------------------------");
            Console.WriteLine($" {name.ToUpper()}, what game would you like to play today? \n Choose from the options below: ");
            
            Console.WriteLine();
            Console.WriteLine("   Menu");
            Console.WriteLine();
            Console.WriteLine("   V - View Games History");
            Console.WriteLine("   A - Addition");
            Console.WriteLine("   S - Substraction");
            Console.WriteLine("   M - Multiplication");
            Console.WriteLine("   D - Division");
            Console.WriteLine("   R - Random");
            Console.WriteLine("   Q - Quit");
            Console.WriteLine();
            Console.WriteLine("--------------------------------------------------------");
            Console.Write("Choice: ");
            string? mainMenuInput = Console.ReadLine() ?? " ".ToUpper();
            return mainMenuInput;
        }

        internal static void PrintSelection(string mainMenuInput)
        {
            Console.Clear();
            switch (mainMenuInput)
            {
                case "A":
                    Console.WriteLine($"{GameType.Addition} selected.");
                    break;
                case "S":
                    Console.WriteLine($"{GameType.Subtraction} selected.");
                    break;
                case "M":
                    Console.WriteLine($"{GameType.Multiplication} selected.");
                    break;
                case "D":
                    Console.WriteLine($"{GameType.Division} selected.");
                    break;
                case "R":
                    Console.WriteLine($"{GameType.Random} operations selected.");
                    break;
                default:
                    Console.WriteLine("Invalid Input!");
                    break;
            }
        }


        // A8 Display Level Menu
        internal static int[] DisplayLevelMenu()
        {
            int[] level = new int[2];
            
            int highLevelInput;
            string levelInput;

            do
            {
                Console.Write("Choose level [1-3] ");
                levelInput = Console.ReadLine() ?? " ";
                levelInput = levelInput.Trim();
            }while (string.IsNullOrEmpty(levelInput) || !Int32.TryParse(levelInput, out _));

            // while (levelInput != "1" && levelInput != "2" && levelInput != "3");


            if (levelInput == "1")
            {
                highLevelInput = 10;

            }
            else if (levelInput == "2")
            {
                highLevelInput = 50;

            }
            else if (levelInput == "3")
            {
                highLevelInput = 100;

            }
            else
            {
                highLevelInput = 0;
            }

            level[0] = Convert.ToInt32(levelInput);
            level[1] = highLevelInput;

            return level;

        }

        // A9 Display Amount of Questions
        internal static int DisplayAmountQuestions()
        {
            int howManyQuestions;
            string numberString;
            do
            {
                Console.Write("Choose the amount of questions [5-20] ");
                numberString = Console.ReadLine() ?? " ";
            } while (string.IsNullOrEmpty(numberString) || !Int32.TryParse(numberString, out _));
            howManyQuestions = Convert.ToInt32(numberString);
            return howManyQuestions;
        }

        // A11 Get Division Numbers
        internal static int[] GetDivisionNumbers(int highLevelInput)
        {
            Random random = new();
            int firstNumber = random.Next(1, highLevelInput);
            int secondNumber = random.Next(1, highLevelInput);

            int[] result = new int[2];

            while (firstNumber % secondNumber != 0)
            {
                firstNumber = random.Next(1, highLevelInput);
                secondNumber = random.Next(1, highLevelInput);
            }

            result[0] = firstNumber;
            result[1] = secondNumber;

            return result;
        }

        // A11 Suite

        internal static int[] SelectTwoRandomNumbers(int highLevelInput)
        {
            int[] twoNums = new int[2];

            Random rnd = new();

            int num1 = rnd.Next(1, highLevelInput);
            int num2 = rnd.Next(1, highLevelInput);

            twoNums[0] = num1;
            twoNums[1] = num2;

            return twoNums;
        }

        // A17 Dispalay Database

        internal static List<Game> games = [];
        internal static void PrintGames()
        {
            Console.Clear();
            Console.WriteLine("Games History");
            Console.WriteLine();
            Console.WriteLine($"Date\t\tType\t\tLevel\tQuestions\tScore\tTime(Sec)");
            Console.WriteLine("----------------------------------------");
            foreach (Game game in games)
            {
                Console.WriteLine($"{game.Date}\t\t{game.Type}\t\t{game.Level}\t{game.Questions}\t{game.Score} pts\t{game.Time}");
            }
            Console.WriteLine("----------------------------------------\n");
            Console.WriteLine("Press any key to return to Main Menu.");
            Console.ReadKey();
        }

        /*internal static void AddToHistory(int gameScore, GameType gameType)
        {
            games.Add(new Game
            {
                Date = DateTime.Now,
                Score = gameScore,
                Type = gameType
            });

        }*/

        
        // A18 Validate Answer
        internal static string? ValidateResult(string result)
        {
            while (string.IsNullOrEmpty(result) || !Int32.TryParse(result, out _))
            {
                Console.WriteLine("Your answer needs to be an integer. Try again.");
                result = Console.ReadLine() ?? " ";
            }
            return result;
        }

        // A16 Test For Correct Answer
        internal static int TestAnswer(int inputAnswer, int calcAnswer, int gameScore)
        {
            Console.WriteLine();
            if (calcAnswer == inputAnswer)
            {
                Console.WriteLine("Very Good! you calculated the right answer!");
                gameScore++; // GLOBAL
            }
            else
            {
                Console.WriteLine("Wrong answer!");
            }
            Console.ReadKey();
            return gameScore;
        }

    }
}
