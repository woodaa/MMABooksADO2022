using MySql.Data.MySqlClient;
using System.Data;
using MMABooksBusinessClasses;

namespace MMABooksDBClasses {
    public static class CustomerDB {
        public static Customer? GetCustomer(int customerID) {
            MySqlConnection connection = MMABooksDB.GetConnection();
            string selectStatement
                = "SELECT CustomerID, Name, Address, City, State, ZipCode "
                + "FROM Customers "
                + "WHERE CustomerID = @CustomerID";
            MySqlCommand selectCommand = new(selectStatement, connection);
            selectCommand.Parameters.AddWithValue("@CustomerID", customerID);
            try {
                connection.Open();
                MySqlDataReader custReader = selectCommand.ExecuteReader(CommandBehavior.SingleRow);
                if (custReader.Read()) {
                    Customer customer = new() {
                        CustomerID = (int)custReader["CustomerID"],
                        Name = custReader["Name"].ToString(),
                        Address = custReader["Address"].ToString(),
                        City = custReader["City"].ToString(),
                        State = custReader["State"].ToString(),
                        ZipCode = custReader["ZipCode"].ToString()
                    };
                    return customer;
                } else return null;
            } catch (MySqlException ex) { throw ex; } finally { connection.Close(); }
        }

        public static int AddCustomer(Customer customer) {
            MySqlConnection connection = MMABooksDB.GetConnection();
            string insertStatement =
                "INSERT Customers " +
                "(Name, Address, City, State, ZipCode) " +
                "VALUES (@Name, @Address, @City, @State, @ZipCode)";
            MySqlCommand insertCommand = new(insertStatement, connection);
            insertCommand.Parameters.AddWithValue("@Name", customer.Name);
            insertCommand.Parameters.AddWithValue("@Address", customer.Address);
            insertCommand.Parameters.AddWithValue("@City", customer.City);
            insertCommand.Parameters.AddWithValue("@State", customer.State);
            insertCommand.Parameters.AddWithValue("@ZipCode", customer.ZipCode);
            try {
                connection.Open();
                insertCommand.ExecuteNonQuery();
                string selectStatement = "SELECT LAST_INSERT_ID()";
                MySqlCommand selectCommand = new(selectStatement, connection);
                int customerID = Convert.ToInt32(selectCommand.ExecuteScalar());
                return customerID;
            } catch (MySqlException ex) { throw ex; } finally { connection.Close(); }
        }

        public static bool DeleteCustomer(Customer customer) {
            MySqlConnection connection = MMABooksDB.GetConnection();
            string deleteStatement =
                "DELETE FROM Customers " +
                "WHERE CustomerID = @CustomerID " +
                "AND Name = @Name " +
                "AND Address = @Address " +
                "AND City = @City " +
                "AND State = @State " +
                "AND ZipCode = @ZipCode";
            MySqlCommand deleteCommand = new(deleteStatement, connection);
            deleteCommand.Parameters.AddWithValue("@CustomerID", customer.CustomerID);
            deleteCommand.Parameters.AddWithValue("@Name", customer.Name);
            deleteCommand.Parameters.AddWithValue("@Address", customer.Address);
            deleteCommand.Parameters.AddWithValue("@City", customer.City);
            deleteCommand.Parameters.AddWithValue("@State", customer.State);
            deleteCommand.Parameters.AddWithValue("@ZipCode", customer.ZipCode);
            try {
                connection.Open();
                deleteCommand.ExecuteNonQuery();
                string selectStatement = "SELECT LAST_INSERT_ID()";
                MySqlCommand selectCommand = new(selectStatement, connection);
                int customerID = Convert.ToInt32(deleteCommand.ExecuteScalar());
                if (customerID == 1) return true;
            } catch (MySqlException ex) { throw ex; } finally { connection.Close(); }

            return false;
        }

        public static bool UpdateCustomer(Customer oldCustomer, Customer newCustomer) {
            MySqlConnection connection = MMABooksDB.GetConnection();
            string updateStatement =
                "UPDATE Customers SET " +
                "Name = @NewName, " +
                "Address = @NewAddress, " +
                "City = @NewCity, " +
                "State = @NewState, " +
                "ZipCode = @NewZipCode " +
                "WHERE CustomerID = @OldCustomerID " +
                "AND Name = @OldName " +
                "AND Address = @OldAddress " +
                "AND City = @OldCity " +
                "AND State = @OldState " +
                "AND ZipCode = @OldZipCode";
            MySqlCommand updateCommand = new(updateStatement, connection);
            // New customer
            updateCommand.Parameters.AddWithValue("@NewName", newCustomer.Name);
            updateCommand.Parameters.AddWithValue("@NewAddress", newCustomer.Address);
            updateCommand.Parameters.AddWithValue("@NewCity", newCustomer.City);
            updateCommand.Parameters.AddWithValue("@NewState", newCustomer.State);
            updateCommand.Parameters.AddWithValue("@NewZipCode", newCustomer.ZipCode);
            // Old customer
            updateCommand.Parameters.AddWithValue("@OldCustomerID", oldCustomer.CustomerID);
            updateCommand.Parameters.AddWithValue("@OldName", oldCustomer.Name);
            updateCommand.Parameters.AddWithValue("@OldAddress", oldCustomer.Address);
            updateCommand.Parameters.AddWithValue("@OldCity", oldCustomer.City);
            updateCommand.Parameters.AddWithValue("@OldState", oldCustomer.State);
            updateCommand.Parameters.AddWithValue("@OldZipCode", oldCustomer.ZipCode);
            try {
                connection.Open();
                updateCommand.ExecuteNonQuery();
                string selectStatement = "SELECT LAST_INSERT_ID()";
                MySqlCommand selectCommand = new(selectStatement, connection);
                int customerID = Convert.ToInt32(updateCommand.ExecuteScalar());
                if (customerID == 1) return true;
            } catch (MySqlException ex) { throw ex; } finally { connection.Close(); }
            return false;
        }
    }
}
