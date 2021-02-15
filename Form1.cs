using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BackPropagation
{
    public partial class Form1 : Form
    {
        public class neuron
        {
            public double[] W { get; set; }
            public double Out { get; set; }
            public double prag { get; set; }
            public neuron(int nr_elemente)
            {
                W = new double[nr_elemente];
                for (int i = 0; i < nr_elemente; i++)
                {
                    W[i] = getRandomDouble();
                }
                prag = getRandomDouble();
                Out = 0;
            }
        }

        class Punct
        {
            public int x { get; set; }
            public int y { get; set; }
            public Color color { get; set; }

            public Punct(int x, int y, Color color)
            {
                this.x = x;
                this.y = y;
                this.color = color;

            }
        }
        #region generareRandom
        public static readonly Random getRandom = new Random();
        public static int getRandomNumber(int min, int max)
        {
            lock (getRandom)
            {
                return getRandom.Next(min, max);
            }
        }
        public static double getRandomDouble()
        {
            lock (getRandom)
            {
                return getRandom.NextDouble();
            }
        }
        #endregion
        public Form1()
        {
            InitializeComponent();
            onlineRadio.Checked = true;
        }
        #region variabileGlobale
        Graphics g;
        Pen p;
   
        int nr_exemple = 10000;
        double[] dateX1 ;
        double[] dateX2;
        double[] dateY;
        neuron[] x, h;
        neuron y;
        int nr_unitati_intrare = 2, hidden_neurons = 4;


        //centruGreutate [culoare,Gx,Gy];
        Color[] colors = { Color.Blue, Color.Red, Color.Green, Color.Brown, Color.Turquoise, Color.Orange, Color.Pink, Color.Coral, Color.LightGreen, Color.Lime };
        #endregion
        private void btn_drawLines_Click(object sender, EventArgs e)
        {
            g = panel1.CreateGraphics();
            p = new Pen(Color.Black);
            p.Width = 3;
            g.TranslateTransform((float)(panel1.Width / 2), (float)(panel1.Height / 2));
            drawLines();
        }
    private void drawLines()
        {
            g.DrawLine(p, 0, 300, 0, -300);
            g.DrawLine(p, -300, 0, 300, 0);
        }
        private void EtapaAntrenare()
        {

            double gradient = 0.95;
            x = new neuron[nr_unitati_intrare];
            y = new neuron(0);
            h = new neuron[hidden_neurons];
            x[0] = new neuron(hidden_neurons);
            x[1] = new neuron(hidden_neurons);
            double E;
            for (int i = 0; i < hidden_neurons; i++)
            {
                h[i] = new neuron(1);
            }

            int k = 0;

            double E_epoca = 0;
            int epoca = 0;
            if (onlineRadio.Checked == true)
            {
                do
                {
                    errorLabel.Text = $"Eroare: {E_epoca}\nEpoca: {epoca}";
                    errorLabel.Update();
                    epoca++;
                    E_epoca = 0;
                    for (k = 0; k < nr_exemple; k++)
                    {
                        x[0].Out = dateX1[k] / 300;
                        x[1].Out = dateX2[k] / 300;
                        y.Out = 0;
                        for (int a = 0; a < hidden_neurons; a++)
                        {
                            h[a].Out = 0;
                            for (int i = 0; i < nr_unitati_intrare; i++)
                            {
                                h[a].Out += x[i].W[a] * x[i].Out + h[a].prag;
                            }
                            h[a].Out = F(h[a].Out);
                            y.Out += h[a].W[0] * h[a].Out + y.prag;
                        }
                        y.Out = F(y.Out);
                        E = Math.Pow((y.Out - (dateY[k])), 2);
                        E_epoca += E;
                        double rez = 2 * (y.Out - dateY[k]) * F_derivat(y.Out);
                        for (int a = 0; a < hidden_neurons; a++)
                        {
                            for (int i = 0; i < nr_unitati_intrare; i++)
                            {
                                x[i].W[a] = x[i].W[a] - (gradient * rez * h[a].W[0] * F_derivat(h[a].Out) * x[i].Out);
                            }
                            h[a].prag -= gradient * (rez) * h[a].W[0] * F_derivat(h[a].Out);
                            h[a].W[0] -= (gradient * rez * h[a].Out);
                        }
                        y.prag -= (gradient * rez);
                    }
                } while (E_epoca > 0.1);
            }

            else if (offlineRadio.Checked == true)
            {

                do
                {
                   // gradient = 1.0;
                    double[,] mediePropietati = new double[hidden_neurons, nr_unitati_intrare + 2];
                    //mediePropietati[neuroni, 
                    double mediePragY = 0;
                   // if (epoca % 200 == 0)
                    //{
                    errorLabel.Text = $"Eroare: {E_epoca}\nEpoca: {epoca}\nGradient: {gradient}";
                        errorLabel.Update();
                    //}
                    errorLabel.Update();
                    epoca++;
                    E_epoca = 0;
                    for (k = 0; k < nr_exemple; k++)
                    {
                        x[0].Out = dateX1[k] / 300;
                        x[1].Out = dateX2[k] / 300;
                        y.Out = 0;
                        for (int a = 0; a < hidden_neurons; a++)
                        {
                            h[a].Out = 0;
                            for (int i = 0; i < nr_unitati_intrare; i++)
                            {
                                h[a].Out += x[i].W[a] * x[i].Out + h[a].prag;
                            }
                            h[a].Out = F(h[a].Out);
                            y.Out += h[a].W[0] * h[a].Out + y.prag;
                        }
                        y.Out = F(y.Out);
                        E = Math.Pow((y.Out - (dateY[k])), 2);
                        E_epoca += E;
                        double rez = 2 * (y.Out - dateY[k]) * F_derivat(y.Out);
                        for (int a = 0; a < hidden_neurons; a++)
                        {
                            for (int i = 0; i < nr_unitati_intrare; i++)
                            {
                                mediePropietati[a, i] += (gradient * rez * h[a].W[0] * F_derivat(h[a].Out) * x[i].Out);
                            }
                            mediePropietati[a, nr_unitati_intrare] += gradient * (rez) * h[a].W[0] * F_derivat(h[a].Out);
                            mediePropietati[a, nr_unitati_intrare + 1] += (gradient * rez * h[a].Out);
                        }
                        mediePragY += (gradient * rez);
                    }

                    for (int a = 0; a < hidden_neurons; a++)
                    {
                        for (int i = 0; i < nr_unitati_intrare; i++)
                        {
                            mediePropietati[a, i] /= nr_exemple;
                            x[i].W[a] -= mediePropietati[a, i];
                        }
                        mediePropietati[a, nr_unitati_intrare] /= nr_exemple;

                        mediePropietati[a, nr_unitati_intrare + 1] /= nr_exemple;
                        h[a].prag -= mediePropietati[a, nr_unitati_intrare];
                        h[a].W[0] -= mediePropietati[a, nr_unitati_intrare + 1] /= nr_exemple;
                    }
                    mediePragY /= nr_exemple;
                    y.prag -= mediePragY;
                   //  if (gradient > 0.2)
                     {
                   // gradient -= 0.0001;
                     }
                } while (E_epoca > 150);
            }


        }
        public double F(double x)
        {
            return 1.0 / (1.0 + Math.Exp(-x));
        }
        public double F_derivat(double x)
        {
            double rez = (x * (1 - x));
            return rez;
        }

     
        private void btn_drawPoints_Click(object sender, EventArgs e)
        {

            dateX1 = new double[nr_exemple];
            dateX2 = new double[nr_exemple];
            dateY = new double[nr_exemple];
            string path = "input.txt";
            string[] lines = File.ReadAllLines(path);
            for (int i = 0; i < lines.Length; i++)
            {
                string[] words = lines[i].Split(' ');
                dateX1[i] = Convert.ToDouble(words[0]);
                dateX2[i] = Convert.ToDouble(words[1]);
                dateY[i] = Convert.ToDouble(words[2]);

            }
                drawPoints(false);


            for(int i = 0; i < dateY.Length; i++)
            {
                if (dateY[i] == 0)
                {
                    dateY[i] = 0.1;
                }
                else if (dateY[i] == 1)
                {
                    dateY[i] = 0.5;
                }
                else dateY[i] = 0.9;
            }





        }

        private void drawPoints(bool all)
        {
            if (!all)
            {
                for(int i = 0; i < nr_exemple; i++)
                {
                    g.FillRectangle((new SolidBrush(colors[Convert.ToInt32(dateY[i])])), Convert.ToInt32(dateX1[i]), Convert.ToInt32(dateX2[i]), 2, 2);

                }
            }
            else
            {
                for(int i = -300; i < 600; i++)
                {
                    for(int j = -300; j < 600; j++)
                    {
                        Color color = getColor(i, j);
                        g.FillRectangle((new SolidBrush(color)), i, j, 2, 2);
                       
                    }
                }
            }
        }

        private void btn_Test_Click(object sender, EventArgs e)
        {
            drawPoints(true);
        }

    

        private Color getColor(double x1, double x2)
        {

            x[0].Out = x1 / 300;


            x[1].Out = x2 / 300;
            y.Out = 0;
            for (int a = 0; a < hidden_neurons; a++)
            {
                h[a].Out = 0;
                for (int i = 0; i < nr_unitati_intrare; i++)
                {
                    h[a].Out += x[i].W[a] * x[i].Out + h[a].prag;
                }
                h[a].Out = F(h[a].Out);
                y.Out += h[a].W[0] * h[a].Out + y.prag;
            }
            // y.Out /= 3;

            

            y.Out = F(y.Out);

            if ((x1 == -280) && (x2 == 100))
            {
                Console.WriteLine(y.Out.ToString());

              }
            if (y.Out < 0.3)
            {
                return colors[0];
            }
            else if (y.Out < 0.7)
            {
                return colors[1];
            }
            else return colors[2];
        }
        private void antrenareBtn_Click(object sender, EventArgs e)
        {
            EtapaAntrenare();
        }
    }

    }

 
