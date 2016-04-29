using UnityEngine;
using System.Collections;

public class LaserSwitch : MonoBehaviour {

    private Animator m_Anim;
    private GameObject laser;
    private string switchName;
    private string switchNumber;
    // Use this for initialization
    void Start () {
        m_Anim = GetComponent<Animator>();              //Find out which switch is being activated 
        switchName = transform.name;                    //Parse the last digit 
        switchNumber = switchName.Substring(7, 1);      //Find the gate with the same last digit
        print(switchNumber);
        laser = GameObject.FindGameObjectWithTag("Laser" +"(" +switchNumber  +")");
    }
	
	// Update is called once per frame
	void Update () {
	}

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "Player")
        {
            m_Anim.SetBool("On", false);
            if (laser != null)
                laser.SetActive(false);
        }
    }
}
