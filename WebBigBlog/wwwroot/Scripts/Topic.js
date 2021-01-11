var app = angular.module('myApp', []);
app.controller('TopicController', function ($scope, $http) {
    $scope.lstTopic = [];
    $scope.new = {
        topicName: '',
        description: '',
    }

    function GetListTopic() {
        $scope.lstTopic = [];
        $http({
            method: 'GET',
            url: 'Topic/GetListTopic',
            data: ''
        }).then(function success(response) {
            console.log(response);
            let data = response.data;
            angular.forEach(data, function (values) {
                $scope.lstTopic.push(values);
            })
        }, function error(response) {

           

        });
    };
    $scope.DeleteTopic = function (id) {
        var params = {
            id: id,
            username: 'binh'
        };
        $http({
            method: 'POST',
            url: 'Topic/DeleteTopic',
            params
        }).then(function success(response) {
            toastr.success(response.data);

            GetListTopic();
        }, function error(response) {


        });
    };


   
   

    $scope.AddTopic = function () {
       
        $('#addNewTopic').modal('show');
    };
    $scope.Submit = function () {
        if ($scope.new.topicName == '' || $scope.new.topicName == null) {
            toastr.warning('The Name Of The Topic Is Not Be Empty');
        }
        else {
            var params = {
                topicName: $scope.new.topicName,
                description: $scope.new.description
            };

            $http({
                method: 'POST',
                url: 'Topic/Create',
                params
            }).then(function success(response) {
                toastr.success(response.data);

                GetListTopic();
            }, function error(response) {
                toastr.error('fail');

            });
            $scope.new.topicName = '';
            $scope.new.description = '';
            $('#addNewTopic').modal('hide');
        }
        
    }
    function InitPage() {
        GetListTopic();
    };
    InitPage();

    $scope.DetailTopic = function (id) {
        window.open('Topic/DetailTopic' + '?id=' +id, '_blank');
    };
});


app.directive('ngConfirmClick', [
    function () {
        return {
            priority: 1,
            terminal: true,
            link: function (scope, element, attr) {
                var msg = attr.ngConfirmClick || "Are you sure?";
                var clickAction = attr.ngClick;
                element.bind('click', function (event) {
                    if (window.confirm(msg)) {
                        scope.$eval(clickAction)
                    }
                });
            }
        };
    }]
)

