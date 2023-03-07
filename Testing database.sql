use AdventureWorksDW2019
select EmployeePhoto, FirstName, LastName, Title, City, SalesTerritoryCountry, Phone
from DimEmployee
join DimGeography
on DimGeography.SalesTerritoryKey = DimEmployee.SalesTerritoryKey
join DimSalesTerritory
on DimSalesTerritory.SalesTerritoryKey = DimEmployee.SalesTerritoryKey
/*
select *
from DimEmployee

select *
from DimCustomer



Created a view after confirming tutorial's instructions:


create or alter view dboEmployeeData
as
select EmployeePhoto, FirstName, LastName, Title, City, SalesTerritoryCountry, Phone
from DimEmployee
join DimGeography
on DimGeography.SalesTerritoryKey = DimEmployee.SalesTerritoryKey
join DimSalesTerritory
on DimSalesTerritory.SalesTerritoryKey = DimEmployee.SalesTerritoryKey

select * from dboEmployeeData
*/