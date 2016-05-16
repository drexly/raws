using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
//using System.Linq;
//using System.Threading.Tasks;
using System.Threading;
using System.Text;
using System.IO;
using System.Windows.Forms;

namespace dbadd
{
    public partial class Learn : Form
    {
        static int j ,inc;
        static string[] textValue = System.IO.File.ReadAllLines(@Directory.GetCurrentDirectory() + "\\temp.log", Encoding.Default);
        static int all = textValue.Length;
        static int []done =new int[all];
        static string[] q = new string[all];
        static string[] a = new string[all];
        static string[] etc = new string[all];
        static string[] h = new string[all];
        static int[] o = new int[4];
        static int current;
        static Queue<int> un = new Queue<int>();
        static Queue<int> did = new Queue<int>();
        public Learn()
        {
            InitializeComponent();
            j =inc = 0;
            for (int i = 0; i < all; i++)
            {
                un.Enqueue(i);
                string[] tarr = textValue[i].Trim().Split('|');
                q[i] = tarr[0];
                a[i] = tarr[1];
                etc[i] = tarr[2];
                h[i] = tarr[3];
            }
            while (un.Count > 0)
            {
                Random ke = new Random();
                int time = ke.Next(10000) % un.Count;
                for (int je = 0; je < time; je++)
                {
                    un.Enqueue(un.Dequeue());
                }
                did.Enqueue(un.Dequeue());
            }
            done=did.ToArray();
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
                            label1.Text = q[done[j]];
                            label2.Text = " ";
                            label4.Text = " ";
                            label5.Text = " ";
                            label6.Text = " ";
                            label3.Text = " ";
                            break;
                        case 1:
                            label1.Text = q[done[j]];
                            o[0]=done[j];
                            o[1]=done[(j+1)%all];
                            o[2]=done[(j+2)%all];
                            o[3]=done[(j+3)%all];
                            Array.Sort(o);
                            label2.Text ="ⓐ"+a[o[0]];
                            label4.Text ="ⓑ"+a[o[1]];
                            label5.Text ="ⓒ"+a[o[2]];
                            label6.Text ="ⓓ"+a[o[3]];
                            
                            label3.Text = " ";
                            break;
                        case 2:
                            label1.Text = q[done[j]];
                            label2.Text ="ⓐ"+a[o[0]];
                            label4.Text ="ⓑ"+a[o[1]];
                            label5.Text ="ⓒ"+a[o[2]];
                            label6.Text ="ⓓ"+a[o[3]];
                            char ans;
                            if (a[o[0]] == a[done[j]])
                                ans = 'ⓐ';
                            else if (a[o[1]] == a[done[j]])
                                ans = 'ⓑ';
                            else if (a[o[2]] == a[done[j]])
                                ans = 'ⓒ';
                            else
                                ans = 'ⓓ';
                            label3.Text = ans+""+a[done[j]] + "\n\n" + etc[done[j]] + "\n\n" + h[done[j]];
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
                 label1.Text = q[done[j]];
                 label2.Text = " ";
                 label4.Text = " ";
                 label5.Text = " ";
                 label6.Text = " ";
                 label3.Text = " ";
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
