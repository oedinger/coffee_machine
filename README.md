# Coffee Machine Project
Implementation of a generic coffee machine by using C# and WPF 

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


# ERD
![image (1)](https://user-images.githubusercontent.com/6663720/132923728-d6e2d80b-35e1-48cb-abdb-75936277fdc8.png)

<br>

# JSON Example
![Screenshot 2021-09-11 012917](https://user-images.githubusercontent.com/6663720/132924205-0d89b67e-7988-4338-8b7e-fda16744c3ba.png)

<br>

# UML
![Copy of Untitled Diagram drawio](https://user-images.githubusercontent.com/6663720/132923843-7de5424e-9d83-4899-acbd-fc676dbd6570.png)

<br>

# Application Snaspshot
![image](https://user-images.githubusercontent.com/6663720/132924609-ebc2f01a-5ed0-4fc7-9572-b190ac6f781c.png)

