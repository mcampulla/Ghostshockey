app.controller('PlayersController', function ($scope, $http, PlayersService) {

    var store = new DevExpress.data.ODataStore({
        url: "http://api-ghosts.azurewebsites.net/odata/Players",
        key: "PlayerID",
        keyType: "Int32",
        version: 4
    });

    var storeClubs = new DevExpress.data.ODataStore({
        url: "http://api-ghosts.azurewebsites.net/odata/Clubs?$select=ClubID,Name",
        key: "ClubID",
        keyType: "Int32",
        version: 4
    });

    var storeCategories = new DevExpress.data.ODataStore({
        url: "http://api-ghosts.azurewebsites.net/odata/Categories?$select=CategoryID,Name",
        key: "CategoryID",
        keyType: "Int32",
        version: 4
    });

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
                dataField: "PlayerID",
                allowEditing: false,
                width: 70,
                alignment: 'center'
        }, "LastName", "FirstName", "Address", "City", "Zip", "Region", {
            dataField: "Birth",
            width: 120,
            validationRules: [{ type: "required" }]
        }, "Email", "Phone", "Mobile" ]
    }

});