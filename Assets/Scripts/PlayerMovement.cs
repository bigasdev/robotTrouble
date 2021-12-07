using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public float moveSpeed;
    public float moveDelay = .5f;
    float timer;
    GameObject flag, circle;
    Coroutine moving;
    Vector2 currentMovingPos;
    Structure structure;
    Animator anim;
    private void Start() {
        anim = GetComponentInChildren<Animator>();
    }
    public Vector2 MousePos{
        get{
            if(Camera.main == null) return new Vector2(0,0);
            Vector2 mousePos = Input.mousePosition;
            Vector2 worldPos = Camera.main.ScreenToWorldPoint(mousePos);
            return worldPos;
        }
    }
    void Update()
    {
        if(!StateController.Instance.CanUpdate)return;
        anim.SetBool("isWalking", moving != null);
        timer -= Time.deltaTime;
        if(timer >= 0)return;
        if(Input.GetMouseButton(0)){
            Movement();
            OnClick(MousePos);
        }
    }
    void OnClick(Vector2 pos){
        SearchForComponents();
        if(flag != null){
            Destroy(flag);
            flag = null;
        }
        if(circle != null){
            Destroy(circle);
            circle = null;
        }
        currentMovingPos = pos;
        RaycastHit2D hit = Physics2D.Raycast(MousePos, Vector2.zero);
        if(hit.collider != null){
            structure = hit.collider.GetComponentInParent<Structure>();
            if(structure == null)return;
            var c = Resources.Load<GameObject>("Prefabs/UI/Circle");
            circle = Instantiate(c);
            circle.transform.position = structure.transform.position;
            timer = .5f;
            return;
        }
        var f = Resources.Load<GameObject>("Prefabs/UI/Flag");
        flag = Instantiate(f);
        flag.transform.position = pos;
        timer = .5f;
    }
    void SearchForComponents(){
        var canvas = FindObjectsOfType<CanvasObject>();
        foreach(var c in canvas){
            Destroy(c.gameObject);
        }
    }
    void Movement(){
        if(moving != null){
            StopCoroutine(moving);
        }
        moving = StartCoroutine(MoveTo(MousePos));
    }
    IEnumerator MoveTo(Vector2 pos){
        var x = this.transform.position.x - pos.x;
        this.transform.localScale = new Vector2(x >= 0 ? -1 : 1, 1);
        while(Vector2.Distance(this.transform.position, pos) >= .15f){
            this.transform.position = Vector2.MoveTowards(this.transform.position, pos, moveSpeed * Time.deltaTime);
            yield return null;
        }
        if(flag != null){
            Destroy(flag);
            flag = null;
        }
        if(structure != null){
            if(circle != null){
                Destroy(circle);
                circle = null;
            }
            structure.Deploy();
            structure = null;
        }
        moving = null;
        if(Vector2.Distance(this.transform.position, currentMovingPos) <= .35f)yield break;
        moving = StartCoroutine(MoveTo(currentMovingPos));
    }
}
