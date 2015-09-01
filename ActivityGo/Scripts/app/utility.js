"use strict";

define(
    function() {
        var getUrl = function(state) {
            var strs = state.split(".");
            if (strs.length > 0) {
                strs = strs.reverse();
            }
            return "/" + strs[0];
        }


        var getTempalteUrl = function(state) {
            var str = state.replace(".", "/");
            return "Views/" + str + ".html";
        }

        var getControllerUrl = function(state) {
            var str = state.replace(".", "/");
            return "Views/" + str + "Controller";
        }
        return {
            getUrl: getUrl,
            getTemplateUrl: getTempalteUrl,
            getControllerUrl: getControllerUrl
        }
    }
);