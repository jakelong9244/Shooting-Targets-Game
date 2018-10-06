using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class TargetLife : MonoBehaviour {

    public GameObject OrigTarget;
    private int TargetsHit = 0;

    // Use this for initialization
    void Start () {

    }
	
	// Update is called once per frame
	void Update () {
    }

    void OnCollisionEnter(Collision other)
    {
        if (other.gameObject.CompareTag("Bullet"))
        {
            GameObject Targets;
            Vector3 NewPosition = new Vector3(Random.Range(-7.5f, 7.5f), Random.Range(1.5f, 4.0f), Random.Range(5.0f, 25.0f));

            Targets = Instantiate(OrigTarget, NewPosition, OrigTarget.transform.rotation) as GameObject;

            gameObject.SetActive(false);

            TargetsHit += 1;
        }
    }

    private void OnGUI()
    {
        GUI.color = Color.black;
        GUI.Label(new Rect(10, 10, 100, 20), "Targets Hit: " + TargetsHit.ToString());
    }

}
