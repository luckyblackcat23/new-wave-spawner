using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using PathCreation;

public class Enemy : MonoBehaviour
{
    public EndOfPathInstruction endOfPathInstruction;
    public PathGenerator pathGen;
    public EnemyStats stat;
    public float health;
    float dstTravelled;
    private bool b = true;
    //you may be asking the use of this object...
    //and that i would like to answer with...
    //"you spin me right round, baby right round like a record baby, right round, right round"
    private GameObject rot;

    private int i;
    void Update()
    {
        if(pathGen != null)
        {
            if (b)
            {
                rot = new GameObject("rot");
                b = false;
            }
            dstTravelled += stat.speed * Time.deltaTime;
            transform.position = pathGen.pathCreator.path.GetPointAtDistance(dstTravelled, endOfPathInstruction);
            rot.transform.position = pathGen.pathCreator.path.GetPointAtDistance(dstTravelled, endOfPathInstruction);
            rot.transform.rotation = pathGen.pathCreator.path.GetRotationAtDistance(dstTravelled, endOfPathInstruction);
            //i will never understand quaternions
            transform.rotation = Quaternion.Euler(0, 0, rot.transform.rotation.eulerAngles.x * -1);
            if (transform.position == pathGen.pathCreator.path.GetPoint(pathGen.pathCreator.path.NumPoints - 1))
            {
                Destroy(gameObject);
                Destroy(rot);
            }
        }

        if (health <= 0)
        {
            SpawnWave.enemiesAlive--;
            Destroy(gameObject);
        }
    }
}