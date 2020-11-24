"use strict";

<%= objectName %>Controllers.controller("<%= objectName %>Controller", ["$scope", "$routeParams", "$location", "$http", "$uibModal", "<%= objectName %>ServiceFactory", function ($scope, $routeParams, $location, $http, $uibModal, <%= objectName %>ServiceFactory) {

    $scope.<%= objectName %> = {};
    $scope.HasSuccess = false;
    $scope.HasErrors = false;
    $scope.<%= extensionName %>Id = $routeParams.<%= objectName %>Id;

    var factory = <%= objectName %>ServiceFactory;
    factory.init(appModuleId, appModuleName);
    $scope.<%= objectName %>Filter = "";

    $scope.userCanEdit = false;

    $scope.LoadData = function () {
        factory.callGetService("GetCurrentUserId")
            .then(function (response) {
                var fullResult = angular.fromJson(response);
                var serviceResponse = JSON.parse(fullResult.data);

                $scope.currentUserId = serviceResponse.Content;

                $scope.LoadEditPermissions();

                if ($scope.<%= extensionName %>Id > -1) {
                    $scope.Load<%= extensionName %>();
                }
                else
                {
                    $scope.Load<%= extensionName %>s();
                }

                LogErrors(serviceResponse.Errors);
            },
            function (data) {
                console.log("Unknown error occurred calling GetCurrentUserId");
                console.log(data);
            });
    }

    $scope.Load<%= extensionName %>s = function () {
        factory.callGetService("Get<%= extensionName %>s")
            .then(function (response) {
                var fullResult = angular.fromJson(response);
                var serviceResponse = JSON.parse(fullResult.data);

                $scope.<%= objectName %>s = serviceResponse.Content;

                if ($scope.<%= objectName %>s === null) {
                    $scope.has<%= extensionName %>s = false;
                } else {
                    $scope.has<%= extensionName %>s = true;
                }

                LogErrors(serviceResponse.Errors);
            },
                function (data) {
                    console.log("Unknown error occurred calling Get<%= extensionName %>s");
                    console.log(data);
                });
    }

    $scope.Load<%= extensionName %> = function () {
        factory.callGetService("Get<%= extensionName %>?<%= objectName %>Id=" + $scope.<%= extensionName %>Id)
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
    }

    $scope.LoadEditPermissions = function () {
        factory.callGetService("UserCanEdit<%= extensionName %>")
            .then(function(response) {
                    var fullResult = angular.fromJson(response);
                    var serviceResponse = JSON.parse(fullResult.data);

                    $scope.userCanEdit = (serviceResponse.Content == "Success");

                    LogErrors(serviceResponse.Errors);
                },
                function(data) {
                    console.log("Unknown error occurred calling UserCanEdit<%= extensionName %>");
                    console.log(data);
                });
    }

    $scope.Update<%= extensionName %> = function () {
        var action = "Create<%= extensionName %>";

        if ($scope.<%= objectName %>.<%= extensionName %>Id > 0) {
            action = "Update<%= extensionName %>";
        }

        factory.callPostService(action, $scope.<%= objectName %>)
            .success(function (data) {
                $scope.HasSuccess = true;

                var serviceResponse = angular.fromJson(data);

                $scope.LoadData();

                LogErrors(serviceResponse.Errors);
            })
            .error(function (data, status) {
                $scope.HasErrors = true;
                console.log("Unknown error occurred calling " + action);
                console.log(data);
            });
    }

    $scope.CanDelete = function (<%= objectName %>Id) {
        return (<%= objectName %>Id > -1);
    }

    $scope.Delete<%= extensionName %> = function (<%= objectName %>Id) {
        var modalInstance = $uibModal.open({
            templateUrl: "Delete<%= extensionName %>Modal.html",
            controller: "Delete<%= extensionName %>ModalController",
            size: "sm",
            backdrop: "static",
            scope: $scope,
            resolve: {
                <%= objectName %>Id: function () {
                    return <%= objectName %>Id;
                }
            }
        });

        modalInstance.result.then(function () {
            $scope.goToPage('<%= objectName %>s');
        }, function () {
            console.log("Modal dismissed at: " + new Date());
        });
    }

    $scope.goToPage = function (pageName) {
        $location.path(pageName);
        $scope.LoadData();
    }

    $scope.LoadData();

}]);
