using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;

namespace Spanzuratoarea
{
    public partial class Form1 : Form
    {
        Button[] b = new Button [27];
        Label[] l = new Label[20];
        Label[] l1 = new Label[20];
        string[] cuvinte;
        string cuv; char lit;
        int z, ok, nr;
        StreamReader f;
        int poz;
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            int i;
            for (i = 0; i <= 25; i++)
            {b[i] = new Button();
            b[i].Width = b[i].Height = 40;
            b[i].Top = 20;
            b[i].Left = 35 + i * 40;
            b[i].Text = Convert.ToString(Convert.ToChar(i + 97));
            b[i].Font = new Font("Microsoft Sans Serif", 12);
            b[i].Enabled = false;
            b[i].Click += new EventHandler(clic);
            Controls.Add(b[i]);
        }
        }

        void citire()
        {
            f = File.OpenText("spanzuratoarea.txt");
            //se citeste vectorul de cuvinte din fisier incapand cu pozitia curenta
            cuvinte = f.ReadToEnd().Split(new Char[] { ' ' });
            //se genereaza o pozitie aleatoare in vectorul cuvintelor
            Random nr = new Random();
            //i este o pozitie aleatoare intre 0 si nr de cuvinte -1
            poz = nr.Next(0, cuvinte.Length - 1);
            //se alege aleatoriu un cuvant
            cuv = cuvinte[poz];
        }

        void clic(object sender, EventArgs e)
        {
            ok = 1;
            lit = Convert.ToChar(((Button)sender).Text);
            for (int i = 0; i < cuv.Length; i++)
                if (lit == cuv[i])
                {
                    l[i].Text = Convert.ToString(lit);
                    l[i].Font = new Font ("Microsoft Sans Serif", 14);
                    ok = 0;
                    nr++;
                }
             if ( ok == 1 )
                {                    
                    label4.Text = Convert.ToString(6 - z);
                    l1[z] = new Label();
                    l1[z].Width = l1[z].Height = 40;
                    l1[z].Top = 375;
                    l1[z].Left = 40 + z * 40;
                    l1[z].Text = Convert.ToString(lit);
                    l1[z].Font = new Font("Microsoft Sans Serif", 14);
                    Controls.Add(l1[z]);
                    z++;
                    if (z == 1)
                    {
                        cap();
                        label4.Visible = true;
                        label4.Text = Convert.ToString(6);
                    }
                    if (z == 2)
                        corp();
                    if (z == 3)
                        mana_dreapta();
                    if (z == 4)
                        mana_stanga();
                    if (z == 5)
                        picior_drept();
                    if (z == 6)
                        picior_stang();
                    if (z == 7)
                    {
                        for (int j = 0; j <= 25; j++)
                        {
                            b[j].Enabled = false;
                        }
                        for (int i = 0; i < cuv.Length; i++)
                            if (l[i].Text == "__")
                            {
                                l[i].Text = Convert.ToString(cuv[i]);
                                l[i].Font = new Font("Microsoft Sans Serif", 14);
                                l[i].ForeColor = Color.Red;
                            }
                        MessageBox.Show(" Nu ați aflat cuvântul la timp ! ");
                    }
                }
            b[lit - 97].Enabled = false;
            if (nr == cuv.Length && ok == 0 && z < 7)
            {
                MessageBox.Show(" Felicitări, ați aflat cuvântul ! ");
                for (int j = 0; j <= 25; j++)
                {
                    b[j].Enabled = false;
                }
            }
        }

        void cap()
        {
            System.Drawing.Pen pen1 = new System.Drawing.Pen(System.Drawing.Color.Black, 2);
            System.Drawing.Graphics graphics = this.CreateGraphics();
            System.Drawing.Rectangle rectangle = new System.Drawing.Rectangle(750, 150, 100, 100);
            graphics.DrawEllipse(pen1, rectangle);
        }

        void corp()
        {
            Graphics linie = this.CreateGraphics();
            Pen penita1 = new Pen(Color.Black, 2);
            Point p1 = new Point(), p2 = new Point();
            p1.X = 800;
            p1.Y = 250;
            p2.X = 800;
            p2.Y = 380;
            linie.DrawLine(penita1, p1, p2); 
        }

        void mana_dreapta()
        {
            Graphics linie = this.CreateGraphics();
            Pen penita1 = new Pen(Color.Black, 2);
            Point p1 = new Point(), p2 = new Point();
            p1.X = 800;
            p1.Y = 275;
            p2.X = 890;
            p2.Y = 350;
            linie.DrawLine(penita1, p1, p2); 
        }

        void mana_stanga()
        {
            Graphics linie = this.CreateGraphics();
            Pen penita1 = new Pen(Color.Black, 2);
            Point p1 = new Point(), p2 = new Point();
            p1.X = 800;
            p1.Y = 275;
            p2.X = 710;
            p2.Y = 350;
            linie.DrawLine(penita1, p1, p2); 
        }

        void picior_stang()
        {
            Graphics linie = this.CreateGraphics();
            Pen penita1 = new Pen(Color.Black, 2);
            Point p1 = new Point(), p2 = new Point();
            p1.X = 800;
            p1.Y = 378;
            p2.X = 750;
            p2.Y = 495;
            linie.DrawLine(penita1, p1, p2); 
        }

        void picior_drept()
        {
            Graphics linie = this.CreateGraphics();
            Pen penita1 = new Pen(Color.Black, 2);
            Point p1 = new Point(), p2 = new Point();
            p1.X = 800;
            p1.Y = 378;
            p2.X = 860;
            p2.Y = 495;
            linie.DrawLine(penita1, p1, p2); 
        }
        private void button1_Click(object sender, EventArgs e)
        {
            citire();
            Graphics linie = this.CreateGraphics();
            Pen penita1 = new Pen(Color.Black, 5);
            Point p1 = new Point(), p2 = new Point();
            p1.X = 800;
            p1.Y = 100;
            p2.X = 800;
            p2.Y = 150;
            linie.DrawLine(penita1, p1, p2);
            p1.X = 800;
            p1.Y = 100;
            p2.X = 975;
            p2.Y = 100;
            linie.DrawLine(penita1, p1, p2);
            p1.X = 975;
            p1.Y = 100;
            p2.X = 975;
            p2.Y = 550;
            linie.DrawLine(penita1, p1, p2);
            p1.X = 630;
            p1.Y = 550;
            p2.X = 975;
            p2.Y = 550;
            linie.DrawLine(penita1, p1, p2);
            p1.X = 630;
            p1.Y = 550;
            p2.X = 1100;
            p2.Y = 550;
            linie.DrawLine(penita1, p1, p2);
            p1.X = 875;
            p1.Y = 100;
            p2.X = 975;
            p2.Y = 200;
            linie.DrawLine(penita1, p1, p2);
            for (int i = 0; i < cuv.Length; i++)
            {
                l[i] = new Label();
                l[i].Width = l[i].Height = 30;
                l[i].Top = 265;
                l[i].Left = 35 + i * 35;
                l[i].Text = "__";
                l[i].Font = new Font("Microsoft Sans Serif", 12);
                Controls.Add(l[i]);
            }
            for (int j = 0; j <= 25; j++)
                b[j].Enabled = true;
            button2.Enabled = true;
            button1.Enabled = false;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            for (int i = 0; i < cuv.Length; i++)
            {
                l[i].Dispose();
            }
            for (int j = 0; j < z; j++)
            {
                l1[j].Dispose();
            }
            z = 0;
            for (int j = 0; j <= 25; j++)
            {
                b[j].Enabled = false;
            }
            this.Invalidate();
            label4.Visible = false;
            label4.Text = null;
            button2.Enabled = false;
            button1.Enabled = true;
        }
    }
}
