"use strict";
define(['app', 'angularAMD'], function(app, angularAMD) {
  angularAMD.config([
    '$stateProvider', '$urlRouterProvider', function($stateprovider, $urlRouterProvider) {

      $stateprovider
        .state('account.follow', {
          url: '/follow',
          templateUrl: 'Views/account/follw.html',
          controllerUrl: 'Views/account/follow'
        })
        .state('account.cancelfollow', {
          url: '/cancelfollow',
          templateUrl: 'Views/account/cancelfollow.html',
          controllerUrl: 'Views/account/cancelfollow'
        });
      $urlRouterProvider.otherwise('follow');
    }
  ]);

    //return this model
});