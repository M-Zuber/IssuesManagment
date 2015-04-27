Feature: Get All Issues
	In order to kepe track of what is going on in a given repository
	As someone with an intrest in the project
	I want to be able to view all the issues of the repository

Background:
	Given An authenticated user
	And the repository
	| reponame    |
	| public-repo |
	And the issues
	| title  | body                      | state  |
	| first  | some random text          | open   |
	| second | bla bla bla bla           | closed |
	| third  | this is a critical matter | open   |

Scenario: View the open issues
	When I request the issues for repository "public-repo"
	Then all the issues in the list have the state "open"

Scenario: View All Issues
	When I request all the issues for repository "public-repo"
	Then the issues vary in state
