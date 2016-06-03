(function () {
    'use strict';

    angular
        .module('app')
        .factory('TestService', TestService);

    TestService.$inject = ['$http'];

    function TestService($http) {

        function getAllTest() {
            return $http.get('/test/GetAllTest');
        }

        function getTestById(id) {
            return $http.get('/test/GetTestById/' + id);
        }

        function getAnswerByTestId(id) {
            return $http.get('/test/GetAnswerByTestId/' + id);
        }

        function getAllProfessions() {
            return $http.get('/test/GetAllProfessions');
        }

        function submitTest(testResult) {
            return $http.post('/test/TestResult', testResult);
        }

        var service = {
            getAllTest: getAllTest,
            getTestById: getTestById,
            getAnswerByTestId: getAnswerByTestId,
            getAllProfessions: getAllProfessions,
            submitTest: submitTest
        };

        return service;
    }
})();