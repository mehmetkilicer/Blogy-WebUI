using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Blogy.DtoLayer.CommentDtos
{
    public class SendCommentDto
    {
        public string Message { get; set; }
        public int ArticleID { get; set; }
        public string ImgUrl { get; set; }
    }
}
