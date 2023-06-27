namespace Myrick_SmallProgramsShowcase
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        //about button
        private void helpToolStripMenuItem_Click(object sender, EventArgs e)
        {
            MessageBox.Show("\"Small Programs Showcase\" by Rebekah Myrick\n for CPSC 23000 Summer 2023");
        }
        //exit button
        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
        //bmi button
        private void bMICalculatorToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Form2 otherForm = new Form2();
            otherForm.Show();
        }
        //password generator button
        private void passwordGeneratorToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Form3 anotherForm = new Form3();
            anotherForm.Show();
        }
        //word counter button
        private void wordCounterToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Form4 lastForm = new Form4();
            lastForm.Show();
        }
    }
}