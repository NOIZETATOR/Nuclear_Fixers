using System.Linq;
using UnityEngine;

public class ValveMachine : Machine
{
    private SpriteRenderer _sprite;
    public Color UnActive;
    public Color Active;
    private Collider2D _colliderBtnLeft;
    private Collider2D _colliderBtnRight;

    private int _leftValveStartIndex = -1;
    public int _leftValveCurrentIndex;
    public int _leftValveTours;
    private int _rightValveStartIndex = -1;
    public int _rightValveCurrentIndex;
    public int _rightValveTours;

    public float _currentPerc;

    private SpriteRenderer _barGauche;
    private SpriteRenderer _barDroite;
    private Vector3 _GstartRotation;
    private Vector3 _DstartRotation;

    public ActionButtons[] _sensRotation = new ActionButtons[] { ActionButtons.JoystickBot, ActionButtons.JoystickLeft, ActionButtons.JoystickTop, ActionButtons.JoystickRight };

    private float _timeBeforeReset = 3f;
    private float _currentInactifTime;

    // Animation
    public Sprite[] SpritesAnimation;
    public int FPS;
    public SpriteRenderer SmokeSprite01;
    public SpriteRenderer SmokeSprite02;
    private int _currentSpriteIndex;
    private float _animationTimer;

    public Sprite Broken;
    public Sprite Fixed;


    // Start is called before the first frame update
    void Start()
    {
        _sprite = GetComponent<SpriteRenderer>();
        _colliderBtnLeft = GameObject.Find("LeftValve").GetComponent<BoxCollider2D>();
        _colliderBtnRight = GameObject.Find("RightValve").GetComponent<BoxCollider2D>();

        _barGauche = GameObject.Find("leftDoor").GetComponent<SpriteRenderer>();
        _barDroite = GameObject.Find("rightDoor").GetComponent<SpriteRenderer>();

        _GstartRotation = _barGauche.transform.rotation.eulerAngles;
        _DstartRotation = _barDroite.transform.rotation.eulerAngles;
    }

    // Update is called once per frame
    void Update()
    {
        var x = Physics2D.BoxCast(_colliderBtnLeft.bounds.center, _colliderBtnLeft.bounds.size, 0f, Vector2.down, .1f, 1 << 8);
        var z = Physics2D.BoxCast(_colliderBtnRight.bounds.center, _colliderBtnRight.bounds.size, 0f, Vector2.down, .1f, 1 << 8);
        isActive = x && z;

        if (isActive)
            _sprite.color = Active;
        else
            _sprite.color = UnActive;

        _currentPerc = (_leftValveTours + _rightValveTours * 1f) / 6f;

        // bar gauche
        _barGauche.transform.rotation = Quaternion.Euler(Vector3.Lerp(_GstartRotation, new Vector3(0, 0, 70), _currentPerc));

        // bar droite
        _barDroite.transform.rotation = Quaternion.Euler(Vector3.Lerp(_DstartRotation, new Vector3(0, 0, -70), _currentPerc));

        if (_currentPerc == 1)
        {
            isBroken = false;
        }

        if (isBroken)
        {
            AnimateSmoke();
            _sprite.sprite = Broken;
        }
        else
        {
            _sprite.sprite = Fixed;
            SmokeSprite01.sprite = null;
            SmokeSprite02.sprite = null;
        }


        if ((_leftValveStartIndex != -1 || _rightValveStartIndex != -1)  && isBroken)
        {
            if (_currentInactifTime >= _timeBeforeReset)
            {
                Break();
                _currentInactifTime = 0;

            }
            _currentInactifTime += Time.deltaTime;
        }
    }

    public override void Action(ActionButtons btn)
    {
        return;
    }

    public override void Break()
    {
        _leftValveTours = 0;
        _rightValveTours = 0;
        _leftValveCurrentIndex = -1;
        _leftValveStartIndex = -1;
        _rightValveCurrentIndex = -1;
        _rightValveStartIndex = -1;
        base.Break();

    }

    public override void JoystickRotation(ActionButtons btn, int valveIndex)
    {
        var index = _sensRotation.ToList().IndexOf(btn);
        if (index == -1 || !isActive || !isBroken)
            return;

        if (valveIndex == 0)
        {
            if (_leftValveTours == 3)
                return;
            if (_leftValveStartIndex == -1)
            {
                _leftValveStartIndex = index;
                _leftValveCurrentIndex = index;
                _leftValveTours = 0;
                SetNextIndex(0, index, true);
            }
            else
            {
                if (index == _leftValveCurrentIndex)
                    SetNextIndex(0, index);
            }

        }
        else if (valveIndex == 1)
        {
            if (_rightValveTours == 3)
                return;
            if (_rightValveStartIndex == -1)
            {
                _rightValveStartIndex = index;
                _rightValveCurrentIndex = index;
                _rightValveTours = 0;
                SetNextIndex(1, index, true);
            }
            else
            {
                if (index == _rightValveCurrentIndex)
                    SetNextIndex(1, index);
            }

        }
    }

    private void SetNextIndex(int valveIndex, int pressedIndex, bool isInit = false)
    {
        _currentInactifTime = 0;

        if (valveIndex == 0)
        {
            if (pressedIndex == _leftValveStartIndex && !isInit)
                _leftValveTours++;
            if (pressedIndex == _sensRotation.Length - 1)
                _leftValveCurrentIndex = 0;
            else
                _leftValveCurrentIndex++;
        }
        else
        {
            if (pressedIndex == _rightValveStartIndex)
                _rightValveTours++;
            if (pressedIndex == _sensRotation.Length - 1)
                _rightValveCurrentIndex = 0;
            else
                _rightValveCurrentIndex++;
        }

    }

    private void AnimateSmoke()
    {
        if (_animationTimer > 1f / FPS)
        {
            SmokeSprite01.sprite = SpritesAnimation[_currentSpriteIndex];
            SmokeSprite02.sprite = SpritesAnimation[_currentSpriteIndex];
            _currentSpriteIndex++;

            if (_currentSpriteIndex >= SpritesAnimation.Length)
                _currentSpriteIndex = 0;

            _animationTimer = 0;
        }
        _animationTimer += Time.deltaTime;
    }


}
