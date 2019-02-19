using System;
using System.Collections.Generic;
using System.Linq;
using Pangul.Entities;
using Pangul.EntityFramework;
using Pangul.Models;

namespace Pangul.Services
{
    public class UrlService : IUrlService
    {
        private readonly DatabaseContext databaseContext;

        public UrlService(DatabaseContext databaseContext)
        {
            this.databaseContext = databaseContext;
        }

        public UrlResult Create(UrlModel urlModel)
        {
            var url = new Url
            {
                Value = urlModel.Url
            };

            databaseContext.Urls.Add(url);

            databaseContext.SaveChanges();

            return Map(url);
        }

        public List<UrlResult> GetAll()
        {
            return databaseContext.Urls.Select(Map).ToList();
        }

        public UrlValidationResult Validate(UrlModel urlModel)
        {
            var url = urlModel.Url;

            var isValid = Uri.TryCreate(url, UriKind.Absolute, out var uri)
                && (uri.Scheme == Uri.UriSchemeHttp || uri.Scheme == Uri.UriSchemeHttps);

            if (!isValid)
            {
                return UrlValidationResult.Malformed;
            }

            var hasDuplicate = databaseContext.Urls.Any(i => i.Value == url);
            if (hasDuplicate)
            {
                return UrlValidationResult.Duplicate;
            }

            return UrlValidationResult.Ok;
        }

        private UrlResult Map(Url url)
        {
            return new UrlResult(url.Id, url.Value);
        }
    }
 }
