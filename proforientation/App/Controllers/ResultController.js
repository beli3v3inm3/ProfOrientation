(function () {
    'use strict';

    angular
        .module('app')
        .controller('ResultController', ResultController);

    ResultController.$inject = ['$scope', 'ResultService'];

    function ResultController($scope, ResultService) {

        $scope.subProfessions = [];

        ResultService.getAllSubProfessions()
            .success(function (data) {
                $scope.subProfessions = data;
            });

        //$scope.addProf = function (id) {
        //    var bucket = {
        //        ProfId: +id
        //    };
        //    HomeService.addToBucket(bucket)
        //        .success(function () { });
        //};
    }
})();
