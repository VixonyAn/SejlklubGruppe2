using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClassLibrary.Models
{
    public class NewsPost:Post
    {


        public NewsPost(int id, string title, string text, Member writer, string postType, DateTime postDate)  //news post
        {
            Id = id;
            Title = title;
            Text = text;
            Writer = writer;
            PostType = postType;
            PostDate = postDate;
        }
        public override string ToString()
        {
            return base.ToString();
        }
    }
}
