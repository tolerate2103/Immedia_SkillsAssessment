using Immedia.API.Endpoint;
using Immedia.API.Model;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Immedia.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ImageController : ControllerBase
    {

        // Location List Endpoint
        [Route("LocationList")]
        [HttpPost]
        public IActionResult LocationList(AllCriteria criteria)
        {
            var vm = new Location();

            // If search is empty , then return the list 
            if (criteria.Search == "" || criteria == null)
                criteria.Search += "*.".ToString();

            vm.Criteria = criteria;
            try
            {
                vm.Initialise();
                return new JsonResult(vm);
            }
            catch (NullReferenceException ex)
            {
                return BadRequest(ex.Message);
            }
        }


        //ImageList Endpoint
        [Route("ImageList")]
        [HttpPost]
        public IActionResult ImageList(AllCriteria criteria)
        {
            var vm = new Image();
            vm.InitialiseImage();
            return new JsonResult(vm);
        }


        // ImageDetails Endpoint,
        // This method read image data from database 
        [Route("ImageDetail")]
        [HttpPost]
        public IActionResult ImageDetail(int imageId)
        {
            var vm = new ImageDetail();
            vm.LoadImageDetail(imageId);
            return new JsonResult(vm);
        }

    }
}
