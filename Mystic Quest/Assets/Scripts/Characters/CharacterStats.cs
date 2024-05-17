using UnityEngine;

public class CharacterStats : MonoBehaviour
{
    public int level = 1;
    public int experiencePoints = 0;
    public int health = 100;
    private int healthGrowth = 10; // instead of using a magic number, this variable can be changed for progressive growth
    public int mana = 50;
    private int manaGrowth = 5;
    public int stamina = 50;
    private int staminaGrowth = 5;
    public int strength = 10;
    private int strengthGrowth = 2;
    public int agility = 10;
    private int agilityGrowth = 2;
    public int intelligence = 10;
    private int intelligenceGrowth = 2;
    public int endurance = 10;
    private int enduranceGrowth = 2;
    public int luck = 10;
    private int luckGrowth = 1;

    void LevelUp()
    {
        level++;
        health += healthGrowth;
        mana += manaGrowth;
        stamina += staminaGrowth;
        strength += strengthGrowth;
        agility += agilityGrowth;
        intelligence += intelligenceGrowth;
        endurance += enduranceGrowth;
        luck += luckGrowth;
    }

    public void GainExperience(int amount)
    {
        experiencePoints += amount;
        // Check if enough experience points are gained for leveling up
        if (experiencePoints >= RequiredExperienceForNextLevel())
        {
            experiencePoints -= RequiredExperienceForNextLevel();
            LevelUp();
        }
    }

    private int RequiredExperienceForNextLevel()
    {
        // Example formula for required experience (this can be adjusted)
        return level * 100;
    }
}