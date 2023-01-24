/*
Name Hasib Yosufi
Student #: 041012318
Assessment: Lab1

*/















using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using System.Numerics;
using System.Security.Cryptography;
using System.Net.WebSockets;
using System.Diagnostics;

namespace Lab1
{


    class Program
    {



        static void printMenu() {

            string endWithD = "Get and display words that end with /'d/' and display the count";
            string includeQ = "Get and display words that include  /'q/' and display the count";
            string wordsMoreThan3 = "Get and display words that are more than 3 characters long and start with the letter 'a', and display the count";

            Console.WriteLine("1 - Import Words from File\n2 - Bubble Sort words\n" + 
                "3 - LINQ/Lambda sort words\n4 - Count the Distinct Words\n5 - Take last 10 words\n" + 
                "6 - Reverse print the words\n7 - " + endWithD + "\n8 - " + includeQ +
                "\n9 - " + wordsMoreThan3 + "\nx - Exit\n");
        
        }
       
       static List<string> bubbleSort(List<string> s) 
        {
            if( s == null){
               

                throw new ArgumentNullException("Null argument exception");
            }


            string[] copy = s.ToArray();

            Stopwatch stopwatch = new Stopwatch();
            stopwatch.Start();

            for(int i = 0; i < (copy.Length - 1); i++)
            {
                for(int j = 0; j < ((copy.Length - 1) - i); j++)
                {
                    //compare two string alphabetically (a < b and b is < c and ...) return 1 if greater -1 if < 0 if equal
                    int comp = string.Compare(copy[j], copy[j + 1]);

                    if(comp > 0)
                    {
                        string temp = copy[j];
                        copy[j] = copy[j + 1];
                        copy[j + 1] = temp;
                    }
                    else if (comp == 0) continue;
                    
                    
                }

            }

            stopwatch.Stop();
           

         
           
            //convert bubble sorted array to list
            s = copy.ToList();

            s.ForEach(x => Console.WriteLine(x));

            //print the time has been taken by bubblesort algorithm
            Console.WriteLine("Time that has been taken is " + stopwatch.ElapsedMilliseconds + " ms");

            //just in case (Extra caution) for GC
            copy = null;


            
            return s;
        }//bubbleSort()



        /**
         Linq_sort method uses the Linq query orderby to sort the string list
         @PARAM List<string>list</string>
         @RETURN List<string>list</string>
         
         */
        static List<string> Linq_Sort(List<string> list)
        {
            if( list == null) { throw new ArgumentNullException("null argument"); }


            Stopwatch watch = new Stopwatch();
            watch.Start();
            
            
            var sortedList = from s in list
                             orderby s.Substring(0, 1) ascending
                             select s;


            watch.Stop();
           
            list = sortedList.ToList();
            

            list.ForEach(x => Console.WriteLine(x));

            Console.WriteLine($"time that has been taken is {watch.ElapsedMilliseconds} ms");

            return list;
        }

        /**
         Count distinct words
         return int 
         */
        static int distinctWords(List<string> s)
        {
            if(s == null) { throw new ArgumentNullException("null arg"); }


            return s.Distinct().Count();
        }


        static void LastTen(List<string> s)
        {

            if (s == null) { throw new ArgumentNullException("null arg"); }

            var last = s.Skip(s.Count() - 10).Take(10).ToList();

            last.ForEach(x => Console.WriteLine(x));

        }

        /**
         Print list in reverse 
         */
        static void printReverse(List<string> s)
        {
            if(s == null) { throw new ArgumentNullException("Null args"); }

            s.Reverse();
            s.ForEach(x => Console.WriteLine(x));
        }


        /**
         
         print words that ends with d
         
         */
        static void printEndWithD(List<string> s)
        {
            if (s == null) { throw new ArgumentNullException("Null args"); }


            var endWithD = s.Where(x => x.EndsWith("d")).ToList();
            endWithD.ForEach(x => Console.WriteLine(x));

            var endD = from list in s
                       where (list.EndsWith("d"))
                       select list;

            foreach(string i in endD) { Console.WriteLine(i); }

            Console.WriteLine("number of words end with d is " + endD.Count());


        }


        /**
         * print words that contain q
         * @PARAM list : string
         */

        static void printContainQ(List<string> s)
        {
            if (s == null) { throw new ArgumentNullException("Null args"); }


            var containQ = from list in s
                           where list.Contains("q")
                           select list;
            int size = containQ.Count();
             foreach(string g in containQ)
            {
                Console.WriteLine(g);
            }

            Console.WriteLine("Number words that contain q is {0}", size);

        }

        /**
         prints words that are more than 3 character long
         
         */

        static void printThreeLongStartWithA(List<string> s)
        {
            if (s == null) { throw new ArgumentNullException("Null args"); }


            var startWithA = from list in s
                             where (list.StartsWith("a") && list.Length > 3)
                             select list;



            foreach(string g in startWithA) {
                Console.WriteLine(g);
            
            }

            Console.WriteLine("Word count is :"+startWithA.Count());


        }



        /**
         Main method execute the program
         
         */
        static void Main(string[] args)
        {
            



           


            string fileName = "Words.txt";
            List<string> words = null;


            while (true)
            {
                try
                {

                    //menu()
                    printMenu();
                    Console.Write("Enter an option: ");
                    string read = Console.ReadLine();
                    if (!(read.Equals("x") || read.Equals("X")))
                    {

                        int option;
                        bool res = int.TryParse(read, out option); //checks if string has integer or not
                        
                        if(res == false) { throw new ArgumentException("Wrong input"); }

                        else 
                        {
                            switch (option)
                            {
                                case 1:
                                     words = File.ReadAllLines(fileName).ToList();
                                    break;

                                case 2:
                                   words =  bubbleSort(words);
                                    break;

                                case 3:
                                  words =  Linq_Sort(words);
                                    break;

                                case 4:
                                    Console.WriteLine("Distinct words count is " + distinctWords(words));
                                    break;
                                case 5:
                                    LastTen(words);
                                    break;
                                case 6:
                                    printReverse(words);
                                    break;
                                case 7:
                                    printEndWithD(words);
                                    break;
                                case 8:
                                    printContainQ(words);
                                    break;
                                case 9:
                                    printThreeLongStartWithA(words);
                                    break;


                            }//end switch

                        }
                       
                       
                       
                    }//end if


                    //if equals to x then break
                    else { break; }
                  



                }//end try
                catch (ArgumentException e)
                {
                    Console.WriteLine(e.Message);

                }
                catch(NullReferenceException e) {
                    Console.WriteLine(e.Message);
                
                }
                catch (Exception e)
                {
                    Console.WriteLine(e.Message);
                }//end catch

            }//end while()

            }//end main()
    }//end class Program
}//end nameSpace 
