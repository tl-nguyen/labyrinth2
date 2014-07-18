﻿namespace Labyrinth.Entities.Contracts
{
    interface IUiText : IRenderable
    {
        void SetText(string input, string[] args);
        void SetText(string input, bool isKey);
        void SetText(string input);
        void Clear();
    }
}