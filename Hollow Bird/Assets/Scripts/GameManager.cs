using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;
    private void Awake()
    {
        if(GameManager.instance != null)
        {
            Destroy(gameObject);
            return;
        }
        Screen.SetResolution(800, 600, false, 60);
        instance = this;
        SceneManager.sceneLoaded += LoadState;
        DontDestroyOnLoad(gameObject);
    }

    //Resources
    public List<Sprite> playerSprites;
    public List<Sprite> weaponSprites;
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
    public CharacterMenu characterMenu;
    //public weapon weapon... 

    public FloatingTextManager floatingTextManager;

    // - - - SAVE STATE - - -

    // - - - FLOATING TEXT - - -
    public void ShowText(string msg, int fontSize, Color color, Vector3 position, Vector3 motion, float duration)
    {
        floatingTextManager.Show(msg,fontSize,color,position,motion,duration);
    }

    //Health
    //Thirst
    public void SaveState()
    {
        Debug.Log("Saved");
        string s = "";
        
        s += player.currentHealth.ToString() + "|";
        s += player.currentThirst.ToString() + "|";
        s += characterMenu.getCharSelection() + "|";
        s += "0";
        Debug.Log(player.currentHealth.ToString());
        Debug.Log(player.currentThirst.ToString());

        PlayerPrefs.SetString("SaveState", s);
        Debug.Log(PlayerPrefs.GetString("SaveState"));
    }
    
    public void LoadState(Scene s, LoadSceneMode mode)
    {   
        if(!PlayerPrefs.HasKey("SaveState"))
            return;
        Debug.Log(PlayerPrefs.GetString("SaveState"));
        string[] data = PlayerPrefs.GetString("SaveState").Split('|');
        Debug.Log(data[0] + " " + data[1]);
        //change player skin
        player.currentHealth = int.Parse(data[0]);
        player.currentThirst = int.Parse(data[1]);
        characterMenu.setCharSelection(int.Parse(data[2]));
        // ! IMPLEMENT ME

        Debug.Log("LoadState"); 
    }


}
