
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Reflection.Emit;
using System.ServiceModel;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.TaskbarClock;
using MINIPROJECT.ServiceReference2;


namespace MINIPROJECT
{
    public partial class PlayGame : Form, IQuizServiceCallback
    {
        private QuizServiceClient quizServiceClient = null;
        private readonly object playerInfoLock = new object(); // 동기화용 락
        private static List<PlayerInfo> playerInfos = new List<PlayerInfo>(); // 플레이어 정보 저장용 리스트
        private HashSet<string> displayedMessages = new HashSet<string>();
        private System.Windows.Forms.Label[] playerLabels;
        private System.Windows.Forms.TextBox[] playerTextBoxes;
        private Image picImage;
        private string Nick;
        private static int playerNum;

        private List<string> answer = new List<string>();

        public PlayGame(string nick)
        {
            Nick = nick;

            InitializeComponent();
            quizServiceClient = new QuizServiceClient(new InstanceContext(this)); // 이 부분에서 'this'는 IQuizCallback을 구현한 객체여야 함

            playerLabels = new System.Windows.Forms.Label[] { label2, label3, label4, label5 };
            playerTextBoxes = new System.Windows.Forms.TextBox[] { textBox3, textBox4, textBox5, textBox6 };

        }


        public void DisplayPlayerInfo(string playerName, string msg, int score, int index)
        {
            // 채팅 메시지가 이미 출력된 적이 있으면 출력하지 않음
            string message = $"채팅 참여 인원({playerName})";

            // 텍스트박스를 초기화하기 전에 이전 메시지를 삭제
            if (displayedMessages.Contains(message))
            {
                // 중복 메시지가 있으면 텍스트박스에서 해당 메시지를 지우는 로직
                textBox1.Text = textBox1.Text.Replace(message + "\r\n", "");
            }

            // 중복되지 않으면 메시지 추가
            textBox1.AppendText(message + "\r\n");

            // 메시지를 출력된 메시지 목록에 추가 
            displayedMessages.Add(message);

            // 동기화 처리
            lock (playerInfoLock)
            {
                // 플레이어 정보 업데이트 또는 추가
                var existingPlayer = playerInfos.FirstOrDefault(p => p.Index == index);
                if (existingPlayer != null)
                {
                    existingPlayer.Name = playerName;
                    existingPlayer.Score = score;
                    existingPlayer.Message = msg;
                }
                else
                {
                    playerInfos.Add(new PlayerInfo
                    {
                        Name = playerName,
                        Score = score,
                        Index = index,
                        Message = msg
                       
                    });
                    playerNum++;

                    if (playerNum == 1)
                    {
                        quizServiceClient.GameStart();
                    
                         quizServiceClient.GetQuiz();
                    }
                }
            }
        }
        private void UpdatePlayerDisplay()
        {
          
            lock (playerInfoLock) // 동기화 처리
            {
                // 모든 Label과 TextBox를 초기화
                for (int i = 0; i < playerLabels.Length; i++)
                {
                    playerLabels[i].Text = string.Empty;
                    playerTextBoxes[i].Text = string.Empty;
                }

                // playerInfos에 저장된 데이터 기준으로 UI 업데이트
                foreach (var player in playerInfos)
                {
                    if (player.Index >= 0 && player.Index < playerLabels.Length)
                    {
                        // 해당 Index 위치의 Label 및 TextBox 업데이트
                        playerLabels[player.Index].Text = $"{player.Name}";
                      
                    }
                }
            }
        }
        private void UpdatePlayerScores()
        {
            lock (playerInfoLock) // 동기화 처리
            {
                // 모든 TextBox를 초기화 (점수만 업데이트하기 위해 TextBox만 초기화)
                for (int i = 0; i < playerTextBoxes.Length; i++)
                {
                    playerTextBoxes[i].Text = string.Empty;
                }

                // playerInfos에 저장된 데이터 기준으로 UI 업데이트
                foreach (var player in playerInfos)
                {
                    if (player.Index >= 0 && player.Index < playerTextBoxes.Length)
                    {
                        // 해당 Index 위치의 TextBox에 점수 업데이트
                        playerTextBoxes[player.Index].Text = $"{player.Score}";
                    }
                }
            }
        }


        public void Score_Ack(string name, int score)
        {
            lock (playerInfoLock)
            {
                // playerInfos에서 해당 인덱스를 사용하여 플레이어 찾기
                for (int i = 0; i < playerInfos.Count; i++)
                {
                    if (playerInfos[i].Name == name)
                    {
                        playerInfos[i].Score = score; // 점수 업데이트
                        break; // 찾으면 더 이상 반복할 필요 없음
                    }
                }

                //// UI 갱신
                //UpdatePlayerScores(); // 점수만 갱신

                //// 화면 갱신
                //this.Invoke((MethodInvoker)(() =>
                //{
                //    this.Invalidate(); // 필요 시 화면 갱신
                //}));
            }
        }

        protected override void OnPaint(PaintEventArgs e)
        {
            base.OnPaint(e);

            UpdatePlayerDisplay();
            UpdatePlayerScores();


        }

        private void button2_Click(object sender, EventArgs e)
        {
            try
            {
                // 서버와 WCF 서비스 연결
                
                // 사용자 이름 입력
                string playerName = Nick; // 텍스트 박스에서 이름 가져오기
                if (string.IsNullOrEmpty(playerName))
                {
                    MessageBox.Show("플레이어 이름을 입력하세요.", "오류", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                // 서버에 입장 요청
                bool result = quizServiceClient.JoinGame(playerName);

                if (result)
                {
                    textBox1.AppendText($"{playerName} 님이 입장하셨습니다.\r\n");

                  
                       
                   

                    Invalidate();
                  

                }
                else
                {
                    MessageBox.Show("게임 입장에 실패했습니다.", "오류", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            catch (FaultException ex)
            {
                // WCF 서비스 호출에서 발생할 수 있는 FaultException 처리
                MessageBox.Show($"서비스 오류 발생: {ex.Message}", "오류", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            catch (CommunicationException ex)
            {
                // 네트워크 연결이나 서비스와의 통신 오류 처리
                MessageBox.Show($"네트워크 오류 발생: {ex.Message}", "오류", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            catch (Exception ex)
            {
                // 그 외 일반적인 예외 처리
                MessageBox.Show($"서버 연결 중 오류 발생: {ex.Message}\n{ex.StackTrace}", "오류", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private class PlayerInfo
        {
            public string Name { get; set; }
            public int Score { get; set; }
            public string Message { get; set; }
            public int Index { get; set; }
        }

        private void PlayGame_Load(object sender, EventArgs e)
        {
            pictureBox2.Hide();
        }

        public void Say_Ack(string playerName, string msg, int index)
        {
           
            textBox1.AppendText($"[{playerName}]: {msg}\r\n");

        }

        private void button1_Click(object sender, EventArgs e)
        {
            string msg = textBox2.Text;
          
            quizServiceClient.Say(Nick, msg);
            textBox2.Text = "";
            textBox2.Focus();
           

        }

        private void button3_Click(object sender, EventArgs e)
        {
            string a = textBox7.Text;
            textBox7.Focus();
            int score = int.Parse(label10.Text);
            int num = int.Parse(label12.Text);
            textBox7.Clear();
            textBox7.Focus();
            quizServiceClient.IsAnswer(Nick, num, a, score);
          
        }

        public void Start_Ack(string msg)
        {
            label1.Text = msg;
           
        }

        public void Quiz_Ack(string msg, int score, int num)
        {
            pictureBox2.Hide();
            label1.Show();

            label1.Text = msg;
            label10.Text = score.ToString();
            label12.Text = num.ToString();
        }

        private void panel6_Paint(object sender, PaintEventArgs e)
        {

        }

        public void IsAnswer_Ack(string name, string msg, int ok)
        {
            if (ok == 1)
            {
                label6.Text = $"{name}님이 정답을 맞췄습니다!! 정답 : {msg}";

                Task.Delay(2000).ContinueWith(_ =>
                {
                    this.Invoke((Action)(() =>
                    {
                        label6.Text = string.Empty;
                    }));
                });
            }
            else if(ok == 0)
            {
                label6.Text = $"{name}오답임ㅋㅋ{msg}";
                Task.Delay(500).ContinueWith(_ =>
                {
                    this.Invoke((Action)(() =>
                    {
                        label6.Text = string.Empty;
                    }));
                });

            }
        }

        public void GetQuiz_Ack(string msg)
        {
          
            label1.Text = msg;
           
        }

        public void QuizImage_Ack(byte[] bytes, int score, int num)
        {
            label1.Hide();
            pictureBox2.Show();

            picImage = Image.FromStream(new MemoryStream(bytes));

            // PictureBox에 이미지 설정
            pictureBox2.SizeMode = PictureBoxSizeMode.StretchImage;
            pictureBox2.Image = picImage;

            Invalidate();   // 화면을 갱신한다.
            label10.Text = score.ToString();
            label12.Text = num.ToString();
        }
    }

   
}
