using System.Collections;
using System.Linq;
using UnityEngine;
using UnityEngine.UI;

public class RadiationManager : MonoBehaviour
{
    private Player _player01;
    private Player _player02;

    public Slider Player01SliderPrefab;
    public Slider Player02SliderPrefab;

    private Slider _player01Slider;
    private Slider _player02Slider;

    public GameObject gameOverScreen;
    private GameObject instGameOver;

    public GameObject victoryScreen;
    private GameObject instScreen;

    public float temps = 120f;
    private float timeVic;

    private int _multiplicateur;
    public float seuil = 75f;
    public float _vitesseRadiation = 4f;
    private Machine[] _machines;

    public bool IsFinish;

    private float _time = 0;

    private void Start()
    {
        var machines = GameObject.FindGameObjectsWithTag("Machine");
        _machines = machines.Select(x => x.GetComponent<Machine>()).ToArray();
        timeVic = temps;

        StartCoroutine(SetMeToPlayer());
    }

    IEnumerator SetMeToPlayer()
    {
        yield return new WaitForSeconds(1.5f);
        if (_player01)
        _player01.RM = this;
        if (_player02)
        _player02.RM = this;
    }

    private void Update()
    {
        if (_time >= 1)
        {
            _multiplicateur = _machines.Where(x => x.isBroken).Count() + 1;
            if (_player01 != null)
                AugmentePlayerRadiation(0);
            if (_player02 != null)
                AugmentePlayerRadiation(1);

            _time = 0;
        }
        _time += Time.deltaTime;
        timeVic -= Time.deltaTime;
        if (timeVic <= 0)
            Victoire();
        if ((_player01 != null && !_player01.IsAlive) || (_player02 != null && !_player02.IsAlive))
            GameOver();
    }

    public void AugmentePlayerRadiation(int index)
    {
        if (index == 0)
        {
            _player01.AugmenteRadiation(_vitesseRadiation * _multiplicateur);
            _player01Slider.value += (_vitesseRadiation * _multiplicateur);
        }
        else if (index == 1)
        {
            _player02.AugmenteRadiation(_vitesseRadiation * _multiplicateur);
            _player02Slider.value += (_vitesseRadiation * _multiplicateur);
        }
    }

    public void ReduirePlayerRadiation(int index, float soin)
    {
        if (index == 0)
        {
            _player01.ReduireRadiation(soin * Time.deltaTime);
            _player01Slider.value -= (soin * Time.deltaTime);
        }
        else if (index == 1)
        {
            _player02.ReduireRadiation(soin * Time.deltaTime);
            _player02Slider.value -= (soin * Time.deltaTime);
        }
    }

    public void AddPlayer(Player p)
    {
        if (_player01 == null)
        {
            _player01Slider = Instantiate(Player01SliderPrefab, GameObject.Find("Canvas").transform);
            _player01 = p;
        }
        else if (_player02 == null)
        {
            _player02Slider = Instantiate(Player02SliderPrefab, GameObject.Find("Canvas").transform);
            _player02 = p;
        }
    }

    public void GameOver()
    {
        IsFinish = true;
        timeVic = temps;
        if (instGameOver == null)
        {
            if (_player01 != null)
                _player01Slider.value = 0;
            if (_player02 != null)
                _player02Slider.value = 0;
            if (instScreen == null)
            {
                instGameOver = Instantiate(gameOverScreen, GameObject.Find("Canvas").transform);
                Destroy(GameObject.Find("Canvas/Text"));
                Destroy(GameObject.Find("Canvas/Player01 Radiation(Clone)"));
                Destroy(GameObject.Find("Canvas/Player02 Radiation(Clone)"));
            }
        }
    }

    public void Victoire()
    {
        IsFinish = true;
        if (_player01 != null)
            _player01Slider.value = 0;
        if (_player02 != null)
            _player02Slider.value = 0;
        if (instScreen == null)
        {
            instScreen = Instantiate(victoryScreen, GameObject.Find("Canvas").transform);
            Destroy(GameObject.Find("Canvas/Text"));
            Destroy(GameObject.Find("Canvas/Player01 Radiation(Clone)"));
            Destroy(GameObject.Find("Canvas/Player02 Radiation(Clone)"));
        }
    }
}
