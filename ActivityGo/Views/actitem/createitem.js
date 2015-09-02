"use strict";
define(['app', 'angularAMD'], function(app, angularAMD) {
  angularAMD.config([
    '$stateProvider', '$urlRouterProvider', function($stateProvider, $urlRouterProvider) {
      $stateProvider
        .state('actitem.createitem', {
          url: '/createitem',
          templateUrl: 'Views/actitem/createitem.html',
          controllerUrl: 'Views/actitem/createitem'
        })
        .state('actitem.itemdetail', {
          url: '/itemdetail',
          templateUrl: 'Views/actitem/itemdetail.html',
          controllerUrl: 'Views/actitem/itemdetail'
        })
        .state('actitem.queryitem', {
          url: '/queryitem',
          template: 'Views/actitem/queryitem.html',
          controllerUrl: 'Views/actitem/queryitem'
        });
      $urlRouterProvider.otherwise('/queryitem');
    }
  ]);

    //return this model
});