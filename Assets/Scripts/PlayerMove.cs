using UnityEngine;

public class PlayerMove : MonoBehaviour
{
    public Rigidbody Rigidbody;
    public float MoveSpeed;
    public float JumpSpeed;
    public float Friction;
    public bool Grounded;

    // скорость в воздухе 
    public float MaxSpeed;

    // public Pointer pointer;

    public Transform ColiderTransform;

    private int _jumpFrameCounter;
    void Update()
    {   
        // поскольку иcпользуем не каждый кадр а один раз то используем в Update()
        if (Input.GetKeyDown(KeyCode.Space))
        {
            if (Grounded)
                Jump();

        }

        // Player приседает
        // Если мы зажали leftShift или Grounded == false при любом из этих условий сжимаем капусулу (player приседает)
        if (Input.GetKey(KeyCode.LeftShift) || Grounded == false)
        {
            // плавно зжимаем капсулу (от текущей позиции, к заданой, с скорость...)
            ColiderTransform.localScale = Vector3.Lerp(ColiderTransform.localScale, new Vector3(1f, 0.5f, 1f), Time.deltaTime * 15f);
        }
        else
        {
            ColiderTransform.localScale = Vector3.Lerp(ColiderTransform.localScale, new Vector3(1f, 1, 1f), Time.deltaTime * 15f);
        }

    }

    public void Jump()
    {
        Rigidbody.AddForce(0, JumpSpeed, 0, ForceMode.VelocityChange);
        // При прыжке крутится 
        _jumpFrameCounter = 0;

    }

    void FixedUpdate()
    {
        Rigidbody.AddForce(0f, 0f, 0f, ForceMode.VelocityChange);
        // уменьшает скорость( управление ) в воздухе 
        float speedMultiplier = 1f;

        // если false(не на земле) то режим в 9 раз
        if (Grounded == false)
        {
            speedMultiplier = 0.2f;

            // Это нужно чтоб в прыжке он не набирал скорость 
            // если скорость по X больше чем MaxSpeed и кнопу которую нажимем вправо больше 0
            // то значит никакая сила добавдяется к нему не будет 
            if (Rigidbody.linearVelocity.x > MaxSpeed && Input.GetAxis("Horizontal") > 0)
                speedMultiplier = 0;
            if (Rigidbody.linearVelocity.x < -MaxSpeed && Input.GetAxis("Horizontal") < 0)
                speedMultiplier = 0;
        }


        // передвижение по X (горизонтали)
        Rigidbody.AddForce(Input.GetAxis("Horizontal") * MoveSpeed * speedMultiplier, 0, 0, ForceMode.VelocityChange);

        // отключаем drag по Y
        if (Grounded)
        {
            // создаем свой drag по X (горизонтали) 
            // пототому-что в Inspector Drag по X and Y 
            Rigidbody.AddForce(-Rigidbody.linearVelocity.x * Friction, 0, 0, ForceMode.VelocityChange);
            // При прыжке крутится 
            transform.rotation = Quaternion.Lerp(transform.rotation, Quaternion.identity, Time.deltaTime * 15f);
        }

        // При прыжке крутится 
        _jumpFrameCounter += 1;
        if (_jumpFrameCounter == 2)
        {
            Rigidbody.freezeRotation = false;
            Rigidbody.AddRelativeTorque(0f, 0f, 10f, ForceMode.VelocityChange);
        }
    }

    void OnCollisionStay(Collision collision)
    {
        // перебераем все точки контакта 
        for (int i = 0; i < collision.contactCount; i++)
        {
            // метод angle меряет угол между векторами 
            float angle = Vector3.Angle(collision.contacts[i].normal, Vector3.up);
            if (angle < 45f)
                Grounded = true;
                // При прыжке крутится 
                Rigidbody.freezeRotation = true;
        }
        
    }

    void OnCollisionExit(Collision collision)
    {
        Grounded = false;
    }

}
