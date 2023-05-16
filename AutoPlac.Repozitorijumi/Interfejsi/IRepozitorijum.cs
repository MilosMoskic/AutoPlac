using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AutoPlac.Repozitorijumi.Interfejsi
{
    public interface IRepozitorijum<T> where T : class
    {
        void Obrisi(object PK);
        T PrikaziPoIDAsync(object ID);
        T Dodaj(T obj);
        T Azuriraj(T obj);
        Task<IEnumerable<T>> PrikazSvihAutomobilaAsync();
        Task<IEnumerable<T>> PrikazSvihAutomobilaPoMarkiAsync(object Marka);
        Task<IEnumerable<T>> PrikazSvihAutomobilaPoCeniAsync(object Cena);
        void Sacuvaj();
        bool PostojiAutomobil();
    }
}
