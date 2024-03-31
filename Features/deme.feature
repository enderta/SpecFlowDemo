Feature: Demo

@page
Scenario Outline: Demo
	Given I am on the demo page <url>
	Then the <title> of page

	Examples:
	| url | title |
	| http://www.google.com | Google |
	| http://www.yahoo.com | Yahoo |
	| http://www.bing.com | Bing |