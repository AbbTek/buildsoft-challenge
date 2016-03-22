(function () {
    'use strict';

    angular
       .module('buildsoft.person')
       .controller('personController', personController);

    function personController($scope, personService) {
        $scope.people = [];

        $scope.getPeople = function (page) {
            personService.getPeople(page)
            .then(function (result) {
                $scope.people = result.data.List;
                $scope.totalItems = result.data.TotalPeople;
                $scope.itemsPerPage = result.data.ItemsPerPage;
            });
        };

        $scope.pageChanged = function () {
            $scope.getPeople($scope.currentPage);
        };

        $scope.getPeople(1);
    }
})();