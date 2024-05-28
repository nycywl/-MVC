-- 創建 LOLIllustratedBook 資料庫
CREATE DATABASE LOLIllustratedBook;
GO

-- 使用 LOLIllustratedBook 資料庫
USE LOLIllustratedBook;
GO

-- 創建 Champion 表
CREATE TABLE Champion (
    Id NVARCHAR(50) NOT NULL PRIMARY KEY,
    KeyName NVARCHAR(50) NOT NULL,
    Name NVARCHAR(100) NOT NULL,
    Title NVARCHAR(100) NOT NULL,
    Lore NVARCHAR(MAX) NOT NULL,
    Blurb NVARCHAR(MAX) NOT NULL,
    Allytips NVARCHAR(MAX) NOT NULL,
    Enemytips NVARCHAR(MAX) NOT NULL,
    Tags NVARCHAR(MAX) NOT NULL,
    Partype NVARCHAR(50) NOT NULL
);

-- 創建 Info 表
CREATE TABLE Info (
    Id NVARCHAR(50) NOT NULL PRIMARY KEY,
    Attack INT NOT NULL,
    Defense INT NOT NULL,
    Magic INT NOT NULL,
    Difficulty INT NOT NULL
);

-- 創建 Stats 表
CREATE TABLE States (
    Id NVARCHAR(50) NOT NULL PRIMARY KEY,
    Hp FLOAT NOT NULL,
    Hpperlevel FLOAT NOT NULL,
    Mp FLOAT NOT NULL,
    Mpperlevel FLOAT NOT NULL,
    Movespeed FLOAT NOT NULL,
    Armor FLOAT NOT NULL,
    Armorperlevel FLOAT NOT NULL,
    Spellblock FLOAT NOT NULL,
    Spellblockperlevel FLOAT NOT NULL,
    Attackrange FLOAT NOT NULL,
    Hpregen FLOAT NOT NULL,
    Hpregenperlevel FLOAT NOT NULL,
    Mpregen FLOAT NOT NULL,
    Mpregenperlevel FLOAT NOT NULL,
    Crit FLOAT NOT NULL,
    Critperlevel FLOAT NOT NULL,
    Attackdamage FLOAT NOT NULL,
    Attackdamageperlevel FLOAT NOT NULL,
    Attackspeedperlevel FLOAT NOT NULL,
    Attackspeed FLOAT NOT NULL
);

-- 創建 Spell 表
CREATE TABLE Spell (
    Guid UNIQUEIDENTIFIER NOT NULL PRIMARY KEY,
    Id NVARCHAR(50) NOT NULL,
    ImageId NVARCHAR(50) NOT NULL,
    Name NVARCHAR(100) NOT NULL,
    Description NVARCHAR(MAX) NOT NULL
);