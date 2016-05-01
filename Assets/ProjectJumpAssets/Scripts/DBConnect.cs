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
        string path = Application.persistentDataPath + "/Database.s3db"; //Path to database.
        Debug.Log(path + "                ");
        if (File.Exists(path))
        {
            string sqlQuery;
            Debug.Log("Exists");
            string conn = "URI=file:" + path;
            using (SqliteConnection dbconn = new SqliteConnection(conn))
            {
                dbconn.Open();
                sqlQuery = "CREATE TABLE IF NOT EXISTS HighScores(RunTime DATETIME)";
                using (IDbCommand cmd = (IDbCommand)new SqliteCommand(sqlQuery, dbconn))
                {
                    cmd.ExecuteNonQuery();
                }
                sqlQuery = "SELECT * " + "FROM HighScores";
                using (IDbCommand cmd = (IDbCommand)new SqliteCommand(sqlQuery, dbconn))
                {
                    using (IDataReader reader = cmd.ExecuteReader())
                    {
                        DateTime value;
                        while (reader.Read())
                        {
                            value = reader.GetDateTime(0); //passing 0 as we are reading from first column in 
                            times.Add(value);
                        }
                    }
                }
            }
            times.Sort();
        }
        return times;
    }

    public static void write(String toBeAdded) //used when there are less than 5 highscores in the database, so score is added without one being removed
    {
        Debug.Log("Write");
        string path = Application.persistentDataPath + "/Database.s3db";//Path to database.
        Debug.Log(path);
        //IDbConnection dbconn;
        string conn = "URI=file:" + path;
        string sqlQuery;
        using (SqliteConnection dbconn = new SqliteConnection(conn))
        {
            dbconn.Open();
            sqlQuery = "CREATE TABLE IF NOT EXISTS HighScores(RunTime DATETIME)";
            using (IDbCommand cmd = (IDbCommand)new SqliteCommand(sqlQuery, dbconn))
            {
                cmd.ExecuteNonQuery();
            }
            sqlQuery = "INSERT INTO HighScores " + "VALUES('" + toBeAdded + "')"; //query broken up for readibility
            using (IDbCommand cmd = (IDbCommand)new SqliteCommand(sqlQuery, dbconn))
            {
                cmd.ExecuteNonQuery();
            }
        }
    }

    public static void write(String toBeRemoved, String toBeAdded)
    {
        Debug.Log("write&&&");

        string path = Application.persistentDataPath + "/Database.s3db";//Path to database.
        Debug.Log(path);
        //IDbConnection dbconn;
        string conn = "URI=file:" + path;
        string sqlQuery;
        using (SqliteConnection dbconn = new SqliteConnection(conn))
        {
            dbconn.Open();
            sqlQuery = "CREATE TABLE IF NOT EXISTS HighScores(RunTime DATETIME)";
            using (IDbCommand cmd = (IDbCommand)new SqliteCommand(sqlQuery, dbconn))
            {
                cmd.ExecuteNonQuery();
            }
            sqlQuery = "INSERT INTO HighScores " + "VALUES('" + toBeAdded + "')"; //query broken up for readibility
            using (IDbCommand cmd = (IDbCommand)new SqliteCommand(sqlQuery, dbconn))
            {
                cmd.ExecuteNonQuery();
            }
            sqlQuery = "DELETE FROM HighScores " + "WHERE RunTime = '" + toBeRemoved + "'";
            using (IDbCommand cmd = (IDbCommand)new SqliteCommand(sqlQuery, dbconn))
            {
                cmd.ExecuteNonQuery();
            }
        }
    }

    public static String getBestTime()
    {
        string path = Application.persistentDataPath + "/Database.s3db"; //Path to database.
        string sqlQuery;
        DateTime min = new DateTime(2000, 01, 01, 00, 00, 00);
        if (!File.Exists(path))
            return TimeScript.getTimeOnly(min);
        string conn = "URI=file:" + path;
        using (SqliteConnection dbconn = new SqliteConnection(conn))
        {
            dbconn.Open();
            sqlQuery = "CREATE TABLE IF NOT EXISTS HighScores(RunTime DATETIME)";
            using (IDbCommand cmd = (IDbCommand)new SqliteCommand(sqlQuery, dbconn))
            {
                cmd.ExecuteNonQuery();
            }
            sqlQuery = "SELECT MIN(RunTime) " + "FROM HighScores";
            using (IDbCommand cmd = (IDbCommand)new SqliteCommand(sqlQuery, dbconn))
            {
                using (IDataReader reader = cmd.ExecuteReader())
                {
                    DateTime value;
                    while (reader.Read())
                    {
                        min = reader.GetDateTime(0);
                    }
                }
            }
        }
        return TimeScript.getTimeOnly(min); //parses timedate as time
    }
}

