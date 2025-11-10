# 🏦 BankApp – README

# 🧾 Summary
BankApp is a console-based C# program that simulates a simple banking system.
Users can log in as either a Customer or an Administrator (Admin) to perform various banking operations such as creating accounts, making transfers, managing loans, or administrating users.
The program focuses on structure, user flow, and logic, and uses multiple classes that work together to create a clear and modular codebase. 
BankApp is divided into several class groups based on their functionality: user management, accounts and economics, menus, and transactions.

# 🧩 Structure and Classes

**User Classes**

User (abstract class)
Base class for all users in the system. Contains common properties such as username, password, full name, and number of failed login attempts.

Customer (inherits from User)
Represents a bank customer. Holds lists of accounts, loans, and transactions.

Admin (inherits from User)
Has extended privileges, such as creating, viewing, and deleting customers through methods like CreateCustomer(), DeleteCustomer(), ViewCustomer(), and DoesUsernameExist().

UserRegister
Contains a dictionary (Dictionary<string, User>) where all users are stored.
Handles login verification and customer management (add, delete, search).
This class is used by both Admin and LogIn.

LogIn
Manages the login flow for users. Checks if the username exists, if the password is correct, and whether the account is locked after too many failed attempts.
After a successful login, it determines whether the user is an Admin or a Customer and redirects them to the appropriate menu.

**Menu Classes**

MainMenu – The program’s starting point, offering options to log in or exit the application.
Menu (with AdminMenu and CustomerMenu) – Displays different options depending on the user role.
CustomerUI – Manages customer interactions such as handling accounts, loans, and transactions.
ConsoleUI – Responsible for console output, layout, and general user interface.
InputValidation – Contains methods for reading and validating user input (e.g., strings and numbers).

**Account Classes**

Account (abstract class)
Base class for accounts, containing properties such as account number, balance, currency, and owner.

SavingsAccount and SalaryAccount inherit from Account and represent specific account types.
Each account holds a list of transactions and can display its balance.

**Economics Classes**

BankRegister – Acts as a central registry for all bank data. It contains lists of accounts, loans, and transactions, along with methods for adding and retrieving these objects.
This class is used by several other parts of the program and provides a centralized way to keep track of all customers’ finances.

Transaction – Represents a transfer between two accounts, containing details such as amount, sender, receiver, and timestamp.

TransactionManager – Manages a queue of pending transactions using a timer (quarterTimer). Implements asynchronous programming (async/await) to execute transfers after a set delay.

Loan – Stores information about loans, interest rates, and loan amounts, and includes methods for calculating repayments.

CurrencyCode – An enum listing available currencies (e.g., SEK, EUR, USD, GBP).
Used to ensure that accounts and loans are always tied to a valid currency.

Currency – Represents currency types and exchange rates. Managed by the administrator through AdminMenu.

CurrencyConversion – Handles currency conversion between different currencies in the bank.
Includes methods to convert amounts based on current exchange rates. Administrators can update exchange rates via AdminMenu.
This class is used in transfers, account creation, and when displaying balances in different currencies.

# ⚙️ Program Flow (Overview)

-> The program starts in MainMenu, where the user logs in.

-> LogIn verifies the credentials and determines the user role.

-> CustomerMenu presents options such as viewing accounts, creating a new account, transferring money, or applying for a loan.

-> AdminMenu allows administrators to create or delete customers and manage exchange rates.

-> All transactions are processed through TransactionManager, which registers and executes them after a delay.


# 📝 Flow Chart and Class Diagram

https://app.diagrams.net/#G1upa4XnK6D76AUzzvikiAWc6_ubersYKu#%7B%22pageId%22%3A%22C5RBs43oDa-KdzZeNtuy%22%7D
