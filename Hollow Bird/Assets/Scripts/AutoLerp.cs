using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AutoLerp : MonoBehaviour
{
    // - - - FOR SPECIAL ANIMATIONS - - -
    public bool active = false;
    public float colorTransitionTime = 2.0f;
    private float transitionTimer = 0.0f;
    private int currentColor = 0;
    private int nextColor = 1;
    protected SpriteRenderer sRenderer;
    public Color[] specialColors = {Color.blue, Color.cyan, Color.magenta};

    // Start is called before the first frame update
    void Start()
    {
        // collect renderer for easy access
        sRenderer = GetComponent<SpriteRenderer>();
    }

    // Update is called once per frame
    void Update()
    {
        // do not cycle colors if not a special chest
        if (!active) return;

        // update timer
        transitionTimer += Time.deltaTime;

        if (transitionTimer > colorTransitionTime)
        {
            currentColor = (currentColor + 1) % specialColors.Length;
            nextColor = (nextColor + 1) % specialColors.Length;
            transitionTimer = 0.0f;
        }

        // Lerp color
        sRenderer.color = Color.Lerp(
            specialColors[currentColor],
            specialColors[nextColor],
            transitionTimer / colorTransitionTime
        );
    }
}
