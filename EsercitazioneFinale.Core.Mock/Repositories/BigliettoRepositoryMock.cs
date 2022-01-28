using EsercitazioneFinale.Core.Entities;
using EsercitazioneFinale.Core.Interfaces;
using EsercitazioneFinale.Core.Mock.Storage;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EsercitazioneFinale.Core.Mock.Repositories
{
    public class BigliettoRepositoryMock : IBigliettoRepository
    {
        public IList<Biglietto> GetAll()
        {
            return MockStorage.Biglietti.ToList();
        }
        public void Create(Biglietto biglietto)
        {
            var newId = MockStorage.Biglietti.Max(b => b.Id)+1;
            biglietto.Id = newId;
            MockStorage.Biglietti.Add(biglietto);
        }

        public void Delete(Biglietto biglietto)
        {
            var bigliettoToDelete = MockStorage.Biglietti.FirstOrDefault(b => b.Id == biglietto.Id);
            if(bigliettoToDelete != null)
                MockStorage.Biglietti.Remove(bigliettoToDelete);
        }


        public void Update(Biglietto biglietto)
        {
            var bigliettoToDelete = MockStorage.Biglietti.FirstOrDefault(b => b.Id == biglietto.Id);
            if (bigliettoToDelete != null)
                MockStorage.Biglietti.Remove(bigliettoToDelete);
            MockStorage.Biglietti.Add(biglietto);
        }
    }
}
