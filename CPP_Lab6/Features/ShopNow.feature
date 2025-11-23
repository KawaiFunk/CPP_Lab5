Feature: SALE Section
  Purpose: Validate the redirect from the SALE module using the Shop Now button

  Scenario: Shop Now button redirects to the correct sale page
    Given the user is on the Home page for sale
    When the user clicks the Shop Now button
    Then the Sale page should load successfully
