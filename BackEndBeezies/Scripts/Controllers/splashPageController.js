(function () {

    'use strict';

    angular.module("bebApp").controller('splashPageController', SplashPageController);
    SplashPageController.$inject = ['splashPageService', '$scope', '$location', '$window'];

    function SplashPageController(splashPageService, $scope, $location, $window) {
        var vm = this;
        vm.splashPageService = splashPageService;
        vm.$scope = $scope;
        vm.$location = $location;
        vm.$window = $window;

        vm.userRegistration = {};
        vm.register = _register;

        function _register(data) {
            vm.splashPageService.register(data).then(function () {
                console.log('successful registration');
            }).catch(function (ex) {
                console.log(ex.statusText);
            })
        }
    }

})();