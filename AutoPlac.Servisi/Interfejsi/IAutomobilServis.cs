using AutoPlac.Modeli.Modeli;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AutoPlac.Servisi.Interfejsi
{
    public interface IAutomobilServis
    {
        Task<IEnumerable<Automobil>> PrikazSvihAutomobilaAsync();
        Task<IEnumerable<Automobil>> PrikazSvihAutomobilaPoMarkiAsync(object Marka);
        Task<IEnumerable<Automobil>> PrikazSvihAutomobilaPoCeniAsync(object Cena);
        Task AzurirajAutomobil(Automobil obj, object ID);
        Task KreirajNovAutomobil(Automobil KartaModel);
        void ObrisiAutomobil(object ID);
        bool PostojiAutomobilUBaziPodataka();
    }
}
