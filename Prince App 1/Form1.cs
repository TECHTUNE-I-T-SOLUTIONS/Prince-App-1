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
    public partial class Form1 : Form
    {
        private Timer growTimer;
        private float currentFontSize;
        private bool isGrowing;

        public Form1()
        {
            InitializeComponent();

            // Initialize label font size and timer
            currentFontSize = label1.Font.Size;
            isGrowing = true; // Indicates the direction of the animation

            growTimer = new Timer();
            growTimer.Interval = 100; // Animation speed (100 ms)
            growTimer.Tick += AnimateLabelFont;

            // Start the grow-shrink animation
            growTimer.Start();

            // Handle form resizing for responsiveness
            this.Resize += Form1_Resize;

            // Call alignment once to position initially
            AlignGroupBox();
        }

        private void AnimateLabelFont(object sender, EventArgs e)
        {
            // Adjust font size based on animation direction
            if (isGrowing)
            {
                currentFontSize += 1f;
                if (currentFontSize >= 30f) // Maximum size
                {
                    isGrowing = false; // Switch direction to shrinking
                }
            }
            else
            {
                currentFontSize -= 1f;
                if (currentFontSize <= 15f) // Minimum size
                {
                    isGrowing = true; // Switch direction to growing
                }
            }

            // Apply new font size
            label1.Font = new Font(label1.Font.FontFamily, currentFontSize);
        }

        private void ShowNextForm()
        {
            // Stop the animation timer
            growTimer.Stop();
            growTimer.Dispose();

            // Show the next form
            Form2 nextForm = new Form2(); // Replace with the actual form class
            nextForm.Show();
            this.Hide(); // Optionally hide the current form
        }

        private void label1_Click(object sender, EventArgs e)
        {
            // Optional: You can define click actions for the label here if needed
        }

        private void button1_Click(object sender, EventArgs e)
        {
            // On button click, transition to the next form
            ShowNextForm();
        }

        private void groupBox1_Enter(object sender, EventArgs e)
        {
            // Optional: Define actions when the GroupBox is entered
        }

        private void Form1_Resize(object sender, EventArgs e)
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