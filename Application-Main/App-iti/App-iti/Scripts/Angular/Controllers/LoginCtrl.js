var app = angular.module('LoginApp', []);

app.controller('LoginCtrl', ['$scope', '$http', function ($scope, $http) {

    $scope.sendData = function (userName, passWord) {
        var ClientId = '123456'
        var ClientSecret = 'abcdef'
        var LogType = "3"
        var ClientType = 'android'
        var ClientVersion = '19'
        var data = "grant_type=password&username=" + userName + "&password=" + passWord + "&Client_Id=" + ClientId +
            "&client_secret=" + ClientSecret + "&logtype=" + LogType + "&client_Type=" + ClientType + "&clientOsVersion=" + ClientVersion;


            alert(data);

        $http({ method: 'POST', url: 'http://localhost:59538/OAuth/Token', headers: { 'Content-Type': 'text/plain' }, data: data })
            .then(function (data) {
                console.log("Here!");
                console.log(data.data.access_token);
                var date = new Date();
                var Expire = date.setDate(date.getDate() + 10); 
                var cdate = new Date(Expire)
                console.log(cdate);
            })
            , (function (data) {
                alert(data)
            });
    }
   
   }])