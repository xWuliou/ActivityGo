"use strict";

define(['ajaxService','app'],function(ajaxService,app) {
  app.factory('activityService',function() {
    var createActivity = function(activity, successFunction, errorFunction) {
      ajaxService.AjaxPost("api/activity/create", activity, successFunction, errorFunction)
    };
  })
})