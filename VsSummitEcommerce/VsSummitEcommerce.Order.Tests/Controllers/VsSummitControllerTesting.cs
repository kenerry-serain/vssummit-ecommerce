using Microsoft.AspNetCore.Mvc;
using Xunit;
using VsSummitEcommerce.Order.Controllers;

namespace VsSummitEcommerce.Order.Tests.Controllers
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
