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
