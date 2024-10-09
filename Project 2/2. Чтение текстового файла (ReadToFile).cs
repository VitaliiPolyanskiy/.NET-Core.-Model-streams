using System;
using System.IO;
using System.Text;

class Test
{
    public static void Main()
    {
        try
        {
            Console.WriteLine("Введите путь к файлу: ");
            string filename = Console.ReadLine();
            StreamReader sr = new StreamReader(filename, Encoding.Default);
            string line = sr.ReadToEnd();
            sr.Close();
            StreamWriter sw = new StreamWriter("User.log", true, Encoding.Default);
            sw.WriteLine(line);
            sw.Close();
        }
        catch (Exception e)
        {
            Console.WriteLine(e.Message); 
        }
    }
}