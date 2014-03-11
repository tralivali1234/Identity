﻿using System;
using System.Threading.Tasks;

namespace Microsoft.AspNet.Identity
{
    /// <summary>
    ///     Interface to generate user tokens
    /// </summary>
    public interface IUserTokenProvider<TUser, TKey> where TUser : class, IUser<TKey> where TKey : IEquatable<TKey>
    {
        /// <summary>
        ///     Generate a token for a user
        /// </summary>
        /// <param name="purpose"></param>
        /// <param name="manager"></param>
        /// <param name="user"></param>
        /// <returns></returns>
        Task<string> Generate(string purpose, UserManager<TUser, TKey> manager, TUser user);

        /// <summary>
        ///     Validate and unprotect a token, returns null if invalid
        /// </summary>
        /// <param name="purpose"></param>
        /// <param name="token"></param>
        /// <param name="manager"></param>
        /// <param name="user"></param>
        /// <returns></returns>
        Task<bool> Validate(string purpose, string token, UserManager<TUser, TKey> manager, TUser user);

        /// <summary>
        ///     Notifies the user that a token has been generated, i.e. via email or sms, or can no-op
        /// </summary>
        /// <param name="token"></param>
        /// <param name="manager"></param>
        /// <param name="user"></param>
        /// <returns></returns>
        Task Notify(string token, UserManager<TUser, TKey> manager, TUser user);

        /// <summary>
        ///     Returns true if provider can be used for this user, i.e. could require a user to have an email
        /// </summary>
        /// <param name="manager"></param>
        /// <param name="user"></param>
        /// <returns></returns>
        Task<bool> IsValidProviderForUser(UserManager<TUser, TKey> manager, TUser user);
    }
}