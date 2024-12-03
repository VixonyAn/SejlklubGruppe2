using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClassLibrary.Interfaces
{
    public interface IMemberRepository
    {
        void AddMember(string name, string phone, string email);

        IMember GetMember(string phone);

        void EditMember(string phone);


        void RemoveMember();

    }
}
