using System.Collections;
using UnityEngine;

public class MusicManager : MonoBehaviour
{
    private AudioSource audioSource;

    [Header("Music Tracks")]
    [SerializeField] private AudioClip introClip;  // Стартовая композиция (играет 1 раз)
    [SerializeField] private AudioClip loopClip;   // Основная тема (играет по кругу)

    void Start()
    {
        audioSource = GetComponent<AudioSource>();
        // Проверяем, всё ли привязано, чтобы избежать NullReference
        if (audioSource != null && introClip != null && loopClip != null)
        {
            StartCoroutine(PlayMusicPlaylist());
        }
        else
        {
            Debug.LogError("Музыкальный менеджер: Забыл привязать AudioSource или треки в Инспекторе!");
        }
    }

    private IEnumerator PlayMusicPlaylist()
    {
        // 1. Настраиваем и запускаем интро
        audioSource.clip = introClip;
        audioSource.loop = false; // Интро НЕ должно циклиться
        audioSource.Play();

        // 2. Ждем, пока интро полностью доиграет
        // Длина ожидания равна длительности трека в секундах
        yield return new WaitForSeconds(introClip.length);

        // 3. Как только время прошло — переключаемся на основную тему
        audioSource.clip = loopClip;
        audioSource.loop = true;  // Включаем бесконечный повтор
        audioSource.Play();
    }
}