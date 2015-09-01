define(['angularAMD','utility', 'utility', 'angular', 'angular-ui-router', 'angular-resource'], function(angularAMD,utility) {
    'use strict';

    var app = angular.module('project', ['ui.router', 'ngResource']);

    app.config([
        '$stateProvider', '$urlRouterProvider', function($stateProvider, $urlRouterProvider) {

            $stateProvider
                .state('activity', angularAMD.route({
                    url: '/activity',
                    templateUrl: 'Views/activity.html'
                  //  controllerUrl: 'Views/activityController'
                    //resolve: {
                    //    load: ['$q', '$rootScope', '$state', function ($q, $rootScope, $state) {
                    //        var state = $state.name;
                    //        alert(state);
                    //        var controller = utility.getControllerUrl(state);
                    //        //var controller = 'Views/activityController';
                    //        var deferred = $q.defer();
                    //        require([controller], function() {
                    //            $rootScope.$apply(function() {
                    //                deferred.resolve();
                    //            });
                    //        });
                    //        return deferred.promise;
                    //    }]
                    //}


                }))
                .state('activity.create',angularAMD.route({
                    url: '/create',
                    templateUrl: 'Views/activity/create.html',
                  //    controllerUrl:'Views/Activity/CreateController'
                }));
            $urlRouterProvider.otherwise('/activity');

        }
    ]);

    return angularAMD.bootstrap(app);
});