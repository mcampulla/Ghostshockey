app.factory("dataService", function ($http, $q) {

    var token = sessionStorage.getItem('accessToken');

    var _sediEnergia = [];

    var _sediEnergiaLoaded = false;
    
    var _includiSedeVoltura = function (idVoltura, idSede, includi, idTabCFG_Azienda) {

        var deferred = $q.defer();

        $http({
            url: QL.serviceUrl + "odata/Years",
            method: "Get",
            data: {
                "idTabOPE_Contratti_Volture": idVoltura.toString(),
                "idSede": idSede,
                "includi": includi,
                "idTabCFG_Azienda": idTabCFG_Azienda
            },
            headers: {
                "Authorization": "Bearer " + token
            }
        }).then(function (result) {
            deferred.resolve();
        }, function () { // failure
            deferred.reject("Errore durante la richiesta di elaborazione sede.");
        });

        return deferred.promise;
    };

    var _includiSedeVoltura = function (idVoltura, idSede, includi, idTabCFG_Azienda) {

        var deferred = $q.defer();

        $http({
            url: QL.serviceUrl + "odata/Years",
            method: "Get",
            data: {
                "idTabOPE_Contratti_Volture": idVoltura.toString(),
                "idSede": idSede,
                "includi": includi,
                "idTabCFG_Azienda": idTabCFG_Azienda
            },
            headers: {
                "Authorization": "Bearer " + token
            }
        }).then(function (result) {
            deferred.resolve();
        }, function () { // failure
            deferred.reject("Errore durante la richiesta di elaborazione sede.");
        });

        return deferred.promise;
    };


    return {
        LoadSediEnergia: _loadSediEnergia,
        SediEnergia: _sediEnergia,
    };
});