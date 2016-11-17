app.controller('YearsController', function ($scope, $http, YearsService) {

    $scope.LoadMe = function () {
        alert('loadme');
    }

    $scope.LoadYears = function () {

        YearsService.GetYears()
            .then(function (result) { // success
                $scope.years = result.Data;
            }), function () { //error

            };

    };

    $scope.LoadYear = function (yearID) {

        YearsService.GetYear(yearID)
            .then(function (result) { // success
                $scope.year = result.Data;
            }), function () { //error

            };

    };
});