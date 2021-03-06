﻿using System.IO;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UnEquipmentNode : MonoBehaviour
{
    private Equipment equipment;
    public GameObject ui;
    public Text euipmentName;
    public Text value;
    public Text PDEF;
    public Text MDEF;
    public Text FirstAttribute;
    public Text SecondAttribute;
    public Text Type;
    public Image image;
    private string hero = null;
    public int index;
    public List<GameObject> tempList;

    void Start()
    {
        ui.SetActive(true);
    }

    public void equip()
    {
        GameObject cubeF = GameObject.Find("HasEquipmentNode");
        if (hero == null)
        {
            return;
        }
        HasEquipmentNode t = cubeF.GetComponent<HasEquipmentNode>();
        if (cubeF == null) return;
        Equipment temp = t.equipment;
        equipment.AddEquipToHero(hero);
        t.set(equipment, equipment.EquipmentType);
        if(temp == null)
        {
            Debug.Log(index);
            Debug.Log(tempList.Count);
            Destroy(tempList[index]);
            tempList.Remove(tempList[index]);
            for(int i = index; i < tempList.Count; i++)
            {
                GameObject ob = tempList[i];
                UnEquipmentNode m = ob.GetComponent<UnEquipmentNode>();
                m.index = m.index - 1;
                m.transform.position = new Vector3(m.transform.position.x, m.transform.position.y + 150f, m.transform.position.z);
            }
        }
       /* else
        {
            Set(temp);
        }*/
        Set(temp);
    }

    public void sell()
    {
        //PlayerStats.Money += equipment.value;
        equipment.Destroy();
        Debug.Log(tempList.Count == 0);
        if (tempList != null && tempList.Count != 0)
        {
            Destroy(tempList[index]);
            tempList.Remove(tempList[index]);
        }
        for (int i = index; i < tempList.Count; i++)
        {
            GameObject ob = tempList[i];
            UnEquipmentNode m = ob.GetComponent<UnEquipmentNode>();
            m.index = m.index - 1;
            m.transform.position = new Vector3(m.transform.position.x, m.transform.position.y + 150f, m.transform.position.z);
        }
        ui.SetActive(false);
    }

    public void Close()
    {
        ui.SetActive(false);
        EquipmentManager.instance.nodeUI = null;
    }

    public void Set(Equipment p)
    {   
        if(p == null)
        {   
            return;
        }
        ui.SetActive(true);
        equipment = p;
        showText();
    }

    private void showText()
    {
        image.sprite = setSprite(equipment.path);
        Type.text = "type:" + equipment.EquipmentType.ToString();
        euipmentName.text = "name:" + equipment.ename;
        value.text = "value:" + equipment.value.ToString();
        if(equipment.EquipmentType == EquipmentType.Helmet)
        {
            PDEF.text = "PDEF:"+ equipment.PDEF.ToString();
            MDEF.text = "MDEF:" + equipment.MDEF.ToString();
            FirstAttribute.text = "ACC:"+ equipment.ACC.ToString();
            SecondAttribute.text = "ACC:" + equipment.Block.ToString();
        }
        else if (equipment.EquipmentType == EquipmentType.Gloves)
        {
            PDEF.text = "PDEF:" + equipment.PDEF.ToString();
            MDEF.text = "MDEF:" + equipment.MDEF.ToString();
            FirstAttribute.text = "Pernetration:" + equipment.Pernetration.ToString();
            SecondAttribute.text = "Crit:" + equipment.Crit.ToString();
        }
        else if (equipment.EquipmentType == EquipmentType.Pants)
        {
            PDEF.text = "PDEF:" + equipment.PDEF.ToString();
            MDEF.text = "MDEF:" + equipment.MDEF.ToString();
            FirstAttribute.text = "HP:" + equipment.HP.ToString();
            SecondAttribute.text = "CritResistance:" + equipment.CritResistance.ToString();
        }
        else if (equipment.EquipmentType == EquipmentType.Shoes)
        {
            PDEF.text = "PDEF:" + equipment.PDEF.ToString();
            MDEF.text = "MDEF:" + equipment.MDEF.ToString();
            FirstAttribute.text = "ACC:" + equipment.ACC.ToString();
            SecondAttribute.text = "Dodge:" + equipment.Dodge.ToString();
        }
        else if (equipment.EquipmentType == EquipmentType.Armor)
        {
            PDEF.text = "PDEF:" + equipment.PDEF.ToString();
            MDEF.text = "MDEF:" + equipment.MDEF.ToString();
            FirstAttribute.text = "Block:" + equipment.Block.ToString();
            SecondAttribute.text = "CritResistance:" + equipment.CritResistance.ToString();
        }
        else if (equipment.EquipmentType == EquipmentType.Bow || equipment.EquipmentType == EquipmentType.Staff ||
                equipment.EquipmentType == EquipmentType.Sword)
        {
            PDEF.text = "ATK:" + equipment.PATK.ToString();
            MDEF.text = "Matk:" + equipment.MATK.ToString();
            FirstAttribute.text = "Block:" + equipment.Crit.ToString();
            SecondAttribute.text = "CritResistance:" + equipment.CritDMG.ToString();
        }
        else
        {
            PDEF.text = "PDEF:" + equipment.PDEF.ToString();
            MDEF.text = "MDEF:" + equipment.MDEF.ToString();
            FirstAttribute.text = "Block:" + equipment.Block.ToString();
            SecondAttribute.text = "CritResistance:" + equipment.CritResistance.ToString();
        }
    }

    public void hide()
    {
        ui.SetActive(false);
    }

    public void setHero(string h)
    {
        hero = h;
    }


    public Sprite setSprite(string text)
    {
        Texture2D aa = (Texture2D)Resources.Load(text) as Texture2D;
        Sprite kk = Sprite.Create(aa, new Rect(0, 0, aa.width, aa.height), new Vector2(0.5f, 0.5f));
        return kk;
    }
}
