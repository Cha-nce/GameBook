angular
.module("myApp")
.service("friendRequestsService", function ($http, $state) {

    this.getFriendRequests = function () {
        return $http.get("http://localhost:5000/api/friendsrequest")
    }

    this.addFriendRequests = function (user1,user2) {
        $http.post("http://localhost:5000/api/friendsrequest?fromUserId="+ user1.id + "&toUserId=" + user2.id).then(function (response) {
            console.log(response);
            
        });
        alert("Your friend request has been sent.");
        $state.reload();
    }
 
    this.deleteFriendRequests = function (id) {
        $http.delete("http://localhost:5000/api/friendsrequest/" + id);
    }

    this.acceptFriendRequests = function(user1, user2,requestID) {
        $http.post("http://localhost:5000/api/friends?fromUserId=" + user1.id + "&toUserId=" + user2.id).then(function (response) {
            $http.delete("http://localhost:5000/api/friendsrequest/" + requestID);
        })
        alert("You are now friends with " + user1.username);
        $state.reload();
    }

})