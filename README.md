# MenuProject

### Overview

Given a JSON string which describes a menu, calculate the SUM of the IDs of all "items", as long as a "label" exists for that item.  All IDs are integers between 0 and 100 and the menu can be of any length.  The application should take a file / path and parse the json string and output the sum of the valid Item IDs.  Example Below:

```json
[
  {
     "menu":{
        "header":"menu",
        "items":[
           {
              "id":27
           },
           {
              "id":0,
              "label":"Label 0"
           },
           null,
           {
              "id":93
           },
           {
              "id":85
           },
           {
              "id":54
           },
           null,
           {
              "id":46,
              "label":"Label 46"
           }
        ]
     }
  },
  {
     "menu":{
        "header":"menu",
        "items":[
           {
              "id":81
           }
        ]
     }
  }
]
```

##Dependencies / Development information
1. Built in VS2015 using C# MVC.

###Dependencies
1. JSON.net : Nuget -> Install-Package Newtonsoft.Json -Version 9.0.1
2. Latest Microsoft Web Developer tools as of 2/2/2017.

##Testing
1. Test cases were written using native Visual Studio unit testing library.  They need to be ran manually from visual studio previous to building solution for deployment.  Once the repo is cloned and the solution is opened navigate to the menu bar to Test -> Run -> All Tests.

#Deployment
1. Login to local IIS Manager
2. Navigate to 'Default Web Site' and right-click and select 'Add Application' ( Ensure application pool .Net version matches that of the one being built for in Visual Studio. )
3. Provide an Alias of 'MenuProject' and choose a physical path (ie  c:\inetpub\wwwroot\menuproject)
5. Navigate to Visual Studio and Right-click project name and select 'Publish'.
6. Select Publish Target of Custome and click next.
7. Select Publish Method of File System and enter the path selected for step 3 and click next.
8. Select 'Release' as the configuration with 'File Publish Options' to delete existing files previous to publishing.
9. Click publish.
10. Return back to IIS and select the Application on the left panel and click browse to verify deployment was successful.
