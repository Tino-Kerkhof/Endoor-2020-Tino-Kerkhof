USE WideWorldImporters
GO

CREATE INDEX IDX_InvoiceDate
ON Sales.Invoices (InvoiceDate)

CREATE INDEX IDX_OrderDate
ON Sales.Orders (OrderDate)
GO