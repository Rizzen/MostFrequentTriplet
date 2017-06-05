using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

public static string MostFrequentTriplet(string str, CancellationToken ct)
        {
            string triplet = "";
            int tripletCount = 0;

            var tripletDictionary = new Dictionary<string, int>();
            var words = str.Split(',');

            //убрать пробелы в начале и конце если есть
            var trimmedWords = words.Select(w => w.Trim())
                                    .Where(w => w.Length >= 3).ToArray();
            var totalWords = trimmedWords.Length;

            if (totalWords < 1)
            {
                return "Wrong String";
            }
            
            try
            {
                Parallel.For(0, totalWords, new ParallelOptions { CancellationToken = ct }, i =>
                {
                    Console.WriteLine($"Started Thread {Thread.CurrentThread.ManagedThreadId}");
                    Thread.Sleep(5000);
                    string currWord = trimmedWords[i];
                    int wordLength = currWord.Length;
                    //проход по каждому слову
                    for (int j = 0; j <= wordLength - 3; j++)
                    {

                        string currTriplet = currWord.Substring(j, 3);
                        if (!tripletDictionary.ContainsKey(currTriplet))
                        {
                            tripletDictionary.Add(currTriplet, 1);
                        }
                        else
                        {
                            tripletDictionary[currTriplet]++;
                        }
                    }
                });
            }
            catch (OperationCanceledException ex)
            {
                return "Cancelled by Token ";
            }
                
            //выбираем максимальное значение
            var trips = tripletDictionary.Where(t => tripletDictionary[t.Key] == tripletDictionary.Values.Max()).ToArray()
                                         .Select(t => t.Key).ToArray();
            tripletCount = tripletDictionary.Max(t => t.Value);

            triplet = String.Join(",", trips);
                       
            return String.Format($"{triplet}\t{tripletCount}");
        }
