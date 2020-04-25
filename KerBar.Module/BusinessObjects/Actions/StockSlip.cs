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
using KerBar.Module.BusinessObjects.Cards;

namespace KerBar.Module.BusinessObjects.Actions
{
    [DefaultClassOptions]
    //[ImageName("BO_Contact")]
    //[DefaultProperty("DisplayMemberNameForLookupEditorsOfThisType")]
    //[DefaultListViewOptions(MasterDetailMode.ListViewOnly, false, NewItemRowPosition.None)]
    //[Persistent("DatabaseTableName")]
    // Specify more UI options using a declarative approach (https://documentation.devexpress.com/#eXpressAppFramework/CustomDocument112701).
    public class StockSlip : BaseObject
    { // Inherit from a different class to provide a custom primary key, concurrency and deletion behavior, etc. (https://documentation.devexpress.com/eXpressAppFramework/CustomDocument113146.aspx).
        public StockSlip(Session session)
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


        double discountRate;
        double grossTotal;
        double totalVat;
        double netTotal;
        DateTime dateTime;
        Warehouse warehouse;
        Partner partner;

        public Partner Partner
        {
            get => partner;
            set
            {
                SetPropertyValue(nameof(Partner), ref partner, value);
            }
        }

        public Warehouse Warehouse
        {
            get => warehouse;
            set
            {
                SetPropertyValue(nameof(Warehouse), ref warehouse, value);
                if (!IsSaving && !IsLoading)
                {

                }
            }
        }

        public DateTime DateTime
        {
            get => dateTime;
            set => SetPropertyValue(nameof(DateTime), ref dateTime, value);
        }

        [Association("Slip-StockLines")]
        public XPCollection<StockLine> StockLines
        {
            get
            {
                return GetCollection<StockLine>(nameof(StockLines));
            }
        }


        public double NetTotal
        {
            get => netTotal;
            set => SetPropertyValue(nameof(NetTotal), ref netTotal, value);
        }

        public double TotalVat
        {
            get => totalVat;
            set => SetPropertyValue(nameof(TotalVat), ref totalVat, value);
        }

        public double GrossTotal
        {
            get => grossTotal;
            set => SetPropertyValue(nameof(GrossTotal), ref grossTotal, value);
        }

        
        public double DiscountRate
        {
            get => discountRate;
            set => SetPropertyValue(nameof(DiscountRate), ref discountRate, value);
        }

    }
}