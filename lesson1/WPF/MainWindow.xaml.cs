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
using System.Threading;

namespace lesson1
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        static int sleepTime;

        readonly int fiboN = 40;

        readonly int startfiboN = 2;

        private object lockObjectOne = new object();

        public MainWindow()
        {
            InitializeComponent();

            sleepTime = Convert.ToInt32(slider.Value);

            textBoxSlider.Text = (Convert.ToInt32(slider.Value)).ToString();
            
            Thread thread = new Thread(new ThreadStart(() => printFibo(textBox, fiboN)));

            thread.Start();

            Thread.Sleep(sleepTime);

            /*Метод Abort устарел и не поддерживается данной платформой*/
            //thread.Abort();

        }

        public void printFibo(TextBox textBox, int fiboN)
        {
            lock (lockObjectOne)
            {
                if (textBox != null)
                {
                    try
                    {
                        
                        for (int i = startfiboN; i <= fiboN; i++)
                        {
                            Application.Current.Dispatcher.BeginInvoke(DispatcherPriority.Background, new Action(() =>
                            {
                                sleepTime = Convert.ToInt32(slider.Value);

                                textBox.Text += String.Concat(Fibo.fib(i).ToString(), "  ");

                            }));

                            Thread.Sleep(Convert.ToInt32(sleepTime));

                        }

                    }
                    catch (ThreadAbortException e)
                    {

                        Console.WriteLine("Caught ThreadAbortException and reset");

                        Console.WriteLine("Ex message: {0}", e.Message);

                        Thread.ResetAbort();
                    }
                           
                }
            }
        
        }

        private void Slider_ValueChanged(object sender, RoutedPropertyChangedEventArgs<double> e)
        {
            if (textBoxSlider != null)
            {
                textBoxSlider.Text = (Convert.ToInt32(((Slider)sender).Value)).ToString();

            }

        }

    }
}
