import { defineConfig } from "cypress";

export default defineConfig({
    e2e: {
        baseUrl: 'https://www.saucedemo.com',
        pageLoadTimeout: 10000,
        trashAssetsBeforeRuns: true,
        defaultCommandTimeout: 10000,
        chromeWebSecurity: false,
        setupNodeEvents(on, config) {
            // implement node event listeners here
        },
    },
});
