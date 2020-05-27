using UnityEngine;
using UnityEngine.InputSystem;

public class GameManager : MonoBehaviour
{
    private PlayerInputManager _playerInputManager;

    public Sprite[] Player01;
    public Sprite[] Player02;
    public Transform Player01Spawn;
    public Transform Player02Spawn;
    public float Timer;


    // Start is called before the first frame update
    void Start()
    {
        _playerInputManager = GetComponent<PlayerInputManager>();
        _playerInputManager.onPlayerJoined += _playerInputManager_onPlayerJoined;
    }

    private void _playerInputManager_onPlayerJoined(PlayerInput obj) //Spawn des players
    {
        if (obj.playerIndex == 0)
        {
            obj.transform.GetComponent<Player>().SpritesAnimation = Player01;
            obj.transform.GetComponent<Player>().PlayerIndex = 0;
            obj.transform.position = Player01Spawn.position;
            obj.transform.name = "Player 01";
            GetComponent<RadiationManager>().AddPlayer(obj.transform.GetComponent<Player>());
        }
        else if (obj.playerIndex == 1)
        {
            obj.transform.GetComponent<Player>().SpritesAnimation = Player02;
            obj.transform.GetComponent<Player>().PlayerIndex = 1;
            obj.transform.position = Player02Spawn.position;
            obj.transform.name = "Player 02";
            GetComponent<RadiationManager>().AddPlayer(obj.transform.GetComponent<Player>());
        }

    }
   



    // Update is called once per frame
    void Update()
    {
        
    }

}
