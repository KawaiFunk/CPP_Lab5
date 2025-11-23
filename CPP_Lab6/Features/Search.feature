Feature: Search Functionality
  Purpose: Validate the behavior of the search bar when no text is entered

  Scenario: Empty search should trigger validation error
    Given the user is on the Home page
    When the user clicks the search button without typing anything
    Then a validation error should be shown
