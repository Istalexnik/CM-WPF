using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows;

using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;

namespace CM_WPF
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        Thread thread;
        List<Environment> envs = Environments.createEnvironments();
        public MainWindow()
        {
            InitializeComponent();
            initialSetUpGUI();
        }

        public void initialSetUpGUI()
        {
            foreach(Environment v in envs)
            {
                cbxSite.Items.Add(v.siteName);             
            }
            cbxSite.SelectedIndex = 0;
        }

        public  void  screenBeforeRunning()
        {
            btnStart.Visibility = Visibility.Visible;
            btnStop.Visibility = Visibility.Hidden;
        }

        public  void screenWhileRunning()
        {
            btnStart.Visibility = Visibility.Hidden;
            btnStop.Visibility = Visibility.Visible;
        }

        public void screenAfterRunning()
        {
            //pop up about claim created TO-DO
            screenBeforeRunning();
        }

        private void btnStart_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                screenWhileRunning();
                thread = new Thread(()=>Base.startCreating(this));
                thread.SetApartmentState(ApartmentState.STA);
                thread.Start();
            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex.Message);
            }
            finally
            {

            }

        }

        private void btnStop_Click(object sender, RoutedEventArgs e)
        {
            thread.Abort();
            screenBeforeRunning();
        }

        private void btnReset_Click(object sender, RoutedEventArgs e)
        {
     //       Base.killChromeProcess();
        }

        private void cbxSite_SelectionChanged(object sender, System.Windows.Controls.SelectionChangedEventArgs e)
        {
            
            foreach (Environment v in envs)
            {
                string currentSite = cbxSite.SelectedItem.ToString();
                if (currentSite == v.siteName)
                {
                    txtZIP.Text = v.zipCode;
                    txtURL.Text = v.siteUrl;
                }
            }
        }
    }
}
