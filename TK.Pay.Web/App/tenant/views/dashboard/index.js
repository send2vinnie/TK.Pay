(function () {
    appModule.controller('tenant.views.dashboard.index', [
        '$scope', 'abp.services.app.tenantDashboard',
        function ($scope, tenantDashboardService) {
            var vm = this;
            
            $scope.$on('$viewContentLoaded', function () {
                App.initAjax();
            });

            vm.getMemberActivity = function () {
                tenantDashboardService.getMemberActivity({}).then(function (result) {
                    $("#totalMembersChart").sparkline(result.data.totalMembers, {
                        type: 'bar',
                        width: '100',
                        barWidth: 6,
                        height: '45',
                        barColor: '#F36A5B',
                        negBarColor: '#e02222',
                        chartRangeMin: 0
                    });

                    $("#newMembersChart").sparkline(result.data.newMembers, {
                        type: 'bar',
                        width: '100',
                        barWidth: 6,
                        height: '45',
                        barColor: '#5C9BD1',
                        negBarColor: '#e02222',
                        chartRangeMin: 0
                    });
                });
            };

            vm.getMemberActivity();
        }
    ]);
})();