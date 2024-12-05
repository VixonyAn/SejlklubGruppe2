using ClassLibrary.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClassLibrary.Interfaces
{
    public interface IPostRepository
    {
        List<Post> GetAll();
        public int Count { get; }
        void Add(Post post);
        void Update(Post post);
        void Delete(int id);
        void PrintAllPosts();

    }
}
