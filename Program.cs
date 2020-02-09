using System;


namespace Assignment1_Spring2020
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = 5;
            if (n > 0)
                PrintPattern(n);
            else
                Console.WriteLine("Please provide a greater than zero value");

            int n2 = 6;
            PrintSeries(n2);

            string s = "09:15:35 PM";
            string t = UsfTime(s);
            Console.WriteLine(t);

            int n3 = 110;
            int k = 11;

            if (n3 < 1 || n3 > 110 || k !=11)
                Console.WriteLine("Please provide number between 1 and 110 and k should be 11");
            else
                UsfNumbers(n3, k);


            string[] words = new string[] { "abcd", "dcba", "lls", "s", "sssll" };
            PalindromePairs(words);

            Console.WriteLine();
            Stones(6);


        }
        /*n – number of lines for the pattern, integer (int)
           summary   : This method prints number pattern of integers using recursion
            For example n = 5 will display the output as: 
             54321
              4321
              321
                21
                 1
                returns      : N/A
               return type  : void */
 


        /// <summary>
        /// in this we will print a pattern  using recurssion instead of loop becasue its a short code  so time complexity is not an issue here we will
        /// 5 t0 1 pattern in decreasing order each time in  diffrent line.so our n  is  for  and 5 integer first we put a condition using if  if 
        /// n is greater and or euqal to 1 then we define logic  where i is for iteration and is equal to n that is 5 
        /// and it will run  untill i is equal or  greater than 1  will print each time and i-- is for decreasing order of pattern.console write means each time
        ///will write pattern and console write each time  in different line  print pattern  n-1 call for next time decremented value since n
        ///each time decrease by 1 and print pattern untill it become  1.  time taken is 2-3 hours.  corner case will be that number should  greater than 0 to print a pattern.
        /// </summary>
        /// <param name="n"></param>
        private static void PrintPattern(int n)
        { 
            try
            {
                if (n >= 1)//base condition
                {
                    for (int i = n; i >= 1; i--)//print n to 1 each time
                        Console.Write(i);

                    Console.WriteLine();//change line

                    PrintPattern(n - 1); // call for the next decreemented value
                }
            }
            catch
            {
                Console.WriteLine("Exception Occured while computing Print Pattern");

            }
        }

        /*n2 – number of terms of the series, integer (int)
          This method prints the following series till n terms: 1, 3, 6, 10, 15, 21……
          For example, if n2 = 6, output will be
          1,3,6,10,15,21
          Returns : N/A
          Return type: void
        Hint: Series is 1,1+2=3,1+2+3=6,1+2+3+4=10,1+2+3+4+5=15, 1+2+3+4+5+6=21……*/
 


        /// <summary>
        /// in this method we have to print a series  n2 that is integer number should be grater than zero to run this program
        ///logic is suppose the next digit is 1 than diffrence is 2  because 1-2  equal 1 and 1+1 =2 so the 2+1 =3, same next digit 3 and diffrence is (3 ) 
        ///  so answer is 6 and n2 is 6 so i should less  than 6 or less. time taken 2-3 approx. learn how to put logic in c#. corner case would be number n2 should be grater than 0 so print the logic.
        /// nextDigit->   1, 3, 6, 10, 15, 21
        /// difference->  2, 3, 4, 5, 6, 7
        ///  print-->     1   3  6   10   15  21
        /// </summary>
        /// <param name="n2"></param>
        private static void PrintSeries(int n2)
        { 
            try
            {
                if (n2 > 0)
                {
                    int nextDigit = 1;
                    int difference = 2;
                    for (int i = 1; i <= n2; i++)
                    {
                        Console.Write(nextDigit + " ");
                        nextDigit = nextDigit + difference;
                        difference = difference + 1;


                    }
                    Console.WriteLine();
                }
                else
                {
                    Console.WriteLine("Please provide a value greater than zero");
                }

            }
            catch
            {
                Console.WriteLine("Exception Occured while computing printSeries");
            }
        }

        /// <summary>
        /// On planet “USF” which is similar to that of Earth follows different clock where instead of hours they have U , instead of minutes they have S, instead
        /// of seconds they have F. Similar to earth where each day has 24 hours, each hour has 60 minutes and each minute has 60 seconds , USF planet’s day has 36 U , each
        /// U has 60 S and each S has 45 F. Writing a method usfTime which takes 12HR format and return string representing input time in USF time format.
        /// </summary>
        /// <param name="s"></param>
        /// <returns></returns>
        public static string UsfTime(string s)
        {    int hour, min, sec, U, S, F;
            String[] timeFormat = s.Split(' '); ;
            String[] originalTime = timeFormat[0].Split(':');


            hour = Convert.ToInt32(originalTime[0]);
            min = Convert.ToInt32(originalTime[1]);
            sec = Convert.ToInt32(originalTime[2]);

            int CurrentSecondsOnEarth;
            // In this program if the time format is in PM format we need to convert the Earth time in PM format into 24 hour format 
            // ie 9PM + 12hr = 21hrs, thus the Earth time in 24hr format is 21:15:35
            // Then we calculate the total num of seconds that have passed till 21:15:35 = 21*60*60 + 15*60 + 35
            // ie 76535 secs
            if (timeFormat[1].Equals("PM"))
            {
                CurrentSecondsOnEarth = ((12 + hour) * 3600 + min* 60 + sec);
                //Console.WriteLine("CurrentSecondsOnEarth :" + CurrentSecondsOnEarth);
            }
            else
            {
                CurrentSecondsOnEarth = ((hour) * 3600 + min* 60 + sec);
                //Console.WriteLine("CurrentSecondsOnEarth :" + CurrentSecondsOnEarth);
            }

            //Since 24hr on earth = 36U on USF, 
            //60min on Earth = 60S on USF and 
            //60sec on Earth = 45F on USF
            //So deriving the U's as integer value of 76535/(60*45) ie 28U
            //Then we need to derive the remainder by taking the mod as follows 76535mod(60*45)= 935
            //Then deriving the S's as integer value of 935/45 ie 20S
            //Then we need to derive the remainder ie the F's by taking the mod as follows 935mod45= 35
            U = CurrentSecondsOnEarth / 2700;
            int rem = CurrentSecondsOnEarth % 2700;
            S = rem / 45 ;
            rem = rem % 45;
            F =  rem;

            return (U + ":" + S + ":" + F );


        }

        

        
       /*  n- total number of integers( 110 )
 k-number of numbers per line( 11)
  USF Numbers : This method prints the numbers 1 to 110, 11 numbers per line.
 The method shall print 'U' in place of numbers which are multiple of 3,"S" for 
  multiples of 5,"F" for multiples of 7, 'US' in place of numbers which are multiple 
  of 3 and 5,'SF' in place of numbers which are multiple of 5 and 7 and so on */

        
        public static void UsfNumbers(int n3, int k)
        {
            try
            {
                Console.WriteLine();
                for (int i = 1; i <= n3; i++) // i should be 1 and less than 110 that is less than  n3. 
                {
                    if (i % 3 == 0 && i % 5 == 0)//if number is divisible by 3 and 5  ex 15 then it will print "US". 
                    {
                        Console.Write(" US");

                    }
                    else if (i % 5 == 0 && i % 7 == 0)// If number is divisible by 7 and 5 ex 35 then it will print SF.
                    {
                        Console.Write(" SF");

                    }
                    else if (i % 3 == 0 && i % 7 == 0) //if number divisible by 3 and 7 ex 21 then it will print UF.
                    {
                        Console.Write(" UF");

                    }
                    else if (i % 3 == 0)//if  divisible by 3 then U.
                    {
                        Console.Write(" U");

                    }
                    else if (i % 5 == 0) //if divisible by 5 then S.
                    {
                        Console.Write(" S");

                    }
                    else if (i % 7 == 0) //  if number is divisible by 7 then it will print F.
                    {
                        Console.Write(" F");

                    }
                    else
                    {
                        Console.Write(" " + i);

                    }

                    if (i % (k - 1) == 0) // for printing in 11 line 
                        Console.WriteLine();

                }

            
            }
            catch
            {
                Console.WriteLine("Exception occured while computing UsfNumbers()");
            }
        }


        /// <summary>
        ///  You are given a list of unique words, the task is to find all the pairs of 
      ///distinct indices(i, j) in the given list such that, the concatenation of two
      /// words i.e.words[i]+words[j] is a palindrome.
      /// Example:
      ///Input: ["abcd","dcba","lls","s","sssll"]
       ///Output: [[0,1], [1,0], [3,2], [2,4]] 

        ///
        /// 
        /// </summary>
        /// <param name="words"></param>
        public static void PalindromePairs(string[] words)
        {
            try
            {
                
                if (words.Length < 2)
                {
                    Console.WriteLine("Please provide atleast 2 words");//corner case if word length is less two program will not run.
                }
                else
                {
                    for (int i = 0; i < words.Length; i++)// we will take word i and compare with word j to check if they are making plaindrome  pair or not.
                    {
                        for (int j = 0; j < words.Length; j++)
                        {
                            if (j != i) //i and j should not  be same word 
                            {
                                string pair = "";
                                pair = words[i] + words[j];

                                if (isPalindrome(pair))
                                {
                                    Console.Write("[" + i + "," + j + "]");
                                }
                            }
                        }
                    }
                }
            }
            catch
            {

                Console.WriteLine("Exception occured while computing PalindromePairs()");
            }
        }


        /*You are playing a stone game with one of your friends. There are N number of 
  stones in a bag, each time one of you take turns to take out 1 to 3 stones.
  The player who takes out the last stone will be the winner.In this case you
  will be the first player to remove the stone(s)(Player 1).
  Write a method to determine whether you can win the game given the number of 
  stones in the bag. Print false if you cannot win the game, otherwise print any
  one set of moves where you are winning the game. Array should contain moves by
  both the players.*/

        /// Calculates any one set of moves where Player 0 is winning and print them.
        /// If Player 1 is winning, the method resets the number stones and set of moves and calculates the moves until player 0 wins. 
        // time taken 5 hours approx. learning  arrays.putting logic in c#
        /// </summary>
        /// <param name="n4"></param>
        public static void Stones(int n4)
        {
            try
            {
         
                Random random = new Random();
                int reset = n4;   
                int player = 0;
                int r;
                int[] moves = new int[n4];
                int index = 0;

                //Only case where winning is impossible
                if (n4 == 4 || n4==0) //In case of 0 and 4 number of stones 
                // the player 0 can never win, for these cases this method prints False
                {
                    Console.Write("False");

                }
                else
                {
                    while (n4 > 0)
                    {
                        r = random.Next(0, 4);
                        if (r > 0 && r <= n4)
                        {
                            switch (r)
                            {
                                case 1:
                                    n4 = n4 - r;
                                    if (player == 0)
                                        player = 1;
                                    else
                                        player = 0;
                                    moves[index] = 1;
                                    index++;
                                    break;
                                case 2:
                                    n4 = n4 - r;
                                    if (player == 0)
                                        player = 1;
                                    else
                                        player = 0;
                                    moves[index] = 2;
                                    index++;
                                    break;
                                case 3:
                                    n4 = n4 - r;
                                    if (player == 0)
                                        player = 1;
                                    else
                                        player = 0;
                                    moves[index] = 3;
                                    index++;
                                    break;
                                default:
                                    break;
                            }
                        }
                        //If Player 2 wins, Reset the number of stones and again calculate for Player 1
                        if (n4 == 0 && player == 0)
                        {
                            n4 = reset;
                            index = 0;
                            Array.Clear(moves, 0, moves.Length);
                        }
                    }


                    //Printing Winning case for Player 1
                    if (n4 == 0 && player == 1)
                    {
                        Console.Write("[");
                        foreach (int move in moves)
                        {
                            if (move != 0)
                                Console.Write(move + ",");
                        }
                        Console.Write("\b]");

                    }
                }
            }
            catch
            {
                Console.WriteLine("Exception occured while computing Stones()");
            }
        }
        /// <summary>
        /// function for palindrome pair finding
        /// </summary>
        /// <param name="pair"></param>
        /// <returns></returns>
        public static Boolean isPalindrome(string pair)
        {
            int len = pair.Length;

            for (int i = 0; i < len / 2; i++)
            {
                if (pair[i] != pair[len - i - 1])
                {
                    return false;
                }
            }
            return true;
        }
    }
}

