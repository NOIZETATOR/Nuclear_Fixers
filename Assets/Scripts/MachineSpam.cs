using System.Collections;
using System.Linq;
using UnityEngine;
using UnityEngine.UI;

public class MachineSpam : Machine
{
    private ActionButtons[] _possibleButtons = new ActionButtons[] { ActionButtons.B, ActionButtons.X, ActionButtons.Y };
    private ActionButtons _touche;
    private SpriteRenderer _sprite;
    private SpriteRenderer _spriteBtn;
    public Color UnActive;
    public Color Active;
    public Color UnActiveBtn;
    private Collider2D _collider;

    public Sprite BSprite;
    public Sprite XSprite;
    public Sprite YSprite;

    public Sprite BrokenSprite;
    public Sprite FixedSprite;


    private bool _canPress = true;
    private float _timeBeforeReset = 1.5f;
    private float _currentInactifTime;


    // Animation
    public Sprite[] SpritesAnimation;
    public int FPS;
    public SpriteRenderer SmokeSprite01;
    public SpriteRenderer SmokeSprite02;
    public SpriteRenderer KeySprite;
    private int _currentSpriteIndex;
    private float _animationTimer;



    public Slider slide;
    private int _requiredPressCount = 20;
    private int _pressCount = 0;
    public GameObject OutilToSpawn;
    private Vector2[] _outilSpawns;




    void Start()
    {
        var t = GameObject.FindGameObjectsWithTag("OutilsSpawn");
        _outilSpawns = t.Select(x => (Vector2)x.transform.position).ToArray();
        _collider = GetComponentInChildren<BoxCollider2D>();
        _sprite = GetComponent<SpriteRenderer>();
        _spriteBtn = transform.Find("actionBtn").GetComponent<SpriteRenderer>();
        slide.maxValue = _requiredPressCount;
    }
    void Update()
    {
        var x = Physics2D.BoxCast(_collider.bounds.center, _collider.bounds.size, 0f, Vector2.down, .1f, 1 << 8);

        if (_pressCount != 0 && isBroken)
        {
            if (_currentInactifTime >= _timeBeforeReset)
            {
                GetTouche();
                _currentInactifTime = 0;

            }
            _currentInactifTime += Time.deltaTime;
        }

        if (_pressCount >= _requiredPressCount)
        {
            isBroken = false;
        }

        isActive = x;
        HighLightActiveBtn();

        if (isActive)
            _sprite.color = Active;
        else
            _sprite.color = UnActive;

        if (isBroken)
        {
            if (isActive)
            {
                slide.transform.Find("Background").GetComponent<Image>().color = new Color(0.8301887f, 0.6086394f, 0.1605553f, 1);
                slide.transform.Find("Fill Area").Find("Fill").GetComponent<Image>().color = new Color(1, 1, 1, 1);
            }
                _sprite.sprite = BrokenSprite;
            AnimateSmoke();
        }
        else
        {
            if (!isActive)
            {
                slide.transform.Find("Background").GetComponent<Image>().color = new Color(0.8301887f, 0.6086394f, 0.1605553f, 0);
                slide.transform.Find("Fill Area").Find("Fill").GetComponent<Image>().color = new Color(1, 1, 1, 0);
            } else
            {
            }
                _sprite.sprite = FixedSprite;
            SmokeSprite01.sprite = null;
            SmokeSprite02.sprite = null;
            _spriteBtn.color = new Color(0, 0, 0, 0);
            KeySprite.color = new Color(0, 0, 0, 0);
        }

        slide.value = _pressCount;
    }

    public void DoRepareAction(ActionButtons btn, Outil t)
    {
        if (!isBroken || !_canPress) return;
        if (btn.Equals(_touche))
        {
            _pressCount++;
            _currentInactifTime = 0;
            _canPress = false;
            t.CurrentUse++;
            StartCoroutine(CanPressAgain());
        }
        else if (!btn.Equals(ActionButtons.None))
        {
            _currentInactifTime = 0;
            _canPress = false;
            t.CurrentUse++;
            StartCoroutine(CanPressAgain());

        }
    }

    public override void Break()
    {
        base.Break();
        SpawnOneOutil();
        GetTouche();
    }

    public void SpawnOneOutil()
    {
        var x = Instantiate(OutilToSpawn, _outilSpawns[Random.Range(0, _outilSpawns.Length)], Quaternion.identity);
        x.GetComponent<Outil>().MaxUse = _requiredPressCount;
        x.GetComponent<Outil>().papa = this;
    }

    IEnumerator CanPressAgain()
    {
        yield return new WaitForSeconds(.05f);
        _canPress = true;
    }

    private void SetupButtonSprite(ActionButtons btn)
    {
        Sprite sprt = BSprite;
        if (btn.Equals(ActionButtons.B))
            sprt = BSprite;
        else if (btn.Equals(ActionButtons.Y))
            sprt = YSprite;
        else if (btn.Equals(ActionButtons.X))
            sprt = XSprite;

        _spriteBtn.sprite = sprt;

    }

    private void HighLightActiveBtn()
    {
        if (isActive && isBroken)
        {
            _spriteBtn.color = Active;
            KeySprite.color = Active;
        }
        else
        {
            _spriteBtn.color = UnActiveBtn;
            KeySprite.color = UnActiveBtn;
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


    private void GetTouche()
    {
        _pressCount = 0;
        _touche = _possibleButtons[Random.Range(0, _possibleButtons.Length)];
        SetupButtonSprite(_touche);
    }

    public override void Action(ActionButtons btn)
    {
    }
}
