using TMPro;
using UnityEngine;
using static SkillTree;


public class Skill : MonoBehaviour
{
    public int id;

    public TMP_Text TitleText;
    public TMP_Text DescritionText;

    public int[] ConnectedSkills;

    public void UpdateUi()
    {
        TitleText.text = $"{skillTree.SkillLevels[id]}/{skillTree.SkillCaps[id]}\n{SkillTree.skillTree.SkillNames[id]}";
    }












}
