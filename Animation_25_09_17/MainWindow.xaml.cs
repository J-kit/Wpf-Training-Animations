using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows;
using System.Windows.Input;

namespace Animation_25_09_17
{
    /// <summary>
    /// Interaktionslogik für MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private cKreis oKreis = new cKreis();

        private ActList<cKreis> Kreise = new ActList<cKreis>();

        private IEnumerable<cKreis> SelectedKreise => Kreise.Where(m => lbxKreise.SelectedItems.Cast<int>().Contains(m.KreisId));

        public MainWindow()
        {
            InitializeComponent();

            Kreise.OnItemAdd = x => lbxKreise.Items.Add(x.KreisId);

            butAnzeigen.Click += (_, __) => SelectedKreise.ForEach(x => x.Anzeigen(leinwand));

            butNachLinks.Click += (_, __) => SelectedKreise.ForEach(x => x.NachLinks());
            butNachRechts.Click += (_, __) => SelectedKreise.ForEach(x => x.NachRechts());

            butNachOben.Click += (_, __) => SelectedKreise.ForEach(x => x.NachOben());
            butNachUnten.Click += (_, __) => SelectedKreise.ForEach(x => x.NachUnten());
        }

        private void leinwand_MouseDown(object sender, MouseButtonEventArgs e)
        {
            var cKreis = new cKreis
            {
                LinksOben = new Point
                {
                    X = e.GetPosition(leinwand).X - 30,
                    Y = e.GetPosition(leinwand).Y - 30,
                }
            };

            cKreis.Anzeigen(leinwand);
            Kreise.Add(cKreis);
        }
    }

    public class ActList<T> : List<T>
    {
        public Action<T> OnItemAdd;

        public new void Add(T obj)
        {
            base.Add(obj);
            OnItemAdd?.Invoke(obj);
        }

        public new void AddRange(IEnumerable<T> obj)
        {
            base.AddRange(obj);
            obj.ForEach(x => OnItemAdd?.Invoke(x));
        }
    }

    public static class IEnumExt
    {
        public static void ForEach<T>(this IEnumerable<T> objs, Action<T> evalFunc)
        {
            if (objs == null || evalFunc == default(Action<T>))
            {
                return;
            }
            foreach (var item in objs)
            {
                evalFunc(item);
            }
        }
    }
}