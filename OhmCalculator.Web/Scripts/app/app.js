var app = angular.module('myApp', []);

app.factory('apiService', ['$http', function ($http) {

    function lookupOhmValue(obj) {
        return $http.post('/home/lookupohmvalue?', obj);
    }

    var service = {
        lookupOhmValue: lookupOhmValue,        
    };

    return service;
}]);




app.controller('homeCtrl', ['$scope', 'apiService', function ($scope, apiService) {

    $scope.model = {
        bandAColor: '',
        bandBColor: '',
        bandCColor: '',
        bandDColor: '',
    };

    $scope.colors = ['Black', 'Brown', 'White', 'Yellow', 'Green'];

    $scope.result = -1;

    $scope.lookupOhmValue = function () {

        var obj = $scope.model;
      
        apiService.lookupOhmValue(obj).then(function (d) {
            console.log(d);
            if (d.data.Status) {
                $scope.result = d.data.OhmValue;
            }
            else {
                alert(d.data.Message);
            }
        },
        function (e) {
     
        });

    }

}]);

