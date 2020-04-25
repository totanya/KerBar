using DevExpress.ExpressApp.Security;
using DevExpress.Persistent.Base;
using DevExpress.Persistent.Base.Security;
using DevExpress.Persistent.BaseImpl;
using DevExpress.Persistent.Validation;
using DevExpress.Xpo;
using KerBar.Module.BusinessObjects.Cards;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KerBar.Module.BusinessObjects.Security
{
    [DefaultClassOptions]
    public class KerUser : Person, ISecurityUser,
    IAuthenticationStandardUser, IAuthenticationActiveDirectoryUser,
    IPermissionPolicyUser
    {
        public KerUser(Session session) : base(session)
        {

        }


        private string code;
        private bool isActive = true;
        private bool changePasswordOnFirstLogon;
        private string storedPassword;
        private string resetPasswordCode;

        IEnumerable<IPermissionPolicyRole> IPermissionPolicyUser.Roles
        {
            get { return Roles.OfType<IPermissionPolicyRole>(); }
        }

        [Association("User-Roles")]
        [RuleRequiredField("RoleIsRequired", DefaultContexts.Save,
        TargetCriteria = "IsActive",
        CustomMessageTemplate = "An active employee must have at least one role assigned")]
        public XPCollection<KerRole> Roles
        {
            get
            {
                return GetCollection<KerRole>("Roles");
            }
        }

        private string userName = String.Empty;
        [RuleRequiredField("EmployeeUserNameRequired", DefaultContexts.Save)]
        [RuleUniqueValue("EmployeeUserNameIsUnique", DefaultContexts.Save,
            "The login with the entered user name was already registered within the system.")]
        public string UserName
        {
            get { return userName; }
            set { SetPropertyValue("UserName", ref userName, value); }
        }

        public bool IsActive
        {
            get { return isActive; }
            set { SetPropertyValue("IsActive", ref isActive, value); }
        }

        public bool ChangePasswordOnFirstLogon
        {
            get { return changePasswordOnFirstLogon; }
            set
            {
                SetPropertyValue("ChangePasswordOnFirstLogon", ref changePasswordOnFirstLogon, value);
            }
        }


        [Browsable(false), Size(SizeAttribute.Unlimited), Persistent, SecurityBrowsable]
        protected string StoredPassword
        {
            get { return storedPassword; }
            set { SetPropertyValue(nameof(StoredPassword), ref storedPassword, value); }
        }

        public bool ComparePassword(string password)
        {
            return PasswordCryptographer.VerifyHashedPasswordDelegate(this.storedPassword, password);
        }

        public void SetPassword(string password)
        {
            this.storedPassword = PasswordCryptographer.HashPasswordDelegate(password);
        }

        public string Code
        {
            get { return code; }
            set { SetPropertyValue("Code", ref code, value); }
        }

        [Browsable(false)]
        public string ResetPasswordCode
        {
            get { return resetPasswordCode; }
            set { SetPropertyValue("ResetPasswordCode", ref resetPasswordCode, value); }
        }


        [Association("KerUser-Warehouses")]
        public XPCollection<Warehouse> Warehouses
        {
            get
            {
                return GetCollection<Warehouse>(nameof(Warehouses));
            }
        }

    }
}
