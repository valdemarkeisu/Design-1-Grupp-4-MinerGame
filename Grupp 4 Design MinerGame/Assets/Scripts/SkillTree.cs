using NUnit.Framework;
using System.Collections.Generic;
using UnityEngine;

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

    public int Leaf;
    public int Stone;
    public int Iron;
    public int Crystal;

    private void Start()
    {
        Leaf = 20;

        SkillLevels = new int[6];
        SkillCaps = new[] { 0, 1, 2, 3, 4, 5, };

        SkillNames = new[] { "Upgrade 1", "Upgrade2", "Upgrade3", "Upgrade4", "Upgrade5" };
        SkillDescription = new[] {
        "Skill 1",
        "Skill 2",
        "Skill 3",
        "Skill 4",
        "Skill 5",
        "Skill 6"
        };


        foreach (var skill in SkillHolder.GetComponentsInChildren<Skill>()) SkillList.Add(skill);
  



    }



}
