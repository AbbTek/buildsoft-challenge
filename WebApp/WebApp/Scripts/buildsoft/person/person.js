(function () {
    'use strict';

    angular
       .module('buildsoft.person')
       .controller('personController', personController);

    function personController($scope, personService) {
        $scope.people = [];

        $scope.getPeople = function () {
            personService.getPeople()
            .then(function (result) {
                $scope.people = result.data;
            });
        };

        $scope.getPeople();
    }
})();