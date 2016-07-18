using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CsvHelper.TypeConversion;

namespace Watermelon.Components.CsvHelperConverters
{
    public class RealNullableConverter : NullableConverter
    {
        public RealNullableConverter(Type type) : base(type)
        {
        }

        public override object ConvertFromString(TypeConverterOptions options, string text)
        {
            return text.Equals("NULL", StringComparison.CurrentCultureIgnoreCase) ? null : base.ConvertFromString(options, text);
        }
    }
}
