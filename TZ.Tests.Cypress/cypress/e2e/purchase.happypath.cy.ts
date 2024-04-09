///<reference types='cypress'/>

import CartPage from "../pageobjects/cart"
import CheckoutPage from "../pageobjects/checkout"
import LoginPage from "../pageobjects/login"
import ProductsPage from "../pageobjects/products"
import { faker } from '@faker-js/faker';

const cartdata = require('../fixtures/cartdata.json')


describe('Feature 2. Cart', () => {
  beforeEach(() => {
    cy.clearAllCookies()
    cy.clearAllLocalStorage()
    cy.clearAllSessionStorage()

    const loginPage = new LoginPage();
    cy.fixture('validcredentials').then((creds) => {
      loginPage.visit();
      loginPage.login(creds.username, creds.password);
    });;
  })

  Array.from([cartdata.product1, cartdata.product2, cartdata.product3]).forEach((product:string) => {
    it(`Happy Path. Add Product: ${product}`, () => {
      //Arrange
      const productsPage = new ProductsPage();
      const cartPage = new CartPage();

      //Act
      productsPage.addToCart(product)
      productsPage.goToCart()

      //Assert
      cartPage.getProduct(product).should('exist')
    })
  })

  it('Happy Path. Checkout', () => {
    //Arrange
    const productsPage = new ProductsPage();
    const cartPage = new CartPage();
    const checkoutPage = new CheckoutPage();
    
    //Act
    productsPage.addToCart(cartdata.product1)
    productsPage.goToCart()

    cartPage.checkout()

    checkoutPage.elements.firstNameInput().type(faker.person.firstName())
    checkoutPage.elements.lastNameInput().type(faker.person.lastName())
    checkoutPage.elements.postalCodeInput().type(faker.location.zipCode())

    checkoutPage.continue()
    checkoutPage.finish()

    //Assert
    checkoutPage.elements.completeMessageContainer().should('contain.text', cartdata.successMessage)
  })
})