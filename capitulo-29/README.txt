Open the sample Web site by selecting the "Northwind" solution in the "Completed Northwind" folder.

If you have been using Visual C# 2008 Express Edition and have detached the Northwind database from the SQL Server Express instance, in the "Completed Northwind" folder rename the file "Web.config" as "old Web.config", and rename the file "VWD Express Web.config" as "Web.config".

This change is necessary because the "Web.config" file contains a database connection string that assumes that the Northwind database is connected to SQL Server Express. 

The connection string in "VWD Express Web.config" references the database as an attached file.