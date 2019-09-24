using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Memory
{
    public class MyButton : Button
    {

        Form1 form1;
        public int myButtonID = 0;

        public MyButton(Form1 form1, int myButtonID)
        {
            this.form1 = form1;
            this.myButtonID = myButtonID;
        }

        public void button_Click(object sender, EventArgs e)
        {
            if (this.BackColor != form1.mapColorToFiledNumberList[myButtonID])
            {
                this.BackColor = form1.mapColorToFiledNumberList[myButtonID];
                if (form1.firstClick)
                {
                    form1.fieldNumberOneClicked = myButtonID;
                    form1.firstClick = false;
                }
                else
                {
                    form1.fieldNumberTwoCliced = myButtonID;
                    form1.firstClick = true;
                    form1.checkWhetherColorMatch();
                    form1.ColorFileds();
                }
            }
        }
    }

    public partial class Form1 : Form
    {

        public Color[] mapColorToFiledNumberList = new Color[17];
        public Color[] colorsList = new Color[8];
        public int fieldNumberOneClicked = 0, fieldNumberTwoCliced = 0;
        public bool firstClick = true;
        private Button[] buttons = new Button[17];
        private bool[] doesFieldHaveAColor = new bool[17];
        private bool[] coveredFileds = new bool[17];

        public Form1()
        {
            InitializeComponent();
            InitializeColorsList();
            InitializeGameGrid();
            InitilizeButtonArray();
        }

        public void ColorFileds()
        {
            for (int i = 1; i < coveredFileds.Length; i++)
            {
                if (coveredFileds[i] == false)
                {
                    buttons[i].BackColor = mapColorToFiledNumberList[i];
                }
                else
                {
                    buttons[i].BackColor = Color.DarkGray;
                }
            }
        }

        public void checkWhetherColorMatch()
        {
            if (mapColorToFiledNumberList[fieldNumberOneClicked] == mapColorToFiledNumberList[fieldNumberTwoCliced])
            {
                MessageBox.Show("Pair's been found");
                coveredFileds[fieldNumberOneClicked] = false;
                coveredFileds[fieldNumberTwoCliced] = false;
            } else
            {
                MessageBox.Show("Pair's been NOT found, Try again!");
            }

            int uncoverdFieldsCount = 0;
            for (int i = 1; i < coveredFileds.Length; i++)
            {
                if (coveredFileds[i] == false)
                {
                    uncoverdFieldsCount++;
                }
            }

            if (uncoverdFieldsCount == coveredFileds.Length - 1) { MessageBox.Show("You have uncoverd all pairs! Well Done!"); }
        }

        private void randomField(Color color) // losuj przyciski i przypisz mu kolor, jeśli przycisk nie jest zajęty;
        {
            Random generator = new Random();
            int fieldNumber = generator.Next(1, 17); // losuj numer pola;

            while (doesFieldHaveAColor[fieldNumber] == true) // jeśli wylosowany numer pola już został wcześniej wylosowany losuj dalej, jeśli nie wyjdź z pętli;
            {
                fieldNumber = generator.Next(1, 17);
            }

            mapColorToFiledNumberList[fieldNumber] = color; // może Tuple;
            doesFieldHaveAColor[fieldNumber] = true;
        }

        private void InitializeColorsList()
        {
            colorsList[0] = Color.Red;
            colorsList[1] = Color.Blue;
            colorsList[2] = Color.Pink;
            colorsList[3] = Color.Green;
            colorsList[4] = Color.LightCyan;
            colorsList[5] = Color.Gold;
            colorsList[6] = Color.Orange;
            colorsList[7] = Color.White;
        }

        private void InitializeGameGrid()
        {
            int i;
            for (i = 0; i < colorsList.Length; i++ )
            {
                randomField(colorsList[i]); // mamy dwa pola o tym samym kolorze;
                randomField(colorsList[i]);
            }
            for (i = 1; i < coveredFileds.Length; i++)
            {
                coveredFileds[i] = true;
            }
        }

        private void InitilizeButtonArray()
        {
            buttons[1] = button1;
            buttons[2] = button2;
            buttons[3] = button3;
            buttons[4] = button4;
            buttons[5] = button5;
            buttons[6] = button6;
            buttons[7] = button7;
            buttons[8] = button8;
            buttons[9] = button9;
            buttons[10] = button10;
            buttons[11] = button11;
            buttons[12] = button12;
            buttons[13] = button13;
            buttons[14] = button14;
            buttons[15] = button15;
            buttons[16] = button16;
        }

    }
}
