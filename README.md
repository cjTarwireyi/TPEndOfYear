﻿#<u> TPEndOfYear</u>
#Group Members
	Siraaj Wilkinson (214068730)
	Cornelious Tarwireyi (214051471)
	Micheal Hendricks (210116986)
	Yongama Ngwenduna (NOT A STUDENT)
	
	#Domain Model

<img src="https://github.com/cjTarwireyi/TPEndOfYear/blob/master/DomainStructure.jpg"/> 


#OVERVIEW 
Nawaal Cottle has a small business which she runs at home she buys and sells clothing,perfume,jewellery etc.Her business is based in a rural area where people can really buy this<br/>
So she decided to start up a business where CLIENTS CAN BUY PRODUCTS which there will recieve on the spot BUT THEY WILL ONLY PAY FOR IT AT THE END OF THE MONTH FOR A THAN STORE PRICE<br/>
She will be able to create orders,add products and very importantly track her stock as she sells product<br/>

#WHY IS THIS UNQIUE
We have discoverd that there are MANY small businesses like this in rural areas but no system has been designed for this type of business yet, this a good chance to create something that has not been created yet<br>

#PURPOSE
This system is designed to keep track of all orders purchased by clients over various months and years<br/>
It will enable the owner to see which products sells and does not sell well<br/>
It will also allow the owner to see who the good customers and bad customers are<br/>
Keeping track of stock will be so much easier<br/>


#Important
	You need to change the time format
	To create orders and to use the system
	The required format is: yyyy-MM-dd
	Very important please set you time format to this!!!!!
#NOTICE
	Please note that none of the data is actual data this is testing database uploaded
	Passowrd for login
	Admin
		username :cj   password:cj
	Non Admin
		username:sw password:sw
#LINK TO DEPLOYED SYSTEM
	http://admindeploy-001-site1.ctempurl.com/Default.aspx
#VIDEO LINK
	https://drive.google.com/file/d/0BzfC0Iq2N7TzOFEtWG81ajZSc1E/view?usp=sharing
		
#System Requirements For Running On Local PC
      Visual Studio Ultimate 2013
      SQL Server 2012 
      Windows 8 and above
      Google Chrome Browser
      <p>
      <b>Instructions On How To Run The Project</b><br/>
  -Clone the project into :C:\Users\Public (to avoid changing the connection string)<br/>
  OR Clone the project in any folder and click this link for for steps on setting connection string<br/>https://github.com/cjTarwireyi/TPEndOfYear/issues/1<br/>
  -Open TPEndOfYear folder  <br/>
  -Doubleclick localhost_40442.sln<br/>
  See screen shot below
  <img src="https://github.com/cjTarwireyi/TPEndOfYear/blob/master/cloning project.PNG"/><br/></p>
<b>Project Structure</b><br/>
   <b>FrondEnd</b><br/>
  TPEndOfYear(1) - consist of all frond end classes and pages
  
  <b>Backend</b><br/>
  domain folder- contains all the domain classes.<br/>
  factories- containr all the factories used to create objects<br/>
  intarface folder- contains all interface methods<br/>
  services folder- contains classes that accesses repositories<br/>
  repositories folder- contains access to the database<br/>
  <b>Testing</b><br/>
  factories folder- contains test cases fo objects creation and updating<br/>
  services folder - contains test cases for CRUD<br/>
  repositories folder- test cases for repositories<br/>
 
   
 <img src="https://github.com/cjTarwireyi/TPEndOfYear/blob/master/projectStructure.PNG"/>
 
<br/><b> Running the Project</b>
  
Expand TPEndOfYear(1) -> expand site1<br/>
A)right click on Default.aspx -> on the options chose "Set As Start Page"
<br/>B)click build -> on the options clean and build<br/>
C)click to run the project
<br/>NB Log in details are on the NOTICE section above.
<img src="https://github.com/cjTarwireyi/TPEndOfYear/blob/master/runLocal.PNG"/> <br/>

<b>Running Tests</b>
A) Click Test->Windows->Test Explorer.<br/>
Test Explorer window Appears<br/>
B) On the Test Explorer different options can be chosen to run tests
<img src="https://github.com/cjTarwireyi/TPEndOfYear/blob/master/running tests.PNG"/> <br/>
