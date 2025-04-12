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
    public partial class Join : Form
    {
        private Manager m = Manager.Instance;
        private bool isIdChecked = false;
        private bool isNameChecked = false;
        public Join()
        {
            InitializeComponent();
            button1.Enabled = false;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string id = textBox1.Text;
            string pw = textBox2.Text;
            string name = textBox3.Text;


            if (m.Insert(id,name,pw) == true)
            {
                MessageBox.Show("회원가입이 완료되었습니다.");
                this.DialogResult = DialogResult.OK; // 성공적으로 닫기
                this.Close();
            }
            else
            {
                MessageBox.Show($"회원가입오류");
            }


        }

        private void button2_Click(object sender, EventArgs e)
        {
            string id = textBox1.Text;

            if (string.IsNullOrWhiteSpace(id))
            {
                MessageBox.Show("ID를 입력하세요.");
                return;
            }

            if (m.IdOk(id) == true)
            {
                MessageBox.Show($"{id}는 사용 가능합니다.");
                isIdChecked = true; // ID 중복 확인 성공
                CheckJoinButtonStatus(); // 회원가입 버튼 상태 확인
                textBox1.Enabled = false;
            }
            else
            {
                MessageBox.Show($"{id}는 사용 불가합니다.");
                isIdChecked = false; // 실패 시 상태 초기화
                CheckJoinButtonStatus(); // 회원가입 버튼 상태 확인
            }
        }

        // 이름 중복 확인 버튼 클릭
        private void button3_Click(object sender, EventArgs e)
        {
            string name = textBox3.Text;

            if (string.IsNullOrWhiteSpace(name))
            {
                MessageBox.Show("이름을 입력하세요.");
                return;
            }

            if (m.NameOk(name) == true)
            {
                MessageBox.Show($"{name}는 사용 가능합니다.");
                isNameChecked = true; // 이름 중복 확인 성공
                CheckJoinButtonStatus(); // 회원가입 버튼 상태 확인
                textBox3.Enabled = false;
            }
            else
            {
                MessageBox.Show($"{name}는 사용 불가합니다.");
                isNameChecked = false; // 실패 시 상태 초기화
                CheckJoinButtonStatus(); // 회원가입 버튼 상태 확인
            }
        }

        // 회원가입 버튼 상태 확인 메서드
        private void CheckJoinButtonStatus()
        {
            // ID와 이름 중복 확인이 모두 성공하면 활성화
            button1.Enabled = isIdChecked && isNameChecked;
        }
    }
}
