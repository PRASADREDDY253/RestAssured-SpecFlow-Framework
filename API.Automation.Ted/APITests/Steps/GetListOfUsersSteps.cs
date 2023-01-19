using API.Automation.Ted;
using API.Automation.Ted.Models.Response;
using API.Automation.Ted.Utility;
using NUnit.Framework;
using RestSharp;
using System;
using TechTalk.SpecFlow;

namespace APITests.Steps
{
    [Binding]
    public class GetListOfUsersSteps
    {
        private RestResponse response;
        private APIClient api;

        public GetListOfUsersSteps()
        {
            api= new APIClient();
        }
        [Given(@"There are some users in list")]
        public void GivenThereAreSomeUsersInList()
        {
            
        }

        [When(@"sends request to get list of users")]
        public async void WhenSendsRequestToGetListOfUsers()
        {
            response = await api.GetListOfUsers<ListOfUserRes>(2);           
        }

        [Then(@"validate users are fetched")]
        public void ThenValidateUsersAreFetched()
        {           
            //var content=Utilities.GetContent<ListOfUserRes>(response);
            //Assert.AreEqual(content.page, 2);          
        }
    }
}
