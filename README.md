#<u> TPEndOfYear</u>
#Group Members
	Siraaj Wilkinson (214068730)
	Cornelious Tarwareyi (214051471)
	Micheal Hendricks (210116986)
	Yongama Ngwenduna (NOT A STUDENT)

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
#LINK
	http://admindeploy-001-site1.ctempurl.com/Default.aspx
		
#System Requirements For Running On Local PC
      Visual Studio Ultimate 2013
      SQL Server 2012 
      Windows 8 and above
      Google Chrome Browser
      <p>
#Instructions On How To Run The Project
  -Clone the project into :C:\Users\Public (to avoid changing the connection string)<br/>
  -Open TPEndOfYear folder  <br/>
  -Doubleclick localhost_40442.sln<br/>
  See screen shot below
  <img src="https://github.com/cjTarwireyi/TPEndOfYear/blob/master/cloning project.PNG"/><br/></p>
#Project Structure<br/>
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
