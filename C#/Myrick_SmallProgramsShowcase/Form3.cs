using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Myrick_SmallProgramsShowcase
{
    public partial class Form3 : Form
    {
        private List<string> words;
        public Form3()
        {
            InitializeComponent();
        }
        //browse text files 
        private void button1_Click(object sender, EventArgs e)
        {
            var openFileDialog = new OpenFileDialog();
            openFileDialog.Filter = "Text files|*.txt";

            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                string filePath = openFileDialog.FileName;
                textBox1.Text = filePath;
                ReadWordsFromFile(filePath);
            }
        }
        //reading words from file input
        private void ReadWordsFromFile(string filePath)
        {
            try
            {
                words = File.ReadAllLines(filePath).ToList();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error reading file: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        //call generate method
        private void button2_Click(object sender, EventArgs e)
        {
            GeneratePasswords();
        }
        //generate passwords
        private void GeneratePasswords()
        {
            if (int.TryParse(textBox2.Text, out int numPasswords))
            {
                if (words != null && words.Count > 0)
                {
                    //clear box when button is hit again
                    listBox1.Items.Clear();

                    Random random = new Random();

                    for (int i = 0; i < numPasswords; i++)
                    {
                        string password = GenerateRandomPassword(words,random);
                        listBox1.Items.Add(password);
                    }
                }
                else
                {
                    MessageBox.Show("No words available. Please select a word file.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            else
            {
                MessageBox.Show("The number of passwords must be an integer.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        //random password generator method
        private string GenerateRandomPassword(List<string> words, Random random)
        {
            string[] word1 = words[random.Next(words.Count)].Split(' ');
            string[] word2 = words[random.Next(words.Count)].Split(' ');
            string[] word3 = words[random.Next(words.Count)].Split(' ');

            string password = $"{word1[0]}{word2[0].ToUpper()}{word3[0]}";
            //replace s characters with $ characters
            password = password.Replace('s', '$');
            //replace i characters with ! characters
            password = password.Replace('i', '!');
            //return passwords
            return password;
        }

        //close button
        private void button3_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}