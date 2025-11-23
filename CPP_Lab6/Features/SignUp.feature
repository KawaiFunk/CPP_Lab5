Feature: Sign Up Functionality
  Purpose: Validate that user can sign up successfully and be redirected to the home page

  Scenario: User signs up successfully
    Given the user opens the Home page for sign up
    When the user clicks the Sign Up button
    And the sign up modal appears
    And the user fills the sign up form with "Dan", "dan@dan.com", "123", "123"
    And the user clicks the Sign Up submit button
    Then the user should be redirected to the home page
