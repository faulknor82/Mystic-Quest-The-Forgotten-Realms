using System.Collections;
using UnityEngine;

public class CharacterSpeed : MonoBehaviour
{
    public int level = 1;
    public int agility = 10;
    private int agilityGrowth = 2; // instead of using a magic number, this variable can be changed for progressive growth

    public float baseMovementSpeed = 5f;
    public float baseAttackSpeed = 1f;
    public float baseDodgeSpeed = 3f;

    public float movementSpeed;
    public float attackSpeed;
    public float dodgeSpeed;

    void Start()
    {
        UpdateSpeedStats();
    }

    void LevelUp()
    {
        level++;
        agility += agilityGrowth;
        UpdateSpeedStats();
    }

    void UpdateSpeedStats()
    {
        movementSpeed = baseMovementSpeed + (agility * 0.1f);
        attackSpeed = baseAttackSpeed + (agility * 0.05f);
        dodgeSpeed = baseDodgeSpeed + (agility * 0.05f);
    }

    public void ApplySpeedBuff(float movementMultiplier, float attackMultiplier, float dodgeMultiplier, float duration)
    {
        StartCoroutine(SpeedBuffCoroutine(movementMultiplier, attackMultiplier, dodgeMultiplier, duration));
    }

    private IEnumerator SpeedBuffCoroutine(float movementMultiplier, float attackMultiplier, float dodgeMultiplier, float duration)
    {
        movementSpeed *= movementMultiplier;
        attackSpeed *= attackMultiplier;
        dodgeSpeed *= dodgeMultiplier;

        yield return new WaitForSeconds(duration);

        UpdateSpeedStats(); // Revert to original speed stats after buff duration
    }
}