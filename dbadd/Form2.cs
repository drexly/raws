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
    public partial class Form2 : Form
    {
        static int s = 0;
        static int j = 0;
        static int all = 0;

        static string[] q = null;
        static string[] a = null;
        static string[] etc = null;
        static string[] dt = null;
        public Form2()
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
                            a[s]=tarr[1];
                            if (tarr[2].Length > 0)
                                etc[s]=tarr[2];
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
                if (j<0||j >=all)
                {
                     this.Close();
                        
                        return;
                }
                if (Tex.Equals("F4"))
                {
                    
                    if (j >=all)
                    {
                        this.Close();
                        
                        return;
                    }
                    else if (j<all)
                    {
                        label3.Text = dt[j];
                        label1.Text = q[j];
                        label2.Text = a[j] + " " + etc[j];
                         j++;
                    }  
                }
                else if (Tex.Equals("F3"))
                {
                    if (j < 0)
                    {
                        this.Close();
                        
                        return;
                    }
                    else if (j >=0)
                    {
                        j--;
                        if (j < 0)
                        {
                            this.Close();

                            return;
                        }
                        else
                        {
                            label3.Text = dt[j];
                            label1.Text = q[j];
                            label2.Text = a[j] + "\n\n" + etc[j];
                        }    
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


            private void Form2_FormClosed(object sender, FormClosedEventArgs e)
            {
                
            }


            }
        }
