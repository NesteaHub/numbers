using System.Text;
using System.Threading.Tasks;

using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System;
using System.Linq;

using System.Windows.Forms;

namespace WindowsFormsApp1
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            textBox2.Text = "";
            textBox3.Text = "";
            string text = textBox1.Text;
            string[] slovar1 = { "one", "two", "three", "four", "five", "six", "seven", "eight", "nine" };
            string[] slovar2 = { "ten", "eleven", "twelve", "thirteen", "fourteen", "fifteen", "sixteen", "seventeen", "eighteen", "nineteen" };
            string[] slovar3 = {"twenty", "thirty", "forty", "fifty", "sixty", "seventy", "eighty", "ninety"};
            string slovar4 = "hundred";

            string [] words;
            char[] splittext = { ' ' };
            words = text.Split(splittext, StringSplitOptions.RemoveEmptyEntries);
            words = words.ToArray();

            int i = words.Length-1;
            int output = 0;

            if (words.Length < 1) 
                MessageBox.Show("Ошибка: введите число");

            

            while (i >= 0)
            {
                for (int j = 0; j < words.Length; j++)
                {
                    if ((!slovar1.Contains(words[j])) && (!slovar2.Contains(words[j])) && (!slovar3.Contains(words[j])) 
                        && (slovar4 != words[j]))
                    {
                        MessageBox.Show("Ошибка в слове " + words[j]);
                        i = -1;
                        output = 0;
                        break;
                    }
                }           ////проверка на ввод не слов
                  
                if (i < 0) break;

                for (int j1 = 0; j1 < slovar1.Length; j1++)
                {
                    if ((words[i] == slovar1[j1]) && (i - 1 >= 0))
                    {
                        if (slovar2.Contains(words[i - 1]))
                        {
                            MessageBox.Show("Ошибка: числа разной разрядности (" + words[i - 1] + " не может располагаться перед " + words[i] + ")");
                            i = -1;
                            output = 0;
                            break;
                        }
                        else if (slovar1.Contains(words[i - 1]))
                        {
                            MessageBox.Show("Ошибка: числа одинаковой разрядности (" + words[i - 1] + " не может располагаться перед " + words[i] + ")");
                            i = -1;
                            output = 0;
                            break;
                        }
                        output += j1 + 1;
                        i--;
                        break;
                    }
                    else if ((words[0] == slovar1[j1]) && (words.Length == 1))
                    {
                        output += j1 + 1;
                        i--;
                        break;
                    }
                }         ////словарь1

                if (i < 0) break;

                for (int k = 0; k < slovar2.Length; k++)
                {
                    if ((words[i] == slovar2[k]) && (i - 1 >= 0))
                    {
                        if (slovar1.Contains(words[i - 1]))
                        {
                            MessageBox.Show("Ошибка: числа разной разрядности (" + words[i - 1] + " не может располагаться перед " + words[i] + ")");
                            i = -1;
                            output = 0;
                            break;
                        }
                        if (slovar2.Contains(words[i - 1]))
                        {
                            MessageBox.Show("Ошибка: числа одинаковой разрядности (" + words[i - 1] + " не может располагаться перед " + words[i] + ")");
                            i = -1;
                            output = 0;
                            break;
                        }
                        if (slovar3.Contains(words[i - 1]))
                        {
                            MessageBox.Show("Ошибка: числа разной разрядности (" + words[i - 1] + " не может располагаться перед " + words[i] + ")");
                            i = -1;
                            output = 0;
                            break;
                        }
                        output += k + 10;
                        i--;
                        break;
                    }                   
                    else if ((words[0] == slovar2[k]) && (words.Length == 1))
                    {
                        output += k + 10;
                        i--;
                        break;
                    }
                }           ////словарь2

                if (i < 0) break;

                for (int j2 = 0; j2 < slovar3.Length; j2++)
                {
                    if ((words[i] == slovar3[j2]) && (i - 1 >= 0))
                    {
                        if (slovar3.Contains(words[i - 1]))
                        {
                            MessageBox.Show("Ошибка: числа одинаковой разрядности (" + words[i - 1] + " не может располагаться перед " + words[i] + ")");
                            i = -1;
                            output = 0;
                            break;
                        }
                        else if (slovar2.Contains(words[i - 1]))
                        {
                            MessageBox.Show("Ошибка: числа разной разрядности (" + words[i - 1] + " не может располагаться перед " + words[i] + ")");
                            i = -1;
                            output = 0;
                            break;
                        }
                        else if (slovar1.Contains(words[i - 1]))
                        {
                            MessageBox.Show("Ошибка: числа разной разрядности (" + words[i - 1] + " не может располагаться перед " + words[i] + ")");
                            i = -1;
                            output = 0;
                            break;
                        }
                        output += (j2 + 2) * 10;
                        i--;
                        break;
                    }
                    else if (words[0] == slovar3[j2]) 
                    {
                        output += (j2 + 2) * 10;
                        i--;
                        break;
                    }                   
                }           ////словарь3

                if (i < 0) break;
                if (words[0] == slovar4)
                {
                    MessageBox.Show("Ошибка: укажите число сотен");
                    i = -1;
                    output = 0;
                    break;
                }
                if (i < 0) break;
                
                if (words.Length >= 2)
                {
                    for (int l = 0; l < slovar1.Length; l++)
                    {
                        if ((words[1] == slovar4)&&((slovar2.Contains(words[0]))||(slovar3.Contains(words[0]))))
                        {
                            MessageBox.Show("Ошибка: число сотен не должно превышать девяти");
                            i = -1;
                            output = 0;
                            break;
                        }
                        if (i < 0) break;

                        else if ((words[1] == slovar4) && (words[0] == slovar1[l]))
                        {
                            output += (l + 1) * 100;
                            i--; i--;
                            break;
                        }    
                        else if(words[1] != slovar4)
                        {
                            MessageBox.Show("Ошибка: перед сотней должно располагаться одно число от 1 до 9");
                            i = -1;
                            output = 0;
                            break;
                        }
                    }           ////сотни 
                }
                if (i < 0) break;

            }
            int count = 0;
            for (int z = 0; z < words.Length; z++)
            {
                if (words[z] == "hundred")
                {
                    count++;
                }
            }
            if (count > 1)
            {
                MessageBox.Show("Ошибка: слово 'hundred' не может повторяться");
                i = -1;
                output = 0;
            }
            if (output > 0)
                textBox2.Text = output.ToString();

            string[] rim = { "CM", "D", "CD", "C", "XC", "L", "XL", "X", "IX", "V", "IV", "I" };
            int[] arab = { 900, 500, 400, 100, 90, 50, 40, 10, 9, 5, 4, 1 };
            int c = 0;
            string output2 = "";

            while (output > 0)
            {
                if (arab[c] <= output)
                {
                    output -= arab[c];
                    output2 += rim[c];
                }
                else c++;
            }
            textBox3.Text = output2;
        }
    }
}
