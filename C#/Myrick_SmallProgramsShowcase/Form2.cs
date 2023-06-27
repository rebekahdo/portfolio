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
    public partial class Form2 : Form
    {
        public Form2()
        {
            InitializeComponent();
        }
        //call calculate bmi method
        private void button1_Click(object sender, EventArgs e)
        {
            CalculateBMI();
        }
        // calculate bmi
        private void CalculateBMI()
        {
            if (double.TryParse(textBox1.Text, out double weight) && double.TryParse(textBox2.Text, out double height))
            {
                double bmi = CalculateBMIValue(weight, height);
                string status = DetermineBMIStatus(bmi);
                textBox3.Text = string.Format("{0:F2}", bmi);
                textBox4.Text = status;

            }
            else
            {
                MessageBox.Show("The weight and height must be numbers.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        //bunch of math to determine bmi
        private double CalculateBMIValue(double weight, double height)
        {
            double heightA = height * 0.0254;
            double weightA = weight * 0.453592;
            double bmi = weightA / (heightA * heightA);
            return bmi;
        }
        //assign a status to the bmi value
        private string DetermineBMIStatus(double bmi)
        {
            if (bmi < 18.5)
            {
                return "Underweight";
            }
            else if (bmi >= 18.5 & bmi <= 24.9)
            {
                return "Normal weight";
            }
            else if (bmi >= 25.0 & bmi <= 29.9)
            {
                return "Overweight";
            }
            else
            {
                return "Obese";
            }
        }
    }
}
