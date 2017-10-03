angular
    .module("myApp")
    .service("clansService", function ($http, $state) {

        this.getClans = function () {
            return $http.get("http://localhost:5000/api/clans")
        }

        this.getClan = function (id) {
            return $http.get("http://localhost:5000/api/clans/" + id);
        }

        this.addClans = function (clan, user) {
            $http.post("http://localhost:5000/api/clans?cname=" + clan.clanname + "&fromUserId=" + user.id).then(function () {
                $state.go("showClans");
            });
            
    }
})