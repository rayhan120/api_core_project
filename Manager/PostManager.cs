using apicore.Context;
using apicore.Interfaces.Manager;
using apicore.Models;
using apicore.Repository;
using EF.Core.Repository.Interface.Repository;
using EF.Core.Repository.Manager;

namespace apicore.Manager
{
    public class PostManager : CommonManager<Post>, IPostManager
    {
        public PostManager(ApplicationDbContext _dbContext) : base(new PostRepository(_dbContext))
        {

        }

        public ICollection<Post> GetAll(string title)
        {
            return Get(c=>c.Title.ToLower()==title.ToLower());
        }

        public Post GetById(int id)
        {
          
            return GetFirstOrDefault(x=>x.Id == id);
        }
    }
}
