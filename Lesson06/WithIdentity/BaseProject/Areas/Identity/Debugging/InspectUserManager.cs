﻿using System;
using System.Collections.Generic;
using System.Security.Claims;
using System.Threading.Tasks;
using BaseProject.Areas.Identity.Data;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;

namespace BaseProject.Areas.Identity.Services
{
    public class InspectUserManager : UserManager<User>
    {
        public InspectUserManager(
            IUserStore<User> store,
            IOptions<IdentityOptions> optionsAccessor,
            IPasswordHasher<User> passwordHasher,
            IEnumerable<IUserValidator<User>> userValidators,
            IEnumerable<IPasswordValidator<User>> passwordValidators,
            ILookupNormalizer keyNormalizer,
            IdentityErrorDescriber errors,
            IServiceProvider services,
            ILogger<UserManager<User>> logger)
            : base(store, optionsAccessor, passwordHasher, userValidators, passwordValidators, keyNormalizer, errors, services, logger)
        {
        }

        public override Task<IdentityResult> AccessFailedAsync(User user)
        {
            return base.AccessFailedAsync(user);
        }

        public override Task<IdentityResult> AddClaimAsync(User user, Claim claim)
        {
            return base.AddClaimAsync(user, claim);
        }

        public override Task<IdentityResult> AddClaimsAsync(User user, IEnumerable<Claim> claims)
        {
            return base.AddClaimsAsync(user, claims);
        }

        public override Task<IdentityResult> AddLoginAsync(User user, UserLoginInfo login)
        {
            return base.AddLoginAsync(user, login);
        }

        public override Task<IdentityResult> AddPasswordAsync(User user, string password)
        {
            return base.AddPasswordAsync(user, password);
        }

        public override Task<IdentityResult> AddToRoleAsync(User user, string role)
        {
            return base.AddToRoleAsync(user, role);
        }

        public override Task<IdentityResult> AddToRolesAsync(User user, IEnumerable<string> roles)
        {
            return base.AddToRolesAsync(user, roles);
        }

        public override Task<IdentityResult> ChangeEmailAsync(User user, string newEmail, string token)
        {
            return base.ChangeEmailAsync(user, newEmail, token);
        }

        public override Task<IdentityResult> ChangePasswordAsync(User user, string currentPassword, string newPassword)
        {
            return base.ChangePasswordAsync(user, currentPassword, newPassword);
        }

        public override Task<IdentityResult> ChangePhoneNumberAsync(User user, string phoneNumber, string token)
        {
            return base.ChangePhoneNumberAsync(user, phoneNumber, token);
        }

        public override Task<bool> CheckPasswordAsync(User user, string password)
        {
            return base.CheckPasswordAsync(user, password);
        }

        public override Task<IdentityResult> ConfirmEmailAsync(User user, string token)
        {
            return base.ConfirmEmailAsync(user, token);
        }

        public override Task<int> CountRecoveryCodesAsync(User user)
        {
            return base.CountRecoveryCodesAsync(user);
        }

        public override Task<IdentityResult> CreateAsync(User user)
        {
            return base.CreateAsync(user);
        }

        public override Task<IdentityResult> CreateAsync(User user, string password)
        {
            return base.CreateAsync(user, password);
        }

        public override Task<byte[]> CreateSecurityTokenAsync(User user)
        {
            return base.CreateSecurityTokenAsync(user);
        }

        public override Task<IdentityResult> DeleteAsync(User user)
        {
            return base.DeleteAsync(user);
        }

        public override Task<User> FindByEmailAsync(string email)
        {
            return base.FindByEmailAsync(email);
        }

        public override Task<User> FindByIdAsync(string userId)
        {
            return base.FindByIdAsync(userId);
        }

        public override Task<User> FindByLoginAsync(string loginProvider, string providerKey)
        {
            return base.FindByLoginAsync(loginProvider, providerKey);
        }

        public override Task<User> FindByNameAsync(string userName)
        {
            return base.FindByNameAsync(userName);
        }

        public override Task<string> GenerateChangeEmailTokenAsync(User user, string newEmail)
        {
            return base.GenerateChangeEmailTokenAsync(user, newEmail);
        }

        public override Task<string> GenerateChangePhoneNumberTokenAsync(User user, string phoneNumber)
        {
            return base.GenerateChangePhoneNumberTokenAsync(user, phoneNumber);
        }

        public override Task<string> GenerateConcurrencyStampAsync(User user)
        {
            return base.GenerateConcurrencyStampAsync(user);
        }

        public override Task<string> GenerateEmailConfirmationTokenAsync(User user)
        {
            return base.GenerateEmailConfirmationTokenAsync(user);
        }

        public override string GenerateNewAuthenticatorKey()
        {
            return base.GenerateNewAuthenticatorKey();
        }

        public override Task<IEnumerable<string>> GenerateNewTwoFactorRecoveryCodesAsync(User user, int number)
        {
            return base.GenerateNewTwoFactorRecoveryCodesAsync(user, number);
        }

        public override Task<string> GeneratePasswordResetTokenAsync(User user)
        {
            return base.GeneratePasswordResetTokenAsync(user);
        }

        public override Task<string> GenerateTwoFactorTokenAsync(User user, string tokenProvider)
        {
            return base.GenerateTwoFactorTokenAsync(user, tokenProvider);
        }

        public override Task<string> GenerateUserTokenAsync(User user, string tokenProvider, string purpose)
        {
            return base.GenerateUserTokenAsync(user, tokenProvider, purpose);
        }

        public override Task<int> GetAccessFailedCountAsync(User user)
        {
            return base.GetAccessFailedCountAsync(user);
        }

        public override Task<string> GetAuthenticationTokenAsync(User user, string loginProvider, string tokenName)
        {
            return base.GetAuthenticationTokenAsync(user, loginProvider, tokenName);
        }

        public override Task<string> GetAuthenticatorKeyAsync(User user)
        {
            return base.GetAuthenticatorKeyAsync(user);
        }

        public override Task<IList<Claim>> GetClaimsAsync(User user)
        {
            return base.GetClaimsAsync(user);
        }

        public override Task<string> GetEmailAsync(User user)
        {
            return base.GetEmailAsync(user);
        }

        public override Task<bool> GetLockoutEnabledAsync(User user)
        {
            return base.GetLockoutEnabledAsync(user);
        }

        public override Task<DateTimeOffset?> GetLockoutEndDateAsync(User user)
        {
            return base.GetLockoutEndDateAsync(user);
        }

        public override Task<IList<UserLoginInfo>> GetLoginsAsync(User user)
        {
            return base.GetLoginsAsync(user);
        }

        public override Task<string> GetPhoneNumberAsync(User user)
        {
            return base.GetPhoneNumberAsync(user);
        }

        public override Task<IList<string>> GetRolesAsync(User user)
        {
            return base.GetRolesAsync(user);
        }

        public override Task<string> GetSecurityStampAsync(User user)
        {
            return base.GetSecurityStampAsync(user);
        }

        public override Task<bool> GetTwoFactorEnabledAsync(User user)
        {
            return base.GetTwoFactorEnabledAsync(user);
        }

        public override Task<User> GetUserAsync(ClaimsPrincipal principal)
        {
            return base.GetUserAsync(principal);
        }

        public override string GetUserId(ClaimsPrincipal principal)
        {
            return base.GetUserId(principal);
        }

        public override Task<string> GetUserIdAsync(User user)
        {
            return base.GetUserIdAsync(user);
        }

        public override string GetUserName(ClaimsPrincipal principal)
        {
            return base.GetUserName(principal);
        }

        public override Task<string> GetUserNameAsync(User user)
        {
            return base.GetUserNameAsync(user);
        }

        public override Task<IList<User>> GetUsersForClaimAsync(Claim claim)
        {
            return base.GetUsersForClaimAsync(claim);
        }

        public override Task<IList<User>> GetUsersInRoleAsync(string roleName)
        {
            return base.GetUsersInRoleAsync(roleName);
        }

        public override Task<IList<string>> GetValidTwoFactorProvidersAsync(User user)
        {
            return base.GetValidTwoFactorProvidersAsync(user);
        }

        public override Task<bool> HasPasswordAsync(User user)
        {
            return base.HasPasswordAsync(user);
        }

        public override Task<bool> IsEmailConfirmedAsync(User user)
        {
            return base.IsEmailConfirmedAsync(user);
        }

        public override Task<bool> IsInRoleAsync(User user, string role)
        {
            return base.IsInRoleAsync(user, role);
        }

        public override Task<bool> IsLockedOutAsync(User user)
        {
            return base.IsLockedOutAsync(user);
        }

        public override Task<bool> IsPhoneNumberConfirmedAsync(User user)
        {
            return base.IsPhoneNumberConfirmedAsync(user);
        }

        public override string NormalizeKey(string key)
        {
            return base.NormalizeKey(key);
        }

        public override Task<IdentityResult> RedeemTwoFactorRecoveryCodeAsync(User user, string code)
        {
            return base.RedeemTwoFactorRecoveryCodeAsync(user, code);
        }

        public override void RegisterTokenProvider(string providerName, IUserTwoFactorTokenProvider<User> provider)
        {
            base.RegisterTokenProvider(providerName, provider);
        }

        public override Task<IdentityResult> RemoveAuthenticationTokenAsync(User user, string loginProvider, string tokenName)
        {
            return base.RemoveAuthenticationTokenAsync(user, loginProvider, tokenName);
        }

        public override Task<IdentityResult> RemoveClaimAsync(User user, Claim claim)
        {
            return base.RemoveClaimAsync(user, claim);
        }

        public override Task<IdentityResult> RemoveClaimsAsync(User user, IEnumerable<Claim> claims)
        {
            return base.RemoveClaimsAsync(user, claims);
        }

        public override Task<IdentityResult> RemoveFromRoleAsync(User user, string role)
        {
            return base.RemoveFromRoleAsync(user, role);
        }

        public override Task<IdentityResult> RemoveFromRolesAsync(User user, IEnumerable<string> roles)
        {
            return base.RemoveFromRolesAsync(user, roles);
        }

        public override Task<IdentityResult> RemoveLoginAsync(User user, string loginProvider, string providerKey)
        {
            return base.RemoveLoginAsync(user, loginProvider, providerKey);
        }

        public override Task<IdentityResult> RemovePasswordAsync(User user)
        {
            return base.RemovePasswordAsync(user);
        }

        public override Task<IdentityResult> ReplaceClaimAsync(User user, Claim claim, Claim newClaim)
        {
            return base.ReplaceClaimAsync(user, claim, newClaim);
        }

        public override Task<IdentityResult> ResetAccessFailedCountAsync(User user)
        {
            return base.ResetAccessFailedCountAsync(user);
        }

        public override Task<IdentityResult> ResetAuthenticatorKeyAsync(User user)
        {
            return base.ResetAuthenticatorKeyAsync(user);
        }

        public override Task<IdentityResult> ResetPasswordAsync(User user, string token, string newPassword)
        {
            return base.ResetPasswordAsync(user, token, newPassword);
        }

        public override Task<IdentityResult> SetAuthenticationTokenAsync(User user, string loginProvider, string tokenName, string tokenValue)
        {
            return base.SetAuthenticationTokenAsync(user, loginProvider, tokenName, tokenValue);
        }

        public override Task<IdentityResult> SetEmailAsync(User user, string email)
        {
            return base.SetEmailAsync(user, email);
        }

        public override Task<IdentityResult> SetLockoutEnabledAsync(User user, bool enabled)
        {
            return base.SetLockoutEnabledAsync(user, enabled);
        }

        public override Task<IdentityResult> SetLockoutEndDateAsync(User user, DateTimeOffset? lockoutEnd)
        {
            return base.SetLockoutEndDateAsync(user, lockoutEnd);
        }

        public override Task<IdentityResult> SetPhoneNumberAsync(User user, string phoneNumber)
        {
            return base.SetPhoneNumberAsync(user, phoneNumber);
        }

        public override Task<IdentityResult> SetTwoFactorEnabledAsync(User user, bool enabled)
        {
            return base.SetTwoFactorEnabledAsync(user, enabled);
        }

        public override Task<IdentityResult> SetUserNameAsync(User user, string userName)
        {
            return base.SetUserNameAsync(user, userName);
        }

        public override Task<IdentityResult> UpdateAsync(User user)
        {
            return base.UpdateAsync(user);
        }

        public override Task UpdateNormalizedEmailAsync(User user)
        {
            return base.UpdateNormalizedEmailAsync(user);
        }

        public override Task UpdateNormalizedUserNameAsync(User user)
        {
            return base.UpdateNormalizedUserNameAsync(user);
        }

        public override Task<IdentityResult> UpdateSecurityStampAsync(User user)
        {
            return base.UpdateSecurityStampAsync(user);
        }

        public override Task<bool> VerifyChangePhoneNumberTokenAsync(User user, string token, string phoneNumber)
        {
            return base.VerifyChangePhoneNumberTokenAsync(user, token, phoneNumber);
        }

        public override Task<bool> VerifyTwoFactorTokenAsync(User user, string tokenProvider, string token)
        {
            return base.VerifyTwoFactorTokenAsync(user, tokenProvider, token);
        }

        public override Task<bool> VerifyUserTokenAsync(User user, string tokenProvider, string purpose, string token)
        {
            return base.VerifyUserTokenAsync(user, tokenProvider, purpose, token);
        }

        protected override string CreateTwoFactorRecoveryCode()
        {
            return base.CreateTwoFactorRecoveryCode();
        }

        protected override void Dispose(bool disposing)
        {
            base.Dispose(disposing);
        }

        protected override Task<IdentityResult> UpdatePasswordHash(User user, string newPassword, bool validatePassword)
        {
            return base.UpdatePasswordHash(user, newPassword, validatePassword);
        }

        protected override Task<IdentityResult> UpdateUserAsync(User user)
        {
            return base.UpdateUserAsync(user);
        }

        protected override Task<PasswordVerificationResult> VerifyPasswordAsync(IUserPasswordStore<User> store, User user, string password)
        {
            return base.VerifyPasswordAsync(store, user, password);
        }
    }
}
