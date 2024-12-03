using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Prince_App_1
{
    public partial class Form2 : Form
    {
        public Form2()
        {
            InitializeComponent();

            // Handle form resizing for responsiveness
            this.Resize += Form2_Resize;

            // Call alignment once to position initially
            AlignGroupBox();
        }

        private void label1_Click(object sender, EventArgs e)
        {
            // Close the current form (Form2)
            this.Close();

            // Reopen Form1
            Form1 form1 = new Form1();
            form1.Show();
        }

        private void Form2_Load(object sender, EventArgs e)
        {

        }

        private void groupBox1_Enter(object sender, EventArgs e)
        {
            // Optional: Define actions when the GroupBox is entered
        }

        private void Form2_Resize(object sender, EventArgs e)
        {
            // Re-align and resize the group box dynamically on form resize
            AlignGroupBox();
        }

        private void AlignGroupBox()
        {
            // Calculate new size and position for GroupBox
            groupBox1.Width = this.ClientSize.Width / 2; // Adjust width
            groupBox1.Height = this.ClientSize.Height / 3; // Adjust height

            groupBox1.Left = (this.ClientSize.Width - groupBox1.Width) / 2; // Center horizontally
            groupBox1.Top = (this.ClientSize.Height - groupBox1.Height) / 2; // Center vertically

            // Adjust label and button sizes within the GroupBox for responsiveness
            label1.Font = new Font(label1.Font.FontFamily, groupBox1.Height / 10); // Adjust font size
            button1.Width = groupBox1.Width / 2; // Adjust button width
            button1.Height = groupBox1.Height / 5; // Adjust button height

            button1.Left = (groupBox1.Width - button1.Width) / 2; // Center button horizontally
            button1.Top = (groupBox1.Height - button1.Height) - 10; // Position button at the bottom
        }
    }
}
