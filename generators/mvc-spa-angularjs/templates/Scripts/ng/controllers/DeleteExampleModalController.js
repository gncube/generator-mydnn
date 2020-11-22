"use strict";

<%= objectName %>App.controller("Delete<%= extensionName %>ModalController", ["$scope", "$rootScope", "$modalInstance", "$location", "<%= objectName %>Id", "<%= objectName %>ServiceFactory", function ($scope, $rootScope, $modalInstance, $location, <%= objectName %>Id, <%= objectName %>ServiceFactory) {

    var factory = <%= objectName %>ServiceFactory;
    factory.init(appModuleId, appModuleName);

    $scope.<%= objectName %> = {};

    factory.callGetService("Get<%= extensionName %>?<%= objectName %>Id=" + <%= objectName %>Id)
        .then(function (response) {
            var fullResult = angular.fromJson(response);
            var serviceResponse = JSON.parse(fullResult.data);

            $scope.<%= objectName %> = serviceResponse.Content;

            LogErrors(serviceResponse.Errors);
        },
        function (data) {
            console.log("Unknown error occurred calling Get<%= extensionName %>");
            console.log(data);
        });

    $scope.ok = function () {
        factory.callDeleteService("Delete<%= extensionName %>?<%= objectName %>Id=" + <%= objectName %>Id)
            .then(function (response) {
                var fullResult = angular.fromJson(response);
                var serviceResponse = JSON.parse(fullResult.data);

                $scope.goToPage('<%= objectName %>s');

                LogErrors(serviceResponse.Errors);
            },
            function (data) {
                console.log("Unknown error occurred calling Delete<%= extensionName %>");
                console.log(data);
            });

        $modalInstance.close();
    };

    $scope.cancel = function () {
        $modalInstance.dismiss("cancel");
    };

    $scope.goToPage = function (pageName) {
        $location.path(pageName);
        $scope.LoadData();
    }
}]);
