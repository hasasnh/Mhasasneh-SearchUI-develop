

<!-- PROJECT LOGO -->
<br />
<p align="center">
  <a href="https://github.com/jaffal83/TripleM-SearchUI">
    <img src="images/search.png" alt="Logo" width="80" height="80">
  </a>

  <h3 align="center">Configurable Solr Search component for Sitecore 9.2</h3>

  <p align="center">
     <a href="https://www.bridgemiles.net/Solr-Search"><strong>For More Clarification Please</strong></a>
    <br />
    <a href="https://www.bridgemiles.net/Solr-Search"><strong>Explore the docs »</strong></a>
    <br />
    <br />
    <a href="https://github.com/jaffal83/TripleM-SearchUI">View Demo</a>
    ·
    <a href="https://github.com/jaffal83/TripleM-SearchUI/issues">Report Bug</a>
    ·
    <a href="https://github.com/jaffal83/TripleM-SearchUI/issues">Request Feature</a>
  </p>
</p>



<!-- TABLE OF CONTENTS -->
## Table of Contents

* [About the Project](#about-the-project)
  * [Built With](#built-with)
* [Getting Started](#getting-started)
  * [Prerequisites](#prerequisites)
  * [Installation](#installation)
* [Usage](#usage)
* [Features](#features)
* [License](#license)
* [Contact](#contact)



<!-- ABOUT THE PROJECT -->
## About The Project

[![Product Name Screen Shot][search-screenshot]](https://github.com/jaffal83/TripleM-SearchUI)

TripleM-SearchUI is a configurable Solr Search component for Sitecore 9.2 that can allow the developer to run solr search queries without writing code by using set of settings and operators  in sitecore tree.

### Built With
Solr Search component tested with the following versions:

* [Sitecore9.2](https://dev.sitecore.net/Downloads.aspx)
* [Solr](solr-8.2.0)



<!-- GETTING STARTED -->
## Getting Started

This is steps of the instructions on setting up your project locally.
To get a local copy up and running follow these simple steps.

### Prerequisites

list things you need to use the component.
* Local instance of Sitecore9.2 up and runing on Solr 8.2.0

### Installation

1. Download sitecore module (Mhasasneh SearchUI-1.0.0.zip)
2. Use sitecore installation wizard in order to isntall the module  
3. That's it we are done :), you should be able to see the follwoing settings template

![Screen Shot][search3-screenshot]

<!-- USAGE EXAMPLES -->
## Usage

Now you will be able to create new settings for your search as follwoing:

1- Create setting item from 	/sitecore/templates/Project/TripleM/Search/Search Settings

![Screen Shot][search2-screenshot]

2- Create setting scope item in order to get all items with sub children under specific root.

![Screen Shot][search4-screenshot]

3- Select the root item from the list

![Screen Shot][search5-screenshot]

4- Create Search Results Setting item from /sitecore/templates/Project/TripleM/Search/Search Results Fields 

 ![Screen Shot][search8-screenshot]
 
5- Add the search results fields separated by comma that you want to see in the view result, please make sure they have the same name of the item property.

EX: searching for the news item and i want to show title, name and description

 ![Screen Shot][search9-screenshot]
 
 ![Screen Shot][search10-screenshot]
 
 
6- Add the search rendering to your page

![Screen Shot][search6-screenshot]

7- Select the Search Settings that you created as datasource

![Screen Shot][search7-screenshot]

8- Open your page and check the search result you will get all items and all childrens under the scope

EX: searching for all items under the news scope, in this case you will get all items with different template types

![Screen Shot][search11-screenshot]

But what if i need only news type? in this case we need to create Queries settings as following:

9- Create Queries settings item from 	/sitecore/templates/Project/TripleM/Search/Queries 

![Screen Shot][search12-screenshot]

10- Create template id query and fill the value of template id 

![Screen Shot][search13-screenshot]

Reload the page again , you will get the news type only

![Screen Shot][search14-screenshot]

<!-- ROADMAP -->
## Features

Also The search component support the follwoing Queries and operators

1- Facets 
You can create facets for any type of item.
EX: news category

![Screen Shot][search15-screenshot]

![Screen Shot][search16-screenshot]

2- Queries
a) Date Query with 5 operators (< , > , = , <= , >=)

![Screen Shot][search17-screenshot]

And because the operators build on builder design you can easlly implement new operator

![Screen Shot][search18-screenshot]

b) Number Query with 5 operators (< , > , = , <= , >=)

![Screen Shot][search19-screenshot]

3- Multiple Partial Word Query , you can search for multiple word

![Screen Shot][search20-screenshot]

4- Highlight Query

![Screen Shot][search21-screenshot]

![Screen Shot][search22-screenshot]


<!-- LICENSE -->
## License

Distributed under the MIT License. See `LICENSE` for more information.



<!-- CONTACT -->
## Contact

Mohannad Alhasasneh - [@MohannadAlhasa2](https://twitter.com/MohannadAlhasa2) - hasasnh@hotmail.com

Project Link: [https://github.com/hasasnh/Mhasasneh-SearchUI-develop)




[search-screenshot]:  images/search1.png
[search2-screenshot]: images/search2.png
[search3-screenshot]: images/search3.png
[search4-screenshot]: images/search4.png
[search5-screenshot]: images/search5.png
[search6-screenshot]: images/search6.png
[search7-screenshot]: images/search7.png
[search8-screenshot]: images/search8.png
[search9-screenshot]: images/search9.png
[search10-screenshot]: images/search10.png
[search11-screenshot]: images/search11.png
[search12-screenshot]: images/search12.png
[search13-screenshot]: images/search13.png
[search14-screenshot]: images/search14.png
[search15-screenshot]: images/search15.png
[search16-screenshot]: images/search16.png
[search17-screenshot]: images/search17.png
[search18-screenshot]: images/search18.png
[search19-screenshot]: images/search19.png
[search20-screenshot]: images/search20.png
[search21-screenshot]: images/search21.png
[search22-screenshot]: images/search22.png