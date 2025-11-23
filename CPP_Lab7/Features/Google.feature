Feature: Google Search Tests

  Scenario: Verificarea încărcării paginii Google
    Given I open Google Home page
    Then Google homepage should be displayed

  Scenario: Verificarea numărului de rezultate pe pagină
    Given I open Google Home page
    When I search for "test"
    Then Search results should be displayed

  Scenario: Apăsarea butonului Search fără text
    Given I open Google Home page
    When I click search with empty field
    Then Google homepage should remain displayed

  Scenario: Căutare irelevantă - Did you mean
    Given I open Google Home page
    When I search for "corect hght"
    Then Did you mean should appear
