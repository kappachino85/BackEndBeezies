var beb = {
    utilities: {}
    , layout: {}
    , page: {
        handlers: {
        }
        , startUp: null
    }
    , services: {}
    , ui: {}
  
};
beb.moduleOptions = {
        APPNAME: "bebApp"
        , extraModuleDependencies: []
    , runners: []
    , page: beb.page//we need this object here for later use
}


sabio.layout.startUp = function () {

    console.debug("beb.layout.startUp");

    //this does a null check on sabio.page.startUp
    if (sabio.page.startUp) {
        console.debug("sabio.page.startUp");
        sabio.page.startUp();
    }
};

beb.APPNAME = "backApp";//legacy

$(document).ready(beb.layout.startUp);