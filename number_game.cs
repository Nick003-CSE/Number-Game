// number game (can not handle exceptions)
using System;
using System.Collections.Generic;
namespace beast
{
    class program
    {
        // game algorithm
        static void game(int number, int guessed_num, int level){
            List<int> _number = new List<int>();
            List<int> _guessed_num = new List<int>();
            List<int> correct_digit = new List<int>();
            int correct_digit_count = 0;
            int correct_place_count = 0;
            string message = "";

            // defining lists
            for (int i=0; i<4; i++){
                _number.Add(number%10);
                number/=10;
                _guessed_num.Add(guessed_num%10);
                guessed_num/=10;
            }
            
            // correct places
            for (int i=0; i<4; i++){
                if (_guessed_num[i]==_number[i])
                correct_place_count++;
            }

            // correct digits
            for (int i=0; i<4; i++){
                for (int j=0; j<_number.Count; j++){
                    if (_guessed_num[i] == _number[j]){
                        correct_digit.Add(_guessed_num[i]);
                        correct_digit_count++;
                        _number.Remove(_guessed_num[i]);
                    }
                }
            }

            // easy
            if (level == 1){
                if (correct_digit.Count == 0) 
                message = "None";
                else{
                    for (int i=0; i<correct_digit.Count; i++){
                        message += correct_digit[i].ToString() + ",";
                    }
                }
                Console.WriteLine("Correct digits = "+message+"\t&\t"+"Correct place count = "+correct_place_count);
            }

            // hard
            else
            Console.WriteLine("Correct digit count = "+correct_digit_count+"\t&\t"+"Correct place count = "+correct_place_count);
        }

        // general rules
        static void rules(){
            Console.WriteLine ("GUESS THE NUMBER");
            Console.WriteLine ("\nRULES: ");
            Console.WriteLine ("\t> You have infinite turns to guess; maximum point is 10.");
            Console.WriteLine ("\t> The number must be in range [1000, 9999].");
            Console.WriteLine ("\n\t> There are two levels; easy & hard.");
            Console.WriteLine ("\t> Easy: correct digits & number of correct places are shown.");
            Console.WriteLine ("\t> Hard: number of correct digits & number of correct places are shown.");
        }

        // driver program
        static void Main(string[] args){
            rules();

            // loop for playing more than once
            int flag = 1;
            do{
                Console.WriteLine("\nPress '1' for easy\n(any other number for hard)");
                int level = Convert.ToInt32 (Console.ReadLine());   // exception occurs, if int not given
                Random n = new Random();
                int number = n.Next(1000,10000);
                int turns = 0;
                int guessed_num = 0;

                // loop for guessing more than once
                while (number!=guessed_num){
                    Console.Write("Guess the number: ");
                    guessed_num = Convert.ToInt32 (Console.ReadLine());
                    turns++;
                    Console.Write("Turn "+turns+": ");
                    if (guessed_num>999 && guessed_num<10000)
                    game(number, guessed_num, level);
                    else
                    Console.WriteLine("Input not in range.");
                }

                // point
                float point = 10.5f - turns*0.5f;
                if (point<0.5f) 
                point = 0.5f;
                Console.WriteLine("You scored "+point);
                Console.WriteLine("\nPress 1 to replay: ");
                flag = Convert.ToInt32 (Console.ReadLine());    // exception occurs, if int not given
            }while (flag == 1);
            Console.WriteLine("\nThank You for playing. \nSee You Again!");            
        }
    }
}