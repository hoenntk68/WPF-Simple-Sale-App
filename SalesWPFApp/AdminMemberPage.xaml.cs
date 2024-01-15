using BusinessObject.Models;
using DataAccess.Model;
using DataAccess.Repository;
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

namespace SalesWPFApp
{
    /// <summary>
    /// Interaction logic for AdminMemberPage.xaml
    /// </summary>
    public partial class AdminMemberPage : Page
    {
        private readonly IMemberRepository memberRepository;
        public AdminMemberPage(IMemberRepository _memberRepository)
        {
            InitializeComponent();
            this.memberRepository = _memberRepository;
            this.listView.SelectionChanged += ListView_SelectionChanged;
        }


        private void Page_Loaded(object sender, RoutedEventArgs e)
        {
            listView.ItemsSource = memberRepository.GetAllMembers();
        }

        private void Button_OpenCreate(object sender, RoutedEventArgs e)
        {
            AdminMemberCreateWindow adminMemberCreate = new AdminMemberCreateWindow(this, null, memberRepository);
            adminMemberCreate.Show();
        }

        public void RefreshListView()
        {
            listView.ItemsSource = memberRepository.GetAllMembers();
        }

        private void ListView_SizeChanged(object sender, SizeChangedEventArgs e)
        {
            ListView? listView = sender as ListView;
            GridView? gridView = listView != null ? listView.View as GridView : null;

            var width = listView != null ? listView.ActualWidth - SystemParameters.VerticalScrollBarWidth : this.Width;

            var column1 = 0.1;
            var column2 = 0.2;
            var column3 = 0.2;
            var column4 = 0.2;
            var column5 = 0.1;
            var column6 = 0.2;

            if (gridView != null && width >= 0)
            {
                gridView.Columns[0].Width = width * column1;
                gridView.Columns[1].Width = width * column2;
                gridView.Columns[2].Width = width * column3;
                gridView.Columns[3].Width = width * column4;
                gridView.Columns[4].Width = width * column5;
                gridView.Columns[5].Width = width * column6;
            }
        }

        private void Button_Reload(object sender, RoutedEventArgs e)
        {
            listView.ItemsSource = memberRepository.GetAllMembers();
        }

        private void Button_Delete(object sender, RoutedEventArgs e)
        {
            MessageBoxResult messageBoxResult = MessageBox.Show("Do you wan't remove member seledted?", "Remove member", MessageBoxButton.YesNo);
            if (messageBoxResult == MessageBoxResult.Yes)
            {
                List<Member> members = listView.SelectedItems.Cast<Member>().ToList();
                members.ForEach(member => memberRepository.DeleteMember(member));
                listView.ItemsSource = memberRepository.GetAllMembers();
            }
        }

        private void Button_Search(object sender, RoutedEventArgs e)
        {
            int? id = !String.IsNullOrEmpty(txtId.Text) ? int.Parse(txtId.Text) : null;
            string? email = !String.IsNullOrEmpty(txtEmail.Text) ? txtEmail.Text : null;
            string? companyName = !String.IsNullOrEmpty(txtCompanyName.Text) ? txtCompanyName.Text : null;
            string? city = !String.IsNullOrEmpty(txtCity.Text) ? txtCity.Text : null;
            string? country = !String.IsNullOrEmpty(txtCountry.Text) ? txtCountry.Text : null;

            MemberFilter memberFilter = new MemberFilter();
            memberFilter.MemberId = id;
            memberFilter.Email = email;
            memberFilter.CompanyName = companyName;
            memberFilter.City = city;
            memberFilter.Country = country;

            listView.ItemsSource = memberRepository.FindAllBy(memberFilter);
        }
        private void Button_Edit(object sender, RoutedEventArgs e)
        {
            int count = listView.SelectedItems.Count;
            if (count > 0)
            {
                List<Member> products = listView.SelectedItems.Cast<Member>().ToList();
                products.ForEach(member =>
                {
                    AdminMemberCreateWindow admimMemberCreate = new AdminMemberCreateWindow(this, member, memberRepository);
                    admimMemberCreate.Show();
                });
            }
            else
            {
                MessageBox.Show("Plase select member");
            }
        }

        private void ListViewItem_Selected(object sender, RoutedEventArgs e)
        {

        }

        private void ListView_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            int count = listView.SelectedItems.Count;
            if (count > 0)
            {
                btnEdit.IsEnabled = true;
                btnDelete.IsEnabled = true;
            }
            else
            {
                btnEdit.IsEnabled = false;
                btnDelete.IsEnabled = false;
            }
        }
    }
}
