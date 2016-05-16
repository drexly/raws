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
    public partial class Form3 : Form
    {
        static int s = 0;
        static int j = 0;
       
        static int boxind = 0;
        static int[] qs = null;
        static int inc = 0;

        static int all;
        static int ind = 0;
        static int[] done = null;
        static string[] q = null;
        static string[] a = null;
        static string[] etc = null;
        static string[] hint = null;
        static string[] dt = null;
        public Form3()
        {
            InitializeComponent();
            s = j = all =inc= ind=0;
            string[] textValue = System.IO.File.ReadAllLines(@"c:\temp.txt", Encoding.Default);
            
            if (textValue.Length > 0)
            {
                all = textValue.Length;
                done = new int[all];
                for (; ind < all; ind++)
                {
                    Random index = new Random();
                    done[ind] = index.Next(10000) % all;
                    for (int k = 0; k < ind; k++)
                        if (done[k] == done[ind])
                            ind -= 1;
                }
                q = new string[all];
                a = new string[all];
                etc = new string[all];
                dt = new string[all];

                qs = new int[4];
                hint = new string[all];
                for (int i = 0; i < textValue.Length; i++)
                {
                    if (textValue[i].Length == 0)
                    {
                        continue;
                    }
                    if (char.IsUpper(textValue[done[i]][0]))
                    {
                        
                        string[] tarr = textValue[done[i]].Trim().Split('|');

                        q[s] = tarr[0];
                        a[s] = tarr[1];

                        int ke = done[i];
                        for (boxind = 0; boxind < 4; boxind++)
                        {
                            Random boxindex = new Random();
                            qs[boxind] = boxindex.Next(10000) % all;
                            if (ke == qs[boxind])
                            {
                                boxind -= 1;
                                continue;
                            }
                            for (int k = 0; k < boxind; k++)
                                if (qs[k] == qs[boxind])
                                    boxind -= 1;
                        }
                        qs[3] = ke;
                        Array.Sort(qs);
                        string [] h1=textValue[qs[0]].Trim().Split('|');
                        string [] h2=textValue[qs[1]].Trim().Split('|');
                        string [] h3=textValue[qs[2]].Trim().Split('|');
                        string [] h4=textValue[qs[3]].Trim().Split('|');
                        hint[s] = "ⓐ" + h1[1] + "\n\nⓑ" + h2[1] + "\n\nⓒ" + h3[1] + "\n\nⓓ" + h4[1];
                        if (tarr[2].Length > 0)
                            etc[s] = tarr[2];
                        else
                            etc[s] = " ";
                        dt[s] = tarr[3];
                        s++;
                    }
                }
            }
        }

        private void Form2_KeyDown(object sender, KeyEventArgs e)
        {
            string Tex = e.KeyCode.ToString();

            if (j < 0 || j >=all)
            {
                this.Close();
                
                return;
            }
            if (Tex.Equals("F4"))
            {
                if (j > all)
                {
                    
                    this.Close();
                    
                    return;
                }
                else
                {
                    

                    switch (inc % 3)
                    {
                        case 0:
                            label1.Text = q[j];
                            label2.Text = " ";
                            label3.Text = " ";
                            break;
                        case 1:
                            label1.Text = q[j];
                            label2.Text = hint[j];
                            label3.Text = " ";
                            break;
                        case 2:
                            label1.Text = q[j];
                            label2.Text = hint[j][hint[j].IndexOf(a[j])-1] + a[j] + "\n\n" + etc[j];
                            label3.Text = dt[j];
                            if (j <= all)
                            {
                                j++;
                            }
                            break;
                        default:
                            break;
                    }
                    inc++;
                }
                
            }
            else if (Tex.Equals("F3"))
            {
                if (j <0)
                {
                    
                    this.Close();
                    
                    return;
                }
                else
                {
                    
                 j-=1;
                 if (j < 0)
                 {

                     this.Close();
                     
                     return;
                 }
                 label1.Text = q[j];
                 label2.Text = " ";
                 label3.Text = dt[j];
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
            Text = string.Format("RAWS {0}/{1}", j, all);
        }
        
        private void Form3_FormClosed(object sender, FormClosedEventArgs e)
        {
            
        }


    }
}
