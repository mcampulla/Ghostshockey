"use strict";

var app = angular.module("home-index", ['dx']);

app.controller('home-index-controller', ["$scope", "$http", "home-index-service", function ($scope, $http, service) {

    $scope.test = "test";

}]);

app.factory("home-index-service", function ($http, $q) {

    //var token = sessionStorage.getItem('accessToken');
    var token = "eyJ0eXAiOiJKV1QiLCJhbGciOiJIUzI1NiJ9.eyJzdWIiOiJtYXJjbyIsImVtYWlsIjoibWFyY28iLCJ2ZXIiOiIzIiwiaXNzIjoiaHR0cHM6Ly9hcGktZ2hvc3RzLmF6dXJld2Vic2l0ZXMubmV0LyIsImF1ZCI6Imh0dHBzOi8vYXBpLWdob3N0cy5henVyZXdlYnNpdGVzLm5ldC8iLCJleHAiOjE0Nzk1NDYxOTgsIm5iZiI6MTQ3OTQ1OTc5OH0.t7OEn6TV1KOCmZZlUY9PnjNu0z-KaN4RS1VSJ3OmytM";
    //var _sediEnergia = [];

    //var _sediEnergiaLoaded = false;

    var _getCategories = function () {

        var deferred = $q.defer();

        $http({
            url: config.apiurl + "odata/Categories",
            method: "GET"
            //,headers: {
            //    "X-ZUMO-AUTH": token
            //}
        }).then(function (result) {
            deferred.resolve({ "Data": result.data.value });
        }, function () { // failure
            deferred.reject("Errore durante la richiesta di elaborazione stagioni.");
        });

        return deferred.promise;
    };


    return {
        GetCategories: _getCategories
    };
});