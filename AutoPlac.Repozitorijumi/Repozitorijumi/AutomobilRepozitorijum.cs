using AutoPlac.Modeli.Modeli;
using AutoPlac.Repozitorijumi.Context;
using AutoPlac.Repozitorijumi.Interfejsi;
using Microsoft.EntityFrameworkCore;

namespace AutoPlac.Repozitorijumi.Repozitorijumi
{
    public class AutomobilRepozitorijum : IAutomobilRepozitorijum
    {

        public AutoPlacDBContext _ctx;

        public AutomobilRepozitorijum(AutoPlacDBContext ctx)
        {
            _ctx = ctx;
        }
        public Automobil Azuriraj(Automobil obj)
        {
            try
            {
                _ctx.Entry(obj).State = EntityState.Modified;

                return obj;
            }
            catch (Exception e)
            {
                throw e;
            }
        }

        public Automobil Dodaj(Automobil obj)
        {
            return _ctx.Automobil.Add(obj).Entity;
        }

        public void Obrisi(object ID)
        {
            var postoji = _ctx.Automobil.Find(ID);
            if (postoji is null)
                throw new ArgumentNullException();

            _ctx.Automobil.Remove(postoji);
        }

        public bool PostojiAutomobil()
        {
            return _ctx.Automobil.Any();
        }

        public Automobil PrikaziPoIDAsync(object ID)
        {
            var postoji = _ctx.Automobil.Find(ID);
            if (postoji is not null)
            {
                _ctx.Entry(postoji).State = EntityState.Detached;
                return postoji;
            }
            else return null;
        }

        public async Task<IEnumerable<Automobil>> PrikazSvihAutomobilaAsync()
        {
            var podaci = await _ctx.Automobil
                .ToListAsync();

            return podaci; ;
        }

        public async Task<IEnumerable<Automobil>> PrikazSvihAutomobilaPoMarkiAsync(object Marka)
        {
            var podaci = await _ctx.Automobil
                    .Where(x => x.Marka == (string)Marka).ToListAsync();

            return podaci;
        }

        public async Task<IEnumerable<Automobil>> PrikazSvihAutomobilaPoCeniAsync(object Cena)
        {
            var podaci = await _ctx.Automobil
                .Where(x => x.Cena == (int)Cena).ToArrayAsync();

            return podaci;
        }

        public void Sacuvaj()
        {
            _ctx.SaveChanges();
        }
    }
}
