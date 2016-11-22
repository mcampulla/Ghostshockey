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
        columns: [{
            caption:"ID",
            dataField: "ClubID",
            allowEditing: false,
            width: 50,
            alignment: 'center'
        }, "Name", "Address", {
            dataField: "Cap",
            width: 60
        }, "City", {
            dataField: "Region",
            width: 40
        }, "Phone", "Mobile", {
            dataField: "Email",
            width: 40,
            cellTemplate: "emailTemplate"
        }, {
            dataField: "Type",
            width: 50,
            lookup: {
                dataSource: types,
                displayExpr: "Name",
                valueExpr: "ID"
            },
            validationRules: [{ type: "required" }]
        }, {
            dataField: "Tag",
            width: 50
        }, {
            dataField: "Icon",
            width: 40,
            cellTemplate: "iconTemplate"
        }]
    }

});