using System;
using System.Collections.Generic;

namespace CustomEnum
{
    public abstract class BaseEnum<TKey, TValue, TDerived> where TDerived : BaseEnum<TKey, TValue, TDerived>
    {
        internal TKey Key { get; set; }
        internal TValue Value { get; }

        internal BaseEnum() { }

        protected BaseEnum(TKey key, TValue value)
        {
            if (key == null || value == null) throw new ArgumentNullException();
            Value = value;
            Key = key;
            KeyDictionary.Add(key, this);
            ValueDictionary.Add(value, this);
        }

        #region Dictionaries
        internal static Dictionary<TKey, BaseEnum<TKey, TValue, TDerived>> KeyDictionary { get; } = new Dictionary<TKey, BaseEnum<TKey, TValue, TDerived>>();
        internal static Dictionary<TValue, BaseEnum<TKey, TValue, TDerived>> ValueDictionary { get; } = new Dictionary<TValue, BaseEnum<TKey, TValue, TDerived>>();
        #endregion

        #region Helpful Methods
        /// <summary>
        /// Check if enum contains key
        /// </summary>
        /// <param name="key">Key to check</param>
        /// <returns>True if the enum key exists</returns>
        public static bool Contains(TKey key)
        {
            return KeyDictionary.ContainsKey(key);
        }

        /// <summary>
        /// CHeck if the enum contains value
        /// </summary>
        /// <param name="value">Value to check</param>
        /// <returns>True if the enum value exists</returns>
        public static bool Contains(TValue value)
        {
            return ValueDictionary.ContainsKey(value);
        }
        #endregion

        #region Equals
        public override bool Equals(object obj)
        {
            BaseEnum<TKey, TValue, TDerived> cstEnum = obj as BaseEnum<TKey, TValue, TDerived>;
            if (cstEnum == null) return false;
            return cstEnum.Key.Equals(Key);
        }

        public override int GetHashCode()
        {
            var hashCode = 206514262;
            hashCode = hashCode * -1521134295 + EqualityComparer<TKey>.Default.GetHashCode(Key);
            hashCode = hashCode * -1521134295 + EqualityComparer<TValue>.Default.GetHashCode(Value);
            return hashCode;
        }
        #endregion

        #region Cast Methods
        /// <summary>
        /// Cast key to derived enum
        /// </summary>
        /// <param name="key">Key to cast</param>
        /// <returns>Derived enum if exists</returns>
        /// <exception cref="KeyNotFoundException"></exception>
        protected static TDerived From(TKey key) => (TDerived)KeyDictionary[key];

        /// <summary>
        /// Cast value to derived enum
        /// </summary>
        /// <param name="value">Value to cast</param>
        /// <returns>Derived enum if exists</returns>
        /// <exception cref="KeyNotFoundException"></exception>
        protected static TDerived From(TValue value) => (TDerived)ValueDictionary[value];
        #endregion

        #region Accessors
        /// <summary>
        /// Get enum key
        /// </summary>
        /// <returns>Enum key</returns>
        public TKey GetKey() => Key;

        /// <summary>
        /// Get enum value
        /// </summary>
        /// <returns>Enum value</returns>
        public TValue GetValue() => Value;
        #endregion
    }
}
