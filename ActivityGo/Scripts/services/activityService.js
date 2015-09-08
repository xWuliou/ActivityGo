"use strict";

define(['app', 'ajaxService'], function(app) {
  app.register.service('activityService', [
    'ajaxService', function(ajaxService) {
      this.CreateActivity = function(activity, successFunction, errorFunction) {
        ajaxService.AjaxPost("/api/activity/create", activity, successFunction, errorFunction);
      };

      this.UpdateActivity = function(activity, successFunction, errorFunction) {
        ajaxService.AjaxPut("/api/activity/update", activity, successFunction, errorFunction)
      };

      this.GetActivitys = function(successFunction, errorFunction) {
        ajaxService.AjaxGet("/api/activity/get", successFunction, errorFunction)
      };

      this.GetActivityById = function(id, successFunction, errorFunction) {
        ajaxService.AjaxGetWithData("/api/activity/get/" + id, id, successFunction, errorFunction)
      };

      this.DeleteActivity = function(id, successFunction, errorFunction) {
        ajaxService.AjaxDelete("/api/activity/delete/" + id, id, successFunction, errorFunction)
      };


    }
  ]);
});