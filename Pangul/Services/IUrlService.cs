using Pangul.Models;
using System.Collections.Generic;

namespace Pangul.Services
{
    public interface IUrlService
    {
        UrlResult Create(UrlModel urlModel);

        UrlValidationResult Validate(UrlModel urlModel);

        List<UrlResult> GetAll();
    }
}