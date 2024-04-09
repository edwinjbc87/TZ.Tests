import ProtectedPage from "./protectedpage";

class CheckoutPage extends ProtectedPage {
    elements = {
        firstNameInput: ()=> cy.get("input[data-test='firstName']"),
        lastNameInput: ()=> cy.get("input[data-test='lastName']"),
        postalCodeInput: ()=> cy.get("input[data-test='postalCode']"),
        continueButton: ()=> cy.get("input[data-test='continue']"),
        finishButton: ()=> cy.get("button[data-test='finish']"),
        itemTotal: ()=> cy.get("div[data-test='subtotal-label']").invoke('text').then((text) => parseFloat(text.replace('Item total: $',''))),
        completeMessageContainer: ()=> cy.get("div[data-test='checkout-complete-container']")
    }

    continue() {
        cy.get("input[data-test='continue']").click()
    }
    finish() {
        cy.get("button[data-test='finish']").click()
    }
}

export default CheckoutPage;