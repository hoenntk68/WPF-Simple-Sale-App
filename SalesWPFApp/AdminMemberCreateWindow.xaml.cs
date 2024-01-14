using BusinessObject.Models;
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
using System.Windows.Shapes;

namespace SalesWPFApp
{
    /// <summary>
    /// Interaction logic for AdminMemberCreateWindow.xaml
    /// </summary>
    public partial class AdminMemberCreateWindow : Window
    {
        private readonly IMemberRepository memberRepository;
        private readonly AdminMemberPage adminMemberPage;
        private Member? member;
        public AdminMemberCreateWindow(AdminMemberPage _adminMemberPage, Member? _member, IMemberRepository _memberRepository)
        {
            this.memberRepository = _memberRepository;
            this.adminMemberPage = _adminMemberPage;
            this.member = _member;
            InitializeComponent();
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            if (member != null)
            {
                txtBoxEmail.Text = member.Email;
                txtBoxCompanyName.Text = member.CompanyName;
                txtBoxCity.Text = member.City;
                txtBoxCountry.Text = member.Country;
                txtBoxPassword.Text = member.Password;
                txtBoxId.Text = member.MemberId.ToString();
                txtBoxId.Visibility = Visibility.Visible;
                labelId.Visibility = Visibility.Visible;
                btn.Content = "Update";
                this.Height = 550;
            }
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            string email = txtBoxEmail.Text;
            string companyName = txtBoxCompanyName.Text;
            string city = txtBoxCity.Text;
            string country = txtBoxCountry.Text;
            string password = txtBoxPassword.Text;

            Member? p = null;
            if (member != null)
            {
                p = member;
            }
            else
            {
                p = new Member();
            }
            p.Email = email;
            p.CompanyName = companyName;
            p.City = city;
            p.Country = country;
            p.Password = password;
            if (member != null)
            {
                memberRepository.UpdateMember(p);
            }
            else
            {
                memberRepository.AddMember(p);
            }
            this.Close();
            adminMemberPage.RefreshListView();
        }
    }
}
