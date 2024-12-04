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

        IMember GetMemberByName(string name);
        IMember GetMemberByPhone(string phone);
        IMember GetMemberByMail(string email);

        void EditMember(string oldName, string newName, string phone, string email);


        void RemoveMember(string name);

    }
}
