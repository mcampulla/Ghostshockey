"use strict";

//var app = angular.module("contratto", ['dx', 'ngAnimate', 'ngRoute', 'ui.router', 'ngSanitize']);
var app = angular.module("Players", ['dx']);

//app.run(['$rootScope', '$templateCache', function ($rootScope, $templateCache) {
//    $rootScope.$on('$routeChangeStart', function (event, next, current) {
//        $templateCache.remove(current.templateUrl);
//    });

//    $rootScope.$on('$stateChangeStart', function (event, next, current) {
//        $templateCache.remove(current.templateUrl);
//    }); 

//    $rootScope.$on('$viewContentLoaded', function () {
//        $templateCache.removeAll();
//    }); 
//}]);

//app.factory('HttpInterceptor', function ($templateCache) {
//    return {
//        'request': function (request) {
//            if (request.url.toLowerCase().indexOf('app/views') !== -1 && $templateCache.get(request.url) === undefined) {
//                request.url += '?ver=' + new Date().toISOString();
//                //request.cache.destroy();
//                $templateCache.removeAll();
//            }
//            return request;
//        }
//    };
//});
    
    
//app.config(function ($stateProvider, $urlRouterProvider, $httpProvider) {

//    $httpProvider.interceptors.push('HttpInterceptor');

//    $stateProvider

//    .state('contratto', {
//        url: '/contratto',
//        templateUrl: '/App/views/contratti/dettaglio.html',
//        controller: 'contrattoController'
//    })

//    .state('contratto.voltura', {
//        url: '/voltura',
//        templateUrl: '/App/views/volture/dettaglio-dativoltura.html'
//    })

//    .state('contratto.posaattriatt', {
//        url: '/posaattriatt',
//        templateUrl: '/App/views/poseattriatt/dettaglio-feedback.html'
//    })

//    .state('contratto.cambiopiano', {
//        url: '/cambiopiano',
//        templateUrl: '/App/views/cambipiano/dettaglio-daticambiopiano.html'
//    })

//    .state('contratto.richiestafornitura', {
//        url: '/richiestafornitura',
//        templateUrl: '/App/views/contratti/dettaglio-richiestafornitura.html'
//    })

//    .state('contratto.sedienergia', {
//        url: '/sedienergia',
//        templateUrl: '/App/views/contratti/dettaglio-sedienergia.html',
//        controller: 'sediEnergiaController'
//    })

//    .state('contratto.sedigas', {
//        url: '/sedigas',
//        templateUrl: '/App/views/contratti/dettaglio-sedigas.html',
//        controller: 'sediGasController'
//    })

//    .state('contratto.altridati', {
//        url: '/altridati',
//        templateUrl: '/App/views/contratti/dettaglio-altridati.html'
//    })

//    .state('contratto.controllieegp', {
//        url: '/controllieegp',
//        templateUrl: '/App/views/contratti/dettaglio-controlli-eegp.html'
//    })

//    .state('contratto.documenti', {
//        url: '/documenti',
//        templateUrl: '/App/views/contratti/dettaglio-documenti.html',
//        controller: 'documentiController'
//    })

//    .state('contratto.sedivoltura', {
//        url: '/sedivoltura',
//        templateUrl: '/App/views/volture/dettaglio-sedivoltura.html'
//    })

//    .state('contratto.sedienergia.sede', {
//        url: '/sedienergia/sede',
//        templateUrl: '/App/views/contratti/sedi/dettaglio-energiadatisede.html'
//    })

//    .state('contratto.sedigas.sede', {
//        url: '/sedigas/sede',
//        templateUrl: '/App/views/contratti/sedi/dettaglio-gasdatisede.html'
//    });

//    // catch all route
//    $urlRouterProvider.otherwise('/contratto');
//});  

//app.run(function ($http) {
//    var token = sessionStorage.getItem('accessToken');
//    if (token) {
//        $http.defaults.headers.common.Authorization = 'Bearer ' + token;
//    }
//});
