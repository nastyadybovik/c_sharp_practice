using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace barley_break
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent(N);
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            
        }

        private void button_Click(object sender, EventArgs e)
        {
            countSteps++;

            System.Windows.Forms.Button button = (System.Windows.Forms.Button) sender;
            int left = button.Left;
            int top = button.Top;

            if (Math.Abs(buttonArray[N * N - 1].Left - left) + Math.Abs(buttonArray[N * N - 1].Top - top) == 50)
            {
                changeButtonWithSpace(button);

            }

            if (started && checkFinish())
            {
                this.soundPlayer.Stream = Properties.Resources.winSound;
                soundPlayer.Play();
                this.labelWin.Text = "YEEH! Your score " + countSteps + " .";
            }                    
            
        }
        private void buttonStart_Click(object sender, EventArgs e)
        {
            Random rnd = new Random();
            int n = 0;
            for (int i = 0; i < 100; i++)
            {
                //от 0 до N*N-1
                n = 0 + rnd.Next(N * N - 1);
                this.buttonArray[n].PerformClick();
            }

            started = true;
            
        }

        private void changeButtonWithSpace(Button button)
        {
            Point temp = button.Location;
            button.Location = buttonArray[N * N - 1].Location;
            buttonArray[N * N - 1].Location = temp;
        }

        private Boolean checkFinish()
        {
            for (int i = 0; i < N; i++)
            {
                for (int j = 0; j < N; j++)
                {
                    if (this.buttonArray[i * N + j].Location.X != 50 * j ||
                       this.buttonArray[i * N + j].Location.Y != 50 * i)
                    {
                        return false;
                    }
                }
            }
            
            return true;
        }

        private int N = 3;
        private int countSteps;
        private Boolean started;
    }
}
