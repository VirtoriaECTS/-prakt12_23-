using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace practica11_12_zad2_3
{
    public partial class Form1 : Form
    {
        Biblioteca bk = new Biblioteca();
        public string cheak() //прокерка на ввод пустых полей
        {
            string text1 = textBox1.Text;
            string text2 = textBox2.Text;
            string text3 = textBox3.Text;
            string text = "";
            if ((text1 == "") || (text2 == "") || (text3 == ""))
            {
                text = "Необходимо заполнить все поля";
            }
            else text = "";
            return text;
        }

        public void fun_vis() //что бы было видно доп поля для довабление и удаления книги
        {

            label2.Visible = true;
            label3.Visible = true;
            label4.Visible = true;
            label5.Visible = true;
            textBox1.Visible = true;
            textBox2.Visible = true;
            textBox3.Visible = true;
            button5.Visible = true;
            button6.Visible = true;

            button1.Visible = false;
            button2.Visible = false;
            button3.Visible = false;
            button4.Visible = false;
        }

        public void fun_not_vis() //что бы НЕ БЫЛО видно доп полей
        {
            label1.Visible = false;
            label2.Visible = false;
            label3.Visible = false;
            label4.Visible = false;
            label5.Visible = false;
            label6.Visible = false;
            textBox1.Visible = false;
            textBox2.Visible = false;
            textBox3.Visible = false;
            textBox4.Visible = false;
            button5.Visible = false;
            button6.Visible = false;
            button7.Visible = false;
            button8.Visible = false;
            button9.Visible = false;
            button10.Visible = false;
            button11.Visible = false;
            button12.Visible = false;

            button1.Visible = true;
            button2.Visible = true;
            button3.Visible = true;
            button4.Visible = true;
        }

        public void print()
        {
            listBox1.Items.Clear();
            string[,] books = bk.array_books();
            for (int i = 0; i < books.GetLength(0); i++)
            {
                string text = books[i, 0] + " " + books[i, 1] + " " + books[i, 2];
                listBox1.Items.Add(text);
            }
        }
        public void clear()
        {
            textBox1.Text = "";
            textBox2.Text = "";
            textBox3.Text = "";
            textBox4.Text = "";
        }

        public Form1()
        {
            InitializeComponent();
            fun_not_vis();
            print();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e) //добавить книгу
        {


            fun_vis();
            button5.Text = "Добавить книгу";
        }

        private void button6_Click(object sender, EventArgs e) //Кнопка назад
        {

            label5.Text = "";
            clear();
            fun_not_vis();

        }

        private void button5_Click(object sender, EventArgs e) //кнопка с несколькик функциями

        {
            string ch = cheak();
            if (ch != "")
            {
                label5.Text = ch;
            }
            else
            {
                bk.name = textBox1.Text;
                bk.avtor = textBox2.Text;
                bk.genre = textBox3.Text;
                if (button5.Text == "Добавить книгу")
                {
                    bk.books_add();

                }
                if (button5.Text == "Удалить книгу")
                {
                    bk.dell_books();
                }
                fun_not_vis(); //скрываем кнопки
                clear(); //очищаем поле
                print(); //показываем результат
            }

        }

        private void button3_Click(object sender, EventArgs e) //Поиск книги
        {
            
            fun_not_vis();
            button1.Visible = false;
            button2.Visible = false;
            button3.Visible = false;
            button4.Visible = false;
            label1.Visible = true;
            label5.Visible = true;
            textBox4.Visible = true;
            button7.Visible = true;
            button8.Visible = true;
        }

        private void button7_Click(object sender, EventArgs e) //еще одна кнопка назад
        {


            panel4.Visible = true;
            clear();
            fun_not_vis();
            print();
            label5.Text = "";
        }

        private void button8_Click(object sender, EventArgs e) //поиск книги
        {
            listBox1.Items.Clear();
            bk.search = textBox4.Text;
            if (textBox4.Text.Length == 0) label5.Text = "Необходимо ввести признак, по которому вы ищете книгу";
            else
            {
                string[,] books = bk.find();
                if (books[0, 0] == "") label5.Text = "Ничего не найдено";
                else
                {
                    for (int i = 0; i < books.GetLength(0); i++)
                    {
                        string text_find = books[i, 0] + " " + books[i, 1] + " " + books[i, 2];
                        listBox1.Items.Add(text_find);
                    }
                }
            }
        }

        private void button2_Click(object sender, EventArgs e) //удаление книги
        {

            fun_vis();
            button5.Text = "Удалить книгу";
        }

        private void button4_Click(object sender, EventArgs e) //сотрировка книги
        {



            button1.Visible = false;
            button2.Visible = false;
            button3.Visible = false;
            button4.Visible = false;
            label6.Visible = true;
            button9.Visible = true;
            button10.Visible = true;
            button11.Visible = true;
            button12.Visible = true;
        }

        private void button9_Click(object sender, EventArgs e) //уже третья кнопка назад
        {


            label5.Text = "";
            clear();
            fun_not_vis();
            print();
        }

        private void button10_Click(object sender, EventArgs e)
        {
            bk.sort(0);
            print();
        }

        private void button11_Click(object sender, EventArgs e)
        {
            bk.sort(1);
            print();
        }

        private void button12_Click(object sender, EventArgs e)
        {
            bk.sort(2);
            print();
        }
    }
}
