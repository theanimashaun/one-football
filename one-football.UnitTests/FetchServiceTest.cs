using Microsoft.Extensions.Configuration;
using Moq;
using Moq.Protected;
using Newtonsoft.Json;
using NUnit.Framework;
using one_football.Models;
using one_football.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Reflection.Emit;
using System.Threading;
using System.Threading.Tasks;
using Assert = NUnit.Framework.Assert;

namespace one_football.UnitTests
{
    [TestFixture]
    public class FetchServiceTest
    {
        private FetchService _fetchService;
        private Mock<IBaseService> _mockBaseService;

        private Mock<HttpMessageHandler> _httpHandler;
        private HttpClient _httpClient;

        private readonly IDictionary<string, string> _apiEndpoints = new Dictionary<string, string>
        {
            { "ApiFootballUrl", "http://localhost:999"  },
            { "ScoreBatUrl", "https://www.scorebat.com/video-api/v1" }
        };

        [SetUp]
        public void SetUp()
        {
            _httpHandler = new Mock<HttpMessageHandler>(MockBehavior.Strict);
            _httpClient = new HttpClient(_httpHandler.Object, false)
            {
                BaseAddress = new Uri("http://test.com/"),
            };

            IConfigurationBuilder configurationBuilder = new ConfigurationBuilder();
            configurationBuilder.Properties.Add("ApiEndpoints", _apiEndpoints);
            IConfiguration configuration = configurationBuilder.Build();

            _mockBaseService = new Mock<IBaseService>();
            _mockBaseService.Setup(x => x.SetupHttpClient(It.IsAny<string>()))
                .Returns(_httpClient);

            _fetchService = new FetchService(configuration, _mockBaseService.Object);
        }

        [Test]
        public async Task ShouldGetCountries()
        {
            _httpHandler.Protected()
                .Setup<Task<HttpResponseMessage>>(
                    "SendAsync",
                    ItExpr.IsAny<HttpRequestMessage>(),
                    ItExpr.IsAny<CancellationToken>()
                )
                .ReturnsAsync(new HttpResponseMessage()
                {
                    StatusCode = HttpStatusCode.OK,
                    Content = new StringContent(JsonConvert.SerializeObject(new List<Country> { }))
                })
                .Verifiable();

            var countries = await _fetchService.GetCountries();
            Assert.AreEqual(countries.Count(), 0);
        }

        [Test]
        public async Task ShouldGetCompetitions()
        {
            _httpHandler.Protected()
                .Setup<Task<HttpResponseMessage>>(
                    "SendAsync",
                    ItExpr.IsAny<HttpRequestMessage>(),
                    ItExpr.IsAny<CancellationToken>()
                )
                .ReturnsAsync(new HttpResponseMessage()
                {
                    StatusCode = HttpStatusCode.OK,
                    Content = new StringContent(JsonConvert.SerializeObject(new List<Competition> { new Competition() }))
                })
                .Verifiable();


            var competitions = await _fetchService.GetCompetitions();
            Assert.AreEqual(competitions.Count(), 1);
        }

        [Test]
        public async Task ShouldGetStandings()
        {
            _httpHandler.Protected()
                .Setup<Task<HttpResponseMessage>>(
                    "SendAsync",
                    ItExpr.IsAny<HttpRequestMessage>(),
                    ItExpr.IsAny<CancellationToken>()
                )
                .ReturnsAsync(new HttpResponseMessage()
                {
                    StatusCode = HttpStatusCode.OK,
                    Content = new StringContent(JsonConvert.SerializeObject(new List<StandingInfo> { new StandingInfo() }))
                })
                .Verifiable();


            var standings = await _fetchService.GetStandings(0);
            Assert.AreEqual(standings.Count(), 1);
        }

        [Test]
        public async Task ShouldGetLivescores()
        {
            _httpHandler.Protected()
                .Setup<Task<HttpResponseMessage>>(
                    "SendAsync",
                    ItExpr.IsAny<HttpRequestMessage>(),
                    ItExpr.IsAny<CancellationToken>()
                )
                .ReturnsAsync(new HttpResponseMessage()
                {
                    StatusCode = HttpStatusCode.OK,
                    Content = new StringContent(JsonConvert.SerializeObject(new List<LivescoreInfo> { new LivescoreInfo(), new LivescoreInfo() }))
                })
                .Verifiable();


            var livescoreInfos = await _fetchService.GetLiveScores();
            Assert.AreEqual(livescoreInfos.Count(), 2);
        }

        [Test]
        public async Task ShouldGetHighlights()
        {
            _httpHandler.Protected()
                .Setup<Task<HttpResponseMessage>>(
                    "SendAsync",
                    ItExpr.IsAny<HttpRequestMessage>(),
                    ItExpr.IsAny<CancellationToken>()
                )
                .ReturnsAsync(new HttpResponseMessage()
                {
                    StatusCode = HttpStatusCode.OK,
                    Content = new StringContent(JsonConvert.SerializeObject(new List<HighlightInfo> { new HighlightInfo() }))
                })
                .Verifiable();


            var highlights = await _fetchService.GetVideoHighlights();
            Assert.AreEqual(highlights.Count(), 1);
        }
    }
}
