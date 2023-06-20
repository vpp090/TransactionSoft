Feature: Merchants

A short summary of the feature

@tag1
Scenario: Get all merchants
	Given I am a client
	And the repository has merchants
	Then the response status code is 200
	And the response json should be 'merchants.json'
