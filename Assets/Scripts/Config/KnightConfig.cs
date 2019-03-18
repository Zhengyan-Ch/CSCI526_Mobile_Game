﻿using System;

[Serializable]
public static class KnightConfig {
    //special attrs

    //level up related bonus
    public static float MaxHPBonus = 30f;
    public static float ATKBonus = 2f;
    public static float MATKBonus = 1f;
    public static float PDEFBonus = 5f;
    public static float MDEFBonus = 5f;


    //common
    public static int Level = 1;
    public static float Range = 8f;

    public static string CharacterName = "Loman";
    public static string CharacterDescription = "A descendant of Loman’s family, who has been gatekeeping the Orvelia for generations.";

    public static float MaxHPValue = 200f;

    public static float ATKValue = 10f;
    public static float MATKValue = 10f;

    public static float PDEFValue = 30f;
    public static float MDEFValue = 30f;

    public static float CritValue = 0.1f;
    public static float CritDMGValue = 0.2f;

    public static float PernetrationValue = 0f;
    public static float ACCValue = 1f;
    public static float DodgeValue = 0f;
    public static float BlockValue = 0f;
    public static float CritResistanceValue = 0.1f;

    public static float ATKSpeedValue = 0.8f;  // 0.8 attack per second
}