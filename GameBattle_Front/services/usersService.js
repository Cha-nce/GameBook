angular
    .module("myApp")
    .service("usersService", function ($http, $state) {

        this.currentUser = null;
        var that = this
        var myFriend = null;

        this.getUsers = function () {
            return $http.get("http://localhost:5000/api/users")
        }
        this.addUsers = function (user) {
            $http.post("http://localhost:5000/api/users", user).then(function () {
                $state.go("users");
            });
        }

        this.deleteUsers = function (id) {
            $http.delete("http://localhost:5000/api/users/" + id);
        }

        // this.validateUser = function (users, username, password) {
        //     for (var i = 0; i < users.length; i++) {
        //         if (users[i].password === password && users[i].username === username) {
        //             user = users[i];
        //             return $http.get("http://localhost:5000/api/users/" + user.id)
        //         }
        //     }
        //     return false;
        // }

        // this.getMyUser = function (id) {
        //     return $http.get("http://localhost:5000/api/users/" + id);
        // }

        this.getFriend = function (id) {
            return $http.get("http://localhost:5000/api/users/" + id);

        }

        this.setCurrentUser = function (user) {
            $http.get("http://localhost:5000/api/users/" + user.id).then(function (response) {
                that.currentUser = response.data;
                console.log(that.currentUser)
                // console.log(this)
                $state.go("home");
            }, function (error) {
                console.log(error);
            });
        }
    })