(function() {
    'use strict';

    angular
        .module('app')
        .controller('TestController', TestController);

    TestController.$inject = ['$scope', 'TestService'];

    function TestController($scope, TestService) {

        $scope.currentAnswer = null;
        $scope.setAnswer = function (answer, id) {
            $scope.binding.answers[id] = answer;
        };
        $scope.getQuestions = [];
        $scope.testAnswers = [];
        $scope.questions = [];
        $scope.binding = {
            answers: {}
        };
        $scope.profesions = [];
        $scope.showResult = false;

        Testing();


        function Testing() {
            var id = 1;

            TestService.getTestById(id)
                .success(function(data) {
                    $scope.questions = data;
                    //$scope.getQuestions.push(data);
                });
            TestService.getAnswerByTestId(id)
                .success(function(data) {
                    $scope.testAnswers = data;
                });

            $scope.nextQuestion = function() {
                id++;

                TestService.getTestById(id)
                    .success(function(data) {
                        if (data[0] != null) {
                            $scope.questions = data;
                            //$scope.getQuestions.push(data);
                            //$scope.currentAnswer = $scope.binding.answers[id];
                        } else {
                            id--;
                            $(".btn-submit")
                                .show("fast",
                                    function() {
                                    });

                        }
                    });

                TestService.getAnswerByTestId(id)
                    .success(function(data) {
                        if (data[0] != null) {
                            $scope.testAnswers = data;
                            //$scope.getQuestions.push(data);
                            $scope.currentAnswer = $scope.binding.answers[id];
                        } else {
                            id--;
                            $(".btn-submit")
                                .show("fast",
                                    function() {
                                    });

                        }
                    });
            };

            $scope.prevQuestion = function() {
                id--;
                TestService.getTestById(id)
                    .success(function(data) {
                        if (data[0] != null) {
                            $scope.questions = data;
                            //$scope.currentAnswer = $scope.binding.answers[id];
                        } else {
                            id++;

                        }
                    });
                TestService.getAnswerByTestId(id)
                    .success(function(data) {
                        if (data[0] != null) {
                            $scope.testAnswers = data;
                            $scope.currentAnswer = $scope.binding.answers[id];
                        } else {
                            id++;

                        }
                    });
            };

            $scope.onSubmit = function() {
                $scope.score = null;
                $scope.showResult = true;
                angular.forEach($scope.binding.answers,
                    function(value, key) {
                        $scope.score += value;
                    });

                TestService.getAllProfessions().then(function (results) {
                    $scope.profesions = results.data;

                    $scope.profesions.forEach(function (profession) {

                        if ($scope.score >= profession.ScoreMin && $scope.score <= profession.ScoreMax) {
                            $scope.result = profession.Name;
                        }

                    });
                });
            };
        }
    }
})();
