﻿#pragma warning disable 1591
#pragma warning disable 0414        
//------------------------------------------------------------------------------
// <autogenerated>
//     This code was generated by a CodeSmith Template.
//
//     DO NOT MODIFY contents of this file. Changes to this
//     file will be lost if the code is regenerated.
// </autogenerated>
//------------------------------------------------------------------------------

using System;
using System.Collections;
using System.Collections.Generic;
using HuatongApply.Data;

namespace HuatongApply.Data
{
    [System.Runtime.Serialization.DataContract(IsReference = true)]
    [System.ComponentModel.DataAnnotations.ScaffoldTable(true)]
    [System.Diagnostics.DebuggerDisplay("FlowId: {FlowId}")]
    public partial class Fundflow : EntityBase
    {
        #region Static Constructor
        
        /// <summary>
        /// Initializes the <see cref="Account"/> class.
        /// </summary>
        [System.CodeDom.Compiler.GeneratedCode("CodeSmith", "5.0.0.0")]
        static Fundflow()
        {
            AddSharedRules();
        }
        
        #endregion

        #region Default Constructor
        /// <summary>
        /// Initializes a new instance of the <see cref="Account"/> class.
        /// </summary>
        [System.Diagnostics.DebuggerNonUserCode]
        [System.CodeDom.Compiler.GeneratedCode("CodeSmith", "6.0.0.0")]
        public Fundflow()
        {
            Initialize();
        }

        [System.CodeDom.Compiler.GeneratedCode("CodeSmith", "6.0.0.0")]
        protected override void Initialize()
        {
            OnCreated();
        }
        
        #endregion
        
        #region Column Mapped Properties
        
        [System.CodeDom.Compiler.GeneratedCode("CodeSmith", "6.0.0.0")]
        private System.Int32 _flowId;
        
        [System.Runtime.Serialization.DataMember(Order = 1)]
        [System.CodeDom.Compiler.GeneratedCode("CodeSmith", "6.0.0.0")]
        public virtual System.Int32 FlowId
        {
            get { return _flowId; }
            set
            {
                OnFlowIdChanging(value, _flowId);
                SendPropertyChanging("FlowId");
                _flowId = value;
                SendPropertyChanged("FlowId");
                OnFlowIdChanged(value);
            }
        }
        
        [System.CodeDom.Compiler.GeneratedCode("CodeSmith", "6.0.0.0")]
        private System.DateTime? _date;
        
        [System.Runtime.Serialization.DataMember(Order = 2)]
        [System.CodeDom.Compiler.GeneratedCode("CodeSmith", "6.0.0.0")]
        public virtual System.DateTime? Date
        {
            get { return _date; }
            set
            {
                OnDateChanging(value, _date);
                SendPropertyChanging("Date");
                _date = value;
                SendPropertyChanged("Date");
                OnDateChanged(value);
            }
        }
        
        [System.CodeDom.Compiler.GeneratedCode("CodeSmith", "6.0.0.0")]
        private System.Int32? _paymentType;
        
        [System.Runtime.Serialization.DataMember(Order = 3)]
        [System.CodeDom.Compiler.GeneratedCode("CodeSmith", "6.0.0.0")]
        public virtual System.Int32? PaymentType
        {
            get { return _paymentType; }
            set
            {
                OnPaymentTypeChanging(value, _paymentType);
                SendPropertyChanging("PaymentType");
                _paymentType = value;
                SendPropertyChanged("PaymentType");
                OnPaymentTypeChanged(value);
            }
        }
        
        [System.CodeDom.Compiler.GeneratedCode("CodeSmith", "6.0.0.0")]
        private System.String _bank;
        
        [System.Runtime.Serialization.DataMember(Order = 4)]
        [System.CodeDom.Compiler.GeneratedCode("CodeSmith", "6.0.0.0")]
        public virtual System.String Bank
        {
            get { return _bank; }
            set
            {
                OnBankChanging(value, _bank);
                SendPropertyChanging("Bank");
                _bank = value;
                SendPropertyChanged("Bank");
                OnBankChanged(value);
            }
        }
        
        [System.CodeDom.Compiler.GeneratedCode("CodeSmith", "6.0.0.0")]
        private System.String _account;
        
        [System.Runtime.Serialization.DataMember(Order = 5)]
        [System.CodeDom.Compiler.GeneratedCode("CodeSmith", "6.0.0.0")]
        public virtual System.String Account
        {
            get { return _account; }
            set
            {
                OnAccountChanging(value, _account);
                SendPropertyChanging("Account");
                _account = value;
                SendPropertyChanged("Account");
                OnAccountChanged(value);
            }
        }
        
        [System.CodeDom.Compiler.GeneratedCode("CodeSmith", "6.0.0.0")]
        private System.Double? _price;
        
        [System.Runtime.Serialization.DataMember(Order = 6)]
        [System.CodeDom.Compiler.GeneratedCode("CodeSmith", "6.0.0.0")]
        public virtual System.Double? Price
        {
            get { return _price; }
            set
            {
                OnPriceChanging(value, _price);
                SendPropertyChanging("Price");
                _price = value;
                SendPropertyChanged("Price");
                OnPriceChanged(value);
            }
        }
        
        [System.CodeDom.Compiler.GeneratedCode("CodeSmith", "6.0.0.0")]
        private System.String _currency;
        
        [System.Runtime.Serialization.DataMember(Order = 7)]
        [System.CodeDom.Compiler.GeneratedCode("CodeSmith", "6.0.0.0")]
        public virtual System.String Currency
        {
            get { return _currency; }
            set
            {
                OnCurrencyChanging(value, _currency);
                SendPropertyChanging("Currency");
                _currency = value;
                SendPropertyChanged("Currency");
                OnCurrencyChanged(value);
            }
        }
        
        [System.CodeDom.Compiler.GeneratedCode("CodeSmith", "6.0.0.0")]
        private System.String _description;
        
        [System.Runtime.Serialization.DataMember(Order = 8)]
        [System.CodeDom.Compiler.GeneratedCode("CodeSmith", "6.0.0.0")]
        public virtual System.String Description
        {
            get { return _description; }
            set
            {
                OnDescriptionChanging(value, _description);
                SendPropertyChanging("Description");
                _description = value;
                SendPropertyChanged("Description");
                OnDescriptionChanged(value);
            }
        }
        
        [System.CodeDom.Compiler.GeneratedCode("CodeSmith", "6.0.0.0")]
        private System.String _maker;
        
        [System.Runtime.Serialization.DataMember(Order = 9)]
        [System.CodeDom.Compiler.GeneratedCode("CodeSmith", "6.0.0.0")]
        public virtual System.String Maker
        {
            get { return _maker; }
            set
            {
                OnMakerChanging(value, _maker);
                SendPropertyChanging("Maker");
                _maker = value;
                SendPropertyChanged("Maker");
                OnMakerChanged(value);
            }
        }
        
        [System.CodeDom.Compiler.GeneratedCode("CodeSmith", "6.0.0.0")]
        private System.Int32? _isPayment;
        
        [System.Runtime.Serialization.DataMember(Order = 10)]
        [System.CodeDom.Compiler.GeneratedCode("CodeSmith", "6.0.0.0")]
        public virtual System.Int32? IsPayment
        {
            get { return _isPayment; }
            set
            {
                OnIsPaymentChanging(value, _isPayment);
                SendPropertyChanging("IsPayment");
                _isPayment = value;
                SendPropertyChanged("IsPayment");
                OnIsPaymentChanged(value);
            }
        }
        
        [System.CodeDom.Compiler.GeneratedCode("CodeSmith", "6.0.0.0")]
        private System.Int32? _isAudit;
        
        [System.Runtime.Serialization.DataMember(Order = 11)]
        [System.CodeDom.Compiler.GeneratedCode("CodeSmith", "6.0.0.0")]
        public virtual System.Int32? IsAudit
        {
            get { return _isAudit; }
            set
            {
                OnIsAuditChanging(value, _isAudit);
                SendPropertyChanging("IsAudit");
                _isAudit = value;
                SendPropertyChanged("IsAudit");
                OnIsAuditChanged(value);
            }
        }
        
        [System.CodeDom.Compiler.GeneratedCode("CodeSmith", "6.0.0.0")]
        private System.String _auditBy;
        
        [System.Runtime.Serialization.DataMember(Order = 12)]
        [System.CodeDom.Compiler.GeneratedCode("CodeSmith", "6.0.0.0")]
        public virtual System.String AuditBy
        {
            get { return _auditBy; }
            set
            {
                OnAuditByChanging(value, _auditBy);
                SendPropertyChanging("AuditBy");
                _auditBy = value;
                SendPropertyChanged("AuditBy");
                OnAuditByChanged(value);
            }
        }
        
        [System.CodeDom.Compiler.GeneratedCode("CodeSmith", "6.0.0.0")]
        private System.DateTime? _createdOn;
        
        [System.Runtime.Serialization.DataMember(Order = 13)]
        [System.CodeDom.Compiler.GeneratedCode("CodeSmith", "6.0.0.0")]
        public virtual System.DateTime? CreatedOn
        {
            get { return _createdOn; }
            set
            {
                OnCreatedOnChanging(value, _createdOn);
                SendPropertyChanging("CreatedOn");
                _createdOn = value;
                SendPropertyChanged("CreatedOn");
                OnCreatedOnChanged(value);
            }
        }
        
        [System.CodeDom.Compiler.GeneratedCode("CodeSmith", "6.0.0.0")]
        private System.String _createdBy;
        
        [System.Runtime.Serialization.DataMember(Order = 14)]
        [System.CodeDom.Compiler.GeneratedCode("CodeSmith", "6.0.0.0")]
        public virtual System.String CreatedBy
        {
            get { return _createdBy; }
            set
            {
                OnCreatedByChanging(value, _createdBy);
                SendPropertyChanging("CreatedBy");
                _createdBy = value;
                SendPropertyChanged("CreatedBy");
                OnCreatedByChanged(value);
            }
        }
        
        [System.CodeDom.Compiler.GeneratedCode("CodeSmith", "6.0.0.0")]
        private System.DateTime? _modifiedOn;
        
        [System.Runtime.Serialization.DataMember(Order = 15)]
        [System.CodeDom.Compiler.GeneratedCode("CodeSmith", "6.0.0.0")]
        public virtual System.DateTime? ModifiedOn
        {
            get { return _modifiedOn; }
            set
            {
                OnModifiedOnChanging(value, _modifiedOn);
                SendPropertyChanging("ModifiedOn");
                _modifiedOn = value;
                SendPropertyChanged("ModifiedOn");
                OnModifiedOnChanged(value);
            }
        }
        
        [System.CodeDom.Compiler.GeneratedCode("CodeSmith", "6.0.0.0")]
        private System.String _modifiedBy;
        
        [System.Runtime.Serialization.DataMember(Order = 16)]
        [System.CodeDom.Compiler.GeneratedCode("CodeSmith", "6.0.0.0")]
        public virtual System.String ModifiedBy
        {
            get { return _modifiedBy; }
            set
            {
                OnModifiedByChanging(value, _modifiedBy);
                SendPropertyChanging("ModifiedBy");
                _modifiedBy = value;
                SendPropertyChanged("ModifiedBy");
                OnModifiedByChanged(value);
            }
        }
        
        #endregion
        
        #region Associations Mappings
        
        #endregion
        
        #region Extensibility Method
        
        static partial void AddSharedRules();
        
        partial void OnCreated();
        
        partial void OnFlowIdChanging(System.Int32 newValue, System.Int32 oldValue);
        
        partial void OnFlowIdChanged(System.Int32 value);
        
        partial void OnDateChanging(System.DateTime? newValue, System.DateTime? oldValue);
        
        partial void OnDateChanged(System.DateTime? value);
        
        partial void OnPaymentTypeChanging(System.Int32? newValue, System.Int32? oldValue);
        
        partial void OnPaymentTypeChanged(System.Int32? value);
        
        partial void OnBankChanging(System.String newValue, System.String oldValue);
        
        partial void OnBankChanged(System.String value);
        
        partial void OnAccountChanging(System.String newValue, System.String oldValue);
        
        partial void OnAccountChanged(System.String value);
        
        partial void OnPriceChanging(System.Double? newValue, System.Double? oldValue);
        
        partial void OnPriceChanged(System.Double? value);
        
        partial void OnCurrencyChanging(System.String newValue, System.String oldValue);
        
        partial void OnCurrencyChanged(System.String value);
        
        partial void OnDescriptionChanging(System.String newValue, System.String oldValue);
        
        partial void OnDescriptionChanged(System.String value);
        
        partial void OnMakerChanging(System.String newValue, System.String oldValue);
        
        partial void OnMakerChanged(System.String value);
        
        partial void OnIsPaymentChanging(System.Int32? newValue, System.Int32? oldValue);
        
        partial void OnIsPaymentChanged(System.Int32? value);
        
        partial void OnIsAuditChanging(System.Int32? newValue, System.Int32? oldValue);
        
        partial void OnIsAuditChanged(System.Int32? value);
        
        partial void OnAuditByChanging(System.String newValue, System.String oldValue);
        
        partial void OnAuditByChanged(System.String value);
        
        partial void OnCreatedOnChanging(System.DateTime? newValue, System.DateTime? oldValue);
        
        partial void OnCreatedOnChanged(System.DateTime? value);
        
        partial void OnCreatedByChanging(System.String newValue, System.String oldValue);
        
        partial void OnCreatedByChanged(System.String value);
        
        partial void OnModifiedOnChanging(System.DateTime? newValue, System.DateTime? oldValue);
        
        partial void OnModifiedOnChanged(System.DateTime? value);
        
        partial void OnModifiedByChanging(System.String newValue, System.String oldValue);
        
        partial void OnModifiedByChanged(System.String value);
        
        
        #endregion
        
        #region Clone
        
        [System.CodeDom.Compiler.GeneratedCode("CodeSmith", "6.0.0.0")]
        public virtual Fundflow Clone()
        {
            return (Fundflow)((ICloneable)this).Clone();
        }
        
        #endregion
        
        #region Serialization
        
        /// <summary>
        /// Deserializes an instance of <see cref="Account"/> from XML.
        /// </summary>
        /// <param name="xml">The XML string representing a <see cref="Account"/> instance.</param>
        /// <returns>An instance of <see cref="Account"/> that is deserialized from the XML String.</returns>
        [System.CodeDom.Compiler.GeneratedCode("CodeSmith", "6.0.0.0")]
        public static Fundflow FromXml(string xml)
        {
            var deserializer = new System.Runtime.Serialization.DataContractSerializer(typeof(Fundflow));

            using (var sr = new System.IO.StringReader(xml))
            using (var reader = System.Xml.XmlReader.Create(sr))
            {
                return deserializer.ReadObject(reader) as Fundflow;
            }
        }

        /// <summary>
        /// Deserializes an instance of <see cref="Account"/> from a byte array.
        /// </summary>
        /// <param name="buffer">The byte array representing a <see cref="Account"/> instance.</param>
        /// <returns>An instance of <see cref="Account"/> that is deserialized from the byte array.</returns>
        [System.CodeDom.Compiler.GeneratedCode("CodeSmith", "6.0.0.0")]
        public static Fundflow FromBinary(byte[] buffer)
        {
            var deserializer = new System.Runtime.Serialization.DataContractSerializer(typeof(Fundflow));

            using (var ms = new System.IO.MemoryStream(buffer))
            using (var reader = System.Xml.XmlDictionaryReader.CreateBinaryReader(ms, System.Xml.XmlDictionaryReaderQuotas.Max))
            {
                return deserializer.ReadObject(reader) as Fundflow;
            }
        }
        
        #endregion
    }
}

#pragma warning restore 1591
#pragma warning restore 0414

