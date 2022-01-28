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
using System.Windows;
using System.Windows.Input;

namespace EsercitazioneFinale.WPF.ViewModels
{
    public class BigliettoRowViewModel : ViewModelBase
    {
       

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



        private Biglietto item;
        public ICommand ChangeChecked { get; set; }
        public ICommand DeleteCommand { get; set; }
        public BigliettoRowViewModel()
        {
            ChangeChecked = new RelayCommand(() => ExecuteChangeCheked());
            DeleteCommand = new RelayCommand(() => ExecuteDelete());
        }

        private void ExecuteChangeCheked()
        {
            if(IsChecked)
                IsChecked = false;
            else
                IsChecked = true;
        }

        public BigliettoRowViewModel(Biglietto item) : this()
        {
            this.item = item;
            Destinatario = item.Destinatario;
            Importo = item.Importo;
            Mittente = item.Mittente;
            Messaggio = item.Messaggio;
            DataScadenza=item.DataScadenza;
        }

        private void ExecuteDelete()
        {
            //Creiamo e inviamo un messaggio una volta ricevuto il comando
            //Che chiede la conferma del comando stesso
            Messenger.Default.Send(new DialogMessage
            {
                Title = "Conferma Cancellazione",
                Content = $"Sei sicuro di voler cancellare la GiftCard \n assegnata a {Destinatario}",
                Icon = System.Windows.MessageBoxImage.Question,
                Buttons = System.Windows.MessageBoxButton.YesNo,
                CallBack = OnMessageBoxResultReceived
            });
        }

        private void OnMessageBoxResultReceived(MessageBoxResult result)
        {
           //In caso di conferma recuperiamo il metodo dal bl e diamo un messaggio di
           //corretta esecuzione delle operazioni
           if(result == MessageBoxResult.Yes)
            {
                var layer = new MainBusinessLayer(new BigliettoRepositoryMock());

                var response = layer.DeleteBiglietto(item);

                if(!response.Success)
                {
                    Messenger.Default.Send(new DialogMessage
                    {
                        Title = "Errore",
                        Content = response.Message,
                        Icon = System.Windows.MessageBoxImage.Error,
                        Buttons = MessageBoxButton.OK
                    });
                }
                else
                {
                    Messenger.Default.Send(new DialogMessage
                    {
                        Title = "Dato Eliminato",
                        Content = response.Message,
                        Icon= System.Windows.MessageBoxImage.Information,
                        Buttons = MessageBoxButton.OK
                    });
                }
            }
        }
        private bool isChecked = false;

        public bool IsChecked
        {
            get { return isChecked; }
            set { isChecked = value; RaisePropertyChanged(); }
        }
    }
}
