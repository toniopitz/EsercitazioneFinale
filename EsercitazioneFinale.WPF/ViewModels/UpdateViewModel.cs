using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Command;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace EsercitazioneFinale.WPF.ViewModels
{
    public class UpdateViewModel : ViewModelBase
    {
        public ICommand UpdateCommand { get; set; }

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
        //public UpdateViewModel()
        //{
        //    UpdateCommand = new RelayCommand(
        //        () => ExecuteUpdate(),
        //        () => CanExecuteUpdate());
        //    if (!IsInDesignMode)
        //    {
        //        PropertyChanged += (s, e) =>
        //        {
        //            (UpdateCommand as RelayCommand).RaiseCanExecuteChanged();
        //        };
        //    }

        //}

        //private object CanExecuteUpdate()
        //{
        //    throw new NotImplementedException();
        //}

        //private void ExecuteUpdate()
        //{
        //    throw new NotImplementedException();
        //}
    }
}
