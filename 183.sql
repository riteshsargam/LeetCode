SELECT C.name Customers
FROM Customers C
WHERE id NOT IN (SELECT customerId FROM Orders)
