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
            coeff = Math.Min(coeff,    time.ActiveTermCoeff(product.Time));
            MessageBox.Show($"Volume: {kalorCoeff * edokCoeff * timeCoeff * 150} g. Coeff:{coeff}");
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

