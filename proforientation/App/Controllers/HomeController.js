(function () {
    'use strict';

    angular
        .module('app')
        .controller('HomeController', HomeController);

    HomeController.$inject = ['$scope', 'HomeService'];

    function HomeController($scope, HomeService) {

        $scope.professions = [];

        HomeService.getAllProfessions()
            .success(function (data) {
                $scope.professions = data;
            });

        $scope.addProf = function(id) {
            var bucket = {
                ProfId: +id
            };
            HomeService.addToBucket(bucket)
                .success(function() {});
        };
    }
})();
