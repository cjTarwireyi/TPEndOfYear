using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI.WebControls;
using BusineesLogic.Interface;

/// <summary>
/// Summary description for ProductDAO
/// </summary>
public class ProductDAO : IProduct
{
    
    private SqlConnection con;
    public ProductDAO()
    {
        con = new SqlConnection(ConfigurationManager.ConnectionStrings["AdminBookingConnectionString"].ConnectionString);
    }

    public void save(Products product)
    {
        con.Open();
        SqlCommand cmd = con.CreateCommand();
        cmd.CommandType = CommandType.Text;
        cmd.CommandText = "insert into Products([ProductName], [ProductDescription], [Quantity],[Price], [Active],[DateArrived],[SupplierID])values('" + product.productName + "','" + product.productDescription + "','" + product.productQuantity + "','" + product.price + "','" + product.productStatus + "','" + product.dateArrived + "','" + product.productSupplierID + "')";
        cmd.ExecuteNonQuery();
        con.Close();
    }


    public Products makeProductDTO(SqlDataReader myDR)
    {
        Products product = new Products.ProductsBuilder()
        .prodNumber(myDR.GetInt32(0))
        .prodName(myDR.GetString(1))
        .prodDescription(myDR.GetString(2))
        .prodPrice(myDR.GetDecimal(3))
        .prodQuantity(myDR.GetInt32(4))
        .prodStatus(myDR.GetBoolean(5))
        .prodSupplierID(myDR.GetInt32(7))
        .build();
        return product;

    }

    public Products getProduct(int id)
    {
        con.Open();
        String selectProduct = "select * from Products where Id =" + id + " ";
        SqlCommand myComm = new SqlCommand(selectProduct, con);
        SqlDataReader myDR;
        myDR = myComm.ExecuteReader();
        if (!myDR.Read())
            return null;
        Products updateProduct = makeProductDTO(myDR);
        con.Close();
        return updateProduct;
    }
    //decreases quantint when Item is purchased
    public void updateQuantity(int prodId, int qty)
    {
        int dbQty = getItemQuantity(prodId.ToString());
        dbQty -= qty;
        qutyUpdaeHelper(dbQty, prodId);
    }


    public void itemBought(string productID, string quantity, string opr)
    {
        string oriQuantity = "";
        int newQuantity = 0;
        DataTable productQuantity = new DataTable();
        con.Open();
        string getQuantity = "select quantity from products where id ='" + productID + "' ";
        SqlCommand cmd = new SqlCommand(getQuantity, con);
        SqlDataAdapter da = new SqlDataAdapter(cmd);
        da.Fill(productQuantity);
        da.Dispose();
        foreach (DataRow row in productQuantity.Rows)
        {
            oriQuantity = row["Quantity"].ToString();
        }
        newQuantity = Convert.ToInt32(oriQuantity) - Convert.ToInt32(quantity);
        con.Close();
        qutyUpdaeHelper(newQuantity, Convert.ToInt32(productID));
    }

    private void qutyUpdaeHelper(int newQuantity, int productID)
    {
        con.Open();
        string updateQuery = "update products set quantity = '" + newQuantity + "' where id ='" + productID + "' ";
        SqlCommand cmd = new SqlCommand(updateQuery, con);
        cmd.ExecuteNonQuery();
        con.Close();

    }
    public int getItemQuantity(string id)
    {
        int quantity = 0;
        DataTable prodQuantity = new DataTable();
        con.Open();
        string query = "select quantity from products where id = '" + id + "' ";
        SqlCommand cmd = new SqlCommand(query, con);
        SqlDataAdapter da = new SqlDataAdapter(cmd);
        da.Fill(prodQuantity);
        da.Dispose();
        foreach (DataRow row in prodQuantity.Rows)
        {
            quantity = Convert.ToInt32(row["Quantity"].ToString());
        }
        cmd.ExecuteNonQuery();
        con.Close();
        return quantity;
    }

    public DataTable populateGrid()
    {
        DataTable products = new DataTable();
        bool status = true;
        string query = "select * from products where active ='" + status + "' order by id DESC ";
        con.Open();
        SqlCommand cmd = new SqlCommand(query, con);
        SqlDataAdapter da = new SqlDataAdapter(cmd);
        da.Fill(products);
        da.Dispose();
        con.Close();
        return products;
    }

    public DataTable populateInactiveProducts()
    {
        DataTable products = new DataTable();
        bool status = false;
        string query = "select * from products where active ='" + status + "' order by id DESC";
        con.Open();
        SqlCommand cmd = new SqlCommand(query, con);
        SqlDataAdapter da = new SqlDataAdapter(cmd);
        da.Fill(products);
        da.Dispose();
        con.Close();
        return products;
    }

    public SqlDataReader loadSuppliers()
    {
        con.Open();
        String strCustomers = "Select supplierID from Suppliers";
        SqlCommand cmd = new SqlCommand(strCustomers, con);
        SqlDataReader reader = cmd.ExecuteReader();
        return reader;
    }

    public void connectionClosed()
    {
        con.Close();
    }

    public void updateProductStatus(string id, bool state)
    {
        con.Open();
        SqlCommand cmd;
        String query;
        if (state == true)
        {
            query = "update Products set Active ='True' where Id ='" + Convert.ToInt32(id) + "'";
            cmd = new SqlCommand(query, con);
        }
        else
        {
            query = "update Products set Active ='False' where Id ='" + Convert.ToInt32(id) + "'";
            cmd = new SqlCommand(query, con);
        }
        cmd.ExecuteNonQuery();
        con.Close();
    }

    public void delete(string id)
    {
        con.Open();
        SqlCommand cmd = con.CreateCommand();
        cmd.CommandType = CommandType.Text;
        cmd.CommandText = "delete from products where id = '" + id + "' ";
        cmd.ExecuteNonQuery();
        con.Close();
    }

    public void update(string id, List<string> productDetails)
    {
        con.Open();
        SqlCommand cmd = con.CreateCommand();
        cmd.CommandType = CommandType.Text;
        cmd.CommandText = "update products set productName ='" + productDetails[0] + "', productDescription='" + productDetails[1] + "',price='" + productDetails[2] + "',Quantity='" + productDetails[3] + "',supplierID='" + productDetails[4] + "' where id = '" + id + "' ";
        cmd.ExecuteNonQuery();
        con.Close();
    }

    public DataTable mostSoldProducts()
    {
        DataTable products = new DataTable();
        string query = @"select products.Id,products.ProductName, sum(OrderLine.Quantity) as [Number Of Times Sold]
                        from orderline 
                        inner join Products
                        on orderline.ProductID = Products.Id
						inner join orders 
						on orderline.OrderID = orders.orderId
						where orders.active = 'true'
                        group by products.id ,Products.ProductName";
        con.Open();
        SqlCommand cmd = new SqlCommand(query, con);
        SqlDataAdapter da = new SqlDataAdapter(cmd);
        da.Fill(products);
        da.Dispose();
        con.Close();
        return products;
    }


    public DataTable mostReturnedProducts()
    {
        DataTable products = new DataTable();
        string query = @"select products.Id,products.ProductName, sum(Returns.Quantity) as [Number Of Times Returned]
                        from orders 
                        inner join returns
                        on orders.orderId = returns.OrderID
                        inner join orderline 
                        on Returns.OrderID = OrderLine.OrderID
                        inner join Products
                        on orderline.ProductID = Products.Id
                        where orders.active = 'true'
                        group by products.id ,Products.ProductName";
        con.Open();
        SqlCommand cmd = new SqlCommand(query, con);
        SqlDataAdapter da = new SqlDataAdapter(cmd);
        da.Fill(products);
        da.Dispose();
        con.Close();
        return products;
    }

    public DataTable monthlyAmount(string year,bool amountDueOrMade)
    {
        DataTable products = new DataTable();
        string query = "";
        query = @"select  datename(MONTH,dateadd(mm,datediff(mm,0,orders.orderdate),0)) as [Month Name] ,sum(orders.amount) as [Amount]
                  from orders
                  where year(orders.orderdate) = '"+year+"' and orders.payed = '"+amountDueOrMade +"' and orders.active = 'true' group by dateadd(mm,datediff(mm,0,orders.orderdate),0) order by dateadd(mm,datediff(mm,0,orders.orderdate),0)";
        con.Open();
        SqlCommand cmd = new SqlCommand(query, con);
        SqlDataAdapter da = new SqlDataAdapter(cmd);
        da.Fill(products);
        da.Dispose();
        con.Close();
        return products;
    }


    public DataTable generateCustomersOrderHistory(bool paid)
    {
        DataTable customer = new DataTable();
        string query = "";
        query = @"select customers.CustomerName as [NAME],customers.CustomerSurname as [SURNAME],count(orders.orderId) as [NUMBER OF ORDERS PAID],sum(orders.totalAmount)as [TOTAL AMOUNT]
                  from customers
                  inner join orders
                  on customers.CustomerID = orders.custId
                  where orders.payed = '"+paid+"' and orders.active ='true' group by customers.CustomerID,customers.CustomerName,customers.CustomerSurname order by customers.CustomerID";
        con.Open();
        SqlCommand cmd = new SqlCommand(query, con);
        SqlDataAdapter da = new SqlDataAdapter(cmd);
        da.Fill(customer);
        da.Dispose();
        con.Close();
        return customer;
    }

       public DataTable loadNotification()
    {
        DataTable customers = new DataTable();
        string query = "select id, ProductName, price, quantity from products where Quantity < 10";
        con.Open();
        SqlCommand cmd = new SqlCommand(query, con);
        SqlDataAdapter da = new SqlDataAdapter(cmd);
        da.Fill(customers);
        da.Dispose();
        con.Close();
        return customers;
    }
}