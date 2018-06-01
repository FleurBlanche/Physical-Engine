using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraScript : MonoBehaviour {

    float moveSpeed;
    float rotateSpeed;
	// Use this for initialization
	void Start () {
        moveSpeed = 1;
        rotateSpeed = 20;
	}
	
	// Update is called once per frame
	void Update () {
        Vector3 pos = transform.position;
        Vector3 rot = transform.eulerAngles;
        if (Input.GetKey(KeyCode.W))
        {
            Debug.Log("W");
            pos.y -= moveSpeed * Time.deltaTime * Mathf.Sin(rot.x * Mathf.Deg2Rad);
            float remain = moveSpeed * Time.deltaTime * Mathf.Cos(rot.x * Mathf.Deg2Rad);
            pos.z += remain * Mathf.Cos(rot.y * Mathf.Deg2Rad);
            pos.x += remain * Mathf.Sin(rot.y * Mathf.Deg2Rad);
        }
        if (Input.GetKey(KeyCode.S))
        {
            Debug.Log("S");
            pos.y += moveSpeed * Time.deltaTime * Mathf.Sin(rot.x * Mathf.Deg2Rad);
            float remain = moveSpeed * Time.deltaTime * Mathf.Cos(rot.x * Mathf.Deg2Rad);
            pos.z -= remain * Mathf.Cos(rot.y * Mathf.Deg2Rad);
            pos.x -= remain * Mathf.Sin(rot.y * Mathf.Deg2Rad);
        }
        if (Input.GetKey(KeyCode.A))
        {
            Debug.Log("A");
            pos.z += moveSpeed * Time.deltaTime * Mathf.Sin(rot.y * Mathf.Deg2Rad);
            pos.x -= moveSpeed * Time.deltaTime * Mathf.Cos(rot.y * Mathf.Deg2Rad);
        }
        if (Input.GetKey(KeyCode.D))
        {
            Debug.Log("D");
            pos.z -= moveSpeed * Time.deltaTime * Mathf.Sin(rot.y * Mathf.Deg2Rad);
            pos.x += moveSpeed * Time.deltaTime * Mathf.Cos(rot.y * Mathf.Deg2Rad);
        }
        if (Input.GetKey(KeyCode.UpArrow))
        {
            rot.x -= rotateSpeed * Time.deltaTime;
        }
        if (Input.GetKey(KeyCode.DownArrow))
        {
            rot.x += rotateSpeed * Time.deltaTime;
        }
        if (Input.GetKey(KeyCode.LeftArrow))
        {
            rot.y -= rotateSpeed * Time.deltaTime;
        }
        if (Input.GetKey(KeyCode.RightArrow))
        {
            rot.y += rotateSpeed * Time.deltaTime;
        }
        transform.position = pos;
        transform.rotation = Quaternion.Euler(rot.x, rot.y, rot.z);
    }
}
