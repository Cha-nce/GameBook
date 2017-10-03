angular
.module("myApp")
.service("clansRequestService", function ($http, $state) {

    this.getClanRequests = function () {
        return $http.get("http://localhost:5000/api/clansrequest")
    }

    this.addClanRequests = function (user,clanleader,clan,message) {
        $http.post("http://localhost:5000/api/clansrequest?fromUserId="+ user.id + "&toUserId=" + clanleader.id + "&toClanId=" + clan.id + "&message=" + message).then(function (response) {
        });
        alert("Your clan request has been sent");
        $state.reload();
    }
 
    this.deleteClanRequests = function (id) {
        $http.delete("http://localhost:5000/api/clansrequest/" + id);
    }

    this.acceptClanRequests = function(user, clan) {
        $http.post("http://localhost:5000/api/clansaccept?toUserId=" + user.id + "&toClanId=" + clan.id).then(function (response) {
            console.log(response);
        })
        alert(user.username + " has joined the clan.")
        $state.reload();
    }

})