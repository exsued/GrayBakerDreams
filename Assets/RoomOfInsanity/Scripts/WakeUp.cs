using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class WakeUp : MonoBehaviour
{
    public GameObject player;
    public Animator anim;
    public float animTime;
    public Text introText;
    // Start is called before the first frame update
    IEnumerator Start()
    {
        yield return new WaitForSeconds(1.5f);
        introText.text = "������ ��� �����";
        yield return new WaitForSeconds(3.0f);
        introText.text = "�� ��������� ������";
        yield return new WaitForSeconds(3.0f);
        introText.text = "������� � ����� ������";
        yield return new WaitForSeconds(3.0f);
        introText.text = "� ������ ��";
        yield return new WaitForSeconds(3.0f);
        introText.text = "������� �� ���� ���������";
        yield return new WaitForSeconds(3.0f);
        introText.text = "";
        anim.enabled = true;
        anim.Play("WakeUp", -1);
        yield return new WaitForSeconds(animTime);
        player.SetActive(true);
        gameObject.SetActive(false);
    }
}
