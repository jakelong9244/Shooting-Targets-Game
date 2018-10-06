using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class CameraControl : MonoBehaviour {

    public float CamSpeed;
    public float MissileSpeed;
    public Rigidbody projectile;
    public Texture2D crosshair;
    public Texture2D Bullet;
    public GameObject explosion;
    private int counter = 0;
    public float timeLeft = 60;
    private int bulletsLeft = 0;

    // Use this for initialization
    void Start () {
        
	}

    void Update() {
        Vector3 rotate = new Vector3(Input.GetAxis("Vertical") /(-1), Input.GetAxis("Horizontal"), 0.0f);
        transform.Rotate(rotate * CamSpeed * Time.deltaTime);

        timeLeft -= Time.deltaTime;
    }
	
	// Update is called once per frame
	void FixedUpdate () {
        counter += 1;
        if (counter == 4) {
            explosion.gameObject.SetActive(false);
            counter = 0;
        }
        
        if (bulletsLeft >= 5) {

        }


        if (Input.GetKeyDown("space")) {

            explosion.gameObject.SetActive(true);

            //Create Missile that is clone of Projectile
            Rigidbody Missile;
            Missile = Instantiate(projectile, transform.position + (transform.forward / 2) + (transform.right / 2), transform.rotation) as Rigidbody;


            //Accelerate Missile
            Vector3 direction = new Vector3(Random.Range(-0.01f,0.01f),Random.Range(-0.01f,0.01f),1.0f);
            Missile.velocity = transform.TransformDirection(direction * MissileSpeed);

            counter = 0;
            bulletsLeft += 1;
        }
	}

    void OnGUI()
    {
        float xMin = (Screen.width / 2) - (crosshair.width / 2);
        float yMin = (Screen.height / 2) - (crosshair.height / 2);
        float xMinHUD = -250;
        float yMinHUD = 270;

        GUI.DrawTexture(new Rect(xMin, yMin, crosshair.width, crosshair.height), crosshair);
        //GUI.DrawTexture(new Rect(xMinHUD, yMinHUD, Bullet.width, Bullet.height), Bullet);

        GUI.color = Color.black;
        GUI.Label(new Rect(800, 10, 150, 150), "Time: " + timeLeft.ToString());
    }


}
