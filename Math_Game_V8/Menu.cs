namespace Math_Game_V8
{
    internal class Menu
    {
        GameEngine engine = new();

        internal void ShowMenu(string name, DateTime date)
        {

            Helpers.DisplayIntroduction(name, date);

            do
            {
                string mainMenuInput;
                
                do
                {
               
                    mainMenuInput = Helpers.DisplayMainMenu(name).ToUpper();

                } while (mainMenuInput != "V" && mainMenuInput != "A" && mainMenuInput != "S" && mainMenuInput != "M" && mainMenuInput != "D" && mainMenuInput != "R" && mainMenuInput != "Q");

                if (mainMenuInput == "Q")
                {
                    Console.Clear();
                    Console.WriteLine("\n\n");
                    Console.WriteLine("Goodbye");
                    Console.WriteLine("\n\n");
                    break;
                }

                if (mainMenuInput == "V")
                {
                    Console.Clear();

                    Helpers.PrintGames();

                    continue;
                }

                Helpers.PrintSelection(mainMenuInput);

                int[] levelInput;// = new int[2];
                do
                {
                    // Console.Clear();
                    Console.WriteLine();
                    levelInput = Helpers.DisplayLevelMenu();

                } while (levelInput[0] < 1 || levelInput[0] > 3);

                /*Add number of questions*/
                int questionsInput;
                do
                {
                    // Console.Clear();
                    Console.WriteLine();
                    questionsInput = Helpers.DisplayAmountQuestions();
                } while (questionsInput < 5 || questionsInput > 20);

                // A3 // N /*Play the game -- HELPERS*/ 

                // List<string> recordData = new List<string>();
                engine.PlayTheGame(mainMenuInput, questionsInput, levelInput);

                /*if (levelInput == 10)
                {
                    recordData[2] = "1";
                }
                else if (levelInput == 50)
                {
                    recordData[2] = "2";
                }
                else if (levelInput == 100)
                {
                    recordData[2] = "3";
                }

                if (mainMenuInput == "A")
                {
                    recordData[1] = "Addition";
                }
                else if (mainMenuInput == "S")
                {
                    recordData[1] = "Subtraction";
                }
                else if (mainMenuInput == "M")
                {
                    recordData[1] = "Multiplication";
                }
                else if (mainMenuInput == "D")
                {
                    recordData[1] = "Division";
                }
                else if (mainMenuInput == "R")
                {
                    recordData[1] = "Random\t";
                }*/

                // A4 /*-------------------PRINT FINAL SCORE (HELPERS)-----------------*/
                /*---------------PRINT LAST GAME -- NO REPEAT------------*/

                /*Show final score*/
                //Helpers.PrintFinalScore(date, gameType, levelInput, questionsInput, gameScore, totalTime);


                // A5 /*----------------ADD SCORE TO DATABASE (HELPERS)*/
                //Helpers.AddToDatabase(date, gameType, levelInput, questionsInput, gameScore, totalTime);

                

            } while (true);

        }
    }
}
