# LibraryManagementApp

![image](https://github.com/uditac/LibraryManagementApp/assets/13919728/8deab34d-4ccc-4ce2-b7ab-fd8eed817e07)

Guidelines

I have made a base class of Library Resources, which contains the Title, ISBN Number which is common for the resources also I have taken the properties for the location of the resources.
<br> I have assumed that there are two kinds of files.
 * Books
 * Optical Drives ( which containes the audio video files)
 
 <br> In the controller there are four methods
  * Create Book where input string should be f.ex
    ![image](https://github.com/uditac/LibraryManagementApp/assets/13919728/f609ab8b-ac4b-4b68-a691-902e86d86e7d)

      This go throught the service layer and then the repository where it will create a BookRequestModel and generate ISBN Number.
  * searches book by filter f.ex "20" , wherever in the json object there is a 20 written it will bring out the book.

* GetBookLocation, you have to provide the ISBN number created for the file and then the book location will be shown.

Please remember to follow the above procedure everytime you start the application.


Tests

I have generated test data and running tests according to it.
 For now there are only few test cases I have considered.
   * Creating books
   * Searching books with single and multiple filters 
   * Getting book location.


  
 
 

