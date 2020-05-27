using UnityEngine;

public class Elevator : MonoBehaviour
{
    public float SecondesArret = 2;
    public Vector2 Etage1;
    public Vector2 Etage2;
    private bool _isGoingDown = false;
    private bool _arret;
    private float _tempsArret;
    private float _tempsTrajet = 2.25f;
    private float _dureeTrajet = 0;
    // Start is called before the first frame update
    void Start()
    {
        _dureeTrajet = 0;
    }

    // Update is called once per frame
    void Update()
    {

        if (!_arret)
        {
            var perc = _dureeTrajet / _tempsTrajet;
            var from = _isGoingDown ? Etage2 : Etage1;
            var to = _isGoingDown ? Etage1 : Etage2;
            transform.position = Vector2.Lerp(from, to, perc);
            if (perc >= 1)
            {
                _arret = true;
                _tempsArret = SecondesArret;
            }
            _dureeTrajet += Time.deltaTime;
        } 
        else
        {
            if (_tempsArret <= 0)
            {
                _arret = false;
                _dureeTrajet = 0;
                _isGoingDown = !_isGoingDown;

            }
            _tempsArret -= Time.deltaTime;
        }
    }
}
