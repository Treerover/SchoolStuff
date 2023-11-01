using UnityEngine;

public class ThirdPersonCamera : MonoBehaviour
{
    public FollowCameraBehaviour FollowCameraBehaviour;

    void Awake()
    {
        if (FollowCameraBehaviour == null)
            FollowCameraBehaviour = new FollowCameraBehaviour();
    }

  void Update()
  {
  }

  void LateUpdate()
  {
      //Check if the camera was initialized
      if (m_Player == null)
      {
          return;
      }

      if(m_CurrentBehaviour != null)
      {
          m_CurrentBehaviour.UpdateCamera();

          ControlRotation = m_CurrentBehaviour.GetControlRotation();
      }
   }

  public void SetPlayer(Player player)
  {
      m_Player = player;

      //Get Follow and look objects
      if (m_Player != null)
      {
          LookPos = m_Player.transform.position;
      }

      //Setup camera behaviours
      FollowCameraBehaviour.Init(this, m_Player);
     
      //Set initial behaviour
      SetCameraBehaviour(FollowCameraBehaviour);
  }

  public void UpdateRotation(float yawAmount, float pitchAmount)
  {
      if (m_CurrentBehaviour != null)
      {
          m_CurrentBehaviour.UpdateRotation(yawAmount, pitchAmount);
      }
  }

  public void SetFacingDirection(Vector3 direction)
  {
      if (m_CurrentBehaviour != null)
      {
          m_CurrentBehaviour.SetFacingDirection(direction);
      }
  }

  public Vector3 ControlRotation { get; private set; }

  public Vector3 LookPos { get; set; }

  public Vector3 PivotRotation { get; set; }

  void SetCameraBehaviour(CameraBehaviour behaviour)
  {
     //Ignore the behaviour if it's the same as before
     if (m_CurrentBehaviour == behaviour)
     {
         return;
     }

     //Deactivate old behaviour
     if (m_CurrentBehaviour != null)
     {
         m_CurrentBehaviour.Deactivate();
     }

     //Set new behaviour
     m_CurrentBehaviour = behaviour;

     //Activate new behaviour
     if (m_CurrentBehaviour != null)
     {
         m_CurrentBehaviour.Activate();
     }
  }

    CameraBehaviour m_CurrentBehaviour;
    Player m_Player;
}
