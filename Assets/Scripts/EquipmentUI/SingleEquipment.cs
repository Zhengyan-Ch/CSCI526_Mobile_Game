﻿using UnityEngine;
using UnityEngine.UI;
using System.IO;

public class SingleEquipment : MonoBehaviour
{
    private Equipment equipment;
    public EquipmentType type;
    public Text ename;
    public GameObject ui;
    public Image image;
    private string NoneString = "Blank";

    public void setEquipment(Equipment e)
    {
        equipment = e;
        if (e == null)
        {
            ename.text = "none";
            image.sprite = setSprite(NoneString);
        }
        else
        {
            ename.text = e.ename;
            image.sprite = setSprite(e.path);
        }
    }

    public void detail()
    {   
        if(equipment == null)
        {
            EquipmentManager.instance.selectEquippedEuipment(type);
        }
        else if (equipment.isUsed == false)
        {
            EquipmentManager.instance.selectUnEquippedEuipment(equipment);
        }
        else
        {
            EquipmentManager.instance.selectEquippedEuipment(equipment,type);
        }
        GameObject temp;
        SingleEquipment tempS;
        temp = GameObject.Find("/EquipmentUI/Equipments/Helmet");
        tempS = temp.GetComponent<SingleEquipment>();
        tempS.ui.SetActive(false);
        temp = GameObject.Find("/EquipmentUI/Equipments/Armor");
        tempS = temp.GetComponent<SingleEquipment>();
        tempS.ui.SetActive(false);
        temp = GameObject.Find("/EquipmentUI/Equipments/Pants");
        tempS = temp.GetComponent<SingleEquipment>();
        tempS.ui.SetActive(false);
        temp = GameObject.Find("/EquipmentUI/Equipments/Shoes");
        tempS = temp.GetComponent<SingleEquipment>();
        tempS.ui.SetActive(false);
        temp = GameObject.Find("/EquipmentUI/Equipments/Gloves");
        tempS = temp.GetComponent<SingleEquipment>();
        tempS.ui.SetActive(false);
        temp = GameObject.Find("/EquipmentUI/Equipments/Weapon");
        tempS = temp.GetComponent<SingleEquipment>();
        tempS.ui.SetActive(false);
        //removeHero();
    }

    /* private void removeHero()
     {
         GameObject t;
         Vector3  v = new Vector3(-1000f, -1000f, 0f);
         t = GameObject.Find("/Knight1");
         t.transform.position = v;
         t = GameObject.Find("/Priest1");
         t.transform.position = v;
         t = GameObject.Find("/IceMage1");
         t.transform.position = v;
         t = GameObject.Find("/FireMage1");
         t.transform.position = v;
         t = GameObject.Find("/Archer1");
         t.transform.position = v;
     }*/

    private static byte[] getImageByte(string imagePath)
    {
        FileStream files = new FileStream(imagePath, FileMode.Open);
        byte[] imgByte = new byte[files.Length];
        files.Read(imgByte, 0, imgByte.Length);
        files.Close();
        return imgByte;
    }

    public Sprite setSprite(string text)
    {
        Texture2D aa = (Texture2D)Resources.Load(text) as Texture2D;
        Sprite kk = Sprite.Create(aa, new Rect(0, 0, aa.width, aa.height), new Vector2(0.5f, 0.5f));
        return kk;
    }
}
