using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CarGenerateManager : MonoBehaviour
{
    public static CarGenerateManager Instance { get; private set; }
    public GameObject CarInstantiated { get; private set; }

    [SerializeField] private CarsSO car;
    [SerializeField] private ColorTexturersSO[] color;

    [SerializeField] private Transform spawnPoint;

    private void Awake()
    {
        Instance = this;
        SpawningCar();
    }

    private void Start()
    {
        //SpawningCar();
    }

    private void Update()
    {
        TESTEDECUSTOMIZACAO();
    }

    private void SpawningCar()
    {
        CarInstantiated = Instantiate(car.car, spawnPoint.position, Quaternion.identity);
        CarCustomized(CarInstantiated);
    }

    private void CarCustomized(GameObject car)
    {
        //setar valores ssalvo da customização do carro
        TESTEDECUSTOMIZACAOSETTED(car);
    }

    //------------------ TESTES ATRIBUTOS CUSTTOMIZAVEIS CARRO ------------------------
    private void TESTEDECUSTOMIZACAOSETTED(GameObject car)
    {   
        car.GetComponent<CarPartsManagement>().SettingAttributesCar(color[3].color);
    }

    private void TESTEDECUSTOMIZACAO()
    {
        if (Input.GetKeyDown(KeyCode.F))
        {
            CarInstantiated.GetComponent<Renderer>().material.color = color[0].color;
        }
        if (Input.GetKeyDown(KeyCode.G))
        {
            CarInstantiated.GetComponent<Renderer>().material.color = color[1].color;
        }
        if (Input.GetKeyDown(KeyCode.H))
        {
            CarInstantiated.GetComponent<Renderer>().material.color = color[2].color;
        }
        if (Input.GetKeyDown(KeyCode.J))
        {
            CarInstantiated.GetComponent<Renderer>().material.color = color[3].color;
        }
    }
}
