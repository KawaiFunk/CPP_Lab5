Feature: Add to Cart Functionality
  Purpose: Validate that PPMiniCart appears when Add to Cart button is clicked

  Scenario: PPMiniCart appears when product is added to cart
    Given the user opens the product page for add to cart test
    When the user clicks the Add to Cart button
    Then the product should be added to the cart