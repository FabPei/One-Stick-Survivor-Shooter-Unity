using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletRiochet : MonoBehaviour
{
    public bool bRiocheted;
    public Bullet bullet_prefab;
    public float angleA;
    public float angleB;
    public bool active = false;
    private void OnCollisionEnter2D(Collision2D col)
    {
        if (active) { 
            if (col.gameObject.CompareTag("Enemy"))
            {
                if (bRiocheted == false)
                {

                    Vector3 VnewLocation = (this.transform.position - col.gameObject.transform.position).normalized;
                    //Debug.Log(VnewLocation);
                    Vector3 VnewLocationM = new Vector3(VnewLocation.x * -1.5f, VnewLocation.y * -1.5f, 0);
                    //Debug.Log(VnewLocationM);
                    float newRotation = Random.Range(this.transform.rotation.z - 90.0f, this.transform.rotation.z + 90.0f);
                    // Debug.Log(newRotation);
                    //float newScale = Random.Range(this.transform.rotation.z - 90.0f, this.transform.rotation.z + 90.0f);
                    //Debug.Log((this.transform.position - col.gameObject.transform.position).normalized + " col: " + col.gameObject.transform.position);
                    Bullet bullet = Instantiate(bullet_prefab, col.gameObject.transform.position + VnewLocationM, Quaternion.LookRotation(new Vector3(0, 0, newRotation)));
                    //Bullet bullet = Instantiate(bullet_prefab, new Vector3(col.gameObject.transform.position.x * 1.2f, col.gameObject.transform.position.y * 1.2f,0), Quaternion.LookRotation(new Vector3(0, 0, newRotation)));
                    //Debug.Log("Col " + new Vector3(col.gameObject.transform.position.x * 1f, col.gameObject.transform.position.y * 1f, 0));
                    //Debug.Log(Vector3.Scale(col.gameObject.transform.position.normalized, new Vector3(1.12f, 1.12f, 1.12f)));
                    // Debug.Log("Rio " + new Vector3(col.gameObject.transform.position.x * 1.2f, col.gameObject.transform.position.y * 1.2f, 0));
                    //Debug.Log("Riochet " + new Vector3(col.gameObject.transform.position.x * 2f, col.gameObject.transform.position.y * 2f, 0));
                    //Debug.Log(bullet.transform.position * 1.5f);
                    //Vector3 V3RandomPosition = new Vector3(this.transform.position.x + Random.Range(-15.0f, 15.0f), this.transform.position.y + Random.Range(-15.0f, 15.0f));
                    //Vector3 V3RandomPosition = Vector.Scale(col.gameObject.transform.position, new Vector3(1.12f, 1.12f, 1.12f);
                    //bullet.GetComponent<Rigidbody2D>().AddForce((Vector3.Scale(col.gameObject.transform.position, new Vector3(1.12f, 1.12f, 1.12f))), ForceMode2D.Impulse);
                    //bullet.GetComponent<Rigidbody2D>().AddForce(bullet.transform.position + (VnewLocationM * 5.0f), ForceMode2D.Impulse);
                    //float angle = (Random.Range(1.0f, 10.0f) * Mathf.PI * 2.5f + Random.Range(1.0f, 10.0f)) / 10; //randomize the float
                    float angle = Random.Range(1.0f, 90.0f);
                    Vector3 newPos = new Vector3(bullet.transform.position.x + Mathf.Cos(angle) * 5, Mathf.Sin(angle) * 5 + bullet.transform.position.y, 0);
                    //Debug.DrawLine(bullet.transform.position, newPos, Color.red, 0.4f);

                    Vector3 axis = Vector3.Cross(VnewLocation, Vector3.up);
                    if (axis == Vector3.zero) axis = Vector3.right;

                    Vector3 limitA = Quaternion.AngleAxis(angleA, Vector3.forward) * VnewLocation * 10;
                    Quaternion quat = Quaternion.AngleAxis(45, bullet.transform.position);
                    //Debug.Log("quat: " + quat);
                   // Debug.Log("b " + bullet.transform.position);
                    Vector3 limitB = Quaternion.AngleAxis(angleB, Vector3.forward) * VnewLocation * 10;
                    newPos = Quaternion.AngleAxis(Random.Range(angleA, angleB), Vector3.forward) * VnewLocation * 10;
                    //Debug.Log("limitA" + limitA + " limitB " + limitB);
                    //Debug.Log(limitA * 5);
                    //Debug.DrawLine(bullet.transform.position, limitA * 5.0f, Color.green, 1.0f);
                    //Debug.DrawLine(bullet.transform.position, limitB * 5.0f, Color.blue, 1.0f);

                    //Debug.Log(limitA);

                    // Debug.DrawLine(bullet.transform.position, Quaternion.AngleAxis(bullet.transform.rotation.z - 90, bullet.transform.position.normalized) * bullet.transform.position.normalized * 5, Color.blue, 1.0f);

                    //Debug.Log(Quaternion.AngleAxis(90.0f, bullet.transform.position.normalized));

                    //Debug.DrawLine(bullet.transform.position, Quaternion.AngleAxis(-30, axis) * bullet.transform.position, Color.yellow, 1.0f);

                    bullet.GetComponent<Rigidbody2D>().AddForce(newPos, ForceMode2D.Impulse);
                    bullet.GetComponent<BulletRiochet>().bRiocheted = true;
                    bullet.GetComponent<Collider2D>().enabled = true;


                    //Debug.DrawLine(Player.transform.position, Player.transform.position + (VnewLocation * 60f), Color.green, 0.5f);
                    // VnewLocation = inputController.GetComponent<JoystickInput>().moveDirection;
                }



            }

            }
    }



}
