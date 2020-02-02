using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using UnityEngine.SceneManagement;


public class MenuScript : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
         GameObject.Find("CustumSoundManager").GetComponent<CustumSoundManagerScript>().playMusique();
         GameObject.Find("CustumSoundManager").GetComponent<CustumSoundManagerScript>().playStart();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void startGame(){
        Debug.Log("aezaze");

        Application.LoadLevel("Scenes/world_test");
        Application.LoadLevel("world_test");
        SceneManager.LoadScene("Scenes/world_test", LoadSceneMode.Additive);
        Debug.Log("azeaze");
    }

    public void exitGame(){
		Application.Quit();
    }
}
