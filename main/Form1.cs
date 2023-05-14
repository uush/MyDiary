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

namespace main
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }


        private void 예산관리ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Form2 cash = new Form2();
            if (cash.ShowDialog() == DialogResult.OK)
            {
                using (StreamReader reader = new StreamReader(@".\cash.txt"))
                {
                    string[] stringLines = reader.ReadToEnd().Replace("\n", "").Split((char)Keys.Enter);

                    foreach (string stringLine in stringLines)
                    {
                        if (stringLine != string.Empty)
                        {
                            string[] stringArray = stringLine.Split(';');

                            ListViewItem item = new ListViewItem(stringArray);
                            item.SubItems.Add(stringArray[0]);
                            item.SubItems.Add(stringArray[1]);
                            item.SubItems.Add(stringArray[2]);
                            item.SubItems.Add(stringArray[3]);
                            listView2.Items.Add(item);
                        }
                    }
                    label3.Text = "총 금액 : " + String.Format("{0:#,###}", cash.amt);
                }

                cash.Dispose();
            }

        }

        private void 메모ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Form4 cash = new Form4();
            if (cash.ShowDialog() == DialogResult.OK)
            {
                string sampleString = null;
                StreamReader sr = new StreamReader(@".\memo.txt");
                while(!sr.EndOfStream)
                {
                    sampleString = sr.ReadLine();
                    if(sampleString == null)
                    {
                        break;
                    }
                    else
                    {
                        string[] words = sampleString.Split(';');
                        textBox2.Text += "[" + words[0] + "]" + Environment.NewLine +words[1] + Environment.NewLine;
                    }
                }

                cash.Dispose();
            }
        }

        private void 일정추가ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Form3 schd = new Form3();

            if (schd.ShowDialog() == DialogResult.OK)
            {
                using (StreamReader reader = new StreamReader(@".\schedule.txt"))
                {
                    string[] stringLines = reader.ReadToEnd().Replace("\n", "").Split((char)Keys.Enter);

                    foreach (string stringLine in stringLines)
                    {
                        if (stringLine != string.Empty)
                        {
                            string[] stringArray = stringLine.Split(';');

                            ListViewItem item = new ListViewItem(stringArray);
                            item.SubItems.Add(stringArray[0]);
                            item.SubItems.Add(stringArray[1]);
                            item.SubItems.Add(stringArray[2]);
                            item.SubItems.Add(stringArray[3]);

                            listView1.Items.Add(item);
                        }
                    }

                }
            }
            schd.Dispose();
        }


        private void comboBox1_SelectedIndexChanged_1(object sender, EventArgs e)
        {
            String search = comboBox1.SelectedItem.ToString();
            String[] lsv = new string[] { };
            StreamWriter sw = new StreamWriter(@".\search.txt");
            for(int i =0; i<listView1.Items.Count;i++)
            {              
                if (search == listView1.Items[i].SubItems[1].Text)
                {                   
                    sw.WriteLine(string.Format("{0};{1};{2};{3} ", listView1.Items[i].SubItems[0].Text, listView1.Items[i].SubItems[1].Text,
                        listView1.Items[i].SubItems[2].Text, listView1.Items[i].SubItems[3].Text));                  
                }
            }
            sw.Close();
                
            listView1.Items.Clear();
            StreamReader sr = new StreamReader(@".\search.txt");
            string[] stringLines = sr.ReadToEnd().Replace("\n", "").Split((char)Keys.Enter);

            foreach (string stringLine in stringLines)
            {
                if (stringLine != string.Empty)
                {
                    string[] stringArray = stringLine.Split(';');

                    ListViewItem item = new ListViewItem(stringArray);
                    item.SubItems.Add(stringArray[0]);
                    item.SubItems.Add(stringArray[1]);
                    item.SubItems.Add(stringArray[2]);
                    item.SubItems.Add(stringArray[3]);

                    listView1.Items.Add(item);
                }
            }
            sr.Close();
            if (comboBox1.SelectedIndex == 0)
            {
                listView1.Items.Clear();
                using (StreamReader reader = new StreamReader(@".\schedule.txt"))
                {
                    string[] stringLines2 = reader.ReadToEnd().Replace("\n", "").Split((char)Keys.Enter);

                    foreach (string stringLine2 in stringLines2)
                    {
                        if (stringLine2 != string.Empty)
                        {
                            string[] stringArray = stringLine2.Split(';');

                            ListViewItem item = new ListViewItem(stringArray);
                            item.SubItems.Add(stringArray[0]);
                            item.SubItems.Add(stringArray[1]);
                            item.SubItems.Add(stringArray[2]);
                            item.SubItems.Add(stringArray[3]);

                            listView1.Items.Add(item);
                        }
                    }
                }
            }

        }



        private void 실행취소ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}
            
