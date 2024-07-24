using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using System.Collections;

public class ApplicatorListener : MonoBehaviour, IBeginDragHandler, IDragHandler, IEndDragHandler
{

    #region Variables, Constants & Initializers

    public Button.ButtonClickedEvent onEnterCollider;
    public Button.ButtonClickedEvent onExitCollider;
    public Button.ButtonClickedEvent onStayingCollider;
	public Button.ButtonClickedEvent onTouchEnd;

    private GameObject ImageParent;

    private RectTransform rectTransform;
    private Image image;

    private bool isStayingInCollider;
	private Transform parent;
	private Vector2 anchorPos;
	private RectTransform rectTrans;

    private Vector3 startPosition;
    private Vector3 startRotation;

    #endregion


    #region Lifecycle Methods

    // Use this for initialization

    void Start()
    {
        rectTransform = gameObject.GetComponent<RectTransform>();
        startPosition = rectTransform.localPosition;
        startRotation = rectTransform.transform.eulerAngles;
        image = gameObject.GetComponent<Image>();
	
    }

    #endregion

    #region IBeginDragHandler implementation
    public void OnBeginDrag(PointerEventData eventData){
		switch (GameManager.instance.currentScene) {
		case GameUtils.CAT_VIEW_SCENE:
			if (this.gameObject.tag == "tweeker") {
				this.gameObject.GetComponent<RectTransform> ().eulerAngles = new Vector3 (0f, 0f, 0f);
				if (onStayingCollider != null) {
					onStayingCollider.Invoke ();
				}
			}

			if (this.gameObject.tag == "rashbrush") {
				if (onStayingCollider != null) {
					onStayingCollider.Invoke ();
				}
			}

			break;

		case GameUtils.DOG_VIEW_SCENE:
			if (this.gameObject.tag == "scanner") {
				SoundManager.instance.PlayscanningLoop (true);
				if (onStayingCollider != null) {
					onStayingCollider.Invoke ();
				}
			}
			break;

		case GameUtils.BUNNY_VIEW_SCENE:
			if (this.gameObject.tag == "Brush") {
				if (onStayingCollider != null) {
					onStayingCollider.Invoke ();
				}
			}
			break;

            case GameUtils.Tiger_VIEW_SCENE:
                if (this.gameObject.tag == "Shower")
                {
                    SoundManager.instance.PlayShowerLoop(true);
                    this.gameObject.transform.GetChild(0).gameObject.SetActive(true);
                    if (onStayingCollider != null)
                    {
                        onStayingCollider.Invoke();
                    }
                }

                if (this.gameObject.tag == "Towel")
                {
                    if (onStayingCollider != null)
                    {
                        onStayingCollider.Invoke();
                    }
                }

                break;

            case GameUtils.BATH_VIEW_SCENE:
                if (this.gameObject.tag == "Shower")
                {
                    SoundManager.instance.PlayShowerLoop(true);
                    this.gameObject.transform.GetChild(0).gameObject.SetActive(true);
                    if (onStayingCollider != null)
                    {
                        onStayingCollider.Invoke();
                    }
                }

                if (this.gameObject.tag == "Towel")
                {
                    if (onStayingCollider != null)
                    {
                        onStayingCollider.Invoke();
                    }
                }

                break;

            case GameUtils.PANDA_VIEW_SCENE:
                if (this.gameObject.tag == "X")
                {
                    isStayingInCollider = true;
                    SoundManager.instance.PlayscanningLoop(true);
                    print("begin");
                    if (onStayingCollider != null)
                    {
                        onStayingCollider.Invoke();
                    }
                }
                break;

            case GameUtils.EATING_VIEW_SCENE:
                if (this.gameObject.tag == "eatingItems")
                {
                    //Debug.Log(GameObject.Find("EatingItems").name);
                    //ImageParent = this.gameObject.transform.parent.gameObject;
                    //transform.SetParent(GameObject.Find("EatingItems").transform);
                }
                break;
        }
	}

    #endregion

    #region IEndDragHandler implementation

    public void OnEndDrag(PointerEventData eventData) {
		
			switch (GameManager.instance.currentScene) {

			case GameUtils.CAT_VIEW_SCENE:
				if (this.gameObject.tag == "tweeker") {
				this.gameObject.GetComponent<RectTransform> ().eulerAngles = new Vector3 (0f, 0f, 65f);
					if (onExitCollider != null) {
						onExitCollider.Invoke ();
					}
				}

				if (this.gameObject.tag == "rashbrush") {
					SoundManager.instance.PlayRubbingLoop (false);
					if (onExitCollider != null) {
						onExitCollider.Invoke ();
					}
				}

				break;

			case GameUtils.DOG_VIEW_SCENE:
				if (this.gameObject.tag == "scanner") {
					SoundManager.instance.PlayscanningLoop (false);
					if (onExitCollider != null) {
						onExitCollider.Invoke ();
					}
				}

				if (this.gameObject.tag == "Picker") {
					if (onExitCollider != null) {
						onExitCollider.Invoke ();
					}
				}

				break;

		case GameUtils.BUNNY_VIEW_SCENE:
			if (this.gameObject.tag == "Brush") {
				if (onExitCollider != null) {
					onExitCollider.Invoke ();
				}
			}
			break;


            case GameUtils.Tiger_VIEW_SCENE:
                if (this.gameObject.tag == "Shower")
                {
                    SoundManager.instance.PlayShowerLoop(false);
                    this.gameObject.transform.GetChild(0).gameObject.SetActive(false);
                    if (onExitCollider != null)
                    {
                        onExitCollider.Invoke();
                    }
                }

                if (this.gameObject.tag == "Towel")
                {
                    SoundManager.instance.PlayRubbingLoop(false);
                    if (onExitCollider != null)
                    {
                        onExitCollider.Invoke();
                    }
                }

                if (this.gameObject.tag == "ToothBrush")
                {
                    SoundManager.instance.PlayBrushingLoop(false);
                    if (onExitCollider != null)
                    {
                        onExitCollider.Invoke();
                    }
                }

                if (this.gameObject.tag == "Sponge")
                {
                    SoundManager.instance.PlaySoapLoop(false);
                    if (onExitCollider != null)
                    {
                        onExitCollider.Invoke();
                    }
                }
                break;


            case GameUtils.BATH_VIEW_SCENE:
                if (this.gameObject.tag == "Shower")
                {
                    SoundManager.instance.PlayShowerLoop(false);
                    this.gameObject.transform.GetChild(0).gameObject.SetActive(false);
                    if (onExitCollider != null)
                    {
                        onExitCollider.Invoke();
                    }
                }

                if (this.gameObject.tag == "Towel")
                {
                    SoundManager.instance.PlayRubbingLoop(false);
                    if (onExitCollider != null)
                    {
                        onExitCollider.Invoke();
                    }
                }

                if (this.gameObject.tag == "ToothBrush")
                {
                    SoundManager.instance.PlayBrushingLoop(false);
                    if (onExitCollider != null)
                    {
                        onExitCollider.Invoke();
                    }
                }

                if (this.gameObject.tag == "Sponge")
                {
                    SoundManager.instance.PlaySoapLoop(false);
                    if (onExitCollider != null)
                    {
                        onExitCollider.Invoke();
                    }
                }
                break;

            case GameUtils.PANDA_VIEW_SCENE:
                if (this.gameObject.tag == "X")
                {
                    SoundManager.instance.PlayscanningLoop(false);
                    if (onTouchEnd != null)
                    {
                        onTouchEnd.Invoke();
                    }
                }
                break;

            case GameUtils.EATING_VIEW_SCENE:
                if (this.gameObject.tag == "eatingItems")
                {
                    //transform.SetParent(ImageParent.transform);

                    if (onTouchEnd != null)
                    {
                        onTouchEnd.Invoke();
                    }
                }
                break;
        }

			rectTransform.localPosition = startPosition;
			rectTransform.transform.eulerAngles = startRotation;


    }

    #endregion

    #region IDragHandler implementation

    public void OnDrag(PointerEventData eventData){
		// dont use localPosition here
		rectTransform.position = Camera.main.ScreenToWorldPoint (Input.mousePosition);
		rectTransform.position = new Vector3 (rectTransform.position.x, rectTransform.position.y, 0);
		if (isStayingInCollider) {
			switch (GameManager.instance.currentScene) {
			case GameUtils.PANDA_VIEW_SCENE:
				if (this.gameObject.tag == "X") {
					if (onExitCollider != null) {
						onExitCollider.Invoke ();
					}
				}
				break;

                case GameUtils.Tiger_VIEW_SCENE:
                    if (this.gameObject.tag == "ToothBrush")
                    {
                        if (onEnterCollider != null)
                        {
                            onEnterCollider.Invoke();
                        }
                    }

                    if (this.gameObject.tag == "Sponge")
                    {
                        if (onEnterCollider != null)
                        {
                            onEnterCollider.Invoke();
                        }
                    }
                    break;

                case GameUtils.BATH_VIEW_SCENE:
                    if (this.gameObject.tag == "ToothBrush")
                    {
                        if (onEnterCollider != null)
                        {
                            onEnterCollider.Invoke();
                        }
                    }

                    if (this.gameObject.tag == "Sponge")
                    {
                        if (onEnterCollider != null)
                        {
                            onEnterCollider.Invoke();
                        }
                    }
                    break;


            }
		}
	}
    #endregion

    #region Collision Detector Methods



    void OnCollisionEnter2D(Collision2D collision){
		switch (GameManager.instance.currentScene) {
		case GameUtils.CAT_VIEW_SCENE:
			if (collision.gameObject.tag == "rat") {
				if (this.gameObject.tag == "rattrap") {
					this.GetComponent<BoxCollider2D> ().enabled = false;
					this.GetComponent<ApplicatorListener> ().enabled = false;
					if (onEnterCollider != null) {
						onEnterCollider.Invoke ();
					}
				}
			}

			if (collision.gameObject.tag == "trash") {
				if (this.gameObject.tag == "leaf") {
					this.GetComponent<BoxCollider2D> ().enabled = false;
					this.GetComponent<ApplicatorListener> ().enabled = false;
					GameManager.instance.currentItem = this.gameObject.name;
					if (onEnterCollider != null) {
						onEnterCollider.Invoke ();
					}
				}
			}

			if (collision.gameObject.tag == "rashes") {
				if (this.gameObject.tag == "rashbrush") {
					GameManager.instance.currentItem = collision.gameObject.name;
					if (onEnterCollider != null) {
						onEnterCollider.Invoke ();
					}
				}
			}

			if (collision.gameObject.tag == "rashgerm1") {
				if (this.gameObject.tag == "rashcream") {
					collision.gameObject.GetComponent<BoxCollider2D> ().enabled = false;
					this.GetComponent<ApplicatorListener> ().enabled = false;
					GameManager.instance.currentItem = collision.gameObject.tag;
					if (onEnterCollider != null) {
						onEnterCollider.Invoke ();
					}
				}
			}

			if (collision.gameObject.tag == "rashgerm2") {
				if (this.gameObject.tag == "rashcream") {
					collision.gameObject.GetComponent<BoxCollider2D> ().enabled = false;
					this.GetComponent<ApplicatorListener> ().enabled = false;
					GameManager.instance.currentItem = collision.gameObject.tag;
					if (onEnterCollider != null) {
						onEnterCollider.Invoke ();
					}
				}
			}

			if (collision.gameObject.tag == "rashgerm3") {
				if (this.gameObject.tag == "rashcream") {
					collision.gameObject.GetComponent<BoxCollider2D> ().enabled = false;
					this.GetComponent<ApplicatorListener> ().enabled = false;
					GameManager.instance.currentItem = collision.gameObject.tag;
					if (onEnterCollider != null) {
						onEnterCollider.Invoke ();
					}
				}
			}

			if (collision.gameObject.tag == "talebandage") {
				if (this.gameObject.tag == "bandage") {
					collision.gameObject.GetComponent<BoxCollider2D> ().enabled = false;
					this.GetComponent<ApplicatorListener> ().enabled = false;
					collision.gameObject.GetComponent<Image> ().enabled = true;
					ParticleManger.instance.showStarParticle (collision.gameObject);
					this.gameObject.SetActive (false);
					if (onEnterCollider != null) {
						onEnterCollider.Invoke ();
					}
				}
			}

			if (collision.gameObject.tag == "mouth") {
				if (this.gameObject.tag == "meat") {
					collision.gameObject.GetComponent<BoxCollider2D> ().enabled = false;
					this.gameObject.GetComponent<BoxCollider2D> ().enabled = false;
					this.GetComponent<ApplicatorListener> ().enabled = false;
					if (onEnterCollider != null) {
						onEnterCollider.Invoke ();
					}
				}
			}

			if (collision.gameObject.tag == "Thorn1") {
				if (this.gameObject.tag == "tweeker") {
					//print ("plast point done"+collision.gameObject.name);
					GameManager.instance.currentItem = collision.gameObject.tag;
					if (onEnterCollider != null) {
						onEnterCollider.Invoke ();
					}
				}
			}

			if (collision.gameObject.tag == "Thorn2") {
				if (this.gameObject.tag == "tweeker") {
					//print ("plast point done"+collision.gameObject.name);
					GameManager.instance.currentItem = collision.gameObject.tag;
					if (onEnterCollider != null) {
						onEnterCollider.Invoke ();
					}
				}
			}

			if (collision.gameObject.tag == "Thorn3") {
				if (this.gameObject.tag == "tweeker") {
					//print ("plast point done"+collision.gameObject.name);
					GameManager.instance.currentItem = collision.gameObject.tag;
					if (onEnterCollider != null) {
						onEnterCollider.Invoke ();
					}
				}
			}

			if (collision.gameObject.tag == "Thorn4") {
				if (this.gameObject.tag == "tweeker") {
					//print ("plast point done"+collision.gameObject.name);
					GameManager.instance.currentItem = collision.gameObject.tag;
					if (onEnterCollider != null) {
						onEnterCollider.Invoke ();
					}
				}
			}

			if (collision.gameObject.tag == "Thorn5") {
				if (this.gameObject.tag == "tweeker") {
					print ("plast point done"+collision.gameObject.name);
					GameManager.instance.currentItem = collision.gameObject.tag;
					if (onEnterCollider != null) {
						onEnterCollider.Invoke ();
					}
				}
			}

			if (collision.gameObject.tag == "tray") {
				if (this.gameObject.tag == "tweeker") {
					//print ("plast point done"+collision.gameObject.name);
					GameManager.instance.currentItem = collision.gameObject.tag;
					if (onEnterCollider != null) {
						onEnterCollider.Invoke ();
					}
				}
			}
				
			break;

		case GameUtils.DOG_VIEW_SCENE:
			if (collision.gameObject.tag == "scannercheckpoint") {
				if (this.gameObject.tag == "scanner") {
					this.GetComponent<BoxCollider2D> ().enabled = false;
					this.GetComponent<ApplicatorListener> ().enabled = false;
					collision.gameObject.GetComponent<BoxCollider2D> ().enabled = false;
					if (onEnterCollider != null) {
						onEnterCollider.Invoke ();
					}
				}
			}

			if (collision.gameObject.tag == "stomachobjects") {
				if (this.gameObject.tag == "Picker") {
					collision.gameObject.GetComponent<BoxCollider2D> ().enabled = false;
					GameManager.instance.currentItem = collision.gameObject.name;
					if (onEnterCollider != null) {
						onEnterCollider.Invoke ();
					}
				}
			}

			if (collision.gameObject.tag == "trash") {
				if (this.gameObject.tag == "Picker") {
					//collision.gameObject.GetComponent<BoxCollider2D> ().enabled = false;
					GameManager.instance.currentItem = collision.gameObject.tag;
					if (onEnterCollider != null) {
						onEnterCollider.Invoke ();
					}
				}
			}

			if (collision.gameObject.tag == "InjectionHitPoint") {
				if (this.gameObject.tag == "Injection") {
					collision.gameObject.GetComponent<BoxCollider2D> ().enabled = false;
					this.gameObject.GetComponent<BoxCollider2D> ().enabled = false;
					this.gameObject.GetComponent<ApplicatorListener> ().enabled = false;
					if (onEnterCollider != null) {
						onEnterCollider.Invoke ();
					}
				}
			}

			if (collision.gameObject.tag == "MedicineMouthPoint") {
				if (this.gameObject.tag == "Medicine") {
					collision.gameObject.GetComponent<BoxCollider2D> ().enabled = false;
					this.gameObject.GetComponent<BoxCollider2D> ().enabled = false;
					this.gameObject.GetComponent<ApplicatorListener> ().enabled = false;
					if (onEnterCollider != null) {
						onEnterCollider.Invoke ();
					}
				}
			}

			if (collision.gameObject.tag == "Cut") {
				if (this.gameObject.tag == "Plaster") {
					collision.gameObject.GetComponent<BoxCollider2D> ().enabled = false;
					this.gameObject.GetComponent<BoxCollider2D> ().enabled = false;
					GameManager.instance.currentItem = collision.gameObject.name;
					this.gameObject.GetComponent<ApplicatorListener> ().enabled = false;
					if (onEnterCollider != null) {
						onEnterCollider.Invoke ();
					}
				}
			}

			if (collision.gameObject.tag == "mouth") {
				if (this.gameObject.tag == "meat") {
					collision.gameObject.GetComponent<BoxCollider2D> ().enabled = false;
					this.gameObject.GetComponent<BoxCollider2D> ().enabled = false;
					this.GetComponent<ApplicatorListener> ().enabled = false;
					if (onEnterCollider != null) {
						onEnterCollider.Invoke ();
					}
				}
			}


			break;

		case GameUtils.BUNNY_VIEW_SCENE:
			if (collision.gameObject.tag == "RightEye") {
				if (this.gameObject.tag == "EyeDropper") {
					//this.GetComponent<BoxCollider2D> ().enabled = false;
					this.GetComponent<ApplicatorListener> ().enabled = false;
					collision.gameObject.GetComponent<BoxCollider2D> ().enabled = false;
					GameManager.instance.currentItem = collision.gameObject.tag;
					if (onEnterCollider != null) {
						onEnterCollider.Invoke ();
					}
				}
			}

			if (collision.gameObject.tag == "LeftEye") {
				if (this.gameObject.tag == "EyeDropper") {
					//this.GetComponent<BoxCollider2D> ().enabled = false;
					this.GetComponent<ApplicatorListener> ().enabled = false;
					collision.gameObject.GetComponent<BoxCollider2D> ().enabled = false;
					GameManager.instance.currentItem = collision.gameObject.tag;
					if (onEnterCollider != null) {
						onEnterCollider.Invoke ();
					}
				}
			}

			if (collision.gameObject.tag == "InjectionHitPoint") {
				if (this.gameObject.tag == "Injection") {
					collision.gameObject.GetComponent<BoxCollider2D> ().enabled = false;
					this.gameObject.GetComponent<BoxCollider2D> ().enabled = false;
					this.gameObject.GetComponent<ApplicatorListener> ().enabled = false;
					if (onEnterCollider != null) {
						onEnterCollider.Invoke ();
					}
				}
			}

			if (collision.gameObject.tag == "MirrorCheckPoint") {
				if (this.gameObject.tag == "Mirror") {
					collision.gameObject.GetComponent<BoxCollider2D> ().enabled = false;
					this.gameObject.GetComponent<BoxCollider2D> ().enabled = false;
					this.gameObject.GetComponent<ApplicatorListener> ().enabled = false;
					if (onEnterCollider != null) {
						onEnterCollider.Invoke ();
					}
				}
			}

			if (collision.gameObject.tag == "Pimple") {
				if (this.gameObject.tag == "Brush") {
					GameManager.instance.currentItem = collision.gameObject.name;
					if (onEnterCollider != null) {
						onEnterCollider.Invoke ();
					}
				}
			}

			if (collision.gameObject.tag == "Plate") {
				if (this.gameObject.tag == "Spoon") {
					collision.gameObject.GetComponent<BoxCollider2D> ().enabled = false;
					GameManager.instance.currentItem = collision.gameObject.tag;
					if (onEnterCollider != null) {
						onEnterCollider.Invoke ();
					}
				}
			}

			if (collision.gameObject.tag == "mouth") {
				if (this.gameObject.tag == "Spoon") {
					collision.gameObject.GetComponent<BoxCollider2D> ().enabled = false;
					GameManager.instance.currentItem = collision.gameObject.tag;
					this.gameObject.GetComponent<ApplicatorListener> ().enabled = false;
					if (onEnterCollider != null) {
						onEnterCollider.Invoke ();
					}
				}
			}


			break;

            case GameUtils.Tiger_VIEW_SCENE:
                if (collision.gameObject.tag == "MirrorCheckPoint")
                {
                    if (this.gameObject.tag == "Mirror")
                    {
                        collision.gameObject.GetComponent<BoxCollider2D>().enabled = false;
                        this.gameObject.GetComponent<BoxCollider2D>().enabled = false;
                        this.gameObject.GetComponent<ApplicatorListener>().enabled = false;
                        if (onEnterCollider != null)
                        {
                            onEnterCollider.Invoke();
                        }
                    }
                }

                if (collision.gameObject.tag == "TeethDirt")
                {
                    if (this.gameObject.tag == "DirtPicker")
                    {
                        collision.gameObject.GetComponent<BoxCollider2D>().enabled = false;
                        collision.gameObject.GetComponent<Rigidbody2D>().gravityScale = 1;
                        collision.gameObject.GetComponent<Rigidbody2D>().constraints = RigidbodyConstraints2D.None;
                        Destroy(collision.gameObject, 3.0f);
                        if (onEnterCollider != null)
                        {
                            onEnterCollider.Invoke();
                        }
                    }
                }

                if (collision.gameObject.tag == "LotionAbovePoint")
                {
                    if (this.gameObject.tag == "Lotion")
                    {
                        collision.gameObject.GetComponent<BoxCollider2D>().enabled = false;
                        this.gameObject.GetComponent<BoxCollider2D>().enabled = false;
                        this.gameObject.GetComponent<ApplicatorListener>().enabled = false;
                        if (onEnterCollider != null)
                        {
                            onEnterCollider.Invoke();
                        }
                    }
                }

                if (collision.gameObject.tag == "Paste")
                {
                    if (this.gameObject.tag == "Shower")
                    {
                        Destroy(collision.gameObject);
                        if (onEnterCollider != null)
                        {
                            onEnterCollider.Invoke();
                        }
                    }
                }

                if (collision.gameObject.tag == "WaterVapors")
                {
                    if (this.gameObject.tag == "Towel")
                    {
                        if (onEnterCollider != null)
                        {
                            onEnterCollider.Invoke();
                        }
                    }
                }

                break;

            case GameUtils.BATH_VIEW_SCENE:
                if (collision.gameObject.tag == "MirrorCheckPoint")
                {
                    if (this.gameObject.tag == "Mirror")
                    {
                        collision.gameObject.GetComponent<BoxCollider2D>().enabled = false;
                        this.gameObject.GetComponent<BoxCollider2D>().enabled = false;
                        this.gameObject.GetComponent<ApplicatorListener>().enabled = false;
                        if (onEnterCollider != null)
                        {
                            onEnterCollider.Invoke();
                        }
                    }
                }

                if (collision.gameObject.tag == "TeethDirt")
                {
                    if (this.gameObject.tag == "DirtPicker")
                    {
                        collision.gameObject.GetComponent<BoxCollider2D>().enabled = false;
                        collision.gameObject.GetComponent<Rigidbody2D>().gravityScale = 1;
                        collision.gameObject.GetComponent<Rigidbody2D>().constraints = RigidbodyConstraints2D.None;
                        Destroy(collision.gameObject, 3.0f);
                        if (onEnterCollider != null)
                        {
                            onEnterCollider.Invoke();
                        }
                    }
                }

                if (collision.gameObject.tag == "LotionAbovePoint")
                {
                    if (this.gameObject.tag == "Lotion")
                    {
                        collision.gameObject.GetComponent<BoxCollider2D>().enabled = false;
                        this.gameObject.GetComponent<BoxCollider2D>().enabled = false;
                        this.gameObject.GetComponent<ApplicatorListener>().enabled = false;
                        if (onEnterCollider != null)
                        {
                            onEnterCollider.Invoke();
                        }
                    }
                }

                if (collision.gameObject.tag == "Paste")
                {
                    if (this.gameObject.tag == "Shower")
                    {
                        Destroy(collision.gameObject);
                        if (onEnterCollider != null)
                        {
                            onEnterCollider.Invoke();
                        }
                    }
                }

                if (collision.gameObject.tag == "WaterVapors")
                {
                    if (this.gameObject.tag == "Towel")
                    {
                        if (onEnterCollider != null)
                        {
                            onEnterCollider.Invoke();
                        }
                    }
                }

                break;

            case GameUtils.PANDA_VIEW_SCENE:
                if (collision.gameObject.tag == "Crack")
                {
                    if (this.gameObject.tag == "X")
                    {
                        collision.gameObject.GetComponent<Collider2D>().enabled = false;
                        this.gameObject.GetComponent<Collider2D>().enabled = false;
                        if (onEnterCollider != null)
                        {
                            onEnterCollider.Invoke();
                        }
                    }
                }

                if (collision.gameObject.tag == "Bone1")
                {
                    if (this.gameObject.tag == "Bone1")
                    {
                        collision.gameObject.GetComponent<BoxCollider2D>().enabled = false;
                        this.gameObject.SetActive(false);
                        collision.gameObject.GetComponent<Image>().enabled = true;
                        ParticleManger.instance.showStarParticle(collision.gameObject);
                        if (onEnterCollider != null)
                        {
                            onEnterCollider.Invoke();
                        }
                    }
                }

                if (collision.gameObject.tag == "Bone2")
                {
                    if (this.gameObject.tag == "Bone2")
                    {
                        collision.gameObject.GetComponent<BoxCollider2D>().enabled = false;
                        this.gameObject.SetActive(false);
                        collision.gameObject.GetComponent<Image>().enabled = true;
                        ParticleManger.instance.showStarParticle(collision.gameObject);
                        if (onEnterCollider != null)
                        {
                            onEnterCollider.Invoke();
                        }
                    }
                }

                if (collision.gameObject.tag == "Bone3")
                {
                    if (this.gameObject.tag == "Bone3")
                    {
                        collision.gameObject.GetComponent<BoxCollider2D>().enabled = false;
                        this.gameObject.SetActive(false);
                        collision.gameObject.GetComponent<Image>().enabled = true;
                        ParticleManger.instance.showStarParticle(collision.gameObject);
                        if (onEnterCollider != null)
                        {
                            onEnterCollider.Invoke();
                        }
                    }
                }

                if (collision.gameObject.tag == "Bone4")
                {
                    if (this.gameObject.tag == "Bone4")
                    {
                        collision.gameObject.GetComponent<BoxCollider2D>().enabled = false;
                        this.gameObject.SetActive(false);
                        collision.gameObject.GetComponent<Image>().enabled = true;
                        ParticleManger.instance.showStarParticle(collision.gameObject);
                        if (onEnterCollider != null)
                        {
                            onEnterCollider.Invoke();
                        }
                    }
                }

                if (collision.gameObject.tag == "Bone5")
                {
                    if (this.gameObject.tag == "Bone5")
                    {
                        collision.gameObject.GetComponent<BoxCollider2D>().enabled = false;
                        this.gameObject.SetActive(false);
                        collision.gameObject.GetComponent<Image>().enabled = true;
                        ParticleManger.instance.showStarParticle(collision.gameObject);
                        if (onEnterCollider != null)
                        {
                            onEnterCollider.Invoke();
                        }
                    }
                }

                if (collision.gameObject.tag == "HeadBandage")
                {
                    if (this.gameObject.tag == "HeadBandage")
                    {
                        collision.gameObject.GetComponent<BoxCollider2D>().enabled = false;
                        ParticleManger.instance.showPointingParticle(collision.gameObject);
                        this.gameObject.SetActive(false);
                        collision.gameObject.GetComponent<Image>().enabled = true;
                        if (onEnterCollider != null)
                        {
                            onEnterCollider.Invoke();
                        }
                    }
                }

                if (collision.gameObject.tag == "ArmBandage")
                {
                    if (this.gameObject.tag == "ArmBandage")
                    {
                        collision.gameObject.GetComponent<BoxCollider2D>().enabled = false;
                        this.gameObject.SetActive(false);
                        collision.gameObject.GetComponent<Image>().enabled = true;
                        ParticleManger.instance.showPointingParticle(collision.gameObject);
                        if (onEnterCollider != null)
                        {
                            onEnterCollider.Invoke();
                        }
                    }
                }

                if (collision.gameObject.tag == "MedicineMouthPoint")
                {
                    if (this.gameObject.tag == "Medicine")
                    {
                        collision.gameObject.GetComponent<BoxCollider2D>().enabled = false;
                        this.gameObject.GetComponent<BoxCollider2D>().enabled = false;
                        this.gameObject.GetComponent<ApplicatorListener>().enabled = false;
                        if (onEnterCollider != null)
                        {
                            onEnterCollider.Invoke();
                        }
                    }
                }

                if (collision.gameObject.tag == "Plate")
                {
                    if (this.gameObject.tag == "Spoon")
                    {
                        collision.gameObject.GetComponent<BoxCollider2D>().enabled = false;
                        GameManager.instance.currentItem = collision.gameObject.tag;
                        if (onEnterCollider != null)
                        {
                            onEnterCollider.Invoke();
                        }
                    }
                }

                if (collision.gameObject.tag == "mouth")
                {
                    if (this.gameObject.tag == "Spoon")
                    {
                        collision.gameObject.GetComponent<BoxCollider2D>().enabled = false;
                        GameManager.instance.currentItem = collision.gameObject.tag;
                        this.gameObject.GetComponent<ApplicatorListener>().enabled = false;
                        if (onEnterCollider != null)
                        {
                            onEnterCollider.Invoke();
                        }
                    }
                }

                break;

            case GameUtils.EATING_VIEW_SCENE:

                if (collision.gameObject.tag == "mouth")
                {
                    if (this.gameObject.tag == "eatingItems")
                    {
                        //collision.gameObject.GetComponent<BoxCollider2D>().enabled = false;
                        this.gameObject.GetComponent<BoxCollider2D>().enabled = false;
                        this.GetComponent<ApplicatorListener>().enabled = false;
                        if (onEnterCollider != null)
                        {
                            onEnterCollider.Invoke();
                        }
                    }
                }

                break;
        }
	}

        
    void OnCollisionStay2D(Collision2D collision){
		switch (GameManager.instance.currentScene)
        {
            case GameUtils.Tiger_VIEW_SCENE:
                if (collision.gameObject.tag == "TeethUpperDirt")
                {
                    if (this.gameObject.tag == "ToothBrush")
                    {
                        GameManager.instance.currentItem = collision.gameObject.tag;
                        GameManager.instance.contact = collision.contacts[0];
                        isStayingInCollider = true;
                    }
                }

                if (collision.gameObject.tag == "TeethLowerDirt")
                {
                    if (this.gameObject.tag == "ToothBrush")
                    {
                        GameManager.instance.currentItem = collision.gameObject.tag;
                        GameManager.instance.contact = collision.contacts[0];
                        isStayingInCollider = true;
                    }
                }

                if (collision.gameObject.tag == "TigerBody")
                {
                    if (this.gameObject.tag == "Sponge")
                    {
                        GameManager.instance.contact = collision.contacts[0];
                        isStayingInCollider = true;
                    }
                }




                break;
            case GameUtils.BATH_VIEW_SCENE:
                if (collision.gameObject.tag == "TeethUpperDirt")
                {
                    if (this.gameObject.tag == "ToothBrush")
                    {
                        GameManager.instance.currentItem = collision.gameObject.tag;
                        GameManager.instance.contact = collision.contacts[0];
                        isStayingInCollider = true;
                    }
                }

                if (collision.gameObject.tag == "TeethLowerDirt")
                {
                    if (this.gameObject.tag == "ToothBrush")
                    {
                        GameManager.instance.currentItem = collision.gameObject.tag;
                        GameManager.instance.contact = collision.contacts[0];
                        isStayingInCollider = true;
                    }
                }

                if (collision.gameObject.tag == "TigerBody")
                {
                    if (this.gameObject.tag == "Sponge")
                    {
                        GameManager.instance.contact = collision.contacts[0];
                        isStayingInCollider = true;
                    }
                }




                break;
        }

    }

    void OnCollisionExit2D(Collision2D collision) {
		isStayingInCollider = false;

    }

    #endregion
}
