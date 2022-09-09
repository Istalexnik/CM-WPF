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
        List<Environment> envs = Environment.createEnvironments();

        public MainWindow()
        {
            InitializeComponent();
            initialSetUpGUI();
        }

        public void initialSetUpGUI()
        {
            cbxSite.Items.Clear();
            cbxClaimType.Items.Clear();

            foreach (Environment v in envs)
            {
                cbxSite.Items.Add(v.siteName);             
            }
            for(int i=0; i < Data._claimTypes.Length; i++)
            {
                cbxClaimType.Items.Add(Data._claimTypes[i]);
            }
            cbxSite.SelectedIndex = 0;
            cbxClaimType.SelectedIndex = 0;

            txtFirstName.Text = Data._FirstName;
            txtLastName.Text = Data._LastName;
            txtDOB.Text = Data._DOB;
            txtEmployer1.Text = Data._Employer1;
            txtEmployer2.Text = Data._Employer2;
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
                assigningFromGUIToData();
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
            Base.killChromeProcess(2);
            initialSetUpGUI();
        }


            private void cbxSite_SelectionChanged(object sender, System.Windows.Controls.SelectionChangedEventArgs e)
        {
            
            foreach (Environment v in envs)
            {
                string currentSite = null;

                if (cbxSite.SelectedItem != null)
                {
                    currentSite = cbxSite.SelectedItem.ToString();
                }

                if (currentSite == v.siteName)
                {
                    txtZIP.Text = v.zipCode;
                    txtURL.Text = v.siteUrl;
                }
            }
        }



        private void cbxClaimType_SelectionChanged(object sender, System.Windows.Controls.SelectionChangedEventArgs e)
        {
            Data._claimType = cbxClaimType.SelectedIndex+1;
 // +1 to the Username nethod To Do
        }


        public void assigningFromGUIToData()
        {
            Data._FirstName = txtFirstName.Text;
            Data._LastName = txtLastName.Text;
            Data._DOB = txtDOB.Text;
            Data._Employer1 = txtEmployer1.Text;
            Data._Employer2 = txtEmployer2.Text;
        }



    }
}
