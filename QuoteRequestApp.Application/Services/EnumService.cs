using QuoteRequestApp.Application.Services.Interfaces;
using QuoteRequestApp.Core.Enums;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace QuoteRequestApp.Application.Services
{
    public class EnumService : IEnumService
    {
        public List<string> GetCountries()
        {
            return Enum.GetValues(typeof(Country)).Cast<Country>()
                .Select(e => e.ToString()).ToList();
        }

        public List<string> GetCitiesByCountry(Country country)
        {
            return GetCitiesByCountryEnum(country)
                .Select(e => GetEnumDescription(e)).ToList();
        }

        private IEnumerable<City> GetCitiesByCountryEnum(Country country)
        {
            switch (country)
            {
                case Country.USA:
                    return new List<City> { City.NewYork, City.LosAngeles, City.Miami, City.Minnesota };
                case Country.China:
                    return new List<City> { City.Beijing, City.Shanghai };
                case Country.Turkey:
                    return new List<City> { City.Istanbul, City.Izmir };
                default:
                    return new List<City>();
            }
        }

        private string GetEnumDescription(Enum value)
        {
            FieldInfo fi = value.GetType().GetField(value.ToString());
            DescriptionAttribute[] attributes = (DescriptionAttribute[])fi.GetCustomAttributes(typeof(DescriptionAttribute), false);
            return (attributes.Length > 0) ? attributes[0].Description : value.ToString();
        }
    }
}
