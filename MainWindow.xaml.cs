using System.Windows;
using System.Windows.Input;
using System.Windows.Media.Imaging;

namespace EnaApp
{
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();

            // エナの画像ファイルを読み込む（PNG形式、背景透過）
            var image = new BitmapImage(new System.Uri("ena.png", System.UriKind.Relative));
            EnaImage.Source = image;
        }

        // ウィンドウドラッグの処理
        private void Window_MouseDown(object sender, MouseButtonEventArgs e)
        {
            if (e.ChangedButton == MouseButton.Left)
            {
                DragMove();
            }
        }
    }
}