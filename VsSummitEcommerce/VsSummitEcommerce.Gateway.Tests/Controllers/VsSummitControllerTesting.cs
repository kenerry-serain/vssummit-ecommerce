using Microsoft.AspNetCore.Mvc;
using VsSummitEcommerce.Gateway.Controllers;
using Xunit;

namespace VsSummitEcommerce.Gateway.Tests.Controllers
{
    public class VsSummitControllerTesting
    {
        [Fact]
        public void ShouldReturnOk()
        {
            var getMethod =(OkObjectResult)new VsSummitController()
                .Get();

            Assert.Equal(getMethod.StatusCode, getMethod.StatusCode);
        }
    }
}
