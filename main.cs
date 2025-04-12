using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Reflection.Emit;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml.Linq;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

using System.ServiceModel;
using System.Threading;
using System.Reflection;
using MINIPROJECT.ServiceReference2;

namespace MINIPROJECT
{
    public partial class main : Form
    {
        private Manager m = Manager.Instance;

        string Nick;
        public main(string id)
        {
            InitializeComponent();
            string info = m.PlayerInfo(id);
            
            
            string[] parts = info.Split('#');

            // 각 파트 값을 라벨에 할당
            label2.Text = parts[0]; // userName
            label3.Text = parts[1]; // user1rd
            label4.Text = parts[2]; // user2rd
            label5.Text = parts[3]; // user3rd
            Nick = parts[0];
        }

        private void button1_Click(object sender, EventArgs e)
        {

            PlayGame play = new PlayGame(Nick);
           
            play.ShowDialog();

        

        }
      

    }
}
