using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Immedia.API.Model
{
    public class ImageModel
    {
        public int ImageId { get; set; }
        public string ImageName { get; set; }
        public string Location { get; set; }
        public DateTime CreatedDate { get; set; }
    }

}
