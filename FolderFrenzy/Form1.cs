using System;
using System.Drawing;
using System.IO;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace FolderFrenzy
{
    public partial class Form1 : Form
    {
        private NotifyIcon notifyIcon;
        private FileSystemWatcher watcher;
        public Form1()
        {
            InitializeComponent();


            notifyIcon = new NotifyIcon();
            notifyIcon.Visible = true;
            notifyIcon.Icon = SystemIcons.Information;
            notifyIcon.BalloonTipTitle = "New File/Folder Created";

            watcher = new FileSystemWatcher();
            watcher.Path = "C:\\test"; // replace with your folder path
            watcher.IncludeSubdirectories = true;
            watcher.EnableRaisingEvents = true;
            watcher.Created += OnFileCreated;
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            // Hide the form
            Visible = false;
            ShowInTaskbar = false;

            //this.Hide();
        }

        private void OnFileCreated(object source, FileSystemEventArgs e)
        {
            notifyIcon.BalloonTipText = e.Name + " was created in " + e.FullPath;
            notifyIcon.ShowBalloonTip(1);
        }

        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            notifyIcon.Dispose();
            watcher.Dispose();
        }
    }
}


