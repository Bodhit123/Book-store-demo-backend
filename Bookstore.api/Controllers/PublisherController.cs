using Bookstore.Models.ModelData;
using Bookstore.Models.Models;
using Bookstore.Repository;
using Microsoft.AspNetCore.Mvc;
using System.Linq;
using System.Net;

namespace Bookstore.api.Controllers
{
    public class PublisherController : ControllerBase
    {
        PublisherRepository _publisherRepository = new PublisherRepository();

        [Route("list")]
        [HttpGet]
        [ProducesResponseType(typeof(ListResponse<PublisherModel>), (int)HttpStatusCode.OK)]
        public IActionResult GetPublishetrs(string keyword, int pageIndex = 1, int pageSize = 10)
        {

            var publishers = _publisherRepository.GetPublishers(pageIndex, pageSize, keyword);
            ListResponse<PublisherModel> listResponse = new ListResponse<PublisherModel>()
            {
                Results = publishers.Results.Select(c => new PublisherModel(c)),
                TotalRecords = publishers.TotalRecords,
            };

            return Ok(listResponse);
        }
        [Route("{id}")]
        [HttpGet]

        public IActionResult GetPublisher(int id) 
        {
            var publisher = _publisherRepository.GetPublisher(id);
            PublisherModel publisherModel = new PublisherModel(publisher);
            return Ok(publisherModel);
        }

        [Route("add")]
        [HttpPost]
        [ProducesResponseType(typeof(PublisherModel), (int)HttpStatusCode.OK)]
        [ProducesResponseType(typeof(BadRequestObjectResult), (int)HttpStatusCode.BadRequest)]
        public IActionResult AddPublisher(PublisherModel model)
        {
            if (model == null)
                return BadRequest("Model is null");

            Publisher publisher = new Publisher()
            {
                Id = model.Id,
                Name = model.Name
            };
            var response = _publisherRepository.AddPublisher(publisher);
            PublisherModel publisherModel = new PublisherModel(response);

            return Ok(publisherModel);
        }
        public IActionResult UpdatePublisher(PublisherModel model)
        {
            if (model == null)
                return BadRequest("Model is null");

            Publisher publisher = new Publisher()
            {
                Id = model.Id,
                Name = model.Name
            };
            var response = _publisherRepository.UpdatePublisher(publisher);
            PublisherModel publisherModel = new PublisherModel(response);

            return Ok(publisherModel);
        }
        [Route("delete/{id}")]
        [HttpDelete]
        [ProducesResponseType(typeof(bool), (int)HttpStatusCode.OK)]
        [ProducesResponseType(typeof(BadRequestObjectResult), (int)HttpStatusCode.BadRequest)]
        public IActionResult DeletePublisher(int id)
        {
            if (id == 0)
                return BadRequest("id is null");

            var response = _publisherRepository.DeletePublisher(id); //response is true or false(boolean type)
            return Ok(response);
        }


    }
}
