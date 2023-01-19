using API.Automation.Ted;
using API.Automation.Ted.Models.Requests;
using API.Automation.Ted.Utility;
using NUnit.Framework;
using RestSharp;
using System;
using System.Net;
using TechTalk.SpecFlow;
using TechTalk.SpecFlow.Assist;

namespace APITests.Steps
{
    [Binding]
    public class CreateUserSteps
    {
        private CreateUserReq createUserReq;
        private RestResponse response;
        private ScenarioContext scenarioContext;
        private HttpStatusCode statusCode;
        private APIClient api;

        public CreateUserSteps(CreateUserReq createUserReq, ScenarioContext scenarioContext)
        {
            this.createUserReq = createUserReq;
            this.scenarioContext = scenarioContext;
            api = new APIClient();
        }
        
        [Given(@"User with payload ""([^""]*)""")]
        public void GivenUserWithPayload(string fileName)
        {
            string filePath = Utilities.GetFilePath(fileName);
            var payLoad = Utilities.ParseJson<CreateUserReq>(filePath);
            scenarioContext.Add("createUser_Payload", payLoad);
        }

        [When(@"send request to create user")]
        public async Task WhenSendRequestToCreateUser()
        {
            createUserReq = scenarioContext.Get<CreateUserReq>("createUser_Payload");
            response = await api.CreateUser(createUserReq);
        }

        [Then(@"validate user is created")]
        public void ThenValidateUserIsCreated()
        {
            statusCode = response.StatusCode;
            var code = (int)statusCode;
            Assert.That(code, Is.EqualTo(201));

            var content = Utilities.GetContent<CreateUserReq>(response);
            Assert.AreEqual(createUserReq.name, content.name);
            Assert.AreEqual(createUserReq.job, content.job);
        }

        [Given(@"Retrive below users with name and job")]
        public void GivenRetriveBelowUsersWithNameAndJob(Table table)
        {
            dynamic datas = table.CreateDynamicSet();
            foreach (var item in datas)
            {
                Console.WriteLine($"Name:{item.name},job:{item.job}");
            }
            
        }

        [When(@"sends request to create user")]
        public void WhenSendsRequestToCreateUser()
        {
            
        }

        [Then(@"validate users are created")]
        public void ThenValidateUsersAreCreated()
        {
            
        }

    }
}
