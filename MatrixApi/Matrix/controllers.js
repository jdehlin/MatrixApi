﻿

matrixApp.controller('ProjectListController', function ($scope, $http, Projects, $location) {
    $scope.projects = [];

    init();

    function init() {
        Projects.getProjects()
            .then(
                function (data) {
                    $scope.projects = data;
                }
            );
    }
    $scope.edit = function (projectId) {
        $location.path("/projects/edit/" + projectId);
    };

    $scope.delete = function (project) {
        Project.deleteProject(project.Id)
            .then(
                function (data) {
                    project = null;
                }
            );
    };
});

matrixApp.controller('ProjectController', function ($scope, $http, Projects, $routeParams, $location) {
    var projectId = $routeParams.projectId;
    $scope.projects = [];

    init();

    function init() {
        Projects.getProject(projectId)
            .then(
                function (data) {
                    $scope.project = data;
                }
            );
    }
});

matrixApp.controller('ProjectCreateController', function ($scope, $http, Projects, $location) {

    init();

    function init() {

    }

    $scope.addProject = function () {
        Projects.createProject($scope.newProject)
            .then(
                function (data, status, headers, config) {
                    // return the created id?
                    $location.path("/projects/");
                }
            );
    };
});

matrixApp.controller('ProjectEditController', function ($scope, $http, Projects, $routeParams, $location) {
    var projectId = $routeParams.projectId;

    init();
    function init() {
        Projects.getProject(projectId)
            .then(
                function (data) {
                    console.log(data)
                    $scope.project = data;
                }
            );
    }

    $scope.editProject = function () {
        Projects.editProject($scope.project)
            .then(
                function (data, status, headers, config) {
                    $location.path("/projects/" + projectId);
                }
            );
    };
});

matrixApp.controller('TicketController', function ($scope, $http, $routeParams, Tickets) {

    var ticketId = $routeParams.ticketId;

    $scope.projects = [];

    Tickets.getTicket(ticketId)
        .then(
            function (data, status, headers, config) {
                // you can do some processing here
                $scope.ticket = data;
            }
        );

    $scope.addComment = function () {
        $http.post("/API/comments", $scope.newComment)
        .success(function (data, status, headers, config) {
            $location.path("/ticket/" + $routeParams.ticketId);
        }).error(function (data, status, headers, config) {
            alert("error");
        });
    };

});


matrixApp.controller('TicketCreateController', function ($scope, $http, $routeParams, $location, Tickets) {

    $scope.projectId = $routeParams.projectId;

    // push to server, get returned id?
    $scope.addTicket = function () {
        // push to server, get returned id?
        $http.post("/API/tickets", $scope.newTicket)

        Tickets.createTicket($scope.newTicket)
            .then(
                function (data, status, headers, config) {
                    $location.path("/project/" + $routeParams.projectId);
                }
            );
    };
});

matrixApp.controller('LoginController', function ($scope, $http, $location, User) {
    $scope.login = function () {
        User.login($scope.user)
            .then(
                function (user) {
                    $location.path("/projects");
                }
            );
    };
});

matrixApp.controller('LogoutController', function ($scope, $http, $location, User) {
    $scope.user = [];

    init();
    
    function init()
    {
        $scope.user = User.getCurrentUser();
    }
    // push to server, get returned id?
    $scope.logout = function () {
        User.logout();
        $location.path("/login");
    };
});