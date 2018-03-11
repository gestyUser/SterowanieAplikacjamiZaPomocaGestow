/////////////////////////////////////////////////
//                  CREATE                      
//Author:       Dominika Brzozowska
//Date:         2017-10-22
//Description:  Rysowanie lini 3D
/////////////////////////////////////////////////
//                  CHANGE                      
//Author:       Piotr Arent
//Date:         2017-11-11
//Description:  Naprawa buga który powodował zmiane pozycji kamery podczas rozpoczęcia rysowania
/////////////////////////////////////////////////
//                  CHANGE                      
//Author:       Piotr Arent
//Date:         2017-11-19
//Description:  Przystosowanie klasy do pracy z kinectem w przestrzeni 3D
/////////////////////////////////////////////////
//                  CHANGE                      
//Author:       Dawid Sklorz
//Date:         2018-01-07
//Description:  Zmiana przestrzeni rysowania kinectem w 3D
/////////////////////////////////////////////////

using UnityEngine;

public class KinectDrawLineCursor : AbstractKinectUICursor
{
    [SerializeField]
    //Siatka cylindra
    public Transform cylinderPrefab;

    //Środek kul
    private GameObject begin = null;
    private GameObject end = null;

    private GameObject cylinder;

    private Vector3 mousePos_s;
    private Vector3 mousePos_e;

    private float speed = 100f;
    private const float scale = 0.2f;

    //tablica z kolorami
    public Material[] line_color;
    private int index = 0;

    public Color normalColor = new Color(1f, 1f, 1f, 0.5f);
    public Color hoverColor = new Color(1f, 1f, 1f, 1f);
    public Color clickColor = new Color(1f, 1f, 1f, 1f);
    public Vector3 clickScale = new Vector3(.8f, .8f, .8f);

    private Vector3 _initScale;

    private bool juststarted = true;

    public override void Start()
    {
        base.Start();
        _initScale = transform.localScale;
        _image.color = new Color(1f, 1f, 1f, 0f);
    }

    private void DrawUpdate()
    {
        //Inicjalizuje dwie kulki pomiędzy, którymi będzie potem rysowany walec
        begin = GameObject.CreatePrimitive(PrimitiveType.Sphere);
        end = GameObject.CreatePrimitive(PrimitiveType.Sphere);

        //Ustawienie skali
        begin.transform.localScale = new Vector3(scale, scale, scale);
        end.transform.localScale = new Vector3(scale, scale, scale);

        //Przygotowanie do rysowania 3D
        Plane objPlane = new Plane(new Vector3(Camera.main.transform.forward.x, Camera.main.transform.forward.y, Camera.main.transform.forward.z), new Vector3(this.transform.position.x, this.transform.position.y, this.transform.position.z * 100));
        Ray mRay = Camera.main.ScreenPointToRay(_data.GetHandScreenPosition());
        float rayDistance;
        if (objPlane.Raycast(mRay, out rayDistance))

            //Zmiana koloru wraz ze sprawdzeniem by nie wychodzić po za zakres tablicy
            if (juststarted)
            {
                mousePos_e = mRay.GetPoint(rayDistance * 0.0040f);

                if (index < line_color.Length - 1)
                    index++;
                else
                    index = 0;
            }
        juststarted = false;
        //Ustawienie koloru
        MeshRenderer beginRenderer = begin.GetComponent<MeshRenderer>();
        MeshRenderer endRenderer = end.GetComponent<MeshRenderer>();

        beginRenderer.material = line_color[index];
        endRenderer.material = line_color[index];

        beginRenderer.sharedMaterial = line_color[index];
        endRenderer.sharedMaterial = line_color[index];

        //Pobieramy pozycję myszki
        mousePos_s = mousePos_e;
        mousePos_e = mRay.GetPoint(rayDistance * 0.0040f);

        //Ustalamy pozycję dla kulek
        begin.transform.position = mousePos_s;
        end.transform.position = mousePos_e;

        //Wywołujemy procedurę, która obliczy nam pozycję cylindra
        InstantiateCylinder(cylinderPrefab, begin.transform.position, end.transform.position);

        //Wywołujemy procedurę, która obliczy nam pozycję cylindra (odświeża)
        UpdateCylinderPosition(cylinder, begin.transform.position, end.transform.position, line_color[index]);
        if (_data.CurrentHandState.Equals(Windows.Kinect.HandState.Open))
            juststarted = true;
    }

    private void InstantiateCylinder(Transform cylinderPrefab, Vector3 beginPoint, Vector3 endPoint)
    {
        //Inicjalizujemy obiekt cylinder
        cylinder = Instantiate<GameObject>(cylinderPrefab.gameObject, Vector3.zero, Quaternion.identity);

    }

    private void UpdateCylinderPosition(GameObject cylinder, Vector3 beginPoint, Vector3 endPoint, Material material)
    {
        //Ustawienie koloru
        MeshRenderer cylinderRenderer = cylinder.GetComponent<MeshRenderer>();
        cylinderRenderer.sharedMaterial = line_color[index];

        //Obliczamy odległość pomiędzy początkiem, a końcem
        Vector3 offset = endPoint - beginPoint;

        //Obliczamy pozycję dla cylindra
        Vector3 position = beginPoint + (offset / 2.0f);

        //Uaktualniamy pozycję cylindra
        cylinder.transform.position = position;
        cylinder.transform.LookAt(beginPoint);

        //Dostosowujemy skalę
        Vector3 localScale = cylinder.transform.localScale;
        localScale.x = scale;
        localScale.y = scale;
        localScale.z = (endPoint - beginPoint).magnitude;
        cylinder.transform.localScale = localScale;
    }

    public override void ProcessData()
    {
        // update pos
        transform.position = _data.GetHandScreenPosition();
        if (_data.IsPressing)
        {
            DrawUpdate();
            _image.color = clickColor;
            _image.transform.localScale = clickScale;
            return;
        }
        if (_data.IsHovering)
        {
            _image.color = hoverColor;
        }
        else
        {
            _image.color = normalColor;
        }
        _image.transform.localScale = _initScale;
    }
}