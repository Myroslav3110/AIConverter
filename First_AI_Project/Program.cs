using System;
using First_AI_Project.Neurons;

namespace First_AI_Project
{
    class Program
    {
        static void Main()
        {
            //var input1 = 100;
            //var input2 = 62.1371m;
            while(true)
            {
                Console.WriteLine("Insert first input to learn:");
                var b1 = decimal.TryParse(Console.ReadLine(), out var input1Result);
                Console.WriteLine("Insert second input to learn:");
                var b2 = decimal.TryParse(Console.ReadLine(), out var input2Result);
                if(b1 && b2)
                {
                    var input1 = input1Result;
                    var input2 = input2Result;
                    var neuron = new NeuronConverter();
                    var i = 0;
                    do
                    {
                        i++;
                        neuron.Train(input1, input2);
                        if (i % 500000 == 0)
                        {
                            Console.WriteLine($"Iteration:{i} \tError:\t{neuron.LastError}");
                        }
                        
                    } while(neuron.LastError > neuron.Smoothing || neuron.LastError < -neuron.Smoothing);

                    Console.WriteLine("Train complete!");
                    Console.WriteLine("Example:");
                    Console.WriteLine($"Conversion from: 100 is: {neuron.ProcessInputData(100)}");
                    Console.WriteLine($"Inversion from: 100 is:{neuron.RestoreInputData(100)}");
                    Console.WriteLine("\n\n************************************************\n\n");
                    Console.WriteLine("1 - New neuron");
                    Console.WriteLine("2 - Use neuron");
                    Console.WriteLine("3 - Exit");
                    var choice = Console.ReadLine();
                    if(choice != "1" && choice != "2" && choice != "3")
                    {
                        Console.WriteLine("Wrong choice");
                        continue;
                    }
                    switch (choice)
                    {
                        case "1":
                            continue;
                        case "2":
                        {
                            Console.WriteLine("1 - Convert");
                            Console.WriteLine("2 - Invert");
                            var subChoice = Console.ReadLine();
                            Console.WriteLine("\n\n************************************************\n\n");
                            while (true)
                            {
                                Console.WriteLine(subChoice == "1"
                                    ? "Insert input to convert:"
                                    : "Insert input to invert:");

                                var tmp = decimal.TryParse(Console.ReadLine(), out var result);
                                if (tmp)
                                {
                                    if (subChoice == "1")
                                    {
                                        Console.WriteLine($"Conversion from: {result} is: {neuron.ProcessInputData(result)}");
                                        Console.WriteLine("\n\n************************************************\n\n");
                                        Console.WriteLine("1 - Countinue");
                                        Console.WriteLine("2 - New neuron");
                                        Console.WriteLine("3 - Exit");
                                        var subChoice2 = Console.ReadLine();
                                        if(subChoice2 == "1")
                                        {
                                            continue;
                                        }
                                        if(subChoice2 == "2")
                                        {
                                            break;
                                        }
                                        if(subChoice2 == "3")
                                        {
                                            return;
                                        }
                                        if(subChoice2 != "1" && subChoice2 != "2" && subChoice2 != "3")
                                        {
                                            Console.WriteLine("Wrong input");
                                            continue;
                                        }
                                    }
                                    if (subChoice == "2")
                                    {
                                        Console.WriteLine("\n\n************************************************\n\n");
                                        Console.WriteLine($"Inversion from: {result} is:{neuron.RestoreInputData(result)}");
                                        Console.WriteLine("\n\n************************************************\n\n");
                                        Console.WriteLine("1 - Countinue");
                                        Console.WriteLine("2 - New neuron");
                                        Console.WriteLine("3 - Exit");
                                        var subChoice2 = Console.ReadLine();
                                        if (subChoice2 == "1")
                                        {
                                            continue;
                                        }
                                        if (subChoice2 == "2")
                                        {
                                            break;
                                        }

                                        if (subChoice2 == "3")
                                        {
                                            return;
                                        }
                                        if (subChoice2 != "1" && subChoice2 != "2" && subChoice2 != "3")
                                        {
                                            Console.WriteLine("Wrong input");
                                            continue;
                                        }
                                    }
                                    if (subChoice != "1" && subChoice != "2")
                                    {
                                        break;
                                    }
                                }
                                else
                                {
                                    Console.WriteLine("Wrong input");
                                    break;
                                }
                                Console.WriteLine("\n\n************************************************\n\n");
                            }

                            break;
                        }
                    }
                    if (choice == "3")
                    {
                        break;
                    }
                }
                else
                {
                    Console.WriteLine("Wrong input");

                }
            }
        }
    }
}
