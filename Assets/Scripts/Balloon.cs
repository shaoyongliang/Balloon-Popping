using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class Balloon : MonoBehaviour
{
    [SerializeField] float speed;
    public int value;
    public float maxSize = 0.18f;
    public float growthrate = .02f;
    public float scale=.08f;


    // Start is called before the first frame update
    void Awake()
    {

    }

    // Update is called once per frame

    void Update()
    {
        Move();
        transform.localScale = Vector3.one * scale;
        scale += growthrate * Time.deltaTime;
        if (scale > maxSize)
        {
            Destroy(gameObject);
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        }

    }

    void Move()
    {
        Vector3 movedPos = transform.position;
        movedPos.x += speed * Time.deltaTime;
        transform.position = movedPos;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "MainCamera")
        {
            ChangeDirection();
        }
        if (collision.gameObject.CompareTag("Bullet"))
        {
            gameObject.SetActive(false);
            Score.instance.IncreaseScore(value);
            Invoke("CompleteLevel", 1f);
        }
    }

    private void ChangeDirection()
    {
        speed *= -1;
    }

    private void CompleteLevel()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }

    private void Load()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

}

