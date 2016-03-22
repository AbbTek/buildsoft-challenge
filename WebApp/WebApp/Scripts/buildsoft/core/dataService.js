(function () {
    'use strict';

    angular
        .module('buildsoft.core')
        .factory('personService', personService);

    function personService($http) {
        return {
            getPeople: function (page) {
                return $http.get('/api/person/getPeople', { params: { page: page } });
            }
        };
    }
})();