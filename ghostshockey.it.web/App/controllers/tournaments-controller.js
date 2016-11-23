app.controller('TournamentsController', function ($scope, $http, TournamentsService) {

    var store = new DevExpress.data.ODataStore({
        url: "http://api-ghosts.azurewebsites.net/odata/Tournaments",
        key: "TournamentID",
        keyType: "Int32",
        version: 4
    });

    var storeCategories = new DevExpress.data.ODataStore({
        url: "http://api-ghosts.azurewebsites.net/odata/Categories",
        key: "CategoryID",
        keyType: "Int32",
        version: 4
    });

    var storeYears = new DevExpress.data.ODataStore({
        url: "http://api-ghosts.azurewebsites.net/odata/Years",
        key: "YearID",
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
        selection: {
            mode: "single"
        },
        paging: {
            pageSize: 20
        },        
        headerFilter: {
            visible: true
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
            caption: "ID",
            dataField: "TournamentID",
            allowEditing: false,
            width: 70,
            alignment: 'center'
        }, {
            dataField: "Name",
            validationRules: [{ type: "required" }]
        }, {
            dataField: "CategoryID",
            width: 100,
            lookup: {
                dataSource: storeCategories,
                displayExpr: "Name",
                valueExpr: "CategoryID"
            }
        }, {
            dataField: "YearID",
            width: 100,
            lookup: {
                dataSource: storeYears,
                displayExpr: "Name",
                valueExpr: "YearID"
            }
        }, {
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