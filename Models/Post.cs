using System.ComponentModel.DataAnnotations;

namespace apicore.Models
{
    public class Post
    {
        public int Id { get; set; }
        [Required (ErrorMessage="please enter title.")]
        public string Title { get; set; }
         [Required (ErrorMessage="please enter description.")]
        public string Description { get; set;}
        public DateTime CreateDate { get; set; } = DateTime.Now;



    }
}
