using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Media;
using System.Text;
using System.Threading.Tasks;
using System.Timers;
using System.Windows.Forms;

namespace HealthReminder
{
    public partial class MainForm : Form
    {
        public MainForm()
        {
            InitializeComponent();

        }

        System.Timers.Timer t;

        int totalSecond;
        int loopSecond;
        int tempSecond;

        TimeSpan timeleft;
        public String Msg = "Time up!";
        public String LoopMsg = "Stand up!";


        private void MainForm_Load(object sender, EventArgs e)
        {
            loadPlayList();
            //songPath = @"playlist\Nếu.wav";
            t = new System.Timers.Timer();
            t.Interval = 1000;
            t.Elapsed += OnTimeEvent;

        }

        private void OnTimeEvent(object sender, ElapsedEventArgs e)
        {
            Trace.WriteLine("total: "+ totalSecond+" loop: "+loopSecond+" temp: "+tempSecond);
            if (totalSecond > 0)
            {
                totalSecond--;
                tempSecond++;
                timeleft = TimeSpan.FromSeconds(totalSecond);
                timeLabel(timeleft.Hours, timeleft.Minutes, timeleft.Seconds);
            }
            else
            {
                timeLabel(0, 0, 0);
                StartButtonChange();
                t.Stop();
                SystemSounds.Asterisk.Play();
                playSong();
                MessageBox.Show(Msg);
            }
            if (loopSecond != 0 && tempSecond == loopSecond)
            {
                tempSecond = 0;
                StartButtonChange();
                SystemSounds.Asterisk.Play();
                playSong();
                MessageBox.Show(LoopMsg);
            }
        }



        private void timeLabel(int h, int m, int s)
        {
            TimeLabel.Invoke((MethodInvoker)(() => TimeLabel.Text = string.Format("{0:D2}:{1:D2}:{2:D2}", h, m, s)));
            if ((h + m + s) == 0)
            {
                TimeLabel.Invoke((MethodInvoker)(() => TimeLabel.ForeColor = Color.DarkRed));
            }
        }

        private void StartButtonChange()
        {
            btnStart.Invoke((MethodInvoker)(() => btnStart.BackColor = Color.ForestGreen));
            btnStart.Invoke((MethodInvoker)(() => btnStart.Text = "Start"));
            btnStart.Invoke((MethodInvoker)(() => btnStart.Click -= btnPause_Click));
            btnStart.Invoke((MethodInvoker)(() => btnStart.Click += new EventHandler(btnStart_Click)));
        }

        private void btnPause_Click(object sender, EventArgs e)
        {
            btnStart.BackColor = Color.ForestGreen;
            btnStart.Text = "Start";
            btnStart.Click -= btnPause_Click;
            btnStart.Click += new EventHandler(btnStart_Click);
            t.Stop();
        }

        private void btnStop_Click(object sender, EventArgs e)
        {
            totalSecond = 0;
        }

        private void btnRelax_Click(object sender, EventArgs e)
        {
            setTime(0, 15, 0);
        }

        private void btnStudy_Click(object sender, EventArgs e)
        {
            setTime(0, 30, 0);
        }

        private void btnStart_Click(object sender, EventArgs e)
        {
            t.Start();
            btnStart.BackColor = Color.YellowGreen;
            btnStart.Text = "Pause";
            btnStart.Click -= btnStart_Click;
            btnStart.Click += new EventHandler(btnPause_Click);
        }

        private void btnSet_Click(object sender, EventArgs e)
        {
            int h = (int)numHour.Value;
            int m = (int)numMinute.Value;
            int s = (int)numSecond.Value;
            int loop = (int)numLoop.Value;
            if(loop == 0)
            {
                setTime(h, m, s);
            }
            else
            {
                setTime(h, m, s,loop);
            }
            
        }

        private void btnExe_Click(object sender, EventArgs e)
        {
            setTime(0, 1, 0, 20);
        }

        private void btnClear_Click(object sender, EventArgs e)
        {
            Msg = "Time up!";
            textBox1.Text = "";
        }

        public void setTime(int h, int m, int s)
        {
            totalSecond = h * 3600 + m * 60 + s;
            t.Start();
            TimeLabel.Text = string.Format("{0:D2}:{1:D2}:{2:D2}", h, m, s);
            t.Stop();
        }

        public void setTime(int h, int m, int s, int loop)
        {
            loopSecond = h * 3600 + m * 60 + s;
            totalSecond = loopSecond * loop;
            t.Start();
        }


        private void btnRemind_Click(object sender, EventArgs e)
        {
            setTime(0, 30, 0, 4);
            Msg = "Stand up and take a walk do something else!";
            LoopMsg = "Stand up and look for 20 seconds at something at least 20 feet away(or 6 meter)";
        }


        private void btnSaveMsg_Click(object sender, EventArgs e)
        {
            Msg = textBox1.Text;
        }



        //Play Song:
        List<Song> songs = new List<Song>();
        String songPath = "";
        int songIndex = -1;

        private void loadPlayList()
        {
            String path = Directory.GetCurrentDirectory() + @"\playlist";
            DirectoryInfo d = new DirectoryInfo(path);
            FileInfo[] Files = d.GetFiles("*.wav");


            songs.Add(new Song { name = "No Song", path = "" });
            foreach (FileInfo file in Files)
            {
                songs.Add(new Song { name = file.Name, path = file.FullName });

                //Trace.WriteLine(file.FullName);
            }
            var bindingSource1 = new BindingSource();
            bindingSource1.DataSource = songs;

            comboBox1.DataSource = bindingSource1.DataSource;

            comboBox1.DisplayMember = "name";
            comboBox1.ValueMember = "path";
        }

        System.Media.SoundPlayer player;

        private void playSong()
        {
            if (!songPath.Equals(""))
            {
                player = new System.Media.SoundPlayer(songPath);
                player.Play();
                if (songIndex < 0)
                {
                    songPlayingLabel.Invoke((MethodInvoker)(() => songPlayingLabel.Text = "[Playing] Default Song"));
                }
                else
                {
                    songPlayingLabel.Invoke((MethodInvoker)(() => songPlayingLabel.Text = "[Playing] " + songs.ElementAt(songIndex).name));
                }
            }
        }

        private void pauseSong()
        {
            player.Stop();
        }

        private void btnSongChoose_Click(object sender, EventArgs e)
        {
            songPath = comboBox1.SelectedValue.ToString();
            songIndex = comboBox1.SelectedIndex;
            if (songIndex != 0)
            {
                songPlayingLabel.Text = "[Pending] " + songs.ElementAt(songIndex).name;
            }
            else
            {
                songPlayingLabel.Text = "[No Song]";
            }
        }

        private void btnStopSong_Click(object sender, EventArgs e)
        {
            player.Stop();
            songPlayingLabel.Text = "[No Song]";
        }

        private void btnPlaySong_Click(object sender, EventArgs e)
        {
            playSong();
        }

    }
}
