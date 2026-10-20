-- Stock Management System: demo data (made-up names)
--
-- Run it after StockManagement.sql. It can be run again at any time to reset a demo: it deletes
-- everything and adds the demo set again, all in one transaction. The stock outs are dated in the last
-- three weeks, so the sales report (1 January to today by default) shows them.
--   sqlcmd -S "(localdb)\MSSQLLocalDB" -d StockManagement -i DemoData.sql

SET NOCOUNT ON;
SET XACT_ABORT ON;
BEGIN TRANSACTION;

DELETE FROM StockOutRecord;
DELETE FROM Items;
DELETE FROM Company;
DELETE FROM Category;

INSERT INTO Category (CategoryName) VALUES (N'Stationery'), (N'Electronics'), (N'Groceries'), (N'Cleaning Supplies');
INSERT INTO Company (CompanyName) VALUES (N'Alpha Traders'), (N'Beta Supplies'), (N'Gamma Electronics');

-- AvailableQuantity is the stock left after the stock outs below. LED Bulb is under its reorder level.
INSERT INTO Items (CategoryId, CompanyId, ItemName, ReOrderLevel, AvailableQuantity)
SELECT ca.Id, co.Id, i.ItemName, i.ReOrderLevel, i.AvailableQuantity
FROM (VALUES
    (N'Notebook',      N'Stationery',        N'Alpha Traders',     20, 120),
    (N'Ballpoint Pen', N'Stationery',        N'Alpha Traders',     50, 300),
    (N'Stapler',       N'Stationery',        N'Beta Supplies',      5,  18),
    (N'A4 Paper',      N'Stationery',        N'Beta Supplies',     10,  45),
    (N'USB Cable',     N'Electronics',       N'Gamma Electronics', 10,  60),
    (N'LED Bulb',      N'Electronics',       N'Gamma Electronics', 15,   8),
    (N'Rice 5kg',      N'Groceries',         N'Alpha Traders',     10,  35),
    (N'Detergent',     N'Cleaning Supplies', N'Beta Supplies',      8,  25)
) AS i (ItemName, CategoryName, CompanyName, ReOrderLevel, AvailableQuantity)
JOIN Category ca ON ca.CategoryName = i.CategoryName
JOIN Company co ON co.CompanyName = i.CompanyName;

-- Stock outs over the last three weeks: item, days ago, quantity, type.
INSERT INTO StockOutRecord (ItemId, CompanyId, StockOutQuantity, StockOutType, Date)
SELECT it.Id, it.CompanyId, s.Quantity, s.StockOutType, DATEADD(DAY, -s.DaysAgo, CAST(GETDATE() AS DATE))
FROM (VALUES
    (N'Notebook',      20, 15, N'Sell'),
    (N'Ballpoint Pen', 18, 40, N'Sell'),
    (N'Notebook',      12, 10, N'Sell'),
    (N'USB Cable',     10,  6, N'Sell'),
    (N'LED Bulb',       9, 12, N'Sell'),
    (N'Rice 5kg',       7,  5, N'Sell'),
    (N'Ballpoint Pen',  5, 25, N'Sell'),
    (N'A4 Paper',       4,  8, N'Sell'),
    (N'Stapler',        3,  2, N'Damage'),
    (N'LED Bulb',       2,  3, N'Damage'),
    (N'Detergent',      2,  1, N'Lost'),
    (N'Notebook',       1,  5, N'Sell')
) AS s (ItemName, DaysAgo, Quantity, StockOutType)
JOIN Items it ON it.ItemName = s.ItemName;

COMMIT;
