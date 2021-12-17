using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class StartPart2 : MonoBehaviour
{
    public Text textMesh;
    public GameObject WakeUp;
    public GameObject Player;
    IEnumerator Start()
    {
        yield return new WaitForSeconds(1f);
        textMesh.text = "Кажется, когда я отключил зажимы";
        yield return new WaitForSeconds(2.5f);
        textMesh.text = "все эмоции одновременно вышли из меня";
        yield return new WaitForSeconds(2.5f);
        textMesh.text = "И в моей психике начался полный хаос";
        yield return new WaitForSeconds(2.5f);
        textMesh.text = "Все сделано верно, с зажимами я бы не смог проникнуть вглубь себя";
        yield return new WaitForSeconds(2.5f);
        textMesh.text = "Остается лишь теперь навести порядок после этого беспредела";
        yield return new WaitForSeconds(2.5f);
        textMesh.text = "А именно - стабилизировать каждую свою эмоцию";
        WakeUp.SetActive(true);
        yield return new WaitForSeconds(7f);
        WakeUp.SetActive(false);
        Player.SetActive(true);
    }
}
