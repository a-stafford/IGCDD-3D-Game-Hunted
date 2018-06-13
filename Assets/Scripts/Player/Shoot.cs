using UnityEngine;
using System.Collections;

public class Shoot : MonoBehaviour
{
    public int gunDamage = 1;
    public GameObject bulletPrefab, ShotgunBulletPrefab;
    public GameObject bulletSpawn, bulletSpawn1, bulletSpawn2, bulletSpawn3, bulletSpawn4, bulletSpawn5, bulletSpawn6, bulletSpawn7, bulletSpawn8, bulletSpawn9, bulletSpawn10, bulletSpawn11, bulletSpawn12, bulletSpawn13, bulletSpawn14;
    public bool Gun1, Gun2, shoot;
    public static bool Pistol, Shotgun;
    public float current = 1f;
    public float timer = 10f;
    public float ShotDelay = 0.25f, ShotgunDelay = 0.25f, crazyDelay = 0.10f;
    public float shotCooldown = 0;
    public Animator anim;

    void Start()
    {
        anim = GetComponent<Animator>();
        Pistol = true;
        shoot = true;
    }

    void Update()
    {
        shotCooldown -= Time.deltaTime;

        if (Input.GetKeyDown("1") && current != 1)
        {
            current = 1;
            anim.SetTrigger("Change");
            Pistol = true;
            Shotgun = false;
        }

        if (Gun1 == true)
        {
            GunChange.GunText1 = true;

            GunChange.GunText2 = false;
        }

        if (Input.GetKeyDown("2") && current != 2)
        {
            current = 2;
            anim.SetTrigger("Change2");
            Shotgun = true;
            Pistol = false;
        }

        if (Gun2 == true)
        {
            GunChange.GunText2 = true;
            GunChange.GunText1 = false;
        }

        if (PowerUp.crazy == true)
        {
            timer -= Time.deltaTime;
        }

        if (timer <= 0 && PowerUp.crazy == true)
        {
            PowerUp.crazy = false;
            Debug.Log("fire off");
            timer = 10;
        }

        if (Pistol == true && shoot == true)
        {
            if (Input.GetKeyDown("mouse 0"))
            {

                SoundEffects.Instance.MakeShotSound();
                Instantiate(bulletPrefab, bulletSpawn14.transform.position, bulletSpawn14.transform.rotation);
            }

            if (Input.GetKey("mouse 1") && shotCooldown <= 0)
            {

                shotCooldown = ShotDelay;
                SoundEffects.Instance.MakeShotSound();
                Instantiate(bulletPrefab, bulletSpawn14.transform.position, bulletSpawn14.transform.rotation);
            }
        }

        if (Pistol == true && shoot == true && timer < 10)
        {


            if (shotCooldown <= 0)
            {
                shotCooldown = crazyDelay;
                SoundEffects.Instance.MakeShotSound();
                Instantiate(bulletPrefab, bulletSpawn14.transform.position, bulletSpawn14.transform.rotation);
            }
        }

            if (Shotgun == true && shoot == true)
        {
            if (Input.GetKeyDown("mouse 0"))
            {

                shotgunShoot();
            }
            if (Input.GetKey("mouse 1") && shotCooldown <= 0)
            {

                shotCooldown = ShotgunDelay;
                shotgunShoot();
            }

        }

        if (Shotgun == true && shoot == true && timer < 10)
        {

            if (shotCooldown <= 0)
            {
                shotCooldown = crazyDelay;
                shotgunShoot();
            }
        }
    }

    void shotgunShoot()
    {

        SoundEffects.Instance.MakeShotSound();
        Instantiate(ShotgunBulletPrefab, bulletSpawn.transform.position, bulletSpawn.transform.rotation);
        Instantiate(ShotgunBulletPrefab, bulletSpawn1.transform.position, bulletSpawn1.transform.rotation);
        Instantiate(ShotgunBulletPrefab, bulletSpawn2.transform.position, bulletSpawn2.transform.rotation);
        Instantiate(ShotgunBulletPrefab, bulletSpawn3.transform.position, bulletSpawn3.transform.rotation);
        Instantiate(ShotgunBulletPrefab, bulletSpawn4.transform.position, bulletSpawn4.transform.rotation);
        Instantiate(ShotgunBulletPrefab, bulletSpawn5.transform.position, bulletSpawn5.transform.rotation);
        Instantiate(ShotgunBulletPrefab, bulletSpawn6.transform.position, bulletSpawn6.transform.rotation);
        Instantiate(ShotgunBulletPrefab, bulletSpawn7.transform.position, bulletSpawn7.transform.rotation);
        Instantiate(ShotgunBulletPrefab, bulletSpawn8.transform.position, bulletSpawn8.transform.rotation);
        Instantiate(ShotgunBulletPrefab, bulletSpawn9.transform.position, bulletSpawn9.transform.rotation);
        Instantiate(ShotgunBulletPrefab, bulletSpawn10.transform.position, bulletSpawn10.transform.rotation);
        Instantiate(ShotgunBulletPrefab, bulletSpawn11.transform.position, bulletSpawn11.transform.rotation);
        Instantiate(ShotgunBulletPrefab, bulletSpawn12.transform.position, bulletSpawn12.transform.rotation);
        Instantiate(ShotgunBulletPrefab, bulletSpawn13.transform.position, bulletSpawn13.transform.rotation);
    }
}