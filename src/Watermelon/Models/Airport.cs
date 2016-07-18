using CsvHelper.Configuration;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;
using Watermelon.Components.CsvHelperConverters;

namespace Watermelon.Models
{
    public class Airport
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int AirportId { get; set; }

        public int? CountryId { get; set; }
        public int? StateId { get; set; }
        public int? CityId { get; set; }
        public string Code { get; set; }
        public string Name { get; set; }
        public string TimeZone { get; set; }
        public double? Latitude { get; set; }
        public double? Longitude { get; set; }
    }

    public class AirportMap : CsvClassMap<Airport>
    {
        public AirportMap()
        {
            AutoMap();
            var intNullableConverter = new RealNullableConverter(typeof(int?));
            var doubleNullableConverter = new RealNullableConverter(typeof(double?));

            Map(m => m.CountryId).TypeConverter(intNullableConverter);
            Map(m => m.StateId).TypeConverter(intNullableConverter);
            Map(m => m.CityId).TypeConverter(intNullableConverter);

            Map(m => m.Latitude).TypeConverter(doubleNullableConverter);
            Map(m => m.Longitude).TypeConverter(doubleNullableConverter);
        }
    }
}
