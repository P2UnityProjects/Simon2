using UnityEngine;

public class S2_RailBoard : MonoBehaviour
{
    S2_Spline spline = null;
    float currentIndex = 0;

    [SerializeField] float moveSpeed = 10;

    public bool IsValid => spline;

    private void Update()
    {
        MoveTo();
        RotateTo();
        currentIndex += Time.deltaTime * moveSpeed;
    }

    public void SetSpline(S2_Spline _spline) => spline = _spline;

    void MoveTo()
    {
        if (!IsValid) return;
        transform.localPosition = spline.GetPoint(currentIndex);
    }
    void RotateTo()
    {
        if (!IsValid) return;
        transform.LookAt(spline.GetPoint(currentIndex) + spline.GetDirection(currentIndex));
    }
}
