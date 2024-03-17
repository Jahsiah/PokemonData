using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class PokemonData : MonoBehaviour
{
    // cette partie du code permet de definire les variables et les informations importante sur le pokemon en question
    [SerializeField] string Name = "Darkrai";
    enum Type { Normal, Fire, Water, Electric, Grass, Ice, Fighting, Poison, Ground, Flying, Psychic, Bug, Rock, Ghost, Dragon, Dark, Steel, Fairy, Stellar };
    [SerializeField] int BaseLife = 70;
    [SerializeField] int Life;
    [SerializeField] int Atk = 90;
    [SerializeField] int Def = 90;
    [SerializeField] int Stats;
    [SerializeField] float Weight = 50.0f;
    [SerializeField] Type CurrentType = Type.Dark;
    [SerializeField] Type[] WeaknesseType = {Type.Fairy, Type.Bug, Type.Fighting};
    [SerializeField] Type[] ResistanceType = {Type.Ghost, Type.Dark};
    [SerializeField] Type[] ImmuneType = {Type.Psychic};

    // cette fonctino permet de initier les points de vie et les points de stats au lancement du jeu
    void Awake() {
        InitCurrentLife();
        InitStatsPoints();
    }
    // cette fonction permet de envoyer sur les logs toute les informations sur le pokemon defini plus haut ou sur le inspecteur et de demarer l'attaque en 
    void Start() {
        Display();
        TakeDmg(30,"Normal");
    }
    // cette fonction permet de verifier a chaque frame si le pokemon est toujour vivant apres chaque attaque 
    void Update() {
        CheckIfAlive();
    }

    void Display() {
        Debug.Log("Name : " + Name);
        Debug.Log("HP : " + BaseLife + " points");
        Debug.Log("Attack : " + Atk + " points");
        Debug.Log("Defense : " + Def + " points");
        Debug.Log("Stats : " + Stats + " points");
        Debug.Log("Weight : " + Weight + " Kg");
        Debug.Log("Type : " + CurrentType);

        for (int i=0; i<WeaknesseType.Length; i++) {
            Debug.Log("Weaknesses : " + WeaknesseType[i]);
        }

        for (int i=0; i<ResistanceType.Length; i++) {
            Debug.Log("Resistances : " + ResistanceType[i]);
        }

        for (int i=0; i<ImmuneType.Length; i++) {
            Debug.Log("Immune(s) : " + ImmuneType[i]);
        }
    }
    
    void InitCurrentLife() {
        Life = BaseLife;
    }

    int GetAttackDmg() {
        return Atk;
    }
    
    void InitStatsPoints() {
        Stats += BaseLife + Atk + Def; 
    }
    
    //cette fonction permet de definir l'algoritme utiliser pour que le pokemon puisse prendre des degats
    void TakeDmg(int damage, string EnnemyType) {
        for (int i=0; i<WeaknesseType.Length; i++) {
            if (EnnemyType == WeaknesseType[i].ToString()) {
                Life -= damage * 2;
            }
        }
        
        for (int i=0; i<ResistanceType.Length; i++) {
            if (EnnemyType == ResistanceType[i].ToString()) {
                Life -= damage / 2;
            }
        }

        for (int i=0; i<ImmuneType.Length; i++) {
            if (EnnemyType == ImmuneType[i].ToString()) {
                Life += 0;
            } else {
                Life -= damage;
            }
        }

        if (Life <= 0) {
            Life = 0;
        }

        Debug.Log(Name + " Has now " + Life + " Health Points");
    }

    //cette fonction permet de verifier si le pokemon est toujour en vie ou pas
    void CheckIfAlive() {
        if (Life <= 0) {
            Life = 0;
            Debug.Log(Name + " died");
        } else {
            Debug.Log(Name + " is still alive");
        }
    }
}
