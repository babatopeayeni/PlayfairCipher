//Name: Babatope Ayeni
//Date: 11/07/2021
//Unit H: C# Lab 5 – Modified Playfair Cipher


using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ModifiedPlayfairCipher
{
    public partial class Form1 : Form
    {

        // Rows and column table
        const int row = 5;
        const int col = 5;
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            
        }

        private void button1_Click(object sender, EventArgs e)
        {

        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnClear_Click(object sender, EventArgs e)
        {
            //this clears text box
            txtInput.Text  = "";
            txtOutput.Text = "";
            txtSecret.Text = "";
        }

        private void btnTranslateText_Click(object sender, EventArgs e)
        {

            char[,] table = new char[row, col];
            string secretWord, inputWord, outputWord;
            outputWord = " ";
            secretWord = txtSecret.Text;
            table = populateTable(secretWord);
            inputWord = txtInput.Text;
            outputWord = txtOutput.Text;
            if (inputWord != "" && outputWord == "")
                txtOutput.Text = cipherText(table, inputWord);
            else
            {
                MessageBox.Show("Fill in the Secret Word and the Text to translate");
            }

            return;
        }



        private void txtInputText_TextChanged(object sender, EventArgs e)
        {

        }

        private void txtOutPutText_TextChanged(object sender, EventArgs e)
        {

        }

        public string cipherText(char[,] myArray, string plaintext)
        {
            string cText = "";
            int r = new int();
            int c = new int();
            for (int i = 0; i < plaintext.Length; i++)
            {
                if (Char.IsLetter(plaintext[i]))
                {
                    findLocation(myArray, Char.ToUpper(plaintext[i]), ref r, ref

                    c);

                    cText += myArray[c, r];
                }
                else

                    cText += plaintext[i];
            }
            return cText;
        }
        public void findLocation(char[,] table, char ch, ref int r, ref int c)
        {
            if (ch == 'J')
                ch = 'I';
            for (int i = 0; i < row; i++)
                for (int j = 0; j < col; j++)
                {
                    if (table[i, j] == ch)
                    {
                        r = i;
                        c = j;
                        break;
                    }
                }
        }
        public char[,] populateTable(string word)
        {
            char[,] table = new char[row, col];
            string alphabet = "ABCDEFGHIKLMNOPQRSTUVWXYZ";
            string textWithoutDubplicate;
            int i;
            int j;
            int k;
            int l;
            int m;
            i = j = k = l = m = 0;
            textWithoutDubplicate = RemoveDuplicateChars(word);
            textWithoutDubplicate = textWithoutDubplicate.ToUpper();
            for (i = 0; i < textWithoutDubplicate.Length; i++)
            {
                char c = textWithoutDubplicate[i];
                if (c == 'J')
                    c = 'I';
                if (k == 5)
                {
                    k = 0;
                    j += 1;
                }
                table[j, k] = c;
                k += 1;
            }
            l = k;
            for (m = 0; m < alphabet.Length; m++)
            {
                if (l == 5)
                {
                    l = 0;
                    j = j + 1;
                }

                if (findCharInTable(table, alphabet[m]) == false)
                {
                    table[j, l] = alphabet[m];
                    l += 1;
                }
            }
            return table;

        }
        public Boolean findCharInTable(Char[,] myArray, char c)
        {
            for (int i = 0; i < row; i++)
            {
                for (int j = 0; j < col; j++)
                {
                    if (myArray[i, j] == c)
                        return true;
                }
            }
            return false;
        }
        public string RemoveDuplicateChars(string s)
        {
            string newString = string.Empty;
            List<char> found = new List<char>();
            foreach (char c in s)
            {
                if (found.Contains(c))
                    continue;
                newString += c.ToString();
                found.Add(c);

            }
  
return newString;
    }
}
}