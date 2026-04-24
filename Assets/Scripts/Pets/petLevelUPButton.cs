using UnityEngine;

public class petLevelUPButton : MonoBehaviour
{
    int index = 0;
    public void lvlUP()
    {
        string id=GetComponentInParent<petBox>().pet.petId;
        foreach(var p in data.pets)
        {
            if(id==p.petId)
            {
                data.pets[index].Petlvl++;
                
            }
            index++;
        }
    }
}

