using NUnit.Framework;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SkillTree : MonoBehaviour
{
    public static SkillTree skillTree;
    private void Awake() => skillTree = this;

    public int[] SkillLevels;
    public int[] SkillCaps;

    public string[] SkillNames;
    public string[] SkillDescription;

    public List<Skill> SkillList;
    public GameObject SkillHolder;

    public List<GameObject> ConnectorList;
    public GameObject ConnectorHolder;

    public int Leaf;

   
    private void Start()
    {
        

        Leaf = 20;

        SkillLevels = new int[13];
        SkillCaps = new[] { 
        3,1,1,1,5,5,5,4,20,5,1,1,1};

        SkillNames = new[] { 
        "Base Amount",
        "Stone",
        "Iron",
        "Crystal",
        "Start Spawns",
        "Continius Spawns",
        "Spawns on break",
        "Dmg Amount",
        "Time",
        "Recource multi",
        "No more bushes",
        "Crytals only",
        "4 x dmg",
        };
        SkillDescription = new[] {
        "Base value += 1",
        "Stones start spawning are worth 4 leafes",
        "Iron start spawning are worth 20",
        "Crystal start spawning are worth 100 leafes",
        "Base recource spawn amount += 2",
        "Recource/3sec += 1",
        "On break spawn recource +=1",
        "Base dmg += 5",
        "Time += 1",
        "Recource value * 1.5",
        "Remove Bushes from recource pool",
        "Skill Remove all other recources from pool except crystal",
        "Dmg * 4",
        };


        foreach (var skill in SkillHolder.GetComponentsInChildren<Skill>()) SkillList.Add(skill);
        foreach (RectTransform connector in ConnectorHolder.GetComponentsInChildren<RectTransform>())
        {
            ConnectorList.Add(connector.gameObject);

            var img = connector.GetComponent<Image>();
            if (img != null)
                img.enabled = false;
        }

        for (var i = 0; i < SkillList.Count; i++) SkillList[i].id = i;
        SkillList[0].ConnectedSkills = new[] {1,7,8,4};
        SkillList[1].ConnectedSkills = new[] {2,9};
        SkillList[2].ConnectedSkills = new[] {3,10};
        SkillList[3].ConnectedSkills = new[] {11};
        SkillList[4].ConnectedSkills = new[] {5,6};
        SkillList[7].ConnectedSkills = new[] {12};



        UpdateAllSkillUi();

    }

    public void UpdateAllSkillUi()
    {
        foreach (var skill in SkillList) skill.UpdateUi();
    }

    public void ApplySkillEffect(int skillId)
    {
        var stats = PlayerStats.instance;

        switch (skillId)
        {
            case 0: // Base Amount
                stats.baseValue += 1;
                break;
            case 1: // Stone
                stats.Stone = true;
                break;
            case 2: // Iron
                stats.Iron = true;
                break;
            case 3: // Crystal
                stats.Crystal = true;
                break;
            case 4: // Start Spawns
                stats.resourcesPerSpawn += 2;
                break;
            case 5: // Continuous Spawns
                stats.resourcesPerSpawn += 1;
                break;
            case 6: // Spawns on break
                stats.resourcesPerSpawn += 1;
                break;
            case 7: // Dmg Amount
                stats.baseDamage += 5;
                break;
            case 8: // Time
                stats.spawnInterval += 1f;
                break;
            case 9: // Resource multi
                stats.resourceMultiplier *= 1.5f;
                break;
            case 10: // No more bushes
                stats.noBushes = true;
                break;
            case 11: // Crystals only
                stats.crystalOnly = true;
                break;
            case 12: // 4x dmg
                stats.baseDamage *= 4;
                break;
        }

    }

    }
