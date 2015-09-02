define(['angularAMD', 'utility', 'angular', 'angular-ui-router', 'angular-resource'], function(angularAMD, utility) {
  'use strict';

  var app = angular.module('project', ['ui.router', 'ngResource']);

  app.config([
    '$stateProvider', '$urlRouterProvider', function($stateProvider, $urlRouterProvider) {

      $stateProvider
        .state('activity', angularAMD.route({
          url: '/activity',
          templateUrl: 'Views/activity.html',
          controllerUrl: 'Views/activity'


        }))
        .state('account', angularAMD.route({
          url: '/account',
          templateUrl: 'Views/account.html',
        //  controllerUrl: 'Views/account'
        }))
        .state('actitem', angularAMD.route({
          url: '/actitem',
          templateUrl: 'Views/actitem.html',
       //   controller: 'Views/actitem'
        }));
      $urlRouterProvider.otherwise('/activity');

    }
  ]);

  angularAMD.bootstrap(app);

  return app;
});