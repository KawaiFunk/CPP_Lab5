Feature: Back to Top Button
  Purpose: Validate the back-to-top button functionality for easy navigation on extended pages

  Scenario: Back to top button becomes visible after scrolling and returns user to top
    Given the user opens the Home page for back to top test
    When the user scrolls down the page
    Then the back to top button should become visible
    When the user clicks the back to top button
    Then the page should scroll back to the top
