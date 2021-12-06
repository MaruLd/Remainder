using NAudio;
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
        System.Timers.Timer m;

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
            m = new System.Timers.Timer();
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
            TimeLabel.Text = string.Format("{0:D2}:{1:D2}:{2:D2}", h, m, s);
            isCountdown = true;
            t.Start();
        }

        public void setTime(int h, int m, int s, int loop)
        {
            loopSecond = h * 3600 + m * 60 + s;
            totalSecond = loopSecond * loop;
            isCountdown = true;
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



        //Play Song:--------------------------------------------------------------
 
        IWavePlayer player = new WaveOut();
        static List<Song> songs = new List<Song>();
        static LinkedList<Song> songPath = new LinkedList<Song>();
        
        int songIndex = -1;

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



        AudioFileReader progressBarAudio;
        private void playSong()
        {
            
            Trace.WriteLine("PlaySong() invoked--" + "Path: " + songPath.First + " List: "+ songPath.Count);
            if (songPath.Count>0)
            {

               
                Trace.WriteLine("con de " + player.PlaybackState);
                if (!songInited)
                {
                    AudioFileReader audioFileReader = new AudioFileReader(songPath.First.Value.path);
                    progressBarAudio = audioFileReader;
                    progressBar1.Maximum = (int)progressBarAudio.TotalTime.TotalSeconds;
                    Trace.WriteLine("Audio length: " + (int)progressBarAudio.Length);
                    
                    progressBar1.Invoke((MethodInvoker)(() => progressBar1.Step = 1));
                    player.Init(audioFileReader);
                    player.Volume = (float)0.1;
                    songInited = true;
                    play();
                    listBox1.Invoke((MethodInvoker)(() => listBox1.Items.RemoveAt(0)));
                }
                else
                {
                    play();
                    
                }
                btnPlaySong.Invoke((MethodInvoker)(() => btnPlaySong.BackColor = Color.YellowGreen));
                btnPlaySong.Invoke((MethodInvoker)(() => btnPlaySong.Text = "Pause"));
            }
            
        }

        private void play()
        {
            player.Play();
            isPlaying = true;
            songPlayingLabel.Invoke((MethodInvoker)(() => songPlayingLabel.Text = "[Playing] " + songPath.First.Value.name));

        }

        int num = 1;
        private void SetPlayList()
        {
            
            if (songPath.Count>0)
            {
                listBox1.Items.Add((num++) + "- " + songPath.Last.Value.name);
                listBox1.DisplayMember = "name";
                listBox1.SelectedIndex = 0;
            }
        }

        private void btnStopSong_Click(object sender, EventArgs e)
        {
            btnPlaySong.BackColor = Color.ForestGreen;
            btnPlaySong.Text = "Play";
            songPlayingLabel.Text = "[No Song]";
            songPath.RemoveFirst();
            player.Stop();
            songInited = false;
            isPlaying = false;
        }

       

        private void btnPlaySong_Click(object sender, EventArgs e)
        {
            if (songPath.Count!=0)
            {
                if (btnPlaySong.Text.Equals("Play"))
                {
                    t.Start();
                    playSong();
                    Trace.WriteLine("Play!!");
                }
                else
                {
                    player.Pause();
                    isPlaying = false;
                    songPlayingLabel.Invoke((MethodInvoker)(() => songPlayingLabel.Text = "[Pause]" + songPath.First.Value.name));
                    btnPlaySong.Invoke((MethodInvoker)(() => btnPlaySong.BackColor = Color.ForestGreen));
                    btnPlaySong.Invoke((MethodInvoker)(() => btnPlaySong.Text = "Play"));
                    Trace.WriteLine("Pause!!");
                }
            }
            
        }



        TimeSpan progressBar;
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

            if (songPath.Count > 0 && isPlaying)
            {
                playSong();
               
            }
            if (player.PlaybackState.ToString().Equals("Stopped") && isPlaying)
            {
                
                if (songPath.Count == 1)
                {
                    player.Stop();
                    btnPlaySong.Invoke((MethodInvoker)(() => btnPlaySong.BackColor = Color.ForestGreen));
                    btnPlaySong.Invoke((MethodInvoker)(() => btnPlaySong.Text = "Start"));
                    songPlayingLabel.Invoke((MethodInvoker)(() => songPlayingLabel.Text = "[No Song]"));
                }
                else
                {
                    listBox1.Invoke((MethodInvoker)(() => listBox1.Items.RemoveAt(0)));
                    songPath.RemoveFirst();
                    songInited = false;
                }
                Trace.WriteLine("Song stopped run out of length");
            }
            if(player.PlaybackState.ToString().Equals("Playing") && isPlaying)
            {
                progressBar = progressBarAudio.CurrentTime;
                progressBar1.Invoke((MethodInvoker)(() => progressBar1.Value = (int)progressBar.TotalSeconds));
            }
            if(!isCountdown && !isPlaying)
            {
                t.Stop();
            }

        }

        private void btnSongChoose_Click(object sender, EventArgs e)
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
            SetPlayList();
            Trace.WriteLine("Combox Commited song: " + songs.ElementAt(songIndex).name + " Songpath count: " + songPath.Count + " songindex" + songIndex);

        }

        private void btnRemove_Click(object sender, EventArgs e)
        {
            if (songPath.Count>0 && listBox1.SelectedIndex>-1) {
                songPath.Remove(songPath.ElementAt(listBox1.SelectedIndex));
                listBox1.Items.RemoveAt(listBox1.SelectedIndex);
            }
            if (listBox1.Items.Count==0)
            {
                num = 1;
            }
            else
            {
                listBox1.SelectedIndex = 0;
            }
            Trace.WriteLine("Songpath count: " + songPath.Count);
        }
    }

}

