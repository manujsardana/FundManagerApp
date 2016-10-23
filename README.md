# FundManagerApp
UBS Technical Excercise

I have uploaded my solution for the problem. Please note of the following points

1) After opening the FundManager solution, please right click on the solution and select "Enable Nuget Package Restore". This would restore the nuget package on building the solution. This is an important step otherwise there would be missing dlls and solution won't build and run.

2) I have used Extended WPF Toolkit to show the grid and some other controls (DecimalUpDown, NumericUpDown) in the ain screen.

3) For Unit test cases I have used Moq and NUnit framework as Nuget packages. 

4) I have followed a MVVM pattern for this solution although I have not used any third party MVVM Tool kit. I have used Dependency Injection (poor man's DI) without any thirty party dlls (Microsoft etc). 

5) I  have not used logging in this solution as I was running out of time and I wanted to finish all the features first. Having said that, I believe and agree that logging and exception handling is as important as the feature itself and is really helpful to track issues/problems.

6) I have also set up some initial data so when the application is started there is some data that is loaded.


