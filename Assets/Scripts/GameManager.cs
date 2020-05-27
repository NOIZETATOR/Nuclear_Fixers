using System.Collections;
using System.Linq;
using UnityEngine;
using UnityEngine.InputSystem;

public class GameManager : MonoBehaviour
{
    private PlayerInputManager _playerInputManager;

    public Sprite[] Player01;
    public Sprite[] Player01Working;
    public Sprite[] Player02;
    public Sprite[] Player02Working;
    public Transform Player01Spawn;
    public Transform Player02Spawn;

    private Machine[] _machines;

    public float _breakMachineMinCD = 9f;
    public float _breakMachineMaxCD = 14f;
    private float _currentCD = 1.5f;

    private bool _firstReduceDone;
    private bool _secondReduceDone;
    private bool _thirdReduceDone;
    private bool _fourthReduceDone;

    public TimerManager TimeManager;
    private bool _hasStarted;
    // Start is called before the first frame update
    void Start()
    {
        _playerInputManager = GetComponent<PlayerInputManager>();
        _playerInputManager.onPlayerJoined += _playerInputManager_onPlayerJoined;
        var pp = InputDevice.all.Where(x => x.layout == "XInputControllerWindows" || x.layout == "Gamepad").ToArray();
        if (pp.Count() >= 1)
        _playerInputManager.JoinPlayer(0, -1, "Xbox", pp[0]);
        if (pp.Count() >= 2)
        _playerInputManager.JoinPlayer(1, -1, "Xbox", pp[1]);

        _playerInputManager.DisableJoining();
        var machines = GameObject.FindGameObjectsWithTag("Machine");
        _machines = machines.Select(x => x.GetComponent<Machine>()).ToArray();
        StartCoroutine(StartDestruction());
        StartCoroutine(StartDestructionb());
    }
    IEnumerator StartDestructionb()
    {
        yield return new WaitForSeconds(3f);
    }
    IEnumerator StartDestruction()
    {
        yield return new WaitForSeconds(1.5f);
        _hasStarted = true;
    }

    private void BreakRandomMachine()
    {
        var t= _machines.Where(x => !x.isBroken).ToArray();
        if (t.Count() > 0)
        {
            t[Random.Range(0, t.Count())].Break();
        }
        _currentCD = Random.Range(_breakMachineMinCD, _breakMachineMaxCD);

    }

    private void _playerInputManager_onPlayerJoined(PlayerInput obj)
    {
        if (obj.playerIndex == 0)
        {
            obj.transform.GetComponent<Player>().SpritesAnimation = Player01;
            obj.transform.GetComponent<Player>().SpritesWorkingAnimation = Player01Working;
            obj.transform.GetComponent<Player>().PlayerIndex = 0;
            obj.transform.GetComponent<Player>().GM = this;
            obj.transform.position = Player01Spawn.position;
            obj.transform.name = "Player 01";
            
            GetComponent<RadiationManager>().AddPlayer(obj.transform.GetComponent<Player>());
        }
        else if (obj.playerIndex == 1)
        {
            obj.transform.GetComponent<Player>().SpritesAnimation = Player02;
            obj.transform.GetComponent<Player>().SpritesWorkingAnimation = Player02Working;
            obj.transform.GetComponent<Player>().PlayerIndex = 1;
            obj.transform.GetComponent<Player>().GM = this;
            obj.transform.position = Player02Spawn.position;
            obj.transform.name = "Player 02";
            GetComponent<RadiationManager>().AddPlayer(obj.transform.GetComponent<Player>());
        }

    }

    // Update is called once per frame
    void Update()
    {
        if (!_hasStarted)
            return;
        if (_currentCD <= 0)
            BreakRandomMachine();

        if (TimeManager.TimePerc >= 0.7  && !_fourthReduceDone)
        {
            _breakMachineMinCD -= 1;
            _breakMachineMaxCD -= 4;
            _fourthReduceDone = true;
            Debug.Log("Reducing");
        }
        if (TimeManager.TimePerc >= 0.5 && !_thirdReduceDone)
        {
            _breakMachineMinCD -= 2;
            _breakMachineMaxCD -= 3;
            _thirdReduceDone = true;
                            Debug.Log("Reducing");

        }
        if (TimeManager.TimePerc >= 0.3 && !_secondReduceDone)
        {
            _breakMachineMinCD -= 2;
            _breakMachineMaxCD -= 3;
            _secondReduceDone = true;
            Debug.Log("Reducing");

        }
        if (TimeManager.TimePerc >= 0.15 && !_firstReduceDone)
        {
            Debug.Log("Reducing");
            _breakMachineMinCD -= 3;
            _breakMachineMaxCD -= 2;
            _firstReduceDone = true;
        }

        _currentCD -= Time.deltaTime;

    }

}
