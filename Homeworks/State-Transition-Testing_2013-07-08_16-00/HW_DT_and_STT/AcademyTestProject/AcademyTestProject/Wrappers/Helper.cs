using System.Collections.Generic;
using System.Text;
using ArtOfTest.WebAii.Silverlight;
using ArtOfTest.WebAii.Silverlight.UI;

namespace Wrappers
{
    internal class Helper
    {
        internal static string GetColorRGBPatternValue(Color color)
        {
            if (color == null)
            {
                return null;
            }
            return color.R + ":" + color.G + ":" + color.B;
        }
    }
}
