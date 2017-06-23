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
using System.Windows.Shapes;
using static System.Console;

namespace migueladanrm.CryptoTool.UI
{
    /// <summary>
    /// Lógica de interacción para Dashboard.xaml
    /// </summary>
    public partial class Dashboard : Window
    {
        public Dashboard()
        {
            InitializeComponent();
        }

        private void tbxInput_TextChanged(object sender, TextChangedEventArgs e)
        {
            tbxOutput.Text = cbxMode.SelectedIndex == 0 ? Encryption.Encrypt(tbxInput.Text, tbxEncryptionKey.Text) : Encryption.Decrypt(tbxInput.Text, tbxEncryptionKey.Text);
        }
    }
}
