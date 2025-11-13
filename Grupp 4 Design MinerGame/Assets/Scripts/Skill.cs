using TMPro;
using UnityEngine;
using UnityEngine.UI;
using static SkillTree;


public class Skill : MonoBehaviour
{
    public int id;
    [SerializeField] public int cost;

    public TMP_Text TitleText;
    public TMP_Text DescritionText;

    public int[] ConnectedSkills;


    public void UpdateUi()
    {
        TitleText.text = $"{skillTree.SkillLevels[id]}/{skillTree.SkillCaps[id]}\n{SkillTree.skillTree.SkillNames[id]}";
        DescritionText.text = $"{skillTree.SkillDescription[id]}\nCost: {skillTree.Leaf}/{cost}";

        GetComponent<Image>().color = skillTree.SkillLevels[id] >= skillTree.SkillCaps[id] ? Color.yellow
            : skillTree.Leaf > 0 ? Color.green : Color.white ;

        foreach (var connectedSkill in ConnectedSkills)
        {
            skillTree.SkillList[connectedSkill].gameObject.SetActive(skillTree.SkillLevels[id] > 0);
            skillTree.ConnectorList[connectedSkill].SetActive(skillTree.SkillLevels[id] > 0);
        }
    }
    
    public void Buy()
    {
        if (skillTree.Leaf < 1 || skillTree.SkillLevels[id] >= skillTree.SkillCaps[id]) return;
        skillTree.Leaf -= cost;
        skillTree.SkillLevels[id]++;
        skillTree.UpdateAllSkillUi();
        skillTree.ApplySkillEffect(id);

    }











}
