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
    public partial class Form3 : Form
    {
        public Form3()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {//추가
            int count;
            ListViewItem Isvitem;
            if (listView2.Items.Count == 0)
                count = 0;
            else
                count = listView2.Items.Count;

            Isvitem = new ListViewItem(textBox1.Text, count);
            listView2.Items.Add(Isvitem);
            listView2.Items[count].SubItems.Add(comboBox1.SelectedItem.ToString());
            listView2.Items[count].SubItems.Add(textBox2.Text);
            listView2.Items[count].SubItems.Add(textBox3.Text);
            comboBox1.SelectedItem = null;
            textBox1.Clear();
            textBox2.Clear();
            textBox3.Clear();   
        }

        private void button3_Click(object sender, EventArgs e)
        {//수정
            if(listView2.SelectedItems.Count == 0)
            {
                MessageBox.Show("수정할 리스트를 선택해 주세요.");
            }
            else
            {
                listView2.SelectedItems[0].SubItems[0].Text = textBox1.Text;
                listView2.SelectedItems[0].SubItems[1].Text = comboBox1.SelectedItem.ToString();
                listView2.SelectedItems[0].SubItems[2].Text = textBox2.Text;
                listView2.SelectedItems[0].SubItems[3].Text = textBox3.Text;
                comboBox1.SelectedItem = null;
                textBox1.Clear();
                textBox2.Clear();
                textBox3.Clear();
            }
                
        }

        private void button4_Click(object sender, EventArgs e)
        {//삭제
            if (listView2.SelectedItems.Count <= 0)
            {
                MessageBox.Show("선택된 항목이 없음!");
            }
            else
                while (listView2.SelectedItems.Count > 0)
                    listView2.Items.Remove(listView2.SelectedItems[0]);
        }

        private void listView2_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (listView2.SelectedIndices.Count == 0)
            {
                return;
            }
            textBox1.Text = listView2.SelectedItems[0].SubItems[0].Text;
            comboBox1.SelectedItem = listView2.SelectedItems[0].SubItems[1].Text;
            textBox2.Text = listView2.SelectedItems[0].SubItems[2].Text;
            textBox3.Text = listView2.SelectedItems[0].SubItems[3].Text;

        
        }

        private void listView2_Click(object sender, EventArgs e)
        {
            foreach (ListViewItem item in listView2.SelectedItems)
            {
                ListViewItem.ListViewSubItemCollection subItem = item.SubItems;
                label6.Text = "[" + subItem[1].Text + "] " + subItem[0].Text + " 의 일정\n" + "<"+subItem[2].Text + "> " + subItem[3].Text;
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {//완료
            using (StreamWriter sw = new StreamWriter(@".\schedule.txt"))
            {
                foreach (ListViewItem item in listView2.Items)
                {
                    sw.WriteLine(string.Format("{0};{1};{2};{3} ", item.Text, item.SubItems[1].Text, item.SubItems[2].Text, item.SubItems[3].Text));
                }
            }
        }

        private void button5_Click(object sender, EventArgs e)
        {
            Close();
        }

    }
}
