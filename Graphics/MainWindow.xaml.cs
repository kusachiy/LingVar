using InteractiveDataDisplay.WPF;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace Graphics
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow
    {
        public MainWindow()
        {
            InitializeComponent();
            var cars = FileLoader.ImportWorkflow();
            #region Lingvar Definition
            LingVar PowerPS = new LingVar();
            LingVar Kilometer = new LingVar();
            LingVar Year = new LingVar();
            LingVar Price = new LingVar();
            Random rnd = new Random();

            PowerPS.Name = "Кол-во лошадинных сил";
            PowerPS.Interval = new Interval { LeftBorder = 0, RightBorder = 300 };
            PowerPS.Terms.Add(new Term("мало", Brushes.Orange, ((s) =>
            {
                var p = 50;
                var con = 7.4;
                double a = (p - Math.Pow((p - s) / con, 2)) / p;
                return a >= 0 ? a : 0;
            })));
            PowerPS.Terms.Add(new Term("средне", Brushes.Yellow, ((s) =>
            {
                var p = 150;
                var con = 7.5;
                double a = (p - Math.Pow((p - s) / con, 2)) / p;
                return a >= 0 ? a : 0;
            })));
            PowerPS.Terms.Add(new Term("много", Brushes.Green, ((s) =>
            {
                var p = 250;
                var con = 12.2;
                double a = (p - Math.Pow((p - s) / con, 2)) / p;
                return a >= 0 ? a : 0;
            })));

            Kilometer.Name = "Пробег";
            Kilometer.Interval = new Interval { LeftBorder = 0, RightBorder = 1000000 };
            Kilometer.Terms.Add(new Term("мало", Brushes.Orange, ((s) =>
            {
                var p = 50000;
                var con = 740;
                double a = (p - Math.Pow((p - s) / con, 2)) / p;
                return a >= 0 ? a : 0;
            })));
            Kilometer.Terms.Add(new Term("средне", Brushes.Yellow, ((s) =>
            {
                var p = 175000;
                var con = 750;
                double a = (p - Math.Pow((p - s) / con, 2)) / p;
                return a >= 0 ? a : 0;
            })));
            Kilometer.Terms.Add(new Term("много", Brushes.Green, ((s) =>
            {
                var p = 600000;
                var con = 1810;
                double a = (p - Math.Pow((p - s) / con, 2)) / p;
                return a >= 0 ? a : 0;
            })));

            Year.Name = "Год выпуска";
            Year.Interval = new Interval { LeftBorder = 1930, RightBorder = 2020 };
            Year.Terms.Add(new Term("Старый", Brushes.Orange, ((s) =>
            {
                var p = 60;
                var con = 6.1;
                double a = (p - Math.Pow((p - s) / con, 2)) / p;
                return a >= 0 ? a : 0;
            })));
            Year.Terms.Add(new Term("Средний возраст", Brushes.Yellow, ((s) =>
            {
                var p = 15;
                var con = 2.2;
                double a = (p - Math.Pow((p - s) / con, 2)) / p;
                return a >= 0 ? a : 0;
            })));
            Year.Terms.Add(new Term("Новый", Brushes.Green, ((s) =>
            {
                var p = 5;
                var con = 1.1;
                double a = (p - Math.Pow((p - s) / con, 2)) / p;
                return a >= 0 ? a : 0;
            })));


            Price.Name = "Цена";
            Price.Interval = new Interval { LeftBorder = 0, RightBorder = 50000 };
            Price.Terms.Add(new Term("Дешёвый", Brushes.Orange, ((s) =>
            {
                var p = 1000;
                var con = 101.3;
                double a = (p - Math.Pow((p - s) / con, 2)) / p;
                return a >= 0 ? a : 0;
            })));
            Price.Terms.Add(new Term("Средняя цена", Brushes.Yellow, ((s) =>
            {
                var p = 5000;
                var con = 91.8;
                double a = (p - Math.Pow((p - s) / con, 2)) / p;
                return a >= 0 ? a : 0;
            })));
            Price.Terms.Add(new Term("Дорогой", Brushes.Green, ((s) =>
            {
                var p = 25000;
                var con = 181.5;
                double a = (p - Math.Pow((p - s) / con, 2)) / p;
                return a >= 0 ? a : 0;
            })));

            #endregion

            foreach (var r in cars)
            {
                KnowledgeBase.AddOrConfirmRule
                    (PowerPS.ActiveTerm(r.powerPS),
                    Kilometer.ActiveTerm(r.kilometer),
                     Year.ActiveTerm(r.yearOfRegistration),
                     Price.ActiveTerm(r.price));
            }
            
            var b = KnowledgeBase.Rules;


            var car = new AutoSaleModel()
            {
                powerPS = 140,
                yearOfRegistration = 2007,
                kilometer = 75000
            };

           
             var forec =   KnowledgeBase.ForecastPrice(
                PowerPS.ActiveTerm(car.powerPS),
                Kilometer.ActiveTerm(car.kilometer),
                Year.ActiveTerm(car.yearOfRegistration)
               
                );

            DrawGraph(rnd, Price);
           
        }
        /*
        private void OldRun()
        {
            Random rnd = new Random();
            LingVar kalor = new LingVar();
            LingVar edok = new LingVar();
            LingVar time = new LingVar();


            kalor.Name = "Калорийность";
            kalor.Interval = new Interval { LeftBorder = 0, RightBorder = 3000 };
            kalor.Terms.Add(new Term("мало", Brushes.Orange, ((s) =>
            {
                var p = 500;
                var con = 25;
                double a = (p - Math.Pow((double)(p - s) / con, 2)) / p;
                return a >= 0 ? a : 0;
            })));
            kalor.Terms.Add(new Term("средне", Brushes.Yellow, ((s) =>
            {
                var p = 1500;
                var con = 25;
                double a = (p - Math.Pow((double)(p - s) / con, 2)) / p;
                return a >= 0 ? a : 0;
            })));
            kalor.Terms.Add(new Term("много", Brushes.Green, ((s) =>
            {
                var p = 2500;
                var con = 25;
                double a = (p - Math.Pow((double)(p - s) / con, 2)) / p;
                return a >= 0 ? a : 0;
            })));

            edok.Name = "Количество едоков";
            edok.Interval = new Interval { LeftBorder = 0, RightBorder = 12 };
            edok.Terms.Add(new Term("мало", Brushes.Orange, ((s) =>
            {
                var p = 3;
                var con = 1.5;
                double a = (p - Math.Pow((double)(p - s) / con, 2)) / p;
                return a >= 0 ? a : 0;
            })));
            edok.Terms.Add(new Term("средне", Brushes.Yellow, ((s) =>
            {
                var p = 6;
                var con = 1.5;
                double a = (p - Math.Pow((double)(p - s) / con, 2)) / p;
                return a >= 0 ? a : 0;
            })));
            edok.Terms.Add(new Term("много", Brushes.Green, ((s) =>
            {
                var p = 9;
                var con = 1.5;
                double a = (p - Math.Pow((double)(p - s) / con, 2)) / p;
                return a >= 0 ? a : 0;
            })));

            time.Name = "Продолжительность обеда в минутах";
            time.Interval = new Interval { LeftBorder = 0, RightBorder = 180 };
            time.Terms.Add(new Term("мало", Brushes.Orange, ((s) =>
            {
                var p = 30;
                var con = 6;
                double a = (p - Math.Pow((double)(p - s) / con, 2)) / p;
                return a >= 0 ? a : 0;
            })));
            time.Terms.Add(new Term("средне", Brushes.Yellow, ((s) =>
            {
                var p = 75;
                var con = 6;
                double a = (p - Math.Pow((double)(p - s) / con, 2)) / p;
                return a >= 0 ? a : 0;
            })));
            time.Terms.Add(new Term("много", Brushes.Green, ((s) =>
            {
                var p = 125;
                var con = 6;
                double a = (p - Math.Pow((double)(p - s) / con, 2)) / p;
                return a >= 0 ? a : 0;
            })));
            Title.Text = kalor.Name;
            int[] x = new int[kalor.Interval.RightBorder - kalor.Interval.LeftBorder];
            for (int i = 0; i < x.Length; i++)
                x[i] = i;
            for (int i = 0; i < kalor.Terms.Count; i++)
            {
                rnd = new Random(rnd.Next());
                var lg = new LineGraph();
                lines.Children.Add(lg);
                lg.Stroke = kalor.Terms[i].LineColor;
                lg.Description = kalor.Terms[i].Name;
                lg.StrokeThickness = 3;
                lg.Plot(x, x.Select(v => kalor.Terms[i].Function(v)).ToArray());
            }
            var product = new Product(2000, 3, 60);

            float kalorCoeff = 0, edokCoeff, timeCoeff;

            if (kalor.ActiveTerm(product.Kalor) == "мало")
                kalorCoeff = 6;
            else if (kalor.ActiveTerm(product.Kalor) == "средне")
                kalorCoeff = 3f;
            else
                kalorCoeff = 2;

            if (edok.ActiveTerm(product.Edok) == "мало")
                edokCoeff = 2;
            else if (edok.ActiveTerm(product.Edok) == "средне")
                edokCoeff = 5;
            else
                edokCoeff = 8;

            if (time.ActiveTerm(product.Time) == "мало")
                timeCoeff = 1;
            else if (time.ActiveTerm(product.Time) == "средне")
                timeCoeff = 1.5f;
            else
                timeCoeff = 2;

            var coeff = Math.Min(kalor.ActiveTermCoeff(product.Kalor), edok.ActiveTermCoeff(product.Edok));
            coeff = Math.Min(coeff, time.ActiveTermCoeff(product.Time));
            MessageBox.Show($"Volume: {kalorCoeff * edokCoeff * timeCoeff * 150} g. Coeff:{coeff}");
        }
        */
        private void DrawGraph(Random rnd, LingVar PowerPS)
        {
            Title.Text = PowerPS.Name;
            int[] x = new int[PowerPS.Interval.RightBorder - PowerPS.Interval.LeftBorder];
            for (int i = 0; i < x.Length; i++)
                x[i] = i;
            for (int i = 0; i < PowerPS.Terms.Count; i++)
            {
                rnd = new Random(rnd.Next());
                var lg = new LineGraph();
                lines.Children.Add(lg);
                lg.Stroke = PowerPS.Terms[i].LineColor;
                lg.Description = PowerPS.Terms[i].Name;
                lg.StrokeThickness = 3;
                lg.Plot(x, x.Select(v => PowerPS.Terms[i].Function(v)).ToArray());
            }
        }
    }

    public class VisibilityToCheckedConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            return ((Visibility)value) == Visibility.Visible;
        }

        public object ConvertBack(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            return ((bool)value) ? Visibility.Visible : Visibility.Collapsed;
        }
    }
}

