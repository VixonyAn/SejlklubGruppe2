using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ClassLibrary.Interfaces;
using ClassLibrary.Models;

namespace ClassLibrary.Services
{
    public class PostRepository : IPostRepository
    {
        private Dictionary<int, Post> _posts = new Dictionary<int, Post>();
        public int Count { get { return _posts.Count; } }

        public void Add(Post post)
        {
            _posts.Add(Count+1, post);
        }

        public void Delete(int id)
        {
            _posts.Remove(id);
        }

        public List<Post> GetAll()
        {
            return _posts.Values.ToList();
        }

        public void PrintAllPosts()
        {
            Console.WriteLine("\n liste af alle posts \n -");
            foreach (Post p in _posts.Values)
            {
                Console.WriteLine();
                Console.WriteLine(p);
            }
            Console.WriteLine("\n liste sluttede \n ");
        }

        public void Update(Post post)
        {
            Post postToUpdate = post;
            Delete(post.Id);
            _posts.Add(post.Id, postToUpdate);
        }
    }
}
