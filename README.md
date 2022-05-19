----------------------------------------------------------------------------------------------------------------------------------------

![Logo](https://github.com/zafeirisdimi/ChocoFactory/blob/master/img/choco.png "Chocofactory logo")


----------------------------------------------------------------------------------------------------------------------------------------

# 🏭CHOCOFACTORY #


<details><summary><strong>Description(GR)</strong></summary>
<p>
    <ol><li>Αρχικά η επιχείρηση θα έχει 1 Εργοστάσιο με δυνατότητα επέκτασης</li></ul>
    <li> Επίσης θα έχει και 1 κατάστημα πώλησης των προϊόντων με δυνατότητα επέκτασης</li>
    <li> Το εργοστάσιο θα παράγει διάφορα είδη σοκολάτας </li>
    <li> Το εργοστάσιο θα προμηθεύεται την πρώτη ύλη κάθε χρόνο με συμβόλαιο από συγκεκριμένο προμηθευτή. Σε Περίπτωση που η πρώτη ύλη πέσει στο 10 % τότε θα γίνεται νέα συμπληρωματική παραγγελία από τον ίδιο Προμηθευτή.</li>
    <li> Θα δεχόμαστε 3 προσφορές από Προμηθευτές οι οποίες θα αφορούν ποσότητα, τιμή ανά κιλό, ποιότητα (δείκτης όσο μεγαλύτερη η ποιότητα τόσο μεγαλύτερη η τιμή)</li>
    <li> Η επιχείρηση θα διαθέτει εργαζόμενους στο εργοστάσιο και στο κατάστημα πώλησης (Ignore for now)</li>
    <li> Τα είδη σοκολάτας που θα παράγει θα είναι λευκή, μαύρη, γάλακτος. Η γάλακτος χωρίζεται σε επιπλέον κατηγορίες: σκέτη, αμυγδάλου, φουντούκι. Κάθε είδος θα έχει διαφορετική τιμή πώλησης. Το κύριο προϊόν παραγωγής θα είναι η μαύρη σοκολάτα.</li>
    <li> Βασικός στόχος της πρώτης έκδοσης του ΣΥΣΤΗΜΑΤΟΣ είναι να μπορεί να επιλέξει προμηθευτή,  να παράγει σοκολάτες και να πουλάει από το κατάστημα.</li>
    <li> Το κατάστημα που θα πουλάει τις σοκολάτες έχει πολιτική έκπτωσης κάθε δεύτερη Τρίτη του μήνα να εφαρμόζει 20 % έκπτωση στα προϊόντα του. </li>
    <li> Η πρώτη ύλη από τους προμηθευτές θα παραλαμβάνεται σε κιλά. Στο τέλος του έτους ότι περισσέψει (εάν περισσέψει) θα αφοσιώνεται σε πειραματισμό για νέα προϊόντα. </li>
    <li> Τα Προϊόντα που θα παράγονται για πειραματισμό θα δίνονται ως δώρο σε πελάτες που υλοποιούν αγορές πάνω από 30 ευρώ(1 προϊόν ανά 30 ευρώ). </li>
    <li> Εάν τα κέρδη της επιχείρησης στο τέλος του χρόνου φτάσουν σε ένα συγκεκριμένο ποσοστό θα δημιουργείται αυτόματα νέο κατάστημα πώλησης προϊόντων. Το ποσοστό θα καθορίζεται από τον πρόεδρο της εταιρίας. </li>
    <li> Η Παραγωγή θα είναι ημερήσια σταθερή 500 σοκολάτες. Το 50 % της σοκολάτας που θα παράγεται αρχικά θα πηγαίνει απευθείας στο κατάστημα. Το υπόλοιπο θα παραμένει σε αποθήκη που ανήκει στο εργοστάσιο. Όταν το ποσοστό στο κατάστημα πέφτει στο 25% τότε θα ανεφοδιάζεται πάλι από την αποθήκη στο τέλος της κάθε μέρας ώστε να έχει πάντα το 50% της παραγωγής. </li>
    <li> Κάθε νέο κατάστημα πώλησης θα διαθέτει τοποθεσία, δικούς του υπαλλήλους και θα μπορεί να αποδίδει ξεχωριστά τα κέρδη του προς την επιχείρηση. </li>
    <li> Στο τέλος κάθε ημέρας το κάθε κατάστημα θα αποδίδει αναφορά πόσο προϊόντα πουλήθηκαν από κάθε είδος καθώς και το υπόλοιπό τους. </li>
    </p>
</details>


------------------------------------------------------------------------------------------------------------------------------------------------------

📋Table of contents
=================

<!--ts-->

   * [Domain](#domain)
   * [Deparments](#deparments)
      * [IDeparment(inteface)](#ideparment)
      * [Company](#company)
      * [Accountint](#accounting)
      * [Production](#production)
      * [Warehouse](#warehouse)
      * [Factory](#factory)
      * [Shop](#shop)
   * [Human](#human)
      * [IHuman(inteface)](#ihuman)
      * [Supplier](#supplier)
      * [Employee](#employee)
   * [Products](#products)
      * [IProduct(inteface)](#iproduct)
   * [Policy](#policy)
      * [CompanyPolicy](#companypolicy)
      * [PricePolicy](#pricepolicy)
      * [ProductionPolicy](#productionpolicy)
      * [Warehouse](#warehouse)
      * [FactoryPolicy](#factorypolicy)
      * [ShopPolicy](#shoppolicy)
   * [Service](#service)
   * [Interfaces](#interfaces)
   * [Screenshots](#screenshots)
   * [Team](#team)
   * [Technologies](#technologies)
   
<!--te-->
                                                                                                               

![factorydiagram](https://github.com/zafeirisdimi/ChocoFactory/blob/master/img/ChocoFactoryDiagram.drawio.png "Object diagram")
------------------------------------------------------------------------------------------------------------------------------

# /Domain/ #

## IDeparment ##
### (interface) ###
| Type           | Properties       | Methods |
| :---:          |     :---:        |  :---:  |
| int            | DepartmentID     | get, set   |
| string         | Description      | get, set    |
| int            | ManagerID        | get, set    |

##### [Back to >Top<](#chocofactory) #####

## 🏢Company ##

| Type           | Properties       | Methods |
| :---:          |     :---:        |  :---:  |

##### [Back to >Top<](#chocofactory) #####

## 🧮Accounting ##
| Type           | Properties       | Methods |
| :---:          |     :---:        |  :---:  |
| List of Supplier | Suppliers        | void ReceiveOffer()  |
| List of Employee | Employees        | Order SendOrder(parameter Offer)   |
| List of Offer    | AvailableOffers  | Offer CheckBestOffer()    |
| Supplier       | supplierLast     | ---- |

##### [Back to >Top<](#chocofactory) #####

## 🏦Production
| Type           | Properties       | Methods |
| :---:          |     :---:        |  :---:  |
| Factory            | Factory     | get, set   |

| Extra Methods         |      Description                                                      |
| ----------------- | ------------------------------------------------------------------ |
| Product CreateProduct(string productName) | Choose what kind of Chocolate we want to create |
| Offer SendOffer() | Send Offer to Accounting Deparment |


##### [Back to >Top<](#chocofactory) #####

## 📦Warehouse
| Type           | Properties       | Methods |
| :---:          |     :---:        |  :---:  |
| int            | DepartmentID     | get, set   |
| string         | Description      | get, set    |
| int            | ManagerID        | get, set    |

##### [Back to >Top<](#chocofactory) #####

## 🏫Factory
| Type           | Properties       | Methods |
| :---:          |     :---:        |  :---:  |
| Warehouse          | Warehouse     | get, set   |
| Production         | Production      | get, set    |
| Company            | Company        | get, set    |
| Account            | Accounting        | get, set    |

##### [Back to >Top<](#chocofactory) #####

## 🏪Shop ##
| Type           | Properties       | Methods |
| :---:          |     :---:        |  :---:  |
| Company            | Company     | get, set   |
| List of Product        | Products      | get, set    |
| List of Employee            | Employees        | get, set    |
| Dictionary string, int            | DailyProductsSold        | {the products for sale}etc "WhiteChocolate"|
| string            | Location        | get, set    |
| decimal            | DailyEarnings        | get, set    |
   

| Extra Methods         |      Description                                                      |
| ----------------- | ------------------------------------------------------------------ |
| decimal SellProduct(string productName) | Sell Product, add the price Of Product in Daily, increase DailyProductsSold|
| decimal ServeCustomer(List string productsToSell) | Get the order of Customer and check if the products have value more than 30 euro|
| void DailyActions(DateTime date) | What do extactly every day the object Shop |
| void DailyReport() | Daily report of sales and earnings|
| void SendDailyEarnings() |  The Shop send the daily earnings to object Company|
| bool IsProductQuantityLow() | Check the Avalaible Quantity of Products of Shop|
| void RefillProducts() | Refill Products,if the IsProductQuantityLow() is true |
| Product ReceiveProduct() | Receive Product from Warehouse |
| RemoveExpiredProducts(DateTime currentDate) | Check if the Products have passed the ExpiredDate and it throws away.|


##### [Back to >Top<](#chocofactory) #####

# /Human/ #

## 🧑IHuman ##
### (inteface) ###
| Type           | Properties       | Methods |
| :---:          |     :---:        |  :---:  |
| string            | FirstName     | get, set   |
| string         | LastName      | get, set    |


- CEO
- Customer
- Employee
- Seller

## 👴Supplier ##
| Type           | Properties       | Methods |
| :---:          |     :---:        |  :---:  |
| int            | ID     | get, set   |

| Extra Methods         |      Description                                                      |
| ----------------- | ------------------------------------------------------------------ |
| void SendSupplies(Order order)| Send Supplies from Supplier to Production|
| Offer SendOffer(decimal pricePerKilo, Quality quality, int suppliesKilos) | Send Offer to Accounting Deparment |

##### [Back to >Top<](#chocofactory) #####

# 🍫Products #

## IProduct ##
### (interface) ###
| Type           | Properties       | Methods |
| :---:          |     :---:        |  :---:  |
| int            | ID     | get, set   |
| Offer         | Offer      | get, set    |
| int            | OrderID        | get, set    |

### IChocolate ### 
- DarkChocolate
- WhiteChocolate
### IMilkChocolate (interface) ###
- PlainMilkChocolate
- AlmondMilkChocolate
- HazelnutMilkChocolate

##### [Back to >Top<](#chocofactory) #####

## 👮Policy ##

### CompanyPolicy ###

### FactoryPolicy ####

| Type           | Properties       | Methods |
| :---:          |     :---:        |  :---:  |                                    
| int            | DailyProducts     | get, set   |
| double        | LowSuppliesThresholdPercent      | get, set    |
| double            | MinimumRevenueToInvest        | get, set    |
| double            | RevenueYearlyGoal        | get, set    |
| int            | NumberOfOffers        | get, set    |

### ProductionPolicy ###

| Type           | Properties       | Methods |
| :---:          |     :---:        |  :---:  | 
| double             | BlackChocolatePercent     | get, set   |
| double        | WhiteChocolatePercent      | get, set    |
| double            | MilkChocolatePercent        | get, set    |
| double            | AlmondMilkChocolatePercent        | get, set    |
| double            | HazelnutMilkChocolatePercent        | get, set    |
| int            | BlackChocolateSupplies     | get, set   |
| int        | WhiteChocolateSupplies      | get, set    |
| int            | AlmondMilkChocolateSupplies        | get, set    |
| int            | HazelnutMilkChocolateSupplies        | get, set    |
| int            | ExperimentalChocolateSupplies        | get, set    |

### ShopPolicy ###

| Type           | Properties       | Methods |
| :---:          |     :---:        |  :---:  |    
| double            | ProductsToShopPercent        | get, set    |
| double            | ShopRestockPercent        | get, set    |
| int            | ShopStockSize        | get, set    |
| int            | ShopRestockThreshold        | get, set    |
| double            | ShopDiscount        | get, set    |
| DayOfWeek      | DiscountDay        | get, set    |
| int      | DiscountDayOccurence        | get, set    |
| decimal      | GiftMinimumPrice        | get, set    |

### PricePolicy ###

| Type           | Properties       | Methods |
| :---:          |     :---:        |  :---:  |                                
| decimal            | BlackChocolatePrice        | get, set    |
| decimal           | WhiteChocolatePrice        | get, set    |
| decimal      | MilkChocolatePrice        | get, set    |
| decimal      | AlmondMilkChocolatePrice        | get, set    |
| decimal      | HazelnutMilkChocolatePrice        | get, set    |



## 🔨Services ##

- CustomerService
- SupplierService
- RandomGenerator


## ⏏️Interfaces ##

All the builded interfaces: 
- IDepartment
- IFactory
- IHuman
- IMaterial
- IOfferModel
- IOrderModel
- IProduct

## 📉Business Logic Diagram ##
------------------------------------------------------------------------------------------

![Business Logic](https://github.com/zafeirisdimi/ChocoFactory/blob/master/img/MicrosoftTeams-image%20(1).png)

------------------------------------------------------------------------------------------

## 🎖️Tasks ##
### Project status ###
- [x] Analysis
- [x] Design
- [x] Development
- [x] Unit testing
- [x] Mockup Data  

## 🖥️Technologies + recourses ##

### Technologies ###
- Programming Language C#
- Framework .NET 4.7.3
- Console Application

### Recourses ###
- [Download Visual Studio](https://visualstudio.microsoft.com/downloads/)
- [Official documentation](https://docs.microsoft.com/en-us/)


##### [Back to >Top<](#chocofactory) ####

------------------------------------------------------------------------------------------
## 🤝Team ##
- [👨Ioannins T.](https://github.com/ioannis-thyris)
- [🧑Dimitris B.](https://github.com/GitEmm)
- [👨Dimitris Z](https://github.com/zafeirisdimi)
- [🧔Stavros G.](https://www.github.com/StaurosGouleas)

