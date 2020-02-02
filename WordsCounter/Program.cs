using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace WordsCounter
{
    
    class Program
    {
        static void Main()
        {
            Task task = new Task(CallMethod);
            task.Start();
            task.Wait();
            Console.ReadLine();
        }

        static async void CallMethod()
        {
            string filePath = " C:\\Users\\Dator\\Desktop\\LabAsignemnt4\\WordsCounter\\test.txt"; // Put the right file path
            Task<int> task = ReadFile(filePath);

        
           
            int length = await task;
            Console.WriteLine(" The total number of words in the text file: " + length);

          
        }

        static async Task<int> ReadFile(string file)
        {
            int length = 0;

            Console.WriteLine("File reading is starting...");
            Thread.Sleep(2000);
            using (StreamReader reader = new StreamReader(file))
            {
                // Here, it reads all characters from the current position to the end of the stream asynchronously    
                // and returns them as one string.    
                string s = await reader.ReadToEndAsync();

                length = s.Length;
            }
            Console.WriteLine(" File reading is completed:");
            return length;
        }




    }
}
