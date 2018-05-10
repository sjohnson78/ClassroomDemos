using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OOPsDriver
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

        private int _Sides; // use the same name as the property, with an underscore in front of it

        // GET IN THE HABIT OF CODING COMPLETE STRUCTURES IE ADD THE OPEN AND CLOSE BRACKETS AT START, DO COMPLETE GET/SET STRUCTURE AS WELL BEFORE FILLING IN DETAILS

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

        public int FaceValue { get; set; }


    }
}
