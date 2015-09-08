"use strict";

define(['app'], function(app) {
  app.register.controller('defaultController', [
    '$scope', function($scope) {
      $scope.state = true;
    }
  ]);
});