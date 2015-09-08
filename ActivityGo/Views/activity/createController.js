"use strict";

define(['app'], function(app) {

    app.register.controller('createController', [
    '$scope','ajaxService', function($scope,ajaxService) {
      $scope.state = true;
    }
  ])

});