using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Enemy", menuName = "ScriptableObject/Enemy")]
public class EnemyStats : ScriptableObject
{
    public float health;
    public float speed;
    public Color colour;
}
