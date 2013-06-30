using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Candidacy_Poll_Arrays
{
    class Program
    {
        static void Main(string[] args)
        {
            char answer,
                answer2;
            int[] votes;
            
                     
           

                /*
                clition = 0
                obama = 1,
                mccain = 2,
                nader = 3,
                none = 4,
                error = 5
                total = 6,
                vote = 7,
                pClinton = 0,
                pObama = 0,
                pMccain = 0,
                pNader = 0,
                pNone = 0,
                error = 0,
                pError = 0;*/
            do
            {
                do
                {
                    displayInput(votes,7);
                    getVotes(vote, ref clinton, ref obama, ref mccain, ref nader, ref none, ref error, ref total);

                    continueLoop(out answer);


                } while (answer == 'y');


                clacVotesClinton(ref total, ref clinton, out pClinton);
                clacVotesObama(ref total, ref obama, out pObama);
                clacVotesMccain(ref total, ref  mccain, out pMccain);
                clacVotesNader(ref total, ref  nader, out pNader);
                clacVotesNone(ref total, ref  none, out pNone);
                clacInvalidVotes(ref total, ref error, out pError);
                displayOutput(clinton, obama, mccain, nader, none, error, pClinton, pObama, pMccain, pNader, pNone, pError, vote);
                continueLoop2(out answer2);

            } while (answer2 == 'y');
        }

        //Display menu 
        static void displayInput(int[] votes, int 7)
        {

            Console.WriteLine("");
            Console.WriteLine("Opinion Poll with Functions");
            Console.WriteLine("");
            Console.WriteLine("***********OPINION POLL*************");
            Console.WriteLine("     1. Hillary Clinton");
            Console.WriteLine("     2. Barack Obama");
            Console.WriteLine("     3. John McCain");
            Console.WriteLine("     4. Ralph  Nader");
            Console.WriteLine("     5. None of these are my favorite");
            Console.WriteLine("Please choose your favorite candidate");
            Console.Write("on its corresponding number=>");
            votes[i] = Convert.ToInt32(Console.ReadLine());

        }


        //Sort out votes
        static void getVotes(double vote, ref double clinton, ref double obama, ref double mccain, ref double nader, ref double none, ref double error, ref double total)
        {

            if (vote == 1)
            {
                clinton += 1;
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
                Console.WriteLine("Error, wrong number.");
                error += 1;
            }

            total = clinton + obama + mccain + nader + none + error;


        }


        //Votes for clinton
        static void clacVotesClinton(ref double total, ref double clinton, out double pClinton)
        {

            pClinton = (clinton / total);
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


        static void clacInvalidVotes(ref double total, ref double error, out double pError)
        {
            pError = (error / total);
        }

        //OutPut
        static void displayOutput(double clinton, double obama, double mccain, double nader, double none, double error, double pClinton, double pObama, double pMccain, double pNader, double pNone, double pError, double total)
        {
            Console.WriteLine("\nCANDIDATE                    VOTES                     PERCENTAGE");
            Console.WriteLine("-------------------------------------------------------------------");
            Console.WriteLine("Total votes for Clinton: {0, 6} {1, 33:P2} ", clinton, pClinton);
            Console.WriteLine("Total votes for Obama {0, 9} {1, 33:P2}", obama, pObama);
            Console.WriteLine("Total votes for McCain {0, 8} {1, 33:P2}", mccain, pMccain);
            Console.WriteLine("Total votes for Nader {0, 9} {1, 33:P2}", nader, pNader);
            Console.WriteLine("Total votes for None {0, 10} {1, 33:P2}", none, pNone);
            Console.WriteLine("Total Invalid votes {0, 11} {1, 33:P2}", error, pError);
            Console.WriteLine("\n Total number of votes => {0}", total);


        }

        //Continue the voting
        static void continueLoop(out char answer)
        {
            Console.WriteLine("\nQuestion...");
            Console.Write("\nDo you want to continue? (y for yes, n for no)");
            answer = Convert.ToChar(Console.ReadLine());
            answer = char.ToLower(answer);
        }

        //Continue the poll
        static void continueLoop2(out char answer2)
        {
            Console.Write("\nStart a New Poll? (y for yes, n for no): ");
            answer2 = Convert.ToChar(Console.ReadLine());
            answer2 = char.ToLower(answer2);
        }
    }
}
