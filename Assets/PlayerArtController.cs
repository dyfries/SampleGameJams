using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(SpriteRenderer))]
public class PlayerArtController : MonoBehaviour {
    // Start is called before the first frame update
    [Header("Component Reference")]
    public SpriteRenderer renderer;

    [Header("Sprites")]
    public Sprite neutralSprite;
    public Sprite tiltLeft;
    public Sprite turnLeft;
    public Sprite tiltRight;
    public Sprite turnRight;

    [Header("Sprite Settings")]
    public float turnThreshold = .7f;
    public float tiltThreshold = .2f;

    private float xIn;
    void Start() {
        renderer = GetComponent<SpriteRenderer>();
    }

    // Update is called once per frame
    void Update() {
        xIn = Input.GetAxis("Horizontal");


        // Determien the sprite based on the input
        // Q: Why Input and not movement? 

        // remember left turn is a negative x value
        if (xIn < -turnThreshold) {
            // Left Turn
            renderer.sprite = turnLeft;
        } else if (xIn > -turnThreshold && xIn < -tiltThreshold) {
            // Tilt Left
            renderer.sprite = tiltLeft;
        } else if (xIn > -tiltThreshold && xIn < tiltThreshold) {
            // mid
            renderer.sprite = neutralSprite;
        } else if (xIn < turnThreshold && xIn > tiltThreshold) {
            // Tilt right
            renderer.sprite = tiltRight;
        } else if (xIn > turnThreshold) {
            // Turn Right
            renderer.sprite = turnRight;
        } else {
            Debug.LogWarning("Dummy check - Should never reach this ");
        }
    }
}

/* Additional Notes: 
This works because the Input that you are getting already has a smoothing function on it. 
You can set up these settings in the Input Editor (Edit > Project Settings > Input Manager). 
The setting you are looking for are on the individual Axis' and Gravity and Sensitivity are a good place to start. 
Sensitivity is how fast the Input value moves towards the keypress, Gravity is how fast it returns to neutral. 
Read the tooltip s(Hover your mouse over the word) for more details. 
*/
