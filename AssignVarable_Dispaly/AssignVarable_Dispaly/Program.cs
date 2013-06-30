/**********************************************************************
**
** Programmer: Chris Hall   
** Date: 7/6/2009
** Course & Section: COMP 170 B
**
** Assignment: Lab 
**
** File Name: firstlab.cpp
**
** Description: Displays varables
**
** Input: number
**
** Output: The value of number is, The value of number is now
**
**********************************************************************/
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
namespace AssignVarable_Dis
{
    class Program
    {
        static void Main(string[] args)
        {

            int number; 


            number = 7865;
            Console.WriteLine("The value of number is " + number + ",");

            number = 5678;
            Console.WriteLine("The value of number is now " + number + ",");

            number = 27;
            Console.WriteLine("The value of number is now " + number + ",");
        }
    }
}
