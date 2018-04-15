using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Windows.Threading;
using WindowsInput;

namespace wpfAutoTyper
{
    /// <summary>
    /// MainWindow.xaml の相互作用ロジック
    /// </summary>
    public partial class MainWindow : Window
    {
        private DispatcherTimer _dispacherTimer;

        public MainWindow()
        {
            InitializeComponent();

            _dispacherTimer = new DispatcherTimer(DispatcherPriority.Normal);
            _dispacherTimer.Tick += new EventHandler(dispacherTimer_Tick);
        }

        private void btnExecute_Click(object sender, RoutedEventArgs e)
        {
            int hour = 0, minutes = 0, seconds = 0;
            try
            {
                hour = Convert.ToInt32(txtIntervalHours.Text);
                minutes = Convert.ToInt32(txtIntervalMinutes.Text);
                seconds = Convert.ToInt32(txtIntervalSeconds.Text);
            }
            catch (Exception exception)
            {

            }
            _dispacherTimer.Interval = new TimeSpan(hour, minutes, seconds);
            _dispacherTimer.Start();
            this.Title = "実行中";
        }

        void dispacherTimer_Tick(object sender, EventArgs e)
        {
            InputSimulator input = new InputSimulator();
            input.Keyboard.KeyPress(WindowsInput.Native.VirtualKeyCode.F10);
            this.Title = "F10 Timer";

            //this.Close();
        }
    }
}
