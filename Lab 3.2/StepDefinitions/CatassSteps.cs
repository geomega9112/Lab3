using Newtonsoft.Json.Linq;
using NUnit.Framework;
using RestSharp;
using TechTalk.SpecFlow;

namespace CataasAPITests.StepDefinitions
{
    [Binding]
    public class CataasStepDefinitions
    {
        private RestResponse response;

        [Given(@"I send a GET request to the GIF endpoint")]
        public void GivenISendAGETRequestToTheGIFEndpoint()
        {
            var client = new RestClient("https://cataas.com/cat/gif");
            var request = new RestRequest
            {
                Method = Method.Get
            };

            // Виконуємо запит
            response = client.Execute(request);
        }

        [Then(@"I should be redirected to the GIF site")]
        public void ThenIShouldBeRedirectedToTheGIFSite()
        {
            // Перевіряємо статус-код
            Assert.AreEqual(200, (int)response.StatusCode, $"Unexpected status code: {(int)response.StatusCode}");

            // Перевіряємо фінальну URL-адресу
            Assert.IsNotNull(response.ResponseUri, "Redirected URL is null");
            var finalUrl = response.ResponseUri.ToString();
            Assert.IsTrue(finalUrl.Contains("/cat/gif"), $"Redirected URL is not as expected: {finalUrl}");
        }
    }

}
