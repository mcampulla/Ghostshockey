app.controller('TournamentsController', function ($scope, $http, TournamentsService) {

    var store = new DevExpress.data.ODataStore({
        url: "http://api-ghosts.azurewebsites.net/odata/Tournaments",
        key: "TournamentID",
        keyType: "Int32",
        version: 4
    });

    var types = [{
        "ID": 0,
        "Name": "Team"
    }, {
        "ID": 1,
        "Name": "State"
    }, {
        "ID": 2,
        "Name": "Country"
    }];

    $scope.dataGridOptions = {
        dataSource: store,
        paging: {
            pageSize: 20
        },
        pager: {
            showPageSizeSelector: true,
            allowedPageSizes: [10, 20, 50],
            showInfo: true
        },
        editing: {
            mode: "row",
            allowUpdating: true,
            allowDeleting: true,
            allowAdding: true
        },
        columns: [{
            dataField: "TournamentID",
            allowEditing: false,
            width: 70,
            alignment: 'center'
        }, {
            caption: "Name",
            dataField: "Tournament1",
            validationRules: [{ type: "required" }]
        }, "Description", {
            dataField: "DateStart",
            width: 120,
            validationRules: [{ type: "required" }]
        }, {
            dataField: "DateEnd",
            width: 120,
            validationRules: [{ type: "required" }]
        }]
    }

});