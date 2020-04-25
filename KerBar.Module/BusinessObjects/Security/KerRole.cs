using DevExpress.Persistent.Base;
using DevExpress.Persistent.BaseImpl.PermissionPolicy;
using DevExpress.Xpo;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KerBar.Module.BusinessObjects.Security
{

    [DefaultClassOptions]
    [ImageName("BO_Role")]
    public class KerRole : PermissionPolicyRoleBase, IPermissionPolicyRoleWithUsers
    {
        public KerRole(Session session)
            : base(session)
        {
        }
        [Association("Users-Roles")]
        public XPCollection<KerUser> Users
        {
            get
            {
                return GetCollection<KerUser>("Users");
            }
        }
        IEnumerable<IPermissionPolicyUser> IPermissionPolicyRoleWithUsers.Users
        {
            get { return Users.OfType<IPermissionPolicyUser>(); }
        }
    }
}
