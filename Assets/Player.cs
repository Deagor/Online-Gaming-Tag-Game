using UnityEngine;
using System.Collections;

public class Player : MonoBehaviour {

    float speed;
    Vector3 startPos;
    Vector3 prevPos;

    //are we player1?
    public bool isPlayer1;

    public Texture p1Texture;

    GameObject player;

    // Use this for initialization
    void Start () {

        speed = 1.5f;

        startPos = transform.position;
        prevPos = transform.position;

        isPlayer1 = true;

        player = GameObject.Find("player1");

        if (isPlayer1 == true)
        {
            player.GetComponent<SpriteRenderer>().material.SetTexture("_MainTex", p1Texture);
        }
        else
        {
            
        }

	}
	
	// Update is called once per frame
	void Update () {
        //access the position as you can not modify it directly?
        Vector3 pos = transform.position;

        if (Input.GetKey("up"))
        {
            pos.y += speed * Time.deltaTime;
        }

        if (Input.GetKey("down"))
        {
            pos.y -= speed * Time.deltaTime;
        }

        if (Input.GetKey("right"))
        {
            pos.x += speed * Time.deltaTime;
        }

        if (Input.GetKey("left"))
        {
            pos.x -= speed * Time.deltaTime;
        }

        //set the position to be the modified position
        transform.position = pos;

        //set the previous position(for not sending loads of update messages later)
        if (prevPos != transform.position)
        {
            prevPos = transform.position;
        }
    }
}
