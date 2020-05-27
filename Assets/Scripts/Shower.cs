using UnityEngine;

public class Shower : Machine
{
    // Start is called before the first frame update
    public Collider2D BtnCollider;
    public Collider2D DoucheCollider;

    private SpriteRenderer _sprite;
    public Color UnActive;
    public Color Active;

    public Sprite[] SpritesAnimation;
    public Sprite ShowerOffSprite;
    public int FPS;
    public SpriteRenderer ShowerSprite;
    private int _currentSpriteIndex;
    private float _animationTimer;

    private bool _Showering;
    private RadiationManager _radiationManager;

    void Start()
    {
        _sprite = GetComponent<SpriteRenderer>();
        _radiationManager = FindObjectOfType<RadiationManager>();
    }

    // Update is called once per frame
    void Update()
    {
        isBroken = false;
        isActive = Physics2D.BoxCast(BtnCollider.bounds.center, BtnCollider.bounds.size, 0f, Vector2.down, .1f, 1 << 8);

        if (isActive)
            _sprite.color = Active;
        else
            _sprite.color = UnActive;

        if (!isActive)
            AnimateShower(false);
    }

    public override void Break()
    {
        return;
    }

    public override void Action(ActionButtons btn)
    {
        if (btn == ActionButtons.B)
        {
            HealPlayer();
            AnimateShower(true);
            _Showering = true;
        } else
        {
            AnimateShower(false);
            _Showering = false;
        }
    }
    public void HealPlayer()
    {
       RaycastHit2D hit =  Physics2D.BoxCast(DoucheCollider.bounds.center, DoucheCollider.bounds.size, 0f, Vector2.down, .1f, 1 << 8);
        if (hit && hit.transform.TryGetComponent<Player>(out Player comp))
            _radiationManager.ReduirePlayerRadiation(comp.PlayerIndex, 35);
    }

    public void AnimateShower(bool on)
    {
        if (on)
        {
            if (_animationTimer > 1f / FPS)
            {
                ShowerSprite.sprite = SpritesAnimation[_currentSpriteIndex];
                _currentSpriteIndex++;

                if (_currentSpriteIndex >= SpritesAnimation.Length)
                    _currentSpriteIndex = 0;

                _animationTimer = 0;
            }
            _animationTimer += Time.deltaTime;
        } else
        {
            ShowerSprite.sprite = ShowerOffSprite;
        }
    }
}
