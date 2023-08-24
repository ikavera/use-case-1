Simple application to get countries information from the https://restcountries.com/v3.1/all
Available fields are here - https://gitlab.com/restcountries/restcountries/-/blob/master/FIELDS.md
Could be used for search countries by name, population, sort by name in both directions(ascendant/descendant).
For the sake of convenience result could be paginated customly - amount on page could be changed. 


How to run:
 In debug mode:
  - Install Visual Studio 2022
  - Install NET 6
  - press F5 or click "play" button
  
 To deploy locally in IIS:
  - activate IIS in windows features
  - open IIS
  - create port binding 
  - create folder
  - assign this folder to the application in IIS
  - deploy endpoint to the folder
  
  Deploy comand:
  dotnet publish -c Release /p:EnvironmentName=Development -o ./bin/Release/publish
  
  copy generated files to the folder assoiciated with IIS application
  
Usage examples:
 - Search for the particular country
   https://localhost:7042/UseCase/GetCountries?countryName=Ukraine

 - Search for symbols that present in country name
   https://localhost:7042/UseCase/GetCountries?countryName=ir
   
 - Search for countries by symbols present in country name and order descendant
   https://localhost:7042/UseCase/GetCountries?countryName=ir&sortDirection=desc
   
 - Search for countries by symbols present in country name and order ascendant
   https://localhost:7042/UseCase/GetCountries?countryName=ir&sortDirection=asc

 - Filter countries by their population, in result would be list of countries which population is less then 20 millions
   https://localhost:7042/UseCase/GetCountries?population=20

 - Filter countries by their population, name, in result would be list of countries which population is less then 20 millions
   https://localhost:7042/UseCase/GetCountries?population=20&countryName=ir

 - Filter countries by symbols present in country name and show first 5 results
   https://localhost:7042/UseCase/GetCountries?countryName=ir&records=5

 - Filter countries by symbols present in country name and show next 5 results
   https://localhost:7042/UseCase/GetCountries?countryName=ir&records=5pageNumber=1

 - Filter countries by symbols present in country name, population, ordered by name descendant and show first 5 results
   https://localhost:7042/UseCase/GetCountries?countryName=ir&population=20&sortDirection=desc&records=5
 
 - Filter countries by population, ordered by name acendant and show 5 results from the third page
   https://localhost:7042/UseCase/GetCountries?population=20&sortDirection=desc&records=5&pageNumber=2
   