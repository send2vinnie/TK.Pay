namespace TK.Pay.Web.Navigation
{
    public static class PageNames
    {
        public static class App
        {
            public static class Common
            {
                public const string Administration = "Administration";
                public const string Roles = "Administration.Roles";
                public const string Users = "Administration.Users";
                public const string AuditLogs = "Administration.AuditLogs";
                public const string OrganizationUnits = "Administration.OrganizationUnits";
                public const string Languages = "Administration.Languages";
            }

            public static class Host
            {
                public const string Tenants = "Tenants";
                public const string Editions = "Editions";
                public const string Maintenance = "Administration.Maintenance";
                public const string Settings = "Administration.Settings.Host";
            }

            public static class Tenant
            {
                public const string Dashboard = "Dashboard.Tenant";
                public const string Settings = "Administration.Settings.Tenant";
            }
        }

        public static class Pay
        {
            public static class Order
            {
                public const string OrderManage = "OrderManage";
                public const string OrderList = "OrderManage.OrderList";
                public const string NotifyList = "OrderManage.NotifyList";
            }

            public static class Device
            {
                public const string DeviceManage = "DeviceManage";
                public const string DeviceList = "DeviceManage.DeviceList";
                public const string QRCodeList = "DeviceManage.QRCodeList";
            }
        }

        public static class Frontend
        {
            public const string Home = "Frontend.Home";
            public const string About = "Frontend.About";
        }
    }
}