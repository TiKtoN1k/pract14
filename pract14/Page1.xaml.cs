using Microsoft.SqlServer.Server;
using pract14.pract14DataSetTableAdapters;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading;
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
    /// Логика взаимодействия для Page1.xaml
    /// </summary>
    public partial class Page1 : Page
    {
        uchetTableAdapter uchet = new uchetTableAdapter();
        type_TableAdapter type = new type_TableAdapter();
        public Page1()
        {
            InitializeComponent();
            uchetDTG.ItemsSource = uchet.GetData();
            Type.ItemsSource = type.GetData();
            Type.DisplayMemberPath = "Name";
            Type.SelectedValuePath = "Id";
        }
        private void uchetDTG_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (uchetDTG.SelectedItem != null)
            {

                var item = uchetDTG.SelectedItem as DataRowView;
                Name.Text = (string)item.Row[1];
                Type.SelectedValue = (int)item.Row[3];
                Price.Text = Convert.ToInt32(item.Row[2]).ToString();
            }
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            int id = (int)Type.SelectedValue;
            uchet.InsertQuery(Name.Text, Convert.ToInt32(Price.Text),id);
            uchetDTG.ItemsSource = uchet.GetData();
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            int id = (int)(uchetDTG.SelectedItem as DataRowView).Row[0];
            uchet.DeleteQuery(id);
            uchetDTG.ItemsSource = uchet.GetData();
        }

        private void Button_Click_2(object sender, RoutedEventArgs e)
        {
            var item = uchetDTG.SelectedItem as DataRowView;
            uchet.UpdateQuery(Name.Text, Convert.ToInt32(Price.Text),(int)Type.SelectedValue, (int)item.Row[0]);
            uchetDTG.ItemsSource = uchet.GetData();
        }
     
    
    }

}
