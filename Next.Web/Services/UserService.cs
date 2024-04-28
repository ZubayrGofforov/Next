using Next.Web.Interfaces;
using Next.Web.Models;
using Next.Web.Models.Common;
using Oracle.ManagedDataAccess.Client;

namespace Next.Web.Services;
public class UserService : IUserService
{
    private readonly string _connectionString;
    public UserService(IConfiguration configuration)
    {
        this._connectionString = configuration.GetConnectionString("OracleDBConnection");
    }

    public void AddUser(User user)
    {
        try
        {
            using (OracleConnection con = new OracleConnection(_connectionString))
            {
                using (OracleCommand cmd = new OracleCommand())
                {
                    con.Open();
                    cmd.CommandText = "INSERT INTO Users(Id, FirstName, LastName, PhoneNumber, Email, UserRole, CreatedAt)" +
                        "Values(" + user.Id + ",'" + user.FristName + ",'" + user.LastName + ",'" + user.PhoneNumber + ",'" + user.Email + ",'" + user.UserRole + ",'" + user.CreatedAt + "')";
                    cmd.ExecuteNonQuery();
                }
            }
        }
        catch (Exception)
        {

            throw;
        }
    }

    public void DeleteUser(User user)
    {
        try
        {
            using (OracleConnection con = new OracleConnection(_connectionString))
            {
                using (OracleCommand cmd = new OracleCommand())
                {
                    con.Open();
                    cmd.CommandText = "Delete from Users where Id="+user.Id+"";
                    cmd.ExecuteNonQuery();
                }
            }
        }
        catch (Exception)
        {

            throw;
        }
    }

    public IEnumerable<User> GetAllUser()
    {
        List<User> users = new List<User>();

        using (OracleConnection con = new OracleConnection(_connectionString))
        {
            using (OracleCommand cmd = new OracleCommand())
            {
                con.Open();
                cmd.BindByName = true;
                cmd.CommandText = "Select Id, FirstName, LastName, PhoneNumber, Email, UserRole from Users";
                OracleDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    var user = new User
                    {
                        Id = (Guid)reader["Id"],
                        FristName = (string)reader["FirstName"],
                        LastName = (string)reader["LastName"],
                        PhoneNumber = (string)reader["PhoneNumber"],
                        Email = (string)reader["Email"],
                        UserRole = (UserRole)reader["UserRole"]
                    };
                    users.Add(user);
                }
            }
        }
        return users;
    }

    public User GetById(Guid id)
    {
        User user = new User();
        using (OracleConnection con = new OracleConnection(_connectionString))
        {
            using (OracleCommand cmd = new OracleCommand())
            {
                con.Open();
                cmd.BindByName = true;
                cmd.CommandText = "Select Id, FirstName, LastName, PhoneNumber, Email, UserRole, CreatedAt from Users Where Id="+ id +"";
                OracleDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    user.Id = (Guid)reader["Id"];
                    user.FristName = (string)reader["FirstName"];
                    user.LastName = (string)reader["LastName"];
                    user.PhoneNumber = (string)reader["PhoneNumber"];
                    user.Email = (string)reader["Email"];
                    user.UserRole = (UserRole)reader["UserRole"];
                    user.CreatedAt = (DateTime)reader["CreatedAt"];
                }
            }
        }
        return user;
    }

    public void UpdateUser(User user)
    {
        try
        {
            using (OracleConnection con = new OracleConnection(_connectionString))
            {
                using (OracleCommand cmd = new OracleCommand())
                {
                    con.Open();
                    cmd.CommandText = "Update Users Set FirstName='"+user.FristName+"', LastName='"+user.LastName+"', PhoneNumber='"+user.PhoneNumber+"'";
                    cmd.ExecuteNonQuery();
                }
            }
        }
        catch (Exception)
        {

            throw;
        }
    }
}
