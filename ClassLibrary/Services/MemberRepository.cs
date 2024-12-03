using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ClassLibrary.Interfaces;

namespace ClassLibrary.Services
{
    public class MemberRepository : IMemberRepository
    {
        public void AddMember(string name, string phone, string email)
        {
            throw new NotImplementedException();
        }

        public void EditMember(string phone)
        {
            throw new NotImplementedException();
        }

        public IMember GetMember(string phone)
        {
            throw new NotImplementedException();
        }

        public void RemoveMember()
        {
            throw new NotImplementedException();
        }
    }
}
