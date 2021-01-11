var app = angular.module('myApp', ["ngRoute","ngSanitize"]);
app.controller('ContentController', function ($scope, $http) {
  
    $scope.message = "welcome to screen 2";
    $scope.message = "Welcome to screen 1";
    $scope.Content = {
        Content: '',
        Tittle: '', 

    };

    $scope.SaveContent = function () {
        var params = {
            content: $('.note-editable').html(),
        };
        $http({
            method: 'POST',
            url: 'Content/AddNewContent',
            params
        }).then(function success(response) {
            toastr.success(response.data);

            GetListTopic();
        }, function error(response) {


        });

        console.log($('.note-editable').html());
    };
    function GetPost() {
        var params = {
            id: 19,
        };
        $http({
            method: 'GET',
            url: 'Content/GetPost',
            params
        }).then(function success(response) {
            $scope.Content = response.data;
            console.log($scope.Content);
        }, function error(err) {
            toastr.warning(err);

        });
    };
    function InitPage() {
        GetPost();
    };
    InitPage();
});
app.config(function ($routeProvider) {
    $routeProvider.when("/screen1", {
        template: "<h3>{{message}}</h3><summer-note></summer-note>",
        controller: "ContentController"
    })
        .when("/screen2", {
            template: "<h3>{{message}}</h3>",
            controller: "screenTwoController"
        });
});
app.directive("summerNote", function () {
    return {

        link: function (scope, el, attr) {

            el.summernote({
                height: 300,        // set editor height
                minHeight: null,    // set minimum height of editor
                maxHeight: null,    // set maximum height of editor
                focus: false        // set focus to editable area after initializing summernote
            });
        }
    };
});

