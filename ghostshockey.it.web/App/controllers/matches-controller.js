app.controller('MatchesController', function ($scope, $http, MatchesService) {

    var store = new DevExpress.data.ODataStore({
        url: "http://api-ghosts.azurewebsites.net/odata/Matches",
        key: "MatchID",
        keyType: "Int32",
        version: 4
    });

    var storeTeams = new DevExpress.data.ODataStore({
        url: "http://api-ghosts.azurewebsites.net/odata/Teams",
        key: "TeamID",
        keyType: "Int32",
        version: 4
    });

    var storeMatchTypes = new DevExpress.data.ODataStore({
        url: "http://api-ghosts.azurewebsites.net/odata/MatchTypes",
        key: "MatchTypeID",
        keyType: "Int32",
        version: 4
    });

    var storeTournaments = new DevExpress.data.ODataStore({
        url: "http://api-ghosts.azurewebsites.net/odata/Tournaments",
        key: "TournamentID",
        keyType: "Int32",
        version: 4
    });

    var states = [{
        "ID": 0,
        "Name": "Open"
    }, {
        "ID": 1,
        "Name": "Closed"
    }, {
        "ID": 2,
        "Name": "Uploaded"
    }];

    $scope.dataGridOptions = {
        dataSource: store,
        allowColumnResizing: true,
        columnAutoWidth: true,
        hoverStateEnabled: true,
        selection: {
            mode: "single"
        },
        paging: {
            pageSize: 20
        },
        filterRow : {
            visible: true,
            applyFilter: "auto"
        },
        headerFilter : {
            visible: true
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
            caption: "ID",
            dataField: "MatchID",
            allowEditing: false,
            width: 50,
            alignment: 'center'
            }, {
                dataField: "HomeTeamID",
                width: 180,
                lookup: {
                    dataSource: storeTeams,
                    displayExpr: "Name",
                    valueExpr: "TeamID"
                }
            }, {
                dataField: "HomeTeamScore",
                width: 40,
                alignment: 'center'
            }, {
                dataField: "AwayTeamID",
                width: 180,
                lookup: {
                    dataSource: storeTeams,
                    displayExpr: "Name",
                    valueExpr: "TeamID"
                }
            }, {
                dataField: "AwayTeamScore",
                width: 40,
                alignment:'center'
            }, {
                dataField: "MatchDate",
                width: 80,
                alignment: 'right'
            }, {
                dataField: "MatchCode",
                width: 50,
                hidingPriority: 0
            }, {
                dataField: "MatchRound",
                width: 50,
                hidingPriority: 1
            }, {
                dataField: "MatchStatus",
                width: 70,
                lookup: {
                    dataSource: states,
                    displayExpr: "Name",
                    valueExpr: "ID"
                }
            }, {
                dataField: "MatchTypeID",
                width: 70,
                lookup: {
                    dataSource: storeMatchTypes,
                    displayExpr: "MatchType1",
                    valueExpr: "MatchTypeID"
                },
                hidingPriority: 2
            }, {
                dataField: "TournamentID",
                width: 100,
                lookup: {
                    dataSource: storeTournaments,
                    displayExpr: "Name ",
                    valueExpr: "TournamentID"
                }
            }, {
                dataField: "StatTeamID",
                width: 100,
                lookup: {
                    dataSource: storeTeams,
                    displayExpr: "Name",
                    valueExpr: "TeamID"
                },
                hidingPriority: 0
            }],
        onSelectionChanged: function (selectedItems) {
            alert(selectedItems.selectedRowsData[0]);
        }
    }

});