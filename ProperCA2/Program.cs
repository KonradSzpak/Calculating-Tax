/*=======================
 * Name: Konrad Szpak
 * Student ID: S00197298
 * Date: 02-03-2020
 * Description: CA2
=========================*/

using System;

namespace CA2Prac
{
    class Program
    {




        // just 1 arrays to store amount of specific grade and 2nd array to just store chars for simpler output
        static int[] valuationTypes = new int[7] { 0, 0, 0, 0, 0, 0, 0 };  //keeps a record of each grade 
        static string[] displayTextRates = new string[7] { "0-100,000","100,001-150,000","150,001-200,000","200,001-250,000","250,001-300,000","300,001-500,000","500,001 and over"  };
        static double[] eachValuationTypeTotal = new double[7] { 0, 0, 0, 0, 0, 0, 0, };
        static double[] eachValuationTypeAverage = new double[7] { 0, 0, 0, 0, 0, 0, 0, };
        static void Main(string[] args)
        {
            int propertyValueCount = 0; //student amount pool
            double totalTaxes = 0; //total marks pool
            double average = 0; //average
            int i = 0; //loop
            double propertyValue = 0; //mark
            bool isValid;


            while (i == 0) //just looping 
            {
                do //starts loop
                {
                    try
                    {
                        isValid = true;//this is true only if mark is returned as a valid input
                        propertyValue = GetPropertyValue(); //calls method//if mark is not between 0 and 100 or is a string or something it shows an error  and repeats the loop
                    }

                    catch (ArithmeticException error)
                    {
                        Console.WriteLine(error.Message);
                        isValid = false;
                    }

                    catch (FormatException error)
                    {
                        Console.WriteLine("\n{0}\n", error.Message);
                        isValid = false;
                    }

                    catch (Exception error)
                    {
                        Console.WriteLine("\n{0}\n", error.Message);
                        isValid = false;
                    }
                }
                while (isValid == false);//

                if (propertyValue != -999)//checks if -999
                {


                    propertyValue = DetermainRate(propertyValue);  //callsmethod to determain grade
                    Console.WriteLine("Property tax: {0}\n", propertyValue);
                    totalTaxes = propertyValue + totalTaxes;
                    propertyValueCount++;//if not student ++


                    //adds mark to total pool
                }
                else  //else breaks
                    break;
            }
            GetAverage(); //if breaks it calculates average
            OutputResults(average, totalTaxes, propertyValueCount);  //then outputs results

        }





        static double GetPropertyValue()//inputs mark
        {
            double propertyValue;
            Console.Write("Enter property value (-999 to end): ");
            propertyValue = double.Parse(Console.ReadLine());
            if (propertyValue == -999 || propertyValue > 0)
                return propertyValue;
            else
                throw new Exception("Number must be between over 0 and cant be negative"); //if this happens isValid is set to false which repeats the loop untill its not false


        }





        static double DetermainRate(double propertyValue)//determains what grade student gets
        {
            if (propertyValue <= 100000)
            {
                propertyValue = propertyValue * 0.18;
                valuationTypes[0] = valuationTypes[0] + 1;
                eachValuationTypeTotal[0] = eachValuationTypeTotal[0] + propertyValue;

            }

            else if (propertyValue > 100000 && propertyValue <= 150000)
            {
                propertyValue = propertyValue * 0.20;
                valuationTypes[1] = valuationTypes[1] + 1;
                eachValuationTypeTotal[1] = eachValuationTypeTotal[1] + propertyValue;
            }

            else if (propertyValue > 150000 && propertyValue <= 200000)
            {
                propertyValue = propertyValue * 0.21;
                valuationTypes[2] = valuationTypes[2] + 1;
                eachValuationTypeTotal[2] = eachValuationTypeTotal[2] + propertyValue;
            }

            else if (propertyValue > 200000 && propertyValue <= 250000)
            {
                propertyValue = propertyValue * 0.23;
                valuationTypes[3] = valuationTypes[3] + 1;
                eachValuationTypeTotal[3] = eachValuationTypeTotal[3] + propertyValue;
            }

            else if (propertyValue > 250000 && propertyValue <= 300000)
            {
                propertyValue = propertyValue * 0.30;
                valuationTypes[4] = valuationTypes[4] + 1;
                eachValuationTypeTotal[4] = eachValuationTypeTotal[4] + propertyValue;
            }

            else if (propertyValue > 300000 && propertyValue <= 50000)
            {
                propertyValue = propertyValue * 0.33;
                valuationTypes[5] = valuationTypes[5] + 1;
                eachValuationTypeTotal[5] = eachValuationTypeTotal[5] + propertyValue;
            }

            else
            {
                propertyValue = propertyValue * 0.50;
                valuationTypes[6] = valuationTypes[6] + 1;
                eachValuationTypeTotal[6] = eachValuationTypeTotal[6] + propertyValue;
            }

                return propertyValue;
        }


        static void GetAverage()//calculates average
        {

            for (int i = 0; i < 7; i++)
            {
                eachValuationTypeAverage[i] = eachValuationTypeTotal[i] / valuationTypes[i];

            }

        }


        static void OutputResults(double average, double totalTaxes, int propertyValueCount)//putputs result
        {
            Console.WriteLine("{0,0}{1,25}{2,30}{3,35}", "Valuation Band","Num of Properties", "Tax Payable", "Average Tax");



            for (int i = 0; i < 7; i++)
            {
                Console.WriteLine("{0,0}{1,25}{2,30}{3,35}", displayTextRates[i],valuationTypes[i],eachValuationTypeTotal[i],eachValuationTypeAverage[i]);
            }
            Console.WriteLine("\nTotal Taxes: {0,50}", totalTaxes);















































     

        }

    }
}

