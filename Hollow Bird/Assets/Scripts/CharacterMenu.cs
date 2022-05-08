using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CharacterMenu : MonoBehaviour
{
    public Text regenText, hitPointText, thirstText;
    private int currentCharacterSelection = 0;
    public Image characterSelectionSprite, weaponSprite;
    //public rectTransform xpBar;

    public void Start()
    {
        OnSelectionChange();
    }

    // Character Selection
    // This method will change the skin one up in the array if the right arrow is clicked, or one down in the array if not right.
    public void OnArrowClick(bool right)
    {
        if(right)
        {
            currentCharacterSelection++;

            //if we went too far
            if(currentCharacterSelection == GameManager.instance.playerSprites.Count)
                currentCharacterSelection = 0;

            OnSelectionChange();
        }
        else
        {
            currentCharacterSelection--;

            //if we went too far back
            if(currentCharacterSelection < 0)
                currentCharacterSelection = GameManager.instance.playerSprites.Count - 1;

            OnSelectionChange();
        }
    }

    public int getCharSelection()
    {
        return currentCharacterSelection;
    }

    public void setCharSelection(int s)
    {
        currentCharacterSelection = s;
    }

    //Will swap the skins
    private void OnSelectionChange()
    {
        characterSelectionSprite.sprite = GameManager.instance.playerSprites[currentCharacterSelection];
        GameManager.instance.player.SwapSprite(currentCharacterSelection);
    }

    //THis is for weapon upgrades but has not been implemented yet
    public void OnUpgradeClick()
    {
        //leave empty for now

    }
    
    //THis will update all references of a menu. Health , thirst, and regen rate will be updated when the menu opens up.
    public void UpdateMenu()
    {
        // weapon
        // weaponSprite.sprite = Gamemanager.instance.weaponSprites[0];
         

        // meta
        hitPointText.text = GameManager.instance.player.currentHealth.ToString();
        thirstText.text = GameManager.instance.player.currentThirst.ToString();
        regenText.text = GameManager.instance.player.regenRate.ToString() + " seconds";
    }


}
