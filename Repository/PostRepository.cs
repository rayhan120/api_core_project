using apicore.Context;
using apicore.Interfaces.Repository;
using apicore.Models;
using EF.Core.Repository.Repository;
using Microsoft.EntityFrameworkCore;

namespace apicore.Repository
{
    public class PostRepository : CommonRepository<Post>, IpostRepository
    {

        public PostRepository(ApplicationDbContext dbContext) : base(dbContext)
        {
        }
    }
}
