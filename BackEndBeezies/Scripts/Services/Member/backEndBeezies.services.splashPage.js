(function () {

    'use strict';

    angular.module("bebApp").factory('splashPageService', SplashPageService);
    SplashPageService.$inject = ["$http", "$q"];

    function SplashPageService($http, $q) {

        var srv = {
            register: _register
        };

        return srv;

        function _register(data) {
            console.log('hitting service');
            return $http.post("/api/users/register", data)
                .then(registerSuccess)
                .catch(registerFail)

            function registerSuccess(response) {
                return response;
            }

            function registerFail(response) {
                return $q.reject(response);
            }
        }
    }

})();