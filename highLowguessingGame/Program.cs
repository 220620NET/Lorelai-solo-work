int[] guessRecords = new int [5];                //This variable holds the values for previous guesses.
int lastWin = 5;                                 //Not used during first round, but holds the record number of guesses (fewest is best).
string lastWinner = "Lor";                       //Placeholder winner name. Not displayed until someone wins and writes over this with their own name.

Beginning:                                       //Statement to restart if desired.
Random randomNumGenerator = new Random();        //Random class choosing a random target number.
int targetNum = randomNumGenerator.Next(100);    //Declaring the random number as the answer.
int tries = 1;                                   //Tries holds the number of attempts for RECORD KEEPING
int guesses = 5;                                 //Guesses holds the number of attempts for THIS GAME.

//Console.WriteLine("The number is " + targetNum); //Solution for debugging purposes. Disabled for this final iteration, but can be enabled any time by removing the //

Console.WriteLine("Welcome to the Number Guessing game^tm");               //Program introduction...
if(lastWinner != "Lor")                                                    //The first run will not display winners to the user until they win themselves.
{
Console.WriteLine(lastWinner + " currently has the record for guessing the number in " + lastWin + " guesses."); //Displays record winner to the user.
Console.WriteLine("The record winning guesses were: " + "[{0}]", string.Join(", ", guessRecords));               //Tells user the last successful guesses.
}
Console.WriteLine("Begin by guessing a number between 1 and 100, pl0x");   //Solicits user for a guess.

do
{
    Console.WriteLine("You have " + guesses + " guesses remaining.");      //Informs user of number of guesses left.
    int[] guessList = new int [5];                                         //Array created to store guess values.
    int i = 0;
    
    do
    {
        guessList[i] = Convert.ToInt32(Console.ReadLine());                     //User enters their guess and it is stored as the most recent array value.
        

        if(guessList[i] < 1 || guessList[i] > 100)                              //if too large or small an entry, asks for a new number.
        {
            Console.WriteLine("Out of Bounds! Guess again!");
        }
        else if(guessList[i] > targetNum)                                       //If guess is too high, says so and uses proximity checker to see by how much.
        {
            Console.WriteLine("Duuuuuuude... tooo highhhhh... try again!");
            proximityChecker(targetNum, guessList[i]);
            if(tries > 1)                                                       //HotteColder should only execute if it is at least the second guess.
            {       
            hotterColder(targetNum);                                            //Executes a comparison between the last and current guess to see what is closer.
            }
            tries++;                                                            //Counts as an attempt for the record keeping.
            guesses--;                                                          //Counts as an attempt for this round of the game.
        }
        else if(guessList[i] < targetNum)                                       //If guess is too low, says so and uses proximity checker to see by how much.
        {
            Console.WriteLine("Too low, too slow... try again, yo");
            proximityChecker(targetNum, guessList[i]);
            if(tries > 1)                                                       //HotterColder here is the same as above.
            {
            hotterColder(targetNum);
            }
            tries++;                                                            //Counts as an attempt for the record keeping.
            guesses--;                                                          //Counts as an attempt for this round of the game.
        }
        else if(guessList[i] == targetNum)                                      //If you win!! Ends the game displaying that sweet, sweet victory message.
        {
            Console.WriteLine("Yo you did it, congrats for guessing a number right!"); //Awww nice job! :3
            Console.WriteLine("Enter your name for the record books!!");               
            string userName = Console.ReadLine();                                      //User inputs name.
            Console.WriteLine("Would you like to play again? (y/n)");
            char userInput = Convert.ToChar(Console.ReadLine());                //Prompts user to enter y/n to replay or exit.

            if(userInput == 'y')                                                //Upon choosing y this path will send the user back to the beginning.
            {
                lastWin = tries;                                                //Updates records with the number of tries this attempt took.
                lastWinner = userName;                                          //Updates records with the name of the winner.
                guessList.CopyTo(guessRecords , 0);                             //Copies information from guessList array into guessRecords array.
                goto Beginning;                                                 //Brings user to the beginning to play again.
            }
            else if(userInput == 'n')
            {
                System.Environment.Exit(0);                                     //This path will terminate the program.
            }
            else                                                        
            {
                System.Environment.Exit(0);                                     //Also exits program if a selection is invalid.
            }
        }

        Console.WriteLine("[{0}]", string.Join(", ", guessList));               //Displays the guesses that have been made.
        i++;                                                                    //Moves onto the next guess and array position.

        int proximityChecker(int target, int actual)            //Determines distance between user's guess and previously generated target.
        {
            int proximity = target - actual;                    //Uses difference between the random target number and the user's guess to get proximity.
            if(proximity < 0)                                    
            {
                int absoluteValue = Math.Abs(proximity);        //If the difference between "target" and "user guess" is negative, this will obtain the absolute value.
                tempCheck(absoluteValue);                       //Using the value "proximity" in the tempCheck function to display the difference to the user.
                return proximity;
            }
            else
            {
                tempCheck(proximity);                           //If the difference between "target" and "user guess" is positive, this simply inputs that value into tempCheck.
                return proximity;
            }
        }

        int tempCheck(int value)                                //Displays how close the user was with their guess.
        {
            if(value <= 5)
            {
                Console.WriteLine("So so close!!! You are hot!");//HOT!!!!
                return 0;
            }        
            else if(value <= 10)
            {
                Console.WriteLine("Close! You are warm.");      //Guesses within 10 are called "warm".
                return 0;
            }
            else if(value <= 20)
            {
                Console.WriteLine("Nuh-uh, lukewarm ;)");       //Guesses within 20 are called "lukewarm".
                return 0;
            }
            else if(value <= 35)
            {
                Console.WriteLine("Nope! You are cold!");       //Guesses within 35 are called "cold".
                return 0;
            }
            else if(value > 50)
            {
                Console.WriteLine("Way off! You are freezing!");//Guesses within 50 are called "freezing".
                return 0;
            }

            return 0;
        }

        int hotterColder(int target)                                                //Uses target number to compare recent guesses.
        {
            int previous = guessList[i-1];                                          //Accessing previously indexed guess in array.
            int current = guessList[i];                                             //Accessing current guess.
            
            int previousClosenessCheck = target - previous;                         //Grabbing numbers for the difference between this
            int currentClosenessCheck = target - current;                           //and last guess.
            if(previousClosenessCheck < 0)                                          //If less than zero, same absolute value idea as above.
            {
                int absoluteValue = Math.Abs(previousClosenessCheck);
                previousClosenessCheck = absoluteValue;  
                return previousClosenessCheck;
            }
            if(currentClosenessCheck < 0)                                           //If lessthan zero, same absolute value idea as above.
            {
                int absoluteValue = Math.Abs(currentClosenessCheck);
                currentClosenessCheck = absoluteValue;  
                return currentClosenessCheck;
            }                 
            if(previousClosenessCheck > currentClosenessCheck)                      //If the current guess is closer than the last one it will say "hotter".
            {
                Console.WriteLine("You are at least warmer than your last guess");
                return 0;
            }
            if(previousClosenessCheck < currentClosenessCheck)                      //If the current guess is further away, it will say "colder."
            {
                Console.WriteLine("You are actually colder than your last guess.");
                return 0;
            }
            return 0;
        }
    }while(i <= 4);                                             //Continues looping unless player wins.


}while(tries <= 5);                                             //Ends loop if user is out of attempts to guess.

if(guesses == 0)                                              
{
    Console.WriteLine("I'm sorry, you are out of guesses... better luck next time!"); //Loss message if user runs out of attempts.
}