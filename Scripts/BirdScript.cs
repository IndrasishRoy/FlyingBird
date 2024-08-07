using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BirdScript : MonoBehaviour
{
    [SerializeField]
    private GameManager _gameManager;
    private Rigidbody2D rb;
    [SerializeField]
    private float _velocity = 10f;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        transform.position = new Vector3(0, 0, 0);
        rb.freezeRotation = true;
    }

    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Space) || Input.GetMouseButtonDown(0))
        {
            rb.velocity = Vector2.up * _velocity;
        }
        transform.rotation = Quaternion.Euler(0, 0, 0);

        if(transform.position.y < -13.2 || transform.position.y > 15.18)
        {
            Destroy(gameObject);
            _gameManager.GameOver();
        }
    }
    private void OnCollisionEnter2D(Collision2D c)
    {
        if (c.collider.tag == "TopPipe" || c.collider.tag == "BottomPipe")
        {
            _gameManager.GameOver();
        }
        if(c.collider.tag == "Score")
        {
            //Debug.Log("Score Interacted!");
            Destroy(c.collider.gameObject);
            _gameManager.addScore();
        }
    }
}
