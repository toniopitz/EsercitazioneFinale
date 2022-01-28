using EsercitazioneFinale.Core.BusinessLayer;
using EsercitazioneFinale.Core.Entities;
using EsercitazioneFinale.Core.Mock.Repositories;
using EsercitazioneFinale.WPF.Messaging.Generic;
using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Command;
using GalaSoft.MvvmLight.Messaging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace EsercitazioneFinale.WPF.ViewModels
{
    public class CreateViewModel : ViewModelBase
    {
        public ICommand CreateCommand { get; set; }

        private string _Destinatario;
        public string Destinatario
        {
            get { return _Destinatario; }
            set { _Destinatario = value; RaisePropertyChanged(); }
        }
        private string _Mittente;
        public string Mittente
        {
            get { return _Mittente; }
            set { _Mittente = value; RaisePropertyChanged(); }
        }
        private string _Messaggio;
        public string Messaggio
        {
            get { return _Messaggio; }
            set { _Messaggio = value; RaisePropertyChanged(); }
        }
        private double _Importo;
        public double Importo
        {
            get { return _Importo; }
            set { _Importo = value; RaisePropertyChanged(); }
        }
        private DateTime _DataScadenza;
        public DateTime DataScadenza
        {
            get { return _DataScadenza; }
            set { _DataScadenza = value; RaisePropertyChanged(); }
        }

        public CreateViewModel()
        {
            CreateCommand = new RelayCommand(
                () => ExecuteCreate(),
                () => CanExecuteCreate());
            if(!IsInDesignMode)
            {
                PropertyChanged += (s, e) =>
                {
                    (CreateCommand as RelayCommand).RaiseCanExecuteChanged();
                };
            }

        }

        private bool CanExecuteCreate()
        {
            return  !string.IsNullOrEmpty(Destinatario) &&
                    !string.IsNullOrEmpty(Mittente) &&
                    !string.IsNullOrEmpty(Messaggio) &&
                    !string.IsNullOrEmpty(Importo.ToString()) &&
                    !string.IsNullOrEmpty(DataScadenza.ToString());
        }

        private void ExecuteCreate()
        {
            var item = new Biglietto
            {
                Destinatario = Destinatario,
                Mittente = Mittente,
                Messaggio = Messaggio,
                Importo = Importo,
                DataScadenza = DataScadenza,
            };

            var layer = new MainBusinessLayer(new BigliettoRepositoryMock());

            var response = layer.CreateBiglietto(item);

            if (!response.Success)
            {
                Messenger.Default.Send(new DialogMessage
                {
                    Title = "Si è verificato un errore",
                    Content = response.Message,
                    Icon = System.Windows.MessageBoxImage.Error,
                    Buttons= System.Windows.MessageBoxButton.OK
                });
                return;
            }
            else
            {
                Messenger.Default.Send(new DialogMessage
                {
                    Title = "Creazione completata",
                    Content = response.Message,
                    Icon = System.Windows.MessageBoxImage.Information,
                    Buttons = System.Windows.MessageBoxButton.OK
                });
            }

        }
    }
}
