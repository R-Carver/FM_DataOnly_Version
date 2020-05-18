using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using UnityEngine;

public class SkillTable : MonoBehaviour
{   
    public static SkillTable instance;

    private void Awake() 
    {
        instance = this;    
    }

    public Dictionary<PlayerSkill, Dictionary<PlayerAttribute, int>> skillConfigurationDict = new Dictionary<PlayerSkill, Dictionary<PlayerAttribute, int>>();

    // Start is called before the first frame update
    void Start()
    {
        InitHelperDicts();
        InitSkillDict();
    }

    public void InitSkillDict()
    {
        string path = "Assets/Text/SkillTable.csv";
        var data = File.ReadLines(path).Select(x => x.Split(',')).ToArray();

        for(int skill=1; skill < data.Length ; skill++)
        {
            Dictionary<PlayerAttribute, int> attributeConfRow = new Dictionary<PlayerAttribute, int>();
            for(int attr=1; attr < data[0].Length ; attr++)
            {   
                //the names of the attributes are in the first row
                PlayerAttribute currentAttr = CsvNameToAttributeEnum[data[0][attr]];
                attributeConfRow.Add(currentAttr, int.Parse(data[skill][attr]));
            }

            //the names of the akills are in the first column
            PlayerSkill currentSkill = CsvNameToSkillEnum[data[skill][0]];
            skillConfigurationDict.Add(currentSkill, attributeConfRow);
        }
    }

    //helper dict to only work with enums in unity
    public Dictionary<PlayerSkill, string> SkillEnumToCsvName = new Dictionary<PlayerSkill, string>();
    public Dictionary<string, PlayerSkill> CsvNameToSkillEnum = new Dictionary<string, PlayerSkill>();
    public Dictionary<PlayerAttribute, string> AttributeEnumToCsvName = new Dictionary<PlayerAttribute, string>();
    public Dictionary<string, PlayerAttribute> CsvNameToAttributeEnum = new Dictionary<string, PlayerAttribute>();

    void InitHelperDicts()
    {   
        string path = "Assets/Text/SkillTable.csv";
        var data = File.ReadLines(path).Select(x => x.Split(',')).ToArray();

        for(int i=1; i<data.Length ; i++)
        {
            SkillEnumToCsvName.Add((PlayerSkill)i-1, data[i][0]);
            CsvNameToSkillEnum.Add(data[i][0], (PlayerSkill)i-1);
        }

        for(int i=1; i<data[0].Length ; i++)
        {
            AttributeEnumToCsvName.Add((PlayerAttribute)i-1, data[0][i]);
            CsvNameToAttributeEnum.Add(data[0][i], (PlayerAttribute)i-1);
        }
    }
}

public enum PlayerSkill
{
    Throwing,
    ReadGame,
    Tackling,
    Catching,
    Evade,
    Kicking,
    Audibles,
    Block,
    RouteRunning,
    LegWork,
    ArmDuell,
    CarryBall,
    Release
}

public enum PlayerAttribute
{
    Jumping,
    Strength,
    Speed,
    Acceleration,
    Balance,
    Controll,
    ArmStrength,
    Height,
    Weight,
    Intelligence,
    Leadership,
    Composure,
    Intuition,
    Bravery,
    Adaptability,
    Lerning,
    Concentration
}


