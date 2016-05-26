(function () {
    'use strict';

    angular
        .module('app')
        .factory('HomeService', HomeService);

    HomeService.$inject = ['$http'];

    function HomeService($http) {

        function getAllProfessions() {
            return $http.get('/home/GetAllProfessions');
        }

        function getDetailsByProfessionId(id) {
            return $http.get('/home/GetDetailsByProfessionId/' + id);
        }

        function addToBucket(bucket) {
            return $http.post('/home/AddToBucket', bucket);
        }

        var service = {
            addToBucket: addToBucket,
            getDetailsByProfessionId: getDetailsByProfessionId,
            getAllProfessions: getAllProfessions
        };

        return service;
    }
})();