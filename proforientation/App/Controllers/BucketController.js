(function () {
    'use strict';

    angular
        .module('app')
        .controller('BucketController', BucketController);

    BucketController.$inject = ['$scope', 'BucketService'];

    function BucketController($scope, BucketService) {

        $scope.orders = [];

        BucketService.getAllOrders()
            .success(function (data) {
                $scope.orders = data;
            });

        $scope.SubmitOrders = function () {

            BucketService.clearOrder()
                .success(function() {
                    getOrders();
                });
        };

        function getOrders() {
            BucketService.getAllOrders()
                .success(function (data) {
                    $scope.orders = data;
            });
        }
    }
})();
