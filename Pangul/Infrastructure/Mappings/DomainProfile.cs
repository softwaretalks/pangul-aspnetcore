using AutoMapper;
using Pangul.Services;
using System;
using System.Net.Http;

namespace Pangul.Infrastructure.Mappings
{
    public class DomainProfile : Profile
    {
        public DomainProfile()
        {
            CreateMap<HttpResponseMessage, HealthStatus>()
                .ConvertUsing<HttpResponseMessageToHealthStatusConverter>();
        }
    }

    public class HttpResponseMessageToHealthStatusConverter : ITypeConverter<HttpResponseMessage, HealthStatus>
    {
        public HealthStatus Convert(HttpResponseMessage httpReponseMessage, HealthStatus destination, ResolutionContext context)
        {
            string url = context.Items["url"].ToString();
            bool isDown = httpReponseMessage == null;
            int? statusCode = (int?)httpReponseMessage?.StatusCode;
            DateTime requestTime = DateTime.Now;

            return new HealthStatus(url, isDown, statusCode, requestTime);
        }
    }
}