app.controller('ClubsController', function ($scope, $http, ClubsService) {

    var store = new DevExpress.data.ODataStore({
        url: "http://api-ghosts.azurewebsites.net/odata/Clubs",
        key: "ClubID",
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
            dataField: "ClubID",
            allowEditing: false,
            width: 70,
            alignment: 'center'
        }, "Name", "Address", "Cap", "City", "Region", "Phone", "Mobile", "Email", {
            dataField: "Type",
            width: 100,
            lookup: {
                dataSource: types,
                displayExpr: "Name",
                valueExpr: "ID"
            },
            validationRules: [{ type: "required" }]
        }, "Tag", "Icon"]
    }

});