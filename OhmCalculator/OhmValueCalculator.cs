using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OhmCalculator
{
    public class OhmValueCalculator : IOhmValueCalculator
    {
        public class OneReading {
            public BandColorEnum BandColor { get; set; }
            public int SignificantFigure { get; set; }
            public int Multiplier { get; set; }
            /// <summary>
            /// looks like tolerance is not using
            /// </summary>
            public decimal Tolerance { get; set; }
        }

        public enum BandColorEnum {
            Black,
            Brown,
            Red,
            Orange,
            Yellow,
            Green,
            Blue,
            Violet,
            Gray,
            White,
            Gold,
            Silver
        }

        public static readonly OneReading[] OHM_LOOKUP = {
            new OneReading { BandColor =BandColorEnum.Black, SignificantFigure = 0, Multiplier = 0, Tolerance = 0m },
            new OneReading { BandColor =BandColorEnum.Brown, SignificantFigure = 1, Multiplier = 1, Tolerance = 1 },
            new OneReading { BandColor =BandColorEnum.Red, SignificantFigure = 2, Multiplier = 2, Tolerance = 2 },
            new OneReading { BandColor =BandColorEnum.Orange, SignificantFigure = 3, Multiplier = 3, Tolerance = 3 },
            new OneReading { BandColor =BandColorEnum.Yellow, SignificantFigure = 4, Multiplier = 4, Tolerance = 4 },
            new OneReading { BandColor =BandColorEnum.Green, SignificantFigure = 5, Multiplier = 5, Tolerance = 5 },
            new OneReading { BandColor =BandColorEnum.Blue, SignificantFigure = 6, Multiplier = 6, Tolerance = 6 },
            new OneReading { BandColor =BandColorEnum.Violet, SignificantFigure = 7, Multiplier = 7, Tolerance = 7 },
            new OneReading { BandColor =BandColorEnum.Gray, SignificantFigure = 8, Multiplier = 8, Tolerance = 8 },
            new OneReading { BandColor =BandColorEnum.White, SignificantFigure = 9, Multiplier = 9, Tolerance = 9 },
            new OneReading { BandColor =BandColorEnum.Gold, Tolerance = -1 },
            new OneReading { BandColor =BandColorEnum.Silver, Tolerance = -2 },
        };

        public int CalculateOhmValue(string bandAColor, string bandBColor, string bandCColor, string bandDColor)
        {
            try
            {
                var bandAReading = OHM_LOOKUP.Where(o => o.BandColor.ToString().ToLower().Equals(bandAColor.ToLower())).FirstOrDefault();
                var bandBReading = OHM_LOOKUP.Where(o => o.BandColor.ToString().ToLower().Equals(bandBColor.ToLower())).FirstOrDefault();
                var bandCReading = OHM_LOOKUP.Where(o => o.BandColor.ToString().ToLower().Equals(bandCColor.ToLower())).FirstOrDefault();
                var bandDReading = OHM_LOOKUP.Where(o => o.BandColor.ToString().ToLower().Equals(bandDColor.ToLower())).FirstOrDefault();

                if (bandAReading == null || bandBReading == null || bandCReading == null || bandDReading == null)
                {
                    throw new Exception("invalid input or can't look up these color composition");
                }

                int ohmValue =(int) ((bandAReading.SignificantFigure * 10 + bandBReading.SignificantFigure) * Math.Pow(10, bandCReading.Multiplier));
                return ohmValue;
            }
            catch (Exception ex) {
                return -1;
            }
        }
    }
}
