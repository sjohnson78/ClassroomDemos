using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OOPsDriver
{
    class Program
    {
        static void Main(string[] args)
        {

            // create instances of our objects to be used in this program

            // you can check for additional namespaces that may me needed to use your objects

            // when you create a project, the default namespace is set to the project name
            // a good way to visualize projects would be as different buildings on campus... the object would be room number... you could have two room 100's,
            // but you can tell them apart because one is in CAT and one is in HP

            // we need to have a structure that will allow us to hold an unknown number of instances of a variable => USE A LIST

            // array is used for a fixed number of items, list is used for an unknown number of items

            // List<T> the T here stands for template, you would want to use the variable name being stored in the list, below using Turn

            // List<T> is an object that holds x number of datatype instances

            // the new List<T> physically creates the instance of List<T> in memory

            // the constructor of List<T> is called

            List<Turn> gameTurns = new List<Turn>(); // FIGURE OUT EXACTLY WHAT HAPPENS HERE

            // create two instances of the Die object

            Die Player1Dice = new Die();                    // default constructor      
            Die Player2Dice = new Die(6, "Green");          // greedy constructor

            string menuChoice = "";
            do
            {
                Console.WriteLine("Game Menu: \n");
                Console.WriteLine("A) Set Die side count");
                Console.WriteLine("B) Roll the dice");
                Console.WriteLine("C) Display all game turn results");
                Console.WriteLine("X) Exit");
                Console.Write("Enter menu choice: ");
                menuChoice = Console.ReadLine();

                switch (menuChoice.ToUpper())
                {
                    case "A":
                        {
                            // logic can de done using a method
                            // the method will need to have the local variables Player1Dice and Player2Dice passed to it
                            // objects are passed as references
                            Console.WriteLine("You selected A");
                            break;
                        }
                    case "B":
                        {
                            //logic can be done actually inside the case
                            //one does not have to always call a method

                            Console.WriteLine("You selected B");
                            break;
                        }
                    case "C":
                        {
                            Console.WriteLine("You selected C");
                            break;
                        }
                    case "X":
                        {
                            Console.WriteLine("Thank you for playing. Come again.");
                            break;
                        }
                    default:
                        {
                            Console.WriteLine("Invalid menu choice. Try again.");
                            break;
                        }

                } // end of switch
            } while (menuChoice.ToUpper() != "X");

            Console.ReadKey();

        } // end of main

        public static void SetDiceSides(Die player1dice, Die player2dice) 
        {
            // Don's coding best practice is to code local variables in all lower case
            string idicesize = ""; // using in represents integer, maybe just use i since that's what I'm used to
            int dicesize = 6;

            Console.WriteLine("Set dice face count of 6 to 20");
            Console.WriteLine("An invalid entry will default to 6");
            Console.WriteLine("Enter number of sides: ");
            idicesize = Console.ReadLine();

            //////////////
            // Validation
            //////////////

            // a. did the user enter a number?
            if (!int.TryParse(idicesize, out dicesize)) // FIGURE OUT HOW THIS SHIT WORKS TOO
            {
                Console.WriteLine("Die size is invalid and will be set to 6.");
                dicesize = 6;
            }

            else
            {
                // b. is integer between 6 an 20?
                if (dicesize < 6 || dicesize > 20)
                {
                    Console.WriteLine("Die size is invalid and will be set to 6.");
                    dicesize = 6;
                }

                else
                {
                    Console.WriteLine("Die size will be set to {0}", dicesize);
                }
            }
            player1dice.SetSides(dicesize); // FIGURE OUT HOW THIS WORKS TOO, COMPARE TO CONSOLE.WRITELINE
            player2dice.SetSides(dicesize);

        } // closes SetDiceSides method

    }
}

// f10 advances one line of code, f5 advances to next break, f11 advances to next method