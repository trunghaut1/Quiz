﻿using System;
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
using System.Windows.Shapes;
using System.Windows.Threading;

namespace Quiz.View
{
    /// <summary>
    /// Interaction logic for SplashScreenView.xaml
    /// </summary>
    public partial class SplashScreenView : Window
    {
        public SplashScreenView()
        {
            InitializeComponent();
            this.Loaded += new RoutedEventHandler(Splash_Loaded);
        }

        void Splash_Loaded(object sender, RoutedEventArgs e)
        {
            IAsyncResult result = null;

            // This is an anonymous delegate that will be called when the initialization has COMPLETED
            AsyncCallback initCompleted = delegate (IAsyncResult ar)
            {
                App.Current.ApplicationInitialize.EndInvoke(result);

                // Ensure we call close on the UI Thread.
                Dispatcher.BeginInvoke(DispatcherPriority.Normal, new Action(delegate { Close(); }));
            };

            // This starts the initialization process on the Application
            result = App.Current.ApplicationInitialize.BeginInvoke(this, initCompleted, null);
        }

        public void SetProgress(double progress)
        {
            // Ensure we update on the UI Thread.
            //Dispatcher.BeginInvoke(DispatcherPriority.Normal, new Action(delegate { progBar.Value = progress; }));
        }
    }
}
