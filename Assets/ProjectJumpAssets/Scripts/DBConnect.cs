using UnityEngine;
using System.Collections.Generic; //list
using Mono.Data.Sqlite;
using System.Data; //connecting to database
using System;//datetime
using System.IO;

public class DBConnect : MonoBehaviour{

    public static List<DateTime> getHighScores()
    {
        Debug.Log("hs");
        List<DateTime> times = new List<DateTime>();
        string path = Application.persistentDataPath + "/Assets/Database.s3db"; //Path to database.
        Debug.Log(path + "                ");
        if (File.Exists(path))
        {
            Debug.Log("Exists");
            string conn = "URI=file:" + path;
            IDbConnection dbconn;
            dbconn = (IDbConnection)new SqliteConnection(conn);//creating connection to sqllite database
            dbconn.Open(); //Open connection to the database.
            string sqlQuery;
            IDbCommand dbcmd = dbconn.CreateCommand();
            sqlQuery = "CREATE TABLE IF NOT EXISTS HighScores(RunTime DATETIME)";
            dbcmd.CommandText = sqlQuery; //puts query we want to execute into dbcmd
            dbcmd.ExecuteNonQuery();
            sqlQuery = "SELECT * " + "FROM HighScores";
            dbcmd.CommandText = sqlQuery; //puts query we want to execute in
            IDataReader reader = dbcmd.ExecuteReader(); //executes query
           /* sqlQuery = "SELECT * " + "FROM HighScores";
            dbcmd.CommandText = sqlQuery; //puts query we want to execute into dbcmd
            reader = dbcmd.ExecuteReader(); //executes query*/

            DateTime value;
            while (reader.Read())
            {
                value = reader.GetDateTime(0); //passing 0 as we are reading from first column in 
                times.Add(value);
            }
            reader.Close();
            reader = null;
            dbcmd.Dispose();
            dbcmd = null;
            dbconn.Close();
            dbconn = null;
            times.Sort();
        }
        return times;
    }

    public static void write(String toBeAdded) //used when there are less than 5 highscores in the database, so score is added without one being removed
    {
        Debug.Log("Write");
        string path = Application.persistentDataPath + "/Assets/Database.s3db";//Path to database.
         Debug.Log(path);
        IDbConnection dbconn;
        string conn = "URI=file:" + path;
        dbconn = (IDbConnection)new SqliteConnection(conn);
        dbconn.Open(); //Open connection to the database.
        string sqlQuery;
        IDbCommand createcmd = dbconn.CreateCommand();
        sqlQuery = "CREATE TABLE IF NOT EXISTS HighScores (RunTime DATETIME)";
        createcmd.CommandText = sqlQuery;
        IDbCommand dbcmd = dbconn.CreateCommand();
        sqlQuery = "INSERT INTO HighScores " + "VALUES('" + toBeAdded + "')"; //query broken up for readibility
        dbcmd.CommandText = sqlQuery;
        dbcmd.ExecuteNonQuery(); //ExecuteNonQuery excutes an SQL command that does not return a result set
        dbcmd.Dispose();
        dbcmd = null;
        dbconn.Close();
        dbconn = null;
    }

    public static void write(String toBeRemoved, String toBeAdded)
    {//if we get to here, DB must already exist
        Debug.Log("write&&&");
        string conn = "URI=file:" + Application.persistentDataPath + "/Assets/Database.s3db"; //Path to database.
        IDbConnection dbconn;
        dbconn = (IDbConnection)new SqliteConnection(conn);
        dbconn.Open(); //Open connection to the database.
        IDbCommand dbcmd = dbconn.CreateCommand();
        string sqlQuery = "INSERT INTO HighScores " + "VALUES('" + toBeAdded + "')";
        dbcmd.CommandText = sqlQuery;
        dbcmd.ExecuteNonQuery();
        sqlQuery = "DELETE FROM HighScores " + "WHERE RunTime = '" + toBeRemoved + "'";
        dbcmd.CommandText = sqlQuery;
        dbcmd.ExecuteNonQuery();
        dbcmd.Dispose();
        dbcmd = null;
        dbconn.Close();
        dbconn = null;
    }

    public static String getBestTime()
    {
        string path = Application.persistentDataPath + "/Assets/Database.s3db"; //Path to database.
        string conn = "URI=file:" + path;
        DateTime min = new DateTime(2000, 01, 01, 00, 00, 00);
        if (!File.Exists(path))
            return TimeScript.getTimeOnly(min);
        IDbConnection dbconn;
        dbconn = (IDbConnection)new SqliteConnection(conn);//creating connection to database
        dbconn.Open(); //Open connection to the database.
        IDbCommand dbcmd = dbconn.CreateCommand();
        string sqlQuery = "SELECT MIN(RunTime) " + "FROM HighScores";
        dbcmd.CommandText = sqlQuery;
        IDataReader reader = dbcmd.ExecuteReader();
        while (reader.Read())
        {
            min = reader.GetDateTime(0);
        }
        reader.Close();
        reader = null;
        dbcmd.Dispose();
        dbcmd = null;
        dbconn.Close();
        dbconn = null;
        return TimeScript.getTimeOnly(min); //parses timedate as time
    }
}

