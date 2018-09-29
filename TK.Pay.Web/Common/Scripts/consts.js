var app = app || {};
(function () {

    $.extend(app, {
        consts: {
            grid: {
                defaultPageSize: 15,
                defaultPageSizes: [15, 20, 50, 100]
            },
            userManagement: {
                defaultAdminUserName: 'admin'
            },
            contentTypes: {
                formUrlencoded: 'application/x-www-form-urlencoded; charset=UTF-8'
            },
            friendshipState: {
                accepted: 1,
                blocked: 2
            }
        }
    });

})();