using apicore.Context;
using apicore.Interfaces.Manager;
using apicore.Manager;
using apicore.Models;
using CoreApiResponse;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Linq;
using System.Net;
using System.Reflection;

namespace apicore.Controllers
{
      [Route("api/[controller]/[Action]")]
    [ApiController]
    public class PostController1 : BaseController
    {

         //ApplicationDbContext _dbContext;
        IPostManager _PostManager;
      
        //public PostController1(ApplicationDbContext dbContext)
        //{
        //    _dbContext = dbContext;

        //    _PostManager = new PostManager(dbContext);
        //}

        public PostController1(IPostManager postManager)
        {
            _PostManager = postManager;
        }

        [HttpGet]

        public IActionResult GetAll()
        {
            try { 
            //var posts = _dbContext.Posts.ToList();
            var posts= _PostManager.GetAll().OrderBy(c=>c.CreateDate).ToList();
            //return CustomResult(HttpStatusCode.OK);
              return CustomResult("Data Loded Succesfully",posts);
              }
            catch (Exception ex)
            {
                return  CustomResult(ex.Message,HttpStatusCode.BadRequest);
            }
        }

        //  [HttpGet]
        //public IActionResult GetAlldesc()
        //{
        //    var posts= _PostManager.GetAll().OrderByDescending(c=>c.CreateDate).ToList();
        //      return CustomResult("Data Loded Succesfully",posts);
        //}

        [HttpGet("title")]
        //t
        public IActionResult GetAll( string title)
        {
            try { 
            
                var posts =_PostManager.GetAll(title);
                return CustomResult( "Data loaded done",posts.ToList() );
             }
            catch (Exception ex)
            {
                return  CustomResult(ex.Message,HttpStatusCode.BadRequest);
            }
        }




        [HttpPost ("id")]

         
        public IActionResult GetById( int id)
        {

            try
            {
                 var post = _PostManager.GetById(id);

          if (post == null)
            {
                return CustomResult("Data Not Found",HttpStatusCode.NotFound);
            }

          return CustomResult("Data Found",post);

            }
            catch (Exception ex)
            {
                return  CustomResult(ex.Message,HttpStatusCode.BadRequest);
            }
           
        }

        private IActionResult BadRequest(object massage)
        {
            throw new NotImplementedException();
        }

        [HttpPost]

        public IActionResult Add(Post post)
        {
            try
            {
            post.CreateDate= DateTime.Now;
            bool isSaved=_PostManager.Add(post);
            //_dbContext.Posts.Add(post);
            //bool isSaved= _dbContext.SaveChanges()>0;
            if (isSaved)
            {
               // return Created("",post);
               return CustomResult("post has been created",post);
            }

            return CustomResult("post saved faild",HttpStatusCode.BadRequest);

            }
            catch (Exception ex)
            {
              return  CustomResult(ex.Message,HttpStatusCode.BadRequest);
            }
           

        }

        
          [HttpPut]
        public IActionResult Edit(Post post)
        {

            try
            {
            if (post.Id == 0)
            {

                    //return BadRequest("Id is missing");
                     return  CustomResult("Id is missing",HttpStatusCode.BadRequest);
            }

            bool isUpdate = _PostManager.Update(post);
            if (isUpdate)
            {

                 return  CustomResult("post updated done",post);
            }

            return BadRequest("post updated faild");
        }
            catch (Exception ex)
            {
                return  CustomResult(ex.Message,HttpStatusCode.BadRequest);
            }
        }

        [HttpDelete ("id")]

        public IActionResult Delete(int id)
        {
            try
            {

                 var post=_PostManager.GetById(id);

            if (post == null)
            {
                return CustomResult("Data not found",HttpStatusCode.NotFound);
            }
           bool isDelete=_PostManager.Delete(post);

            if (isDelete)
            {
                return  CustomResult ("post has been deleted.");
            }
            return CursorResult("post Deleted faild");
            }
            catch (Exception ex)
            {
                return  CustomResult(ex.Message,HttpStatusCode.BadRequest);
            }
           

        }

        private IActionResult CursorResult(string v)
        {
            throw new NotImplementedException();
        }
    }
}
