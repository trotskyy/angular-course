using AngularCourseBE.Models;
using System.Collections.Generic;
using System.Linq;
using System.Web.Http;
using System.Web.Http.Results;

namespace AngularCourseBE.Controllers
{
    [RoutePrefix("api/resource")]
    public class ResourceController : ApiController
    {
        private static readonly List<Resource> _resources = new List<Resource>
        {
            new Resource
            {
                Id = 1,
                Name = "Resource 1"
            },
            new Resource
            {
                Id = 2,
                Name = "Resource 2"
            },
            new Resource
            {
                Id = 3,
                Name = "Resource 3"
            },
            new Resource
            {
                Id = 4,
                Name = "Resource 4"
            },
            new Resource
            {
                Id = 5,
                Name = "Resource 5"
            },
            new Resource
            {
                Id = 6,
                Name = "Resource 6"
            },
            new Resource
            {
                Id = 7,
                Name = "Resource 7"
            },
            new Resource
            {
                Id = 8,
                Name = "Resource 8"
            },
            new Resource
            {
                Id = 9,
                Name = "Resource 9"
            },
            new Resource
            {
                Id = 10,
                Name = "Resource 10"
            }
        };

        [HttpGet]
        [Route("")]
        public IHttpActionResult GetAll()
        {
            return Ok(_resources);
        }

        [HttpGet]
        [Route("{id}")]
        public IHttpActionResult Get(int id)
        {
            Resource resource = _resources
                .FirstOrDefault(r => r.Id == id);

            return resource == null
                ? NotFound()
                : (IHttpActionResult)Ok(resource);
        }

        [HttpPost]
        [Route("")]
        public IHttpActionResult Create(ResourceCreateUpdateModel createModel)
        {
            if (createModel == null)
            {
                return BadRequest($"{createModel} must be passed");
            }

            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            int lastId = _resources.Last().Id;

            var newResource = new Resource
            {
                Id = lastId + 1,
                Name = createModel.Name
            };

            _resources.Add(newResource);

            return Created("api/resource/" + newResource.Id, newResource);
        }

        [HttpPut]
        [Route("{id}")]
        public IHttpActionResult Update(int id, ResourceCreateUpdateModel updateModel)
        {
            if (updateModel == null)
            {
                return BadRequest($"{updateModel} must be passed");
            }

            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            Resource resource = _resources
                .FirstOrDefault(r => r.Id == id);

            if (resource == null)
            {
                return NotFound();
            }

            resource.Name = updateModel.Name;

            return new StatusCodeResult(System.Net.HttpStatusCode.NoContent, this);
        }

        [HttpDelete]
        [Route("{id}")]
        public IHttpActionResult Delete(int id)
        {
            Resource resource = _resources
                .FirstOrDefault(r => r.Id == id);

            if (resource == null)
            {
                return NotFound();
            }

            _resources.Remove(resource);

            return new StatusCodeResult(System.Net.HttpStatusCode.NoContent, this);
        }
    }
}
