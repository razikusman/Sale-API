using Microsoft.AspNetCore.Mvc.Testing;
using RESTFulSense.Clients;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace sale_API.Acceptance.Test.Brokers
{
    public class sale_ApiBroker
    {
        private readonly WebApplicationFactory<Startup> webApplicationFactory;
        public readonly HttpClient httpClient;
        private readonly IRESTFulApiClient restFactoryClient;

        public sale_ApiBroker()
        {
            this.webApplicationFactory = new WebApplicationFactory<Startup>()
        }
    }
}
