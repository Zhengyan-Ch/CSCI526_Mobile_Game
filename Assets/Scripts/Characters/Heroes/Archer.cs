﻿using UnityEngine;
using System.Collections;


/// <summary>
/// Archer.
/// </summary>
public class Archer : BaseHero {
    public static Archer instance = null;

    private static readonly object padlock = new object();

    public ArcherLeveling LevelManager;

    //Skill fields
    StatModifier ATKSpeedModifierBySkill;

    new void Start() {
        if (instance == null)
        {
            lock (padlock)
            {
                if (instance == null)
                {
                    instance = new Archer();
                }
            }
        }
        instance = this;

        HeroPool.GetInstance().SetHero(this, "Archer");

        //  Object.DontDestroyOnLoad(instance);
        LevelManager = new ArcherLeveling(this, ArcherConfig.Level);

        SkillIsReady = true;
        HeroAnimator = GetComponent<Animator>();

        LoadAttr();

        InvokeRepeating("UpdateTarget", 0f, 0.5f);
    }

    protected override void Attack() {
        if (HeroAnimator != null) {
            HeroAnimator.SetBool("CanAttack", true);
        }
        GameObject bulletGO = (GameObject)Instantiate(bulletPrefab, firePoint.position, firePoint.rotation);
        Bullet bullet = bulletGO.GetComponent<Bullet>();
        bullet.damage = 0.3f * ATKValue;
        bullet.ACC = ACCValue;
        bullet.criticalDamage = CritDMGValue;
        bullet.critical = CritValue;
        if (bullet != null) {
        	bullet.Seek(Target);
        }
    }


    public override void ExSkill() {
        //duration time
        Debug.Log("Attack Speed Up");

        ATKSpeed.AddModifier(ATKSpeedModifierBySkill);
        attackRate = ATKSpeedValue;
        StartCoroutine("SkillDuration");
    }


    public override IEnumerator SkillCooldown() {
        yield return new WaitForSeconds(ArcherConfig.SkillCooldownTime);
        SkillIsReady = true;
    }


    IEnumerator SkillDuration() {
        yield return new WaitForSeconds(3f);
        Debug.Log("Attack Speed back to normal");

        ATKSpeed.RemoveModifier(ATKSpeedModifierBySkill);
        attackRate = ATKSpeedValue;  //3 attacks per second
    }


    //TODO: change back to private (currently set to pulbic for testing purpose)
    public void LoadAttr() {
        //special
        Range = new CharacterAttribute(ArcherConfig.Range);

        //skill
        ATKSpeedModifierBySkill = new StatModifier(ArcherConfig.ATKSpeedPercent, StatModType.PercentAdd);

        CharacterName = ArcherConfig.CharacterName;
        CharacterDescription = ArcherConfig.CharacterDescription;

        MaxHP = new CharacterAttribute(ArcherConfig.MaxHPValue);
        CurHP = MaxHPValue;

        ATK = new CharacterAttribute(ArcherConfig.ATKValue);
        MATK = new CharacterAttribute(ArcherConfig.MATKValue);

        PDEF = new CharacterAttribute(ArcherConfig.PDEFValue);
        MDEF = new CharacterAttribute(ArcherConfig.MDEFValue);

        Crit = new CharacterAttribute(ArcherConfig.CritValue);
        CritDMG = new CharacterAttribute(ArcherConfig.CritDMGValue);

        Pernetration = new CharacterAttribute(ArcherConfig.PernetrationValue);
        ACC = new CharacterAttribute(ArcherConfig.ACCValue);
        Dodge = new CharacterAttribute(ArcherConfig.DodgeValue);
        Block = new CharacterAttribute(ArcherConfig.BlockValue);
        CritResistance = new CharacterAttribute(ArcherConfig.CritResistanceValue);

        ATKSpeed = new CharacterAttribute(ArcherConfig.ATKSpeedValue);
        attackRate = ATKSpeedValue;  //3 attacks per second
    }
}
