using UnityEngine;
using System.Collections;
using System.Collections.Generic; //list
using System;

public class TimeScript : MonoBehaviour {

    // Use this for initialization
    void Start() {

    }

    // Update is called once per frame
    void Update() {

    }

    public static void checkHighScores(int hours, int minutes, int seconds)
    {
        {
            List<DateTime> times = DBConnect.getHighScores();
            String h = timeFormatter(hours); //formats '0' as '00' for example
            String m = timeFormatter(minutes);
            String s = timeFormatter(seconds);
            String rTime = "2000-01-01 " + h + ":" + m + ":" + s;
            DateTime runTime = new DateTime(2000, 01, 01, hours, minutes, seconds);
            if (times.Count < 5) //if there's ;ess than 5 scores, the last runtime is added regardless of how quick it is
                DBConnect.write(rTime);
            else if(times[4] > runTime) //if runtime is shorter than the longest time in the DB (times[4]), it replaces it
                replaceTime(times[4], rTime);
        }
    }
    public static string timeFormatter(int tInt)//move this to another script
    {
        return tInt.ToString("00");
    }

    public static void replaceTime(DateTime highestTime, String rTime)
    {
        String hTime = highestTime.ToString("yyyy-MM-dd HH:mm:ss");
        DBConnect.write(hTime, rTime); //deletes highestTime, and adds runTime to database*/
    }

    public static String getTimeOnly(DateTime dt)//takes away the date part of a datetime object and returns a string of the time
    {
        String dtString = dt.ToString("HH:mm:ss");
        return dtString;
    }
}
