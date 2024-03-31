
Feature: Youte video
	@youtube
	Scenario: Youte video
		Given I am on the Youte video page
		When I click on the video
		Then I should see the video playing