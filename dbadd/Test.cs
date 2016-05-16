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

using System.Collections;

namespace dbadd
{
    public partial class Test : Form
    {
        static string[] textValue = System.IO.File.ReadAllLines(@Directory.GetCurrentDirectory() + "\\temp.log", Encoding.Default);
        static int all = textValue.Length;
        static string[] q = new string[all];
        static string[] a = new string[all];
        static string[] etc = new string[all];
        static string[] h = new string[all];
        static int[] o = new int[4];
        static int current;
        static int inc = 0;
        static int tsize=9;
        static Queue<int> lotto = new Queue<int>();
        static FileStream fs;
        static StreamWriter sw;
        public Test()
        {
            InitializeComponent();
            radioButton1.Checked = radioButton2.Checked=radioButton3.Checked =radioButton4.Checked =false;
            for (int i = 0; i <all ; i++)
            {
                lotto.Enqueue(i);
                string[] tarr = textValue[i].Trim().Split('|');
                q[i] = tarr[0];
                a[i] = tarr[1];
                etc[i] = tarr[2];
                h[i] = tarr[3];
            }
     
        }

        private void Test_KeyDown(object sender, KeyEventArgs e)
        {
           
            string Tex = e.KeyCode.ToString();
            if (Tex.Equals("Oemplus"))
            {
                tsize++;
                label2.Font = new Font("굴림", tsize);

            }
            else if (Tex.Equals("OemMinus"))
            {
                tsize--;
                label2.Font = new Font("굴림", tsize);
            }
            else if (Tex.Equals("Return"))
            {
                inc++;
 
                    if (inc%2==0&&(radioButton1.Checked || radioButton2.Checked || radioButton3.Checked || radioButton4.Checked))
                    {
                        if (radioButton1.Checked)
                        {
                            if (string.Equals(radioButton1.Text, a[current]))
                            {
                                label2.Text = "[O] 맞았습니다 " + q[current] + "\n\n" + a[current] + "\n\n" + etc[current] + "\n\n" + h[current];
                            }
                            else
                            {
                                label2.Text = "[X] 틀렸습니다  답은 " + "'" + a[current] + "'" + "\n\n" + etc[current] + "\n\n" + h[current] + " \n 오답노트에 추가되었습니다";
                                wrong();
                            }
                        }
                        else if (radioButton2.Checked)
                        {
                            if (string.Equals(radioButton2.Text, a[current]))
                            {
                                label2.Text = "[O] 맞았습니다 " + q[current] + "\n\n" + a[current] + "\n\n" + etc[current] + "\n\n" + h[current];
                            }
                            else
                            {
                                label2.Text = "[X] 틀렸습니다  답은 " + "'" + a[current] + "'" + "\n\n" + etc[current] + "\n\n" + h[current] + " \n 오답노트에 추가되었습니다";
                                wrong();
                            }
                        }
                        else if (radioButton3.Checked)
                        {
                            if (string.Equals(radioButton3.Text, a[current]))
                            {
                                label2.Text = "[O] 맞았습니다 " + q[current] + "\n\n" + a[current] + "\n\n" + etc[current] + "\n\n" + h[current];
                            }
                            else
                            {
                                label2.Text = "[X] 틀렸습니다  답은 " + "'" + a[current] + "'" + "\n\n" + etc[current] + "\n\n" + h[current] + " \n 오답노트에 추가되었습니다";
                                wrong();
                            }
                        }
                        else
                        {
                            if (string.Equals(radioButton4.Text, a[current]))
                            {
                                label2.Text = "[O] 맞았습니다 " + q[current] + "\n\n" + a[current] + "\n\n" + etc[current] + "\n\n" + h[current];
                            }
                            else
                            {
                                label2.Text = "[X] 틀렸습니다  답은 " + "'" + a[current] + "'" + "\n\n" + etc[current] + "\n\n" + h[current] + " \n 오답노트에 추가되었습니다";
                                wrong();
                            }

                        }
                       
                    }
                    else if(inc%2==1)
                    {
                        if (lotto.Count ==0)
                        {
                            this.Close();

                            return;
                        }
                        radioButton1.Checked = radioButton2.Checked = radioButton3.Checked = radioButton4.Checked = false;
                        label2.Text = "";
                        Random ke = new Random();
                        int time = ke.Next(10000) % lotto.Count;
                        for (int j = 0; j < time; j++)
                        {
                            lotto.Enqueue(lotto.Dequeue());
                        }
                        current = lotto.Dequeue();
                        o[3] = current;
                        for (int l = 0; l < 3; l++)
                        {
                            Random other = new Random();
                            o[l] = other.Next(10000) % all;
                            if (o[l] == current)
                            {
                                l -= 1;
                                continue;
                            }
                            for (int m = 0; m < l; m++)
                            {
                                if (o[m] == o[l])
                                {
                                    l -= 1;
                                    break;
                                }
                            }
                        }
                        Array.Sort(o);
                        label1.Text = q[current];
                        radioButton1.Text = a[o[0]];
                        radioButton2.Text = a[o[1]];
                        radioButton3.Text = a[o[2]];
                        radioButton4.Text = a[o[3]];
                        Text = string.Format("RAWS {0}/{1}/{2}", all - lotto.Count, lotto.Count, all);
                    }
                    
                }
            
            else if (Tex.Equals("D1"))
            {
                if (radioButton1.Checked)
                {
                    radioButton1.Checked = false;
                }
                else
                {
                    radioButton1.Checked = true;
                }
            }
            else if (Tex.Equals("D2"))
            {
                if (radioButton2.Checked)
                {
                    radioButton2.Checked = false;
                }
                else
                {
                    radioButton2.Checked = true;
                }
            }
            else if (Tex.Equals("D3"))
            {
                if (radioButton3.Checked)
                {
                    radioButton3.Checked = false;
                }
                else
                {
                    radioButton3.Checked = true;
                }
            }
            else if (Tex.Equals("D4"))
            {
                if (radioButton4.Checked)
                {
                    radioButton4.Checked = false;
                }
                else
                {
                    radioButton4.Checked = true;
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
        static void wrong()
        {
            fs = new FileStream(@Directory.GetCurrentDirectory() + "\\wrong.log", FileMode.Append, FileAccess.Write);
            sw = new StreamWriter(fs, System.Text.Encoding.Default);
            sw.WriteLine(q[current] + "|" + a[current] + "|" + etc[current] + "|" + DateTime.Now.ToString());
            sw.Flush();
            sw.Close();
            fs.Close();
                      
        }

    }
}

