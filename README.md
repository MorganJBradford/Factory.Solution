## <div align="center">Dr. Sillystringz's Factory</div>
#### <div align="center"> *A website created for tracking engineers and machinery* </div> 
***<p align="right">Morgan Bradford***</p>   
<p align="center">
<br>

<img alt="C#" src="https://img.shields.io/badge/c%23%20-%23239120.svg?&style=for-the-badge&logo=c-sharp&logoColor=white"/>
<img alt="made with Bash" src="https://img.shields.io/badge/Made%20with-Bash-1f425f.svg"/>
</p>

___
## 🚩 *Description*:    
### *This website allows users to track their engineers and machines, and establish relationships between the two based on licensure.*


## 🔧 *Setup/Installation instructions:*
#### 🌐 From the web:
* Go to my GitHub repository, using following [URL](https://github.com/MorganJBradford/Factory.Solution.git).
* Click the "Code" <img src="README-files/download-button.png" alt="code button" height="20" align="center"/> and click the 'Download zip' option ![img](README-files/Capture.JPG).
#### ⚙️ From the terminal: 
* Clone my repository from GitHub using `git clone https://github.com/MorganJBradford/Factory.Solution.git` in your terminal or GitBash
* Navigate to the downloaded folder using the '*cd*' command
⚠️ *Note: To run this project locally you will need to have .NET Core. You can check if you have .NET Core by running 'dotnet --version' in the command line. If you do not have .NET Core please find more information and download [here](https://dotnet.microsoft.com/download/dotnet)*


####  🖥️ View website:

1. Configure appsettings.json.

* Create a file named "appsettings.json" in the top level of the production directory 'Factory.Solution/Factory'. 
**Uploading to your own repository**: If using vscode and "appsettings.json" is is not grayed out like in the image below, you may need to commit the .gitignore file included in this project first. If "appsettings.json" is not grayed out **do not upload your project**
![img](README-files/appsettings.JPG)

* Navigate to your appsettings.json and paste the following template code:

``{
  "ConnectionStrings": {
      "DefaultConnection": "Server=localhost;Port=3306;database=[database_name];uid=root;pwd=[password];"
  }
}``

If you are using a server other than the default server, you will need to change the Port number. Otherwise, we will update the code to put in our database information and password. Replace "\[database_name]" with the "factory_db" and "\[password]" with your password. **Again this is private and should be included in a .gitignore.** The final result should look like the following:

``{
  "ConnectionStrings": {
      "DefaultConnection": "Server=localhost;Port=3306;database=factory_db;uid=root;pwd=mydbpassword;"
  }
}``

2. Run Application

* From the top level directory enter 'cd Factory' in the command line.
* Run 'dotnet ef database update' to create your database.
* Run the command 'dotnet restore' to download dependencies required to run the project.
* Next, enter 'dotnet run' the in command line. You should see a message similar to the following populate in your terminal:

> Hosting environment: Production
> Content root path: C:\Users\vampi\OneDrive\Desktop\epicodus\Factory.Solution\Factory
> Now listening on: http://localhost:5000
> Now listening on: https://localhost:5001
> Application started. Press Ctrl+C to shut down.

* Lastly, follow the link "http://localhost:5000" either via holding the 'ctrl' and clicking the link (PC), or by holding 'cmd' and clicking the link (Mac).


## 🛠️ *Technologies used:*
* ASP.NET Core MVC
* C# 9
* Entity Framework Core
* Git and GitHub
* MSTest
* MySql
* .NET v5.0
* REPL

## 🐛 *Known bugs:*
* You you find any bugs, _please_ contact me via my email below.

## 📬 Contact Information
#### For any questions *[email Morgan](mailto:morganjbradford95@gmail.com)*



## 📘 *License and copyright:*

> ***© Morgan Bradford 2021***  
> ⚖️ *[![License: MIT](https://img.shields.io/badge/License-MIT-yellow.svg)](https://opensource.org/licenses/MIT)*