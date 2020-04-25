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
    public class StockLine : BaseObject
    { // Inherit from a different class to provide a custom primary key, concurrency and deletion behavior, etc. (https://documentation.devexpress.com/eXpressAppFramework/CustomDocument113146.aspx).
        public StockLine(Session session)
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


        double vatRate;
        double grossTotal;
        double netTotal;
        bool sign;
        double discountRate;
        double currencyConvertionFactor;
        Currency currency;
        double unitConvertionFactor;
        Unit unit;
        double price;
        double amount;
        Stock stock;

        [Association("Stock-StockLines")]
        public Stock Stock
        {
            get => stock;
            set => SetPropertyValue(nameof(Stock), ref stock, value);
        }


        public double Amount
        {
            get => amount;
            set => SetPropertyValue(nameof(Amount), ref amount, value);
        }


        public Unit Unit
        {
            get => unit;
            set => SetPropertyValue(nameof(Unit), ref unit, value);
        }

        public double Price
        {
            get => price;
            set => SetPropertyValue(nameof(Price), ref price, value);
        }

        public double UnitConvertionFactor
        {
            get => unitConvertionFactor;
            set => SetPropertyValue(nameof(UnitConvertionFactor), ref unitConvertionFactor, value);
        }

        public Currency Currency
        {
            get => currency;
            set => SetPropertyValue(nameof(Currency), ref currency, value);
        }

        public double CurrencyConvertionFactor
        {
            get => currencyConvertionFactor;
            set => SetPropertyValue(nameof(CurrencyConvertionFactor), ref currencyConvertionFactor, value);
        }

        public double DiscountRate
        {
            get => discountRate;
            set => SetPropertyValue(nameof(DiscountRate), ref discountRate, value);
        }

        [Browsable(false)]
        public bool Sign
        {
            get => sign;
            set => SetPropertyValue(nameof(Sign), ref sign, value);
        }

        public double VatRate
        {
            get => vatRate;
            set => SetPropertyValue(nameof(VatRate), ref vatRate, value);
        }

        public double GrossTotal
        {
            get => grossTotal;
            set => SetPropertyValue(nameof(GrossTotal), ref grossTotal, value);
        }

        public double NetTotal
        {
            get => netTotal;
            set => SetPropertyValue(nameof(NetTotal), ref netTotal, value);
        }

        
    }
}