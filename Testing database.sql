use AdventureWorksDW2019

create or alter view dboEmployeeData
as
select EmployeePhoto, FirstName, LastName, Title, City, SalesTerritoryCountry, Phone
from DimEmployee
join DimGeography
on DimGeography.SalesTerritoryKey = DimEmployee.SalesTerritoryKey
join DimSalesTerritory
on DimSalesTerritory.SalesTerritoryKey = DimEmployee.SalesTerritoryKey

select * from dboEmployeeData



/* Correct Formatting:


from p in ctx.Persons
where p.ID == personId
join bornIn in ctx.Cities
on p.BornIn equals bornIn.CityID
join livesIn in ctx.Cities
on p.LivesIn equals livesIn.CityID
join s in ctx.Sexes
on p.SexID equals s.ID
select new PersonInfo
{
    Name = p.FirstName + " " + p.LastName,
    BornIn = bornIn.Name,
    LivesIn = livesIn.Name,
    Gender = s.Name,
    CarsOwnedCount = ctx.Cars.Where(c =&gt; c.OwnerID == p.ID).Count()
}





Backup OG:

use AdventureWorksDW2019
select EmployeePhoto, FirstName, LastName, Title, City, SalesTerritoryCountry, Phone
from DimEmployee
join DimGeography
on DimGeography.SalesTerritoryKey = DimEmployee.SalesTerritoryKey
join DimSalesTerritory
on DimSalesTerritory.SalesTerritoryKey = DimEmployee.SalesTerritoryKey

*/



/*
select *
from DimEmployee

select *
from DimCustomer



*/