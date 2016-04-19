using UnityEngine;
using System.Collections.Generic; //list
using Mono.Data.Sqlite;
using System.Data; //connecting to database
using System;//datetime

public class DBConnect : MonoBehaviour{

    public static List<DateTime> getHighScores()
    {
        string conn = "URI=file:" + Application.dataPath + "/Database.s3db"; //Path to database.
        IDbConnection dbconn;
        dbconn = (IDbConnection)new SqliteConnection(conn);//creating connection to sqllite database
        dbconn.Open(); //Open connection to the database.
        IDbCommand dbcmd = dbconn.CreateCommand(); 
        string sqlQuery = "SELECT * " + "FROM HighScores";
        dbcmd.CommandText = sqlQuery; //puts query we want to execute into dbcmd
        IDataReader reader = dbcmd.ExecuteReader(); //executes query
        List<DateTime> times = new List<DateTime>();
        DateTime value;
        while (reader.Read())
        {
            value = reader.GetDateTime(0); //passing 0 as we are reading from first column in 
            times.Add(value);
        }
        reader.Close();
        dbcmd.Dispose();
        dbconn.Close();
        times.Sort();
        return times;
    }

    public static void write(String toBeAdded) //used when there are less than 5 highscores in the database, so score is added without one being removed
    {
        string conn = "URI=file:" + Application.dataPath + "/Database.s3db"; //Path to database.
        IDbConnection dbconn;
        dbconn = (IDbConnection)new SqliteConnection(conn);
        dbconn.Open(); //Open connection to the database.
        IDbCommand dbcmd = dbconn.CreateCommand();
        string sqlQuery = "INSERT INTO HighScores " + "VALUES('" + toBeAdded + "')"; //query broken up for readibility
        dbcmd.CommandText = sqlQuery;
        dbcmd.ExecuteNonQuery(); //ExecuteNonQuery excutes an SQL command that does not return a result set
        dbcmd.Dispose();
        dbconn.Close();
    }

    public static void write(String toBeRemoved, String toBeAdded)
    {
        string conn = "URI=file:" + Application.dataPath + "/Database.s3db"; //Path to database.
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
        dbconn.Close();
    }

    public static String getBestTime()
    {
        string conn = "URI=file:" + Application.dataPath + "/Database.s3db"; //Path to database.
        IDbConnection dbconn;
        dbconn = (IDbConnection)new SqliteConnection(conn);//creating connection to database
        dbconn.Open(); //Open connection to the database.
        IDbCommand dbcmd = dbconn.CreateCommand();
        string sqlQuery = "SELECT MIN(RunTime) " + "FROM HighScores";
        dbcmd.CommandText = sqlQuery;
        IDataReader reader = dbcmd.ExecuteReader();
        DateTime min = new DateTime();
        while (reader.Read())
        {
            min = reader.GetDateTime(0);
        }
        reader.Close();
        dbcmd.Dispose();
        dbconn.Close();
        return TimeScript.getTimeOnly(min); //parses timedate as time
    }
}

