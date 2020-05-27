using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Outil : MonoBehaviour
{

    public int MaxUse = 15;
    public int CurrentUse = 0;
    public bool Useless;


    public MachineSpam papa;

    Vector3 startPos;
    public float amplitude = 10f;
    public float period = 5f;


    private bool _hasCalledSpawnTool;
    // Start is called before the first frame update
    void Start()
    {

        startPos = transform.position;

    }

    // Update is called once per frame
    void OnTriggerEnter2D(Collider2D col)
    {
    }

    public void SetPosition(Vector2 pos)
    {
        transform.position = pos;
        startPos = transform.position;
    }

    void OnTriggerExit2D(Collider2D other)
    {
    }

    void Update()
    {
        transform.Rotate(Vector3.forward * 5f * Time.deltaTime);
        float theta = Time.timeSinceLevelLoad / period;
        float distance = amplitude * Mathf.Sin(theta);
        transform.position = startPos + Vector3.up * distance;

        if (CurrentUse >= MaxUse && !Useless)
        {
            Useless = true;
        }

        if (Useless && papa.isBroken)
            papa.SpawnOneOutil();

    }
}
