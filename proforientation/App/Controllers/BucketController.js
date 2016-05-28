(function () {
    'use strict';

    angular
        .module('app')
        .controller('BucketController', BucketController);

    BucketController.$inject = ['$scope', 'BucketService'];

    function BucketController($scope, BucketService) {

        $scope.orders = [];
        $scope.isEmpty = false;
        $scope.clearBucket = "123";

        BucketService.getAllOrders()
            .then(function (result) {
                $scope.orders = result.data;

                if ($scope.orders.length === 0) {
                    $scope.isEmpty = true;
                    $scope.clearBucket = "Bucket is clear.";
                }
                //$scope.orders.forEach(function(data) {
                //    if (data.Id === null) {
                //        $scope.isEmpty = true;
                //        $scope.msg = "Bucket is clear.";
                //    }
                //});
            });

        $scope.SubmitOrders = function () {
            var bucket = {
                Id: 1
            };
            BucketService.clearOrder(bucket)
                .success(function (data) {

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
