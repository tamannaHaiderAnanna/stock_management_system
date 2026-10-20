-- Stock Management System: database schema
--
-- Rebuilt in October 2026 from the application code; the original 2018 database script was not kept.
-- Table, view and column names match what the code expects.
--
-- Run it on an empty database (SQL Server 2012 or newer; LocalDB is enough):
--   sqlcmd -S "(localdb)\MSSQLLocalDB" -Q "CREATE DATABASE StockManagement"
--   sqlcmd -S "(localdb)\MSSQLLocalDB" -d StockManagement -i StockManagement.sql
--
-- Every table has a single Id primary key. Indexes are plain (non-unique) and each one serves a
-- search the code runs; duplicates are prevented in the code, not by unique constraints.

SET ANSI_NULLS ON;
SET QUOTED_IDENTIFIER ON;
GO

CREATE TABLE Category (
    Id           INT IDENTITY(1,1) NOT NULL CONSTRAINT PK_Category PRIMARY KEY,
    CategoryName NVARCHAR(100) NOT NULL
);

CREATE TABLE Company (
    Id          INT IDENTITY(1,1) NOT NULL CONSTRAINT PK_Company PRIMARY KEY,
    CompanyName NVARCHAR(100) NOT NULL
);

CREATE TABLE Items (
    Id                INT IDENTITY(1,1) NOT NULL CONSTRAINT PK_Items PRIMARY KEY,
    CategoryId        INT NOT NULL CONSTRAINT FK_Items_Category REFERENCES Category (Id),
    CompanyId         INT NOT NULL CONSTRAINT FK_Items_Company REFERENCES Company (Id),
    ItemName          NVARCHAR(100) NOT NULL,
    ReOrderLevel      INT NOT NULL,
    AvailableQuantity INT NOT NULL
);

-- One row per item per stock out (sale, damage or loss).
CREATE TABLE StockOutRecord (
    Id               INT IDENTITY(1,1) NOT NULL CONSTRAINT PK_StockOutRecord PRIMARY KEY,
    ItemId           INT NOT NULL CONSTRAINT FK_StockOutRecord_Items REFERENCES Items (Id),
    CompanyId        INT NOT NULL CONSTRAINT FK_StockOutRecord_Company REFERENCES Company (Id),
    StockOutQuantity INT NOT NULL,
    StockOutType     NVARCHAR(10) NOT NULL,   -- Sell, Damage or Lost
    Date             DATE NOT NULL
);

CREATE INDEX IX_Category_CategoryName ON Category (CategoryName);   -- is this category name taken?
CREATE INDEX IX_Company_CompanyName ON Company (CompanyName);       -- is this company name taken?
CREATE INDEX IX_Items_ItemName ON Items (ItemName);                 -- is this item name taken?
CREATE INDEX IX_Items_CompanyId ON Items (CompanyId);               -- items of a company
CREATE INDEX IX_Items_CategoryId ON Items (CategoryId);             -- items of a category
CREATE INDEX IX_StockOutRecord_Date ON StockOutRecord (Date);       -- sales report between two dates
GO

-- Items with their company and category names (stock in, stock out, search pages).
CREATE VIEW ItemsView AS
SELECT i.Id,
       i.ItemName,
       i.CompanyId,
       c.CompanyName,
       i.CategoryId,
       ca.CategoryName,
       i.AvailableQuantity,
       i.ReOrderLevel
FROM Items i
JOIN Company c ON c.Id = i.CompanyId
JOIN Category ca ON ca.Id = i.CategoryId;
GO

-- Stock outs with the item and company names (sales report).
CREATE VIEW StockOutView AS
SELECT s.Id,
       s.ItemId,
       i.ItemName,
       s.CompanyId,
       c.CompanyName,
       s.StockOutQuantity,
       s.StockOutType,
       s.Date
FROM StockOutRecord s
JOIN Items i ON i.Id = s.ItemId
JOIN Company c ON c.Id = s.CompanyId;
GO
