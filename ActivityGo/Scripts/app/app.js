define(['angularAMD', 'angular', 'angular-ui-router', 'angular-resource'], function(angularAMD, utility) {
  'use strict';

  var app = angular.module('project', ['ui.router', 'ngResource']);

  app.config([
    '$stateProvider', '$urlRouterProvider', function($stateProvider, $urlRouterProvider) {

      $stateProvider
        .state('activity', angularAMD.route({
          url: '/activity',
          templateUrl: 'Views/activity.html',
          controllerUrl: 'Views/activityController',
          controller: 'activityController'


        }))
        .state('account', angularAMD.route({
          url: '/account',
          templateUrl: 'Views/account.html',
          //  controllerUrl: 'Views/accountController'
        }))
        .state('actitem', angularAMD.route({
          url: '/actitem',
          templateUrl: 'Views/actitem.html',
          //   controllerUrl: 'Views/actitemController'
        }))
        .state('activity.default', angularAMD.route({
          url: '/default',
          templateUrl: 'Views/activity/default.html',
          controllerUrl: 'Views/activity/defaultController',
          controller: 'defaultController'
        }))
        .state('activity.create', angularAMD.route({
          url: '/create',
          templateUrl: 'Views/activity/create.html',
          controllerUrl: 'Views/activity/createController',
          controller: 'createController'
        }))
        .state('activity.detail', angularAMD.route({
          url: '/detail',
          templateUrl: 'Views/activity/detail.html',
          controllerUrl: 'Views/activity/detailController',
          controller: 'detailController'
        }))
        .state('activity.join', angularAMD.route({
          url: '/join',
          templateUrl: 'Views/activity/join.html',
          controllerUrl: 'Views/activity/joinController',
          controller: 'joinController'
        }))
        .state('activity.queryact', angularAMD.route({
          url: '/queryact',
          templateUrl: 'Views/activity/queryact.html',
          controllerUrl: 'Views/activity/queryactController',
          controller: 'queryactController'
        }));
      $urlRouterProvider.otherwise('/activity/default');

    }
  ]);

  app.config(function($httpProvider) {
    $httpProvider.defaults.headers.common['X-Requested-With'] = 'XMLHttpRequest';
    //$httpProvider.defaults.withCredentials = true;
  });
  angularAMD.bootstrap(app);

  return app;
});