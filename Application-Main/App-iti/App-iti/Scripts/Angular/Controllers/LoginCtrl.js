var app = angular.module('LoginApp', []);

app.controller('LoginCtrl', ['$scope', '$http', function ($scope, $http) {


    $scope.TokenFetchs = function (userName, passWord, Type) {
        var token = $scope.getCookie(userName);
        if (token !== "") {
            alert(userName + passWord + Type);
            if (Type == "S")
            {
                window.location.pathname = '/Student/AppProfile/'+userName;
            }
            else if (Type == "E")
            {
                window.location.pathname = '/Employee/AppProfile/'+userName;
            }
        }
        else {
            if (Type == "S") {
                $scope.sendData(userName, passWord,"2");
            }
            else if (Type == "E") {
                $scope.sendData(userName, passWord,"1");
            }
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


    $scope.sendData = function (userName, passWord, Type) {
        var ClientId = '123456'
        var ClientSecret = 'abcdef'
        var LogType = Type
        var ClientType = 'android'
        var ClientVersion = '19'
        var data = "grant_type=password&username=" + userName + "&password=" + passWord + "&Client_Id=" + ClientId +
            "&client_secret=" + ClientSecret + "&logtype=" + LogType + "&client_Type=" + ClientType + "&clientOsVersion=" + ClientVersion;

        $http({ method: 'POST', url: 'http://localhost:59538/OAuth/Token', headers: { 'Content-Type': 'text/plain' }, data: data })
            .then(function (data) {
                var AccTok = data.data.access_token;
                var date = new Date();
                if (document.getElementById("Cb").checked == true) {
                    var Expire = date.setDate(date.getDay() + 10);
                    console.log("Save")
                    console.log("assa")
                }
                else {
                    var Expire = date.setMinutes(date.getMinutes() + 30);
                    console.log("Don't Save")
                }
                var cdate = new Date(Expire)
                $scope.setCookie(userName, AccTok, cdate);

                if (Type == "2") {
                    window.location.pathname = '/Student/AppProfile/' + userName;
                }
                else if (Type == "1") {
                    window.location.pathname = '/Employee/AppProfile/' + userName;
                }
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