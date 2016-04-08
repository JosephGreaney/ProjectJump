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
            //DateTime rTime = new DateTime(2000,01,01,hours,minutes,seconds);
            String h = timeFormatter(hours);
            String m = timeFormatter(minutes);
            String s = timeFormatter(seconds);
            String rTime = "2000-01-01 " + h + ":" + m + ":" + s;
            DateTime runTime = new DateTime(2000, 01, 01, hours, minutes, seconds);
            if (times.Count < 5)
            {
                DBConnect.write(rTime);
                times.Add(runTime);
                //times.Sort(); //sorts times in  ascending order
            }
            else
                replaceTime(times, runTime, rTime);
        }
    }
    public static string timeFormatter(int tInt)//move this to another script
    {
        return tInt.ToString("00");
    }

    public static void replaceTime(List<DateTime> times, DateTime runTime, String rTime)
    {
        DateTime highestTime = times[4];
        if (highestTime > runTime)
        {   //formats time to be removed into the format required by the database "yyyy-MM-dd ss:mm:ss"
            String highString = highestTime.ToString();
            Char[] splitChars = { '/', ' ' };//split requires a char array as an argument
            Char[] splitChars2 = { ':' };
            String[] dtArray = highString.Split(splitChars);  //Splits into four parts, with date parts having their own array index and time in the final index of the array
            String[] timeArray = dtArray[3].Split(splitChars2); //splits time into three parts
            int hrs = (Int32.Parse(timeArray[0])) - 12; //Stops time of 00:00:12 appearing as 12:00:12 AM
            String hour = timeFormatter(hrs); //Formats 9 as '09' for example
            String month = timeFormatter(Int32.Parse(dtArray[1]));
            String day = timeFormatter(Int32.Parse(dtArray[0]));
            String hString = dtArray[2] + "-" + month + "-" + day + " " + hour + ":" + timeArray[1] + ":" + timeArray[2];
            DBConnect.write(hString, rTime); //deletes highestTime, and adds runTime to database*/
            //times.Remove(highestTime);
            //times.Add(runTime);
        }
    }
}
