app.factory("YearsService", function ($http, $q) {

    //var token = sessionStorage.getItem('accessToken');
    var token = "eyJ0eXAiOiJKV1QiLCJhbGciOiJIUzI1NiJ9.eyJzdWIiOiJtYXJjbyIsImVtYWlsIjoibWFyY28iLCJ2ZXIiOiIzIiwiaXNzIjoiaHR0cHM6Ly9hcGktZ2hvc3RzLmF6dXJld2Vic2l0ZXMubmV0LyIsImF1ZCI6Imh0dHBzOi8vYXBpLWdob3N0cy5henVyZXdlYnNpdGVzLm5ldC8iLCJleHAiOjE0Nzk0OTA5MzAsIm5iZiI6MTQ3OTQwNDUzMH0.GjmHG6IEVTkVmIhbMGhd4Xyxv9UwdGQEpB8QuNWlgEQ";
    //var _sediEnergia = [];

    //var _sediEnergiaLoaded = false;
    
    var _getYears = function () {

        var deferred = $q.defer();

        $http({
            url: config.apiurl + "odata/Years",
            method: "Get",
            headers: {
                "Authorization": "Bearer " + token
            }
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
            method: "Get",
            //,
            //data: {
            //    "idTabOPE_Contratti_Volture": idVoltura.toString(),
            //    "idSede": idSede,
            //    "includi": includi,
            //    "idTabCFG_Azienda": idTabCFG_Azienda
            //},
            headers: {
                "Authorization": "Bearer " + token
            }
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