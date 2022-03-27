# Doctors Office 

#### By _**Cesar Lopez**_

### _March 25, 2022_

#### _An application for Dr.Sillystringz to track engineers, machines, and licenses in the factory._

## Technologies Used

* C#
* .NET 5.0
* dotnet
* MySql/Workbench

## Description

An application for Dr.Sillystringz to track engineers, machines, and licenses in the factory. The application is capable of the following:
* Add a engineer to the system including name and license.
* Add a machine to a engineer including name and license.
* Add more than one engineer to a machine and vice versa.

## Setup/Installation Requirements

* Make sure you have MySql Workbench installed on your computer.
* Make sure to have dotnet-ef installed too.<br>
<em>This project uses <code>dotnet-ef --version 3.0.0</code> which I have globally installed but you can install it however you want. 
1. Download .NET 5.0 SDK for : <a href="https://dotnet.microsoft.com/download/dotnet/thank-you/sdk-5.0.102-windows-x64-installer" target="_blank">Windows</a> or <a href="https://dotnet.microsoft.com/download/dotnet/thank-you/sdk-5.0.100-macos-x64-installer" target="_blank">Mac</a>

2. Clone the appliction to your computer by entering: ```git clone https://github.com/wowgr8/Factory.Solution``` in the terminal
3. Open the repository in the terminal 
4. Import cesar_lopez.sql database into MySql by following these steps 
5. Launch MySql Workbench 
6. Select MySql intance in the middle under MySqlConnections
7. Select Navigator, then Administration, followed by DataImport/Restore 
8. Select Import from Self- contained File 
9. Click the 3 dots at the end of Self-Contained file and in the pop up choose the cesar_lopez.sql file
10. In the Default Schema to be Imported to section select new and a pop up will appear, name the schema cesar_lopez 
11. Click start import within the import progress if on windows, if on mac it will be in the same window
12. Once complete, refresh and it will appear

## Setup for appsettings.json
1. In the terminal, cd into the file HairSalon
2. Create a new file by entering `touch appsettings.json`  in the root directory
3. Enter the following code below. Be sure to replace [Password] with the password for MySql workbench that you have set up. Do the same for [userid], the uid is the user id you've set up in MySql workbench.
```
{
  "ConnectionStrings": {
    "DefaultConnection": "Server=localhost;Port=3306;database=cesar_lopez;uid=[userid];pwd=[Password];"
  }
}
```  
4. After that is complete, run the application by cd'ing into HairSalon and enter ```dotnet run``` in your terminal 
5. When it finishes you should see ```Now listenin on: http://localhost:5000 ``` CTRL click the link to view the application in your browser.

## Additional Setup/Installation Note for Windows Users

- None

## Known Bugs

* _No known issues_

## License

[MIT License](https://opensource.org/licenses/MIT) Published _**2022**_ by _**Cesar Lopez**_

## Contact Information

If you encounter any questions, issues, or ideas for this site, please contact:

- Cesar Lopez at [Lopez.cesar.aug@gmail.com](mailto:lopez.cesar.aug@gmail.com)