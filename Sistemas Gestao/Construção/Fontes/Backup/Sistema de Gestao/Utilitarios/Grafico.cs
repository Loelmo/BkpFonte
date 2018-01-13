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
using System.Data.SqlClient;
using Dundas.Charting.WebControl;
using System.Globalization;
using Vinit.SG.Ent;
using System.Collections.Generic;

namespace Sistema_de_Gestao.Utilitarios
{
    public class Grafico
    {
        #region Métodos
        #region Gerar Gráfico Pizza
        public Chart GerarGraficoPizza(string[,] valorXY)
        {
            Chart chart = new Dundas.Charting.WebControl.Chart();

            #region configuração
            //chart.AnimationDuration = 3;
            //chart.ImageType = ChartImageType.Flash;
            chart.ImageType = ChartImageType.Jpeg;
            chart.Height = new Unit("232px");
            chart.Width = new Unit("560px");
            chart.BorderLineWidth = 0;
            //chart.AnimationTheme = AnimationTheme.Fading;
            chart.BorderLineColor = Color.Black;
            chart.BackColor = (Color)(new ColorConverter().ConvertFromString("#EEF2F4"));
            chart.BackGradientEndColor = Color.White;
            chart.Palette = ChartColorPalette.Dundas;
            #endregion

            #region legenda

            chart.Legends.Add("default1");
            chart.Legends[0].Enabled = false;
            /*
            chart.Legends[0].BorderColor = Color.Black;
            chart.Legends[0].BackColor = Color.Transparent;
            chart.Legends[0].Alignment = StringAlignment.Center;
            */

            #endregion

            #region BorderSkin
            chart.BorderSkin.FrameBackColor = Color.MediumTurquoise;
            chart.BorderSkin.FrameBackGradientEndColor = Color.Teal;
            chart.BorderSkin.PageColor = Color.AliceBlue;
            #endregion

            #region ChartAreas
            chart.ChartAreas.Add("default1");
            chart.ChartAreas[0].BorderColor = Color.Transparent;
            chart.ChartAreas[0].BorderStyle = ChartDashStyle.Solid;
            chart.ChartAreas[0].BackColor = Color.Transparent;
            chart.ChartAreas[0].Area3DStyle.Enable3D = true;
            chart.ChartAreas[0].Area3DStyle.YAngle = 63;
            chart.ChartAreas[0].Area3DStyle.XAngle = 53;
            #endregion

            #region Series
            chart.Series.Clear();
            chart.Series.Add("Series1");
            chart.Series["Series1"].Type = Dundas.Charting.WebControl.SeriesChartType.Pie;
            chart.Series["Series1"].ShowLabelAsValue = true;
            chart.Series["Series1"].ShowInLegend = false;
            chart.Series["Series1"].CustomAttributes = "LabelStyle=Outside";

            for (int i = 0; i <= valorXY.GetUpperBound(0); i++)
            {
                chart.Series["Series1"].Points.AddY(int.Parse(valorXY[i, 0]));
                chart.Series["Series1"].Points[chart.Series["Series1"].Points.Count - 1].Label = valorXY[i, 2] + System.Environment.NewLine + valorXY[i, 1];
            }

            chart.DataBind();
            #endregion

            return chart;
        }
        #endregion

        #region Gerar Gráfico Coluna
        public Chart GerarGraficoColuna(string[,] valorXY)
        {
            return (GerarGraficoColuna(valorXY, true));
        }

        public Chart GerarGraficoColuna(string[,] valorXY, bool isPorcentagem)
        {
            Chart chart = new Dundas.Charting.WebControl.Chart();

            #region configuração
            chart.ImageType = ChartImageType.Jpeg;
            chart.Height = new Unit("232px");
            chart.Width = new Unit("560px");
            chart.BorderLineWidth = 0;
            chart.BorderLineColor = Color.Transparent;
            chart.BackColor = (Color)(new ColorConverter().ConvertFromString("#EEF2F4"));
            chart.BackGradientEndColor = Color.White;
            chart.Palette = ChartColorPalette.Dundas;
            #endregion

            #region legenda

            chart.Legends.Add("default1");
            chart.Legends[0].Enabled = false;
            /*
            chart.Legends[0].BorderColor = Color.Black;
            chart.Legends[0].BackColor = Color.Transparent;
            chart.Legends[0].Alignment = StringAlignment.Center;
            */
            #endregion

            #region BorderSkin
            chart.BorderSkin.FrameBackColor = Color.MediumTurquoise;
            chart.BorderSkin.FrameBackGradientEndColor = Color.Teal;
            chart.BorderSkin.PageColor = Color.AliceBlue;
            #endregion

            #region ChartAreas
            chart.ChartAreas.Add("default1");
            chart.ChartAreas[0].BorderStyle = ChartDashStyle.NotSet;
            chart.ChartAreas[0].BackColor = Color.White;
            chart.ChartAreas[0].ShadowOffset = 2;

            chart.ChartAreas[0].Area3DStyle.Enable3D = true;
            chart.ChartAreas[0].Area3DStyle.YAngle = 15;
            chart.ChartAreas[0].Area3DStyle.XAngle = 15;
            chart.ChartAreas[0].Area3DStyle.WallWidth = 2;

            chart.ChartAreas[0].AxisY.MajorGrid.LineColor = Color.Silver;
            chart.ChartAreas[0].AxisY.MinorGrid.LineColor = Color.Silver;

            if (isPorcentagem)
            {
                chart.ChartAreas[0].AxisY.LabelStyle.Format = "P0";
            }

            chart.ChartAreas[0].AxisY2.MajorGrid.LineColor = Color.Silver;
            chart.ChartAreas[0].AxisY2.MinorGrid.LineColor = Color.Silver;

            chart.ChartAreas[0].AxisX2.MajorGrid.LineColor = Color.Silver;
            chart.ChartAreas[0].AxisX2.MinorGrid.LineColor = Color.Silver;

            chart.ChartAreas[0].AxisX.MajorGrid.LineColor = Color.Silver;
            chart.ChartAreas[0].AxisX.MinorGrid.LineColor = Color.Silver;
            #endregion

            #region Series
            chart.Series.Clear();

            for (int i = 0; i <= valorXY.GetUpperBound(0); i++)
            {
                string serie = "Series" + i.ToString();

                chart.Series.Add(serie);

                chart.Series[serie].ShadowOffset = 2;
                chart.Series[serie].Type = Dundas.Charting.WebControl.SeriesChartType.Column;
                //chart.Series[serie].LegendText = valorXY[i, 2];
                if (valorXY[i, 2] != "")
                {
                    chart.Series[serie].AxisLabel = valorXY[i, 2];
                }

                chart.Series[serie].Points.AddXY(i + 1, int.Parse(valorXY[i, 0]));//(int.Parse(valorXY[i, 0]) == 0 ? 1 : int.Parse(valorXY[i, 0])));

                chart.Series[serie].Points[chart.Series[serie].Points.Count - 1].Label = valorXY[i, 1];
                chart.Series[serie].Points[chart.Series[serie].Points.Count - 1].LegendText = valorXY[i, 2];
            }

            chart.DataBind();
            #endregion

            return chart;
        }

        public Chart GerarGraficoColuna(string[, ,] valorXY, bool isPorcentagem, double maior_valor)
        {
            Chart chart = new Dundas.Charting.WebControl.Chart();

            #region configuração
            chart.ImageType = ChartImageType.Jpeg;
            chart.Height = new Unit("332px");
            chart.Width = new Unit("900px");
            chart.BorderLineWidth = 0;
            chart.BorderLineColor = Color.Transparent;
            chart.BackColor = (Color)(new ColorConverter().ConvertFromString("#EEF2F4"));
            chart.BackGradientEndColor = Color.White;
            chart.Palette = ChartColorPalette.Dundas;
            #endregion

            #region legenda

            chart.Legends.Add("default1");
            chart.Legends[0].Enabled = true;
            /*chart.Legends[0].Position.Y = float.Parse(chart.Height.Value.ToString()) - (chart.Legends[0].Position.Height + 10);
            chart.Legends[0].Position.X = (float.Parse(chart.Width.Value.ToString()) - (chart.Legends[0].Position.Width + 10))/2;
            chart.Legends[0].Position.Width = float.Parse( chart.Width.Value.ToString());*/


            chart.Legends[0].BorderColor = Color.Black;
            chart.Legends[0].BackColor = Color.Transparent;
            chart.Legends[0].Alignment = StringAlignment.Center;

            #endregion

            #region BorderSkin
            chart.BorderSkin.FrameBackColor = Color.MediumTurquoise;
            chart.BorderSkin.FrameBackGradientEndColor = Color.Teal;
            chart.BorderSkin.PageColor = Color.AliceBlue;
            #endregion

            #region ChartAreas
            chart.ChartAreas.Add("default1");
            chart.ChartAreas[0].BorderStyle = ChartDashStyle.NotSet;
            chart.ChartAreas[0].BackColor = Color.White;
            chart.ChartAreas[0].ShadowOffset = 2;

            chart.ChartAreas[0].Area3DStyle.Enable3D = true;
            chart.ChartAreas[0].Area3DStyle.YAngle = 15;
            chart.ChartAreas[0].Area3DStyle.XAngle = 15;
            chart.ChartAreas[0].Area3DStyle.WallWidth = 2;

            chart.ChartAreas[0].AxisY.MajorGrid.LineColor = Color.Silver;
            chart.ChartAreas[0].AxisY.MinorGrid.LineColor = Color.Silver;

            if (isPorcentagem)
            {
                chart.ChartAreas[0].AxisY.LabelStyle.Format = "P0";
                chart.ChartAreas[0].AxisY.Interval = 10;

                if (maior_valor > 70)
                    chart.ChartAreas[0].AxisY.Maximum = 100;
            }

            chart.ChartAreas[0].AxisY2.MajorGrid.LineColor = Color.Silver;
            chart.ChartAreas[0].AxisY2.MinorGrid.LineColor = Color.Silver;

            chart.ChartAreas[0].AxisX2.MajorGrid.LineColor = Color.Silver;
            chart.ChartAreas[0].AxisX2.MinorGrid.LineColor = Color.Silver;

            chart.ChartAreas[0].AxisX.MajorGrid.LineColor = Color.Silver;
            chart.ChartAreas[0].AxisX.MinorGrid.LineColor = Color.Silver;
            chart.ChartAreas[0].AxisX.Interval = 1;
            #endregion

            #region Series
            chart.Series.Clear();

            for (int i = 0; i <= valorXY.GetUpperBound(0); i++)
            {
                string serie = "Series" + i.ToString();

                chart.Series.Add(serie);

                chart.Series[serie].ShadowOffset = 2;
                chart.Series[serie].Type = Dundas.Charting.WebControl.SeriesChartType.Column;

                switch (i)
                {
                    case 0:
                        chart.Series[serie].LegendText = "Inscritas";
                        break;
                    case 1:
                        chart.Series[serie].LegendText = "Candidatas";
                        break;
                    case 2:
                        chart.Series[serie].LegendText = "Classificadas";
                        break;
                    case 3:
                        chart.Series[serie].LegendText = "Finalistas Gestão";
                        break;
                    case 4:
                        chart.Series[serie].LegendText = "Finalistas Responsabilidade Social";
                        break;
                    case 5:
                        chart.Series[serie].LegendText = "Finalistas Inovação";
                        break;
                    case 6:
                        chart.Series[serie].LegendText = "Vencedora Gestão";
                        break;
                    case 7:
                        chart.Series[serie].LegendText = "Vencedora Responsabilidade Social";
                        break;
                    case 8:
                        chart.Series[serie].LegendText = "Vencedora Inovação";
                        break;
                }

                for (int j = 0; j <= valorXY.GetUpperBound(1); j++)
                {

                    if (!string.IsNullOrEmpty(valorXY[i, j, 0]))
                        chart.Series[serie].Points.AddXY(j + 1, double.Parse(valorXY[i, j, 0]));//(int.Parse(valorXY[i, 0]) == 0 ? 1 : int.Parse(valorXY[i, 0])));
                    else
                        chart.Series[serie].Points.AddXY(j + 1, 0);

                    chart.Series[serie].Points[chart.Series[serie].Points.Count - 1].Label = valorXY[i, j, 1];


                    if (valorXY[i, j, 2] != "")
                    {
                        chart.Series[serie].Points[chart.Series[serie].Points.Count - 1].AxisLabel = valorXY[i, j, 2];
                    }

                    if (valorXY.GetUpperBound(2) == 3)
                        chart.Series[serie].Points[chart.Series[serie].Points.Count - 1].ToolTip = valorXY[i, j, 3];
                    else
                    {
                        chart.Series[serie].Points[chart.Series[serie].Points.Count - 1].ToolTip = valorXY[i, j, 1];
                    }
                }
            }

            chart.DataBind();
            #endregion

            return chart;
        }
        #endregion

        #region Gerar Gráfico Linha
        public Chart GerarGraficoLinha(string[,] valorXY, string labelX, string labelY)
        {
            return (GerarGraficoLinha(valorXY, labelX, labelY, true, 10.0));
        }

        public Chart GerarGraficoLinha(string[,] valorXY, string labelX, string labelY, double limiteGrafico)
        {
            return (GerarGraficoLinha(valorXY, labelX, labelY, true, limiteGrafico));
        }

        public Chart GerarGraficoLinha(string[,] valorXY, string labelX, string labelY, bool isPorcentagem, double limiteGrafico)
        {
            Chart chart = new Dundas.Charting.WebControl.Chart();

            #region configuração
            chart.ImageType = ChartImageType.Jpeg;
            chart.Height = new Unit("300px");
            chart.Width = new Unit("800px");
            chart.BorderLineWidth = 0;
            chart.BorderLineColor = Color.Transparent;
            //chart.BackColor = (Color)(new ColorConverter().ConvertFromString("#EEF2F4"));
            chart.BackColor = (Color)(new ColorConverter().ConvertFromString("#FFFFFF"));
            chart.BackGradientEndColor = Color.White;
            chart.Palette = ChartColorPalette.Dundas;
            #endregion

            #region legenda

            chart.Legends.Add("default1");
            chart.Legends[0].Enabled = false;
            /*
            chart.Legends[0].BorderColor = Color.Black;
            chart.Legends[0].BackColor = Color.Transparent;
            chart.Legends[0].Alignment = StringAlignment.Center;
            */
            #endregion

            #region BorderSkin
            chart.BorderSkin.FrameBackColor = Color.MediumTurquoise;
            chart.BorderSkin.FrameBackGradientEndColor = Color.Teal;
            chart.BorderSkin.PageColor = Color.AliceBlue;
            #endregion

            #region ChartAreas
            chart.ChartAreas.Add("default1");
            chart.ChartAreas[0].BorderStyle = ChartDashStyle.NotSet;
            chart.ChartAreas[0].BackColor = Color.White;
            chart.ChartAreas[0].ShadowOffset = 0;

            chart.ChartAreas[0].Area3DStyle.Enable3D = false;
            chart.ChartAreas[0].Area3DStyle.YAngle = 0;
            chart.ChartAreas[0].Area3DStyle.XAngle = 0;
            chart.ChartAreas[0].Area3DStyle.WallWidth = 0;

            chart.ChartAreas[0].AxisY.LabelStyle.Font = new Font("Arial", 10);
            chart.ChartAreas[0].AxisX.LabelStyle.Font = new Font("Arial", 8);

            chart.ChartAreas[0].AxisY.MajorGrid.LineColor = Color.Silver;
            chart.ChartAreas[0].AxisY.MinorGrid.LineColor = Color.Silver;

            if (isPorcentagem)
            {
                chart.ChartAreas[0].AxisY.LabelStyle.Format = "P1";
            }

            chart.ChartAreas[0].AxisY2.MajorGrid.LineColor = Color.Silver;
            chart.ChartAreas[0].AxisY2.MinorGrid.LineColor = Color.Silver;

            chart.ChartAreas[0].AxisX2.MajorGrid.LineColor = Color.Silver;
            chart.ChartAreas[0].AxisX2.MinorGrid.LineColor = Color.Silver;

            chart.ChartAreas[0].AxisX.MajorGrid.LineColor = Color.Silver;
            chart.ChartAreas[0].AxisX.MinorGrid.LineColor = Color.Silver;
            #endregion

            #region Series
            chart.Series.Clear();

            string serie = "Series";
            chart.Series.Add(serie);

            chart.Series[serie].ShadowOffset = 0;
            chart.Series[serie].Type = Dundas.Charting.WebControl.SeriesChartType.Line;
            chart.Series[serie].MarkerStyle = MarkerStyle.Circle;

            chart.ChartAreas[0].AxisY.Interval = 0.0;
            chart.ChartAreas[0].AxisY.Maximum = limiteGrafico;

            for (int i = 0; i <= valorXY.GetUpperBound(0); i++)
            {
                chart.Series[serie].Points.AddXY(i + 1, double.Parse(valorXY[i, 0]));

                chart.Series[serie].Points[chart.Series[serie].Points.Count - 1].Label = valorXY[i, 1];
                chart.Series[serie].Points[chart.Series[serie].Points.Count - 1].LegendText = valorXY[i, 2];
                chart.Series[serie].Points[chart.Series[serie].Points.Count - 1].AxisLabel = valorXY[i, 2];
            }

            chart.ChartAreas[0].AxisX.Title = labelX;
            chart.ChartAreas[0].AxisX.TitleFont = new Font("Arial", 10, FontStyle.Bold);

            chart.ChartAreas[0].AxisY.Title = labelY;
            chart.ChartAreas[0].AxisY.TitleFont = new Font("Arial", 10, FontStyle.Bold);

            chart.DataBind();
            #endregion

            return chart;
        }
        #endregion
        #endregion
    }
}