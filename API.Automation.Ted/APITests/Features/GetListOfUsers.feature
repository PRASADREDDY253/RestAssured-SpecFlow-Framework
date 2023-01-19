Feature: GetListOfUsers

Get a list of users

@tag1
Scenario: Get a list of users
	Given There are some users in list
	When sends request to get list of users
	Then validate users are fetched
