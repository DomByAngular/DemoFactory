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
    [System.Diagnostics.DebuggerDisplay("ApplyId: {ApplyId}")]
    public partial class Applyrecord : EntityBase
    {
        #region Static Constructor
        
        /// <summary>
        /// Initializes the <see cref="Account"/> class.
        /// </summary>
        [System.CodeDom.Compiler.GeneratedCode("CodeSmith", "5.0.0.0")]
        static Applyrecord()
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
        public Applyrecord()
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
        private System.Int32 _applyId;
        
        [System.Runtime.Serialization.DataMember(Order = 1)]
        [System.CodeDom.Compiler.GeneratedCode("CodeSmith", "6.0.0.0")]
        public virtual System.Int32 ApplyId
        {
            get { return _applyId; }
            set
            {
                OnApplyIdChanging(value, _applyId);
                SendPropertyChanging("ApplyId");
                _applyId = value;
                SendPropertyChanged("ApplyId");
                OnApplyIdChanged(value);
            }
        }
        
        [System.CodeDom.Compiler.GeneratedCode("CodeSmith", "6.0.0.0")]
        private System.Int32? _orId;
        
        [System.Runtime.Serialization.DataMember(Order = 2)]
        [System.CodeDom.Compiler.GeneratedCode("CodeSmith", "6.0.0.0")]
        public virtual System.Int32? OrId
        {
            get { return _orId; }
            set
            {
                OnOrIdChanging(value, _orId);
                SendPropertyChanging("OrId");
                _orId = value;
                SendPropertyChanged("OrId");
                OnOrIdChanged(value);
            }
        }
        
        [System.CodeDom.Compiler.GeneratedCode("CodeSmith", "6.0.0.0")]
        private System.Double? _price;
        
        [System.Runtime.Serialization.DataMember(Order = 3)]
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
        
        [System.Runtime.Serialization.DataMember(Order = 4)]
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
        private System.String _applyBy;
        
        [System.Runtime.Serialization.DataMember(Order = 5)]
        [System.CodeDom.Compiler.GeneratedCode("CodeSmith", "6.0.0.0")]
        public virtual System.String ApplyBy
        {
            get { return _applyBy; }
            set
            {
                OnApplyByChanging(value, _applyBy);
                SendPropertyChanging("ApplyBy");
                _applyBy = value;
                SendPropertyChanged("ApplyBy");
                OnApplyByChanged(value);
            }
        }
        
        [System.CodeDom.Compiler.GeneratedCode("CodeSmith", "6.0.0.0")]
        private System.DateTime? _applyOn;
        
        [System.Runtime.Serialization.DataMember(Order = 6)]
        [System.CodeDom.Compiler.GeneratedCode("CodeSmith", "6.0.0.0")]
        public virtual System.DateTime? ApplyOn
        {
            get { return _applyOn; }
            set
            {
                OnApplyOnChanging(value, _applyOn);
                SendPropertyChanging("ApplyOn");
                _applyOn = value;
                SendPropertyChanged("ApplyOn");
                OnApplyOnChanged(value);
            }
        }
        
        [System.CodeDom.Compiler.GeneratedCode("CodeSmith", "6.0.0.0")]
        private System.String _description;
        
        [System.Runtime.Serialization.DataMember(Order = 7)]
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
        private System.Int32? _isCar;
        
        [System.Runtime.Serialization.DataMember(Order = 8)]
        [System.CodeDom.Compiler.GeneratedCode("CodeSmith", "6.0.0.0")]
        public virtual System.Int32? IsCar
        {
            get { return _isCar; }
            set
            {
                OnIsCarChanging(value, _isCar);
                SendPropertyChanging("IsCar");
                _isCar = value;
                SendPropertyChanged("IsCar");
                OnIsCarChanged(value);
            }
        }
        
        [System.CodeDom.Compiler.GeneratedCode("CodeSmith", "6.0.0.0")]
        private System.String _carNo;
        
        [System.Runtime.Serialization.DataMember(Order = 9)]
        [System.CodeDom.Compiler.GeneratedCode("CodeSmith", "6.0.0.0")]
        public virtual System.String CarNo
        {
            get { return _carNo; }
            set
            {
                OnCarNoChanging(value, _carNo);
                SendPropertyChanging("CarNo");
                _carNo = value;
                SendPropertyChanged("CarNo");
                OnCarNoChanged(value);
            }
        }
        
        [System.CodeDom.Compiler.GeneratedCode("CodeSmith", "6.0.0.0")]
        private System.Int32? _auditStatus;
        
        [System.Runtime.Serialization.DataMember(Order = 10)]
        [System.CodeDom.Compiler.GeneratedCode("CodeSmith", "6.0.0.0")]
        public virtual System.Int32? AuditStatus
        {
            get { return _auditStatus; }
            set
            {
                OnAuditStatusChanging(value, _auditStatus);
                SendPropertyChanging("AuditStatus");
                _auditStatus = value;
                SendPropertyChanged("AuditStatus");
                OnAuditStatusChanged(value);
            }
        }
        
        [System.CodeDom.Compiler.GeneratedCode("CodeSmith", "6.0.0.0")]
        private System.String _depAuditBy;
        
        [System.Runtime.Serialization.DataMember(Order = 11)]
        [System.CodeDom.Compiler.GeneratedCode("CodeSmith", "6.0.0.0")]
        public virtual System.String DepAuditBy
        {
            get { return _depAuditBy; }
            set
            {
                OnDepAuditByChanging(value, _depAuditBy);
                SendPropertyChanging("DepAuditBy");
                _depAuditBy = value;
                SendPropertyChanged("DepAuditBy");
                OnDepAuditByChanged(value);
            }
        }
        
        [System.CodeDom.Compiler.GeneratedCode("CodeSmith", "6.0.0.0")]
        private System.String _financeAuditBy;
        
        [System.Runtime.Serialization.DataMember(Order = 12)]
        [System.CodeDom.Compiler.GeneratedCode("CodeSmith", "6.0.0.0")]
        public virtual System.String FinanceAuditBy
        {
            get { return _financeAuditBy; }
            set
            {
                OnFinanceAuditByChanging(value, _financeAuditBy);
                SendPropertyChanging("FinanceAuditBy");
                _financeAuditBy = value;
                SendPropertyChanged("FinanceAuditBy");
                OnFinanceAuditByChanged(value);
            }
        }
        
        [System.CodeDom.Compiler.GeneratedCode("CodeSmith", "6.0.0.0")]
        private System.String _finalAuditBy;
        
        [System.Runtime.Serialization.DataMember(Order = 13)]
        [System.CodeDom.Compiler.GeneratedCode("CodeSmith", "6.0.0.0")]
        public virtual System.String FinalAuditBy
        {
            get { return _finalAuditBy; }
            set
            {
                OnFinalAuditByChanging(value, _finalAuditBy);
                SendPropertyChanging("FinalAuditBy");
                _finalAuditBy = value;
                SendPropertyChanged("FinalAuditBy");
                OnFinalAuditByChanged(value);
            }
        }
        
        [System.CodeDom.Compiler.GeneratedCode("CodeSmith", "6.0.0.0")]
        private System.DateTime? _createdOn;
        
        [System.Runtime.Serialization.DataMember(Order = 14)]
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
        
        [System.Runtime.Serialization.DataMember(Order = 15)]
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
        
        [System.Runtime.Serialization.DataMember(Order = 16)]
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
        
        [System.Runtime.Serialization.DataMember(Order = 17)]
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

		[System.CodeDom.Compiler.GeneratedCode("CodeSmith", "6.0.0.0")]
		private System.String _orName;

		[System.Runtime.Serialization.DataMember(Order = 18)]
		[System.CodeDom.Compiler.GeneratedCode("CodeSmith", "6.0.0.0")]
		public virtual System.String OrName
		{
			get { return _orName; }
			set
			{
				OnModifiedByChanging(value, _orName);
				SendPropertyChanging("OrName");
				_orName = value;
				SendPropertyChanged("OrName");
				OnModifiedByChanged(value);
			}
		}
        
        #endregion
        
        #region Associations Mappings
        
        [System.CodeDom.Compiler.GeneratedCode("CodeSmith", "6.0.0.0")]
        private IList<Applydetail> _applydetailList;
        
        [System.Runtime.Serialization.DataMember(Order = 18, EmitDefaultValue = false)]
        [System.CodeDom.Compiler.GeneratedCode("CodeSmith", "6.0.0.0")]
        public virtual IList<Applydetail> ApplydetailList
        {
            get { return _applydetailList; }
            set
            {
                OnApplydetailListChanging(value, _applydetailList);
                SendPropertyChanging("ApplydetailList");
                _applydetailList = value;
                SendPropertyChanged("ApplydetailList");
                OnApplydetailListChanged(value);
            }
        }
        
        #endregion
        
        #region Extensibility Method
        
        static partial void AddSharedRules();
        
        partial void OnCreated();
        
        partial void OnApplyIdChanging(System.Int32 newValue, System.Int32 oldValue);
        
        partial void OnApplyIdChanged(System.Int32 value);
        
        partial void OnOrIdChanging(System.Int32? newValue, System.Int32? oldValue);
        
        partial void OnOrIdChanged(System.Int32? value);
        
        partial void OnPriceChanging(System.Double? newValue, System.Double? oldValue);
        
        partial void OnPriceChanged(System.Double? value);
        
        partial void OnCurrencyChanging(System.String newValue, System.String oldValue);
        
        partial void OnCurrencyChanged(System.String value);
        
        partial void OnApplyByChanging(System.String newValue, System.String oldValue);
        
        partial void OnApplyByChanged(System.String value);
        
        partial void OnApplyOnChanging(System.DateTime? newValue, System.DateTime? oldValue);
        
        partial void OnApplyOnChanged(System.DateTime? value);
        
        partial void OnDescriptionChanging(System.String newValue, System.String oldValue);
        
        partial void OnDescriptionChanged(System.String value);
        
        partial void OnIsCarChanging(System.Int32? newValue, System.Int32? oldValue);
        
        partial void OnIsCarChanged(System.Int32? value);
        
        partial void OnCarNoChanging(System.String newValue, System.String oldValue);
        
        partial void OnCarNoChanged(System.String value);
        
        partial void OnAuditStatusChanging(System.Int32? newValue, System.Int32? oldValue);
        
        partial void OnAuditStatusChanged(System.Int32? value);
        
        partial void OnDepAuditByChanging(System.String newValue, System.String oldValue);
        
        partial void OnDepAuditByChanged(System.String value);
        
        partial void OnFinanceAuditByChanging(System.String newValue, System.String oldValue);
        
        partial void OnFinanceAuditByChanged(System.String value);
        
        partial void OnFinalAuditByChanging(System.String newValue, System.String oldValue);
        
        partial void OnFinalAuditByChanged(System.String value);
        
        partial void OnCreatedOnChanging(System.DateTime? newValue, System.DateTime? oldValue);
        
        partial void OnCreatedOnChanged(System.DateTime? value);
        
        partial void OnCreatedByChanging(System.String newValue, System.String oldValue);
        
        partial void OnCreatedByChanged(System.String value);
        
        partial void OnModifiedOnChanging(System.DateTime? newValue, System.DateTime? oldValue);
        
        partial void OnModifiedOnChanged(System.DateTime? value);
        
        partial void OnModifiedByChanging(System.String newValue, System.String oldValue);
        
        partial void OnModifiedByChanged(System.String value);
        
        
        partial void OnApplydetailListChanging(IList<Applydetail> newValue, IList<Applydetail> oldValue);
        
        partial void OnApplydetailListChanged(IList<Applydetail> value);
        
        #endregion
        
        #region Clone
        
        [System.CodeDom.Compiler.GeneratedCode("CodeSmith", "6.0.0.0")]
        public virtual Applyrecord Clone()
        {
            return (Applyrecord)((ICloneable)this).Clone();
        }
        
        #endregion
        
        #region Serialization
        
        /// <summary>
        /// Deserializes an instance of <see cref="Account"/> from XML.
        /// </summary>
        /// <param name="xml">The XML string representing a <see cref="Account"/> instance.</param>
        /// <returns>An instance of <see cref="Account"/> that is deserialized from the XML String.</returns>
        [System.CodeDom.Compiler.GeneratedCode("CodeSmith", "6.0.0.0")]
        public static Applyrecord FromXml(string xml)
        {
            var deserializer = new System.Runtime.Serialization.DataContractSerializer(typeof(Applyrecord));

            using (var sr = new System.IO.StringReader(xml))
            using (var reader = System.Xml.XmlReader.Create(sr))
            {
                return deserializer.ReadObject(reader) as Applyrecord;
            }
        }

        /// <summary>
        /// Deserializes an instance of <see cref="Account"/> from a byte array.
        /// </summary>
        /// <param name="buffer">The byte array representing a <see cref="Account"/> instance.</param>
        /// <returns>An instance of <see cref="Account"/> that is deserialized from the byte array.</returns>
        [System.CodeDom.Compiler.GeneratedCode("CodeSmith", "6.0.0.0")]
        public static Applyrecord FromBinary(byte[] buffer)
        {
            var deserializer = new System.Runtime.Serialization.DataContractSerializer(typeof(Applyrecord));

            using (var ms = new System.IO.MemoryStream(buffer))
            using (var reader = System.Xml.XmlDictionaryReader.CreateBinaryReader(ms, System.Xml.XmlDictionaryReaderQuotas.Max))
            {
                return deserializer.ReadObject(reader) as Applyrecord;
            }
        }
        
        #endregion
    }
}

#pragma warning restore 1591
#pragma warning restore 0414

