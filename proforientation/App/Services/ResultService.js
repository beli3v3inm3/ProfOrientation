(function () {
    'use strict';

    angular
        .module('app')
        .factory('ResultService', ResultService);

    ResultService.$inject = ['$http'];

    function ResultService($http) {

        function getAllSubProfessions() {
            return $http.get('/result/GetSubProfessions');
        }

        var service = {
            getAllSubProfessions: getAllSubProfessions
        };

        return service;
    }
})();