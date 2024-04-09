
# TZ.Tests

This repository contains an implementation of a set of test cases using Selenium and Cypress tools.

### Covered Test Cases:
#### A. Test case 1 (Successful Login)
1. Navigate to https://www.saucedemo.com/
2. Enter Login Credentials: Username: “standard_user” ; Password: “secret_sauce”
3. Click “Login”

#### B. Test case 2 (Failed Login)
1. Navigate to https://www.saucedemo.com/
2. Enter Login Credentials: Username: “locked_out_user” ; Password: “secret_sauce”
3. Click “Login”

#### C. Test case 3 (Happy Path Workflow)
1. Login to https://www.saucedemo.com/
2. Click “Add to Cart” button for “Sauce Labs Bike Light” on “Products” page
3. Click “Cart” icon on “Products” page
4. Click “Checkout” button on “Your Cart” page
5. Fill the “Checkout: Your Information” page (Random data).
6. Click “Continue” button
7. Click “Finish” button on “Checkout: Overview” page
8. Click “Menu” Icon on top left of the header
9. Click “Logout” button

#### D. Test case 4 (Multiple scenarios Workflow)
1. Login to https://www.saucedemo.com/
2. Change the Product Sort to “Price (low to high)” on “Products” page
3. Assert if the Selected (Displayed) Item on the Product Sort is “Price (low to high)”
4. Capture all prices from the product page and Assert if it is in ascending order.
5. Click “Add to Cart” button for “Sauce Labs Fleece Jacket” and “Sauce Labs Onesie”
6. Check if “Remove” button enabled for “Sauce Labs Fleece Jacket” and “Sauce Labs Onesie”
7. Capture price of “Sauce Labs Fleece Jacket” from “Products” page
8. Capture price of “Sauce Labs Onesie” from “Products” page
9. Capture value from “Cart Icon” on the top right and assert is its “2”.
10. Click “Cart” icon
11. Capture price of “Sauce Labs Fleece Jacket” from “Your Cart” page
12. Capture price of “Sauce Labs Onesie” from “Your Cart“ page
13. Assert price values from step 7 and step 11
14. Assert price values from step 8 and step 12
15. Click “Remove” button for “Sauce Labs Onesie” on “Your Cart“ page
16. Capture quantity of “Sauce Labs Fleece Jacket” from “Your Cart“page
17. Capture value from “Cart Icon” on the top right from “Your Cart“page
18. Assert quantity values from step 16 and step 17
19. Click “Checkout” button on “Your Cart“ page
20. Fill the “Checkout: Your Information” page (Random data).
21. Click “Continue” button
22. Capture “Item total” from “Checkout: Overview” page and Assert it with price from step 7
23. Click “Finish” button on “Checkout: Overview” page
24. Capture “Thank you for your order” text from “Checkout Complete” page and Assert it
25. Click “Menu” Icon on top left of the header
26. Click “Logout” button



## TZ.Tests.Selenium
Developed with .NET 6 (C#), it is configured to run with Chrome, Edge, and Firefox browsers. Make sure you have them installed.

To execute the tests, use the following commands:

```
dotnet build
dotnet test
```

## TZ.Tests.Cypress
Developed with NodeJS (TypeScript), it has been tested with Node version 18.17.1 and Yarn version 1.22.19. It is configured to use Chrome and Edge browsers.

To run the tests, use the following commands:
```
npm install
npm run test
```