using EsercitazioneFinale.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EsercitazioneFinale.Core.Interfaces
{
    public interface IBigliettoRepository
    {
        IList<Biglietto> GetAll();
        void Create(Biglietto biglietto);
        void Update(Biglietto biglietto);
        void Delete(Biglietto biglietto);

    }
}
