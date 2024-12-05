using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ClassLibrary.Models;

namespace ClassLibrary.Interfaces
{
    public interface IPost
    {
        int Id { get; set; }
        string Title { get; set; }
        string Text { get; set; }
        Member Writer { get; set; }
        string PostType {  get; set; }
        DateTime PostDate {  get; set; }
    }
}
