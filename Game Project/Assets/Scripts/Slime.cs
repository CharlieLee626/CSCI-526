using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Slime: MonoBehaviour
{
    public bool moveRight;
    public float speed;
    public int health;
    public Animator animator3;
    // Start is called before the first frame update
    private GameObject playerObj;
    private GameObject slimeObj;

    void Start()
    {
        playerObj = GameObject.Find("Player");
        slimeObj = GameObject.Find("Slime");
        
    }

    // Update is called once per frame
    void Update()
    {
        if (health <= 0)
        {
            Destroy(gameObject);
        }
        if(moveRight)
        {
            transform.Translate(2 * Time.deltaTime * speed, 0, 0);
            transform.localScale = new Vector2(-10, 10);
        }
        else
        {
            transform.Translate(-2 * Time.deltaTime * speed, 0, 0);
            transform.localScale = new Vector2(10, 10);
        }
        
        float distance = Vector2.Distance(playerObj.transform.position, slimeObj.transform.position);
        if (distance < 3.0f)
        {
            animator3.Play("slimeanimation_atk");
        }
    }

    void OnTriggerEnter2D(Collider2D trig)
    {
        if(trig.gameObject.CompareTag("patrolpath"))
        {
            if (moveRight)
            {
                moveRight = false;
            }
            else
                moveRight = true;
        }
    }

    public void TakeDamage(int dmg)
    {
        health -= dmg;

    }

    public void OnDestroy()
    {
        //SceneManager.LoadScene("SampleScene");
        GameOver.IsGameOver = true;
        SceneManager.LoadScene("Menu", LoadSceneMode.Additive);
    }
}
