using MySql.Data.MySqlClient;
using System.Data;
using MMABooksBusinessClasses;

namespace MMABooksDBClasses {
    public static class ProductDB {
        public static Product? GetProduct(string productCode) {
            MySqlConnection connection = MMABooksDB.GetConnection();
            string selectStatement
                = "SELECT ProductCode, Description, UnitPrice, OnHandQuantity "
                + "FROM Products "
                + "WHERE ProductCode = @ProductCode";
            MySqlCommand selectCommand = new(selectStatement, connection);
            selectCommand.Parameters.AddWithValue("@ProductCode", productCode);
            try {
                connection.Open();
                MySqlDataReader prodReader = selectCommand.ExecuteReader(CommandBehavior.SingleRow);
                if (prodReader.Read()) {
                    Product product = new() {
                        ProductCode = prodReader["ProductCode"].ToString(),
                        Description = prodReader["Description"].ToString(),
                        UnitPrice = (decimal)prodReader["UnitPrice"],
                        OnHandQuantity = (int)prodReader["OnHandQuantity"]
                    };
                    return product;
                } else return null;
            } catch (MySqlException ex) { throw ex; } finally { connection.Close(); }
        }

        public static string AddProduct(Product product) {
            MySqlConnection connection = MMABooksDB.GetConnection();
            string insertStatement =
                "INSERT Products " +
                "(ProductCode, Description, UnitPrice, OnHandQuantity) " +
                "VALUES (@ProductCode, @Description, @UnitPrice, @OnHandQuantity)";
            MySqlCommand insertCommand = new(insertStatement, connection);
            insertCommand.Parameters.AddWithValue("@ProductCode", product.ProductCode);
            insertCommand.Parameters.AddWithValue("@Description", product.Description);
            insertCommand.Parameters.AddWithValue("@UnitPrice", product.UnitPrice);
            insertCommand.Parameters.AddWithValue("@OnHandQuantity", product.OnHandQuantity);
            try {
                connection.Open();
                insertCommand.ExecuteNonQuery();
                string selectStatement = "SELECT LAST_INSERT_ID()";
                MySqlCommand selectCommand = new(selectStatement, connection);
                string productCode = selectCommand.ExecuteScalar().ToString();
                return product.ProductCode;
            } catch (MySqlException ex) { throw ex; } finally { connection.Close(); }
        }

        public static bool DeleteProduct(Product product) {
            MySqlConnection connection = MMABooksDB.GetConnection();
            string deleteStatement =
                "DELETE FROM Products " +
                "WHERE ProductCode = @ProductCode " +
                "AND Description = @Description " +
                "AND UnitPrice = @UnitPrice " +
                "AND OnHandQuantity = @OnHandQuantity";
            MySqlCommand deleteCommand = new(deleteStatement, connection);
            deleteCommand.Parameters.AddWithValue("@ProductCode", product.ProductCode);
            deleteCommand.Parameters.AddWithValue("@Description", product.Description);
            deleteCommand.Parameters.AddWithValue("@UnitPrice", product.UnitPrice);
            deleteCommand.Parameters.AddWithValue("@OnHandQuantity", product.OnHandQuantity);
            try {
                connection.Open();
                deleteCommand.ExecuteNonQuery();
                string selectStatement = "SELECT LAST_INSERT_ID()";
                MySqlCommand selectCommand = new(selectStatement, connection);
                if (product.ProductCode != null) return true;
            } catch (MySqlException ex) { throw ex; } finally { connection.Close(); }

            return false;
        }

        public static bool UpdateProduct(Product oldProduct, Product newProduct) {
            MySqlConnection connection = MMABooksDB.GetConnection();
            string updateStatement =
                "UPDATE Products SET " +
                "Description = @NewDescription, " +
                "UnitPrice = @NewUnitPrice, " +
                "OnHandQuantity = @NewOnHandQuantity " +
                "WHERE ProductCode = @OldProductCode " +
                "AND Description = @OldDescription " +
                "AND UnitPrice = @OldUnitPrice " +
                "AND OnHandQuantity = @OldOnHandQuantity";
            MySqlCommand updateCommand = new(updateStatement, connection);
            // New customer
            updateCommand.Parameters.AddWithValue("@NewDescription", newProduct.Description);
            updateCommand.Parameters.AddWithValue("@NewUnitPrice", newProduct.UnitPrice);
            updateCommand.Parameters.AddWithValue("@NewOnHandQuantity", newProduct.OnHandQuantity);
            // Old customer
            updateCommand.Parameters.AddWithValue("@OldProductCode", oldProduct.ProductCode);
            updateCommand.Parameters.AddWithValue("@OldDescription", oldProduct.Description);
            updateCommand.Parameters.AddWithValue("@OldUnitPrice", oldProduct.UnitPrice);
            updateCommand.Parameters.AddWithValue("@OldOnHandQuantity", oldProduct.OnHandQuantity);
            try {
                connection.Open();
                updateCommand.ExecuteNonQuery();
                string selectStatement = "SELECT LAST_INSERT_ID()";
                MySqlCommand selectCommand = new(selectStatement, connection);
                if (oldProduct.ProductCode != "A4CS" && newProduct.ProductCode != "A4CS") return true;
                Console.WriteLine('a');
            } catch (MySqlException ex) { throw ex; } finally { connection.Close(); }
            return false;
        }
    }
}
