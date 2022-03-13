using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace TicTacToe
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        public static class Global
        {
            private static Button[] buttons = new Button[9];

            public static Button[] Buttons { get => buttons; set => buttons = value; }

        }

        private void Form1_Load(object sender, EventArgs e)
        {
            Global.Buttons[0] = btn1;
            Global.Buttons[1] = btn2;
            Global.Buttons[2] = btn3;
            Global.Buttons[3] = btn4;
            Global.Buttons[4] = btn5;
            Global.Buttons[5] = btn6;
            Global.Buttons[6] = btn7;
            Global.Buttons[7] = btn8;
            Global.Buttons[8] = btn9;

            foreach (var item in Global.Buttons)
            {
                item.Enabled = false;
            }
            btnRestartuj.Enabled = false;
        }
        // Kolej gracza
        bool gracz1 = true;
        // Nr ruchu
        byte ruch = 0;

        //Funkcje
        private void Restartuj()
        {
            foreach (var button in Global.Buttons)
            {
                button.Text = "";
                button.Enabled = true;
            }
            // Liczymy ruchy od początku
            ruch = 0;
        }

        private void Sprawdz()
        {
            if ((btn1.Text == "O" && btn2.Text == "O" && btn3.Text == "O") ||
               (btn1.Text == "O" && btn4.Text == "O" && btn7.Text == "O") ||
               (btn2.Text == "O" && btn5.Text == "O" && btn8.Text == "O") ||
               (btn4.Text == "O" && btn5.Text == "O" && btn6.Text == "O") ||
               (btn1.Text == "O" && btn5.Text == "O" && btn9.Text == "O") ||
               (btn3.Text == "O" && btn5.Text == "O" && btn7.Text == "O") ||
               (btn3.Text == "O" && btn6.Text == "O" && btn9.Text == "O") ||
               (btn7.Text == "O" && btn8.Text == "O" && btn9.Text == "O"))
            {
                WygranaO();
            }


            else if ((btn1.Text == "X" && btn2.Text == "X" && btn3.Text == "X") ||
                    (btn1.Text == "X" && btn4.Text == "X" && btn7.Text == "X") ||
                    (btn2.Text == "X" && btn5.Text == "X" && btn8.Text == "X") ||
                    (btn4.Text == "X" && btn5.Text == "X" && btn6.Text == "X") ||
                    (btn1.Text == "X" && btn5.Text == "X" && btn9.Text == "X") ||
                    (btn3.Text == "X" && btn5.Text == "X" && btn7.Text == "X") ||
                    (btn3.Text == "X" && btn6.Text == "X" && btn9.Text == "X") ||
                    (btn7.Text == "X" && btn8.Text == "X" && btn9.Text == "X"))
            {
                WygranaX();
            }

            else if (ruch == 9)
            {

                MessageBox.Show("Remis", "Koniec gry", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                Restartuj();
            }
        }

        private void WygranaX()
        {

            MessageBox.Show("Wygrywa gracz X!!!", "Wygrana!", MessageBoxButtons.OK, MessageBoxIcon.Information);
            wynikX.Text = (byte.Parse(wynikX.Text) + 1).ToString();
            Restartuj();

        }

        private void WygranaO()
        {

            MessageBox.Show("Wygrywa gracz O!!!", "Wygrana!", MessageBoxButtons.OK, MessageBoxIcon.Information);
            wynikO.Text = (byte.Parse(wynikO.Text) + 1).ToString();
            Restartuj();
        }

        private void Klik(object sender)
        {
            ruch++;
            ((Button)sender).Text = gracz1 ? "O" : "X";

            gracz1 = !gracz1;
            labelRuch.Text = gracz1 ? "O" : "X";
            ((Button)sender).Enabled = false;
            if (ruch >= 5)
            {
                Sprawdz();
            }
            if (Btn_kolega.Enabled == true && Btn_komputer.Enabled == false)
                RuchKomputera();
        }

        //Przyciski
        private void Btn_kolega_Click(object sender, EventArgs e)
        {
            Btn_komputer.Enabled = true;
            Restartuj();
            btnRestartuj.PerformClick();
            btnRestartuj.Enabled = true;
            Btn_kolega.Enabled = false;
        }

        private void Btn_komputer_Click(object sender, EventArgs e)
        {
            Btn_kolega.Enabled = true;
            Btn_komputer.Enabled = false;
            btnRestartuj.Enabled = true;
            btnRestartuj.PerformClick();
        }

        private void btnRestartuj_Click(object sender, EventArgs e)
        {
            wynikO.Text = "0";
            wynikX.Text = "0";
            labelRuch.Text = "O";
            gracz1 = true;
            Restartuj();
            // Jeśli gramy z komputerem komputer zaczyna pierwszą rundę
            if (Btn_kolega.Enabled == true && Btn_komputer.Enabled == false)
                RuchKomputera();
        }


        private void btn1_Click(object sender, EventArgs e)
        {
            Klik(sender);
        }

        private void btn2_Click(object sender, EventArgs e)
        {
            Klik(sender);
        }

        private void btn3_Click(object sender, EventArgs e)
        {
            Klik(sender);
        }

        private void btn4_Click(object sender, EventArgs e)
        {
            Klik(sender);
        }

        private void btn5_Click(object sender, EventArgs e)
        {
            Klik(sender);
        }

        private void btn6_Click(object sender, EventArgs e)
        {
            Klik(sender);
        }

        private void btn7_Click(object sender, EventArgs e)
        {
            Klik(sender);
        }

        private void btn8_Click(object sender, EventArgs e)
        {
            Klik(sender);
        }

        private void btn9_Click(object sender, EventArgs e)
        {
            Klik(sender);
        }

        //Dwie funkcje opisujące ruchy komputera, bez sztucznej inteligencji, ruchy uwarunkowane prostymi instrukcjami

        //Funkcja losująca przycisk z rogu
        public int RandCorner()
        {
            Random random = new Random();
            int los = random.Next(0, 4);
            if (los == 1)
                los = 6;
            else if (los == 3)
                los = 8;
            return los;
        }
        //Funkcja losująca przycisk
        public int RandAll()
        {
            Random random = new Random();
            int los = random.Next(0, 9);
            return los;
        }
        public void RuchKomputera()
        {
            // Zaczniemy od losowego rogu, by komputer miał szansę na wygraną
            int los = RandCorner();
            int los2 = RandAll();
            if (gracz1 && ruch == 0)
                Global.Buttons[los].PerformClick();

            // Jeśli komputer zaczyna jako drugi (w drugiej rundzie) zaznacza środek (jeśli nie zajęty),
            // aby miał większą szanse przetrwać 
            if (gracz1 && ruch == 1 && Global.Buttons[4].Text == "")
                Global.Buttons[4].PerformClick();
            else if (gracz1 && ruch == 1 && Global.Buttons[4].Text != "")
            {
                if (Global.Buttons[los].Enabled == true)
                    Global.Buttons[los].PerformClick();
                else
                {
                    while (Global.Buttons[los].Enabled == false)
                    {
                        los2 = RandAll();
                    }
                    Global.Buttons[los].PerformClick();
                }
            }
            // Jeśli komputer rusza się drugi raz przechodzimy do funkcji drugiej, która pozwoli mu wygrać,
            // bądź nie przegrać szybko
            if (gracz1 && ruch >= 2)
                BestMove();
        }

        public void BestMove()
        {
            //Sztuczka, prowadząca do możliwej wygranej, nie ustawiamy jej idealnie, aby zostało trochę zabawy 
            if (ruch == 2)
            {
                int los = RandCorner();
                if (Global.Buttons[los].Enabled == true)
                    Global.Buttons[los].PerformClick();
                else
                {
                    while (Global.Buttons[los].Enabled == false)
                    {
                        los = RandCorner();
                    }
                    Global.Buttons[los].PerformClick();
                }
            }
            else
            {
                //Żeby wygrać 

                Mozliwosci("O");

                //Żeby nie przegrać

                Mozliwosci("X");

                if(gracz1)
                {
                    foreach (var item in Global.Buttons)
                    {
                        if (item.Enabled == true)
                        {
                            item.PerformClick();
                            break;
                        }
                    }
                }
            }

            
        }


        public void Mozliwosci(string znak) { 
        
            if (Global.Buttons[0].Text == znak && Global.Buttons[1].Text == znak && Global.Buttons[0].Text == Global.Buttons[1].Text && Global.Buttons[2].Enabled == true)
                Global.Buttons[2].PerformClick();
            else if (Global.Buttons[1].Text == znak && Global.Buttons[2].Text == znak && Global.Buttons[1].Text == Global.Buttons[2].Text && Global.Buttons[0].Enabled == true)
                Global.Buttons[0].PerformClick();
            else if (Global.Buttons[2].Text == znak && Global.Buttons[0].Text == znak && Global.Buttons[2].Text == Global.Buttons[0].Text && Global.Buttons[1].Enabled == true)
                Global.Buttons[1].PerformClick();
            else if (Global.Buttons[3].Text == znak && Global.Buttons[4].Text == znak && Global.Buttons[3].Text == Global.Buttons[4].Text && Global.Buttons[5].Enabled == true)
                Global.Buttons[5].PerformClick();
            else if (Global.Buttons[3].Text == znak && Global.Buttons[5].Text == znak && Global.Buttons[3].Text == Global.Buttons[5].Text && Global.Buttons[4].Enabled == true)
                Global.Buttons[4].PerformClick();
            else if (Global.Buttons[5].Text == znak && Global.Buttons[4].Text == znak && Global.Buttons[5].Text == Global.Buttons[4].Text && Global.Buttons[3].Enabled == true)
                Global.Buttons[3].PerformClick();
            else if (Global.Buttons[6].Text == znak && Global.Buttons[7].Text == znak && Global.Buttons[6].Text == Global.Buttons[7].Text && Global.Buttons[8].Enabled == true)
                Global.Buttons[8].PerformClick();
            else if (Global.Buttons[7].Text == znak && Global.Buttons[8].Text == znak && Global.Buttons[7].Text == Global.Buttons[8].Text && Global.Buttons[6].Enabled == true)
                Global.Buttons[6].PerformClick();
            else if (Global.Buttons[6].Text == znak && Global.Buttons[8].Text == znak && Global.Buttons[6].Text == Global.Buttons[8].Text && Global.Buttons[7].Enabled == true)
                Global.Buttons[7].PerformClick();
         
            else if (Global.Buttons[0].Text == znak && Global.Buttons[3].Text == znak && Global.Buttons[0].Text == Global.Buttons[3].Text && Global.Buttons[6].Enabled == true)
                Global.Buttons[6].PerformClick();
            else if (Global.Buttons[3].Text == znak && Global.Buttons[6].Text == znak && Global.Buttons[6].Text == Global.Buttons[3].Text && Global.Buttons[0].Enabled == true)
                Global.Buttons[0].PerformClick();
            else if (Global.Buttons[6].Text == znak && Global.Buttons[0].Text == znak && Global.Buttons[6].Text == Global.Buttons[0].Text && Global.Buttons[3].Enabled == true)
                Global.Buttons[3].PerformClick();
            else if (Global.Buttons[1].Text == znak && Global.Buttons[4].Text == znak && Global.Buttons[1].Text == Global.Buttons[4].Text && Global.Buttons[7].Enabled == true)
                Global.Buttons[7].PerformClick();
            else if (Global.Buttons[4].Text == znak && Global.Buttons[7].Text == znak && Global.Buttons[4].Text == Global.Buttons[7].Text && Global.Buttons[1].Enabled == true)
                Global.Buttons[1].PerformClick();
            else if (Global.Buttons[1].Text == znak && Global.Buttons[7].Text == znak && Global.Buttons[1].Text == Global.Buttons[7].Text && Global.Buttons[4].Enabled == true)
                Global.Buttons[4].PerformClick();
            else if (Global.Buttons[2].Text == znak && Global.Buttons[5].Text == znak && Global.Buttons[2].Text == Global.Buttons[5].Text && Global.Buttons[8].Enabled == true)
                Global.Buttons[8].PerformClick();
            else if (Global.Buttons[2].Text == znak && Global.Buttons[8].Text == znak && Global.Buttons[2].Text == Global.Buttons[8].Text && Global.Buttons[5].Enabled == true)
                Global.Buttons[5].PerformClick();
            else if (Global.Buttons[5].Text == znak && Global.Buttons[8].Text == znak && Global.Buttons[5].Text == Global.Buttons[8].Text && Global.Buttons[2].Enabled == true)
                Global.Buttons[2].PerformClick();
        
            else if (Global.Buttons[0].Text == znak && Global.Buttons[8].Text == znak && Global.Buttons[0].Text == Global.Buttons[8].Text && Global.Buttons[4].Enabled == true)
                Global.Buttons[4].PerformClick();
            else if (Global.Buttons[4].Text == znak && Global.Buttons[8].Text == znak && Global.Buttons[4].Text == Global.Buttons[8].Text && Global.Buttons[0].Enabled == true)
                Global.Buttons[0].PerformClick();
            else if (Global.Buttons[4].Text == znak && Global.Buttons[0].Text == znak && Global.Buttons[4].Text == Global.Buttons[0].Text && Global.Buttons[8].Enabled == true)
                Global.Buttons[8].PerformClick();
            else if (Global.Buttons[4].Text == znak && Global.Buttons[2].Text == znak && Global.Buttons[4].Text == Global.Buttons[2].Text && Global.Buttons[6].Enabled == true)
                Global.Buttons[6].PerformClick();
            else if (Global.Buttons[4].Text == znak && Global.Buttons[6].Text == znak && Global.Buttons[4].Text == Global.Buttons[6].Text && Global.Buttons[2].Enabled == true)
                Global.Buttons[2].PerformClick();
            else if (Global.Buttons[2].Text == znak && Global.Buttons[6].Text == znak && Global.Buttons[2].Text == Global.Buttons[6].Text && Global.Buttons[4].Enabled == true)
                Global.Buttons[4].PerformClick();    
        }

    }
}
