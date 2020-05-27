using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Computer : Machine
{
    private ActionButtons[] _possibleButtons = new ActionButtons[] { ActionButtons.B, ActionButtons.X, ActionButtons.Y };
    private ActionButtons[] _combinaison;

    private SpriteRenderer _sprite;
    public Color UnActive;
    public Color Active;
    public Color UnActiveBtn;
    private Collider2D _collider;

    private SpriteRenderer _btn0Sprite;
    private SpriteRenderer _btn1Sprite;
    private SpriteRenderer _btn2Sprite;

    public Sprite BSprite;
    public Sprite XSprite;
    public Sprite YSprite;

    private bool _canPress = true;
    private int _currentBtnIndex = 0;
    private float _timeBeforeReset = 1.5f;
    private float _currentInactifTime;


    // Animation
    public Sprite[] SpritesAnimation;
    public int FPS;
    public SpriteRenderer SmokeSprite;
    private int _currentSpriteIndex;
    private float _animationTimer;





    // Start is called before the first frame update
    void Start()
    {
        _collider = GetComponentInChildren<BoxCollider2D>();
        _sprite = GetComponent<SpriteRenderer>();
        _btn0Sprite = transform.Find("actionBtn0").GetComponent<SpriteRenderer>();
        _btn1Sprite = transform.Find("actionBtn1").GetComponent<SpriteRenderer>();
        _btn2Sprite = transform.Find("actionBtn2").GetComponent<SpriteRenderer>();

    }

    public override void Break()
    {
        base.Break();
        GetCombinaison();
    }


    // Update is called once per frame
    void Update()
    {
        var x = Physics2D.BoxCast(_collider.bounds.center, _collider.bounds.size, 0f, Vector2.down, .1f, 1 << 8);

        if (_currentBtnIndex != 0 && isBroken)
        {
            if (_currentInactifTime >= _timeBeforeReset)
            {
                GetCombinaison();
                _currentInactifTime = 0;

            }
            _currentInactifTime += Time.deltaTime;
        }


        isActive = x;
        HighLightActiveBtn();

        if (isActive)
            _sprite.color = Active;
        else
            _sprite.color = UnActive;

        if (isBroken)
            AnimateSmoke();
        else
        {
            SmokeSprite.sprite = null;
            _btn0Sprite.color = new Color(0, 0, 0, 0);
            _btn1Sprite.color = new Color(0, 0, 0, 0);
            _btn2Sprite.color = new Color(0, 0, 0, 0);
        }
        
    }
    public override void Action(ActionButtons btn)
    {
        if (!isBroken || !_canPress) return;
        if (btn.Equals(_combinaison[_currentBtnIndex]))
        {
            if (_currentBtnIndex == 2)
            {
                _combinaison = new ActionButtons[0];
                isBroken = false;
                HighLightActiveBtn();
                return;
            }
            _currentBtnIndex++;
            _currentInactifTime = 0;
            _canPress = false;
            StartCoroutine(CanPressAgain());
        }
        else if(!btn.Equals(ActionButtons.None) && !btn.Equals(ActionButtons.JoystickBot) && !btn.Equals(ActionButtons.JoystickTop) && !btn.Equals(ActionButtons.JoystickRight) && !btn.Equals(ActionButtons.JoystickLeft))
        {
            _currentBtnIndex = 0;
            _currentInactifTime = 0;
            _canPress = false;
            StartCoroutine(CanPressAgain());
        }
    }

    IEnumerator CanPressAgain()
    {
        yield return new WaitForSeconds(.15f);
        _canPress = true;
    }

    private void SetupButtonSprite(int index, ActionButtons btn)
    {
        Sprite sprt = BSprite;
        if (btn.Equals(ActionButtons.B))
            sprt = BSprite;
       else if (btn.Equals(ActionButtons.Y))
            sprt = YSprite;
       else if (btn.Equals(ActionButtons.X))
            sprt = XSprite;

        if (index == 0)
            _btn0Sprite.sprite = sprt;
        if (index == 1)
            _btn1Sprite.sprite = sprt;
        if (index == 2)
            _btn2Sprite.sprite = sprt;

        _combinaison[index] = btn;
    }

    private void HighLightActiveBtn()
    {
        _btn0Sprite.color = UnActiveBtn;
        _btn1Sprite.color = UnActiveBtn;
        _btn2Sprite.color = UnActiveBtn;

        if (isActive && isBroken)
        {
            if (_currentBtnIndex == 0)
                _btn0Sprite.color = Active;
            if (_currentBtnIndex == 1)
                _btn1Sprite.color = Active;
            if (_currentBtnIndex == 2)
                _btn2Sprite.color = Active;
        }
    }

    private void AnimateSmoke()
    {
        if (_animationTimer > 1f / FPS)
        {
            SmokeSprite.sprite = SpritesAnimation[_currentSpriteIndex];
            _currentSpriteIndex++;

            if (_currentSpriteIndex >= SpritesAnimation.Length)
                _currentSpriteIndex = 0;

            _animationTimer = 0;
        }
        _animationTimer += Time.deltaTime;
    }

    private void GetCombinaison()
    {
        _combinaison = new ActionButtons[3];
        for (int i = 0; i < _combinaison.Length; i++)
        {
            var btn = _possibleButtons[Random.Range(0, _possibleButtons.Length)];
            SetupButtonSprite(i, btn);
        }
        _currentBtnIndex = 0;
    }
}
