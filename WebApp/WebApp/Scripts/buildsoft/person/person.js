(function () {
    'use strict';

    angular
       .module('buildsoft.person')
       .controller('personController', personController);

    function personController($scope, personService) {
        $scope.people = [];
        $scope.personType = 0;
        $scope.currentPage = 1;

        $scope.getPeople = function (page, personType) {
            personService.getPeople(page, personType)
            .then(function (result) {
                $scope.people = result.data.List;
                $scope.totalItems = result.data.TotalPeople;
                $scope.itemsPerPage = result.data.ItemsPerPage;
                $scope.currentPage = result.data.CurrentPage;
                $scope.maxAge = result.data.MaxAge;
                $scope.minAge = result.data.MinAge;
                $scope.averageAge = result.data.AverageAge;
            });
        };

        $scope.pageChanged = function () {
            $scope.getPeople($scope.currentPage, $scope.personType);
        };

        $scope.typeChanged = function () {
            $scope.getPeople($scope.currentPage, $scope.personType);
        };

        $scope.addOneYear = function () {
            personService.addOneYear()
            .then(function (result) {
                $scope.getPeople($scope.currentPage, $scope.personType);
            });
        };

        $scope.restart = function () {
            personService.restart()
            .then(function (result) {
                $scope.init();
            });
        };

        $scope.init = function () {
            $scope.getPeople(1, $scope.personType);
            personService.getConsolidatedData()
            .then(function (result) {
                $scope.totalAngles = result.data['Angle'];
                $scope.totalAsians = result.data['Asian'];
                $scope.totalJutes = result.data['Jute'];
                $scope.totalSaxons = result.data['Saxon'];
            });
        };

        $scope.init();
    }
})();