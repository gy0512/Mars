Feature: ShareSkill
	login, edit profile, share skill, search skill, skill display

#@Profile
#Background: 
#	Given Login to The Mars

@Profile
Scenario: Create the profile
	Given I create the description in profile
	And I Add the new language in profile

@Profile
Scenario: Share the skill
	Given I click the share skill button in profile
	And I create skill in share skill page