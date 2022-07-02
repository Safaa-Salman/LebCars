CREATE TABLE IF NOT EXISTS "__EFMigrationsHistory" (
    "MigrationId" TEXT NOT NULL CONSTRAINT "PK___EFMigrationsHistory" PRIMARY KEY,
    "ProductVersion" TEXT NOT NULL
);

BEGIN TRANSACTION;

CREATE TABLE "AspNetRoles" (
    "Id" TEXT NOT NULL CONSTRAINT "PK_AspNetRoles" PRIMARY KEY,
    "Name" TEXT NULL,
    "NormalizedName" TEXT NULL,
    "ConcurrencyStamp" TEXT NULL
);

CREATE TABLE "AspNetUsers" (
    "Id" TEXT NOT NULL CONSTRAINT "PK_AspNetUsers" PRIMARY KEY,
    "DisplayName" TEXT NULL,
    "Bio" TEXT NULL,
    "UserName" TEXT NULL,
    "NormalizedUserName" TEXT NULL,
    "Email" TEXT NULL,
    "NormalizedEmail" TEXT NULL,
    "EmailConfirmed" INTEGER NOT NULL,
    "PasswordHash" TEXT NULL,
    "SecurityStamp" TEXT NULL,
    "ConcurrencyStamp" TEXT NULL,
    "PhoneNumber" TEXT NULL,
    "PhoneNumberConfirmed" INTEGER NOT NULL,
    "TwoFactorEnabled" INTEGER NOT NULL,
    "LockoutEnd" TEXT NULL,
    "LockoutEnabled" INTEGER NOT NULL,
    "AccessFailedCount" INTEGER NOT NULL
);

CREATE TABLE "Rides" (
    "Id" TEXT NOT NULL CONSTRAINT "PK_Rides" PRIMARY KEY,
    "Departure" TEXT NULL,
    "Destination" TEXT NULL,
    "departureDate" TEXT NOT NULL,
    "returnDate" TEXT NOT NULL,
    "passengerNumber" TEXT NULL,
    "Cost" TEXT NULL,
    "Children" INTEGER NOT NULL,
    "Animals" INTEGER NOT NULL,
    "Smoking" INTEGER NOT NULL,
    "IsCancelled" INTEGER NOT NULL
);

CREATE TABLE "AspNetRoleClaims" (
    "Id" INTEGER NOT NULL CONSTRAINT "PK_AspNetRoleClaims" PRIMARY KEY AUTOINCREMENT,
    "RoleId" TEXT NOT NULL,
    "ClaimType" TEXT NULL,
    "ClaimValue" TEXT NULL,
    CONSTRAINT "FK_AspNetRoleClaims_AspNetRoles_RoleId" FOREIGN KEY ("RoleId") REFERENCES "AspNetRoles" ("Id") ON DELETE CASCADE
);

CREATE TABLE "AspNetUserClaims" (
    "Id" INTEGER NOT NULL CONSTRAINT "PK_AspNetUserClaims" PRIMARY KEY AUTOINCREMENT,
    "UserId" TEXT NOT NULL,
    "ClaimType" TEXT NULL,
    "ClaimValue" TEXT NULL,
    CONSTRAINT "FK_AspNetUserClaims_AspNetUsers_UserId" FOREIGN KEY ("UserId") REFERENCES "AspNetUsers" ("Id") ON DELETE CASCADE
);

CREATE TABLE "AspNetUserLogins" (
    "LoginProvider" TEXT NOT NULL,
    "ProviderKey" TEXT NOT NULL,
    "ProviderDisplayName" TEXT NULL,
    "UserId" TEXT NOT NULL,
    CONSTRAINT "PK_AspNetUserLogins" PRIMARY KEY ("LoginProvider", "ProviderKey"),
    CONSTRAINT "FK_AspNetUserLogins_AspNetUsers_UserId" FOREIGN KEY ("UserId") REFERENCES "AspNetUsers" ("Id") ON DELETE CASCADE
);

CREATE TABLE "AspNetUserRoles" (
    "UserId" TEXT NOT NULL,
    "RoleId" TEXT NOT NULL,
    CONSTRAINT "PK_AspNetUserRoles" PRIMARY KEY ("UserId", "RoleId"),
    CONSTRAINT "FK_AspNetUserRoles_AspNetRoles_RoleId" FOREIGN KEY ("RoleId") REFERENCES "AspNetRoles" ("Id") ON DELETE CASCADE,
    CONSTRAINT "FK_AspNetUserRoles_AspNetUsers_UserId" FOREIGN KEY ("UserId") REFERENCES "AspNetUsers" ("Id") ON DELETE CASCADE
);

CREATE TABLE "AspNetUserTokens" (
    "UserId" TEXT NOT NULL,
    "LoginProvider" TEXT NOT NULL,
    "Name" TEXT NOT NULL,
    "Value" TEXT NULL,
    CONSTRAINT "PK_AspNetUserTokens" PRIMARY KEY ("UserId", "LoginProvider", "Name"),
    CONSTRAINT "FK_AspNetUserTokens_AspNetUsers_UserId" FOREIGN KEY ("UserId") REFERENCES "AspNetUsers" ("Id") ON DELETE CASCADE
);

CREATE TABLE "RideAttendees" (
    "AppUserId" TEXT NOT NULL,
    "RideId" TEXT NOT NULL,
    "IsDriver" INTEGER NOT NULL,
    CONSTRAINT "PK_RideAttendees" PRIMARY KEY ("AppUserId", "RideId"),
    CONSTRAINT "FK_RideAttendees_AspNetUsers_AppUserId" FOREIGN KEY ("AppUserId") REFERENCES "AspNetUsers" ("Id") ON DELETE CASCADE,
    CONSTRAINT "FK_RideAttendees_Rides_RideId" FOREIGN KEY ("RideId") REFERENCES "Rides" ("Id") ON DELETE CASCADE
);

CREATE INDEX "IX_AspNetRoleClaims_RoleId" ON "AspNetRoleClaims" ("RoleId");

CREATE UNIQUE INDEX "RoleNameIndex" ON "AspNetRoles" ("NormalizedName");

CREATE INDEX "IX_AspNetUserClaims_UserId" ON "AspNetUserClaims" ("UserId");

CREATE INDEX "IX_AspNetUserLogins_UserId" ON "AspNetUserLogins" ("UserId");

CREATE INDEX "IX_AspNetUserRoles_RoleId" ON "AspNetUserRoles" ("RoleId");

CREATE INDEX "EmailIndex" ON "AspNetUsers" ("NormalizedEmail");

CREATE UNIQUE INDEX "UserNameIndex" ON "AspNetUsers" ("NormalizedUserName");

CREATE INDEX "IX_RideAttendees_RideId" ON "RideAttendees" ("RideId");

INSERT INTO "__EFMigrationsHistory" ("MigrationId", "ProductVersion")
VALUES ('20210809101028_InitialCreate', '5.0.8');

COMMIT;

BEGIN TRANSACTION;

ALTER TABLE "Rides" ADD "Description" TEXT NULL;

INSERT INTO "__EFMigrationsHistory" ("MigrationId", "ProductVersion")
VALUES ('20210813111617_DescriptionAdded', '5.0.8');

COMMIT;

BEGIN TRANSACTION;

CREATE TABLE "Photos" (
    "Id" TEXT NOT NULL CONSTRAINT "PK_Photos" PRIMARY KEY,
    "Url" TEXT NULL,
    "IsMain" INTEGER NOT NULL,
    "AppUserId" TEXT NULL,
    CONSTRAINT "FK_Photos_AspNetUsers_AppUserId" FOREIGN KEY ("AppUserId") REFERENCES "AspNetUsers" ("Id") ON DELETE RESTRICT
);

CREATE INDEX "IX_Photos_AppUserId" ON "Photos" ("AppUserId");

INSERT INTO "__EFMigrationsHistory" ("MigrationId", "ProductVersion")
VALUES ('20210827205146_PhotoEntityAdded', '5.0.8');

COMMIT;

BEGIN TRANSACTION;

CREATE TABLE "Comments" (
    "Id" INTEGER NOT NULL CONSTRAINT "PK_Comments" PRIMARY KEY AUTOINCREMENT,
    "Body" TEXT NULL,
    "AuthorId" TEXT NULL,
    "RideId" TEXT NULL,
    "CreatedAt" TEXT NOT NULL,
    CONSTRAINT "FK_Comments_AspNetUsers_AuthorId" FOREIGN KEY ("AuthorId") REFERENCES "AspNetUsers" ("Id") ON DELETE RESTRICT,
    CONSTRAINT "FK_Comments_Rides_RideId" FOREIGN KEY ("RideId") REFERENCES "Rides" ("Id") ON DELETE CASCADE
);

CREATE INDEX "IX_Comments_AuthorId" ON "Comments" ("AuthorId");

CREATE INDEX "IX_Comments_RideId" ON "Comments" ("RideId");

INSERT INTO "__EFMigrationsHistory" ("MigrationId", "ProductVersion")
VALUES ('20210901201850_CommentEntityAdded', '5.0.8');

COMMIT;

BEGIN TRANSACTION;

CREATE TABLE "UserFollowings" (
    "ObserverId" TEXT NOT NULL,
    "TargetId" TEXT NOT NULL,
    CONSTRAINT "PK_UserFollowings" PRIMARY KEY ("ObserverId", "TargetId"),
    CONSTRAINT "FK_UserFollowings_AspNetUsers_ObserverId" FOREIGN KEY ("ObserverId") REFERENCES "AspNetUsers" ("Id") ON DELETE CASCADE,
    CONSTRAINT "FK_UserFollowings_AspNetUsers_TargetId" FOREIGN KEY ("TargetId") REFERENCES "AspNetUsers" ("Id") ON DELETE CASCADE
);

CREATE INDEX "IX_UserFollowings_TargetId" ON "UserFollowings" ("TargetId");

INSERT INTO "__EFMigrationsHistory" ("MigrationId", "ProductVersion")
VALUES ('20210908115846_FollowingEntityAddeed', '5.0.8');

COMMIT;

BEGIN TRANSACTION;

ALTER TABLE "AspNetUsers" ADD "Age" TEXT NULL;

ALTER TABLE "AspNetUsers" ADD "CarModel" TEXT NULL;

ALTER TABLE "AspNetUsers" ADD "CarNumber" TEXT NULL;

ALTER TABLE "AspNetUsers" ADD "Gender" TEXT NULL;

INSERT INTO "__EFMigrationsHistory" ("MigrationId", "ProductVersion")
VALUES ('20210911215535_ProfileUpdated', '5.0.8');

COMMIT;

BEGIN TRANSACTION;

CREATE TABLE "UserRatings" (
    "ObserverId" TEXT NOT NULL,
    "TargetId" TEXT NOT NULL,
    "Feedback" TEXT NULL,
    "RatingValue" TEXT NULL,
    CONSTRAINT "PK_UserRatings" PRIMARY KEY ("ObserverId", "TargetId"),
    CONSTRAINT "FK_UserRatings_AspNetUsers_ObserverId" FOREIGN KEY ("ObserverId") REFERENCES "AspNetUsers" ("Id") ON DELETE CASCADE,
    CONSTRAINT "FK_UserRatings_AspNetUsers_TargetId" FOREIGN KEY ("TargetId") REFERENCES "AspNetUsers" ("Id") ON DELETE CASCADE
);

CREATE INDEX "IX_UserRatings_TargetId" ON "UserRatings" ("TargetId");

CREATE TABLE "ef_temp_UserFollowings" (
    "ObserverId" TEXT NOT NULL,
    "TargetId" TEXT NOT NULL,
    CONSTRAINT "PK_UserFollowings" PRIMARY KEY ("ObserverId", "TargetId"),
    CONSTRAINT "FK_UserFollowings_AspNetUsers_ObserverId" FOREIGN KEY ("ObserverId") REFERENCES "AspNetUsers" ("Id") ON DELETE CASCADE,
    CONSTRAINT "FK_UserFollowings_AspNetUsers_TargetId" FOREIGN KEY ("TargetId") REFERENCES "AspNetUsers" ("Id") ON DELETE CASCADE
);

INSERT INTO "ef_temp_UserFollowings" ("ObserverId", "TargetId")
SELECT "ObserverId", "TargetId"
FROM "UserFollowings";

COMMIT;

PRAGMA foreign_keys = 0;

BEGIN TRANSACTION;

DROP TABLE "UserFollowings";

ALTER TABLE "ef_temp_UserFollowings" RENAME TO "UserFollowings";

COMMIT;

PRAGMA foreign_keys = 1;

BEGIN TRANSACTION;

CREATE INDEX "IX_UserFollowings_TargetId" ON "UserFollowings" ("TargetId");

INSERT INTO "__EFMigrationsHistory" ("MigrationId", "ProductVersion")
VALUES ('20210913115213_RatingAdded', '5.0.8');

COMMIT;

BEGIN TRANSACTION;

ALTER TABLE "Rides" ADD "Baggage" TEXT NULL;

ALTER TABLE "Rides" ADD "BaggageCost" TEXT NULL;

CREATE TABLE "ef_temp_Rides" (
    "Id" TEXT NOT NULL CONSTRAINT "PK_Rides" PRIMARY KEY,
    "Animals" TEXT NULL,
    "Baggage" TEXT NULL,
    "BaggageCost" TEXT NULL,
    "Children" TEXT NULL,
    "Cost" TEXT NULL,
    "Departure" TEXT NULL,
    "Description" TEXT NULL,
    "Destination" TEXT NULL,
    "IsCancelled" INTEGER NOT NULL,
    "Smoking" TEXT NULL,
    "departureDate" TEXT NOT NULL,
    "passengerNumber" TEXT NULL,
    "returnDate" TEXT NOT NULL
);

INSERT INTO "ef_temp_Rides" ("Id", "Animals", "Baggage", "BaggageCost", "Children", "Cost", "Departure", "Description", "Destination", "IsCancelled", "Smoking", "departureDate", "passengerNumber", "returnDate")
SELECT "Id", "Animals", "Baggage", "BaggageCost", "Children", "Cost", "Departure", "Description", "Destination", "IsCancelled", "Smoking", "departureDate", "passengerNumber", "returnDate"
FROM "Rides";

COMMIT;

PRAGMA foreign_keys = 0;

BEGIN TRANSACTION;

DROP TABLE "Rides";

ALTER TABLE "ef_temp_Rides" RENAME TO "Rides";

COMMIT;

PRAGMA foreign_keys = 1;

BEGIN TRANSACTION;

INSERT INTO "__EFMigrationsHistory" ("MigrationId", "ProductVersion")
VALUES ('20210923203631_RideUpdated', '5.0.8');

COMMIT;

