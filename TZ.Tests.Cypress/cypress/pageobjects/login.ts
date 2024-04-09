class LoginPage {
  elements = {
    usernameInput: () => cy.get('input[data-test="username"]'),
    passwordInput: () => cy.get('input[data-test="password"]'),
    loginButton: () => cy.get('input[data-test="login-button"]'),
    errorMessage: () => cy.get('[data-test="error"]'),
  } 

  visit() {
    cy.visit('/');
  }

  login(email: string, password: string) {
    this.elements.usernameInput().type(email);
    this.elements.passwordInput().type(password);
    this.elements.loginButton().click();
  }
}

export default LoginPage;