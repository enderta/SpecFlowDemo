Feature: SpaceX
@space
Scenario Outline: Get upcoming launches
    When I send a GET request to "<End Points>" spacex
    Then The response status code should be <Status Code>

    Examples:
      | End Points         | Status Code |
      | /launches/upcoming | 200         |
      | /launches/past     | 200         |
      | /launches/latest   | 200         |
      | /launches/next     | 200         |