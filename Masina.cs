using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibrarieModele
{
    internal class Masina
    {
        //constante
        private const char SEPARATOR_PRINCIPAL_FISIER = ';';

        private const int ID = 0;
        private const int FIRMA = 1;
        private const int MODEL = 2;
        private const int AN_FABRICATIE = 3;
        private const int CULOARE = 4;
        private const int DISPONIBILITATE =5;

        //proprietati auto-implemented

        private int idMasina;//identificator unic 
        private string firma; //ex:Audi
        private string model;//A4
        private string an_fabricatie;
        private string culoare;
        private bool disponibilitate;


        //constructor implicit
        public Masina()
        {
            disponibilitate=false;
            firma = model = an_fabricatie = culoare = string.Empty;
        }

        //constructor cu parametri
        public Masina(int _id, string _firma, string _model, string _an_fabricatie, string _culoare)
        {
            idMasina = _id;
            firma = _firma;
            model = _model;
            an_fabricatie = _an_fabricatie;
            culoare = _culoare;
            disponibilitate = true;
        }

        public Masina(string linieFisier)
        {
            var dateFisier = linieFisier.Split(SEPARATOR_PRINCIPAL_FISIER);

            //ordinea de preluare a campurilor este data de ordinea in care au fost scrise in fisier prin apelul implicit al metodei ConversieLaSir_PentruFisier()
            idMasina = Convert.ToInt32(dateFisier[ID]);
            firma = dateFisier[FIRMA];
            model = dateFisier[MODEL];
            an_fabricatie = dateFisier[AN_FABRICATIE];
            culoare = dateFisier[CULOARE];
            //disponibilitate = dateFisier[DISPONIBILITATE];
        }
        public string ConversieLaSir_PentruFisier()
        {
            string obiectMasinaPentruFisier = string.Format("{1}{0}{2}{0}{3}{0}{4}{0}{5}",
                SEPARATOR_PRINCIPAL_FISIER,
                idMasina.ToString(),
                (firma ?? " NECUNOSCUT "),
                (model ?? " NECUNOSCUT "),
                (an_fabricatie ?? " NECUNOSCUT "),
                (culoare ?? "NECUNOSCUT"),
                (disponibilitate , "NECUNOSCUT"));

            return obiectMasinaPentruFisier;
        }

        public int GetIdMasina()
        {
            return idMasina;
        }

        public string GetFirma()
        {
            return firma;
        }

        public string GetModel()
        {
            return model;
        }

        public string GetAnFabricatie()
        {
            return an_fabricatie;
        }

        public string GetCuloare()
        {
            return culoare;
        }
    }
}
