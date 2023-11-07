using UnityEngine;
using UnityEngine.Events;

namespace DefaultNamespace
{
    [CreateAssetMenu(fileName = "IntVariable", menuName = "Kanelbulle/IntVariable", order = 0)]
    public class Test : ScriptableObject
    {
        
        public UnityEvent<int> ValueChanged;
        public UnityEvent<string> StringValueChanged;
        private int value;

        public void SetValue(int newValue)
        {
            value = newValue;
            ValueChanged.Invoke(newValue);
            StringValueChanged.Invoke(newValue.ToString());
        }

        public int GetValue()
        {
            return value;
        }
    }

}