using System;
using System.Collections.Generic;
using System.Diagnostics.Metrics;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using BusinessObject.Models;

namespace DataAccess.Repository
{
    public interface IMemberRepository
    {
        IEnumerable<Member> GetAllMembers();
        void AddMember(Member member);
        void DeleteMember(Member member);
        void UpdateMember(Member member);
        Member GetMemberById(int id);
        Member GetMemberByEmail(string email, string password);
    }
}
