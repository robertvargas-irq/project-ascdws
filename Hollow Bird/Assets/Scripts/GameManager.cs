using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;
    private void Awake()
    {
        // if(GameManger.instance != null)
        // {
        //     Destory(gameObject);
        //     return;
        // }
        Screen.SetResolution(800, 600, false, 60);
        instance = this;
        SceneManager.sceneLoaded += LoadState;
        DontDestroyOnLoad(gameObject);
    }

    //Resources
    public List<Sprite> playerSprites;
    public List<Sprite> weaponSprites;
    public List<int> weaponPrices;
    public List<int> xpTable;

    //References 
    public Player player;
    //public weapon weapon... 

    public FloatingTextManager floatingTextManager;

    // Logic
    public int pesos;
    public int experience;

    //saveState
    /*
        INT preferedSkin
        INT pesos
        INT experience
        INT weaponLevel
    */

    //floating text
    public void ShowText(string msg, int fontSize, Color color, Vector3 position, Vector3 motion, float duration)
    {
        floatingTextManager.Show(msg,fontSize,color,position,motion,duration);
    }


    public void SaveState()
    {
        string s = "";
        
        s += "0" + "|";
        //s += pesos.ToString() + "|";
        //s += experience.ToString() + "|";
        s += "0";

        PlayerPrefs.SetString("SaveState", s);
    }
    
    public void LoadState(Scene s, LoadSceneMode mode)
    {
        SceneManager.sceneLoaded  -= LoadState;
        if(!PlayerPrefs.HasKey("SaveState"))
            return;
        string[] data = PlayerPrefs.GetString("SaveState").Split('|');

        //change player skin
        pesos = int.Parse(data[0]);
        experience = int.Parse(data[2]);

        Debug.Log("LoadState"); 
    }


}
