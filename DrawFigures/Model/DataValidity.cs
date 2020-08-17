using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DrawFigures.Model
{
    class DataValidity
    {
        string[] symbol = new string[] { "-n", "-p", ";" };
        Regex regex;
        public bool flag { get; private set; }

        public void FormatCheck(string input)
        {
            int[] result = new int[symbol.Length];
            for (int i = 0; i < symbol.Length; i++)
            {
                regex = new Regex(symbol[i], RegexOptions.IgnoreCase);
                MatchCollection numberMaches = regex.Matches(input);
                result[i] = numberMaches.Count;

            }

            if (result[0] != result[1] || result[1] != result[2] + 1 || result[0] != result[2] + 1)
            {
                MessageBox.Show("Координаты линии указаны неверно", "Неверный формат", MessageBoxButtons.OK);
            }
                       
        }

        public void FigureCheck(string nameFigure, string coordinate)
        {

            if (nameFigure.Equals("line"))
            {
                regex = new Regex(@"\[[0-7]?[0-9]?[0-9],[0-3]?[0-9]?[0-9]\]\[[0-7]?[0-9]?[0-9],[0-3]?[0-9]?[0-9]\]");
                if (!coordinate.Equals(regex.Match(coordinate).ToString()))
                {
                    flag = false;
                    MessageBox.Show("Координаты линии указаны неверно", "Неверный формат", MessageBoxButtons.OK);

                }
                else
                {
                    flag = true;
                }
            }
            else if (nameFigure.Equals("rectangle"))
            {
                regex = new Regex(@"\[[0-7]?[0-9]?[0-9],[0-3]?[0-9]?[0-9]\]\[[0-7]?[0-9]?[0-9],[0-3]?[0-9]?[0-9]\]");
                if (!coordinate.Equals(regex.Match(coordinate).ToString()))
                {
                    flag = false;
                    MessageBox.Show("Координаты прямоугольника указаны неверно", "Неверный формат", MessageBoxButtons.OK);

                }
                else
                {
                    flag = true;
                }
            }
            else if (nameFigure.Equals("triangle"))
            {
                regex = new Regex(@"\[[0-7]?[0-9]?[0-9],[0-3]?[0-9]?[0-9]\]\[[0-7]?[0-9]?[0-9],[0-3]?[0-9]?[0-9]\]\[[0-7]?[0-9]?[0-9],[0-3]?[0-9]?[0-9]\]");
                if (!coordinate.Equals(regex.Match(coordinate).ToString()))
                {
                    flag = false;
                    MessageBox.Show("Координаты треугольника указаны неверно", "Неверный формат", MessageBoxButtons.OK);

                }
                else
                {
                    flag = true;
                }
            }
            else if (nameFigure.Equals("circle"))
            {
                regex = new Regex(@"\[[0-7]?[0-9]?[0-9],[0-3]?[0-9]?[0-9]\]");
                if (!coordinate.Equals(regex.Match(coordinate).ToString()))
                {
                    flag = false;
                    MessageBox.Show("Координаты круга указаны неверно", "Неверный формат", MessageBoxButtons.OK);

                }
                else
                {
                    flag = true;
                }
            }
            else if (nameFigure.Equals("ellipse"))
            {
                regex = new Regex(@"\[[0-7]?[0-9]?[0-9],[0-3]?[0-9]?[0-9]\]");
                if (!coordinate.Equals(regex.Match(coordinate).ToString()))
                {
                    flag = false;
                    MessageBox.Show("Координаты элипса указаны неверно", "Неверный формат", MessageBoxButtons.OK);

                }
                else
                {
                    flag = true;
                }
            }
        }

        public void RGBACheck(ExtractFromString extractFromString)
        {
            if (extractFromString.colorType.Length == 3 || extractFromString.backColorType.Length == 3)
            {
                regex = new Regex(@"^rgb\((25[0-5]|2[0-4][0-9]|1[0-9]?[0-9]?|[1-9][0-9]?|[0-9]),?(25[0-5]|2[0-4][0-9]|1[0-9]?[0-9]?|[1-9][0-9]?|[0-9]),?(25[0-5]|2[0-4][0-9]|1[0-9]?[0-9]?|[1-9][0-9]?|[0-9])\)$");
                if (!extractFromString.color.Equals(regex.Match(extractFromString.color).ToString()) || !extractFromString.backColor.Equals(regex.Match(extractFromString.backColor).ToString()))
                {
                    flag = false;
                    MessageBox.Show("Цвет указан неверно", "Неверный формат", MessageBoxButtons.OK);
                }
            }
            else if (extractFromString.colorType.Length == 4 || extractFromString.backColorType.Length == 4)
            {
                regex = new Regex(@"^rgba\((25[0-5]|2[0-4][0-9]|1[0-9]?[0-9]?|[1-9][0-9]?|[0-9]), ?(25[0-5]|2[0-4][0-9]|1[0-9]?[0-9]?|[1-9][0-9]?|[0-9]), ?(25[0-5]|2[0-4][0-9]|1[0-9]?[0-9]?|[1-9][0-9]?|[0-9]), ?(1|0|0\.[0-9]+)\)$");
                if (!extractFromString.color.Equals(regex.Match(extractFromString.color).ToString()) || !extractFromString.backColor.Equals(regex.Match(extractFromString.backColor).ToString()))
                {
                    flag = false;
                    MessageBox.Show("Цвет указан неверно", "Неверный формат", MessageBoxButtons.OK);
                }
            }
            else
            {
                flag = true;
               
            }
        }
    }
}
