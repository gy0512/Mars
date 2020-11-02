Feature: ShareSkill
	login, edit profile, share skill, search skill, skill display

#@Profile
#Background: 
#	Given Login to The Mars

@Profile
#Scenario: SF1 Create the profile
#	Given I goto the profile page
#	And I create the description in profile

@Profile
Scenario Outline: SF1 Create the profile
	Given I goto the profile page
	When ScenarioContext dynamic data details
		| randnum    | curdatetime  |
		| 1234567890 | 202011020001 |
	Then I create the description in profile


@Profile
Scenario: SF2 Share the skill
	Given Share the skill I goto the profile page
	When Share the skill data details
		| randnum	 |
		| 1234567890 |
	And Share the skill I create the description in profile
	And Share the skill I click the share skill button in profile
	Then Share the skill I create skill in share skill page

@Profile
Scenario: SF3 Search the skill
	Given SFTWO Share the skill I goto the profile page
	When SFTWO Share the skill data details
		| randnum	 |
		| 1234567890 |
	And SFTWO Share the skill I click the share skill button in profile
	And SFTWO Share the skill I create skill in share skill page
	And I search the skill name in search box
	Then I turn page to find the skill card