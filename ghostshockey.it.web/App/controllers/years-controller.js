app.controller('YearsController', function ($scope, $http, YearsService) {

    var store = new DevExpress.data.ODataStore({
        url: "http://api-ghosts.azurewebsites.net/odata/Years",
        key: "YearID",
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
            caption: "ID",
            dataField: "YearID",
            allowEditing: false,
            width: 70,
            alignment: 'center'
        }, {
            dataField: "Name"
        }, {
            dataField: "DateStart",
            validationRules: [{ type: "required" }]
        }, {
            dataField: "DateEnd",
            validationRules: [{ type: "required" }]
        }, {
            dataField: "IsCurrent"
        }],
    }

});