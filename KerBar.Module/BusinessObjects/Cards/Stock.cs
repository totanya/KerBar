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
using DevExpress.XtraCharts;

namespace KerBar.Module.BusinessObjects.Cards
{
    [DefaultClassOptions]
    //[ImageName("BO_Contact")]
    //[DefaultProperty("DisplayMemberNameForLookupEditorsOfThisType")]
    //[DefaultListViewOptions(MasterDetailMode.ListViewOnly, false, NewItemRowPosition.None)]
    //[Persistent("DatabaseTableName")]
    // Specify more UI options using a declarative approach (https://documentation.devexpress.com/#eXpressAppFramework/CustomDocument112701).
    public class Stock : BaseObject
    { // Inherit from a different class to provide a custom primary key, concurrency and deletion behavior, etc. (https://documentation.devexpress.com/eXpressAppFramework/CustomDocument113146.aspx).
        public Stock(Session session)
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
        //}\


        double vatRate;
        double thirdUnitConvFactor = 1;
        double secondUnitConvFactor = 1;
        Unit thirdUnit;
        Unit secondUnit;
        Unit mainUnit;
        StockGroup stockGroup;
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

        [Association("Stock-StockPrices")]
        public XPCollection<StockPrice> StockPrices
        {
            get
            {
                return GetCollection<StockPrice>(nameof(StockPrices));
            }
        }


        [Association("StockGroup-Stocks")]
        public StockGroup StockGroup
        {
            get => stockGroup;
            set => SetPropertyValue(nameof(StockGroup), ref stockGroup, value);
        }



        public Unit MainUnit
        {
            get => mainUnit;
            set => SetPropertyValue(nameof(MainUnit), ref mainUnit, value);
        }


        public Unit SecondUnit
        {
            get => secondUnit;
            set => SetPropertyValue(nameof(SecondUnit), ref secondUnit, value);
        }

        [RuleValueComparison(ValueComparisonType.GreaterThan, 0)]
        public double SecondUnitConvFactor
        {
            get => secondUnitConvFactor;
            set => SetPropertyValue(nameof(SecondUnitConvFactor), ref secondUnitConvFactor, value);
        }


        public Unit ThirdUnit
        {
            get => thirdUnit;
            set => SetPropertyValue(nameof(ThirdUnit), ref thirdUnit, value);
        }


        public double ThirdUnitConvFactor
        {
            get => thirdUnitConvFactor;
            set => SetPropertyValue(nameof(ThirdUnitConvFactor), ref thirdUnitConvFactor, value);
        }


        [RuleValueComparison(ValueComparisonType.GreaterThanOrEqual, 0)]
        public double VatRate
        {
            get => vatRate;
            set => SetPropertyValue(nameof(VatRate), ref vatRate, value);
        }

    }
}