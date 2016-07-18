using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using NuGet.Protocol.Core.v3;

namespace Watermelon.Components
{
    public class MockHttpClientResponseHandler : DelegatingHandler
    {
        // TODO: Setup as JSON file for scalability, readability and adjusting at runtime
        private readonly MockResponse _responses = new MockResponse();

        protected async override Task<HttpResponseMessage> SendAsync(HttpRequestMessage request,
            System.Threading.CancellationToken cancellationToken)
        {
            // TODO: Search response dictionary for specific query as well as path
            var requestUrl = request.RequestUri.LocalPath;
            if (_responses.Wan.ContainsKey(requestUrl))
            {
                // TODO: Add ability for bad responses
                return new HttpResponseMessage(HttpStatusCode.OK)
                {
                    Content = new StringContent(_responses.Wan[requestUrl])
                };
            }
            else
            {
                return new HttpResponseMessage(HttpStatusCode.NotFound) {RequestMessage = request};
            }
        }
    }
}
