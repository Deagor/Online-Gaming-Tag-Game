using UnityEngine;
using System.Collections;
using UnityEngine.Networking;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using System.Collections.Generic;

public class Player : MonoBehaviour {

    float speed;
    Vector3 startPos;
    Vector3 prevPos;

    //are we player1?
    public bool isPlayer1;

    //are we the chaser?
    public bool isChaser;

    List<byte> _updateMessage = new List<byte>();

    // Use this for initialization
    void Start () {

        speed = 1.5f;

        startPos = transform.position;
        prevPos = transform.position;

	}
	
	// Update is called once per frame
	void Update () {

        if (isPlayer1 == true)
        {
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
                SerializeAndSend();
            }
        }
    }

    //serialize the players position and get ready to send it
    void SerializeAndSend()
    {
        _updateMessage.Clear();
        _updateMessage.Add((byte)'U');

        //serialize the player
        _updateMessage.AddRange(System.BitConverter.GetBytes(transform.position.x));
        _updateMessage.AddRange(System.BitConverter.GetBytes(transform.position.y));

        byte[] messageToSend = _updateMessage.ToArray();

        Debug.Log("My serialized message: " + messageToSend);

        byte[] buffer = new byte[1024];
        Stream stream = new MemoryStream(buffer);
        BinaryFormatter formatter = new BinaryFormatter();
        formatter.Serialize(stream, messageToSend);

        int bufferSize = 1024;

        //send the serialised information so that net can send it on then
        //net.GetComponent<NetClientHost>().SendUpdateMessage(buffer, bufferSize);
    }
}
