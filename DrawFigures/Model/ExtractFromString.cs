using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace DrawFigures.Model
{
    class ExtractFromString
    {
        public string nameFigure { get; private set; }
        public int radius1 { get; private set; }
        public int radius2 { get; private set; }
        public int Ax { get; private set; }
        public int Ay { get; private set; }
        public int Bx { get; private set; }
        public int By { get; private set; }
        public int Cx { get; private set; }
        public int Cy { get; private set; }
        public string colorType { get; private set; }
        public int colorR { get; private set; }
        public int colorG { get; private set; }
        public int colorB { get; private set; }
        public double colorOpacity { get; private set; }
        public string backColorType { get; private set; }
        public int backColorR { get; private set; }
        public int backColorG { get; private set; }
        public int backColorB { get; private set; }
        public double backColorOpacity { get; private set; }
        public string coordinate { get; private set; }
        public string color { get; private set; }
        public string backColor { get; private set; }


        private string input;
        private Regex regex;
        private DataValidity dataValidity = new DataValidity();

        public ExtractFromString(string input)
        {
            //input = input.Replace(" ", "").ToLower();
            this.input = input ?? throw new ArgumentNullException(nameof(input));

            DividingTheLine();
            ExtractString();
            if (color != null) ExtractColor(color);
            if (coordinate != null) ExtractCoordinate(coordinate);
            if (backColor != null) ExtractBackColor(backColor);

        }

        private void DividingTheLine()
        {
            string[] undefinedArray = input.Split(new char[] { '-' });

            nameFigure = IsSymbolContains(undefinedArray, "n");
            coordinate = IsSymbolContains(undefinedArray, "p");
            radius1 = Convert.ToInt32(IsSymbolContains(undefinedArray, "r1"));
            radius2 = Convert.ToInt32(IsSymbolContains(undefinedArray, "r2"));
            color = IsSymbolContains(undefinedArray, "c");
            backColor = IsSymbolContains(undefinedArray, "b");

        }

        private void ExtractString()
        {
            regex = new Regex(@"\D[a-z]+");
            if (color != null)
            {
                colorType = regex.Match(color).ToString();
                color = color.Remove(0, colorType.Length);
            }
            if (backColor != null)
            {
                backColorType = regex.Match(backColor).ToString();
                backColor = backColor.Remove(0, backColorType.Length);
            }
        }


        private void ExtractColor(string collor)
        {
            string[] undefinedArray = collor.Trim('(', ')').Split(new char[] { ',' });
            colorR = Convert.ToInt32(undefinedArray[0]);
            colorG = Convert.ToInt32(undefinedArray[1]);
            colorB = Convert.ToInt32(undefinedArray[2]);
            if (undefinedArray.Length == 4)
            {
                colorOpacity = Convert.ToDouble(undefinedArray[3].Replace(".", ","));
            }
        }

        private void ExtractBackColor(string backCollor)
        {
            string[] undefinedArray = backCollor.Trim('(', ')').Split(new char[] { ',' });
            backColorR = Convert.ToInt32(undefinedArray[0]);
            backColorG = Convert.ToInt32(undefinedArray[1]);
            backColorB = Convert.ToInt32(undefinedArray[2]);
            if (undefinedArray.Length == 4)
            {
                backColorOpacity = Convert.ToDouble(undefinedArray[3].Replace(".", ","));
            }
        }
        private void ExtractCoordinate(string coordinate)
        {
            dataValidity.FigureCheck(nameFigure, coordinate);
            coordinate = coordinate.Replace("]", ",").Replace("[", "");
            coordinate = coordinate.Substring(0, coordinate.Length - 1);
            string[] undefinedArray = coordinate.Split(new char[] { ',' });
            Ax = Convert.ToInt32(undefinedArray[0]);
            Ay = Convert.ToInt32(undefinedArray[1]);
            if (undefinedArray.Length >= 4)
            {
                Bx = Convert.ToInt32(undefinedArray[2]);
                By = Convert.ToInt32(undefinedArray[3]);
            }
            if (undefinedArray.Length == 6)
            {
                Cx = Convert.ToInt32(undefinedArray[4]);
                Cy = Convert.ToInt32(undefinedArray[5]);
            }
        }

        private string IsSymbolContains(string[] input, string symbol)
        {
            for (int i = 1; i < input.Length; i++)
            {

                if (input[i].StartsWith(symbol))
                    return input[i].Remove(0, symbol.Length);
            }
            return null;
        }
    }
}
