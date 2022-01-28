using EsercitazioneFinale.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EsercitazioneFinale.Core.Mock.Storage
{
    public static class MockStorage
    {
        public static IList<Biglietto> Biglietti { get; set; }

        public static void Initialize()
        {
            Biglietti = new List<Biglietto>();
            Biglietti.Add(
                new Biglietto
                {
                    Mittente = "Paolo Brosio",
                    Destinatario = "Barbara D'Urso",
                    Messaggio = "Non vengo più in trasmissione, tieni sta giftcard",
                    Importo = 0.50,
                    DataScadenza = new DateTime(2022,2,1)
                });
            Biglietti.Add(
                new Biglietto
                {
                    Mittente = "Maurizio Costanzo",
                    Destinatario = "Maria De Filippi",
                    Messaggio = "Comprati un'altra trasmissione",
                    Importo = 10000,
                    DataScadenza = new DateTime(2022, 7, 20)
                });
            Biglietti.Add(
                new Biglietto
                {
                    Mittente = "Mariottide",
                    Destinatario = "Ginetto",
                    Messaggio = "Con questa gift card invisibile potrai comprare dove vuoi!",
                    Importo = 0.0,
                    DataScadenza = new DateTime(2100, 2, 1)
                });
            Biglietti.Add(
                new Biglietto
                {
                    Mittente = "Juventus",
                    Destinatario = "Fiorentina",
                    Messaggio = "Spero vada bene per l'acquisto di Vlahovic",
                    Importo = 1.50,
                    DataScadenza = new DateTime(2022, 6, 1)
                });
        }
    }
}
