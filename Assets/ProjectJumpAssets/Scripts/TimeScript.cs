using UnityEngine;
using System.Collections.Generic; //list
using System;

public class TimeScript : MonoBehaviour {

    public static void checkHighScores(int hours, int minutes, int seconds) //run time of level just completed
    {
        {
            List<DateTime> times = DBConnect.getHighScores();
            String h = timeFormatter(hours); //formats '0' as '00' for example
            String m = timeFormatter(minutes);
            String s = timeFormatter(seconds);
            String rTime = "2000-01-01 " + h + ":" + m + ":" + s;
            DateTime runTime = new DateTime(2000, 01, 01, hours, minutes, seconds);
            if (times.Count < 5) //if there's less than 5 scores in DB, the user's runtime is added regardless of how slow it is
                DBConnect.write(rTime);
            else if (times[4] > runTime) //if runtime is quicker than the slowest time in the DB (times[4]), it replaces it
            {
                String hTime = times[4].ToString("yyyy-MM-dd HH:mm:ss");
                DBConnect.write(hTime, rTime); //deletes highestTime, and adds runTime to database*/
            }
        }
    }

    public static string timeFormatter(int tInt) //formats ints like time, so "1" becomes "01"
    {
        return tInt.ToString("00");
    }
    
    public static String getTimeOnly(DateTime dt)//takes away the date part of a datetime object and returns a string of the time
    {
        String dtString = dt.ToString("HH:mm:ss");
        return dtString;
    }
}
