using BusinessObject.Models;
using DataAccess.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess
{
    internal class MemberDAO
    {
        private static MemberDAO instance = null;
        private static readonly object instancelock = new object();
        private MemberDAO() { }
        public static MemberDAO Instance
        {
            get
            {
                lock (instancelock)
                {
                    if (instance == null)
                    {
                        instance = new MemberDAO();
                    }
                    return instance;
                }
            }
        }

        public IEnumerable<Member> GetAllMembers()
        {
            List<Member> memberList;
            try
            {
                using (var ctx = new WPF_Sale_ManagerContext())
                {
                    memberList = ctx.Members.ToList();
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            return memberList;
        }

        public Member getMemberById(int id)
        {
            Member member = null;
            try
            {
                using (var ctx = new WPF_Sale_ManagerContext())
                {
                    member = ctx.Members.SingleOrDefault(m => m.MemberId == id);
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            return member;
        }

        public Member getMemberByEmail(string email, string password)
        {
            Member member = null;
            try
            {
                using (var ctx = new WPF_Sale_ManagerContext())
                {
                    member = ctx.Members.SingleOrDefault(m => m.Email.Equals(email) && m.Password.Equals(password));
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            return member;
        }

        public void AddMember(Member member)
        {
            try
            {
                Member m = getMemberById(member.MemberId);
                if (m == null)
                {
                    using (var ctx = new WPF_Sale_ManagerContext())
                    {
                        ctx.Members.Add(member);
                        ctx.SaveChanges();
                    }
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public void UpdateMember(Member member)
        {
            try
            {
                Member m = getMemberById(member.MemberId);
                if (m != null)
                {
                    using (var ctx = new WPF_Sale_ManagerContext())
                    {
                        ctx.Entry<Member>(member).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
                        ctx.SaveChanges();
                    }
                }
                else
                {
                    throw new Exception("Member does not exist");
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public void DeleteMember(Member member)
        {
            try
            {
                Member m = getMemberById(member.MemberId);
                if (m != null)
                {
                    using (var ctx = new WPF_Sale_ManagerContext())
                    {
                        ctx.Members.Remove(member);
                        ctx.SaveChanges();
                    }
                }
                else
                {
                    throw new Exception("Member does not exist");
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public IEnumerable<Member> FindAllBy(MemberFilter filter)
        {
            if (filter != null)
            {
                List<Member> memberList;
                try
                {
                    using (var ctx = new WPF_Sale_ManagerContext())
                    {
                        memberList = ctx.Members
                            .Where(member => (filter.MemberId == null || member.MemberId.Equals(filter.MemberId)) &&
                                                (filter.Email == null || member.Email.ToLower().Contains(filter.Email.ToLower())) &&
                                                (filter.CompanyName == null || member.CompanyName.Equals(filter.CompanyName)) &&
                                                (filter.City == null || member.City.Equals(filter.City)) &&
                                                (filter.Country == null || member.Country.Equals(filter.Country))).ToList();
                        return memberList;
                    }
                }
                catch (Exception ex)
                {
                    throw new Exception(ex.Message);
                }
            }
            return GetAllMembers();
        }

        public Member? FindByEmail(string email)
        {
            MemberFilter filter = new MemberFilter();
            filter.Email = email;
            List<Member> memberfound = FindAllBy(filter).ToList();
                return memberfound.FirstOrDefault();
        }
    }
}
