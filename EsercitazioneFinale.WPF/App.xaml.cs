using EsercitazioneFinale.Core.Mock.Storage;
using EsercitazioneFinale.WPF.Messaging.Generic;
using EsercitazioneFinale.WPF.ViewModels;
using EsercitazioneFinale.WPF.Views;
using GalaSoft.MvvmLight.Messaging;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using System.Windows;

namespace EsercitazioneFinale.WPF
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        protected override void OnStartup(StartupEventArgs e)
        {
            //Ascolto Messaggi di tipo DialogMessage
            Messenger.Default.Register<DialogMessage>(this, OnDialogMessageReceived);

            MockStorage.Initialize();

            RiepilogoView view = new RiepilogoView();

            RiepilogoViewModel vm = new RiepilogoViewModel();
            
            view.DataContext = vm; 

            view.Show();

            base.OnStartup(e);
        }

        private void OnDialogMessageReceived(DialogMessage message)
        {
            MessageBoxResult result = MessageBox.Show(
                message.Title,
                message.Content,
                message.Buttons,
                message.Icon);
            if (message.CallBack != null)
                message.CallBack(result);
        }
    }
}
