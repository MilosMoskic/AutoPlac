using AutoPlac.Modeli.Modeli;
using AutoPlac.Servisi.Interfejsi;

namespace AutoPlac
{
    public partial class Form1 : Form
    {
        private readonly IAutomobilServis _automobilServis;
        public Form1(IAutomobilServis automobilServis)
        {
            _automobilServis = automobilServis;
            InitializeComponent();
            _ = InitPrikaz();
        }
        private void PostavkaTabele(DataGridView tabela)
        {
            int offset = 0;
            DataGridView tabelaPodataka = tabela;

            int cnt = 0;
            cnt = tabelaPodataka.RowCount;

            if (cnt < 11) offset = 8;
            else offset = 0;

            tabelaPodataka.Columns["Id"].HeaderText = "ID";
            tabelaPodataka.Columns["Id"].Width = 30;
            tabelaPodataka.Columns["Naziv"].HeaderText = "Naziv automobila";
            tabelaPodataka.Columns["Naziv"].Width = 190;
            tabelaPodataka.Columns["Marka"].HeaderText = "Marka";
            tabelaPodataka.Columns["Marka"].Width = 150 + offset;
            tabelaPodataka.Columns["DatumProdaje"].HeaderText = "DatumProdaje";
            tabelaPodataka.Columns["DatumProdaje"].Width = 60 + offset;
            tabelaPodataka.Columns["Cena"].HeaderText = "Cena";
            tabelaPodataka.Columns["Cena"].Width = 50;
            tabelaPodataka.Columns["Godiste"].HeaderText = "Godiste";
            tabelaPodataka.Columns["Godiste"].Width = 50;
        }

        private async Task InitPrikaz()
        {
            try
            {
                var automobili = await _automobilServis.PrikazSvihAutomobilaAsync();

                dataGridView1.DataSource = automobili;
                PostavkaTabele(dataGridView1);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }
        private async void btnDodaj_Click(object sender, EventArgs e)
        {
            try
            {
                Automobil AutomobilZaIzmenu = new();

                AutomobilZaIzmenu.Naziv = txtNaziv.Text;
                AutomobilZaIzmenu.Marka = txtMarka.Text;
                AutomobilZaIzmenu.DatumProdaje = DateTime.Parse(date.Text);
                AutomobilZaIzmenu.Godiste = Int32.Parse(txtGodiste.Text);
                AutomobilZaIzmenu.Cena = Int32.Parse(txtCena.Text);

                await _automobilServis.KreirajNovAutomobil(AutomobilZaIzmenu);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
            _ = InitPrikaz();
        }

        private void cbFilterGodiste_CheckedChanged(object sender, EventArgs e)
        {
            throw new NotImplementedException();
        }

        private async void btnIzmeni_Click(object sender, EventArgs e)
        {
            try
            {
                var ID = Int32.Parse(txtID.Text);

                Automobil AutomobilZaIzmenu = new()
                {
                    Naziv = txtNaziv.Text,
                    Marka = txtMarka.Text,
                    DatumProdaje = DateTime.Parse(date.Text),
                    Godiste = Int32.Parse(txtGodiste.Text),
                    Cena = Int32.Parse(txtCena.Text)
                };

                await _automobilServis.AzurirajAutomobil(AutomobilZaIzmenu, ID);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
            _ = InitPrikaz();
        }

        private void btnObrisi_Click(object sender, EventArgs e)
        {
            var ID = Int32.Parse(txtID.Text);
            _automobilServis.ObrisiAutomobil(ID);
            _ = InitPrikaz();
        }

        private async void btnFilter_Click(object sender, EventArgs e)
        {

            IEnumerable<Automobil>? filtrirano;
            try
            {
                if (cbFilterCena.Checked)
                {
                    cbFilterMarka.Checked = false;

                    var filterCena = Int32.Parse(txtFilter.Text);

                    filtrirano = await _automobilServis.PrikazSvihAutomobilaPoCeniAsync(filterCena);
                }
                else if (cbFilterMarka.Checked)
                {
                    cbFilterCena.Checked = false;

                    var filterMarka = txtFilter.Text;

                    filtrirano = await _automobilServis.PrikazSvihAutomobilaPoMarkiAsync(filterMarka);
                }
                else
                {
                    filtrirano = null;
                }
            }
            catch (Exception)
            {
                throw new ArgumentNullException();
            }

            if (filtrirano is not null)
            {
                dataGridView1.DataSource = filtrirano;
                PostavkaTabele(dataGridView1);
            }
            else
            {
                _ = InitPrikaz();
            }

        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                DataGridViewRow selektovaniRed = dataGridView1.Rows[e.RowIndex];

                txtID.Text = selektovaniRed.Cells["Id"].Value.ToString();
                txtNaziv.Text = selektovaniRed.Cells["Naziv"].Value.ToString();
                txtMarka.Text = selektovaniRed.Cells["Marka"].Value.ToString();
                date.Text = selektovaniRed.Cells["DatumProdaje"].Value.ToString();
                txtGodiste.Text = selektovaniRed.Cells["Godiste"].Value.ToString();
                txtCena.Text = selektovaniRed.Cells["Cena"].Value.ToString();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }

        private void cbFilterCena_CheckedChanged_1(object sender, EventArgs e)
        {
            if (cbFilterCena.Checked == true)
            {
                cbFilterMarka.Checked = false;
            }
        }

        private void cbFilterMarka_CheckedChanged(object sender, EventArgs e)
        {
            if (cbFilterMarka.Checked == true)
            {
                cbFilterCena.Checked = false;
            }
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }
    }
}