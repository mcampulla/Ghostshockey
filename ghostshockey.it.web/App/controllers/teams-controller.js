app.controller('TeamsController', function ($scope, $http, TeamsService) {

    var store = new DevExpress.data.ODataStore({
        url: "http://api-ghosts.azurewebsites.net/odata/Teams",
        key: "TeamID",
        keyType: "Int32",
        version: 4
    });

    var storeClubs = new DevExpress.data.ODataStore({
        url: "http://api-ghosts.azurewebsites.net/odata/Clubs",
        key: "ClubID",
        keyType: "Int32",
        version: 4
    });

    var storeCategories = new DevExpress.data.ODataStore({
        url: "http://api-ghosts.azurewebsites.net/odata/Categories",
        key: "CategoryID",
        keyType: "Int32",
        version: 4
    });

    $scope.dataGridOptions = {
        dataSource: store,
        allowColumnResizing: true,
        paging: {
            pageSize: 20
        },
        pager: {
            showPageSizeSelector: true,
            allowedPageSizes: [10, 20, 50],
            showInfo: true
        },
        editing: {
            mode: "form",
            allowUpdating: true,
            allowDeleting: true,
            allowAdding: true
        },
        grouping: {
            autoExpandAll: true
        },
        groupPanel: {
            visible: true
        },
        //filterRow: {
        //    visible: true,
        //    applyFilter: "auto"
        //},
        headerFilter: {
            visible: true
        },
        columns: [{
            dataField: "TeamID",
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
            },
            validationRules: [{ type: "required" }]
        }, {
            dataField: "ClubID",
            width: 200,
            groupIndex:0,
            lookup: {
                dataSource: storeClubs,
                displayExpr: "Name",
                valueExpr: "ClubID"
            },
            validationRules: [{ type: "required" }]
        }]
    }

});