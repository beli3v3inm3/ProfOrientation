(function () {
    'use strict';

    angular
        .module('app')
        .factory('BucketService', BucketService);

    BucketService.$inject = ['$http'];

    function BucketService($http) {

        function getAllOrders() {
            return $http.get('/bucket/GetAllOrders');
        }

        function clearOrder() {
            return $http.delete('/bucket/CleatOrders');
        }

        var service = {
            getAllOrders: getAllOrders,
            clearOrder: clearOrder
        };

        return service;
    }
})();