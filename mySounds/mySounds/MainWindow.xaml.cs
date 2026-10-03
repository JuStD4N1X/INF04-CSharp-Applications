using System;
using System.IO;
using System.Collections.Generic;
using System.Windows;

namespace mySounds
{
    public partial class MainWindow : Window
    {
        private List<Album> albumList = new List<Album>();
        private int currentIndex = 0;

        public class Album
        {
            public string Artist { get; set; }
            public string AlbumName { get; set; }
            public int SongsNumber { get; set; }
            public int Year { get; set; }
            public long DownloadNumber { get; set; }
        }

        public MainWindow()
        {
            InitializeComponent();
            LoadData("Data.txt");
            DisplayAlbum(currentIndex);
        }

        private void LoadData(string path)
        {
            if (!File.Exists(path)) return;

            string[] lines = File.ReadAllLines(path);

            for (int i = 0; i < lines.Length; i += 6)
            {
                if (i + 4 < lines.Length)
                {
                    Album newAlbum = new Album();

                    newAlbum.Artist = lines[i].Trim();
                    newAlbum.AlbumName = lines[i + 1].Trim();
                    newAlbum.SongsNumber = int.Parse(lines[i + 2].Trim());
                    newAlbum.Year = int.Parse(lines[i + 3].Trim());
                    newAlbum.DownloadNumber = long.Parse(lines[i + 4].Trim());

                    albumList.Add(newAlbum);
                }
            }
        }

        private void DisplayAlbum(int index)
        {
            if (albumList.Count == 0) return;

            Album current = albumList[index];

            lblArtist.Content = current.Artist;
            lblTitle.Content = current.AlbumName;
            lblCount.Content = current.SongsNumber.ToString();
            lblYear.Content = current.Year.ToString();
            lblDownloads.Content = current.DownloadNumber.ToString();
        }

        private void btnPrev_Click(object sender, RoutedEventArgs e)
        {
            if (currentIndex > 0)
            {
                currentIndex--;
            }
            else
            {
                currentIndex = albumList.Count - 1;
            }
            DisplayAlbum(currentIndex);
        }

        private void btnNext_Click(object sender, RoutedEventArgs e)
        {
            if (currentIndex < albumList.Count - 1)
            {
                currentIndex++;
            }
            else
            {
                currentIndex = 0;
            }

            DisplayAlbum(currentIndex);
        }

        private void btnDownload_Click(object sender, RoutedEventArgs e)
        {
            if (albumList.Count == 0) return;
            Album current = albumList[currentIndex];
            current.DownloadNumber++;
            lblDownloads.Content = current.DownloadNumber.ToString();
        }
    }
}