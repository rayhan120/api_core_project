using apicore.Models;
using EF.Core.Repository.Interface.Manager;

namespace apicore.Interfaces.Manager
{
    public interface IPostManager:ICommonManager<Post>
    {

        Post GetById(int id);
        ICollection<Post>GetAll(string title);
       
    }
}
