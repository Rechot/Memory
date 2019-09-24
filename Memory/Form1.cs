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
    public partial class Form1 : Form
    {
        private bool[] doesButtonHaveAColor = new bool[17];
        private Color[] colorsList = new Color[17];

        public Form1()
        {
            InitializeComponent();
        }

        private void randomButton(Color color) // losuj przyciski i przypisz mu kolor, jeśli przycisk nie jest zajęty;
        {
            Random generator = new Random();
            int fieldNumber = generator.Next(1, 17); // losuj numer pola;

            while (doesButtonHaveAColor[fieldNumber] == true) // jeśli wylosowany numer pola już został wcześniej wylosowany losuj dalej, jeśli nie wyjdź z pętli;
            {
                fieldNumber = generator.Next(1, 17);
            }

            colorsList[fieldNumber] = color;
            doesButtonHaveAColor[fieldNumber] = true;
        }
    }
}
