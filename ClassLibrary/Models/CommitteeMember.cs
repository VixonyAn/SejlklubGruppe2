using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClassLibrary.Models
{
    public class CommitteeMember : Member
    {

        public string Title { get; set;}
        public string Address { get; set; }
        public string PostNr { get; set; }

        public CommitteeMember(string name, string phone, string email, string address, string postNr) : base(name, phone, email)
        {
            Title = "Bestyrelsesmedlem";
            Address = address;
            PostNr = postNr;
        }

        public CommitteeMember(string name, string phone, string email, string address, string postNr, string title) : base(name, phone, email)
        {
            Title = title;
            Address = address;
            PostNr = postNr;
        }

        public override string ToString()
        {
            return base.ToString() + $"\n" +
                $"{Title}\n" +
                $"Adresse: {Address} {PostNr}";
        }
    }
}
