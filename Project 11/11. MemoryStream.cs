﻿// Демонстрация использования класса MemoryStream.
using System;
using System.IO;
using System.Threading;

class MemStrDemo
{
    public static void Main()
    {
        try
        {
            byte[] storage = new byte[255];
            // Создаем поток с ориентацией на память.
            MemoryStream memstrm = new MemoryStream(storage);
            // Помещаем объект memstrm в оболочки StreamWriter  и StreamReader.
            StreamWriter memwtr = new StreamWriter(memstrm);
            StreamReader memrdr = new StreamReader(memstrm);
            // Записываем данные в память с помощью
            // объекта memwtr.
            for (int i = 0; i < 10; i++)
                memwtr.WriteLine("byte [" + i + "] : " + i);
            // Ставим в конце точку,
            memwtr.Write('.');
            memwtr.Flush();
            Console.WriteLine("Считываем данные прямо из массива storage: ");
            // Отображаем напрямую содержимое памяти.
            foreach (char ch in storage)
            {
                if (ch == '.') break;
                Console.Write(ch);
                Thread.Sleep(100);
            }
            Console.WriteLine("\nСчитываем данные посредством объекта memrdr: ");
            // Считываем данные из объекта memstrm, используя  средство чтения потоков.
            memstrm.Seek(0, SeekOrigin.Begin); // Установка  указателя позиции в начало потока.
            string str;
            while ((str = memrdr.ReadLine()) != null)
            {
                if (str.CompareTo(".") == 0) break;
                Console.WriteLine(str);
                Thread.Sleep(100);
            }
        }
        catch (Exception ex)
        {
            Console.WriteLine(ex.Message);
        }
    }
}
