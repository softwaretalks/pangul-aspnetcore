<<<<<<< HEAD
﻿using System;
using System.Collections.Generic;
=======
﻿using System.Collections.Generic;
>>>>>>> 0cc8d4295b245a564bfde2daf27fd26a18a41a4c
using System.Net.Http;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;
using Pangul.Services;

namespace Pangul.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class HealthController : ControllerBase
    {
        private readonly IOptions<List<string>> _urls;
        private readonly IHealthChecker _healthChecker;
        private readonly IHealthJob _healthJob;
        private readonly IHttpClientFactory _client;

        public HealthController(IOptions<List<string>> urls, IHealthChecker healthChecker, IHealthJob healthJob, IHttpClientFactory client)
        {
            _urls = urls;
            _healthChecker = healthChecker;
            _healthJob = healthJob;
            _client = client;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<HealthStatus>>> GetHealthStatus()
        {
            // just for test !!!
<<<<<<< HEAD
            
=======

>>>>>>> 0cc8d4295b245a564bfde2daf27fd26a18a41a4c
            IUrl url = new Url("https://www.dotnettips.info/", _client);
            IUrl url2 = new Url("https://www.dotnettips.info/", _client, "post/3003/شروع-به-کار-با-dntframeworkcore-قسمت-5-مکانیزم-eventing-و-استفاده-از-سرویس‌های-موجودیت‌ها");
            IUrl url3 = new Url("http://random-domain.ir/", _client);
            IUrl url4 = new Url("http://ali895.com/", _client);
            IUrl invalidUrl = new Url("", _client);

            var urls = new Urls(new[] { url, url2, url3, url4, invalidUrl });


            var healthStatuses = await _healthChecker.Check(urls);
            //----------------

            await _healthChecker.UnavailableUrls(urls);
            //-----------------

            //await _healthChecker.AvailableUrls(urls);

            await _healthJob.Save(healthStatuses);

            return healthStatuses;
        }
    }
}
