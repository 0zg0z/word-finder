using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ödev3
{
    class Program
    {
        static void Main(string[] args)
        {
            //variables
            string input, choosenword;
            string[] words = null;
            string[] original = null;
            bool control = true;
            bool star = false, dash = false, flag;
            // receiving text from user
            Console.Write("Please input a text:");
            input = Console.ReadLine();
            // input vadiation
            do
            {
                for (int i = 0; i < input.Length; i++)
                {
                    if (!char.IsLetter(input[i]) && (input[i] != ' ') && (input[i] != '.') && (input[i] != ','))
                    {
                        control = false;
                        break;
                    }
                    else
                        control = true;
                }
                if (control == false)
                {
                    Console.Write("text must include only letters, comma and dot \nPlease enter a new text: ");
                    input = Console.ReadLine();
                }
            }
            while (!control);
            //erasing '.', ',' and ' '
            input = input.Replace(".", " ");
            input = input.Replace(",", " ");
            while (input.Contains("  "))
                input = input.Replace("  ", " ");
            //to show the words with original state  
            original = input.Split(' ');
            //convert the text to lowercase letters
            input = input.ToLower(new CultureInfo("en-US", false));
            words = input.Split(' ');
            // erasing repeating words
            for (int m = 0; m < words.Length; m++)
            {
                for (int n = 0; n < words.Length; n++)
                {
                    if (m != n && words[m] == words[n])
                    {
                        words[n] = "";
                        original[n] = "";
                    }
                }
            }
            // receiving word
            Console.Write("please write the world :");
            choosenword = Console.ReadLine();
            choosenword = choosenword.ToLower(new CultureInfo("en-US", false));
            // input validation
            do
            {
                //for the case when use input a character isnt a letter or '*' or '-'
                for (int i = 0; i < choosenword.Length; i++)
                {
                    if (!char.IsLetter(choosenword[i]) && (choosenword[i] != '*') && (choosenword[i] != '-'))
                    {
                        control = false;
                        break;
                    }
                    else
                        control = true;
                }
                if (control == false)
                {
                    Console.Write("word must include only letters, star and - \nPlease enter a new word: ");
                    choosenword = Console.ReadLine();
                }
                else
                {
                    // control for '*' and '-'
                    for (int i = 0; i < choosenword.Length; i++)
                    {
                        if (choosenword[i] == '*') star = true;
                        else if (choosenword[i] == '-') dash = true;
                    }
                    if (star == dash)
                    {
                        control = false;
                        Console.Write("word must include star or -, but not both \nPlease enter a new word: ");
                        choosenword = Console.ReadLine();
                        star = false;
                        dash = false;
                    }
                    else control = true;
                }
            }
            while (!control);

            // checking matching words
            int counter = 0;
            if (star == true)
            {
                //for star

                string[] str = choosenword.Split('*'); //spliting the string to string bits
                bool[] flAg = new bool[str.Length];

                for (int j = 0; j < words.Length; j++)
                {
                    // reseting the variables
                    int length = 0;
                    int indexint = 0;
                    flag = true;
                    for (int f = 0; f < str.Length; f++)
                        flAg[f] = true;
                    //checking the word for matchabilty to string bits
                    for (int i = 0; i < str.Length; i++)
                    {
                        if (str[i] != "")
                        {
                            if (words[j].IndexOf(str[i]) == -1)
                            {
                                flAg[i] = false;
                            }
                            for (int m = 0; m < i; m++)
                            {
                                length += str[m].Length;
                            }
                            if (words[j].IndexOf(str[i]) < indexint + length)
                            {
                                flAg[i] = false;
                            }
                            indexint = words[j].IndexOf(str[i]);
                            if (i == 0 && indexint != 0)
                            {
                                flAg[i] = false;
                            }
                            else if (i == str.Length - 1 && indexint != words[j].Length - str[i].Length)
                            {
                                flAg[i] = false;
                            }

                        }

                    }
                    //controling flags
                    for (int f = 0; f < str.Length; f++)
                        if (flAg[f] == false)
                            flag = false;
                    //writing the word if word is meet the conditions
                    if (flag == true)
                    {
                        Console.WriteLine(original[j]);
                    }


                }



            }
            else
            {
                //for dash
                for (int m = 0; m < words.Length; m++)
                {
                    flag = false;
                    if (words[m].Length == choosenword.Length)
                    {

                        if (counter != choosenword.Length)
                        {
                            counter = 0;
                            for (int i = 0; i < choosenword.Length; i++)
                            {
                                if (choosenword[i] != '-')
                                {
                                    if (words[m][i] == choosenword[i]) flag = true;
                                    else flag = false;
                                }
                                else counter += 1;
                            }
                        }
                        //writing the word if word is meet the conditions
                        if (flag == true)
                        {
                            Console.WriteLine(original[m]);
                        }
                        else if (counter == choosenword.Length)
                            Console.WriteLine(original[m]);
                    }
                }

            }

            Console.ReadLine();
        }

    }
}