import LoginPage from "../pageobjects/login";
import ProductsPage from "../pageobjects/products";

describe('Feature 1. Auth Pages', () => {
  it('Case 1. Sucessful Login', () => {
    //Arrange
    const loginPage = new LoginPage();

    cy.fixture('validcredentials').then((validcredentials) => {
      //Act
      loginPage.visit();
      loginPage.elements.usernameInput().type(validcredentials.username);
      loginPage.elements.passwordInput().type(validcredentials.password);
      loginPage.elements.loginButton().click();
      
      //Assert
      cy.url().should('include', '/inventory.html')
    });    
  })

  it('Case 2. Failed Login', () => {
    //Arrange
    const loginPage = new LoginPage();
    
    cy.fixture('invalidcredentials').then((invalidcredentials) => {
      //Act
      loginPage.visit();
      loginPage.elements.usernameInput().type(invalidcredentials.username);
      loginPage.elements.passwordInput().type(invalidcredentials.password);
      loginPage.elements.loginButton().click();
      
      //Assert
      loginPage.elements.errorMessage().should('exist')
    });   
  })

  it('Case 3. Logout', () => {
    //Arrange
    const loginPage = new LoginPage();
    const prodsPage = new ProductsPage();
    
    //Act
    cy.fixture('validcredentials').then((creds) => {
      loginPage.visit();
      loginPage.login(creds.username, creds.password);
    })
    prodsPage.openMenu()
    prodsPage.logout()
    
    //Assert
    loginPage.elements.loginButton().should('exist')
  })
})