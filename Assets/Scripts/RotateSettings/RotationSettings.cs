using UnityEngine;

public class RotationSettings : MonoBehaviour
{
    [SerializeField] private Joystick joystick;
    [SerializeField] private GameObject gun;

    public CircleLaunchingEnemyAggression circleAgression;

    private float angle;
    [HideInInspector] public Vector2 vectorRotation = Vector2.right;

    public void Update()
    {
        Rotation();
    }

    public void Rotation()
    {
        if (circleAgression.enemyInCircle.Count == 0)
        {
            GetComponent<SpriteRenderer>().flipY = false;

            var eulerAnglesGun = transform.rotation.eulerAngles;

            Vector2 direction = new Vector2(joystick.Horizontal, joystick.Vertical);
            direction.Normalize();

            if (direction.x <= 0 && vectorRotation == Vector2.right)
            {
                GetComponent<SpriteRenderer>().flipX = true;
                vectorRotation = Vector2.left;
            }
            else if (direction.x > 0 && vectorRotation == Vector2.left)
            {
                GetComponent<SpriteRenderer>().flipX = false;
                vectorRotation = Vector2.right;
            }


            float angle = Vector2.Angle(direction, vectorRotation);


            if (angle > 50 && angle < 90)
                angle = 50;


            if (angle < -50 && angle > -90)
                angle = -50;


            if (joystick.Vertical < 0f && vectorRotation == Vector2.right || joystick.Vertical >= 0f && vectorRotation == Vector2.left)
                transform.rotation = Quaternion.Euler(eulerAnglesGun.x, eulerAnglesGun.y, -angle);
            else
                transform.rotation = Quaternion.Euler(eulerAnglesGun.x, eulerAnglesGun.y, angle);
        }
        else
        {
            GetComponent<SpriteRenderer>().flipX = false;

            if (circleAgression.SearchEnemyWithMinDistanceToPlayer() != null)
                transform.rotation = Quaternion.Euler(transform.rotation.eulerAngles.x, transform.rotation.eulerAngles.y, Mathf.Atan2(circleAgression.SearchEnemyWithMinDistanceToPlayer().transform.position.y - transform.position.y, circleAgression.SearchEnemyWithMinDistanceToPlayer().transform.position.x - transform.position.x) * Mathf.Rad2Deg);

            float eulerAnglesObject = transform.rotation.eulerAngles.z;
            vectorRotation = Vector2.right;

            if (eulerAnglesObject > 90 && eulerAnglesObject <= 270) 
                GetComponent<SpriteRenderer>().flipY = true;
            else
                GetComponent<SpriteRenderer>().flipY = false;

            if (eulerAnglesObject > 50 && eulerAnglesObject <= 90)
                eulerAnglesObject = 50;

            if (eulerAnglesObject > 90 && eulerAnglesObject < 130)
                eulerAnglesObject = 130;

            if (eulerAnglesObject >= 270 && eulerAnglesObject < 310)
                eulerAnglesObject = 310;

            if (eulerAnglesObject > 230 && eulerAnglesObject < 270)
                eulerAnglesObject = 230;

            transform.eulerAngles = new Vector3(transform.eulerAngles.x, transform.eulerAngles.y, eulerAnglesObject);
        }
    }
}
