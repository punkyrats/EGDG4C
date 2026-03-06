using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.Serialization;
using Random = UnityEngine.Random;

public class Player : MonoBehaviour
{
    public SpriteRenderer SR;
    public Rigidbody2D RB;

    public float Jump;
    public float Speed = 5f;
    

    public List<GameObject> Grounds;

    public float DesiredVel;

    void Update()
    {
        Vector2 vel = RB.linearVelocity;

        if (Input.GetKey(KeyCode.UpArrow))
        {
            transform.Translate(Vector3.up * Speed * Time.deltaTime);
        }
        else if (Input.GetKey(KeyCode.LeftArrow))
        {
            transform.Translate(Vector3.left * Speed * Time.deltaTime);
        }
        else if (Input.GetKey(KeyCode.RightArrow))
        {
            transform.Translate(Vector3.right * Speed * Time.deltaTime);
        }
        else if (Input.GetKey(KeyCode.DownArrow))
        {
            transform.Translate(Vector3.down * Speed * Time.deltaTime);
        }

        RB.linearVelocity = vel;

        if (transform.position.y < -20)
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        }

    }

    public bool CanJump()
    {
        return Grounds.Count > 0;
    }

    private void OnCollisionEnter2D(Collision2D other)
    {
        Grounds.Add(other.gameObject);
    }
}
