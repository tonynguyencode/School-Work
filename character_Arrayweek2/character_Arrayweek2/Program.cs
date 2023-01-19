using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections;
using Character_Frequency;
using System.IO;
using System.Xml.Linq;

namespace character_Arrayweek2
{
    internal class Program
    {
        public static CharacterFrequency character_Frequency;
        public static ArrayList arrayVector = new ArrayList();
        private static bool Check_valid(char value)
        {
            int value_byte = (int)value;
            if (value >= 33)
            {
                return true;
            }
            return false;
        }
        static void Main(string[] args)
        {
            Console.WriteLine($"Enter your input full path: ");  //Getting the appropriate path
            string read_file = Console.ReadLine();
            string fileName = $@"{read_file}";

            //Using BinaryWriter to write the output txt
            //Getting the path or create a path
            Console.WriteLine("Enter your output file path: ");
            string output_file = Console.ReadLine();
            string file_output_Name = $@"{output_file}";

            //Got the path.
            //Using BinaryReader to read the input txt

            try
            {
                if (File.Exists(fileName))
                {
                    FileInfo file_info = new FileInfo(fileName);
                    //Using the array only to store the ASCII object
                    long size = 0;
                    arrayVector = new ArrayList((int)file_info.Length);
                    int array_position = 0;
                    //This is where calculation will be make.
                    using (var stream = File.Open(fileName, FileMode.Open)) //Open the file and stream
                    {
                        using (var reader = new BinaryReader(stream, Encoding.UTF8, false))      //Using BinaryReader method
                        {
                            while (size < file_info.Length)
                            {
                                char c = (char)reader.Read();
                                
                                size++;
                            }
                        }
                    }
                }
                else
                {
                    Console.WriteLine("Invalid File!");
                }
            } catch (Exception eex) { Console.WriteLine(eex.Message); }

        }
    }
}
