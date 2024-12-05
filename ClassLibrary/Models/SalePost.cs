using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClassLibrary.Models
{
    public class SalePost:Post
    {
        int Price { get; set; }
        public SalePost(int id, string title, string text, Member writer, string postType, DateTime postDate, int price)
        {
            Id = id;
            Title = title;
            Text = text;
            Writer = writer;
            PostType = postType;
            PostDate = postDate;
            Price = price;
        }
        public override string ToString()
        {
            return base.ToString() + " price= " + Price;
        }
    }
}
