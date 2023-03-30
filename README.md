# Costbook Exporter

This code can be used to flatten costbook data from the bacpac structure to a single Excel spreadsheet. It uses EF Core to access the database.

The solution consists of 3 projects:
- TNE.Costbooks.Domain. Contains class definition of the costbook data model.
- TNE.Costbooks.EntityFrameworkV2. Defines mappings from the object model to the relational database structure, and the database context to query the database.
- CostbookExport. Implements the actual exporter. The main point of interest in this project is the CostbookExcelExporter class that does all the work.
