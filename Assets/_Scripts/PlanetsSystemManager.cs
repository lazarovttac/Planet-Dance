using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using TMPro;

public class PlanetsSystemManager : MonoBehaviour
{
    public float timeScale = 1;
    public Slider tSlider;
    public TextMeshProUGUI tText;

    
    [SerializeField]
    private Transform planetSettingsParent;
    [SerializeField]
    private GameObject planetSettingsPrefab;
    [SerializeField]
    private GameObject planetPrefab;

    [System.Serializable]
    public class Planet
    {
        public PlanetSettings settings;
        public OrbitAround script;
        public TrailRenderer trail;
    }

    [SerializeField]
    public List<Planet> planets = new List<Planet>();

    void Start()
    {
        tSlider.onValueChanged.AddListener (delegate {tChanged ();});
    }

    void Update()
    {
        foreach (Planet planet in planets) {
            planet.script.a = planet.settings.a;
            planet.script.b = planet.settings.b;
            planet.script.w = planet.settings.w;

            planet.trail.time = planet.settings.tT;

            planet.trail.startColor = planet.settings.startTrailColor;
            planet.trail.endColor = planet.settings.endTrailColor;

            planet.trail.startWidth = planet.settings.sW;
            planet.trail.endWidth = planet.settings.eW;
        }

        tText.text = timeScale.ToString();
    }

    public void tChanged() {
        timeScale = tSlider.value;
        Time.timeScale = timeScale;
    }
    
    public void CreateNewPlanet() {
        Transform parent = null;
        
        if(planets.Count - 1 >= 0) {
            parent = planets[planets.Count - 1].script.gameObject.transform;
        } 
        
        GameObject planetObject = Instantiate(planetPrefab, Vector3.zero, Quaternion.identity);
        planetObject.transform.SetParent(parent);
        GameObject planetSettingsObject = Instantiate(planetSettingsPrefab, Vector3.zero, Quaternion.identity, planetSettingsParent);
        
        Planet newPlanet = new Planet();
        newPlanet.script = planetObject.GetComponent<OrbitAround>();
        newPlanet.settings = planetSettingsObject.GetComponent<PlanetSettings>();
        newPlanet.trail = planetObject.GetComponentInChildren<TrailRenderer>();
        newPlanet.settings.planetName = (planets.Count + 1) + "° Planet";

        planets.Add(newPlanet);
        ResetPositions();
    }

    public void DeleteLastPlanet() {
        int index = planets.Count - 1;

        Destroy(planets[index].script.gameObject);
        Destroy(planets[index].settings.gameObject);

        planets.RemoveAt(index);
    }

    
    public void RestartTrails() {
        foreach (Planet planet in planets) {
            planet.script.trail.Clear();
        }
    }

    public void ResetPositions() {
        foreach (Planet planet in planets) {
            planet.script.angle = 0;
            StartCoroutine(planet.script.InitialReset());
        }
    }
}
