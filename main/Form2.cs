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
    public partial class Form2 : Form
    {
        public Form2()
        {
            InitializeComponent();
        }
        int count;
        int money;
        public String amt;
        private void button1_Click(object sender, EventArgs e)
        {
            //입금
            string amount = textBox3.Text;
                ListViewItem Isvitem;
                if (listView1.Items.Count == 0)
                    count = 0;
                else
                    count = listView1.Items.Count;

                Isvitem = new ListViewItem(button1.Text, count);
                listView1.Items.Add(Isvitem);
                listView1.Items[count].SubItems.Add(textBox1.Text);
                listView1.Items[count].SubItems.Add(textBox2.Text);
                listView1.Items[count].SubItems.Add(textBox3.Text);

                textBox1.Clear();
                textBox2.Clear();
                textBox3.Clear();

            money += Convert.ToInt32(amount);
            label1.Text = String.Format("{0:#,### 원}",money);
        }

        private void button2_Click(object sender, EventArgs e)
        {
            //출금
            string amount2 = textBox3.Text;
            ListViewItem Isvitem;
            if (listView1.Items.Count == 0)
                count = 0;
            else
                count = listView1.Items.Count;

            Isvitem = new ListViewItem(button2.Text, count);
            listView1.Items.Add(Isvitem);
            listView1.Items[count].SubItems.Add(textBox1.Text);
            listView1.Items[count].SubItems.Add(textBox2.Text);
            listView1.Items[count].SubItems.Add(textBox3.Text);
            textBox1.Clear();
            textBox2.Clear();
            textBox3.Clear();

            money -= Convert.ToInt32(amount2);
            label1.Text = String.Format("{0:#,### 원}", money);
        }

        private void button4_Click(object sender, EventArgs e)
        {
         
            //삭제
            if (listView1.SelectedItems.Count <= 0)
            {
                MessageBox.Show("선택된 항목이 없음!");
            }
            else
                while (listView1.SelectedItems.Count > 0)
                {

                    String TextValue1 = listView1.SelectedItems[0].SubItems[0].Text;
                    
                    if (TextValue1 == "입금")
                    {
                        money -= Convert.ToInt32(listView1.SelectedItems[0].SubItems[3].Text);
                        label1.Text = String.Format("{0:#,### 원}", money);
                    }
                        else if(TextValue1 == button2.Text)
                    {
                        money += Convert.ToInt32(listView1.SelectedItems[0].SubItems[3].Text);
                        label1.Text = String.Format("{0:#,### 원}", money);
                    }
                    listView1.Items.Remove(listView1.SelectedItems[0]);
                }                   
            {              
            }
        }
        public void button5_Click(object sender, EventArgs e)
        {
            //확인
            using (StreamWriter sw = new StreamWriter(@".\cash.txt"))
            {
                foreach (ListViewItem item in listView1.Items)
                {
                    sw.WriteLine(string.Format("{0};{1};{2};{3}", item.Text, item.SubItems[1].Text, item.SubItems[2].Text, item.SubItems[3].Text));
                }
                amt = label1.Text;
            }
        }
        private void button6_Click(object sender, EventArgs e)
        {
            //취소
            Close();
        }

        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void Form2_Load(object sender, EventArgs e)
        {

        }

    }
}
