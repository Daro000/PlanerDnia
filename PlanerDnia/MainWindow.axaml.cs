using System.Collections.ObjectModel;
using System.Threading.Tasks;
using Avalonia.Controls;
using Avalonia.Interactivity;
using System.Linq;

namespace PlanerDnia;

public partial class MainWindow : Window
{
    public ZadanieButton wybraneZadanie;
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
            
            ListaZadanBox.Items.Add(newZadanieButton);
            
            Zadanie.Clear();
            
            RZadania.SelectedIndex = -1;

            Odswiez();
        }
    }
    

    private void ListaZadanBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
    {
        if (ListaZadanBox.SelectedItem != null)
        {
            wybraneZadanie = (ZadanieButton)ListaZadanBox.SelectedItem;
            EdytujZadanie.Text = wybraneZadanie.Nazwa;

           
            foreach (ComboBoxItem item in EdytujKategorie.Items)
            {
                if (item.Content.ToString() == wybraneZadanie.Kategoria)
                {
                    EdytujKategorie.SelectedItem = item;
                    break;
                }
            }
        }
    }
    
  
        
    private void Odswiez()
    {
        int wszystkieZad = ListaZadan.Count;
        int ukonczoneZad = ListaZadan.Count(zadanie => zadanie.CzyUkonczone);
        Podsumowanie.Text = $"Zadania: {wszystkieZad}, Ukończone: {ukonczoneZad}";
    }
    
    }
