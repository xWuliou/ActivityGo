"use strict";
define(['app'], function() {
    return [
        '$scope','$state', function($scope,$state) {
            $scope.lastName = $state.current.url;
            $scope.firstName = $state.current.name;
        }
    ];
});