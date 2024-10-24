using DyavolskayaKontora.Model;
using System.ComponentModel;
using System.Net.Http;
using System.Net.Http.Json;
using System.Text;
using System.Text.Json;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Controls.Primitives;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace DyavolskiiKontrol
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window, INotifyPropertyChanged
    {
        public Devil Devil { get; set; }
        public Rack Rack { get; set; }
        public Disposal Disposal { get; set; }

        private Devil devils;
        public Devil Devils
        {
            get => devils;
            set
            {
                devils = value;
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(Devils)));
            }
        }

        private Rack racks;
        public Rack Racks
        {
            get => racks;
            set
            {
                racks = value;
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(Racks)));
            }
        }

        private Disposal disposals;
        public Disposal Disposals
        {
            get => disposals;
            set
            {
                disposals = value;
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(Disposals)));
            }
        }



        HttpClient httpClient = new HttpClient();

        public event PropertyChangedEventHandler? PropertyChanged;

        public MainWindow()
        {
            InitializeComponent();
            httpClient.BaseAddress = new Uri("http://localhost:5091/api/");
            DataContext = this;
        }

        public async void GetDevils()
        {
            var responce = await httpClient.PostAsync($"SotrudnekiController/GetSotrudneki", new StringContent("", Encoding.UTF8, "application/json"));

            if(responce.StatusCode != System.Net.HttpStatusCode.OK)
            {
                var result = await responce.Content.ReadAsStringAsync();
                return;
               
            }
            else
            {
                var devils = await responce.Content.ReadFromJsonAsync<List<Devil>>();
                //Devils = new List<Devil>(devils);
            }
        }

        public async void GetRacks()
        {
            var responce = await httpClient.PostAsync($"RaksController/GetRacks", new StringContent("", Encoding.UTF8, "application/json"));

            if (responce.StatusCode != System.Net.HttpStatusCode.OK)
            {
                var result = await responce.Content.ReadAsStringAsync();
                return;

            }
            else
            {
                var racks = await responce.Content.ReadFromJsonAsync<List<Rack>>();
            }
        }


        public void AddDemon(object sender, RoutedEventArgs e)
        {
            AddDemon addDemon = new AddDemon();
            addDemon.Show();
        }

        public void UpdateDemon(object sender, RoutedEventArgs e)
        {
            ChangeDemon changeDemon = new ChangeDemon();
            changeDemon.Show();
        }

        public async void KillTheDemon(object sender, RoutedEventArgs e)
        {
            string arg = JsonSerializer.Serialize(Devil);
            var responce = await httpClient.PostAsync($"SotrudnekiController/BolsheNeNashaBlood", new StringContent(arg, Encoding.UTF8, "application/json"));

            if (responce.StatusCode != System.Net.HttpStatusCode.OK)
            {
                var result = await responce.Content.ReadAsStringAsync();
                return;

            }
            else
            {
                var result = await responce.Content.ReadAsStringAsync();             
            }


        }

        public void DemonWithOrudie(object sender, RoutedEventArgs e)
        {

        }

        public void AddOrudiePitki(object sender, RoutedEventArgs e)
        {
            AddOrudiyaPitki addOrudiyaPitki = new AddOrudiyaPitki();
            addOrudiyaPitki.Show();

        }

        public void UpdateOrudiePitki(object sender, RoutedEventArgs e)
        {
            ChangeOrudiePitki change = new ChangeOrudiePitki();
            change.Show();
        }

        public async void DeleteOridiePitki(object sender, RoutedEventArgs e)
        {
            string arg = JsonSerializer.Serialize(Rack);
            var responce = await httpClient.PostAsync($"RaksController/BolsheNeNashaBlood", new StringContent(arg, Encoding.UTF8, "application/json"));

            if (responce.StatusCode != System.Net.HttpStatusCode.OK)
            {
                var result = await responce.Content.ReadAsStringAsync();
                return;

            }
            else
            {
                var result = await responce.Content.ReadAsStringAsync();
            }
        }
    }

    
}