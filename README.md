# Coffee Machine Project
Implementation of a generic coffee machine

# Requirments
* Functional Requirements
  * The application will have a user interface.
    * The user interface will present 4 drinks:
      * black coffee
      * Chocolate
      * Hot water
      * Cappuccino
    * The recipe for each drink is as below:
      * Black coffee – hot water, 2x dose of coffee
      * Chocolate – coco powder, hot water, milk
      * Hot water – hot water
      * Cappuccino – 1 dose of coffee, hot water, milk
    * If an ingredient of the machine is not available, the user interface should disable all drinks that rely on that ingredient
    * After user selects it drink (assuming available), the application will log to the screen the recipe instructions for that specific drink
      *  It’s ok to simulate the recipe by just printing the steps
* Non functional requirements
  * An addition of a new drink requires zero code change in the application and user interface
  * The application need to track the availability level of all ingredients
  * The architecture should be easy to integrate on different machines
  * The application needs to notify the user before an ingredient is over

# UML
