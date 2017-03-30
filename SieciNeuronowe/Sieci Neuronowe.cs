using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SieciNeuronowe
{
    public partial class Form1 : Form
    {
       
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            listbox_Obliczenia.Items.Add(DateTime.Now);
            listbox_Obliczenia.Items.Add("");

            Neuron[] Web = new Neuron[3];
            List<string> _items = new List<string>();

            for (int i = 0; i < 3; i++)
                Web[i] = new Neuron(3);

            List<double[]> d = new List<double[]>();
            d.Add(new double[] { 1, -1, -1 });
            d.Add(new double[] { -1, 1, -1 });
            d.Add(new double[] { -1, -1, 1 });

            var x = new List<double[]>();
            x.Add(new double[] { Convert.ToDouble(x11.Text), Convert.ToDouble(x12.Text), Convert.ToDouble(x13.Text) });
            x.Add(new double[] { Convert.ToDouble(x21.Text), Convert.ToDouble(x22.Text), Convert.ToDouble(x23.Text) });
            x.Add(new double[] { Convert.ToDouble(x31.Text), Convert.ToDouble(x32.Text), Convert.ToDouble(x33.Text) });

            Web[0]._weights = new double[] { Convert.ToDouble(w11.Text), Convert.ToDouble(w12.Text), Convert.ToDouble(w13.Text) };
            Web[1]._weights = new double[] { Convert.ToDouble(w21.Text), Convert.ToDouble(w22.Text), Convert.ToDouble(w23.Text) };
            Web[2]._weights = new double[] { Convert.ToDouble(w31.Text), Convert.ToDouble(w32.Text), Convert.ToDouble(w33.Text) };

            int iterations = 1;
            int licznik = 0;
            int step = 0;
            do
            {
                listbox_Obliczenia.Items.Add(String.Format("Iteracja " + iterations));

                for (int i = 0; i < 3; i++)
                {
                    step++;
                    listbox_Obliczenia.Items.Add(String.Format("Krok " + step));


                    for (int j = 0; j < 3; j++)
                    {
                        if (d.ElementAt(i)[j] != Web[j].Sgn(Web[j].Y(x.ElementAt(i))))
                        {
                            listbox_Obliczenia.Items.Add(String.Format("Poprawa wag: "));
                            listbox_Obliczenia.Items.Add(String.Format("Nowe wagi w" + (j + 1)));

                            for (int k = 0; k < 3; k++)
                            {
                                licznik = 0;
                                Web[j]._weights[k] -= x.ElementAt(i)[k];
                                listbox_Obliczenia.Items.Add(String.Format(Web[j]._weights[k] + "," ));

                            }
                        }
                        else
                            licznik++;
                    }
                }
                step = 0;
                iterations++;
                if (licznik >= 3)
                {
                    r11.Text = Web[0]._weights[0].ToString(); r12.Text = Web[0]._weights[1].ToString(); r13.Text = Web[0]._weights[2].ToString();
                    r21.Text = Web[1]._weights[0].ToString(); r22.Text = Web[1]._weights[1].ToString(); r23.Text = Web[1]._weights[2].ToString();
                    r31.Text = Web[2]._weights[0].ToString(); r32.Text = Web[2]._weights[1].ToString(); r33.Text = Web[2]._weights[2].ToString();
                    return;
                }
                listbox_Obliczenia.Items.Add("");

            } while (iterations < 12);

            listbox_Obliczenia.Items.Add(String.Format("Sieć nauczona"));
        }

        private void button2_Click(object sender, EventArgs e)
        {
            x11.Text = "10";
            x12.Text = "2";
            x13.Text = "-1";
            x21.Text = "2";
            x22.Text = "-5";
            x23.Text = "-1";
            x31.Text = "-5";
            x32.Text = "5";
            x33.Text = "-1";

            w11.Text = "1";
            w12.Text = "-2";
            w13.Text = "0";
            w21.Text = "0";
            w22.Text = "-1";
            w23.Text = "2";
            w31.Text = "1";
            w32.Text = "3";
            w33.Text = "-1";
        }

        private void button3_Click(object sender, EventArgs e)
        {
            listbox_Obliczenia.Items.Add("");
            listbox_Obliczenia.Items.Add("Otrzymano nowe wagi:");

            listbox_Obliczenia.Items.Add(String.Format(gb_x1.Text + " = [" + r11.Text + " , " + r12.Text + " , " + r13.Text +"]"));
            listbox_Obliczenia.Items.Add(String.Format(gb_x2.Text + " = [" + r21.Text + " , " + r22.Text + " , " + r23.Text + "]"));
            listbox_Obliczenia.Items.Add(String.Format(gb_x3.Text + " = [" + r31.Text + " , " + r32.Text + " , " + r33.Text + "]"));


            const string sPath = "C:\\wyniki.txt";

            System.IO.StreamWriter SaveFile = new System.IO.StreamWriter(sPath);
            foreach (var item in listbox_Obliczenia.Items)
            {
                SaveFile.WriteLine(item);
            }

            SaveFile.Close();

            MessageBox.Show("Obliczenia Zapisane!");
        }

    }
}

