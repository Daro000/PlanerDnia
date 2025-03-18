using System.Collections.ObjectModel;
using System.Threading.Tasks;
using Avalonia.Controls;
using Avalonia.Interactivity;

namespace PlanerDnia;

public partial class MainWindow : Window
{
    public ObservableCollection<ZadanieButton> ListaZadan { get; set; }
    public MainWindow()
    {
        InitializeComponent();
        ListaZadan = new ObservableCollection<ZadanieButton>();
        Stworz.Click += Stworz_button_Click;
    }

    public class ZadanieButton{
        public string Nazwa{get;set;}
        public string Kategoria{get;set;}
        public bool CzyUkonczone{get;set;}

        public ZadanieButton(string nazwa, string kategoria)
        {
            Nazwa = nazwa;
            Kategoria = kategoria;
            CzyUkonczone = false;
        }
        
    }

    private void Stworz_button_Click(object sender, RoutedEventArgs e)
    {
        var valueZadanie = Zadanie.Text;
        var valueprzedmiot = (RZadania.SelectedItem as ComboBoxItem) ?.Content?.ToString() ?? "Nie wybrane";
        
        if (!string.IsNullOrEmpty(valueZadanie) && !string.IsNullOrEmpty(valueprzedmiot))
        {
            ZadanieButton newZadanieButton= new ZadanieButton(valueZadanie, valueprzedmiot);
            ListaZadan.Add(newZadanieButton);
            Zadanie.Clear();
            RZadania.SelectedIndex = -1;

            UpdateSummary();
        }
    }

    }
}