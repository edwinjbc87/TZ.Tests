import ProtectedPage from "./protectedpage";

class CartPage extends ProtectedPage {
    elements = {
        productsQtyInCartIcon: ()=> cy.get("span[data-test='shopping-cart-badge']").invoke('text').then((text) => parseInt(text)),
        productsQtyInCart: ()=> {
            let qty:number = 0;
            return cy.get("div[data-test='item-quantity']").each(($el) => {
                qty += parseInt($el.text())
            }).then(() => qty);
        },
    }
    checkout() {
        cy.get("button[data-test='checkout']").click()
    }
    getProduct(productName: string) {
        return cy.get(`div[data-test='inventory-item-name']`).contains(productName)
    }
    getAddedProductPrice(productName: string) {
        return cy.get(`button[data-test='remove-${productName.toLowerCase().replace(/ /g,'-')}']`).then(($el) => {
            return parseFloat($el.parent().find("div[data-test='inventory-item-price']").text().replace('$',''))
        })
    }
    removeFromCart(productName: string) {
        cy.get(`button[data-test='remove-${productName.toLowerCase().replace(/ /g,'-')}']`).click()
    }
}

export default CartPage;