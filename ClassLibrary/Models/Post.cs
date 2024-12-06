using System;
using System.Collections.Generic;
using System.Diagnostics.Metrics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;
using ClassLibrary.Interfaces;

namespace ClassLibrary.Models
{
    public class Post : IPost
    {
        public int Id { get; set ; }
        public string Title { get; set ; }
        public string Text { get; set; }
        public Member Writer { get ; set ; }
        public string PostType { get; set; } //Event  /  News    / Sale
        public DateTime PostDate { get; set; }


        public Post()
        {
        }

        public Post(int id, string title, string text, Member writer, string postType)  //normal post
        {
            Id = id;
            Title = title;
            Text = text;
            Writer = writer;
            PostType = postType;
            PostDate = DateTime.Now;
        }

        public override string ToString()
        {
            return $"id: {Id} \n Title: {Title} \n   Writer: {Writer.Name}   Time of Post: {PostDate} \n  it is a {PostType} \n {Text}";
        }
    }
}
