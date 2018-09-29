namespace TK.Pay.Migrations
{
    using System;
    using System.Collections.Generic;
    using System.Data.Entity.Infrastructure.Annotations;
    using System.Data.Entity.Migrations;
    
    public partial class init : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.TK_AuditLogs",
                c => new
                    {
                        Id = c.Long(nullable: false, identity: true),
                        TenantId = c.Int(),
                        UserId = c.Long(),
                        ServiceName = c.String(maxLength: 256, storeType: "nvarchar"),
                        MethodName = c.String(maxLength: 256, storeType: "nvarchar"),
                        Parameters = c.String(maxLength: 1024, storeType: "nvarchar"),
                        ExecutionTime = c.DateTime(nullable: false, precision: 0),
                        ExecutionDuration = c.Int(nullable: false),
                        ClientIpAddress = c.String(maxLength: 64, storeType: "nvarchar"),
                        ClientName = c.String(maxLength: 128, storeType: "nvarchar"),
                        BrowserInfo = c.String(maxLength: 512, storeType: "nvarchar"),
                        Exception = c.String(maxLength: 2000, storeType: "nvarchar"),
                        ImpersonatorUserId = c.Long(),
                        ImpersonatorTenantId = c.Int(),
                        CustomData = c.String(maxLength: 2000, storeType: "nvarchar"),
                    },
                annotations: new Dictionary<string, object>
                {
                    { "DynamicFilter_AuditLog_MayHaveTenant", "EntityFramework.DynamicFilters.DynamicFilterDefinition" },
                })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.TK_BackgroundJobs",
                c => new
                    {
                        Id = c.Long(nullable: false, identity: true),
                        JobType = c.String(nullable: false, maxLength: 512, storeType: "nvarchar"),
                        JobArgs = c.String(nullable: false, unicode: false),
                        TryCount = c.Short(nullable: false),
                        NextTryTime = c.DateTime(nullable: false, precision: 0),
                        LastTryTime = c.DateTime(precision: 0),
                        IsAbandoned = c.Boolean(nullable: false),
                        Priority = c.Byte(nullable: false),
                        CreationTime = c.DateTime(nullable: false, precision: 0),
                        CreatorUserId = c.Long(),
                    })
                .PrimaryKey(t => t.Id)
                .Index(t => new { t.IsAbandoned, t.NextTryTime });
            
            CreateTable(
                "dbo.AppBinaryObjects",
                c => new
                    {
                        Id = c.Guid(nullable: false),
                        TenantId = c.Int(),
                        Bytes = c.Binary(nullable: false),
                    },
                annotations: new Dictionary<string, object>
                {
                    { "DynamicFilter_BinaryObject_MayHaveTenant", "EntityFramework.DynamicFilters.DynamicFilterDefinition" },
                })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.AppChatMessages",
                c => new
                    {
                        Id = c.Long(nullable: false, identity: true),
                        UserId = c.Long(nullable: false),
                        TenantId = c.Int(),
                        TargetUserId = c.Long(nullable: false),
                        TargetTenantId = c.Int(),
                        Message = c.String(nullable: false, maxLength: 4096, storeType: "nvarchar"),
                        CreationTime = c.DateTime(nullable: false, precision: 0),
                        Side = c.Int(nullable: false),
                        ReadState = c.Int(nullable: false),
                    },
                annotations: new Dictionary<string, object>
                {
                    { "DynamicFilter_ChatMessage_MayHaveTenant", "EntityFramework.DynamicFilters.DynamicFilterDefinition" },
                })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.TK_Features",
                c => new
                    {
                        Id = c.Long(nullable: false, identity: true),
                        TenantId = c.Int(),
                        Name = c.String(nullable: false, maxLength: 128, storeType: "nvarchar"),
                        Value = c.String(nullable: false, maxLength: 2000, storeType: "nvarchar"),
                        CreationTime = c.DateTime(nullable: false, precision: 0),
                        CreatorUserId = c.Long(),
                        EditionId = c.Int(),
                        Discriminator = c.String(nullable: false, maxLength: 128, storeType: "nvarchar"),
                    },
                annotations: new Dictionary<string, object>
                {
                    { "DynamicFilter_EditionFeatureSetting_MayHaveTenant", "EntityFramework.DynamicFilters.DynamicFilterDefinition" },
                    { "DynamicFilter_FeatureSetting_MayHaveTenant", "EntityFramework.DynamicFilters.DynamicFilterDefinition" },
                    { "DynamicFilter_TenantFeatureSetting_MayHaveTenant", "EntityFramework.DynamicFilters.DynamicFilterDefinition" },
                })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.TK_Editions", t => t.EditionId, cascadeDelete: true)
                .Index(t => t.EditionId);
            
            CreateTable(
                "dbo.TK_Editions",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(nullable: false, maxLength: 32, storeType: "nvarchar"),
                        DisplayName = c.String(nullable: false, maxLength: 64, storeType: "nvarchar"),
                        IsDeleted = c.Boolean(nullable: false),
                        DeleterUserId = c.Long(),
                        DeletionTime = c.DateTime(precision: 0),
                        LastModificationTime = c.DateTime(precision: 0),
                        LastModifierUserId = c.Long(),
                        CreationTime = c.DateTime(nullable: false, precision: 0),
                        CreatorUserId = c.Long(),
                    },
                annotations: new Dictionary<string, object>
                {
                    { "DynamicFilter_Edition_SoftDelete", "EntityFramework.DynamicFilters.DynamicFilterDefinition" },
                })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.AppFriendships",
                c => new
                    {
                        Id = c.Long(nullable: false, identity: true),
                        UserId = c.Long(nullable: false),
                        TenantId = c.Int(),
                        FriendUserId = c.Long(nullable: false),
                        FriendTenantId = c.Int(),
                        FriendUserName = c.String(nullable: false, maxLength: 256, storeType: "nvarchar"),
                        FriendTenancyName = c.String(unicode: false),
                        FriendProfilePictureId = c.Guid(),
                        State = c.Int(nullable: false),
                        CreationTime = c.DateTime(nullable: false, precision: 0),
                    },
                annotations: new Dictionary<string, object>
                {
                    { "DynamicFilter_Friendship_MayHaveTenant", "EntityFramework.DynamicFilters.DynamicFilterDefinition" },
                })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.TK_Languages",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        TenantId = c.Int(),
                        Name = c.String(nullable: false, maxLength: 10, storeType: "nvarchar"),
                        DisplayName = c.String(nullable: false, maxLength: 64, storeType: "nvarchar"),
                        Icon = c.String(maxLength: 128, storeType: "nvarchar"),
                        IsDisabled = c.Boolean(nullable: false),
                        IsDeleted = c.Boolean(nullable: false),
                        DeleterUserId = c.Long(),
                        DeletionTime = c.DateTime(precision: 0),
                        LastModificationTime = c.DateTime(precision: 0),
                        LastModifierUserId = c.Long(),
                        CreationTime = c.DateTime(nullable: false, precision: 0),
                        CreatorUserId = c.Long(),
                    },
                annotations: new Dictionary<string, object>
                {
                    { "DynamicFilter_ApplicationLanguage_MayHaveTenant", "EntityFramework.DynamicFilters.DynamicFilterDefinition" },
                    { "DynamicFilter_ApplicationLanguage_SoftDelete", "EntityFramework.DynamicFilters.DynamicFilterDefinition" },
                })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.TK_LanguageTexts",
                c => new
                    {
                        Id = c.Long(nullable: false, identity: true),
                        TenantId = c.Int(),
                        LanguageName = c.String(nullable: false, maxLength: 10, storeType: "nvarchar"),
                        Source = c.String(nullable: false, maxLength: 128, storeType: "nvarchar"),
                        Key = c.String(nullable: false, maxLength: 256, storeType: "nvarchar"),
                        Value = c.String(nullable: false, unicode: false),
                        LastModificationTime = c.DateTime(precision: 0),
                        LastModifierUserId = c.Long(),
                        CreationTime = c.DateTime(nullable: false, precision: 0),
                        CreatorUserId = c.Long(),
                    },
                annotations: new Dictionary<string, object>
                {
                    { "DynamicFilter_ApplicationLanguageText_MayHaveTenant", "EntityFramework.DynamicFilters.DynamicFilterDefinition" },
                })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.TK_Notifications",
                c => new
                    {
                        Id = c.Guid(nullable: false),
                        NotificationName = c.String(nullable: false, maxLength: 96, storeType: "nvarchar"),
                        Data = c.String(unicode: false),
                        DataTypeName = c.String(maxLength: 512, storeType: "nvarchar"),
                        EntityTypeName = c.String(maxLength: 250, storeType: "nvarchar"),
                        EntityTypeAssemblyQualifiedName = c.String(maxLength: 512, storeType: "nvarchar"),
                        EntityId = c.String(maxLength: 96, storeType: "nvarchar"),
                        Severity = c.Byte(nullable: false),
                        UserIds = c.String(unicode: false),
                        ExcludedUserIds = c.String(unicode: false),
                        TenantIds = c.String(unicode: false),
                        CreationTime = c.DateTime(nullable: false, precision: 0),
                        CreatorUserId = c.Long(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.TK_NotificationSubscriptions",
                c => new
                    {
                        Id = c.Guid(nullable: false),
                        TenantId = c.Int(),
                        UserId = c.Long(nullable: false),
                        NotificationName = c.String(maxLength: 96, storeType: "nvarchar"),
                        EntityTypeName = c.String(maxLength: 250, storeType: "nvarchar"),
                        EntityTypeAssemblyQualifiedName = c.String(maxLength: 512, storeType: "nvarchar"),
                        EntityId = c.String(maxLength: 96, storeType: "nvarchar"),
                        CreationTime = c.DateTime(nullable: false, precision: 0),
                        CreatorUserId = c.Long(),
                    },
                annotations: new Dictionary<string, object>
                {
                    { "DynamicFilter_NotificationSubscriptionInfo_MayHaveTenant", "EntityFramework.DynamicFilters.DynamicFilterDefinition" },
                })
                .PrimaryKey(t => t.Id)
                .Index(t => new { t.NotificationName, t.EntityTypeName, t.EntityId, t.UserId });
            
            CreateTable(
                "dbo.TK_OrganizationUnits",
                c => new
                    {
                        Id = c.Long(nullable: false, identity: true),
                        TenantId = c.Int(),
                        ParentId = c.Long(),
                        Code = c.String(nullable: false, maxLength: 95, storeType: "nvarchar"),
                        DisplayName = c.String(nullable: false, maxLength: 128, storeType: "nvarchar"),
                        IsDeleted = c.Boolean(nullable: false),
                        DeleterUserId = c.Long(),
                        DeletionTime = c.DateTime(precision: 0),
                        LastModificationTime = c.DateTime(precision: 0),
                        LastModifierUserId = c.Long(),
                        CreationTime = c.DateTime(nullable: false, precision: 0),
                        CreatorUserId = c.Long(),
                    },
                annotations: new Dictionary<string, object>
                {
                    { "DynamicFilter_OrganizationUnit_MayHaveTenant", "EntityFramework.DynamicFilters.DynamicFilterDefinition" },
                    { "DynamicFilter_OrganizationUnit_SoftDelete", "EntityFramework.DynamicFilters.DynamicFilterDefinition" },
                })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.TK_OrganizationUnits", t => t.ParentId)
                .Index(t => t.ParentId);
            
            CreateTable(
                "dbo.TK_Permissions",
                c => new
                    {
                        Id = c.Long(nullable: false, identity: true),
                        TenantId = c.Int(),
                        Name = c.String(nullable: false, maxLength: 128, storeType: "nvarchar"),
                        IsGranted = c.Boolean(nullable: false),
                        CreationTime = c.DateTime(nullable: false, precision: 0),
                        CreatorUserId = c.Long(),
                        RoleId = c.Int(),
                        UserId = c.Long(),
                        Discriminator = c.String(nullable: false, maxLength: 128, storeType: "nvarchar"),
                    },
                annotations: new Dictionary<string, object>
                {
                    { "DynamicFilter_PermissionSetting_MayHaveTenant", "EntityFramework.DynamicFilters.DynamicFilterDefinition" },
                    { "DynamicFilter_RolePermissionSetting_MayHaveTenant", "EntityFramework.DynamicFilters.DynamicFilterDefinition" },
                    { "DynamicFilter_UserPermissionSetting_MayHaveTenant", "EntityFramework.DynamicFilters.DynamicFilterDefinition" },
                })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.TK_Users", t => t.UserId, cascadeDelete: true)
                .ForeignKey("dbo.TK_Roles", t => t.RoleId, cascadeDelete: true)
                .Index(t => t.RoleId)
                .Index(t => t.UserId);
            
            CreateTable(
                "dbo.TK_Roles",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        TenantId = c.Int(),
                        Name = c.String(nullable: false, maxLength: 32, storeType: "nvarchar"),
                        DisplayName = c.String(nullable: false, maxLength: 64, storeType: "nvarchar"),
                        IsStatic = c.Boolean(nullable: false),
                        IsDefault = c.Boolean(nullable: false),
                        IsDeleted = c.Boolean(nullable: false),
                        DeleterUserId = c.Long(),
                        DeletionTime = c.DateTime(precision: 0),
                        LastModificationTime = c.DateTime(precision: 0),
                        LastModifierUserId = c.Long(),
                        CreationTime = c.DateTime(nullable: false, precision: 0),
                        CreatorUserId = c.Long(),
                    },
                annotations: new Dictionary<string, object>
                {
                    { "DynamicFilter_Role_MayHaveTenant", "EntityFramework.DynamicFilters.DynamicFilterDefinition" },
                    { "DynamicFilter_Role_SoftDelete", "EntityFramework.DynamicFilters.DynamicFilterDefinition" },
                })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.TK_Users", t => t.CreatorUserId)
                .ForeignKey("dbo.TK_Users", t => t.DeleterUserId)
                .ForeignKey("dbo.TK_Users", t => t.LastModifierUserId)
                .Index(t => t.DeleterUserId)
                .Index(t => t.LastModifierUserId)
                .Index(t => t.CreatorUserId);
            
            CreateTable(
                "dbo.TK_Users",
                c => new
                    {
                        Id = c.Long(nullable: false, identity: true),
                        ProfilePictureId = c.Guid(),
                        ShouldChangePasswordOnNextLogin = c.Boolean(nullable: false),
                        AuthenticationSource = c.String(maxLength: 64, storeType: "nvarchar"),
                        UserName = c.String(nullable: false, maxLength: 256, storeType: "nvarchar"),
                        TenantId = c.Int(),
                        EmailAddress = c.String(nullable: false, maxLength: 256, storeType: "nvarchar"),
                        Name = c.String(nullable: false, maxLength: 32, storeType: "nvarchar"),
                        Surname = c.String(nullable: false, maxLength: 32, storeType: "nvarchar"),
                        Password = c.String(nullable: false, maxLength: 128, storeType: "nvarchar"),
                        EmailConfirmationCode = c.String(maxLength: 328, storeType: "nvarchar"),
                        PasswordResetCode = c.String(maxLength: 328, storeType: "nvarchar"),
                        LockoutEndDateUtc = c.DateTime(precision: 0),
                        AccessFailedCount = c.Int(nullable: false),
                        IsLockoutEnabled = c.Boolean(nullable: false),
                        PhoneNumber = c.String(maxLength: 32, storeType: "nvarchar"),
                        IsPhoneNumberConfirmed = c.Boolean(nullable: false),
                        SecurityStamp = c.String(maxLength: 128, storeType: "nvarchar"),
                        IsTwoFactorEnabled = c.Boolean(nullable: false),
                        IsEmailConfirmed = c.Boolean(nullable: false),
                        IsActive = c.Boolean(nullable: false),
                        LastLoginTime = c.DateTime(precision: 0),
                        IsDeleted = c.Boolean(nullable: false),
                        DeleterUserId = c.Long(),
                        DeletionTime = c.DateTime(precision: 0),
                        LastModificationTime = c.DateTime(precision: 0),
                        LastModifierUserId = c.Long(),
                        CreationTime = c.DateTime(nullable: false, precision: 0),
                        CreatorUserId = c.Long(),
                    },
                annotations: new Dictionary<string, object>
                {
                    { "DynamicFilter_User_MayHaveTenant", "EntityFramework.DynamicFilters.DynamicFilterDefinition" },
                    { "DynamicFilter_User_SoftDelete", "EntityFramework.DynamicFilters.DynamicFilterDefinition" },
                })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.TK_Users", t => t.CreatorUserId)
                .ForeignKey("dbo.TK_Users", t => t.DeleterUserId)
                .ForeignKey("dbo.TK_Users", t => t.LastModifierUserId)
                .Index(t => t.DeleterUserId)
                .Index(t => t.LastModifierUserId)
                .Index(t => t.CreatorUserId);
            
            CreateTable(
                "dbo.TK_UserClaims",
                c => new
                    {
                        Id = c.Long(nullable: false, identity: true),
                        TenantId = c.Int(),
                        UserId = c.Long(nullable: false),
                        ClaimType = c.String(maxLength: 256, storeType: "nvarchar"),
                        ClaimValue = c.String(unicode: false),
                        CreationTime = c.DateTime(nullable: false, precision: 0),
                        CreatorUserId = c.Long(),
                    },
                annotations: new Dictionary<string, object>
                {
                    { "DynamicFilter_UserClaim_MayHaveTenant", "EntityFramework.DynamicFilters.DynamicFilterDefinition" },
                })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.TK_Users", t => t.UserId, cascadeDelete: true)
                .Index(t => t.UserId);
            
            CreateTable(
                "dbo.TK_UserLogins",
                c => new
                    {
                        Id = c.Long(nullable: false, identity: true),
                        TenantId = c.Int(),
                        UserId = c.Long(nullable: false),
                        LoginProvider = c.String(nullable: false, maxLength: 128, storeType: "nvarchar"),
                        ProviderKey = c.String(nullable: false, maxLength: 256, storeType: "nvarchar"),
                    },
                annotations: new Dictionary<string, object>
                {
                    { "DynamicFilter_UserLogin_MayHaveTenant", "EntityFramework.DynamicFilters.DynamicFilterDefinition" },
                })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.TK_Users", t => t.UserId, cascadeDelete: true)
                .Index(t => t.UserId);
            
            CreateTable(
                "dbo.TK_UserRoles",
                c => new
                    {
                        Id = c.Long(nullable: false, identity: true),
                        TenantId = c.Int(),
                        UserId = c.Long(nullable: false),
                        RoleId = c.Int(nullable: false),
                        CreationTime = c.DateTime(nullable: false, precision: 0),
                        CreatorUserId = c.Long(),
                    },
                annotations: new Dictionary<string, object>
                {
                    { "DynamicFilter_UserRole_MayHaveTenant", "EntityFramework.DynamicFilters.DynamicFilterDefinition" },
                })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.TK_Users", t => t.UserId, cascadeDelete: true)
                .Index(t => t.UserId);
            
            CreateTable(
                "dbo.TK_Settings",
                c => new
                    {
                        Id = c.Long(nullable: false, identity: true),
                        TenantId = c.Int(),
                        UserId = c.Long(),
                        Name = c.String(nullable: false, maxLength: 256, storeType: "nvarchar"),
                        Value = c.String(maxLength: 2000, storeType: "nvarchar"),
                        LastModificationTime = c.DateTime(precision: 0),
                        LastModifierUserId = c.Long(),
                        CreationTime = c.DateTime(nullable: false, precision: 0),
                        CreatorUserId = c.Long(),
                    },
                annotations: new Dictionary<string, object>
                {
                    { "DynamicFilter_Setting_MayHaveTenant", "EntityFramework.DynamicFilters.DynamicFilterDefinition" },
                })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.TK_Users", t => t.UserId)
                .Index(t => t.UserId);
            
            CreateTable(
                "dbo.TK_TenantNotifications",
                c => new
                    {
                        Id = c.Guid(nullable: false),
                        TenantId = c.Int(),
                        NotificationName = c.String(nullable: false, maxLength: 96, storeType: "nvarchar"),
                        Data = c.String(unicode: false),
                        DataTypeName = c.String(maxLength: 512, storeType: "nvarchar"),
                        EntityTypeName = c.String(maxLength: 250, storeType: "nvarchar"),
                        EntityTypeAssemblyQualifiedName = c.String(maxLength: 512, storeType: "nvarchar"),
                        EntityId = c.String(maxLength: 96, storeType: "nvarchar"),
                        Severity = c.Byte(nullable: false),
                        CreationTime = c.DateTime(nullable: false, precision: 0),
                        CreatorUserId = c.Long(),
                    },
                annotations: new Dictionary<string, object>
                {
                    { "DynamicFilter_TenantNotificationInfo_MayHaveTenant", "EntityFramework.DynamicFilters.DynamicFilterDefinition" },
                })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.TK_Tenants",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        CustomCssId = c.Guid(),
                        LogoId = c.Guid(),
                        LogoFileType = c.String(maxLength: 64, storeType: "nvarchar"),
                        EditionId = c.Int(),
                        TenancyName = c.String(nullable: false, maxLength: 64, storeType: "nvarchar"),
                        Name = c.String(nullable: false, maxLength: 128, storeType: "nvarchar"),
                        ConnectionString = c.String(maxLength: 1024, storeType: "nvarchar"),
                        IsActive = c.Boolean(nullable: false),
                        IsDeleted = c.Boolean(nullable: false),
                        DeleterUserId = c.Long(),
                        DeletionTime = c.DateTime(precision: 0),
                        LastModificationTime = c.DateTime(precision: 0),
                        LastModifierUserId = c.Long(),
                        CreationTime = c.DateTime(nullable: false, precision: 0),
                        CreatorUserId = c.Long(),
                    },
                annotations: new Dictionary<string, object>
                {
                    { "DynamicFilter_Tenant_SoftDelete", "EntityFramework.DynamicFilters.DynamicFilterDefinition" },
                })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.TK_Users", t => t.CreatorUserId)
                .ForeignKey("dbo.TK_Users", t => t.DeleterUserId)
                .ForeignKey("dbo.TK_Editions", t => t.EditionId)
                .ForeignKey("dbo.TK_Users", t => t.LastModifierUserId)
                .Index(t => t.EditionId)
                .Index(t => t.DeleterUserId)
                .Index(t => t.LastModifierUserId)
                .Index(t => t.CreatorUserId);
            
            CreateTable(
                "dbo.TK_UserAccounts",
                c => new
                    {
                        Id = c.Long(nullable: false, identity: true),
                        TenantId = c.Int(),
                        UserId = c.Long(nullable: false),
                        UserLinkId = c.Long(),
                        UserName = c.String(maxLength: 256, storeType: "nvarchar"),
                        EmailAddress = c.String(maxLength: 256, storeType: "nvarchar"),
                        LastLoginTime = c.DateTime(precision: 0),
                        IsDeleted = c.Boolean(nullable: false),
                        DeleterUserId = c.Long(),
                        DeletionTime = c.DateTime(precision: 0),
                        LastModificationTime = c.DateTime(precision: 0),
                        LastModifierUserId = c.Long(),
                        CreationTime = c.DateTime(nullable: false, precision: 0),
                        CreatorUserId = c.Long(),
                    },
                annotations: new Dictionary<string, object>
                {
                    { "DynamicFilter_UserAccount_SoftDelete", "EntityFramework.DynamicFilters.DynamicFilterDefinition" },
                })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.TK_UserLoginAttempts",
                c => new
                    {
                        Id = c.Long(nullable: false, identity: true),
                        TenantId = c.Int(),
                        TenancyName = c.String(maxLength: 64, storeType: "nvarchar"),
                        UserId = c.Long(),
                        UserNameOrEmailAddress = c.String(maxLength: 255, storeType: "nvarchar"),
                        ClientIpAddress = c.String(maxLength: 64, storeType: "nvarchar"),
                        ClientName = c.String(maxLength: 128, storeType: "nvarchar"),
                        BrowserInfo = c.String(maxLength: 512, storeType: "nvarchar"),
                        Result = c.Byte(nullable: false),
                        CreationTime = c.DateTime(nullable: false, precision: 0),
                    },
                annotations: new Dictionary<string, object>
                {
                    { "DynamicFilter_UserLoginAttempt_MayHaveTenant", "EntityFramework.DynamicFilters.DynamicFilterDefinition" },
                })
                .PrimaryKey(t => t.Id)
                .Index(t => new { t.UserId, t.TenantId })
                .Index(t => new { t.TenancyName, t.UserNameOrEmailAddress, t.Result });
            
            CreateTable(
                "dbo.TK_UserNotifications",
                c => new
                    {
                        Id = c.Guid(nullable: false),
                        TenantId = c.Int(),
                        UserId = c.Long(nullable: false),
                        TenantNotificationId = c.Guid(nullable: false),
                        State = c.Int(nullable: false),
                        CreationTime = c.DateTime(nullable: false, precision: 0),
                    },
                annotations: new Dictionary<string, object>
                {
                    { "DynamicFilter_UserNotificationInfo_MayHaveTenant", "EntityFramework.DynamicFilters.DynamicFilterDefinition" },
                })
                .PrimaryKey(t => t.Id)
                .Index(t => new { t.UserId, t.State, t.CreationTime });
            
            CreateTable(
                "dbo.TK_UserOrganizationUnits",
                c => new
                    {
                        Id = c.Long(nullable: false, identity: true),
                        TenantId = c.Int(),
                        UserId = c.Long(nullable: false),
                        OrganizationUnitId = c.Long(nullable: false),
                        IsDeleted = c.Boolean(nullable: false),
                        CreationTime = c.DateTime(nullable: false, precision: 0),
                        CreatorUserId = c.Long(),
                    },
                annotations: new Dictionary<string, object>
                {
                    { "DynamicFilter_UserOrganizationUnit_MayHaveTenant", "EntityFramework.DynamicFilters.DynamicFilterDefinition" },
                    { "DynamicFilter_UserOrganizationUnit_SoftDelete", "EntityFramework.DynamicFilters.DynamicFilterDefinition" },
                })
                .PrimaryKey(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.TK_Tenants", "LastModifierUserId", "dbo.TK_Users");
            DropForeignKey("dbo.TK_Tenants", "EditionId", "dbo.TK_Editions");
            DropForeignKey("dbo.TK_Tenants", "DeleterUserId", "dbo.TK_Users");
            DropForeignKey("dbo.TK_Tenants", "CreatorUserId", "dbo.TK_Users");
            DropForeignKey("dbo.TK_Permissions", "RoleId", "dbo.TK_Roles");
            DropForeignKey("dbo.TK_Roles", "LastModifierUserId", "dbo.TK_Users");
            DropForeignKey("dbo.TK_Roles", "DeleterUserId", "dbo.TK_Users");
            DropForeignKey("dbo.TK_Roles", "CreatorUserId", "dbo.TK_Users");
            DropForeignKey("dbo.TK_Settings", "UserId", "dbo.TK_Users");
            DropForeignKey("dbo.TK_UserRoles", "UserId", "dbo.TK_Users");
            DropForeignKey("dbo.TK_Permissions", "UserId", "dbo.TK_Users");
            DropForeignKey("dbo.TK_UserLogins", "UserId", "dbo.TK_Users");
            DropForeignKey("dbo.TK_Users", "LastModifierUserId", "dbo.TK_Users");
            DropForeignKey("dbo.TK_Users", "DeleterUserId", "dbo.TK_Users");
            DropForeignKey("dbo.TK_Users", "CreatorUserId", "dbo.TK_Users");
            DropForeignKey("dbo.TK_UserClaims", "UserId", "dbo.TK_Users");
            DropForeignKey("dbo.TK_OrganizationUnits", "ParentId", "dbo.TK_OrganizationUnits");
            DropForeignKey("dbo.TK_Features", "EditionId", "dbo.TK_Editions");
            DropIndex("dbo.TK_UserNotifications", new[] { "UserId", "State", "CreationTime" });
            DropIndex("dbo.TK_UserLoginAttempts", new[] { "TenancyName", "UserNameOrEmailAddress", "Result" });
            DropIndex("dbo.TK_UserLoginAttempts", new[] { "UserId", "TenantId" });
            DropIndex("dbo.TK_Tenants", new[] { "CreatorUserId" });
            DropIndex("dbo.TK_Tenants", new[] { "LastModifierUserId" });
            DropIndex("dbo.TK_Tenants", new[] { "DeleterUserId" });
            DropIndex("dbo.TK_Tenants", new[] { "EditionId" });
            DropIndex("dbo.TK_Settings", new[] { "UserId" });
            DropIndex("dbo.TK_UserRoles", new[] { "UserId" });
            DropIndex("dbo.TK_UserLogins", new[] { "UserId" });
            DropIndex("dbo.TK_UserClaims", new[] { "UserId" });
            DropIndex("dbo.TK_Users", new[] { "CreatorUserId" });
            DropIndex("dbo.TK_Users", new[] { "LastModifierUserId" });
            DropIndex("dbo.TK_Users", new[] { "DeleterUserId" });
            DropIndex("dbo.TK_Roles", new[] { "CreatorUserId" });
            DropIndex("dbo.TK_Roles", new[] { "LastModifierUserId" });
            DropIndex("dbo.TK_Roles", new[] { "DeleterUserId" });
            DropIndex("dbo.TK_Permissions", new[] { "UserId" });
            DropIndex("dbo.TK_Permissions", new[] { "RoleId" });
            DropIndex("dbo.TK_OrganizationUnits", new[] { "ParentId" });
            DropIndex("dbo.TK_NotificationSubscriptions", new[] { "NotificationName", "EntityTypeName", "EntityId", "UserId" });
            DropIndex("dbo.TK_Features", new[] { "EditionId" });
            DropIndex("dbo.TK_BackgroundJobs", new[] { "IsAbandoned", "NextTryTime" });
            DropTable("dbo.TK_UserOrganizationUnits",
                removedAnnotations: new Dictionary<string, object>
                {
                    { "DynamicFilter_UserOrganizationUnit_MayHaveTenant", "EntityFramework.DynamicFilters.DynamicFilterDefinition" },
                    { "DynamicFilter_UserOrganizationUnit_SoftDelete", "EntityFramework.DynamicFilters.DynamicFilterDefinition" },
                });
            DropTable("dbo.TK_UserNotifications",
                removedAnnotations: new Dictionary<string, object>
                {
                    { "DynamicFilter_UserNotificationInfo_MayHaveTenant", "EntityFramework.DynamicFilters.DynamicFilterDefinition" },
                });
            DropTable("dbo.TK_UserLoginAttempts",
                removedAnnotations: new Dictionary<string, object>
                {
                    { "DynamicFilter_UserLoginAttempt_MayHaveTenant", "EntityFramework.DynamicFilters.DynamicFilterDefinition" },
                });
            DropTable("dbo.TK_UserAccounts",
                removedAnnotations: new Dictionary<string, object>
                {
                    { "DynamicFilter_UserAccount_SoftDelete", "EntityFramework.DynamicFilters.DynamicFilterDefinition" },
                });
            DropTable("dbo.TK_Tenants",
                removedAnnotations: new Dictionary<string, object>
                {
                    { "DynamicFilter_Tenant_SoftDelete", "EntityFramework.DynamicFilters.DynamicFilterDefinition" },
                });
            DropTable("dbo.TK_TenantNotifications",
                removedAnnotations: new Dictionary<string, object>
                {
                    { "DynamicFilter_TenantNotificationInfo_MayHaveTenant", "EntityFramework.DynamicFilters.DynamicFilterDefinition" },
                });
            DropTable("dbo.TK_Settings",
                removedAnnotations: new Dictionary<string, object>
                {
                    { "DynamicFilter_Setting_MayHaveTenant", "EntityFramework.DynamicFilters.DynamicFilterDefinition" },
                });
            DropTable("dbo.TK_UserRoles",
                removedAnnotations: new Dictionary<string, object>
                {
                    { "DynamicFilter_UserRole_MayHaveTenant", "EntityFramework.DynamicFilters.DynamicFilterDefinition" },
                });
            DropTable("dbo.TK_UserLogins",
                removedAnnotations: new Dictionary<string, object>
                {
                    { "DynamicFilter_UserLogin_MayHaveTenant", "EntityFramework.DynamicFilters.DynamicFilterDefinition" },
                });
            DropTable("dbo.TK_UserClaims",
                removedAnnotations: new Dictionary<string, object>
                {
                    { "DynamicFilter_UserClaim_MayHaveTenant", "EntityFramework.DynamicFilters.DynamicFilterDefinition" },
                });
            DropTable("dbo.TK_Users",
                removedAnnotations: new Dictionary<string, object>
                {
                    { "DynamicFilter_User_MayHaveTenant", "EntityFramework.DynamicFilters.DynamicFilterDefinition" },
                    { "DynamicFilter_User_SoftDelete", "EntityFramework.DynamicFilters.DynamicFilterDefinition" },
                });
            DropTable("dbo.TK_Roles",
                removedAnnotations: new Dictionary<string, object>
                {
                    { "DynamicFilter_Role_MayHaveTenant", "EntityFramework.DynamicFilters.DynamicFilterDefinition" },
                    { "DynamicFilter_Role_SoftDelete", "EntityFramework.DynamicFilters.DynamicFilterDefinition" },
                });
            DropTable("dbo.TK_Permissions",
                removedAnnotations: new Dictionary<string, object>
                {
                    { "DynamicFilter_PermissionSetting_MayHaveTenant", "EntityFramework.DynamicFilters.DynamicFilterDefinition" },
                    { "DynamicFilter_RolePermissionSetting_MayHaveTenant", "EntityFramework.DynamicFilters.DynamicFilterDefinition" },
                    { "DynamicFilter_UserPermissionSetting_MayHaveTenant", "EntityFramework.DynamicFilters.DynamicFilterDefinition" },
                });
            DropTable("dbo.TK_OrganizationUnits",
                removedAnnotations: new Dictionary<string, object>
                {
                    { "DynamicFilter_OrganizationUnit_MayHaveTenant", "EntityFramework.DynamicFilters.DynamicFilterDefinition" },
                    { "DynamicFilter_OrganizationUnit_SoftDelete", "EntityFramework.DynamicFilters.DynamicFilterDefinition" },
                });
            DropTable("dbo.TK_NotificationSubscriptions",
                removedAnnotations: new Dictionary<string, object>
                {
                    { "DynamicFilter_NotificationSubscriptionInfo_MayHaveTenant", "EntityFramework.DynamicFilters.DynamicFilterDefinition" },
                });
            DropTable("dbo.TK_Notifications");
            DropTable("dbo.TK_LanguageTexts",
                removedAnnotations: new Dictionary<string, object>
                {
                    { "DynamicFilter_ApplicationLanguageText_MayHaveTenant", "EntityFramework.DynamicFilters.DynamicFilterDefinition" },
                });
            DropTable("dbo.TK_Languages",
                removedAnnotations: new Dictionary<string, object>
                {
                    { "DynamicFilter_ApplicationLanguage_MayHaveTenant", "EntityFramework.DynamicFilters.DynamicFilterDefinition" },
                    { "DynamicFilter_ApplicationLanguage_SoftDelete", "EntityFramework.DynamicFilters.DynamicFilterDefinition" },
                });
            DropTable("dbo.AppFriendships",
                removedAnnotations: new Dictionary<string, object>
                {
                    { "DynamicFilter_Friendship_MayHaveTenant", "EntityFramework.DynamicFilters.DynamicFilterDefinition" },
                });
            DropTable("dbo.TK_Editions",
                removedAnnotations: new Dictionary<string, object>
                {
                    { "DynamicFilter_Edition_SoftDelete", "EntityFramework.DynamicFilters.DynamicFilterDefinition" },
                });
            DropTable("dbo.TK_Features",
                removedAnnotations: new Dictionary<string, object>
                {
                    { "DynamicFilter_EditionFeatureSetting_MayHaveTenant", "EntityFramework.DynamicFilters.DynamicFilterDefinition" },
                    { "DynamicFilter_FeatureSetting_MayHaveTenant", "EntityFramework.DynamicFilters.DynamicFilterDefinition" },
                    { "DynamicFilter_TenantFeatureSetting_MayHaveTenant", "EntityFramework.DynamicFilters.DynamicFilterDefinition" },
                });
            DropTable("dbo.AppChatMessages",
                removedAnnotations: new Dictionary<string, object>
                {
                    { "DynamicFilter_ChatMessage_MayHaveTenant", "EntityFramework.DynamicFilters.DynamicFilterDefinition" },
                });
            DropTable("dbo.AppBinaryObjects",
                removedAnnotations: new Dictionary<string, object>
                {
                    { "DynamicFilter_BinaryObject_MayHaveTenant", "EntityFramework.DynamicFilters.DynamicFilterDefinition" },
                });
            DropTable("dbo.TK_BackgroundJobs");
            DropTable("dbo.TK_AuditLogs",
                removedAnnotations: new Dictionary<string, object>
                {
                    { "DynamicFilter_AuditLog_MayHaveTenant", "EntityFramework.DynamicFilters.DynamicFilterDefinition" },
                });
        }
    }
}
