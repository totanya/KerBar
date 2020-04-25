using System;
using System.Linq;
using System.Text;
using DevExpress.Xpo;
using DevExpress.ExpressApp;
using System.ComponentModel;
using DevExpress.ExpressApp.DC;
using DevExpress.Data.Filtering;
using DevExpress.Persistent.Base;
using System.Collections.Generic;
using DevExpress.ExpressApp.Model;
using DevExpress.Persistent.BaseImpl;
using DevExpress.Persistent.Validation;

namespace KerBar.Module.BusinessObjects.Cards
{
    [DefaultClassOptions]
    //[ImageName("BO_Contact")]
    //[DefaultProperty("DisplayMemberNameForLookupEditorsOfThisType")]
    //[DefaultListViewOptions(MasterDetailMode.ListViewOnly, false, NewItemRowPosition.None)]
    //[Persistent("DatabaseTableName")]
    // Specify more UI options using a declarative approach (https://documentation.devexpress.com/#eXpressAppFramework/CustomDocument112701).
    public class Partner : BaseObject
    { // Inherit from a different class to provide a custom primary key, concurrency and deletion behavior, etc. (https://documentation.devexpress.com/eXpressAppFramework/CustomDocument113146.aspx).
        public Partner(Session session)
            : base(session)
        {
        }
        public override void AfterConstruction()
        {
            base.AfterConstruction();
            // Place your initialization code here (https://documentation.devexpress.com/eXpressAppFramework/CustomDocument112834.aspx).
        }
        //private string _PersistentProperty;
        //[XafDisplayName("My display name"), ToolTip("My hint message")]
        //[ModelDefault("EditMask", "(000)-00"), Index(0), VisibleInListView(false)]
        //[Persistent("DatabaseColumnName"), RuleRequiredField(DefaultContexts.Save)]
        //public string PersistentProperty {
        //    get { return _PersistentProperty; }
        //    set { SetPropertyValue("PersistentProperty", ref _PersistentProperty, value); }
        //}

        //[Action(Caption = "My UI Action", ConfirmationMessage = "Are you sure?", ImageName = "Attention", AutoCommit = true)]
        //public void ActionMethod() {
        //    // Trigger a custom business logic for the current record in the UI (https://documentation.devexpress.com/eXpressAppFramework/CustomDocument112619.aspx).
        //    this.PersistentProperty = "Paid";
        //}

        string correspondentAccount;
        string bankAccount;
        string fax;
        string phone2;
        string phone1;
        string email;
        Address address2;
        Address address1;
        string name2;
        string name;
        string code;

        [Size(50)]
        public string Code
        {
            get => code;
            set => SetPropertyValue(nameof(Code), ref code, value);
        }


        [Size(SizeAttribute.DefaultStringMappingFieldSize)]
        public string Name
        {
            get => name;
            set => SetPropertyValue(nameof(Name), ref name, value);
        }


        [Size(SizeAttribute.DefaultStringMappingFieldSize)]
        public string Name2
        {
            get => name2;
            set => SetPropertyValue(nameof(Name2), ref name2, value);
        }


        public Address Address1
        {
            get => address1;
            set => SetPropertyValue(nameof(Address1), ref address1, value);
        }


        public Address Address2
        {
            get => address2;
            set => SetPropertyValue(nameof(Address2), ref address2, value);
        }


        [Size(255)]
        public string Email
        {
            get => email;
            set => SetPropertyValue(nameof(Email), ref email, value);
        }


        [Size(20)]
        public string Phone1
        {
            get => phone1;
            set => SetPropertyValue(nameof(Phone1), ref phone1, value);
        }


        [Size(20)]
        public string Phone2
        {
            get => phone2;
            set => SetPropertyValue(nameof(Phone2), ref phone2, value);
        }


        [Size(20)]
        public string Fax
        {
            get => fax;
            set => SetPropertyValue(nameof(Fax), ref fax, value);
        }


        [Size(SizeAttribute.DefaultStringMappingFieldSize)]
        public string BankAccount
        {
            get => bankAccount;
            set => SetPropertyValue(nameof(BankAccount), ref bankAccount, value);
        }

        
        [Size(SizeAttribute.DefaultStringMappingFieldSize)]
        public string CorrespondentAccount
        {
            get => correspondentAccount;
            set => SetPropertyValue(nameof(CorrespondentAccount), ref correspondentAccount, value);
        }

    }
}