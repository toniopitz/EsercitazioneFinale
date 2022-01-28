using EsercitazioneFinale.WPF.Messaging.Biglietto;
using EsercitazioneFinale.WPF.ViewModels;
using GalaSoft.MvvmLight.Messaging;
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

namespace EsercitazioneFinale.WPF.Views
{
    /// <summary>
    /// Interaction logic for RiepilogoView.xaml
    /// </summary>
    public partial class RiepilogoView : Window
    {
        public RiepilogoView()
        {
            InitializeComponent();
            Messenger.Default.Register<ShowCreateBigliettoMessage>(this, OnShowCreateBiglietto);
        }

        private void OnShowCreateBiglietto(ShowCreateBigliettoMessage message)
        {
            CreateView view = new CreateView();
            CreateViewModel vm = new CreateViewModel();
            view.DataContext = vm;
            view.ShowDialog();
        }
    }
}
