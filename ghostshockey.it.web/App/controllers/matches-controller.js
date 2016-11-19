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
        columnAutoWidth: true,
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
            dataField: "MatchID",
            allowEditing: false,
            width: 70,
            alignment: 'center'
            }, "MatchID", {
                dataField: "HomeTeamID",
                width: 100,
                lookup: {
                    dataSource: storeTeams,
                    displayExpr: "Name",
                    valueExpr: "TeamID"
                }
            }, "HomeTeamScore", {
                dataField: "AwayTeamID",
                width: 100,
                lookup: {
                    dataSource: storeTeams,
                    displayExpr: "Name",
                    valueExpr: "TeamID"
                }
            }, "AwayTeamScore", {
                dataField: "MatchDate",
                width: 120
            }, "MatchCode", "MatchRound", {
                dataField: "MatchStatus",
                width: 100,
                lookup: {
                    dataSource: states,
                    displayExpr: "Name",
                    valueExpr: "ID"
                }
            }, {
                dataField: "MatchTypeID",
                width: 100,
                lookup: {
                    dataSource: storeMatchTypes,
                    displayExpr: "MatchType1",
                    valueExpr: "MatchTypeID"
                }
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
                dataField: "TournamentID",
                width: 100,
                lookup: {
                    dataSource: storeTournaments,
                    displayExpr: "Tournament1",
                    valueExpr: "TournamentID"
                }
            }, {
                dataField: "StatTeamID",
                width: 100,
                lookup: {
                    dataSource: storeTeams,
                    displayExpr: "Name",
                    valueExpr: "TeamID"
                }
            }]
    }

});