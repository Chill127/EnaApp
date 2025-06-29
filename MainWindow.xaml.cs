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

            // エナの画像ファイルを読み込む(ena.pngという名前でソリューションエクスプローラーに保存してある)
            var image = new BitmapImage(new System.Uri("ena.png", System.UriKind.Relative));
            EnaImage.Source = image;
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