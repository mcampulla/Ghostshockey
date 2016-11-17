app.factory("YearsService", function ($http, $q) {

    //var token = sessionStorage.getItem('accessToken');

    //var _sediEnergia = [];

    //var _sediEnergiaLoaded = false;
    
    var _getYears = function () {

        var deferred = $q.defer();

        $http({
            url: config.apiurl + "odata/Years",
            method: "Get"
            //,
            //headers: {
            //    "Authorization": "Bearer " + token
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
            //},
            //headers: {
            //    "Authorization": "Bearer " + token
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