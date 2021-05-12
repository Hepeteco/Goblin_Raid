using UnityEngine;
using UnityEngine.UI;
using System.Collections.Generic;


public class VidaInimigo : MonoBehaviour {
    public float vidaInicial;
    public float vidaAtual; //quantidade de vida atual do objeto
    public float[] dropRatio;
    public List<GameObject> prefabMorte; //objeto a ser isntanciado no momento da morte
    private Animator anim;
    private BoxCollider2D bc2d;


    //inicializa a vida atual
    void Start()
    {
        vidaAtual = vidaInicial;
        anim = GetComponent<Animator>();
        bc2d = GetComponent<BoxCollider2D>();
    }

    /// <summary>
    /// Função chamada para aplicar dano ao objeto. Deve passar a quantidade de dano a ser aplicada
    /// </summary>
    /// <param name="danoParaAplicar></param>
    public void TomaDano(float danoParaAplicar)
    {
        //diminui a quantidade de vida
        vidaAtual -= danoParaAplicar;
        //verifica se a vida chegou a zero e chama a função de morte em caso positivo
        if (vidaAtual <= 0)
        {
            Morre();
        }
  
    }

    //Instancia o prefab de morte e destroi o objeto morto
    public void Morre()
    {
        main.CONTADOR++;
        bc2d.enabled = false;
        anim.SetBool("Death", true);
        vidaAtual = 0;
        DropaItem();
        Destroy(gameObject, 1f);
        if (gameObject.layer == 8)
            main.BOSS_MORTO = true;
    }

    void DropaItem()
    {
        GameObject[] prefab = prefabMorte.ToArray();

        float drop = Random.Range(0, 100);

        for (int i = 0; i < dropRatio.Length; i++)
        {
            for (int j = 0; j < prefab.Length; j++)
            {
                if (drop <= dropRatio[i])
                {
                    Instantiate(prefabMorte[j], transform.position, Quaternion.identity);
                    
                }                                    
            }
        }
    }
}
