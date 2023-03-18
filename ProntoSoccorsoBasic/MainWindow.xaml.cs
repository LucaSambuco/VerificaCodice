using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Remoting.Contexts;
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

namespace ProntoSoccorsoBasic
{
    /// <summary>
    /// Logica di interazione per MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            coda = new List<Paziente>();
        }
        Paziente paziente;
        List<Paziente> coda;

        private void btnEliminaAt_Click(object sender, RoutedEventArgs e)
        {
            if (coda.Count != 0)
            {
                foreach (Paziente paz in coda)
                {
                    if (paz.Codice_Fiscale == txtCodFisc.Text)
                    {
                        paziente = paz;
                    }
                }
                if (paziente.Codice_Urgenza == "rosso")
                {
                    string message = "ATTENZIONE !IL PAZIENTE SI TROVA IN UNA SITUAZIONE DI SALUTE MOLTO GRAVE IN CODICE ROSSO, " +
                        "HA BISOGNO DI CURE IMMEDIATE.E' VIVAMENTE SCONSIGLIABILE DIMETTERLO ED ELIMINARLO DALLA LISTA,E' SICURO DI PROCEDERE CON LE DIMISSIONI?";

                    var result = MessageBox.Show(message, "", MessageBoxButton.YesNo);

                    if (result == MessageBoxResult.Yes)
                    {
                        MessageBox.Show(paziente.Stampa());
                        coda.Remove(paziente);
                    }
                }
                else
                {
                    MessageBox.Show(paziente.Stampa());
                    coda.Remove(paziente);
                }
            }
            else
            {
                MessageBox.Show("Il paziente non è stato trovato.");
            }
        }

        private void btnAggiungi_Click(object sender, RoutedEventArgs e)
        {
            paziente = new Paziente(txtNome.Text, txtCognome.Text, txtCodFisc.Text, txtCodUrgenza.Text);

            if (txtCodUrgenza.Text != "rosso" && txtCodUrgenza.Text != "arancione" && txtCodUrgenza.Text != "azzurro" && txtCodUrgenza.Text != "bianco" && txtCodUrgenza.Text != "verde")
            {
                MessageBox.Show("Codice d'urgenza non corretto!");
            }
            else
            {
                int cont = 0;
                if (paziente.Codice_Urgenza == "bianco")
                {
                    coda.Add(paziente);
                }
                else if (paziente.Codice_Urgenza == "rosso")
                {
                    foreach (Paziente pa in coda)
                    {
                        if (pa.Codice_Urgenza == "rosso")
                        {
                            cont++;
                        }
                        else { break; }
                    }
                    coda.Insert(cont, paziente);
                }
                else if (paziente.Codice_Urgenza == "arancione")
                {
                    foreach (Paziente pa in coda)
                    {
                        if (pa.Codice_Urgenza == "rosso" || pa.Codice_Urgenza == "arancione")
                        {
                            cont++;
                        }
                        else { break; }
                    }
                    coda.Insert(cont, paziente);
                }
                else if (paziente.Codice_Urgenza == "azzurro")
                {
                    foreach (Paziente pa in coda)
                    {
                        if (pa.Codice_Urgenza == "rosso" || pa.Codice_Urgenza == "arancione" || pa.Codice_Urgenza == "azzurro")
                        {
                            cont++;
                        }
                        else { break; }
                    }
                    coda.Insert(cont, paziente);
                }
                else if (paziente.Codice_Urgenza == "verde")
                {
                    foreach (Paziente pa in coda)
                    {
                        if (pa.Codice_Urgenza != "bianco")
                        {
                            cont++;
                        }
                        else { break; }
                    }
                    coda.Insert(cont, paziente);
                }
            }
        }

        private void btnStampa_Click(object sender, RoutedEventArgs e)
        {
            string result = "";
            foreach (Paziente p in coda)
            {
                result += p.Stampa() + "\n";
            }
            MessageBox.Show(result);
        }

        private void btnElimina_Click(object sender, RoutedEventArgs e)
        {
            if (coda.Count != 0)
            {
                paziente = coda[0];
                if (paziente.Codice_Urgenza == "rosso")
                {
                    string message = "ATTENZIONE !IL PAZIENTE SI TROVA IN UNA SITUAZIONE DI SALUTE MOLTO GRAVE IN CODICE ROSSO, " +
                        "HA BISOGNO DI CURE IMMEDIATE.E' VIVAMENTE SCONSIGLIABILE DIMETTERLO ED ELIMINARLO DALLA LISTA,E' SICURO DI PROCEDERE CON LE DIMISSIONI?";

                    var result = MessageBox.Show(message, "", MessageBoxButton.YesNo);

                    if (result == MessageBoxResult.Yes)
                    {
                        MessageBox.Show(paziente.Stampa());
                        coda.Remove(paziente);
                    }
                }
                else
                {
                    MessageBox.Show(paziente.Stampa());
                    coda.Remove(paziente);
                }
            }
            else
            {
                MessageBox.Show("Nessun paziente.");
            }
        }
    }
}
