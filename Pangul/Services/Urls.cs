using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Pangul.Common;
using Pangul.Services.HttpResult;

namespace Pangul.Services
{
    public class Urls
    {
        private IEnumerable<IUrl> ContainedUrls { get; }
        private IEnumerable<OperationResult> _results;
        public Urls(IEnumerable<IUrl> containedUrls)
        {
            ContainedUrls = containedUrls.ToList();
        }
        public async Task<IEnumerable<OperationResult>> GetAvailable()
        {
            _results = await GetResponses();
            _results = _results.OfType<Success>();
            return _results;

        }
        public async Task<IEnumerable<OperationResult>> GetUnAvailable()
        {

            _results = await GetResponses();
            _results = _results.OfType<Failed>();
            return _results;

        }


        public async Task<IEnumerable<OperationResult>> GetResponses() => await ContainedUrls
            .ForEach(x => x.GetResponse());
    }
}