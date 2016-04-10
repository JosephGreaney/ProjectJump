using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using System;//datetime
using System.Collections;
using System.Collections.Generic; //list

public class LeaderBoardScript : MonoBehaviour
{
    public Text Score1, Score2, Score3, Score4, Score5;
	
	void Start ()
    {
        getScores();
    }
	
	void getScores ()
    {
        List<DateTime> times = DBConnect.getHighScores();
        String[] tempArray = new String[5] { "--:--:--", "--:--:--", "--:--:--", "--:--:--", "--:--:--" };
        for (int i = 0; i < times.Count; i++)
            tempArray[i] = TimeScript.getTimeOnly(times[i]);
        Score1.text = tempArray[0];
        Score2.text = tempArray[1];
        Score3.text = tempArray[2];
        Score4.text = tempArray[3];
        Score5.text = tempArray[4];
    }

    public void ContinueButtonPressed()
    {
        SceneManager.LoadScene("MainMenu");
    }
}
