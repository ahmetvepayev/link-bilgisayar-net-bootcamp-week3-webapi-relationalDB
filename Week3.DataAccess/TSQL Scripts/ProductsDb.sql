-- DDL (Data Definition Language)
-- Create the database, create the tables and define the relationships between the tables
CREATE DATABASE ProductsDb
GO

USE ProductsDb
GO

CREATE TABLE Categories(
    Id int PRIMARY KEY IDENTITY(1,1),
    Name nvarchar(MAX)
)
GO

CREATE TABLE Products(
    Id int PRIMARY KEY IDENTITY(1,1),
    Name nvarchar(MAX),
    Price decimal(18,2),
    Stock int,
    CategoryId int
)
GO

-- Defining One-to-Many relationship between Categories and Products
-- Set cascading to update dependent tables on modification
ALTER TABLE Products
ADD CONSTRAINT FK_CategoryId FOREIGN KEY (CategoryId) REFERENCES Categories(Id)
ON UPDATE CASCADE
ON DELETE CASCADE
GO

CREATE TABLE ProductFeatures(
    Id int PRIMARY KEY,
    Height int,
    Width int,
    Color nvarchar(15)
)
GO

-- Defining One-to-One relationship between Products and ProductFeatures
-- Set cascading to update dependent tables on modification
ALTER TABLE ProductFeatures
ADD CONSTRAINT FK_ProductId FOREIGN KEY (Id) REFERENCES Products(Id)
ON UPDATE CASCADE
ON DELETE CASCADE
GO

-- DML (Data Manipulation Language)
-- First insert the entries for Categories table since it's the independent table
INSERT Categories Values('Beverages'),
('Cleaning Supplies'),
('Electronics')
GO

-- Insert Products entries since they only depend on Categories
INSERT Products Values('Milk', 12.90, 20, 1),
('Cola', 8.56, 45, 1),
('Bleach', 12.25, 37, 2),
('Sponge', 6.05, 50, 2),
('Phone', 699.99, 10, 3),
('Calculator', 80.00, 25, 3)
GO

-- Insert the ProductFeatures entries since we now have sample Products entries
INSERT ProductFeatures Values(1, 10, 7, 'White'),
(2, 10, 7, 'Brown'),
(3, 12, 8, 'White'),
(4, 5, 6, 'Yellow'),
(5, 7, 4, 'Black'),
(6, 7, 5, 'Silver')
GO

-- Example UPDATE command
UPDATE Products SET Price = 9.15 WHERE Name = 'Cola'
GO

-- Example DELETE command. Will not affect any other table since no other table is dependent on ProductFeatures
DELETE FROM ProductFeatures WHERE Id = (SELECT Id FROM Products WHERE Name = 'Sponge')
GO

-- This DELETE command will also delete all products associated with the deleted category and the features associated with the deleted products
DELETE FROM Categories WHERE Name = 'Electronics'
GO