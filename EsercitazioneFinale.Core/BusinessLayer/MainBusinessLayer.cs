using EsercitazioneFinale.Core.Entities;
using EsercitazioneFinale.Core.Interfaces;
using EsercitazioneFinale.Core.Utils;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EsercitazioneFinale.Core.BusinessLayer
{
    public class MainBusinessLayer
    {
        private IBigliettoRepository _bigliettoRepo;

        public MainBusinessLayer(IBigliettoRepository bigliettoRepository)
        {
            _bigliettoRepo = bigliettoRepository;
        }

        public IList<Biglietto> GetAllBiglietti()
        {
            return _bigliettoRepo.GetAll();
        }

        public Response CreateBiglietto(Biglietto biglietto)
        {
            //Vari Controlli
            if (biglietto is null)
                return new Response { Success = false, Message = "Biglietto non valido" };
            if (biglietto.DataScadenza <= DateTime.Now)
                return new Response { Success = false, Message = "La data deve decorrere dalla data di oggi + 1gg" };
            if (biglietto.Importo < 0)
                return new Response { Success = false, Message = "L'importo non è valido" };
            //Creazione e Conferma della stessa
            _bigliettoRepo.Create(biglietto);
            return new Response { Success = true, Message = "Creazione del biglietto avvenuta con successo" };

        }
        public Response DeleteBiglietto(Biglietto biglietto)
        {
            if (biglietto is null)
                return new Response { Success = false, Message = "Biglietto non valido" };
            if (GetAllBiglietti().FirstOrDefault(b => b.Id == biglietto.Id) is null)
                return new Response { Success = false, Message = "Biglietto inesistente" };
            
            _bigliettoRepo.Delete(biglietto);
            return new Response { Success = true, Message = "Biglietto eliminato con successo" };

        }
        //public Response UpdateBiglietto(Biglietto biglietto) OPZIONALE
    }
}
