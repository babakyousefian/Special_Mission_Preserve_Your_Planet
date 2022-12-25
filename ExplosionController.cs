using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ExplosionController : MonoBehaviour
{

    #region public Variables
    #endregion

    #region private Variables
    [SerializeField]
    private Animator Animator;
    #endregion

    #region public Methods
    #endregion

    #region private Methods
    private void Start()
    {
        //Animator = GetComponent<Animator>();
        StartCoroutine(DestroyThis());
    }
    private IEnumerator DestroyThis()
    {
        yield return new WaitForSeconds(Animator.GetCurrentAnimatorStateInfo(0).length);
        Destroy(gameObject);
    }
    #endregion
}