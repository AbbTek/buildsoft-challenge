(function () {
    'use strict';

    angular
        .module('buildsoft.core')
        .factory('personService', personService);

    function personService($http) {
        return {
            getPeople: function (page, personType) {
                return $http.get('/api/person/getpeople', { params: { page: page, personType: personType } });
            },
            addOneYear: function () {
                return $http.post('/api/person/addoneyear');
            },
            getConsolidatedData: function () {
                return $http.get('/api/person/getconsolidateddata');
            },
            restart: function () {
                return $http.post('/api/person/restart');
            }
        };
    }
})();