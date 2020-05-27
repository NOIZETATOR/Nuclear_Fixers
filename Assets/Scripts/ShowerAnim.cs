using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ShowerAnim : MonoBehaviour
{
    public Sprite[] SpritesAnimation;
    public int FPS;
    public float animationTimer;
    private int currentSpriteIndex = 0;
    private Image me;
    void Start()
    {
        me = GetComponent<Image>();
    }

    void Update()
    {
        if (animationTimer > 1f / FPS)
        {
            me.sprite = SpritesAnimation[currentSpriteIndex];
            currentSpriteIndex++;
            if (currentSpriteIndex >= SpritesAnimation.Length)
                currentSpriteIndex = 0;

            animationTimer = 0;
            }
        animationTimer += Time.deltaTime;
    }
}
