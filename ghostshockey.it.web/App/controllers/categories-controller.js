app.controller('CategoriesController', function ($scope, $http, CategoriesService) {

    var store = new DevExpress.data.ODataStore({
        url: "http://api-ghosts.azurewebsites.net/odata/Categories",
        key: "CategoryID",
        keyType: "Int32",
        version: 4
    });

    var states = [{
        "ID": 1,
        "Name": "Enabled"
    }, {
        "ID": 0,
        "Name": "Disabled"
    }];

    $scope.dataGridOptions = {
        dataSource: store,
        paging: {
            pageSize: 20
        },
        pager: {
            showPageSizeSelector: true,
            allowedPageSizes: [5, 10, 20],
            showInfo: true
        },
        editing: {
            mode: "row",
            allowUpdating: true,
            allowDeleting: true,
            allowAdding: true
        },
        columns: [{
            dataField: "CategoryID",
            allowEditing: false,
            width: 70,
            alignment: 'center'
        }, {
            dataField: "CategoryTag",
            width: 100,
            validationRules: [{ type: "required" }]
        }, {
            dataField: "Name",
            validationRules: [{ type: "required" }]
        }, {
            dataField: "Enabled",
            width: 100,
            lookup: {
                dataSource: states,
                displayExpr: "Name",
                valueExpr: "ID"
            },
            validationRules: [{ type: "required" }]
        }]
    }

});