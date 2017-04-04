If you are using Visual C# 2008 Express Edition, detach the Northwind database from SQL Server by running the following command from the command prompt window:

sqlcmd -S.\SQLExpress -E -idetach.sql

If you have detached the Northwind database from the SQL Server Express instance, in the "Completed Suppliers\Suppliers" folder rename the file "app.config" as "old app.config", and rename the file "VC# Express app.config" as "app.config".

This change is necessary because the "app.config" file contains a database connection string that assumes that the Northwind database is connected to SQL Server Express. 

The connection string in "VC# Express app.config" references the database as an attached file.