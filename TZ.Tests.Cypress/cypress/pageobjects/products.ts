import ProtectedPage from "./protectedpage"

class ProductsPage extends ProtectedPage {
    elements = {
        selectedProductSortStrategyName: ()=> cy.get("span[data-test='active-option']"),
        productsQtyInCartIcon: ()=> cy.get("span[data-test='shopping-cart-badge']"),
    }
    addToCart(productName: string) {
        cy.get(`button[data-test='add-to-cart-${productName.toLowerCase().replace(/ /g,'-')}']`).click()
    }
    goToCart() {
        cy.get("a[data-test='shopping-cart-link']").click()
    }
    selectSortStrategy(sortStrategy: string) {
        cy.get("select[data-test='product-sort-container']").select(sortStrategy)
    }
    getPriceList() {
        let prices:number[] = []
        return cy.get("div[data-test='inventory-item-price']").each(($el, index, $list) => {
            prices.push(parseFloat($el.text().replace('$','')))
        })
        .then(() => {
            return prices
        })
    }
    getProductRemoveButton(productName: string) {
        return cy.get(`button[data-test='remove-${productName.toLowerCase().replace(/ /g,'-')}']`)
    }
    getAddedProductPrice(productName: string) {
        return cy.get(`button[data-test='remove-${productName.toLowerCase().replace(/ /g,'-')}']`).then(($el) => {
            return parseFloat($el.parent().find("div[data-test='inventory-item-price']").text().replace('$',''))
        })
    }
}

export default ProductsPage;