using Avalonia.Controls;

namespace PlanerDnia;

public partial class MainWindow : Window
{
    public MainWindow()
    {
        InitializeComponent();
    }

    public class ZadanieButton{
        public string Nazwa{get;set;}
        public string Kategoria{get;set;}
        public bool CzyUkonczone{get;set;}

        ZadanieButton(string nazwa, string kategoria)
        {
            Nazwa = nazwa;
            Kategoria = kategoria;
            CzyUkonczone = false;
        }
        
    }
}