using NAudio.Wave;
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

namespace Reminder
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
        public Boolean isCountdown = false;

        private void MainForm_Load(object sender, EventArgs e)
        {
            loadPlayList();
            //songPath = @"playlist\Nếu.wav";
            t = new System.Timers.Timer();
            t.Interval = 1000;
            t.Elapsed += OnTimeEvent;
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
            isCountdown = false;
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
            btnStart.BackColor = Color.YellowGreen;
            btnStart.Text = "Pause";
            btnStart.Click -= btnStart_Click;
            btnStart.Click += new EventHandler(btnPause_Click);
            isCountdown = true;
        }

        private void btnSet_Click(object sender, EventArgs e)
        {
            int h = (int)numHour.Value;
            int m = (int)numMinute.Value;
            int s = (int)numSecond.Value;
            int loop = (int)numLoop.Value;
            if (loop == 0)
            {
                setTime(h, m, s);
            }
            else
            {
                setTime(h, m, s, loop);
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
            isCountdown = true;
        }

        public void setTime(int h, int m, int s, int loop)
        {
            loopSecond = h * 3600 + m * 60 + s;
            totalSecond = loopSecond * loop;
            isCountdown = true;
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



        //Play Song:--------------------------------------------------------------

        IWavePlayer player = new WaveOut();
        static List<Song> songs = new List<Song>();
        LinkedList<Song> songPath = new LinkedList<Song>();
        
        int songIndex = -1;
        int playingSongIndex = -1;

        Boolean songInited = false;
        Boolean isPlaying = false;


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

        //WMPLib.WindowsMediaPlayer player = new WMPLib.WindowsMediaPlayer();




        private void playSong()
        {
            Trace.WriteLine("PlaySong() invoked--" + "Path: " + songPath.First + " List: "+ songPath.Count);
            if (songPath.Count>0)
            {
                AudioFileReader audioFileReader = new AudioFileReader(songPath.First.Value.path);
                Trace.WriteLine("con de " + player.PlaybackState);
                if (!songInited)
                {
                    player.Init(audioFileReader);
                    player.Volume = (float)0.05;
                    songInited = true;

                    play();
                    
                }
                else
                {
                    play();
                }


                btnPlaySong.Invoke((MethodInvoker)(() => btnPlaySong.BackColor = Color.YellowGreen));
                btnPlaySong.Invoke((MethodInvoker)(() => btnPlaySong.Text = "Pause"));
                btnPlaySong.Invoke((MethodInvoker)(() => btnPlaySong.Click -= btnPlaySong_Click));
                btnPlaySong.Invoke((MethodInvoker)(() => btnPlaySong.Click += new EventHandler(btnPauseSong_Click)));
            }
        }

        private void play()
        {
            player.Play();
            isPlaying = true;
            songPlayingLabel.Invoke((MethodInvoker)(() => songPlayingLabel.Text = "[Playing] " + songPath.First.Value.name));

        }


        private void btnSongSet_Click(object sender, EventArgs e)
        {

        }

        private void btnStopSong_Click(object sender, EventArgs e)
        {
            player.Stop();
            songInited = false;
            isPlaying = false;
            songPlayingLabel.Text = "[No Song]";
        }

        private void btnPauseSong_Click(object sender, EventArgs e)
        {

            player.Pause();
            isPlaying = false;
            songPlayingLabel.Invoke((MethodInvoker)(() => songPlayingLabel.Text = "[Pause]" + songPath.First.Value.name));
            btnPlaySong.Invoke((MethodInvoker)(() => btnPlaySong.BackColor = Color.ForestGreen));
            btnPlaySong.Invoke((MethodInvoker)(() => btnPlaySong.Text = "Start"));
            btnPlaySong.Invoke((MethodInvoker)(() => btnPlaySong.Click -= btnPauseSong_Click));
            btnPlaySong.Invoke((MethodInvoker)(() => btnPlaySong.Click += new EventHandler(btnPlaySong_Click)));

        }

        private void btnPlaySong_Click(object sender, EventArgs e)
        {
            t.Start();
            playSong();
        }

        private void comboBox1_SelectionChangeCommitted(object sender, EventArgs e)
        {
            songIndex = comboBox1.SelectedIndex;

            if (songIndex == 0)
            {
                songPlayingLabel.Text = "[No Song]";
            }
            else if (songPath.Count > 0)
            {
                songPath.AddLast(songs.ElementAt(songIndex));
                songPlayingLabel.Text = "[Pending] " + songs.ElementAt(songIndex).name;
            }
            else
                {
                    songPath.AddFirst(songs.ElementAt(songIndex));
                    songPlayingLabel.Text = "[Pause] " + songs.ElementAt(songIndex).name;
                }
            Trace.WriteLine("Combox Commited song: " + songs.ElementAt(songIndex).name+" Songpath count: "+songPath.Count+" songindex"+songIndex);
        }

        private void OnTimeEvent(object sender, ElapsedEventArgs e)
        {
            Trace.WriteLine("Playbackstate " + player.PlaybackState);
            Trace.WriteLine("total: " + totalSecond + " loop: " + loopSecond + " temp: " + tempSecond);
            if (isCountdown)
            {
                if (totalSecond > 0)
                {
                    totalSecond--;
                    tempSecond++;
                    timeleft = TimeSpan.FromSeconds(totalSecond);
                    timeLabel(timeleft.Hours, timeleft.Minutes, timeleft.Seconds);
                }
                else if (totalSecond == 0)
                {
                    totalSecond--;
                    timeLabel(0, 0, 0);
                    StartButtonChange();
                    t.Stop();
                    SystemSounds.Asterisk.Play();
                    MessageBox.Show(Msg);
                    if (songPath.Count > 0)
                    {
                        playSong();
                    }
                    isCountdown = false;
                    Trace.WriteLine("T stop here");
                }
                if (loopSecond != 0 && tempSecond == loopSecond)
                {
                    tempSecond = 0;
                    SystemSounds.Asterisk.Play();
                    playSong();
                    MessageBox.Show(LoopMsg);
                }
            }

            // Audio player:

            if (songPath.Count > 0)
            {
                playSong();
            }
            if (player.PlaybackState.ToString().Equals("Stopped") && isPlaying)
            {
                songPath.RemoveFirst();
                if (songPath.Count == 0)
                {
                    player.Stop();
                }
                songInited = false;
                Trace.WriteLine("Song stopped run out of length");
            }
            if(songPath.Count == 0 && !isCountdown)
            {
                t.Stop();
            }

            Trace.WriteLine(songPath.ToString());
        }
    }

}

