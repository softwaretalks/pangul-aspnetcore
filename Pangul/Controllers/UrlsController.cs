using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using Pangul.Models;
using Pangul.Services;

namespace Pangul.Controllers
{
    [ApiController]
    [Route("/api/v1/[controller]")]
    public class UrlsController : ControllerBase
    {
        private readonly IUrlService urlService;

        public UrlsController(IUrlService urlService)
        {
            this.urlService = urlService;
        }

        [HttpGet]
        [ProducesResponseType(200)]
        public ActionResult<IEnumerable<UrlResult>> Index()
        {
            return urlService.GetAll();
        }

        [HttpPost]
        [ProducesResponseType(201)]
        [ProducesResponseType(400)]
        [ProducesResponseType(409)]
        public ActionResult<UrlResult> Index(UrlModel urlModel)
        {
            var result = urlService.Validate(urlModel);

            if (result == UrlValidationResult.Malformed)
            {
                return BadRequest();
            }

            if (result == UrlValidationResult.Duplicate)
            {
                return StatusCode(409);
            }

            return urlService.Create(urlModel);
        }
    }
}
