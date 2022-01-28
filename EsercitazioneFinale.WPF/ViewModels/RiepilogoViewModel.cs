using EsercitazioneFinale.Core.BusinessLayer;
using EsercitazioneFinale.Core.Entities;
using EsercitazioneFinale.Core.Interfaces;
using EsercitazioneFinale.Core.Mock.Repositories;
using EsercitazioneFinale.WPF.Messaging.Biglietto;
using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Command;
using GalaSoft.MvvmLight.Messaging;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Data;
using System.Windows.Input;

namespace EsercitazioneFinale.WPF.ViewModels
{
    public class RiepilogoViewModel : ViewModelBase
    {
        public ICommand CreateBiglietto { get; set; }
        public ICommand Aggiorna { get; set; }
        public ObservableCollection<BigliettoRowViewModel> _BigliettiSource;
        private ICollectionView _Biglietti;

        public ICollectionView Biglietti
        {
            get { return _Biglietti; }
            set { _Biglietti = value; RaisePropertyChanged(); }
        }

        public ICommand LoadBigliettoCommand { get; set; }

        public RiepilogoViewModel()
        {
            Aggiorna = new RelayCommand(() => ExecuteAggiorna());
            CreateBiglietto = new RelayCommand(() => ExecuteShowCreateBiglietto());
            LoadBigliettoCommand = new RelayCommand(() => ExecuteLoadBiglietto());
            _BigliettiSource = new ObservableCollection<BigliettoRowViewModel>();
            _Biglietti = new CollectionView(_BigliettiSource);

            LoadBigliettoCommand.Execute(null);
        }

        private void ExecuteAggiorna()
        {
            IBigliettoRepository repo = new BigliettoRepositoryMock();
            MainBusinessLayer layer = new MainBusinessLayer(repo);

            //Ottengo i biglietti e li formatto nel tipo BigliettoRowViewModel
            var biglietti = layer.GetAllBiglietti();

            _BigliettiSource.Clear();
            //ciclo per ogni biglietto all'interno di biglietti e li aggiungo alla lista
            foreach (Biglietto item in biglietti)
            {
                var row = new BigliettoRowViewModel(item);
                _BigliettiSource.Add(row);
            }
        }

        private void ExecuteLoadBiglietto()
        {
            //Istanzio il Repo tramite il BL per poter usufruire dei dati nel Mock
            IBigliettoRepository repo = new BigliettoRepositoryMock();
            MainBusinessLayer layer = new MainBusinessLayer(repo);
            
            //Ottengo i biglietti e li formatto nel tipo BigliettoRowViewModel
            var biglietti = layer.GetAllBiglietti();

            _BigliettiSource.Clear();
            //ciclo per ogni biglietto all'interno di biglietti e li aggiungo alla lista
            foreach(Biglietto item in biglietti)
            {
                var row = new BigliettoRowViewModel(item);
                _BigliettiSource.Add(row);
            }

        }

        private void ExecuteShowCreateBiglietto()
        {
            Messenger.Default.Send(new ShowCreateBigliettoMessage());
        }

        
    }
}
