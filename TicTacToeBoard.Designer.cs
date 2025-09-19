
using System.Drawing;
using System.Windows.Forms;

namespace TicTacToe
{
    partial class TicTacToeBoard
    {
        /// <summary>
        /// Wymagana zmienna projektanta.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Wyczyść wszystkie używane zasoby.
        /// </summary>
        /// <param name="disposing">prawda, jeżeli zarządzane zasoby powinny zostać zlikwidowane; Fałsz w przeciwnym wypadku.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Kod generowany przez Projektanta formularzy systemu Windows

        /// <summary>
        /// Metoda wymagana do obsługi projektanta — nie należy modyfikować
        /// jej zawartości w edytorze kodu.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(TicTacToeBoard));
            this.btn5 = new System.Windows.Forms.Button();
            this.btn9 = new System.Windows.Forms.Button();
            this.btn7 = new System.Windows.Forms.Button();
            this.btn1 = new System.Windows.Forms.Button();
            this.btn8 = new System.Windows.Forms.Button();
            this.btn6 = new System.Windows.Forms.Button();
            this.btn4 = new System.Windows.Forms.Button();
            this.btn2 = new System.Windows.Forms.Button();
            this.btn3 = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.labelRuch = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.wynikX = new System.Windows.Forms.Label();
            this.wynikO = new System.Windows.Forms.Label();
            this.btnRestartuj = new System.Windows.Forms.Button();
            this.Btn_komputer = new System.Windows.Forms.Button();
            this.Btn_kolega = new System.Windows.Forms.Button();
            this.btnEasy = new System.Windows.Forms.Button();
            this.btnMedium = new System.Windows.Forms.Button();
            this.btnHard = new System.Windows.Forms.Button();
            this.btnImpossible = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // btn5
            // 
            this.btn5.Font = new System.Drawing.Font("Microsoft Sans Serif", 72F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.btn5.Location = new System.Drawing.Point(100, 98);
            this.btn5.Margin = new System.Windows.Forms.Padding(0);
            this.btn5.Name = "btn5";
            this.btn5.Size = new System.Drawing.Size(100, 98);
            this.btn5.TabIndex = 0;
            this.btn5.UseVisualStyleBackColor = true;
            this.btn5.Click += new System.EventHandler(this.btn5_Click);
            // 
            // btn9
            // 
            this.btn9.Font = new System.Drawing.Font("Microsoft Sans Serif", 72F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.btn9.Location = new System.Drawing.Point(200, 195);
            this.btn9.Margin = new System.Windows.Forms.Padding(0);
            this.btn9.Name = "btn9";
            this.btn9.Size = new System.Drawing.Size(100, 98);
            this.btn9.TabIndex = 1;
            this.btn9.UseVisualStyleBackColor = true;
            this.btn9.Click += new System.EventHandler(this.btn9_Click);
            // 
            // btn7
            // 
            this.btn7.Font = new System.Drawing.Font("Microsoft Sans Serif", 72F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.btn7.Location = new System.Drawing.Point(0, 195);
            this.btn7.Margin = new System.Windows.Forms.Padding(0);
            this.btn7.Name = "btn7";
            this.btn7.Size = new System.Drawing.Size(100, 98);
            this.btn7.TabIndex = 2;
            this.btn7.UseVisualStyleBackColor = true;
            this.btn7.Click += new System.EventHandler(this.btn7_Click);
            // 
            // btn1
            // 
            this.btn1.Font = new System.Drawing.Font("Microsoft Sans Serif", 72F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.btn1.Location = new System.Drawing.Point(0, 0);
            this.btn1.Margin = new System.Windows.Forms.Padding(0);
            this.btn1.Name = "btn1";
            this.btn1.Size = new System.Drawing.Size(100, 98);
            this.btn1.TabIndex = 4;
            this.btn1.UseVisualStyleBackColor = true;
            this.btn1.Click += new System.EventHandler(this.btn1_Click);
            // 
            // btn8
            // 
            this.btn8.Font = new System.Drawing.Font("Microsoft Sans Serif", 72F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.btn8.Location = new System.Drawing.Point(100, 195);
            this.btn8.Margin = new System.Windows.Forms.Padding(0);
            this.btn8.Name = "btn8";
            this.btn8.Size = new System.Drawing.Size(100, 98);
            this.btn8.TabIndex = 5;
            this.btn8.UseVisualStyleBackColor = true;
            this.btn8.Click += new System.EventHandler(this.btn8_Click);
            // 
            // btn6
            // 
            this.btn6.Font = new System.Drawing.Font("Microsoft Sans Serif", 72F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.btn6.Location = new System.Drawing.Point(200, 98);
            this.btn6.Margin = new System.Windows.Forms.Padding(0);
            this.btn6.Name = "btn6";
            this.btn6.Size = new System.Drawing.Size(100, 98);
            this.btn6.TabIndex = 7;
            this.btn6.UseVisualStyleBackColor = true;
            this.btn6.Click += new System.EventHandler(this.btn6_Click);
            // 
            // btn4
            // 
            this.btn4.Font = new System.Drawing.Font("Microsoft Sans Serif", 72F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.btn4.Location = new System.Drawing.Point(0, 98);
            this.btn4.Margin = new System.Windows.Forms.Padding(0);
            this.btn4.Name = "btn4";
            this.btn4.Size = new System.Drawing.Size(100, 98);
            this.btn4.TabIndex = 9;
            this.btn4.UseVisualStyleBackColor = true;
            this.btn4.Click += new System.EventHandler(this.btn4_Click);
            // 
            // btn2
            // 
            this.btn2.Font = new System.Drawing.Font("Microsoft Sans Serif", 72F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.btn2.Location = new System.Drawing.Point(100, 0);
            this.btn2.Margin = new System.Windows.Forms.Padding(0);
            this.btn2.Name = "btn2";
            this.btn2.Size = new System.Drawing.Size(100, 98);
            this.btn2.TabIndex = 10;
            this.btn2.UseVisualStyleBackColor = true;
            this.btn2.Click += new System.EventHandler(this.btn2_Click);
            // 
            // btn3
            // 
            this.btn3.Font = new System.Drawing.Font("Microsoft Sans Serif", 72F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.btn3.Location = new System.Drawing.Point(200, 0);
            this.btn3.Margin = new System.Windows.Forms.Padding(0);
            this.btn3.Name = "btn3";
            this.btn3.Size = new System.Drawing.Size(100, 98);
            this.btn3.TabIndex = 11;
            this.btn3.UseVisualStyleBackColor = true;
            this.btn3.Click += new System.EventHandler(this.btn3_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 16F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.label1.Location = new System.Drawing.Point(381, 6);
            this.label1.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(140, 26);
            this.label1.TabIndex = 12;
            this.label1.Text = "Ruch gracza:";
            // 
            // labelRuch
            // 
            this.labelRuch.AutoSize = true;
            this.labelRuch.Font = new System.Drawing.Font("Microsoft Sans Serif", 20F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.labelRuch.Location = new System.Drawing.Point(431, 39);
            this.labelRuch.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.labelRuch.Name = "labelRuch";
            this.labelRuch.Size = new System.Drawing.Size(200, 31);
            this.labelRuch.TabIndex = 13;
            this.labelRuch.Text = "X";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 16F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.label2.Location = new System.Drawing.Point(409, 73);
            this.label2.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(78, 26);
            this.label2.TabIndex = 14;
            this.label2.Text = "Wynik:";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 16F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.label3.Location = new System.Drawing.Point(488, 98);
            this.label3.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(33, 26);
            this.label3.TabIndex = 15;
            this.label3.Text = "X:";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 16F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.label4.Location = new System.Drawing.Point(344, 98);
            this.label4.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(35, 26);
            this.label4.TabIndex = 16;
            this.label4.Text = "O:";
            // 
            // wynikX
            // 
            this.wynikX.AutoSize = true;
            this.wynikX.Font = new System.Drawing.Font("Microsoft Sans Serif", 16F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.wynikX.Location = new System.Drawing.Point(523, 98);
            this.wynikX.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.wynikX.Name = "wynikX";
            this.wynikX.Size = new System.Drawing.Size(24, 26);
            this.wynikX.TabIndex = 17;
            this.wynikX.Text = "0";
            // 
            // wynikO
            // 
            this.wynikO.AutoSize = true;
            this.wynikO.Font = new System.Drawing.Font("Microsoft Sans Serif", 16F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.wynikO.Location = new System.Drawing.Point(382, 98);
            this.wynikO.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.wynikO.Name = "wynikO";
            this.wynikO.Size = new System.Drawing.Size(24, 26);
            this.wynikO.TabIndex = 18;
            this.wynikO.Text = "0";
            // 
            // btnRestartuj
            // 
            this.btnRestartuj.Font = new System.Drawing.Font("Microsoft Sans Serif", 20F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.btnRestartuj.Location = new System.Drawing.Point(386, 234);
            this.btnRestartuj.Margin = new System.Windows.Forms.Padding(0);
            this.btnRestartuj.Name = "btnRestartuj";
            this.btnRestartuj.Size = new System.Drawing.Size(133, 49);
            this.btnRestartuj.TabIndex = 19;
            this.btnRestartuj.Text = "Restartuj";
            this.btnRestartuj.UseVisualStyleBackColor = true;
            this.btnRestartuj.Click += new System.EventHandler(this.btnRestartuj_Click);
            // 
            // Btn_komputer
            // 
            this.Btn_komputer.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.Btn_komputer.Location = new System.Drawing.Point(447, 124);
            this.Btn_komputer.Margin = new System.Windows.Forms.Padding(0);
            this.Btn_komputer.Name = "Btn_komputer";
            this.Btn_komputer.Size = new System.Drawing.Size(133, 49);
            this.Btn_komputer.TabIndex = 20;
            this.Btn_komputer.Text = "Zagraj z komputerem";
            this.Btn_komputer.UseVisualStyleBackColor = true;
            this.Btn_komputer.Click += new System.EventHandler(this.Btn_komputer_Click);
            // 
            // Btn_kolega
            // 
            this.Btn_kolega.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.Btn_kolega.Location = new System.Drawing.Point(307, 124);
            this.Btn_kolega.Margin = new System.Windows.Forms.Padding(0);
            this.Btn_kolega.Name = "Btn_kolega";
            this.Btn_kolega.Size = new System.Drawing.Size(133, 49);
            this.Btn_kolega.TabIndex = 21;
            this.Btn_kolega.Text = "Zagraj z kolegą";
            this.Btn_kolega.UseVisualStyleBackColor = true;
            this.Btn_kolega.Click += new System.EventHandler(this.Btn_kolega_Click);
            // 
            // btnEasy
            // 
            this.btnEasy.BackColor = System.Drawing.Color.LightGreen;
            this.btnEasy.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.btnEasy.Location = new System.Drawing.Point(307, 175);
            this.btnEasy.Margin = new System.Windows.Forms.Padding(2);
            this.btnEasy.Name = "btnEasy";
            this.btnEasy.Size = new System.Drawing.Size(90, 23);
            this.btnEasy.TabIndex = 22;
            this.btnEasy.Text = "Łatwy";
            this.btnEasy.UseVisualStyleBackColor = false;
            this.btnEasy.Visible = false;
            this.btnEasy.Click += new System.EventHandler(this.Btn_easy_Click);
            // 
            // btnMedium
            // 
            this.btnMedium.BackColor = System.Drawing.Color.Orange;
            this.btnMedium.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.btnMedium.Location = new System.Drawing.Point(447, 175);
            this.btnMedium.Margin = new System.Windows.Forms.Padding(2);
            this.btnMedium.Name = "btnMedium";
            this.btnMedium.Size = new System.Drawing.Size(90, 23);
            this.btnMedium.TabIndex = 23;
            this.btnMedium.Text = "Średni";
            this.btnMedium.UseVisualStyleBackColor = false;
            this.btnMedium.Visible = false;
            this.btnMedium.Click += new System.EventHandler(this.Btn_medium_Click);
            // 
            // btnHard
            // 
            this.btnHard.BackColor = System.Drawing.Color.OrangeRed;
            this.btnHard.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.btnHard.Location = new System.Drawing.Point(307, 202);
            this.btnHard.Margin = new System.Windows.Forms.Padding(2);
            this.btnHard.Name = "btnHard";
            this.btnHard.Size = new System.Drawing.Size(90, 23);
            this.btnHard.TabIndex = 24;
            this.btnHard.Text = "Trudny";
            this.btnHard.UseVisualStyleBackColor = false;
            this.btnHard.Visible = false;
            this.btnHard.Click += new System.EventHandler(this.Btn_hard_Click);
            // 
            // btnImpossible
            // 
            this.btnImpossible.BackColor = System.Drawing.Color.DarkRed;
            this.btnImpossible.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.btnImpossible.Location = new System.Drawing.Point(447, 209);
            this.btnImpossible.Margin = new System.Windows.Forms.Padding(2);
            this.btnImpossible.Name = "btnImpossible";
            this.btnImpossible.Size = new System.Drawing.Size(90, 23);
            this.btnImpossible.TabIndex = 25;
            this.btnImpossible.Text = "Niemożliwy";
            this.btnImpossible.UseVisualStyleBackColor = false;
            this.btnImpossible.Visible = false;
            this.btnImpossible.Click += new System.EventHandler(this.Btn_impossible_Click);
            // 
            // TicTacToeBoard
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.ClientSize = new System.Drawing.Size(589, 292);
            this.Controls.Add(this.btnEasy);
            this.Controls.Add(this.btnMedium);
            this.Controls.Add(this.btnHard);
            this.Controls.Add(this.btnImpossible);
            this.Controls.Add(this.Btn_kolega);
            this.Controls.Add(this.Btn_komputer);
            this.Controls.Add(this.btnRestartuj);
            this.Controls.Add(this.wynikO);
            this.Controls.Add(this.wynikX);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.labelRuch);
            this.Controls.Add(this.btn3);
            this.Controls.Add(this.btn2);
            this.Controls.Add(this.btn4);
            this.Controls.Add(this.btn6);
            this.Controls.Add(this.btn8);
            this.Controls.Add(this.btn1);
            this.Controls.Add(this.btn7);
            this.Controls.Add(this.btn9);
            this.Controls.Add(this.btn5);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(2);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "TicTacToeBoard";
            this.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.Text = "Kółko i Krzyżyk";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btn5;
        private System.Windows.Forms.Button btn9;
        private System.Windows.Forms.Button btn7;
        private System.Windows.Forms.Button btn1;
        private System.Windows.Forms.Button btn8;
        private System.Windows.Forms.Button btn6;
        private System.Windows.Forms.Button btn4;
        private System.Windows.Forms.Button btn2;
        private System.Windows.Forms.Button btn3;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label labelRuch;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label wynikX;
        private System.Windows.Forms.Label wynikO;
        private System.Windows.Forms.Button btnRestartuj;
        private System.Windows.Forms.Button Btn_komputer;
        private System.Windows.Forms.Button Btn_kolega;

        private System.Windows.Forms.Button btnEasy;
        private System.Windows.Forms.Button btnMedium;
        private System.Windows.Forms.Button btnHard;
        private System.Windows.Forms.Button btnImpossible;
    }
}

