using System;
using System.Collections.Generic;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace EducationApp.View.Windows
{
    /// <summary>
    /// Логика взаимодействия для AttentionWindow.xaml
    /// </summary>
    public partial class AttentionWindow : Window, IDisposable
    {
        public AttentionWindow(string text)
        {
            InitializeComponent();
            InputText.Text = text;
            this.Owner = Application.Current.MainWindow;
            this.WindowStartupLocation = WindowStartupLocation.CenterOwner;
            this.ShowDialog();
        }
        private bool disposed = false;
        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }
        protected virtual void Dispose(bool disposing)
        {
            if (!disposed)
            {
                if (disposing)
                {
                    // Освобождаем управляемые ресурсы
                }
                // освобождаем неуправляемые объекты
                disposed = true;
            }
        }        
        // destructor
        ~AttentionWindow()
        {
            Dispose(false);
        }

        private void Window_MouseMove(object sender, MouseEventArgs e)
        {
            System.Threading.Thread.Sleep(1000);
            this.Close();
        }
    }
}
