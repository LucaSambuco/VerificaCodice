using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProntoSoccorsoBasic
{
    internal class Paziente
    {
        private string Nome;
        private string Cognome;
        public string Codice_Fiscale;
        public string Codice_Urgenza;

        public Paziente(string nome, string cognome, string codicefiscale, string codiceurgenza)
        {
            Nome = nome;
            Cognome = cognome;
            Codice_Fiscale = codicefiscale;
            Codice_Urgenza = codiceurgenza;
        }

        public string Stampa()
        {
            string result = "";
            result += "Nome:" + Nome + "\nCognome:" + Cognome + "\nCodice Fiscale:" + Codice_Fiscale + "\nCodice d'Urgenza:" + Codice_Urgenza;
            return result;
        }
    }
}
