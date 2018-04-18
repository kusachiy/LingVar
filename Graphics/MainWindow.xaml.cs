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
            LingVar automobileSpeed = new LingVar();
            automobileSpeed.Name = "Automobile Speed";
            automobileSpeed.Interval = new Interval { LeftBorder = 0, RightBorder = 240 };
            automobileSpeed.Terms.Add(new Term("Стоя на месте",Brushes.Red,  ((s) =>
            {
                double con = .1;
                if (s == 0)
                    return 1;
                double a = con/s;
                return a >= 1 ? 1 : a;
            })));
            automobileSpeed.Terms.Add(new Term("Медленно", Brushes.Orange, ((s) =>
            {
                var p = 30;
                var con = 4;
                double a = (p - Math.Pow((double)(p - s) / con, 2)) / p;
                return a >= 0 ? a : 0;
            })));
            automobileSpeed.Terms.Add(new Term("Средне", Brushes.Yellow, ((s) =>
            {
                var p = 60;
                var con = 3;
                double a = (p - Math.Pow((double)(p - s) / con, 2)) / p;
                return a >= 0 ? a : 0;
            })));
            automobileSpeed.Terms.Add(new Term("Быстро", Brushes.Green, ((s) =>
            {
                var p = 100;
                var con = 4;
                double a = (p - Math.Pow((double)(p - s) / con, 2)) / p;
                return a >= 0 ? a : 0;
            })));
            automobileSpeed.Terms.Add(new Term("Крышеснос", Brushes.SkyBlue, ((s) =>
            {
                var p = 170;
                var con = 5;
                double a = (p - Math.Pow((double)(p - s)/con, 2)) / p;
                return a >= 0 ? a : 0;
            })));
            automobileSpeed.Terms.Add(new Term("Едем в ад", Brushes.Violet, ((s) =>
            {
                var p = 300;
                var con = 8;
                double a = (p - Math.Pow((double)(p - s) / con, 2)) / p;
                return a >= 0 ? a : 0;
            })));
            
            int[] x = new int[automobileSpeed.Interval.RightBorder - automobileSpeed.Interval.LeftBorder];
            for (int i = 0; i < x.Length; i++)
                x[i] = i;
            for (int i = 0; i < automobileSpeed.Terms.Count; i++)
            {
                rnd = new Random(rnd.Next());
                var lg = new LineGraph();
                lines.Children.Add(lg);
                lg.Stroke = automobileSpeed.Terms[i].LineColor;
                lg.Description = automobileSpeed.Terms[i].Name;
                lg.StrokeThickness = 2;
                lg.Plot(x, x.Select(v => automobileSpeed.Terms[i].Function(v)).ToArray());
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

