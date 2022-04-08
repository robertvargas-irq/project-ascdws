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
    public ItemDatabase itemDatabase;

    // - - - PREFERRED PRONOUNS - - -
    private string[][] pronouns = {    // global pronouns
        new string[]{"he", "him", "his"},
        new string[]{"she", "her", "hers"},
        new string[]{"they", "them", "theirs"},
        new string[]{"xe", "xem", "xeirs"}
    };
    public int preferredPronouns = 2; // preferred pronouns from globals
    public string Subjective // he/she/they/xe
    {
        get {return pronouns[preferredPronouns][0];}
    }
    public string Objective // him/her/them/xem
    {
        get {return pronouns[preferredPronouns][1];}
    }
    public string Possesive // his/hers/theirs/xeirs
    {
        get {return pronouns[preferredPronouns][2];}
    }

    // - - - GAMEOBJECT REFERENCES - - -
    public Player player;
    //public weapon weapon... 

    public FloatingTextManager floatingTextManager;

    // - - - SAVE STATE - - -

    // - - - FLOATING TEXT - - -
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
        // ! IMPLEMENT ME

        Debug.Log("LoadState"); 
    }


}
