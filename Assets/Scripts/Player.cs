using System.Linq;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.SceneManagement;

public class Player : MonoBehaviour
{
    #region Movements
    [SerializeField]
    private PlayerInputActions _playerInputActions;
    private Vector2 _movements;
    private Vector3 _rotation;
    public float MovementSpeed;
    private bool _isGrounded
    {
        get
        {
            return Physics2D.BoxCast(_boxCollider.bounds.center, _boxCollider.bounds.size, 0f, Vector2.down, .1f, 1 << 9);

        }
    }
    private float _jumpSpeed = 20;
    private Rigidbody2D _rb;
    public float Angle;
    #endregion

    #region Animation
    [HideInInspector]
    public Sprite[] SpritesAnimation;
    [HideInInspector]
    public Sprite[] SpritesWorkingAnimation;
    public int FPS;
    public SpriteRenderer PlayerSprite;
    private int _currentSpriteIndex;
    private int _currentWorkingSpriteIndex;
    private float _animationTimer;

    public GameManager GM;
    public RadiationManager RM;

    public bool IsInMenu;
    #endregion

    #region Push
    [HideInInspector]
    public bool IsBeingPushed;
    [HideInInspector]
    public bool IsBeingPushToRight;
    private float _distToGround;
    private BoxCollider2D _boxCollider;
    private float _pushLength = .15f;
    private float _pushStartTime;
    #endregion

    #region Radioactivite
    private float _radiationLevel;
    public bool IsAlive = true;
    #endregion

    #region elevatorHelper
    private bool _inElevator;
    #endregion

    #region ActionButtons
    private ActionButtons _activeBtn = ActionButtons.None;
    #endregion

    #region Inventory
    public bool hasTool;
    private Outil _tool;
    private SpriteRenderer _srKey;
    #endregion

    private Machine _MachineInContact;
    public int PlayerIndex;
    private int _valveIndex;


    private void Awake()
    {
        _playerInputActions = new PlayerInputActions();
        _playerInputActions.Enable();
        _rb = GetComponent<Rigidbody2D>();
        _boxCollider = GetComponent<BoxCollider2D>();
    }

    void Start()
    {
        _srKey = gameObject.transform.Find("key_white").GetComponent<SpriteRenderer>();
        _distToGround = GetComponent<Collider2D>().bounds.extents.y;
    }
    #region INPUTS HANDLER 

    private void OnMove(InputValue value)
    {
        _movements = new Vector3(0, 0, 0);
        if (value.Get<Vector2>().x > 0)
            _movements.x = 1;
        else if (value.Get<Vector2>().x < 0)
            _movements.x = -1f;
        else _movements.x = 0;

    }

    private void OnStop(InputValue value)
    {
        _movements = Vector2.zero;
    }

    private void OnJump(InputValue value)
    {
        if (_isGrounded && IsAlive)
            _rb.velocity = Vector2.up * _jumpSpeed;
    }

    private void OnPush(InputValue value)
    {
        for (int i = 0; i < GetFacingContacts().Count(); i++)
        {
            GetFacingContacts()[i].transform.GetComponent<Player>().IsBeingPushToRight = transform.position.x < GetFacingContacts()[i].transform.position.x;
            GetFacingContacts()[i].transform.GetComponent<Player>().IsBeingPushed = true;
        }
    }

    private void OnDrop(InputValue value)
    {
        if (hasTool)
        {
            if (PlayerSprite.flipX)
                _tool.SetPosition(new Vector2(transform.position.x - 3f, transform.position.y));
            else
                _tool.SetPosition(new Vector2(transform.position.x + 3f, transform.position.y));
            hasTool = false;
            _tool = null;
        }
    }

    private void OnAction_X(InputValue value)
    {

        if (value.isPressed)
            _activeBtn = ActionButtons.X;
        else
        {
            _activeBtn = ActionButtons.None;
        }
    }
    private void OnAction_Y(InputValue value)
    {
        Debug.Log(value);

        if (value.isPressed)
            _activeBtn = ActionButtons.Y;
        else
        {
            _activeBtn = ActionButtons.None;
        }
    }
    private void OnAction_B(InputValue value)
    {


        if (value.isPressed)
            _activeBtn = ActionButtons.B;
        else
        {
            _activeBtn = ActionButtons.None;
        }
    }

    private void OnExit(InputValue value)
    {
        if (RM && RM.IsFinish)
            SceneManager.LoadScene(0);
        if (IsInMenu)
        {
#if UNITY_EDITOR
            // Application.Quit() does not work in the editor so
            // UnityEditor.EditorApplication.isPlaying need to be set to false to end the game
            UnityEditor.EditorApplication.isPlaying = false;
#else
         Application.Quit();
#endif
        }
    }

    private void OnStart(InputValue value)
    {
        if ((RM && RM.IsFinish) || IsInMenu)
            SceneManager.LoadScene(1);
    }

    private void OnRightJoystickRotation(InputValue value)
    {
        _rotation = new Vector3(0, 0, Mathf.Atan2(value.Get<Vector2>().y, value.Get<Vector2>().x) * 180 / Mathf.PI);
    }
    #endregion
    private void AnimateMovements()
    {
        if (_MachineInContact && _activeBtn.Equals(ActionButtons.None) && _MachineInContact.isActive && _MachineInContact.isBroken && _movements == Vector2.zero)
        {
            if (_animationTimer > 1f / 10)
            {
                PlayerSprite.sprite = SpritesWorkingAnimation[_currentWorkingSpriteIndex];
                _currentWorkingSpriteIndex++;

                if (_currentWorkingSpriteIndex >= SpritesWorkingAnimation.Length)
                    _currentWorkingSpriteIndex = 0;

                _animationTimer = 0;
            }
            _animationTimer += Time.deltaTime;
        }
        else
        {
            if (!_isGrounded)
                PlayerSprite.sprite = SpritesAnimation[1];
            else if (_movements.x != 0)
            {
                if (_animationTimer > 1f / FPS)
                {
                    PlayerSprite.sprite = SpritesAnimation[_currentSpriteIndex];
                    _currentSpriteIndex++;

                    if (_currentSpriteIndex >= SpritesAnimation.Length)
                        _currentSpriteIndex = 0;

                    _animationTimer = 0;
                }
                _animationTimer += Time.deltaTime;
            }
            else
            {
                PlayerSprite.sprite = SpritesAnimation[0];
            }
        }
    }

    private void FlipSprite()
    {
        if (_movements.x > 0)
            PlayerSprite.flipX = false;
        else if (_movements.x < 0)
            PlayerSprite.flipX = true;
    }

    private void Move()
    {
        if (HasFacingContacts())
        {
            _rb.velocity = new Vector2(0, _rb.velocity.y);
            return;
        }
        float midAirControl = 1.5f;
        if (_isGrounded)
        {
            if (!IsBeingPushed)
            {
                if (IsAlive)
                    _rb.velocity = new Vector2(_movements.x * MovementSpeed, _rb.velocity.y);
                else
                    _rb.velocity = Vector2.zero;
            }
        }
        else
        {
            if (!IsAlive)
                _movements.x = 0;

            _rb.velocity += new Vector2(_movements.x * (MovementSpeed * midAirControl), 0);
            _rb.velocity = new Vector2(Mathf.Clamp(_rb.velocity.x, -MovementSpeed, MovementSpeed), _rb.velocity.y);


            if (_rb.velocity.y < 0)
                _rb.velocity += Vector2.up * Physics2D.gravity.y * 3.9f * Time.deltaTime;
            else if (_rb.velocity.y > 0)
                _rb.velocity += Vector2.up * Physics2D.gravity.y * 2.8f * Time.deltaTime;

        }

    }

    public void BePushed()
    {

        if (_pushStartTime < _pushLength && IsBeingPushed)
        {
            _rb.AddForce(Vector2.right * (IsBeingPushToRight ? 2.5f : -2.5f), ForceMode2D.Impulse);
            _pushStartTime += Time.deltaTime;
        }
        else
        {
            _pushStartTime = 0;
            IsBeingPushed = false;
            IsBeingPushToRight = false;
        }
    }

    public void AugmenteRadiation(float amount)
    {
        _radiationLevel += amount;
    }
    public void ReduireRadiation(float amount)
    {
        _radiationLevel -= amount;
    }

    private RaycastHit2D[] GetFacingContacts()
    {

        RaycastHit2D[] contacts = Physics2D.BoxCastAll(_boxCollider.bounds.center, _boxCollider.bounds.size, 0f, PlayerSprite.flipX ? Vector2.left : Vector2.right, .1f, 1 << 8);

        if (PlayerSprite.flipX)
            return contacts.Where(x => x.transform.gameObject != transform.gameObject && x.transform.position.x < transform.position.x).ToArray();
        else
            return contacts.Where(x => x.transform.gameObject != transform.gameObject && x.transform.position.x > transform.position.x).ToArray();
    }

    private bool HasFacingContacts()
    {
        return GetFacingContacts().Count() > 0;
    }

    private void CheckIfAlive()
    {
        IsAlive = _radiationLevel < 100;
    }

    // Update is called once per frame
    void Update()
    {
        CheckIfAlive();
        Move();

        if (hasTool && _tool != null)
        {
            if (_tool.Useless)
            {
                hasTool = false;
                Destroy(_tool.gameObject);
                _tool = null;

            }
            _srKey.color = new Color(1, 1, 1, 1);
        } else
        {
            _srKey.color = new Color(1, 1, 1, 0);
        }

        if (IsAlive)
        {
            AnimateMovements();
            BePushed();
            FlipSprite();
        }

        if (_MachineInContact)
        {
            if (_MachineInContact.TryGetComponent<ValveMachine>(out ValveMachine comp))
            {
                var angle = Mathf.Round(_rotation.z);
                Angle = angle;
                if (angle == 0)
                    comp.JoystickRotation(ActionButtons.None, _valveIndex);
                else if (angle >= -45 && angle < 45)
                    comp.JoystickRotation(ActionButtons.JoystickRight, _valveIndex);
                else if (angle < -45 && angle > -135)
                    comp.JoystickRotation(ActionButtons.JoystickBot, _valveIndex);
                else if ((angle <= 180 && angle > 135) || (angle <= -135 && angle >= -180))
                    comp.JoystickRotation(ActionButtons.JoystickLeft, _valveIndex);
                else
                    comp.JoystickRotation(ActionButtons.JoystickTop, _valveIndex);
            }
            else if (_MachineInContact.TryGetComponent<MachineSpam>(out MachineSpam putainjesuisfatigue))
            {
                if (hasTool && _tool != null)
                {
                    putainjesuisfatigue.DoRepareAction(_activeBtn, _tool);
                }
            }
                _MachineInContact.Action(_activeBtn);
        }
    }

    private void FixedUpdate()
    {
        if (_inElevator && _isGrounded)
        {
            RaycastHit2D hit = Physics2D.Raycast(transform.position, Vector2.down);
            if (hit && hit.transform.CompareTag("Elevator"))
            {
                _rb.position = new Vector2(transform.position.x, hit.point.y);
                transform.position = new Vector2(transform.position.x, hit.point.y);
            }
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Elevator"))
            _inElevator = true;
        if (collision.transform.parent && collision.transform.parent.TryGetComponent<Machine>(out Machine comp) && collision.transform.CompareTag("Btn"))
        {
            if (collision.transform.name.Equals("LeftValve"))
                _valveIndex = 0;
            else if (collision.transform.name.Equals("RightValve"))
                _valveIndex = 1;
            _MachineInContact = comp;
        }
        if (collision.CompareTag("Outil") && !hasTool)
        {
           if (collision.TryGetComponent<Outil>(out Outil outil))
            {
                outil.SetPosition(new Vector2(150, 0));
                _tool = outil;
                hasTool = true;
            }
        }

    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("Elevator"))
            _inElevator = false;
        if (collision.transform.parent && collision.transform.parent.TryGetComponent<Machine>(out Machine comp) && collision.transform.CompareTag("Btn"))
        {
            if (_MachineInContact != null && comp == _MachineInContact)
            {
                _MachineInContact = null;
            }
            if (collision.transform.name.Equals("LeftValve") && _valveIndex == 0)
                _valveIndex = -1;
            else if (collision.transform.name.Equals("RightValve") && _valveIndex == 1)
                _valveIndex = -1;
        }
    }

    public float GetRadiation()
    {
        return _radiationLevel;
    }
}
