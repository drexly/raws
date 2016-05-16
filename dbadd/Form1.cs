using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
//using System.Linq;
//using System.Threading.Tasks;
using System.Threading;
using System.Text;

using System.Windows.Forms;
using System.IO;
using System.Collections;
namespace dbadd
{
    public partial class RAWS : Form
    {

        static FileStream fs;
        static StreamWriter sw;
        static int inc = 0;
        static int all=0;
        static int che = 0;
        static string thing = null;
        static string path = @Directory.GetCurrentDirectory()+"\\note.log";
        public RAWS()
        {
            InitializeComponent();
            textBox1.Enabled = true;          
            textBox2.Enabled = false;
            textBox3.Enabled = false;
            listView1.AllowDrop = true;
            this.StartPosition = FormStartPosition.Manual;
            this.Location = new Point(1024, 768);
            this.Size = new Size(438, 65);
            //this.Show();
        }

        private void Form1_KeyDown(object sender, KeyEventArgs e)
        {
            string Tex = e.KeyCode.ToString();
            
            if (Tex.Equals("F1"))
            {
                Opacity+=0.1;
            }
            else if (Tex.Equals("F2"))
            {
                Opacity-=0.1;
            }
            else if (Tex.Equals("F5"))
            {
                inc = 2;
                textBox1.Clear();
                textBox2.Clear();
                textBox3.Clear();
                thing = null;
                textBox1.Enabled = false;
                textBox2.Enabled = false;
                textBox3.Enabled = false;
            }
            else if (Tex.Equals("Return"))
            {
                
                inc++;
                textBox1.ImeMode=ImeMode.Alpha;
                textBox2.ImeMode = ImeMode.Hangul;
                textBox3.ImeMode = ImeMode.Alpha;
                switch (inc%3)
                {
                    case 0:
                        if (textBox1.Text.Length > 0 && textBox2.Text.Length > 0)
                        {
                             bool exist = false;
                             if (textBox3.Text.Length>0)
                             {
                                 thing += (textBox3.Text);
                             }
                             fs = new FileStream(path, FileMode.Append, FileAccess.Write);
                             sw = new StreamWriter(fs, System.Text.Encoding.Default);
                             foreach (ListViewItem ch in listView1.Items)
                             {
                                 if (ch.Text==textBox1.Text)
	                             {
                                    exist = true;
                                     ch.Checked = true;
                                     MessageBox.Show(ch.Text+" already exist");
                                     break;
	                             }
                             }
                             if (char.IsUpper(thing[0])&&!exist)
                             {
                                 thing += ("|" + DateTime.Now.ToString());
                                 sw.WriteLine(thing);
                                 string[] tarr = thing.Trim().Split('|');
                                 ListViewItem item = new ListViewItem();
                                 item.Text = tarr[0];
                                 item.SubItems.Add(tarr[1]);
                                 if (tarr[2].Length > 0)
                                     item.SubItems.Add(tarr[2]);
                                 else
                                     item.SubItems.Add(" ");
                                 item.SubItems.Add(tarr[3]);
                                // monthCalendar1.AddAnnuallyBoldedDate(Convert.ToDateTime(tarr[3].ToString()));
                                 listView1.Items.Add(item);
                                 Text = string.Format("RAWS-입력은 엔터 {0}", listView1.Items.Count);
                             }
                             thing = null;
                             textBox1.Clear();
                             textBox2.Clear();
                             textBox3.Clear();
                             sw.Flush();
                             sw.Close();
                             fs.Close();
                        }
                                              
                        textBox1.Enabled = true;
                        textBox1.Focus();
                        textBox2.Enabled = false;
                        textBox3.Enabled = false;
                        //button3_Click(sender, e);
     
                        break;
                    case 1:
                        thing = null;
                        thing += (textBox1.Text+"|");
                        textBox1.Enabled = false;
                        textBox2.Enabled = true;
                        textBox2.Focus();
                        textBox3.Enabled = false;
                        break;
                    case 2:
                        thing += (textBox2.Text+"|");
                        textBox1.Enabled = false;
                        textBox2.Enabled = false;
                        textBox3.Enabled = true;
                        textBox3.Focus();
                        break;
                    default:
                        break;
                }
            }
        }
        private void Form1_FormClosed(object sender, FormClosedEventArgs e)
        {
            
        }

        private void button1_Click(object sender, EventArgs e)
        {
            foreach (ListViewItem ch in listView1.Items)
            {
                if (ch.Checked)
                {
                    listView1.Items.Remove(ch);
                }
            }
        }
        private void Form1_Load(object sender, EventArgs e)
        {
            listView1.CheckBoxes = true;
            
         
            button3_Click(sender, e);
        
            
        }

        private void button3_Click(object sender, EventArgs e)//Refresh
        {
            listView1.Items.Clear();
            //fs = new FileStream(path, FileMode.Append, FileAccess.Write);
            //fs.Close();
            string[] textValue = System.IO.File.ReadAllLines(path, Encoding.Default);
            numericUpDown1.Maximum = textValue.Length;
            if (textValue.Length > 0)
            {
                for (int i = 0; i < textValue.Length; i++)
                {
                    if (textValue[i].Length == 0)
                    {
                        continue;
                    }
                    if (char.IsUpper(textValue[i][0]))
                    {
                        string[] tarr = textValue[i].Trim().Split('|');
                        ListViewItem item = new ListViewItem();
                        item.Text = tarr[0];
                        item.SubItems.Add(tarr[1]);
                        if (tarr[2].Length>0)
                            item.SubItems.Add(tarr[2]);
                        else
                            item.SubItems.Add(" ");
                        item.SubItems.Add(tarr[3]);
                        //monthCalendar1.AddAnnuallyBoldedDate(Convert.ToDateTime(tarr[3].ToString()));
                            listView1.Items.Add(item);
                        
                    }

                }
            }
             Text = string.Format("RAWS-입력은 엔터 {0}",listView1.Items.Count);

        }

        private void button6_Click(object sender, EventArgs e)
        {
            fs = new FileStream(@Directory.GetCurrentDirectory() + "\\temp.log", FileMode.Create, FileAccess.Write);
            sw = new StreamWriter(fs, System.Text.Encoding.Default);
            foreach (ListViewItem ch in listView1.Items)
            {
                    sw.WriteLine(ch.SubItems[0].Text + "|" + ch.SubItems[1].Text + "|" + ch.SubItems[2].Text + "|" + ch.SubItems[3].Text);
                    sw.Flush();
            }
            sw.Close();
            fs.Close();
            //this.Opacity= 0;            
            Rotate form4 = new Rotate();
            form4.Show();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            all++;
            if (all%2==1)
            {
                foreach (ListViewItem ch in listView1.Items)
                {
                    ch.Checked = true;
                }
                che = listView1.Items.Count;
            }
            else
            {
                foreach (ListViewItem ch in listView1.Items)
                {
                    ch.Checked = false;
                }
                che =0;
            }
        }

        private void button5_Click(object sender, EventArgs e)
        {
            foreach (ListViewItem ch in listView1.Items)
            {
                if (ch.Checked)
                    ch.Checked = false;
                else
                    ch.Checked = true;
            }
        }

        private void listView1_ColumnClick(object sender, ColumnClickEventArgs e)
        {

            if (this.listView1.Sorting==SortOrder.Ascending||this.listView1.Sorting==SortOrder.None)
            {
                this.listView1.ListViewItemSorter = new ListViewItemComparer(e.Column, "desc");
                listView1.Sorting = SortOrder.Descending;
            }
            else
            {
                this.listView1.ListViewItemSorter = new ListViewItemComparer(e.Column, "asc");
                listView1.Sorting = SortOrder.Ascending;
            }
            listView1.Sort();
        }
       
        private void button2_Click(object sender, EventArgs e)
        {
            fs = new FileStream(path, FileMode.Create, FileAccess.Write);
            sw = new StreamWriter(fs, System.Text.Encoding.Default);
            foreach (ListViewItem ch in listView1.Items)
            {
                sw.WriteLine(ch.SubItems[0].Text + "|" + ch.SubItems[1].Text + "|" + ch.SubItems[2].Text+"|" + ch.SubItems[3].Text);
                sw.Flush();
            }

            sw.Close();
            fs.Close();
        }

        private void monthCalendar1_DateSelected(object sender, DateRangeEventArgs e)
        {
            dategotwords();
            richTextBox1.Clear();
            foreach (ListViewItem ch in listView1.Items)
            {
                if (ch.SubItems[3].Text.Contains(monthCalendar1.SelectionStart.ToShortDateString()))
                {
                    richTextBox1.Text += (ch.SubItems[0].Text + " " + ch.SubItems[1].Text + " "+ch.SubItems[2].Text+"\n");
                    ch.Checked = true;
                }
                else
                    ch.Checked = false;
            }
            
        }

        private void monthCalendar1_DateChanged(object sender, DateRangeEventArgs e)
        {
            dategotwords();
        }
        private void dategotwords()
        {
            for (int item = 1; item < DateTime.DaysInMonth(monthCalendar1.SelectionStart.Year, monthCalendar1.SelectionStart.Month)+1; item++)
            {
                foreach (ListViewItem ch in listView1.Items)
                {
                    if (ch.SubItems[3].Text.Substring(8, 2) == item.ToString())
                    {
                        monthCalendar1.AddAnnuallyBoldedDate(Convert.ToDateTime(ch.SubItems[3].Text));
                    }
                }
            }
        }

        private void button7_Click(object sender, EventArgs e)
        {
            fs = new FileStream(@Directory.GetCurrentDirectory() + "\\temp.log", FileMode.Create, FileAccess.Write);
            sw = new StreamWriter(fs, System.Text.Encoding.Default);
            foreach (ListViewItem ch in listView1.Items)
            {
                if (ch.Checked)
                {
                    sw.WriteLine(ch.SubItems[0].Text + "|" + ch.SubItems[1].Text + "|" + ch.SubItems[2].Text + "|" + ch.SubItems[3].Text);
                    sw.Flush();
                }
            }

            sw.Close();
            fs.Close();
            //this.Opacity= 0;            
            Slide form2 = new Slide();
            form2.Show();
            
        }

        private void button8_Click(object sender, EventArgs e)
        {
            fs = new FileStream(@Directory.GetCurrentDirectory() + "\\temp.log", FileMode.Create, FileAccess.Write);
            sw = new StreamWriter(fs, System.Text.Encoding.Default);
            //this.Opacity = 0;
            if ( listView1.CheckedItems.Count>=5)
	        {
                foreach (ListViewItem ch in listView1.Items)
                {
                    if (ch.Checked)
                    {
                        sw.WriteLine(ch.SubItems[0].Text + "|" + ch.SubItems[1].Text + "|" + ch.SubItems[2].Text + "|" + ch.SubItems[3].Text);
                        sw.Flush();
                    }
                }
                sw.Close();
                fs.Close();
                Learn form3 = new Learn();
                form3.Show();    
	        }
            else 
            {
                if (listView1.CheckedItems.Count==0)
                {
                    foreach (ListViewItem ch in listView1.Items)
                    {
                            sw.WriteLine(ch.SubItems[0].Text + "|" + ch.SubItems[1].Text + "|" + ch.SubItems[2].Text + "|" + ch.SubItems[3].Text);
                            sw.Flush();
                    }
                    sw.Close();
                    fs.Close();
                    Learn form3 = new Learn();
                    form3.Show();    
                }
                else
	            {
                    MessageBox.Show(5-listView1.CheckedItems.Count + " more items need to be selected");
                    sw.Close();
                    fs.Close();
            	}
               
            }
        }

        private void button9_Click(object sender, EventArgs e)
        {
            openFileDialog1.InitialDirectory = @"C:\";
            
            openFileDialog1.FilterIndex = 1;
            openFileDialog1.RestoreDirectory = true;
            openFileDialog1.Multiselect = false;
            openFileDialog1.ShowDialog();
            foreach (string strTmp in openFileDialog1.FileNames)
            {
                path = strTmp;
            }
            if (!openFileDialog1.CheckFileExists)
	        {
                fs = new FileStream(@path, FileMode.OpenOrCreate, FileAccess.Write);
                sw = new StreamWriter(fs, System.Text.Encoding.Default);
                sw.Close();
                fs.Close();
	        }
            button3_Click(sender, e);
        }
        private void listView1_DragDrop(object sender, DragEventArgs e)
        {
            if (e.Data.GetDataPresent(DataFormats.FileDrop))
            {
                string[] file = (string[])e.Data.GetData(DataFormats.FileDrop);
                foreach (string str in file)
                {
                    path=str;
                    button3_Click(sender, e);
                }
            }
        }

        private void listView1_DragEnter(object sender, DragEventArgs e)
        {
            if (e.Data.GetDataPresent(DataFormats.FileDrop))
            {
                e.Effect = DragDropEffects.Copy | DragDropEffects.Scroll;
            }
        }


        private void listView1_ItemCheck(object sender, ItemCheckEventArgs e)
        {
            if (e.CurrentValue!=CheckState.Checked)
            {
                che += 1;
            }
            else
            {
                che -= 1;
            }
            Text = string.Format("RAWS-입력은 엔터 {0}/{1}", che, listView1.Items.Count);
        }

        private void listView1_ItemMouseHover(object sender, ListViewItemMouseHoverEventArgs e)
        {
            e.Item.ToolTipText = e.Item.SubItems[0].Text + " " + e.Item.SubItems[1].Text + " " + e.Item.SubItems[2].Text + " " + e.Item.SubItems[3].Text;
        }

        private void Rselect(object sender, EventArgs e)
        {
            foreach (ListViewItem ch in listView1.Items)
            {
                ch.Checked = false;
            }
            che = 0;

            int total = Convert.ToInt16(numericUpDown1.Value) > listView1.Items.Count ? listView1.Items.Count : Convert.ToInt16(numericUpDown1.Value);
            Queue<int> lotto = new Queue<int>();
            for (int ind=0; ind <listView1.Items.Count ; ind++)
            {
                lotto.Enqueue(ind);
            }
            while (total!=0)
            {
                Random ke = new Random();
                int time = ke.Next(10000)%lotto.Count;
                for (int j = 0; j < time; j++)
                {
                    lotto.Enqueue(lotto.Dequeue());
                }
                listView1.Items[lotto.Dequeue()].Checked = true;
                total -= 1;
            }
     


        }

        private void button10_Click(object sender, EventArgs e)
        {
            fs = new FileStream(@Directory.GetCurrentDirectory() + "\\temp.log", FileMode.Create, FileAccess.Write);
            sw = new StreamWriter(fs, System.Text.Encoding.Default);
            //this.Opacity = 0;
            if ( listView1.CheckedItems.Count>=5)
	        {
                foreach (ListViewItem ch in listView1.Items)
                {
                    if (ch.Checked)
                    {
                        sw.WriteLine(ch.SubItems[0].Text + "|" + ch.SubItems[1].Text + "|" + ch.SubItems[2].Text + "|" + ch.SubItems[3].Text);
                        sw.Flush();
                    }
                }
                sw.Close();
                fs.Close();
                Test test = new Test();
                test.Show();    
	        }
            else 
            {
                if (listView1.CheckedItems.Count==0)
                {
                    foreach (ListViewItem ch in listView1.Items)
                    {
                            sw.WriteLine(ch.SubItems[0].Text + "|" + ch.SubItems[1].Text + "|" + ch.SubItems[2].Text + "|" + ch.SubItems[3].Text);
                            sw.Flush();
                    }
                    sw.Close();
                    fs.Close();
                    Test test = new Test();
                     test.Show();    
                }
                else
	            {
                    MessageBox.Show(5-listView1.CheckedItems.Count + " more items need to be selected");
                    sw.Close();
                    fs.Close();
            	}
            }
        }

        private void button11_Click(object sender, EventArgs e)
        {
            fs = new FileStream(@Directory.GetCurrentDirectory() + "\\temp.log", FileMode.Create, FileAccess.Write);
            sw = new StreamWriter(fs, System.Text.Encoding.Default);
            //this.Opacity = 0;
            if ( listView1.CheckedItems.Count>=5)
	        {
                foreach (ListViewItem ch in listView1.Items)
                {
                    if (ch.Checked)
                    {
                        sw.WriteLine(ch.SubItems[0].Text + "|" + ch.SubItems[1].Text + "|" + ch.SubItems[2].Text + "|" + ch.SubItems[3].Text);
                        sw.Flush();
                    }
                }
                sw.Close();
                fs.Close();
                Tss test = new Tss();
                test.Show();    
	        }
            else 
            {
                if (listView1.CheckedItems.Count==0)
                {
                    foreach (ListViewItem ch in listView1.Items)
                    {
                            sw.WriteLine(ch.SubItems[0].Text + "|" + ch.SubItems[1].Text + "|" + ch.SubItems[2].Text + "|" + ch.SubItems[3].Text);
                            sw.Flush();
                    }
                    sw.Close();
                    fs.Close();
                    Tss test = new Tss();
                     test.Show();    
                }
                else
	            {
                    MessageBox.Show(5-listView1.CheckedItems.Count + " more items need to be selected");
                    sw.Close();
                    fs.Close();
            	}
            }
        }
        }

    }
    class ListViewItemComparer : IComparer
    {
        private int col;
        public string sort = "asc";
        public ListViewItemComparer()
        {
            col = 0;
        }
        public ListViewItemComparer(int column, string sort)
        {
            col = column;
            this.sort = sort;
        }
        public int Compare(object x, object y)
        {
            if (sort == "asc")
            {
                if (!Char.IsLetter(((ListViewItem)x).SubItems[col].Text, 0))
                {
                    if (Char.IsWhiteSpace(((ListViewItem)x).SubItems[col].Text, 0))
                        return String.Compare(((ListViewItem)x).SubItems[col].Text, ((ListViewItem)y).SubItems[col].Text);
                    else if (Char.IsNumber(((ListViewItem)x).SubItems[col].Text, 5) && Char.IsNumber(((ListViewItem)y).SubItems[col].Text, 5))
                        return DateTime.Compare(Convert.ToDateTime(((ListViewItem)x).SubItems[col].Text), Convert.ToDateTime(((ListViewItem)y).SubItems[col].Text)); 
                    else
                        return String.Compare(((ListViewItem)x).SubItems[col].Text, ((ListViewItem)y).SubItems[col].Text);
                }
                else
                    return String.Compare(((ListViewItem)x).SubItems[col].Text, ((ListViewItem)y).SubItems[col].Text);
            }
            else
            {
                if (!Char.IsLetter(((ListViewItem)x).SubItems[col].Text, 0))
                {
                    if (Char.IsWhiteSpace(((ListViewItem)x).SubItems[col].Text, 0))
                        return String.Compare(((ListViewItem)y).SubItems[col].Text, ((ListViewItem)x).SubItems[col].Text);
                    else if (Char.IsNumber(((ListViewItem)y).SubItems[col].Text, 5) && Char.IsNumber(((ListViewItem)x).SubItems[col].Text, 5))
                        return DateTime.Compare(Convert.ToDateTime(((ListViewItem)y).SubItems[col].Text), Convert.ToDateTime(((ListViewItem)x).SubItems[col].Text));
                    else
                        return String.Compare(((ListViewItem)y).SubItems[col].Text, ((ListViewItem)x).SubItems[col].Text);
                }
                else
                 return String.Compare(((ListViewItem)y).SubItems[col].Text, ((ListViewItem)x).SubItems[col].Text);
            }
                
        }
    }


