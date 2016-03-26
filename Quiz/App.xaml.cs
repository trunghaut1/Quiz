using Quiz.View;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Threading;

namespace Quiz
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        public App()
        {
            ApplicationInitialize = _applicationInitialize;
        }
        public static new App Current
        {
            get { return Application.Current as App; }
        }
        internal delegate void ApplicationInitializeDelegate(SplashScreenView splashWindow);
        internal ApplicationInitializeDelegate ApplicationInitialize;
        private void _applicationInitialize(SplashScreenView splashWindow)
        {
            // fake workload, but with progress updates.
            /*
            Thread.Sleep(500);
            splashWindow.SetProgress(0.2);

            Thread.Sleep(500);
            splashWindow.SetProgress(0.4);

            Thread.Sleep(500);
            splashWindow.SetProgress(0.6);

            Thread.Sleep(500);
            splashWindow.SetProgress(0.8);

            Thread.Sleep(500);
            splashWindow.SetProgress(1);
            */

            // Create the main window, but on the UI thread.
            Dispatcher.BeginInvoke(DispatcherPriority.Normal, new Action(delegate
            {
                MainWindow = new MainWindow();
                MainWindow.Show();
            }));
        }
    }
}
