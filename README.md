
![Logo](https://github.com/zafeirisdimi/ChocoFactory/blob/master/img/choco.png)


----------------------------------------------------------------------------------------------------------------------------------------

# CHOCOFACTORY


<details><summary><strong>Description(Greek)</strong></summary>
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

Table of contents
=================

<!--ts-->
   * [Domain](#domain)
   * [Deparments](#deparments)
      * [Deparment(abstract Class)](#deparment)
      * [Account](#account)
      * [Production](#production)
      * [Warehouse](#warehouse)
      * [Factory](#factory)
      * [Shop](#shop)
   * [Human](#human)
      * [Human(abstract Class)](#human)
      * [CEO](#ceo)
      * [Customer](#customer)
      * [Employee](#employee)
      * [Seller](#seller)
      * [Supplier](#supplier)
   * [Products](#products)
      * [Product (abstract Class)](#product)
      * [Chocolate (abstract Class)](#chocolate)
      * [WhiteChocolate](#whitechocolate)
      * [MilkChocolate (abstract Class)](#milkchocolate)
      * [PlainMilkChocolate](#plainMilkChocolate)
      * [AlmondMilkChocolate](#almondMilkChocolate)
      * [HazelnutMilkChocolate](#hazelnutMilkChocolate)
   * [Interfaces](#Interfaces)
   * [Screenshots](#Screenshots)
   * [Team](#team)
   * [Technologies](#technologies)
<!--te-->
                                                                                                               

![factorydiagram](https://github.com/zafeirisdimi/ChocoFactory/blob/master/img/ChocoFactoryDiagram.drawio.png)
------------------------------------------------------------------------------------------------------------------------------

# /Domain/


# /Deparments/
| Left-aligned | Center-aligned | Right-aligned |
| :---         |     :---:      |          ---: |
| git status   | git status     | git status    |
| git diff     | git diff       | git diff      |

##### [Back to >Top<](#chocofactory)

## Deparment
### (abstract Class)
| Type           | Properties       | Methods |
| :---:          |     :---:        |  :---:  |
| int            | DepartmentID     | get, set   |
| string         | Description      | get, set    |
| int            | ManagerID        | get, set    |

##### [Back to >Top<](#chocofactory)

## Account
| Type           | Properties       | Methods |
| :---:          |     :---:        |  :---:  |
| List<Supplier> | Suppliers        | void ReceiveOffer()  |
| List<Employee> | Employees        | Order SendOrder(parameter Offer)   |
| List<Offer>    | AvailableOffers  | Offer CheckBestOffer()    |
| Supplier       | supplierLast     | ---- |

##### [Back to >Top<](#chocofactory)

## Production
| Type           | Properties       | Methods |
| :---:          |     :---:        |  :---:  |
| int            | DepartmentID     | get, set   |
| string         | Description      | get, set    |
| int            | ManagerID        | get, set    |

##### [Back to >Top<](#chocofactory)

## Warehouse
| Type           | Properties       | Methods |
| :---:          |     :---:        |  :---:  |
| int            | DepartmentID     | get, set   |
| string         | Description      | get, set    |
| int            | ManagerID        | get, set    |

##### [Back to >Top<](#chocofactory)

## Factory
| Type           | Properties       | Methods |
| :---:          |     :---:        |  :---:  |
| int            | DepartmentID     | get, set   |
| string         | Description      | get, set    |
| int            | ManagerID        | get, set    |

##### [Back to >Top<](#chocofactory)

## Shop
| Type           | Properties       | Methods |
| :---:          |     :---:        |  :---:  |
| int            | DepartmentID     | get, set   |
| string         | Description      | get, set    |
| int            | ManagerID        | get, set    |

##### [Back to >Top<](#chocofactory)

# /Human/ 

## Human
### (abstract Class)
| Type           | Properties       | Methods |
| :---:          |     :---:        |  :---:  |
| string            | FirstName     | get, set   |
| string         | LastName      | get, set    |
| double            | PhoneNumber         | get, set    |
| char            | Sex        | get, set    |

##### [Back to >Top<](#chocofactory)

## CEO
| Type           | Properties       | Methods |
| :---:          |     :---:        |  :---:  |
| int            | DepartmentID     | get, set   |
| string         | Description      | get, set    |
| int            | ManagerID        | get, set    |

##### [Back to >Top<](#chocofactory)

## Customer
| Type           | Properties       | Methods |
| :---:          |     :---:        |  :---:  |
| int            | DepartmentID     | get, set   |
| string         | Description      | get, set    |
| int            | ManagerID        | get, set    |

##### [Back to >Top<](#chocofactory)

## Employee
| Type           | Properties       | Methods |
| :---:          |     :---:        |  :---:  |
| int            | ID     | get, set   |
| decimal         | Salary      | get, set    |
| int            | ManagerID        | get, set    |
| int            | DeparmentID        | get, set    |

##### [Back to >Top<](#chocofactory)

## Seller
| Properties        | Methods                                                            |
| ----------------- | ------------------------------------------------------------------ |
| firstName | getFirstName , setFirstName |
| lastName | getLastName , setLastName |

##### [Back to >Top<](#chocofactory)

## Supplier
| Type           | Properties       | Methods |
| :---:          |     :---:        |  :---:  |
| int            | DepartmentID     | get, set   |
| string         | Description      | get, set    |
| int            | ManagerID        | get, set    |

| Extra Methods         |      Description                                                      |
| ----------------- | ------------------------------------------------------------------ |
| int SendSupplies(parameter Order) | Send Supplies from Supplier to Production|
| Offer SendOffer() | Send Offer to Accounting Deparment |

##### [Back to >Top<](#chocofactory)

# /Products/


## Product
### (abstract Class)
| Type           | Properties       | Methods |
| :---:          |     :---:        |  :---:  |
| int            | ID     | get, set   |
| Offer         | Offer      | get, set    |
| int            | OrderID        | get, set    |

##### [Back to >Top<](#chocofactory)

## Chocolate 
| Type           | Properties       | Methods |
| :---:          |     :---:        |  :---:  |
| int            | DepartmentID     | get, set   |
| string         | Description      | get, set    |
| int            | ManagerID        | get, set    |

##### [Back to >Top<](#chocofactory)

## DarkChocolate
| Type           | Properties       | Methods |
| :---:          |     :---:        |  :---:  |
| int            | DepartmentID     | get, set   |
| string         | Description      | get, set    |
| int            | ManagerID        | get, set    |

##### [Back to >Top<](#chocofactory)

## WhiteChocolate
| Type           | Properties       | Methods |
| :---:          |     :---:        |  :---:  |
| int            | DepartmentID     | get, set   |
| string         | Description      | get, set    |
| int            | ManagerID        | get, set    |

##### [Back to >Top<](#chocofactory)

## MilkChocolate
### (abstract Class)
| Type           | Properties       | Methods |
| :---:          |     :---:        |  :---:  |
| int            | DepartmentID     | get, set   |
| string         | Description      | get, set    |
| int            | ManagerID        | get, set    |

##### [Back to >Top<](#chocofactory)

## PlainMilkChocolate
| Type           | Properties       | Methods |
| :---:          |     :---:        |  :---:  |
| int            | DepartmentID     | get, set   |
| string         | Description      | get, set    |
| int            | ManagerID        | get, set    |

##### [Back to >Top<](#chocofactory)

## AlmondMilkChocolate
| Type           | Properties       | Methods |
| :---:          |     :---:        |  :---:  |
| int            | DepartmentID     | get, set   |
| string         | Description      | get, set    |
| int            | ManagerID        | get, set    |

##### [Back to >Top<](#chocofactory)

## HazelnutMilkChocolate
| Type           | Properties       | Methods |
| :---:          |     :---:        |  :---:  |
| int            | DepartmentID     | get, set   |
| string         | Description      | get, set    |
| int            | ManagerID        | get, set    |



## Screenshots
------------------------------------------------------------------------------------------

![App Screenshot](https://via.placeholder.com/468x300?text=App+Screenshot+Here)

------------------------------------------------------------------------------------------

## Technologies
- Programming Language C#
- Framework .NET 4.7.3
- Console Application
- [Visual Studio Community Edition 2019](https://visualstudio.microsoft.com/downloads/)
- [Microsoft technical documentation](https://docs.microsoft.com/en-us/)
##### [Back to >Top<](#chocofactory)
------------------------------------------------------------------------------------------
## Team
- [@ioannis-thyris](https://github.com/ioannis-thyris)
- [@GitEmm](https://github.com/GitEmm)
- [@zafeirisdimi](https://github.com/zafeirisdimi)
- [@StaurosGouleas](https://www.github.com/StaurosGouleas)








