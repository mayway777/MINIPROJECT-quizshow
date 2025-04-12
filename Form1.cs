using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MINIPROJECT
{
    public partial class Form1 : Form
    {
        private Manager m = Manager.Instance;
        public Form1()
        {
            InitializeComponent();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Join join = new Join();
            join.ShowDialog();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string id = textBox1.Text;
            string pw = textBox2.Text;



            if (m.Login(id, pw) == true)
            {
                MessageBox.Show("로그인성공");

                this.DialogResult = DialogResult.OK; // 성공적으로 닫기
               //this.Hide();
                main main1 = new main(id);
               
                main1.ShowDialog(); // 모달 방식으로 창을 띄움
                

            }
            else
            {
                MessageBox.Show("아이디정보가 틀립니다.");
            }
        }
    }
}
