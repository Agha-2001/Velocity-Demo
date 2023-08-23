using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class LevelManager : Singleton<LevelManager>
{
    [SerializeField] private GameObject loaderCanvas;
    [SerializeField] private Image progressBar;
    [SerializeField] private float duration;
    private float target;

    protected override void Awake()
    {
        base.Awake();
        DontDestroyOnLoad(this.gameObject);
    }

    public async void LoadScene(string sceneName)
    {
        CanvasManager.GetInstance().CloseAllCanvas();

        target = 0;
        var scene = SceneManager.LoadSceneAsync(sceneName);
        scene.allowSceneActivation = false;

        loaderCanvas.SetActive(true);

        // Wait for the minimum display time (3 seconds)
        await Task.Delay((int)(duration * 1000));

        // Continue loading the scene until progress is close to 0.9
        while (scene.progress < 0.9f)
        {
            await Task.Delay(100);
            target = scene.progress;
        }

        scene.allowSceneActivation = true;
        loaderCanvas.SetActive(false);
    }

    private void Update()
    {
        progressBar.fillAmount = Mathf.MoveTowards(progressBar.fillAmount, target, 3f * Time.deltaTime);
    }
}
