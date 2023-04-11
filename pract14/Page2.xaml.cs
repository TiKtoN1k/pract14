using pract14.pract14DataSetTableAdapters;
using System;
using System.Collections.Generic;
using System.Data;
using System.Diagnostics;
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

namespace pract14
{
    /// <summary>
    /// Логика взаимодействия для Page2.xaml
    /// </summary>
    public partial class Page2 : Page
    {
        type_TableAdapter type = new type_TableAdapter();
        public Page2()
        {
            InitializeComponent();
            typeDTG.ItemsSource = type.GetData();
        }
        private void typeDTG_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (typeDTG.SelectedItem != null)
            {

                var item = typeDTG.SelectedItem as DataRowView;
                Name.Text = (string)item.Row[1];
            }
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            type.InsertQuery(Name.Text);
            typeDTG.ItemsSource = type.GetData();
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            int id = (int)(typeDTG.SelectedItem as DataRowView).Row[0];
            type.DeleteQuery(id);
            typeDTG.ItemsSource = type.GetData();
        }

        private void Button_Click_2(object sender, RoutedEventArgs e)
        {
            var item = typeDTG.SelectedItem as DataRowView;
            type.UpdateQuery(Name.Text, (int)item.Row[0]);
            typeDTG.ItemsSource = type.GetData();
        }
    }
}
