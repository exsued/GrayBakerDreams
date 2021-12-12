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
        textMesh.text = "�������, ����� � �������� ������";
        yield return new WaitForSeconds(2.5f);
        textMesh.text = "��� ������ ������������ ����� �� ����";
        yield return new WaitForSeconds(2.5f);
        textMesh.text = "� � ���� ������� ������� ������ ����";
        yield return new WaitForSeconds(2.5f);
        textMesh.text = "��� ������� �����, � �������� � �� �� ���� ���������� ������ ����";
        yield return new WaitForSeconds(2.5f);
        textMesh.text = "�������� ���� ������ ������� ������� ����� ����� ����������";
        yield return new WaitForSeconds(2.5f);
        textMesh.text = "� ������ - ��������������� ������ ���� ������";
        WakeUp.SetActive(true);
        yield return new WaitForSeconds(7f);
        WakeUp.SetActive(false);
        Player.SetActive(true);
    }
}
