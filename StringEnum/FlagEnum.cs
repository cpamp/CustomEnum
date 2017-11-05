using System;
using System.Collections.Generic;
using System.Text;

namespace CustomEnum
{
    public abstract class FlagEnum<TValue, TDerived> : BaseEnum<int, TValue, TDerived>
        where TDerived : FlagEnum<TValue, TDerived>, new()
    {
        public FlagEnum() { }

        public FlagEnum(int key, TValue value) : base(key, value)
        { }

        #region Helpful methods
        /// <summary>
        /// Check if enum contains flag
        /// </summary>
        /// <param name="flag">Flag to check</param>
        /// <returns>True if the enum contains the flag</returns>
        public bool HasFlag(FlagEnum<TValue, TDerived> flag)
        {
            return (int)(this & flag) != 0;
        }

        /// <summary>
        /// Check if enum contains all flags
        /// </summary>
        /// <param name="flags">Flags to check</param>
        /// <returns>True if enum contains all flags</returns>
        public bool HasFlags(params FlagEnum<TValue, TDerived>[] flags)
        {
            foreach (var flag in flags)
            {
                if ((int)(flag & this) == 0) return false;
            }
            return true;
        }
        #endregion

        #region Operators
        public static TDerived operator |(FlagEnum<TValue, TDerived> flag1, FlagEnum<TValue, TDerived> flag2)
        {
            return From(flag1.Key | flag2.Key);
        }

        public static TDerived operator &(FlagEnum<TValue, TDerived> flag1, FlagEnum<TValue, TDerived> flag2)
        {
            return From(flag1.Key & flag2.Key);
        }

        public static explicit operator int(FlagEnum<TValue, TDerived> enm)
        {
            return enm.Key;
        }
        #endregion

        #region Cast
        /// <summary>
        /// Cast key to derived enum
        /// </summary>
        /// <param name="key">Key to cast</param>
        /// <returns>Derived enum matching key OR new enum if not exists</returns>
        protected new static TDerived From(int key)
        {
            if (KeyDictionary.ContainsKey(key))
            {
                return (TDerived)KeyDictionary[key];
            }

            var result = new TDerived
            {
                Key = key
            };
            KeyDictionary.Add(key, result);
            return result;
        }
        #endregion
    }
}
