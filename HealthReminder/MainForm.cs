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
        TimeSpan timeleft;
        public String Msg = "Time up!";

        String songPath = "";
        private void MainForm_Load(object sender, EventArgs e)
        {
            loadPlayList();
            songPath = @"playlist\Nếu.wav";
            t = new System.Timers.Timer();
            t.Interval = 1000;
            t.Elapsed += OnTimeEvent;
            
        }

        private void OnTimeEvent(object sender, ElapsedEventArgs e)
        {
            Trace.WriteLine("total second: " + totalSecond);
            if (totalSecond > 0)
            {
                totalSecond--;
                timeleft = TimeSpan.FromSeconds(totalSecond);
                Trace.WriteLine("total second: " + totalSecond);
                timeLabel(timeleft.Hours, timeleft.Minutes, timeleft.Seconds);
            }
            else
            {
                timeLabel(0, 0, 0);
                StartButtonChange();
                t.Stop();
                playSong();
                MessageBox.Show(Msg);
            }
            }

        private void loadPlayList()
        {
            String path = Directory.GetCurrentDirectory() + @"\playlist";
            DirectoryInfo d = new DirectoryInfo(path);
            FileInfo[] Files = d.GetFiles("*.wav");
            List<Song> songs = new List<Song>();

            int num = 0;
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

        private void playSong()
        {
            SystemSounds.Asterisk.Play();
            System.Media.SoundPlayer player = new System.Media.SoundPlayer(songPath);
            player.Play();
        }

        private void pauseSong()
        {
            SystemSounds.Asterisk.Play();
            System.Media.SoundPlayer player = new System.Media.SoundPlayer(songPath);
            player.Play();
        }


        private void timeLabel(int h,int m,int s)
        {
            TimeLabel.Invoke((MethodInvoker)(() => TimeLabel.Text = string.Format("{0:D2}:{1:D2}:{2:D2}", h,m,s)));
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
            setTime(1, 0, 0);
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
            int h = 0, m = 0, s = 0;
            h = (int)numHour.Value;
            m = (int)numMinute.Value;
            s = (int)numSecond.Value;
            setTime(h, m, s);
            TimeLabel.Text = string.Format("{0:D2}:{1:D2}:{2:D2}", h, m, s);
        }

        private void btnExe_Click(object sender, EventArgs e)
        {
            setTime(0, 30, 0);
        }

        private void btnClear_Click(object sender, EventArgs e)
        {
            Msg = "Time up!";
            textBox1.Text = "";
        }

        public void setTime(int h, int m, int s)
        {
            totalSecond = h * 3600 + m * 60 + s;
            Trace.WriteLine("total second: " + totalSecond);
        }


        private void btnSaveMsg_Click(object sender, EventArgs e)
        {
            Msg = textBox1.Text;
        }

        private void btnSongChoose_Click(object sender, EventArgs e)
        {
            songPath = comboBox1.SelectedValue.ToString();
        }
    }
}
