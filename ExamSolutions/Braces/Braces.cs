namespace Braces
{
    using System;
    using System.Collections.Generic;

    public class Braces
    {
        public static void Main(string[] args)
        {
            int numberOfInputLines = int.Parse(Console.ReadLine());
            string[] inputs = new string[numberOfInputLines];
            string[] answers = new string[numberOfInputLines];

            for (int i = 0; i < numberOfInputLines; i++)
            {
                inputs[i] = Console.ReadLine();
            }

            for (int k = 0; k < inputs.Length; k++)
            {
                string input = inputs[k];

                if (input is null || input.Length % 2 != 0)
                {
                    answers[k] = "NO";
                }
                else
                {
                    bool notBalanced = false;
                    Stack<char> stack = new Stack<char>();

                    for (int j = 0; j < input.Length; j++)
                    {
                        if (input[j] == '(' || input[j] == '{' || input[j] == '[')
                        {
                            stack.Push(input[j]);
                        }
                        else
                        {
                            if (stack.Count > 0)
                            {
                                var currElem = stack.Pop();
                                if (currElem == '(' && input[j] != ')')
                                {
                                    notBalanced = true;
                                    break;
                                }
                                if (currElem == '{' && input[j] != '}')
                                {
                                    notBalanced = true;
                                    break;
                                }
                                if (currElem == '[' && input[j] != ']')
                                {
                                    notBalanced = true;
                                    break;
                                }
                            }
                            else
                            {
                                notBalanced = true;
                                break;
                            }
                        }
                    }

                    if (notBalanced)
                    {
                        answers[k] = "NO";
                    }
                    else
                    {
                        answers[k] = "YES";
                    }
                }
            }

            for (int l = 0; l < answers.Length; l++)
            {
                Console.WriteLine(answers[l]);
            }
        }
    }
}
