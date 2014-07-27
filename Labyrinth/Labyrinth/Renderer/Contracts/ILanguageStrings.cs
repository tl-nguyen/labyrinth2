// ********************************
// <copyright file="ILanguageStrings.cs" company="Telerik Academy">
// Copyright (c) 2014 Telerik Academy. All rights reserved.
// </copyright>
//
// ********************************
namespace Labyrinth.Renderer.Contracts
{
    using Labyrinth.Commons;
    
    /// <summary>
    /// The Interface for game dialogs implementations
    /// </summary>
    public interface ILanguageStrings
    {
        /// <summary>
        /// Returns the dialog string, corresponding to the given string key.
        /// </summary>
        /// <param name="key">The dialog key that you want to get</param>
        /// <returns>The wanted dialog</returns>
        string GetDialog(Dialog key);
    }
}