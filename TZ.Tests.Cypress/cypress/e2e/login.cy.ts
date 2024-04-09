import LoginPage from "../pageobjects/login";

describe('Feature 1. Login Page', () => {
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
})