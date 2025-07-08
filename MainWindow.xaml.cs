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
        private SerifManager serifManager = new SerifManager();//chatgptより記載
        private DispatcherTimer serifTimer = new DispatcherTimer();//chatgptより記載


        public MainWindow()
        {
            InitializeComponent();

            // エナの画像ファイルを読み込む(ena.pngという名前でソリューションエクスプローラーに保存してある)
            var image = new BitmapImage(new System.Uri("ena.png", System.UriKind.Relative));
            EnaImage.Source = image;
        }


        private void EnaImage_RightClick(object sender, MouseButtonEventArgs e)//右クリックを定義
        {
            string line = serifManager.GetRandomSerif();
            ShowSerif(line);
        }

        private void ShowSerif(string text)//chatgptより記載
        {
            SerifText.Text = text;
            SerifText.Visibility = Visibility.Visible;//SerifTextの表示状態を「見える（Visible）」に設定している。

            serifTimer.Stop();//もしserifTimer（タイマー）が動いていたら、まず止める処理。
            serifTimer = new DispatcherTimer();
            serifTimer.Interval = TimeSpan.FromSeconds(3);//タイマーを三秒に設定
            serifTimer.Tick += delegate (object s, EventArgs e)
            {
                SerifText.Visibility = Visibility.Collapsed;//SerifTextの表示状態を「見えなくなる(Collapsed)」に設定している。
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

        private void Window_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Escape)
            {
                Close(); // アプリを閉じる
            }
        }


    }
}