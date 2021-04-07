using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace _6.Individual._14
{
    public partial class Form1 : Form
    {
        private const int fieldWidth = 3;
        private const int fieldHeight = 3;
        private const int cellSize = 200;
        private const int minesAmount = 3;


        private int[,] field;
        private Button[,] allButtons;


        public Form1()
        {
            InitializeComponent();
        }
        private void Form1_Load(object sender, EventArgs e)
        {

            this.FormBorderStyle = FormBorderStyle.FixedSingle;
            this.Text = "Мінер";
            StartGame();
        }

        
        public void StartGame()
        {
            ClearField();
            ClientSize = new Size(cellSize * fieldWidth, cellSize * fieldHeight);
            field = new int[fieldHeight, fieldWidth];
            allButtons = new Button[fieldHeight, fieldWidth];

            for (int i = 0; i < fieldHeight; i++)
            {
                for (int j = 0; j < fieldWidth; j++)
                {
                    Button button = new Button();
                    button.Width = cellSize;
                    button.Height = cellSize;
                    button.Location = new Point(j * cellSize, i * cellSize);
                    int iTemp = i;
                    int jTemp = j;
                    button.Click += (sen, evArg) =>
                    {
                        ButtonClick(iTemp, jTemp);
                    };
                    Controls.Add(button);
                    allButtons[i, j] = button;
                }
            }
            Random random = new Random();
            int mines = minesAmount;

            while (mines > 0)
            {
                int randX = random.Next(0, fieldWidth);
                int randY = random.Next(0, fieldHeight);

                if (field[randY, randX] == 0)
                {
                    field[randY, randX] = 1;
                    mines--;
                }
            }
        }

        private void ClearField()
        {
            if (allButtons != null)
            {
                foreach (Button button in allButtons)
                {
                    Controls.Remove(button);
                }
            }
        }

       
        private void ButtonClick(int i, int j)
        {        
            Button b = allButtons[i, j];
            if (field[i, j] == 1)
            {
                b.BackColor = Color.Red;
                b.Text = "Відірвало кацапу ногу!!!";
                MessageBox.Show("Поразка!");
                StartGame();
                return;
            }
            int minesAroundCount = 0;
            for (int y = i - 1; y <= i + 1; y++)
            {
                for (int x = j - 1; x <= j + 1; x++)
                {
                    if (y == i && x == j) 
                        continue;
                    if (!(y >= 0 && y < fieldHeight) || !(x >= 0 && x < fieldWidth)) 
                        continue;
                    if (field[y, x] == 1)
                    {
                        minesAroundCount++;
                    }
                }
            }
            b.Text = minesAroundCount.ToString();
        }
    }
}
