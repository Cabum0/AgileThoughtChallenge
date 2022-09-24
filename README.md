# AgileThoughtChallenge
Agile Thought Challenge

The solutions contains 4 projects:

1. StringListHandler: Is the .NET standard library with the sorting logic
2. AgileThoughtTest: Is a console application using the library
3. StringListHandlerWeb: Is an API using the library
4. StringListHandler.Test: Unit test for the library

API explantion:

The logic for the sorting is encapsulated in a .Net Standard Library so other project (.Net framework/.Net Core) can use it, inside the web project is set a OrderingByController with an Action of Post, this action will receive a instance of the type ListToSort in the body of the message with the parameters for the names array and the order array, and will return the sorted array as a JSON result. 
