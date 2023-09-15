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

namespace WpfTestRationnel
{
    /// <summary>
    /// Logique d'interaction pour MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                TextBoxRationnel.Clear();
                if (TextBoxNumerateur.Text == "" || TextBoxDenominateur.Text == "")
                {
                    MessageBox.Show("Il faut remplir le Numérateur ET le Dénominateur", "Erreur 305", MessageBoxButton.OK, MessageBoxImage.Error);
                }
                int numerateur = Convert.ToInt32(TextBoxNumerateur.Text);
                int denominateur = Convert.ToInt32(TextBoxDenominateur.Text);
                Rationnel.Rationnel rationnel = new Rationnel.Rationnel(numerateur, denominateur);
                Rationnel.Rationnel reduit = Rationnel.Rationnel.Reduit(rationnel);
                TextBoxRationnel.Text = reduit.ToString();
            }
            catch (Exception ex) { MessageBox.Show(ex.Message); }
        }

        private void BoutonValeurDécimale_Click(object sender, RoutedEventArgs e)
        {
            try {
                TextBoxRationnel.Clear();
                if (TextBoxNumerateur.Text == "" || TextBoxDenominateur.Text == "")
                {
                    MessageBox.Show("Il faut remplir le Numérateur ET le Dénominateur", "Erreur 305", MessageBoxButton.OK, MessageBoxImage.Error);
                }
                int numerateur = Convert.ToInt32(TextBoxNumerateur.Text);
                int denominateur = Convert.ToInt32(TextBoxDenominateur.Text);
                Rationnel.Rationnel rationnel = new Rationnel.Rationnel(numerateur, denominateur);
                double mondouble = (double)rationnel;
                TextBoxRationnel.Text = mondouble.ToString();
            }
            catch (Exception ex) { MessageBox.Show(ex.Message); }
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            try
            {
                TextBoxRationnel.Clear();
                if (TextBoxNumerateur.Text == "" || TextBoxDenominateur.Text == "")
                {
                    MessageBox.Show("Il faut remplir le Numérateur ET le Dénominateur", "Erreur 305", MessageBoxButton.OK, MessageBoxImage.Error);
                }
                int numerateur = Convert.ToInt32(TextBoxNumerateur.Text);
                int denominateur = Convert.ToInt32(TextBoxDenominateur.Text);
                Rationnel.Rationnel rationnel = new Rationnel.Rationnel(numerateur, denominateur);
                TextBoxRationnel.Text = rationnel.ToString();
            }
            catch (Exception ex) { MessageBox.Show(ex.Message); }
        }
    }
}
