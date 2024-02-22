using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class EnemyWave : ISerializationCallbackReceiver
{
    [SerializeField] private List<EnemyData> _enemys = new List<EnemyData>();

    public IList<EnemyData> Enemys { get => _enemys.AsReadOnly(); }

    public void OnBeforeSerialize()
    {
        Validate();
    }

    public void OnAfterDeserialize()
    {
    }


    private void Validate()
    {
        int maxCount = GameConfig.MAX_ENEMY_IN_SQUAD;

        if (_enemys.Count > maxCount)
        {
            int excess = _enemys.Count - maxCount;
            _enemys.RemoveRange(maxCount, excess);
            throw new System.ArgumentException($"The maximum number of units in a Squad should not exceed {maxCount}");
        }
    }
}
