using System.Collections.Generic;

namespace RoleplayGame
{
    /// <summary>
    /// Interface para los personajes que pueden controlar y utilizar Items mágicos
    /// </summary>
    public interface IMagicCharacter
    {
        public List<IMagicItem> MagicItems { get; }
        void AddMagicItem(IMagicItem magicItem);
        void RemoveMagicItem(IMagicItem magicItem);
    }
}