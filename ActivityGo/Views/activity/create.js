"use strict";

define(['app'], function () {

    return ['$scope','$state',function($scope, $state) {
        $scope.url = $state.current.url;
        $scope.state = $state.current.name;
    }]
    
})