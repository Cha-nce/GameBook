var app = angular.module("myApp", ["ui.router"])

app.config(function ($stateProvider, $urlRouterProvider) {
    $urlRouterProvider.otherwise("/");

    $stateProvider
        .state("home", {
            url: "/home",
            templateUrl: "./views/home.html",
            controller: "newsController"
        })
        .state("users", {
            url: "/",
            templateUrl: "./views/users_index.html",
            controller: "usersController"
        })

        .state("newUsers", {
            url: "/users/new",
            templateUrl: "./views/users_new.html",
            controller: "usersController"
        })

        .state("showUsers", {
            url: "/users/show",
            templateUrl: "./views/users_show.html",
            controller: "notificationsController"
        })
        .state("editUsers", {
            url: "/users/:id/edit",
            templateUrl: "./views/users_edit.html",
            controller: "usersController"
        })
        .state("addUsers", {
            url: "/users/add",
            templateUrl: "./views/users_add.html",
            controller: "notificationsController"
        })
        .state("dmUsers", {
            url: "/users/DM",
            templateUrl: "./views/users_dm.html",
            controller: "noticationsController"
        })
        .state("showFriends", {
            url: "/users/friends",
            templateUrl: "./views/friends_show.html",
            controller: "usersController"
        })
        
        // .state("showFriend", {
        //     url: "/users/friend",
        //     templateUrl: "./views/friend_show.html",
        //     controller: "usersController"
        // })
        .state("showUser", {
            url: "/users/:id",
            templateUrl: "./views/friend_show.html",
            controller: "usersController"
        })
        .state("showClans", {
            url: "/clans",
            templateUrl: "./views/clans_show.html",
            controller: "usersController"
        })
        .state("showClan", {
            url: "/clans/:id",
            templateUrl: "./views/clan_show.html",
            controller: "usersController"
        })
        .state("newClan", {
            url: "/newclan",
            templateUrl: "./views/clans_new.html",
            controller: "usersController"
        })

})