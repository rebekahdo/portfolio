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
    public partial class Form4 : Form
    {
        public Form4()
        {
            InitializeComponent();
        }
        //call the count words method!
        private void button1_Click(object sender, EventArgs e)
        {
            CountWords();
        }
        //count the words
        private void CountWords()
        {
            //add words to array
            string story = richTextBox1.Text;
            string[] words = story.ToLower().Split(new[] { ' ', '\n', '\r', '\t', '.', ',', ';', ':', '!', '?' }, StringSplitOptions.RemoveEmptyEntries);

            Dictionary<string, int> wordCounts = new Dictionary<string, int>();

            foreach (string word in words)
            {
                if (wordCounts.ContainsKey(word))
                {
                    wordCounts[word]++;
                }
                else
                {
                    wordCounts[word] = 1;
                }
            }

            var sortedWordCounts = wordCounts.OrderByDescending(x => x.Value);

            listBox1.Items.Clear();

            foreach (var pair in sortedWordCounts)
            {
                listBox1.Items.Add($"{pair.Key,-15}{pair.Value}");
            }
        }
        //close
        private void button2_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}
