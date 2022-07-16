using System.Collections;
using UnityEngine;

public class EnemyParameters
{
    // Speed of the projectiles
    public float shootSpeed;

    // Speed of the enemy
    public float moveSpeed;

    // Number of waves of missiles the enmy will fire
    public int ammo;

    // Enemy will fire missiles of this pattern
    public int attackPattern;

    // Point where enemy will stop, shoot, then change velocity
    public Vector2 pausePoint;

    // Initial spawn point, where the enemy flies in from, selected from an array
    public Vector2 spawnLocation;

    // Exit point, where the enemy flies away to, selected from an array
    public Vector2 exitLocation;

    // Determines whether enemy stops and shoots or moves while shooting
    public int shootBehaviour;

    // For moves while shooting, partition screen to select when to shoot based on X pos
    public int xPartition;

    // For moves while shooting, partition screen to select when to shoot based on Y pos
    public int yPartition;

    public EnemyParameters(float shootSpeed, float moveSpeed, int ammo, int attackPattern, Vector2 pausePoint, Vector3 spawnLocation, Vector3 exitLocation, int shootBehaviour, int xPartition, int yPartition) 
    {
        this.shootSpeed = shootSpeed;
        this.moveSpeed = moveSpeed;
        this.ammo = ammo;
        this.attackPattern = attackPattern;
        this.pausePoint = pausePoint;
        this.spawnLocation = spawnLocation;
        this.exitLocation = exitLocation;
        this.shootBehaviour = shootBehaviour;
        this.xPartition = xPartition;
        this.yPartition = yPartition;
    }
}
