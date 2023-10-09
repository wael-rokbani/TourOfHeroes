using System.Net.Http.Json;
using TourOfHeroes.Backend.Entities;
using TourOfHeroes.Backend.Tests.Utils;

namespace TourOfHeroes.Backend.Tests;
public class HeroControllerTests : BaseTests
{
    public HeroControllerTests()
    {
        ApiClient = App.CreateClient("api/v1/Heroes");
    }

    [Fact]
    public void GetAllHeroesShouldBeOK()
    {
        var requestResult = ApiClient.GetAsync("").Result;

        Assert.True(requestResult.StatusCode == System.Net.HttpStatusCode.OK, "Get All Heroes result should be ok 200");

        var contentResult = requestResult.Content.ReadFromJsonAsync<IEnumerable<Hero>>().Result;

        Assert.True(contentResult != null, "Get All Heroes result is not well initialized");
    }

    //TODO Endpoints
}