(function () {
    'use strict';

    angular
        .module('buildsoft.core')
        .factory('personService', personService);

    function personService($http) {
        return {
            getPeople: function () {
                return $http.get('/api/person/getPeople');
            }
        };
    }
})();