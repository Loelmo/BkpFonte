using System;
using System.Data;
using System.Configuration;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;
using System.Drawing;
using System.Drawing.Imaging;
using System.Drawing.Drawing2D;

namespace PEG.Utilitarios
{
    public class GraficoRadar
    {
        #region Métodos

        #region Gerar
        public Bitmap Gerar(string[,] valor, string[,] arrValorMax, bool mostrarValorArea)
        {
            try
            {
                // Create a Bitmap instance that's 468x60, and a Graphics instance
                const int width = 302, height = 302;

                Bitmap objBitmap = new Bitmap(width, height);
                Graphics objGraphics = Graphics.FromImage(objBitmap);

                ColorConverter cor = new ColorConverter();

                // Create a black background for the border
                objGraphics.FillRectangle(new SolidBrush((Color)cor.ConvertFromString("#f0f0f0")), 0, 0, width, height);
                SolidBrush objBrush = new SolidBrush((Color)cor.ConvertFromString("#ADCCE1"));

                Pen pen = new Pen(Color.Gray);
                pen.DashStyle = DashStyle.Dash;

                Font font = new Font("Arial", 10);

                objGraphics.SmoothingMode = SmoothingMode.AntiAlias;

                Point pointOrigem = new Point(150, 150);

                Point[] point = new Point[8];
                point[0] = new Point(150, 0);
                point[1] = new Point(256, 44);
                point[2] = new Point(300, 150);
                point[3] = new Point(256, 256);
                point[4] = new Point(150, 300);
                point[5] = new Point(44, 256);
                point[6] = new Point(0, 150);
                point[7] = new Point(44, 44);

                Point[] pointValor = new Point[point.Length];
                for (int i = 0; i < point.Length; i++)
                {
                    pointValor[i] = point[i];
                }

                int valorMax = 100;

                for (int i = 0; i <= arrValorMax.GetUpperBound(0); i++)
                {
                    if (int.Parse(arrValorMax[i, 1]) > valorMax)
                    {
                        valorMax = int.Parse(arrValorMax[i, 1]);
                    }
                }

                double valorIntervalo = Convert.ToDouble(valorMax) / 5.0;

                // Área máxima
                objBrush.Color = (Color)cor.ConvertFromString("#aaaaaa");

                int percent = 0;
                for (int i = 0; i <= arrValorMax.GetUpperBound(0); i++)
                {
                    percent = int.Parse(arrValorMax[i, 1]) * 100 / valorMax;

                    switch (i)
                    {
                        case 0:
                            pointValor[i].Y = 150 - (percent * 150 / 100);
                            break;
                        case 1:
                            for (int j = 100; j >= percent; j--)
                            {
                                pointValor[i].X -= 1;
                                pointValor[i].Y += 1;
                            }
                            break;
                        case 2:
                            pointValor[i].X = 150 + (percent * 150 / 100);
                            break;
                        case 3:
                            for (int j = 100; j >= percent; j--)
                            {
                                pointValor[i].X -= 1;
                                pointValor[i].Y -= 1;
                            }
                            break;
                        case 4:
                            pointValor[i].Y = 150 + (percent * 150 / 100);
                            break;
                        case 5:
                            for (int j = 100; j >= percent; j--)
                            {
                                pointValor[i].X += 1;
                                pointValor[i].Y -= 1;
                            }
                            break;
                        case 6:
                            pointValor[i].X = 150 - (percent * 150 / 100);
                            break;
                        case 7:
                            for (int j = 100; j >= percent; j--)
                            {
                                pointValor[i].X += 1;
                                pointValor[i].Y += 1;
                            }
                            break;
                    }
                }

                // Monta área máxima
                objGraphics.FillPolygon(objBrush, pointValor, FillMode.Winding);


                // Área obtida
                pointValor = new Point[point.Length];
                for (int i = 0; i < point.Length; i++)
                {
                    pointValor[i] = point[i];
                }

                string color = "#C7DCEB";
                objBrush.Color = (Color)cor.ConvertFromString(color);
                percent = 0;
                for (int i = 0; i <= valor.GetUpperBound(0); i++)
                {
                    percent = int.Parse(valor[i, 1]) * 100 / valorMax;

                    switch (i)
                    {
                        case 0:
                            pointValor[i].Y = 150 - (percent * 150 / 100);
                            break;
                        case 1:
                            for (int j = 100; j >= percent; j--)
                            {
                                pointValor[i].X -= 1;
                                pointValor[i].Y += 1;
                            }
                            break;
                        case 2:
                            pointValor[i].X = 150 + (percent * 150 / 100);
                            break;
                        case 3:
                            for (int j = 100; j >= percent; j--)
                            {
                                pointValor[i].X -= 1;
                                pointValor[i].Y -= 1;
                            }
                            break;
                        case 4:
                            pointValor[i].Y = 150 + (percent * 150 / 100);
                            break;
                        case 5:
                            for (int j = 100; j >= percent; j--)
                            {
                                pointValor[i].X += 1;
                                pointValor[i].Y -= 1;
                            }
                            break;
                        case 6:
                            pointValor[i].X = 150 - (percent * 150 / 100);
                            break;
                        case 7:
                            for (int j = 100; j >= percent; j--)
                            {
                                pointValor[i].X += 1;
                                pointValor[i].Y += 1;
                            }
                            break;
                    }
                }

                // Monta área obitida
                objGraphics.FillPolygon(objBrush, pointValor, FillMode.Winding);
                Pen pen2 = new Pen(Color.Black);
                pen2.DashStyle = DashStyle.Solid;
                objGraphics.DrawPolygon(pen2, pointValor);
                // Desenha os circulos
                objBrush.Color = Color.Black;
                objGraphics.DrawEllipse(pen, 0, 0, 300, 300);

                double valorMostra = valorMax;
                if (mostrarValorArea)
                {
                    objGraphics.DrawString(valorMostra.ToString("N0"), font, objBrush, 152, 0);
                    objGraphics.DrawString(valorMostra.ToString("N0"), font, objBrush, 275, 150);
                }

                valorMostra -= valorIntervalo;
                objGraphics.DrawEllipse(pen, 30, 30, 240, 240);
                if (mostrarValorArea)
                {
                    objGraphics.DrawString(valorMostra.ToString("N0"), font, objBrush, 152, 30);
                    objGraphics.DrawString(valorMostra.ToString("N0"), font, objBrush, 250, 150);
                }

                valorMostra -= valorIntervalo;
                objGraphics.DrawEllipse(pen, 60, 60, 180, 180);
                if (mostrarValorArea)
                {
                    objGraphics.DrawString(valorMostra.ToString("N0"), font, objBrush, 152, 60);
                    objGraphics.DrawString(valorMostra.ToString("N0"), font, objBrush, 220, 150);
                }

                valorMostra -= valorIntervalo;
                objGraphics.DrawEllipse(pen, 90, 90, 120, 120);
                if (mostrarValorArea)
                {
                    objGraphics.DrawString(valorMostra.ToString("N0"), font, objBrush, 152, 90);
                    objGraphics.DrawString(valorMostra.ToString("N0"), font, objBrush, 190, 150);
                }

                valorMostra -= valorIntervalo;
                objGraphics.DrawEllipse(pen, 120, 120, 60, 60);
                if (mostrarValorArea)
                {
                    objGraphics.DrawString(valorMostra.ToString("N0"), font, objBrush, 152, 120);
                    objGraphics.DrawString(valorMostra.ToString("N0"), font, objBrush, 160, 150);
                }

                // Desenha linhas
                pen.DashStyle = DashStyle.Solid;
                int x = 0;
                int y = 0;
                for (int i = 0; i < point.Length; i++)
                {
                    objGraphics.DrawLine(pen, point[i], pointOrigem);

                    switch (i)
                    {
                        case 0:
                            x = 133;
                            y = 0;
                            break;
                        case 1:
                            x = 234;
                            y = 33;
                            break;
                        case 2:
                            x = 289;
                            y = 135;
                            break;
                        case 3:
                            x = 245;
                            y = 234;
                            break;
                        case 4:
                            x = 152;
                            y = 285;
                            break;
                        case 5:
                            x = 55;
                            y = 245;
                            break;
                        case 6:
                            x = 5;
                            y = 155;
                            break;
                        default:
                            x = 40;
                            y = 50;
                            break;
                    }
                    objGraphics.DrawString(valor[i, 0], font, objBrush, x, y);
                }

                return (objBitmap);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.ToString());
            }
        }
        #endregion

        #endregion
    }
}