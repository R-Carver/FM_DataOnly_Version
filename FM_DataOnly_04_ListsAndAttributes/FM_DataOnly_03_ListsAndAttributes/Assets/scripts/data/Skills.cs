using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Skills
{   
    [FmDbField] public int throwing;
    [FmDbField] public int readGame;
    [FmDbField] public int tackling;
    [FmDbField] public int catching;
    [FmDbField] public int evade;
    [FmDbField] public int kicking;
    [FmDbField] public int audibles;
    [FmDbField] public int block;
    [FmDbField] public int routeRunning;
    [FmDbField] public int legWork;
    [FmDbField] public int armDuell;
    [FmDbField] public int carryBall;
    [FmDbField] public int release;

    public Skills(Attributes attr)
    {
        CalculateSkills(attr);
    }

    public void CalculateSkills(Attributes attr)
    {
        this.throwing = GetSkillValue(PlayerSkill.Throwing, attr);
        this.readGame = GetSkillValue(PlayerSkill.ReadGame, attr);
        this.tackling = GetSkillValue(PlayerSkill.Tackling, attr);
        this.catching = GetSkillValue(PlayerSkill.Catching, attr);
        this.evade = GetSkillValue(PlayerSkill.Evade, attr);
        this.kicking = GetSkillValue(PlayerSkill.Kicking, attr);
        this.audibles = GetSkillValue(PlayerSkill.Audibles, attr);
        this.block = GetSkillValue(PlayerSkill.Block, attr);
        this.routeRunning = GetSkillValue(PlayerSkill.RouteRunning, attr);
        this.legWork = GetSkillValue(PlayerSkill.LegWork, attr);
        this.armDuell = GetSkillValue(PlayerSkill.ArmDuell, attr);
        this.carryBall = GetSkillValue(PlayerSkill.CarryBall, attr);
        this.release = GetSkillValue(PlayerSkill.Release, attr);
    }

    /*
    For the skill value all we multiply all attributes with their scalar weights of importance 
    However this is a complicated calculation and should maybe be refactored in a later version

    1) Get the maximum possible value for a skill:
    This means multiplying each scalar value of the current skill with 99

    2) Get the real player value by multiplying each scalar with the actual player values

    3) (real sum/max sum) * 100 rounded to the next int
    */
    int GetSkillValue(PlayerSkill skillName, Attributes attr)
    {
        Dictionary<PlayerAttribute,int> currentSkillConf = SkillTable.instance.skillConfigurationDict[skillName]; 

        int maxValue = 99;

        int maxSum = 0;
        int realSum = 0;

        //1)and 2) Get the maximum and the real values
        foreach(PlayerAttribute key in currentSkillConf.Keys)
        {   
            int attrValue = attr.nameToAttribute[key];
            int currentScalar = currentSkillConf[key];
            
            maxSum += maxValue * currentScalar;
            realSum += attrValue * currentScalar;
            
        }

        // (real sum/max sum) * 100 rounded to the next int
        float rawResult = (float)realSum/(float)maxSum;
        float roundedResult = (float)Math.Round(rawResult, 2);

        int finalResult = Mathf.RoundToInt(roundedResult * 100);

        return finalResult;
    }
}
