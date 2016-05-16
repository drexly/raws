using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace dbadd
{
    public partial class Form4 : Form
    {

        static int s = 0;
        static int j = 0;
        static int all = 0;
        static bool rand=true;
        static string[] q = null;
        static string[] a = null;
        static string[] etc = null;
        static string[] dt = null;

        public Form4()
        {
            InitializeComponent();
            
            s = j = all = 0;
            string[] textValue = System.IO.File.ReadAllLines(@"c:\temp.txt", Encoding.Default);

            if (textValue.Length > 0)
            {
                all = textValue.Length;
                q = new string[all];
                a = new string[all];
                etc = new string[all];
                dt = new string[all];
                for (int i = 0; i < textValue.Length; i++)
                {
                    if (textValue[i].Length == 0)
                    {
                        continue;
                    }
                    if (char.IsUpper(textValue[i][0]))
                    {

                        string[] tarr = textValue[i].Trim().Split('|');

                        q[s] = tarr[0];
                        a[s] = tarr[1];
                        if (tarr[2].Length > 0)
                            etc[s] = tarr[2];
                        else
                            etc[s] = " ";
                        dt[s] = tarr[3];
                        s++;
                    }
                }
            }
            timer1.Start();       
        }
        private void Form2_KeyDown(object sender, KeyEventArgs e)
        {
            string Tex = e.KeyCode.ToString();
            
            if (Tex.Equals("F4"))
            {
                timer1.Interval += 500;
               
            }
            else if (Tex.Equals("F3"))
            {
                if (timer1.Interval>999)
                {
                    timer1.Interval -= 500;    
                }
                
            }
            else if (Tex.Equals("F5"))
            {
                if (timer1.Enabled)
                {
                    timer1.Enabled = false;
                }
                else
                {
                    timer1.Enabled = true;
                }

            }
            else if (Tex.Equals("F6"))
            {
                if (rand)
                {
                    rand = false;
                }
                else
                {
                    rand = true;
                }

            }
            else if (Tex.Equals("F7"))
            {
                if (rand)
                {
                    Text = string.Format("RAWS {0}/{1}", j, all);
                    label3.Text = dt[j % all];
                    label1.Text = q[j % all];
                    label2.Text = a[j % all] + "\n\n" + etc[j % all];

                    j++;
                }
                else
                {
                    Random boxindex = new Random();
                    int jj = boxindex.Next(1, all + 1) % all;
                    Text = string.Format("RAWS {0}/{1}", jj, all);
                    label3.Text = dt[jj];
                    label1.Text = q[jj];
                    label2.Text = a[jj] + "\n\n" + etc[jj];
                }

            }
            else if (Tex.Equals("F1"))
            {
                Opacity += 0.1;
            }
            else if (Tex.Equals("F2"))
            {
                Opacity -= 0.1;
            }
            
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            
            if (rand)
            {
                Text = string.Format("RAWS {0}/{1}", j, all);
                label3.Text = dt[j % all];
                label1.Text = q[j % all];
                label2.Text = a[j % all] + "\n\n" + etc[j % all];

                j++;
            }
            else
            {
                Random boxindex = new Random();
                int jj=boxindex.Next(1, all + 1)%all;
                Text = string.Format("RAWS {0}/{1}", jj, all);
                label3.Text = dt[jj];
                label1.Text = q[jj];
                label2.Text = a[jj] + "\n\n" + etc[jj];
            }
            
        }
    }
}
