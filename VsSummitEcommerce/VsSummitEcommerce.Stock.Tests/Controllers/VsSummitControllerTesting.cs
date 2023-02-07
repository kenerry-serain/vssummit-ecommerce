using Microsoft.AspNetCore.Mvc;
using VsSummitEcommerce.Stock.Controllers;
using Xunit;

namespace VsSummitEcommerce.Stock.Tests.Controllers
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
