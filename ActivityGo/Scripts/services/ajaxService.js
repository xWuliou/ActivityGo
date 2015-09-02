"use strict";

define(['app'], function(app) {
  app.register.service('ajaxService', [
    '$http', function($http) {
       this.AjaxGet = function(route, successFunction, errorFunction) {
        $http({ method: 'GET', url: route })
          .success(function(response, status, headers, config) {
            successFunction(response, status);
          })
          .error(function(response) {
            errorFunction(response);
          });
      };

      this.AjaxGetWithData = function(route, data, successFunction, errorFunction) {
        $http({ method: 'GET', url: route, params: data })
          .success(function(response, status, headers, config) {
            successFunction(response, status);
          })
          .error(function(response) {
            errorFunction(response);
          });
      };

      this.AjaxPost = function (route, data, sucessFunction, errorFunction) {
        $http({ method: 'POST', url: route, data: data })
          .success(function(response, status, headers, config) {
            successFunction(response, status);
          })
          .error(function(response) {
            errorFunction(response);
          });
      };

      this.AjaxPut = function (route, data, successFunction, errorFunction) {
        $http({ method: 'PUT', url: route, data: data })
          .success(function(response, status, headers, config) {
            successFunction(response, status);
          })
          .error(function(response) {
            errorFunction(response);
          });
      };

      this.AjaxDelete = function (route, data, successFunction, errorFunction) {
        $http({ method: 'DELETE', url: route, params: data })
          .success(function(response, status, headers, config) {
            successFunction(response, status);
          })
          .error(function(response) {
            errorFunction(response);
          });
      };


      this.ajaxtest = function() { alert("ajaxtest") };

    }
  ]);
});
