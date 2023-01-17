using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ASCIIobject;
//Requires a reference to the ASCIIobject
using System.Diagnostics;
using System.Security.Cryptography;
using System.Runtime.CompilerServices;

namespace characterCounter_Array
{
    internal class Program
    {

        public static Process proc1 = new Process();

        
        public static ASObject add_object;
        public static ASObject[] character_Objects;

        private static bool Check_valid(char value)
        {
            int value_byte = (int)value;
            if (value >= 33)
            {
                return true;
            }
            return false;
        }
        private static bool check_File_valid(string file_name)
        {
            if (File.Exists(file_name))
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
                    //Using the array only to store the ASCII object.
                    character_Objects = new ASObject[file_info.Length];
                    long size = 0;
                    int array_position = 0;
                    //This is where calculation will be make.
                    using (var stream = File.Open(fileName, FileMode.Open)) //Open the file and stream
                    {
                        using (var reader = new BinaryReader(stream, Encoding.UTF8, false))      //Using BinaryReader method
                        {
                            while(size < file_info.Length)
                            {
                                char c = (char)reader.Read(); 
                                if (Check_valid(c))   //Check if the value is within the approriate letter.
                                {
                                    char byte_char = c;
                                    ASObject add_object = new ASObject(byte_char); //Create the object for comparasion
                                    var index = Array.IndexOf(character_Objects, add_object);
                                    if (index != -1)  //Get the index of Object
                                    {
                                        character_Objects[index].Increment();  //Increment up one frequency if it already exist
                                    }
                                    else
                                    {
                                        character_Objects[array_position] = add_object; //Else add the object to the Array
                                        array_position++;
                                    }
                                }
                                size++;
                            }
                        }
                    }   
                } else
                {
                    Console.WriteLine("Invalid File!");
                }


                //Use StreamWriter to format and write it the output
                try
                {
                    using (var stream = File.Open(file_output_Name, FileMode.OpenOrCreate))
                    {
                        using (var writer = new StreamWriter(stream))
                        {
                            for (int x = 0; x < character_Objects.Length; x++)
                            {
                                if (character_Objects[x] == null)
                                {
                                    break;
                                }
                                else
                                {
                                    writer.WriteLine(character_Objects[x].ToString());
                                }
                            }
                        }
                    }
                    Console.WriteLine("Data succesfully writing to the file!");
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                }



            } catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }

            
        
        }



    }
}