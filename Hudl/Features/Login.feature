Feature: As a user i should be able to login to Hudl

Scenario Outline: I should be able to login
Given I login with username as "<username>"and Password as "<password>"
Then I should be able to see myaccount as "Coach J"
Examples: 
| username              | password       |
| s.jataprolu@gmail.com | TestPassword@1 |

Scenario Outline: With invalid credentials i should not login
Given I login with username as "<username>"and Password as "<password>"
Then I should be to see error message "We didn't recognize that email and/or password. Need help?"
Examples: 
| username              | password |
| asada                 | asasa    |
| s.jataprolu@gmail.com |          |
|                       | dsdfsfsd |