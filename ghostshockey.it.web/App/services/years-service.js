﻿app.factory("YearsService", function ($http, $q) {

    //var token = sessionStorage.getItem('accessToken');
    var token = "eyJ0eXAiOiJKV1QiLCJhbGciOiJIUzI1NiJ9.eyJzdWIiOiJtYXJjbyIsImVtYWlsIjoibWFyY28iLCJ2ZXIiOiIzIiwiaXNzIjoiaHR0cHM6Ly9hcGktZ2hvc3RzLmF6dXJld2Vic2l0ZXMubmV0LyIsImF1ZCI6Imh0dHBzOi8vYXBpLWdob3N0cy5henVyZXdlYnNpdGVzLm5ldC8iLCJleHAiOjE0Nzk1NDYxOTgsIm5iZiI6MTQ3OTQ1OTc5OH0.t7OEn6TV1KOCmZZlUY9PnjNu0z-KaN4RS1VSJ3OmytM";
    //var _sediEnergia = [];

    //var _sediEnergiaLoaded = false;
    
    var _getYears = function () {

        var deferred = $q.defer();

        $http({
            url: config.apiurl + "odata/Years",
            method: "Get"
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

    var _getYear = function (yearID) {

        var deferred = $q.defer();

        $http({
            url: config.apiurl + "odata/Years(" + yearID + ")",
            method: "Get"
            //,
            //data: {
            //    "idTabOPE_Contratti_Volture": idVoltura.toString(),
            //    "idSede": idSede,
            //    "includi": includi,
            //    "idTabCFG_Azienda": idTabCFG_Azienda
            //}
            //,headers: {
            //    "X-ZUMO-AUTH": token
            //}
        }).then(function (result) {
            deferred.resolve({ "Data": result.data });
        }, function () { // failure
            deferred.reject("Errore durante la richiesta di elaborazione stagione.");
        });

        return deferred.promise;
    };


    return {
        GetYears: _getYears,
        GetYear: _getYear
    };
});