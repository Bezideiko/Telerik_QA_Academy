Feature: SpecFlowHomework
	In order to avoid silly mistakes
	As a math idiot
	I want to be told the sum of two numbers


Scenario: Sum of 2 and 2
	
	Given clean calculator

	When I enter 2
	And I press add
	And I press 2
	And I press equal

	Then result should be 4

