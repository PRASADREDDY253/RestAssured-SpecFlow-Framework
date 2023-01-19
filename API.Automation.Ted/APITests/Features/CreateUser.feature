Feature: CreateUser

	Create a new User

@tag1
Scenario: Create a new user with valid inputs
	Given User with payload "CreateUser.json"	
	When send request to create user
	Then validate user is created

Scenario: Create a users with table input
	Given Retrive below users with name and job
	| name   | job       |
	| prasad | QA        |
	| reddy  | Develpoer |
	When sends request to create user
	Then validate users are created