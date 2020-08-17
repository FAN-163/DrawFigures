using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DrawFigures.Model
{
    class FigureDraw
    {
        SolidBrush brush;
        Pen pen;
        ExtractFromString extractFromString;

        public FigureDraw(ExtractFromString extractFromString)
        {
            this.extractFromString = extractFromString;

        }

        public void Draw(Graphics g, string nameFigure)
        {
            switch (nameFigure)
            {
                case "line":
                    {
                        ColorPen(extractFromString.colorType);
                        g.DrawLine(pen,
                                    new Point(extractFromString.Ax,
                                    extractFromString.Ay),
                                    new Point(extractFromString.Bx,
                                    extractFromString.By));
                        pen.Dispose();
                        break;
                    }
                case "rectangle":
                    {
                        ColorPen(extractFromString.colorType);
                        ColorSolidBrash(extractFromString.backColorType);
                        Rectangle rectangle = new Rectangle(extractFromString.Ax,
                                                            extractFromString.Ay,
                                                            extractFromString.Bx,
                                                            extractFromString.By);
                        g.DrawRectangle(pen, rectangle);
                        g.FillRectangle(brush, rectangle);
                        brush.Dispose();
                        pen.Dispose();

                        break;
                    }
                case "triangle":
                    {
                        ColorPen(extractFromString.colorType);
                        ColorSolidBrash(extractFromString.backColorType);
                        Point[] points = new Point[3];
                        points[0].X = extractFromString.Ax; points[0].Y = extractFromString.Ay;
                        points[1].X = extractFromString.Bx; points[1].Y = extractFromString.By;
                        points[2].X = extractFromString.Cx; points[2].Y = extractFromString.Cy;

                        g.DrawPolygon(pen, points);
                        g.FillPolygon(brush, points);
                        brush.Dispose();
                        pen.Dispose();
                        break;
                    }
                case "circle":
                    {
                        ColorPen(extractFromString.colorType);
                        ColorSolidBrash(extractFromString.backColorType);
                        Rectangle rectangle = new Rectangle(extractFromString.Ax - extractFromString.radius1,
                                                            extractFromString.Ay - extractFromString.radius1,
                                                            extractFromString.radius1 * 2,
                                                            extractFromString.radius1 * 2);
                        g.DrawEllipse(pen, rectangle);
                        g.FillEllipse(brush, rectangle);
                        brush.Dispose();
                        pen.Dispose();
                        break;
                    }
                case "ellipse":
                    {
                        ColorPen(extractFromString.colorType);
                        ColorSolidBrash(extractFromString.backColorType);
                        Rectangle rectangle = new Rectangle(extractFromString.Ax - extractFromString.radius1,
                                                            extractFromString.Ay - extractFromString.radius2,
                                                            extractFromString.radius1 * 2,
                                                            extractFromString.radius2 * 2);
                        g.DrawEllipse(pen, rectangle);
                        g.FillEllipse(brush, rectangle);
                        brush.Dispose();
                        pen.Dispose();
                        break;
                    }
            }
        }

        private void ColorPen(string colorType)
        {
            if (colorType == null)
            {
                pen = new Pen(Color.Black);
            }
            else if (colorType.Length == 4)
            {
                pen = new Pen(Color.FromArgb(Convert.ToInt32(255 * extractFromString.colorOpacity),
                                             extractFromString.colorR,
                                             extractFromString.colorG,
                                             extractFromString.colorB));
            }
            else if (colorType.Length == 3)
            {
                pen = new Pen(Color.FromArgb(extractFromString.colorR,
                              extractFromString.colorG,
                              extractFromString.colorB));
            }

        }
        private void ColorSolidBrash(string backColorType)
        {

            if (backColorType == null)
            {
                brush = new SolidBrush(Color.White);
            }
            else if (backColorType.Length == 4)
            {
                brush = new SolidBrush(Color.FromArgb(Convert.ToInt32(255 * extractFromString.backColorOpacity),
                                       extractFromString.backColorR,
                                       extractFromString.backColorG,
                                       extractFromString.backColorB));
            }
            else if (backColorType.Length == 3)
            {
                brush = new SolidBrush(Color.FromArgb(extractFromString.backColorR,
                                       extractFromString.backColorG,
                                       extractFromString.backColorB));
            }

        }
    
    }
}
