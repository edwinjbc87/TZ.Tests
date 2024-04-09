import { faker } from "@faker-js/faker";
import CartPage from "../pageobjects/cart";
import CheckoutPage from "../pageobjects/checkout";
import LoginPage from "../pageobjects/login";
import ProductsPage from "../pageobjects/products";

describe('Feature 2. Cart', () => {
    beforeEach(() => {
      cy.clearAllCookies()
      cy.clearAllLocalStorage()
      cy.clearAllSessionStorage()
  
      cy.fixture('validcredentials').as('creds');
      cy.fixture('cartdata').as('cartdata');

      const loginPage = new LoginPage();
      loginPage.visit();
      cy.get('@creds').then((creds:any) => { 
        loginPage.login(creds.username, creds.password);
      });
    })

    it('Multiple Scenarios Workflow. Sort by price(low to high)', () => {
        //Arrange
        const productsPage = new ProductsPage();
    
        cy.get('@cartdata').then((cartdata:any) => {
            //Act
            productsPage.selectSortStrategy(cartdata.sortByPrice_LowToHigh);

            productsPage.elements.selectedProductSortStrategyName().invoke('text').as('selectedSortStrategyName')
            productsPage.getPriceList().then((priceList:number[]) => isSorted(priceList)).as('isSortedPriceList');
            
            //Assert
            cy.get('@selectedSortStrategyName').should('eq', cartdata.sortByPrice_LowToHigh);
            cy.get('@isSortedPriceList').should('eq', true);
        })

    })

    it('Multiple Scenarios Workflow. Show remove button for added products', () => {
        //Arrange
        const productsPage = new ProductsPage();
    
        cy.get('@cartdata').then((cartdata:any) => {
            //Act
            productsPage.addToCart(cartdata.product1);
            productsPage.addToCart(cartdata.product2);

            //Assert
            productsPage.getProductRemoveButton(cartdata.product1).should('exist');
            productsPage.getProductRemoveButton(cartdata.product2).should('exist');
        })    
    })

    it('Multiple Scenarios Workflow. Show Products qty in cart', () => {
        //Arrange
        const productsPage = new ProductsPage();
        const expectedQty:number = 2;
        
        cy.get('@cartdata').then((cartdata:any) => {
            //Act
            productsPage.addToCart(cartdata.product1);
            productsPage.addToCart(cartdata.product2);

            productsPage.elements.productsQtyInCartIcon().invoke('text').as('productsQtyInCartIcon');
            
            //Assert
            cy.get('@productsQtyInCartIcon').should("eq", String(expectedQty));
        })    
    })

    it('Multiple Scenarios Workflow. Match Products Item Price with Cart Item Price', () => {
        //Arrange
        const productsPage = new ProductsPage();
        const cartPage = new CartPage();
    
        cy.get('@cartdata').then((cartdata:any) => {
            //Act
            productsPage.addToCart(cartdata.product2);
            productsPage.addToCart(cartdata.product3);

            productsPage.getAddedProductPrice(cartdata.product2).as('product1PriceInProductsPage');
            productsPage.getAddedProductPrice(cartdata.product3).as('product2PriceInProductsPage');
            
            productsPage.goToCart();
            cartPage.getAddedProductPrice(cartdata.product2).as('product1PriceInCartPage');
            cartPage.getAddedProductPrice(cartdata.product3).as('product2PriceInCartPage');

            
            //Assert
            cy.get('@product1PriceInProductsPage').then((product1PriceInProductsPage:any) => {
                cy.get('@product1PriceInCartPage').should('eq', product1PriceInProductsPage);
            });
            cy.get('@product2PriceInProductsPage').then((product2PriceInProductsPage:any) => {
                cy.get('@product2PriceInCartPage').should('eq', product2PriceInProductsPage);
            });
        })    
    })

    it('Multiple Scenarios Workflow. Match Cart Icon qty and products qty in Cart Page', () => {
        //Arrange
        const productsPage = new ProductsPage();
        const cartPage = new CartPage();
        
        cy.get('@cartdata').then((cartdata:any) => {
            //Act
            productsPage.addToCart(cartdata.product2);
            productsPage.addToCart(cartdata.product3);

            productsPage.goToCart();
            cartPage.removeFromCart(cartdata.product3);

            cartPage.elements.productsQtyInCartIcon().as('productsQtyInCartIcon');
            cartPage.elements.productsQtyInCart().as('productsQtyInCart');
            
            //Assert
            cy.get('@productsQtyInCartIcon').then((productsQtyInCartIcon:any) => {
                cy.get('@productsQtyInCart').should('eq', productsQtyInCartIcon);
            })
        })    
    })

    it('Multiple Scenarios Workflow. Match Products price with Checkout total', () => {
        //Arrange
        const productsPage = new ProductsPage();
        const cartPage = new CartPage();
        const checkoutPage = new CheckoutPage();
        
        cy.get('@cartdata').then((cartdata:any) => {
            //Act
            productsPage.addToCart(cartdata.product2);
            productsPage.addToCart(cartdata.product3);
            productsPage.getAddedProductPrice(cartdata.product2).as('product2PriceInProductsPage');

            productsPage.goToCart();
            
            cartPage.removeFromCart(cartdata.product3);

            cartPage.checkout();
            
            checkoutPage.elements.firstNameInput().type(faker.person.firstName());
            checkoutPage.elements.lastNameInput().type(faker.person.lastName());
            checkoutPage.elements.postalCodeInput().type(faker.location.zipCode());

            checkoutPage.continue();

            checkoutPage.elements.itemTotal().as('itemTotal');

            //Assert
            cy.get('@itemTotal').then((itemTotal:any) => {
                cy.get('@product2PriceInProductsPage').should('eq', itemTotal);
            });
        })    
    })
});

function isSorted(arr: number[]): boolean {
    for (let i = 1; i < arr.length; i++) {
        if (arr[i-1] > arr[i]) {
            return false;
        }
    }
    return true;
}