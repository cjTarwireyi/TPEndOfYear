select top 10 products.Id,products.ProductName, sum(OrderLine.Quantity) as [Number Of Times Sold]
                        from orderline 
                        inner join Products
                        on orderline.ProductID = Products.Id
                        group by products.id ,Products.ProductName



						select orders.orderId AS ORDER_ID ,orderline.ProductID AS PRODUCT_ID,Products.ProductName AS PRODUCT_NAME,orderline.OrderLineID,orderline.Quantity as [Quantity]
                             from customers
                             inner join orders
                             on customers.CustomerID = Orders.custId
                             inner join orderline
                             on orders.orderId = orderline.OrderID
                             inner join Products
                             on orderline.ProductID = Products.Id
                             where orders.orderId = 103 and customers.CustomerID = 18 and orders.active = 'True' ;




							 select * from orderline where orderid = 109











select orderline.OrderID,orderline.OrderLineID,products.Id,products.ProductName,orderline.Quantity,customers.CustomerID
from products
inner join orderline
on products.Id = orderline.ProductID
inner join orders
on  orderline.OrderID = orders.orderId
inner join Customers
on orders.custId = customers.CustomerID
where orderline.OrderID = @id
order by orderline.OrderID

