using UnityEngine;
using UnityEngine.UI;


public class FloatingText
{
    public bool active; 
    public GameObject go;
    public Text txt;
    public Vector3 motion;
    public float duration; 
    public float lastShown;

    //This will call the setactive method to set wether the text should still be up or not
    public void Show()
    {
        active = true;
        lastShown = Time.time;
        go.SetActive(active);
    }

    //This will hide the text once the time limit has been reached
    public void Hide()
    {
        active = false;
        go.SetActive(active);
    }

    //This method will make sure to check the time last shown versus the duration wanted and hide it if it has been longer than wanted time
    public void UpdateFloatingText()
    {
        if(!active)
            return;
        
        // 10 seconds - 7        >    2
        if(Time.time - lastShown > duration)
            Hide();

        go.transform.position += motion * Time.deltaTime;

    }

    
}
