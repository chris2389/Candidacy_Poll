/**********************************************************************
 * **
 * ** Programmer: Chris Hall
 * ** Date: 8/21/09
 * ** Course & Section: COMP 170 B 
 * **
 * ** Assignment: Candidacy Poll
 * **
 * ** File Name:Candidacy_Poll  
 * **
 * ** Description:A voting poll that takes the users vote a outputs the results 
 * **
 * ** Input: votes, answer, answer2
 * **
 * ** Output: total number of votes including precengates 
 * **
 * **********************************************************************/
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;

namespace Candidacy_Poll
{
    class Program
    {
        //Do not forget to change this---
        private const string FILE_NAME = "C:\\Users\\Chris\\Desktop\\Poll Results.txt";
        static void Main(string[] args)
        {
            //Answer Choice 
            char answer,
                answer2;
           
            do
            { 
                //Declared Variables
                double vote = 0,
                clinton =0,
                obama = 0,
                mccain = 0,
                nader = 0,
                none = 0,
                total = 0,  
                pClinton = 0,
                pObama = 0,
                pMccain = 0,
                pNader = 0,
                pNone = 0,
                error = 0,
                pError = 0;
                
                //Display the title and the canidates
                displayInput();
                do
                {
                    //Get the votes of the user
                    getUsersChoice(ref vote);
                    //Sort out the votes
                    getVotes(ref vote, ref clinton, ref obama, ref mccain, ref nader, ref none, ref error, ref total);
                    //Continue the votes of the user
                    continueLoop(out answer);

                    
                } while (answer == 'y');
             
            //Clac the votes of clinton
            clacVotesClinton( ref total,  ref clinton, out pClinton);
            //Clac Votes Obama
            clacVotesObama( ref total, ref obama, out pObama);
            //Clac Votes McCain
            clacVotesMccain(ref total, ref  mccain, out pMccain);
            //Clac Votes Nader
            clacVotesNader(ref total, ref  nader, out pNader);
            //Clac Votes None
            clacVotesNone(ref total, ref  none, out pNone);
            //Clac Invaild Votes
            clacInvalidVotes(ref total, ref error, out pError);
            //Display the Out put
            displayOutput(ref clinton, ref obama, ref mccain, ref nader, ref none, ref error, pClinton, pObama, pMccain, pNader, pNone, pError, total);
            //Display the Winner
            displayWinner(ref  clinton, ref  obama, ref   mccain, ref  nader);
            //Write the file
            writeFile(ref clinton, ref  obama, ref  mccain, ref  nader, ref   none, ref   error,  pClinton,  pObama,  pMccain,  pNader,  pNone,  pError,  total);
            //Continue the Poll
            continueLoop2(out answer2);
                
            } while (answer2 == 'y');
        }
        
        //Display menu 
        static void displayInput()
        {
            
            Console.WriteLine();
            Console.WriteLine("Opinion Poll with Functions");
            Console.WriteLine();
            Console.WriteLine("***********OPINION POLL*************");
            Console.WriteLine("     1. Hillary Clinton");
            Console.WriteLine("     2. Barack Obama");
            Console.WriteLine("     3. John McCain");
            Console.WriteLine("     4. Ralph  Nader");
            Console.WriteLine("     5. None of these are my favorite");
            
            
        }
        //Get users choice
        static void getUsersChoice(ref double vote)
        {
            Console.WriteLine("\nPlease choose your favorite candidate");
            Console.Write("on its corresponding number=>");
            vote = Convert.ToInt32(Console.ReadLine());
        }

        
        //Sort out votes
        static void getVotes(ref double vote, ref double clinton, ref double obama, ref double mccain, ref double nader, ref double none, ref double error, ref double total)
        {

            if (vote == 1)
            {
                clinton = clinton + 1;
            }
            else if (vote == 2)
            {
                obama += 1;
            }
            else if (vote == 3)
            {
                mccain += 1;
            }
            else if (vote == 4)
            {
                nader += 1;
            }
            else if (vote == 5)
            {
                none += 1;
            }
            else
            {
                Console.WriteLine("<<<<Error, wrong number. 1-5 Only>>>>");
                error += 1;
            }

            total = clinton + obama + mccain + nader + none + error;

            
        }
     

        //Votes for clinton
        static void clacVotesClinton(ref double total, ref double clinton, out double pClinton)
        { 

            pClinton =  (clinton / total);
        }

        //Votes for Obama
        static void clacVotesObama(ref double total, ref double obama, out double pObama)
        {
            pObama = (obama / total);
        }

        //Votes for Mccain
        static void clacVotesMccain(ref double total, ref double mccain, out double pMccain)
        {
            pMccain = (mccain / total);
        }
           
        //Votes for Nader
        static void clacVotesNader(ref double total, ref double nader, out double pNader)
        {
            pNader = (nader / total);
        }

        //Votes for none
        static void clacVotesNone(ref double total, ref double none, out double pNone)
        {
            pNone = (none / total);
        }

        //Invalid Votes
        static void clacInvalidVotes(ref double total, ref double error, out double pError)
        {
           pError = (error / total);
        }
        
        //OutPut
        static void displayOutput(ref double clinton, ref double obama, ref  double mccain, ref double nader, ref  double none, ref  double error, double pClinton, double pObama, double pMccain, double pNader, double pNone, double pError, double total)
        {
            Console.WriteLine("\n\t\t\tOPINIPON POLL RESULTS");
            Console.WriteLine("\nCANDIDATE                    VOTES                     PERCENTAGE");
            Console.WriteLine("-------------------------------------------------------------------");
            Console.WriteLine("Total votes for Clinton: {0, 6} {1,33:0%} ", clinton, pClinton);
            Console.WriteLine("Total votes for Obama {0, 9} {1, 33:0%}", obama, pObama);
            Console.WriteLine("Total votes for McCain {0, 8} {1, 33:P2}", mccain, pMccain );
            Console.WriteLine("Total votes for Nader {0, 9} {1, 33:P2}", nader, pNader);
            Console.WriteLine("Total votes for None {0, 10} {1, 33:P2}", none, pNone);
            Console.WriteLine("Total Invalid votes {0, 11} {1, 33:P2}", error, pError);
            Console.WriteLine("\n Total number of votes => {0}", total);
            


        }

        //Display the Winner
        static void displayWinner(ref double clinton, ref double obama, ref  double mccain, ref double nader)
        {
            if (clinton > obama && clinton > mccain && clinton > nader)
            {
                Console.WriteLine("\nHillary Clinton Wins the Poll!");
            }
            else if (obama > clinton && obama > mccain && obama > nader)
            {
                Console.WriteLine("\nBarack Obama Wins the Poll!");
            }
            else if (mccain > clinton && mccain > obama && mccain > nader)
            {
                Console.WriteLine("\nJohn McCain Wins the Poll!");
            }
            else if (nader > clinton && nader > mccain && nader > clinton)
            {
                Console.WriteLine("\nRalph Nader Wins the Poll!");
            }
            else
            {
                Console.WriteLine("\nNo body wins. :( Or its even.");
            }
            Console.WriteLine("Check you desktop for the 'Results' file.");
        }
        //Write the text file
        static void writeFile(ref double clinton, ref double obama, ref  double mccain, ref double nader, ref  double none, ref  double error, double pClinton, double pObama, double pMccain, double pNader, double pNone, double pError, double total)
        {
            StreamWriter sWriter = File.CreateText(FILE_NAME);
            sWriter.WriteLine("\nCANDIDATE                    VOTES                     PERCENTAGE");
            sWriter.WriteLine("-------------------------------------------------------------------");
            sWriter.WriteLine("Total votes for Clinton: {0, 6} {1,33:P2} ", clinton, pClinton);
            sWriter.WriteLine("Total votes for Obama {0, 9} {1, 33:P2}", obama, pObama);
            sWriter.WriteLine("Total votes for McCain {0, 8} {1, 33:P2}", mccain, pMccain);
            sWriter.WriteLine("Total votes for Nader {0, 9} {1, 33:P2}", nader, pNader);
            sWriter.WriteLine("Total votes for None {0, 10} {1, 33:P2}", none, pNone);
            sWriter.WriteLine("Total Invalid votes {0, 11} {1, 33:P2}", error, pError);
            sWriter.WriteLine("\n Total number of votes => {0}", total);
            sWriter.Close();
        }
        //Continue the voting
       static void continueLoop(out char answer)
       {
           Console.WriteLine("\n!!!!Question...");
           Console.Write("\nDo you want to continue? (y for yes, n for no)");
           answer = Convert.ToChar(Console.ReadLine());
           answer = char.ToLower(answer);
           if(answer != 'y' || answer != 'n')
           {
                Console.WriteLine("\n!!!!Please Enter y or n.");
                Console.Write("\nDo you want to continue? (y for yes, n for no)");
                answer = Convert.ToChar(Console.ReadLine());
           }
       }

        //Continue the poll
       static void continueLoop2(out char answer2)
       {
           Console.Write("\n^Start a New Poll?^ (y for yes, n for no): ");
           answer2 = Convert.ToChar(Console.ReadLine());
           answer2 = char.ToLower(answer2);
           if (answer2 != 'y' || answer2 != 'n')
           {
               Console.WriteLine("\n!!!!Please Enter y or n.");
               Console.Write("\nDo you want to continue? (y for yes, n for no)");
               answer2 = Convert.ToChar(Console.ReadLine());
           }
       }
     }
}
