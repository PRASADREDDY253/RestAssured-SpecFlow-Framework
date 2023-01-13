Feature: CreateUser

	Create a new User

@tag1
Scenario: Create a new user with valid inputs
	Given User with payload "CreateUser.json"
	And user with job "Tech Lead"
	When send request to create user
	Then validate user is created
