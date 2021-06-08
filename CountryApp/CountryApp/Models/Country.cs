using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CountryApp.Models
{
    public class Country
    {
        public string Capital { get; set; }
        public int GeonameId { get; set; }
        public string CountryCode { get; set; }
        public string CountryName { get; set; }
        public string ContinentName { get; set; }
        public string CurrencyCode { get; set; }
        public string FlagUrl { get; set; }
    }
}
