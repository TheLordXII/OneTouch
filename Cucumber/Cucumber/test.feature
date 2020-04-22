Feature: test
	

@mytag
Scenario: Links
	Given the OneTouchNextGen blog site is open
    When I click on the custom link labeled "Blog Feed"
    Then the page title should contain "Week"
