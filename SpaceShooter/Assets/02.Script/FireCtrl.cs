using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(AudioSource))]
public class FireCtrl : MonoBehaviour
{
    // �Ѿ� ������.
    public GameObject bullet;
    // �Ѿ� �߻� ��ǥ.
    public Transform firePos;
    // �ѼҸ��� ����� ����� ����.
    public AudioClip fireSfx;

    // AudioSource ������Ʈ�� ������ ����.
    private new AudioSource audio;
    // Muzzle Flash�� MeshRenderer ������Ʈ
    private MeshRenderer muzzleFlash;

    void Start()
    {
        audio = GetComponent<AudioSource>();

        // FirePos ������ �ִ� MuzzleFlash�� Material ������Ʈ ����
        muzzleFlash = firePos.GetComponentInChildren<MeshRenderer>();
        // ó�� ������ �� ��Ȱ��ȭ
        muzzleFlash.enabled = false;
    }

    void Update()
    {
        // ���콺 ���� ��ư�� Ŭ������ �� Fire �Լ� ȣ��
        if (Input.GetMouseButtonDown(0))
        {
            Fire();
        }
    }

    void Fire()
    {
        // Bullet �������� �������� ����(������ ��ü, ��ġ, ȸ��)
        Instantiate(bullet, firePos.position, firePos.rotation);
        // �ѼҸ� �߻�
        audio.PlayOneShot(fireSfx, 1.0f);
    }
}
