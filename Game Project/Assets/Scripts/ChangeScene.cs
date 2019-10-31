using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ChangeScene : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnCollisionEnter(Collision gameObjectInfromation)
    {
        if (gameObjectInfromation.gameObject.name == "Player_White")
        {
            Debug.Log("Collision Detected");
            SceneManager.LoadScene("2DFightScene");
        }
    }
}
