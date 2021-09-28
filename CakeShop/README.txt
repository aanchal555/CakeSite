HI Joel, 

Thanks for the opportunity. I am happy that I was able to push myself and complete the tasks that you asked for this quiz,
despite my initial setup of having to start a couple hours later than intended 
because of the windows machine requirements.


I was able to complete all of the tasks that the quiz requested. However, I did have some issues with implementing 
Integration Testing for the application. I ideally wanted to implemented integration testing within the project. 
Unfortunately, I kept facing different issues, some of which were compatibility issues with the packages that I was trying to use.
I was able to use a write some scripts outside of the project in Visual Studio that tested the functionality of the Web APi, some of which is included within the project. 

For the Web Api, a post request is able to be made to the application using a url with the structure https://localhost[portnumber]/api/[CakeId]/[Quantity]. A user is allowed
to make a request for one type of cake at a time and decide the quantity of that one cake he or she wants in that order. I decided to use a post request because it is more secure than a get request. 
A user would just need to call the make a request to the url in the code they want to use to automate the ordering process. In addition, I also added some simple error handling to ensure that a request is not made for a cake 
that is not within that database. In addition, Functionality for Notes and the Calories are working as intended. 

Here are some steps I would take next to improve the overall functionality of the application. 

- Add user authentication and authorization. Security is very important. 
- Ensure that only an authorized user can make a api request
- Be able to persist and map cart data for each unique profile. If I switch accounts or even logout, the cart data does not change. 
- Allow users to leave reviews for cakes 
- Allow users the capability to pick up cakes from the shop


I am certain the Web APi can be designed a lot better, and more functionalities can be added to it. 


Questions that I would ask a Senior Engineer would be:

- Would are the best practices in developing in C# and the .Net ecosystem, and are their and resources that you can point me towards ?
- Are there any coding styles that the company enforces I should adhere to ?
- I would want to have an in-depth conversation about how to approach tackling a problem before going straight into coding
- I would ask and make sure that I have a clear understanding of the expectations of the user for a product I could be working on


More information on how I approached testing can be found in Testing1.txt.
