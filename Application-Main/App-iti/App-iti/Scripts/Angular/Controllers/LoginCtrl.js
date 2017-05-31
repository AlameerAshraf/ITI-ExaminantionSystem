var app = angular.module('LoginApp', []);

app.controller('LoginCtrl', ['$scope', '$http', function ($scope, $http) {


    $scope.TokenFetchs = function (userName, passWord) {
        var token = $scope.getCookie(userName);
        if (token !== "") {
            console.log(token);
            window.location.pathname = '/Student/Test/' + userName;
        }
        else {
            $scope.sendData(userName, passWord);
        }
    }



    $scope.getCookie = function (cname) {
        var name = cname + "=";
        var decodedCookie = decodeURIComponent(document.cookie);
        var ca = decodedCookie.split(';');
        for (var i = 0; i < ca.length; i++) {
            var c = ca[i];
            while (c.charAt(0) === ' ') {
                c = c.substring(1);
            }
            if (c.indexOf(name) === 0) {
                return c.substring(name.length, c.length);
            }
        }
        return "";
    }


    $scope.sendData = function (userName, passWord) {

        var ClientId = '123456'
        var ClientSecret = 'abcdef'
        var LogType = "3"
        var ClientType = 'android'
        var ClientVersion = '19'
        var data = "grant_type=password&username=" + userName + "&password=" + passWord + "&Client_Id=" + ClientId +
            "&client_secret=" + ClientSecret + "&logtype=" + LogType + "&client_Type=" + ClientType + "&clientOsVersion=" + ClientVersion;

        $http({ method: 'POST', url: 'http://localhost:59538/OAuth/Token', headers: { 'Content-Type': 'text/plain' }, data: data })
            .then(function (data) {
                var AccTok = data.data.access_token;
                var date = new Date();
                var Expire = date.setDate(date.getDate() + 10); 
                var cdate = new Date(Expire)
                console.log(cdate);
                $scope.setCookie(userName, AccTok, cdate);
            })
            ,(function (data) {
                alert(data)
            });
    }

    $scope.setCookie = function (cname, cvalue, exdays) {
        console.log(exdays);
        document.cookie = cname + "=" + cvalue + ";" + "expires=" + exdays;
    }



   
   }])