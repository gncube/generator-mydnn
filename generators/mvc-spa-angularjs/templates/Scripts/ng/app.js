"use strict";

$("body").attr("ng-app", "<%= objectName %>App");

var <%= objectName %>App = angular.module("<%= objectName %>App", ["ngRoute", "ngAnimate", "ui.bootstrap", "ui.sortable", "angularMoment", "flow", "<%= objectName %>Controllers"]);

var <%= objectName %>Controllers = angular.module("<%= objectName %>Controllers", []);

<%= objectName %>App.config(["$routeProvider", 
	function ($routeProvider) {

		$routeProvider
		.when("/update", {
			templateUrl: templatePath + "Templates/_default/update.html",
			controller: "<%= objectName %>Controller"
        })
        .when("/update/:<%= objectName %>Id", {
            templateUrl: templatePath + "Templates/_default/update.html",
            controller: "<%= objectName %>Controller"
        })
		.when("/<%= objectName %>s", {
            templateUrl: templatePath + "Templates/_default/<%= objectName %>s.html",
			controller: "<%= objectName %>Controller"
		})
		.otherwise({
			redirectTo: "/<%= objectName %>s"
		});
	}]);
