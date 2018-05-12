using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OOPsDriver

    // REBUILD AT THE END OF EDITING CODE
{
    // default access privelige of a class is private, you MUST add public to your classes to be able to access them


    public class Die
    {
        // create a new instance of the math object Random
        // this will be shared by each instance of Die
        // the instance of Random, which is an object, will be created when the first instance of Die is created
        // this will be a static instance (example used is a taxi.... everyone can share the taxi, no one gets their own taxi)

            private static Random _rnd = new Random();

        // classes have:
        //  a. data members
        //  b. properties
        //  c. constructors
        //  d. behaviours (aka methods)

        // data members may be private for the class, meaning they are able to use used only within the class

        // the interface with a class is done via properties and behaviours

        // properties

        // can be fully implemented:
        //  -a private data member
        //  -a public property


            // this is a data member?
        private int _Sides; // use the same name as the property, with an underscore in front of it

        // GET IN THE HABIT OF CODING COMPLETE STRUCTURES IE ADD THE OPEN AND CLOSE BRACKETS AT START, DO COMPLETE GET/SET STRUCTURE AS WELL BEFORE FILLING IN DETAILS

            // this is a property?
        public int Sides
        {
            get     // what does get do lol???
            {
                // this will return the private data member
                // MAKE SURE YOU RETURN _SIDES AND NOT SIDES, YOU WANT TO RETURN THE PRIVATE NOT THE PUBLIC OR ELSE YOU'LL GET AN ENDLESS LOOP ERROR
                return Sides;
            }

            set     // what does set do lol???
            {
                // "value" is a reserved key word used by the compiler to obtain the incoming data value to the property
                // make sure you save the incoming data value to your private
                _Sides = value;
            }
        }

        // can be auto implemented:
        //  -does not have a private data member
        //  -the system craetes and internal data storage member for the property

        public int FaceValue { get; set; } // FIGURE OUT WHAT THIS DOES TOO

        // within a property you can validate that the incoming data value is "of the expected type (not sure if type is the right word here)"

        private string _Color; // the data member often closely resembles the property
        public string Color
        {
            get     // get must always return something
            {
                return _Color; // make sure to return _Color and not Color, avoiding an infinite loop
            }
            set
            {
                // sample validation
                // there MUST be data within the incoming value
                // therefore, an empty string is invalid

                // reasons for using "IsNullOrEmpty" instead of "if(value = mull)" or "if (value ="") is that it covers both instead of just one outcome
                if (string.IsNullOrEmpty(value))
                {
                    // code here runs if the incoming data value is null or empty, you must use either A or B

                    // A. you could send an error message to the outside user, example below
                    throw new Exception("Color must have a value");

                    // B. you could allow the storage of a null value within the string data member
                    // _Color = null;

                }

                else
                {
                    // this code will run if the incoming data value is not null or empty, and sets the _Color = value;
                    _Color = value;
                }

            }
        }

        /////////////////////
        //      Constructors
        /////////////////////

        // Constructors are NOT directly called by the outside user
        // constructors are called indirectly when the outside user creates an instance of the class

        // to create an instance of the class, the outside user will declare the class using the following syntax:
        // class variablename = new class ();
        // "new" is the part of this syntax that is calling the constructor

        //  you may or may not have a constructor for your class

        //  if you do not code a construcor for your class, a default system constructor is executed
        //  this default system constructor initializes your local data members to their default C# values 
        // (for example, the default value for a string is null, the default value for a number is 0, the default value for a bool is false)

        // if you do code a constructor for your class, then YOU ARE RESPONSIBLE for any and all constructor in the class

        // there are two types of constructors that we use: greedy and default

        /////////////////////////
        // "Default" Constructor
        /////////////////////////

        // the default constructor is similar to the system constructor. Example:
        // this constructor would be called for something like: new classname();
        public Die()
        {

        }

        ////////////////////////
        // "Greedy" Constructor
        ////////////////////////

        // this constructor usually recieves a list of paramaters, one for each data member in the class
        // this constructor takes these parameter values and assigns them to the appropriate data member
        // this constructor would be called for something like: new classname(value1, value2, value3, ...)

        public Die(int sides, string color)
        {
            // what is the difference between data member or property
            // property has a built in validation, therefore we should always assign to properties here instead of data members

            Sides = sides; // the set {} of the property Sides is used
            Color = color;
        }

    } // end of class die
} // end of namespace

// REBUILD AT THE END OF EDITING CODE