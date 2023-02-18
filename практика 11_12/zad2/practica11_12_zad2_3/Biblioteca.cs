using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace practica11_12_zad2_3
{/*Описать класс «домашняя библиотека». Предусмотреть
возможность работы с произвольным числом книг, поиска книги по
какому-либо признаку(например, по автору или по году издания),
добавления книг в библиотеку, удаления книг из нее, сортировки книг по
разным полям.*/
    internal class Biblioteca
    {
        public string name;
        public string avtor;
        public string genre;
        public string search;
        public void books_add()  //добавление
        {
            StreamWriter txt = File.AppendText("books.txt");
            txt.Write($"\n{name}|{avtor}|{genre}");
            txt.Close();
        }

        public string[,] help_array(string text) //создает двухмерный масив из строки (этот метод нужен для создания массива книг)
        {
            string[] text_full = text.Split('?');
            string[,] books = new string[text_full.Length, 3];
            for (int i = 0; i < text_full.Length; i++)
            {
                string stroka = text_full[i];
                string[] one_book = stroka.Split('|');
                for (int j = 0; j < one_book.Length; j++)
                {
                    books[i, j] = one_book[j];
                }
            }

            return books;
        }
        public string[,] array_books() //создает двухмерный массив где содержаться все книги
        {
            string text = "";
            StreamReader txt = File.OpenText("books.txt");
            while (!txt.EndOfStream)
            {
                string cheak = txt.ReadLine();
                if(cheak.Length > 2)
                {
                    text += cheak + "?";
                }
            }

            string[,] books = help_array(text);
            txt.Close();
            return books;

        }


        public string[,] find() //находит нужную книгу
        {
            string text = "";
            string[,] books = array_books();
            for (int i = 0; i < books.GetLength(0); i++)
            {
                for (int j = 0; j < books.GetLength(1); j++)
                {
                    if (books[i, j] == search)
                    {
                        text += books[i, 0] + "|" + books[i, 1] + "|" + books[i, 2] + "?";
                    }
                }

            }
            string[,] find_books = help_array(text);
            return find_books;
        }

        public void dell_books()
        {
            int k = 0;
            string text_dell = $"{name}|{avtor}|{genre}";
            string[,] books = array_books();
            string[,] v2_books = new string[books.GetLength(0) - 1, books.GetLength(1)];

            //создание двухмерного массива книг без удаленного элемента
            for (int i = 0; i < books.GetLength(0); i++)
            {
                string text = books[i, 0] + "|" + books[i, 1] + "|" + books[i, 2];
                if (text != text_dell)
                {
                    v2_books[k, 0] = books[i, 0];
                    v2_books[k, 1] = books[i, 1];
                    v2_books[k, 2] = books[i, 2];
                    k += 1;
                }
            }

            //запись нового массива в файл
            StreamWriter txt = File.CreateText("books.txt");
            for (int i = 0; i < v2_books.GetLength(0); i++)
            {
                string text = "\n" + v2_books[i, 0] + "|" + v2_books[i, 1] + "|" + v2_books[i, 2];
                txt.Write(text);
            }
            txt.Close();
        }

        public void sort(int feature)
        {
            string[,] books = array_books();
            string[] one = new string[books.GetLength(0)]; //масив длиной количестра книг
            string[,] sort_books = new string[books.GetLength(0), books.GetLength(1)];
            for(int i = 0; i < one.Length; i++)
            {
                one[i] = books[i, feature];
            }

            Array.Sort(one);
            //Создание отсортированного массива
            for(int i = 0; i < one.Length; ++i)
            {
                string text = one[i];
                
                for(int j = 0; j < books.GetLength(0); j++)
                {
                    if(text == books[j, feature])
                    {
                        sort_books[i, 0] = books[j, 0] + "|";
                        sort_books[i, 1] = books[j, 1] + "|";
                        sort_books[i, 2] = books[j, 2];
                    }
                }
            }
            
            //запись нового массива в файл
            StreamWriter txt = File.CreateText("books.txt");
            for (int i = 0; i < sort_books.GetLength(0); i++)
            {
                string text = "\n" + sort_books[i, 0] + sort_books[i, 1]  + sort_books[i, 2];
                txt.Write(text);
            }
            txt.Close();

        }

    }
}

