using Microsoft.EntityFrameworkCore.Migrations;
using System;

namespace FirstCoreApp.Data.Migrations
{
    public partial class AddUsersAndRoles : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "Name", "NormalizedName", "ConcurrencyStamp" },
                values: new object[] { Guid.NewGuid().ToString(), "SuperAdmin", "SuperAdmin".ToUpper(), Guid.NewGuid().ToString() },
                schema: "dbo"
            );

            migrationBuilder.Sql("INSERT INTO [dbo].[AspNetUsers] ([Id], [UserName], [NormalizedUserName], [Email], [NormalizedEmail], [EmailConfirmed], [PasswordHash], [SecurityStamp], [ConcurrencyStamp], [PhoneNumber], [PhoneNumberConfirmed], [TwoFactorEnabled], [LockoutEnd], [LockoutEnabled], [AccessFailedCount]) " +
                "VALUES (N'1856ba8d-2241-481f-89f5-ac84cd841bb8', N'yousef.elmsry@gmail.com', N'YOUSEF.ELMSRY@GMAIL.COM', N'yousef.elmsry@gmail.com', N'YOUSEF.ELMSRY@GMAIL.COM', 1, N'AQAAAAEAACcQAAAAEDPDJHefLsHQdVpLlzatsfay2mHvufQ5rZZJ6Hhh+o7Ke3WEVSVQnOtBw0/k8rt1TA==', N'BMLZ6WPEHLDUUQS7UHM7J5I4CTWBHUKH', N'1e1c7817-045c-4346-807e-34ec1012edff', NULL, 0, 0, NULL, 1, 0)");
            migrationBuilder.Sql("INSERT INTO [dbo].[AspNetUsers] ([Id], [UserName], [NormalizedUserName], [Email], [NormalizedEmail], [EmailConfirmed], [PasswordHash], [SecurityStamp], [ConcurrencyStamp], [PhoneNumber], [PhoneNumberConfirmed], [TwoFactorEnabled], [LockoutEnd], [LockoutEnabled], [AccessFailedCount]) " +
                "VALUES (N'1c8196a2-f8af-4fc7-a428-f82773349c7b', N'dina@gmail.com', N'DINA@GMAIL.COM', N'dina@gmail.com', N'DINA@GMAIL.COM', 1, N'AQAAAAEAACcQAAAAEFhex1Jlmc5IVmNK6ejDcpY8kb5eNDsTlIOXW+XFx+y7F3k/XGVLr/y3q2lxl+iH4w==', N'H5CYMV3SJAVHKYPUWPBFQSBZJT7IX6JK', N'b2423b02-8aa8-48fd-a1f5-2aef37ae5e47', NULL, 0, 0, NULL, 1, 0)");

            migrationBuilder.Sql("INSERT INTO [dbo].[AspNetUserRoles] (UserId, RoleId) SELECT '1856ba8d-2241-481f-89f5-ac84cd841bb8', Id FROM[dbo].[AspNetRoles]");
            migrationBuilder.Sql("INSERT INTO [dbo].[AspNetUserRoles] (UserId, RoleId) SELECT '1c8196a2-f8af-4fc7-a428-f82773349c7b', Id FROM[dbo].[AspNetRoles]");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql("DELETE FROM [dbo].[AspNetRoles]");

            migrationBuilder.Sql("DELETE FROM [dbo].[AspNetUsers] WHERE Id = '1c8196a2-f8af-4fc7-a428-f82773349c7b'");
            migrationBuilder.Sql("DELETE FROM [dbo].[AspNetUsers] WHERE Id = '1856ba8d-2241-481f-89f5-ac84cd841bb8'");

            migrationBuilder.Sql("DELETE FROM [dbo].[AspNetUserRoles] WHERE UserId = '1856ba8d-2241-481f-89f5-ac84cd841bb8'");
            migrationBuilder.Sql("DELETE FROM [dbo].[AspNetUserRoles] WHERE UserId = '1c8196a2-f8af-4fc7-a428-f82773349c7b'");
        }
    }
}
