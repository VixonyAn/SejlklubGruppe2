using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClassLibrary.Interfaces
{
    public interface IMemberRepository
    {
        void AddMember(IMember member);
        void AddMember(string name, string phone, string email);

        IMember GetMemberByEmail(string email);
        IMember GetMemberByName(string name);
        IMember GetMemberByPhone(string phone);

        List<IMember> GetAll();

        void EditMember(string name, string phone, string email, string oldEmail);


        void RemoveMember(string email);

    }
}
