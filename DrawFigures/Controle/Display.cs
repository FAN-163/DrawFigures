using DrawFigures.Model;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DrawFigures.Controle
{
    class Display
    {
        private DataValidity dataValidity;

        List<ExtractFromString> listExtractFromString = new List<ExtractFromString>();


        public void PreparingDisplay(TextBox textBox1)
        {
            string[] input;
            string text = textBox1.Text.Replace(" ", "").ToLower();
            
            dataValidity = new DataValidity();
            dataValidity.FormatCheck(text);

            input = text.Split(new char[] { ';' });



            for (int i = 0; i < input.Length; i++)
            {
                listExtractFromString.Add(new ExtractFromString(input[i]));
            }
        }

        public void StartView(TextBox textBox1, PictureBox pictureBox1)
        {
            if (!dataValidity.flag == true)
            {
                textBox1.Clear();
                using (Graphics g = pictureBox1.CreateGraphics())
                {

                    foreach (ExtractFromString element in listExtractFromString)

                    {
                        FigureDraw figureDraw = new FigureDraw(element);
                        figureDraw.Draw(g, element.nameFigure);
                    }
                }
            }
        }
    }
}

