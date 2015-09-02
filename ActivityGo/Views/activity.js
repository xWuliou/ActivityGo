"use strict";
define(['app', 'angularAMD','ajaxService'], function(app, angularAMD) {
  angularAMD.config([
    '$stateProvider', '$urlRouterProvider', function($stateProvider, $urlRouterProvider) {
      $stateProvider
        .state('activity.create', {
          url: '/create',
          templateUrl: 'Views/activity/create.html',
          controllerUrl: 'Views/activity/create'
        })
        .state('activity.detail', {
          url: '/detail',
          templateUrl: 'Views/activity/detail.html',
          controllerUrl: 'Views/activity/detail'
        })
        .state('activity.join', {
          url: '/join',
          templateUrl: 'Views/activity/join.html',
          controllerUrl: 'Views/activity/join'
        })
        .state('activity.queryact', {
          url: '/queryact',
          templateUrl: 'Views/activity/queryact.html',
          controllerUrl: 'Views/activity/queryact'
        });
      $urlRouterProvider.otherwise('/queryact');
    }
  ]);
  return [
    '$scope', '$state','ajaxService', function($scope, $state,ajaxService) {
      $scope.url = $state.current.url;
      $scope.statename = $state.current.name;
      $scope.message = ajaxService.ajaxtest();
    }
  ];
});