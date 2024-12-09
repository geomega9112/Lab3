Feature: Redirect to Cat GIF
  As a user of the Cataas API
  I want to ensure that the endpoint redirects me to a GIF
  So that I can confirm the API behavior

  Scenario: Verify redirect to the GIF endpoint
    Given I send a GET request to the GIF endpoint
    Then I should be redirected to the GIF site
