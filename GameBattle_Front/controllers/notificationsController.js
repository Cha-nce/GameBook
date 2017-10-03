angular
.module("myApp")
.controller("notificationsController", function($scope, $state, usersService, friendRequestsService, directMessagesService, clansRequestService)
{
    $scope.currentUser = usersService.currentUser;
    $scope.view = false;
    
    // get Users from DB
    usersService.getUsers()
    .then(function(response) {
        $scope.users = response.data;
        $scope.newuserid = $scope.users.length;
        for (var i = 0; i < $scope.users.length; i++ )
        {
            if ($scope.users[i].username == null)
            {
                $scope.users.splice($scope.users.indexOf($scope.users[i]),1)
            }
        }
    })

    //Friend Request
    friendRequestsService.getFriendRequests()
    .then(function(response) {
        $scope.friendrequests = response.data;
    })
    $scope.addFriendRequests = function(user) {
        friendRequestsService.addFriendRequests($scope.currentUser,user);
    }
    $scope.acceptFriendRequests = function(request) {
        friendRequestsService.acceptFriendRequests(request.user1, request.user2,request.id);
    }
    
    //Direct Messages
    directMessagesService.getDirectMessages().then(function(response){
        $scope.directmessages = response.data;
    })
    $scope.addDirectMessages = function(user,message) {
        directMessagesService.addDirectMessages($scope.currentUser, user, message);
    }
    
    //Clan Messages
    clansRequestService.getClanRequests().then(function(response) {
        $scope.clanrequests = response.data;
        console.log($scope.clanrequests)
    })

    $scope.acceptClanRequests = function(request) {
        console.log(request)
        clansRequestService.acceptClanRequests(request.user1,request.clan)
    }

    //other functions
    $scope.getFriend = function (friend) {
        $state.go("showUser", { id: friend.id });
    }

    $scope.view = function() {
        if ($scope.view == false) {
            $scope.view = true;
        }
        if ($scope.view == true) {
            $scope.view = false;
        }

    }


})


















