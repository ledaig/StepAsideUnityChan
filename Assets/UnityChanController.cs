using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UnityChanController : MonoBehaviour
{
  //アニメーションするためのコンポーネントを入れる
  private Animator myAnimator;
  //Unityちゃんを移動させるコンポーネントを入れる
  private Rigidbody myRigidbody;
  //前方向の速度
  private float velocityZ = 16f;
  //横方向の速度
  private float velocityX = 10f;
  //上方向の速度（追加）
  private float velocityY = 10f;
  //左右の移動できる範囲
  private float movableRange = 3.4f;


        // Use this for initialization
        void Start()
        {
                //アニメータコンポーネントを取得
                this.myAnimator = GetComponent<Animator>();

                //走るアニメーションを開始
                this.myAnimator.SetFloat("Speed", 1);

                //Rigidbodyコンポーネントを取得（追加）
                this.myRigidbody = GetComponent<Rigidbody>();
                this.myRigidbody.velocity = new Vector3(0.0f,0.0f,0.0f);
        }

        // Update is called once per frame
        void Update ()
        {
                //横方向の入力による速度
                float inputVelocityX = 0;
                //上方向の入力による速度（追加）
                float inputVelocityY = 0;

                //Unityちゃんを矢印キーまたはボタンに応じて左右に移動させる
                if (Input.GetKey (KeyCode.LeftArrow)  && -this.movableRange < this.transform.position.x)
                {
                        //左方向への速度を代入
                        inputVelocityX = -this.velocityX;
                }
                else if (Input.GetKey (KeyCode.RightArrow)  && this.transform.position.x < this.movableRange)
                {
                        //右方向への速度を代入
                        inputVelocityX = this.velocityX;
                }

                //ジャンプしていない時にスペースが押されたらジャンプする（追加）
                if (Input.GetKeyDown(KeyCode.Space) && this.transform.position.y < 0.5f)
                {
                        //ジャンプアニメを再生（追加）
                        this.myAnimator.SetBool ("Jump", true);
                        //上方向への速度を代入（追加）
                        inputVelocityY = this.velocityY;
                }
                else
                {
                        //現在のY軸の速度を代入（追加）
                        inputVelocityY = this.myRigidbody.velocity.y;
                      

                }

                //Jumpステートの場合はJumpにfalseをセットする（追加）
                if (this.myAnimator.GetCurrentAnimatorStateInfo(0).IsName ("Jump"))
                {
                        this.myAnimator.SetBool ("Jump", false);
                }

                //Unityちゃんに速度を与える（変更）
                Debug.Log("velocityX");
                Debug.Log(this.myRigidbody.velocity.x);
                Debug.Log("VelocityY");
                Debug.Log(this.myRigidbody.velocity.y);


                Debug.Log(inputVelocityY);
                this.myRigidbody.velocity = new Vector3 (inputVelocityX , inputVelocityY , velocityZ);
                //this.myRigidbody.velocity = new Vector3 (inputVelocityX , 0 , velocityZ);

        }

}