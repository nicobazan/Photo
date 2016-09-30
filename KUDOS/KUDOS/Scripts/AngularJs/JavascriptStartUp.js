var kudos = {
    utilities: {}
    , layout: {}
    , page: {
        handlers: {
        }
    }
    , services: {}
    , ui: {}

};
kudos.moduleOptions = {
    APPNAME: "mainApp"
        , extraModuleDependencies: []
        , runners: []
        , page: kudos.page//we need this object here for later use
}


kudos.layout.startUp = function () {

    console.debug("kudos.layout.startUp");

    //this does a null check on sabio.page.startUp
    if (kudos.page.startUp) {
        console.debug("kudos.page.startUp");
        kudos.page.startUp();
    }
};
kudos.APPNAME = "mainApp";//legacy



$(document).ready(kudos.layout.startUp);