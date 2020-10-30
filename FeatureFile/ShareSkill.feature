Feature: ShareSkill
	login, edit profile, share skill, search skill, skill display

#@Profile
#Background: 
#	Given Login to The Mars

@Profile
Scenario: SF1 Create the profile
	Given I create the description in profile
	And I Add the new language in profile

@Profile
Scenario: SF2 Share the skill
	Given I click the share skill button in profile
	And I create skill in share skill page

@Profile
Scenario: SF3 Search the skill
	Given I search the skill name in search box
	And I turn page to find the skill card