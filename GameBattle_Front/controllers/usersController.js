angular
    .module("myApp")
    .controller("usersController", function ($scope, $state, $stateParams, usersService, clansService, clansRequestService, directMessagesService, friendRequestsService) {

        if ($stateParams.id != null && $stateParams.id != undefined) {
            usersService.getFriend($stateParams.id).then(function (response) {
                $scope.myFriend = response.data;
                console.log($scope.myFriend)
                //$state.go("showFriend");
            })
        }

        if ($stateParams.id != null && $stateParams.id != undefined) {
            clansService.getClan($stateParams.id).then(function (response) {
                $scope.clan = response.data;
                console.log($scope.clan)
            })
        }
        $scope.currentUser = usersService.currentUser;
        $scope.myFriend = null;

        // if ($scope.myUser == null) {
        //     $state.go("users");
        // }
        $scope.invalidUser = false;

        // get users from db
        usersService.getUsers()
            .then(function (response) {
                $scope.users = response.data;
                console.log($scope.users);
            })

        $scope.addUsers = function () {
            usersService.addUsers($scope.newuser)
        }

        $scope.deleteUsers = function (user) {
            usersService.deleteUser(user.id);
            $scope.users.splice($scope.users.indexOf(user), 1)
        }

        // get Clans from db
        clansService.getClans()
            .then(function (response) {
                $scope.clans = response.data;
                console.log($scope.clans)
            })

        $scope.addClans = function () {
            clansService.addClans($scope.newclan, $scope.currentUser)
        }

        $scope.getClan = function (clan) {
            clansService.getClan(clan.id).then(function (response) {
                $scope.clan = response.data;
            })
        }

        //other functions
        $scope.validateUser = function () {
            for (var i = 0; i < $scope.users.length; i++) {

                if ($scope.users[i].password === $scope.password && $scope.users[i].username === $scope.username) {
                    usersService.setCurrentUser($scope.users[i])
                    break;
                }
                else {
                    console.log("couldnt find user")
                }
            }
        }

        $scope.getFriend = function (friend) {
            $state.go("showUser", { id: friend.id });
        }

        $scope.getClan = function (clan) {
            $state.go("showClan", { id: clan.id });
        }

        $scope.addClanRequests = function (clan, message) {
            console.log(clan.clanleader)
            console.log(message)
            clansRequestService.addClanRequests($scope.currentUser, clan.clanleader, clan, message)
        }
        $scope.addDirectMessages = function (user, message) {
            directMessagesService.addDirectMessages($scope.currentUser, user, message);
        }
        $scope.addFriendRequests = function (user) {
            friendRequestsService.addFriendRequests($scope.currentUser, user);
        }
    })


