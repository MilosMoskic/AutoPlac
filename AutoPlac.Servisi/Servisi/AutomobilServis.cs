using AutoPlac.Modeli.Modeli;
using AutoPlac.Repozitorijumi.Interfejsi;
using AutoPlac.Servisi.Interfejsi;


namespace AutoPlac.Servisi.Servisi
{
    public class AutomobilServis : IAutomobilServis
    {
        private IAutomobilRepozitorijum _automobilRepozitorijum;
        public AutomobilServis(IAutomobilRepozitorijum automobilRepozitorijum)
        {
            _automobilRepozitorijum = automobilRepozitorijum;
        }

        public Task AzurirajAutomobil(Automobil obj, object ID)
        {
            var podatci = _automobilRepozitorijum.PrikaziPoIDAsync(ID);
            if (podatci == null) throw new ArgumentNullException();

            Automobil izmenjeniautomobil = new()
            {
                Id = podatci.Id,
                Naziv = obj.Naziv,
                Marka = obj.Marka,
                DatumIzdanja = obj.DatumIzdanja,
                Godiste = obj.Godiste,
                Cena = obj.Cena

            };

            _automobilRepozitorijum.Azuriraj(izmenjeniautomobil);
            _automobilRepozitorijum.Sacuvaj();
            return Task.CompletedTask;
        }

        public Task KreirajNovAutomobil(Automobil automobil)
        {
            Automobil automobilZaDodati = new()
            {
                Naziv = automobil.Naziv,
                Marka = automobil.Marka,
                DatumIzdanja = automobil.DatumIzdanja,
                Godiste = automobil.Godiste,
                Cena = automobil.Cena
            };

            _automobilRepozitorijum.Dodaj(automobilZaDodati);
            _automobilRepozitorijum.Sacuvaj();
            return Task.CompletedTask;
        }

        public void ObrisiAutomobil(object ID)
        {
            _automobilRepozitorijum.Obrisi(ID);
            _automobilRepozitorijum.Sacuvaj();
        }

        public bool PostojiAutomobilUBaziPodataka()
        {
            var postojiAutomobil = _automobilRepozitorijum.PostojiAutomobil();

            return postojiAutomobil;
        }

        public async Task<IEnumerable<Automobil>> PrikazSvihAutomobilaAsync()
        {
            var postoji = await _automobilRepozitorijum.PrikazSvihAutomobilaAsync();
            if (postoji is null) throw new ArgumentNullException();

            List<Automobil> automobili = new();
            Automobil automobil;

            foreach (var item in postoji)
            {
                automobil = new Automobil
                {
                    Id = item.Id,
                    Naziv = item.Naziv,
                    Marka = item.Marka,
                    DatumIzdanja = item.DatumIzdanja,
                    Godiste = item.Godiste,
                    Cena = item.Cena
                };
                automobili.Add(automobil);
            }
            return automobili.OrderBy(f => f.DatumIzdanja).ToList();
        }

        public async Task<IEnumerable<Automobil>> PrikazSvihAutomobilaPoMarkiAsync(object Marka)
        {
            var postoji = await _automobilRepozitorijum.PrikazSvihAutomobilaPoMarkiAsync(Marka);
            if (postoji is null) throw new ArgumentNullException();

            List<Automobil> automobili = new List<Automobil>();
            Automobil automobil;

            foreach (var item in postoji)
            {
                automobil = new Automobil
                {
                    Id = item.Id,
                    Naziv = item.Naziv,
                    Marka = item.Marka,
                    DatumIzdanja = item.DatumIzdanja,
                    Godiste = item.Godiste,
                    Cena = item.Cena
                };
                automobili.Add(automobil);
            }
            return automobili.OrderBy(f => f.DatumIzdanja).ToList();
        }

        public async Task<IEnumerable<Automobil>> PrikazSvihAutomobilaPoCeniAsync(object Cena)
        {
            var postoji = await _automobilRepozitorijum.PrikazSvihAutomobilaPoCeniAsync(Cena);
            if (postoji is null) throw new ArgumentNullException();

            List<Automobil> automobili = new List<Automobil>();
            Automobil automobil;

            foreach (var item in postoji)
            {
                automobil = new Automobil
                {
                    Id = item.Id,
                    Naziv = item.Naziv,
                    Marka = item.Marka,
                    DatumIzdanja = item.DatumIzdanja,
                    Godiste = item.Godiste,
                    Cena = item.Cena
                };
                automobili.Add(automobil);
            }
            return automobili.OrderBy(f => f.DatumIzdanja).ToList();
        }
    }
}