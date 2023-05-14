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
    public partial class Form4 : Form
    {
        public Form4()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {//저장
            int count;
            ListViewItem Isvitem;
            if (listView1.Items.Count == 0)
                count = 0;
            else
                count = listView1.Items.Count;

            Isvitem = new ListViewItem(textBox2.Text, count);
            listView1.Items.Add(Isvitem);
            listView1.Items[count].SubItems.Add(textBox1.Text); //2.제목 1.내용
            textBox1.Clear();
            textBox2.Clear();
        }

        private void button2_Click(object sender, EventArgs e)
        {//수정
            if (listView1.SelectedItems.Count == 0)
            {
                MessageBox.Show("수정할 리스트를 선택해 주세요.");
            }
            else
            {
                
                listView1.SelectedItems[0].SubItems[0].Text = textBox2.Text;
                listView1.SelectedItems[0].SubItems[1].Text = textBox1.Text;
                textBox1.Clear();
                textBox2.Clear();

            }
        }

        private void button3_Click(object sender, EventArgs e)
        {//삭제
            if (listView1.SelectedItems.Count <= 0)
            {
                MessageBox.Show("선택된 항목이 없음!");
            }
            else
                while (listView1.SelectedItems.Count > 0)
                    listView1.Items.Remove(listView1.SelectedItems[0]);
            textBox1.Clear();
            textBox2.Clear();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            using (StreamWriter sw = new StreamWriter(@".\memo.txt"))
            {
                foreach (ListViewItem item in listView1.Items)
                {
                    sw.WriteLine(string.Format("{0};{1}", item.Text, item.SubItems[1].Text));
                }
            }

        }

        private void listView1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (listView1.SelectedItems.Count != 0)
            {
                int SelectRow = listView1.SelectedItems[0].Index;

                string a = listView1.Items[SelectRow].SubItems[0].Text;
                string b = listView1.Items[SelectRow].SubItems[1].Text;

                textBox1.Text = b;
                textBox2.Text = a;
            }
        }
    }
}
