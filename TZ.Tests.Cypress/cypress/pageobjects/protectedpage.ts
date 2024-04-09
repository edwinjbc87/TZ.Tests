class ProtectedPage {
    logout() {
        cy.get("a[data-test='logout-sidebar-link']").click();
    }
    openMenu() {
        cy.get("img[data-test='open-menu']").siblings("button").click();
    }
}

export default ProtectedPage;