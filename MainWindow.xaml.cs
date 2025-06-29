using System;
using System.Windows;
using System.Windows.Input;
using System.Windows.Media.Imaging;
using System.Windows.Threading;
using EnaApp.Serif;

namespace EnaApp
{
    public partial class MainWindow : Window
    {
        private SerifManager serifManager = new SerifManager();
        private DispatcherTimer serifTimer = new DispatcherTimer();


        public MainWindow()
        {
            InitializeComponent();

            // エナの画像ファイルを読み込む(ena.pngという名前でソリューションエクスプローラーに保存してある)
            var image = new BitmapImage(new System.Uri("ena.png", System.UriKind.Relative));
            EnaImage.Source = image;
        }


        private void EnaImage_RightClick(object sender, MouseButtonEventArgs e)
        {
            string line = serifManager.GetRandomSerif();
            ShowSerif(line);
        }

        private void ShowSerif(string text)
        {
            SerifText.Text = text;
            SerifText.Visibility = Visibility.Visible;

            serifTimer.Stop();
            serifTimer = new DispatcherTimer();
            serifTimer.Interval = TimeSpan.FromSeconds(3);
            serifTimer.Tick += delegate (object s, EventArgs e)
            {
                SerifText.Visibility = Visibility.Collapsed;
                serifTimer.Stop();
            };
            serifTimer.Start();
        }

        // ドラッグで動くようにする。
        private void Window_MouseDown(object sender, MouseButtonEventArgs e)
        {
            if (e.ChangedButton == MouseButton.Left)//左クリック時の処理
            {
                DragMove();
            }
        }

    }
}