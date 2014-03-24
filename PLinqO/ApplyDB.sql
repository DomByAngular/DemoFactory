/*==============================================================*/
/* DBMS name:      Microsoft SQL Server 2005                    */
/* Created on:     2013/12/8 22:29:08                           */
/*==============================================================*/


if exists (select 1
   from sys.sysreferences r join sys.sysobjects o on (o.id = r.constid and o.type = 'F')
   where r.fkeyid = object_id('tb_applydetail') and o.name = 'FK_ApplyDetail_ApplyRecord')
alter table tb_applydetail
   drop constraint FK_ApplyDetail_ApplyRecord
go

if exists (select 1
   from sys.sysreferences r join sys.sysobjects o on (o.id = r.constid and o.type = 'F')
   where r.fkeyid = object_id('tb_applydetail') and o.name = 'FK_ApplyItem_ApplyDetail')
alter table tb_applydetail
   drop constraint FK_ApplyItem_ApplyDetail
go

if exists (select 1
            from  sysobjects
           where  id = object_id('tb_applydetail')
            and   type = 'U')
   drop table tb_applydetail
go

if exists (select 1
            from  sysobjects
           where  id = object_id('tb_applyitem')
            and   type = 'U')
   drop table tb_applyitem
go

if exists (select 1
            from  sysobjects
           where  id = object_id('tb_applyrecord')
            and   type = 'U')
   drop table tb_applyrecord
go

if exists (select 1
            from  sysobjects
           where  id = object_id('tb_fundflow')
            and   type = 'U')
   drop table tb_fundflow
go

/*==============================================================*/
/* Table: tb_applydetail                                        */
/*==============================================================*/
create table tb_applydetail (
   DetailId             int                  identity,
   ItemId               int                  null,
   ApplyId              int                  null,
   Count                int                  null,
   Price                float                null,
   CreatedOn            datetime             null,
   CreatedBy            varchar(200)         null,
   ModifiedOn           datetime             null,
   ModifiedBy           varchar(200)         null,
   constraint PK_TB_APPLYDETAIL primary key nonclustered (DetailId)
)
go

declare @CurrentUser sysname
select @CurrentUser = user_name()
execute sys.sp_addextendedproperty 'MS_Description', 
   '报销明细表',
   'user', @CurrentUser, 'table', 'tb_applydetail'
go

declare @CurrentUser sysname
select @CurrentUser = user_name()
execute sp_addextendedproperty 'MS_Description', 
   '明细ID',
   'user', @CurrentUser, 'table', 'tb_applydetail', 'column', 'DetailId'
go

declare @CurrentUser sysname
select @CurrentUser = user_name()
execute sp_addextendedproperty 'MS_Description', 
   '项目类型Id',
   'user', @CurrentUser, 'table', 'tb_applydetail', 'column', 'ItemId'
go

declare @CurrentUser sysname
select @CurrentUser = user_name()
execute sp_addextendedproperty 'MS_Description', 
   '报销单ID',
   'user', @CurrentUser, 'table', 'tb_applydetail', 'column', 'ApplyId'
go

declare @CurrentUser sysname
select @CurrentUser = user_name()
execute sp_addextendedproperty 'MS_Description', 
   '项目数量',
   'user', @CurrentUser, 'table', 'tb_applydetail', 'column', 'Count'
go

declare @CurrentUser sysname
select @CurrentUser = user_name()
execute sp_addextendedproperty 'MS_Description', 
   '项目单价',
   'user', @CurrentUser, 'table', 'tb_applydetail', 'column', 'Price'
go

declare @CurrentUser sysname
select @CurrentUser = user_name()
execute sp_addextendedproperty 'MS_Description', 
   '创建时间',
   'user', @CurrentUser, 'table', 'tb_applydetail', 'column', 'CreatedOn'
go

declare @CurrentUser sysname
select @CurrentUser = user_name()
execute sp_addextendedproperty 'MS_Description', 
   '创建人',
   'user', @CurrentUser, 'table', 'tb_applydetail', 'column', 'CreatedBy'
go

declare @CurrentUser sysname
select @CurrentUser = user_name()
execute sp_addextendedproperty 'MS_Description', 
   '修改时间',
   'user', @CurrentUser, 'table', 'tb_applydetail', 'column', 'ModifiedOn'
go

declare @CurrentUser sysname
select @CurrentUser = user_name()
execute sp_addextendedproperty 'MS_Description', 
   '修改人',
   'user', @CurrentUser, 'table', 'tb_applydetail', 'column', 'ModifiedBy'
go

/*==============================================================*/
/* Table: tb_applyitem                                          */
/*==============================================================*/
create table tb_applyitem (
   ItemId               int                  identity,
   ItemName             varchar(100)         null,
   CreatedOn            datetime             null,
   CreatedBy            varchar(200)         null,
   ModifiedOn           datetime             null,
   ModifiedBy           varchar(200)         null,
   constraint PK_TB_APPLYITEM primary key nonclustered (ItemId)
)
go

declare @CurrentUser sysname
select @CurrentUser = user_name()
execute sys.sp_addextendedproperty 'MS_Description', 
   '报销项目表',
   'user', @CurrentUser, 'table', 'tb_applyitem'
go

declare @CurrentUser sysname
select @CurrentUser = user_name()
execute sp_addextendedproperty 'MS_Description', 
   '报销项目ID',
   'user', @CurrentUser, 'table', 'tb_applyitem', 'column', 'ItemId'
go

declare @CurrentUser sysname
select @CurrentUser = user_name()
execute sp_addextendedproperty 'MS_Description', 
   '报销项目名称',
   'user', @CurrentUser, 'table', 'tb_applyitem', 'column', 'ItemName'
go

declare @CurrentUser sysname
select @CurrentUser = user_name()
execute sp_addextendedproperty 'MS_Description', 
   '创建时间',
   'user', @CurrentUser, 'table', 'tb_applyitem', 'column', 'CreatedOn'
go

declare @CurrentUser sysname
select @CurrentUser = user_name()
execute sp_addextendedproperty 'MS_Description', 
   '创建人',
   'user', @CurrentUser, 'table', 'tb_applyitem', 'column', 'CreatedBy'
go

declare @CurrentUser sysname
select @CurrentUser = user_name()
execute sp_addextendedproperty 'MS_Description', 
   '修改时间',
   'user', @CurrentUser, 'table', 'tb_applyitem', 'column', 'ModifiedOn'
go

declare @CurrentUser sysname
select @CurrentUser = user_name()
execute sp_addextendedproperty 'MS_Description', 
   '修改人',
   'user', @CurrentUser, 'table', 'tb_applyitem', 'column', 'ModifiedBy'
go

/*==============================================================*/
/* Table: tb_applyrecord                                        */
/*==============================================================*/
create table tb_applyrecord (
   ApplyId              int                  identity,
   Or_Id                int                  null,
   Price                float                null,
   Currency             varchar(10)          null,
   ApplyBy              varchar(200)         null,
   ApplyOn              datetime             null,
   Description          varchar(500)         null,
   IsCar                int                  null,
   CarNo                varchar(20)          null,
   AuditStatus          int                  null,
   DepAuditBy           varchar(200)         null,
   FinanceAuditBy       varchar(200)         null,
   FinalAuditBy         varchar(200)         null,
   CreatedOn            datetime             null,
   CreatedBy            varchar(200)         null,
   ModifiedOn           datetime             null,
   ModifiedBy           varchar(200)         null,
   constraint PK_TB_APPLYRECORD primary key nonclustered (ApplyId)
)
go

declare @CurrentUser sysname
select @CurrentUser = user_name()
execute sys.sp_addextendedproperty 'MS_Description', 
   '报销记录表',
   'user', @CurrentUser, 'table', 'tb_applyrecord'
go

declare @CurrentUser sysname
select @CurrentUser = user_name()
execute sp_addextendedproperty 'MS_Description', 
   '报销单ID',
   'user', @CurrentUser, 'table', 'tb_applyrecord', 'column', 'ApplyId'
go

declare @CurrentUser sysname
select @CurrentUser = user_name()
execute sp_addextendedproperty 'MS_Description', 
   '报销部门ID',
   'user', @CurrentUser, 'table', 'tb_applyrecord', 'column', 'Or_Id'
go

declare @CurrentUser sysname
select @CurrentUser = user_name()
execute sp_addextendedproperty 'MS_Description', 
   '报销金额',
   'user', @CurrentUser, 'table', 'tb_applyrecord', 'column', 'Price'
go

declare @CurrentUser sysname
select @CurrentUser = user_name()
execute sp_addextendedproperty 'MS_Description', 
   '报销币种',
   'user', @CurrentUser, 'table', 'tb_applyrecord', 'column', 'Currency'
go

declare @CurrentUser sysname
select @CurrentUser = user_name()
execute sp_addextendedproperty 'MS_Description', 
   '经手人',
   'user', @CurrentUser, 'table', 'tb_applyrecord', 'column', 'ApplyBy'
go

declare @CurrentUser sysname
select @CurrentUser = user_name()
execute sp_addextendedproperty 'MS_Description', 
   '报销单填写日期',
   'user', @CurrentUser, 'table', 'tb_applyrecord', 'column', 'ApplyOn'
go

declare @CurrentUser sysname
select @CurrentUser = user_name()
execute sp_addextendedproperty 'MS_Description', 
   '备注',
   'user', @CurrentUser, 'table', 'tb_applyrecord', 'column', 'Description'
go

declare @CurrentUser sysname
select @CurrentUser = user_name()
execute sp_addextendedproperty 'MS_Description', 
   '是否是车辆成本',
   'user', @CurrentUser, 'table', 'tb_applyrecord', 'column', 'IsCar'
go

declare @CurrentUser sysname
select @CurrentUser = user_name()
execute sp_addextendedproperty 'MS_Description', 
   '车牌号',
   'user', @CurrentUser, 'table', 'tb_applyrecord', 'column', 'CarNo'
go

declare @CurrentUser sysname
select @CurrentUser = user_name()
execute sp_addextendedproperty 'MS_Description', 
   '报销审核状态（0：新增，1：部门审核，2：财务审核，3：最终审核，4：已支付）',
   'user', @CurrentUser, 'table', 'tb_applyrecord', 'column', 'AuditStatus'
go

declare @CurrentUser sysname
select @CurrentUser = user_name()
execute sp_addextendedproperty 'MS_Description', 
   '部门审核人',
   'user', @CurrentUser, 'table', 'tb_applyrecord', 'column', 'DepAuditBy'
go

declare @CurrentUser sysname
select @CurrentUser = user_name()
execute sp_addextendedproperty 'MS_Description', 
   '财务审核人',
   'user', @CurrentUser, 'table', 'tb_applyrecord', 'column', 'FinanceAuditBy'
go

declare @CurrentUser sysname
select @CurrentUser = user_name()
execute sp_addextendedproperty 'MS_Description', 
   '最终审核人',
   'user', @CurrentUser, 'table', 'tb_applyrecord', 'column', 'FinalAuditBy'
go

declare @CurrentUser sysname
select @CurrentUser = user_name()
execute sp_addextendedproperty 'MS_Description', 
   '创建日期',
   'user', @CurrentUser, 'table', 'tb_applyrecord', 'column', 'CreatedOn'
go

declare @CurrentUser sysname
select @CurrentUser = user_name()
execute sp_addextendedproperty 'MS_Description', 
   '创建人',
   'user', @CurrentUser, 'table', 'tb_applyrecord', 'column', 'CreatedBy'
go

declare @CurrentUser sysname
select @CurrentUser = user_name()
execute sp_addextendedproperty 'MS_Description', 
   '修改日期',
   'user', @CurrentUser, 'table', 'tb_applyrecord', 'column', 'ModifiedOn'
go

declare @CurrentUser sysname
select @CurrentUser = user_name()
execute sp_addextendedproperty 'MS_Description', 
   '修改人',
   'user', @CurrentUser, 'table', 'tb_applyrecord', 'column', 'ModifiedBy'
go

/*==============================================================*/
/* Table: tb_fundflow                                           */
/*==============================================================*/
create table tb_fundflow (
   FlowId               int                  identity,
   Date                 datetime             null,
   PaymentType          int                  null,
   Bank                 varchar(100)         null,
   Account              varchar(100)         null,
   Price                float                null,
   Currency             varchar(10)          null,
   Description          varchar(500)         null,
   Maker                varchar(200)         null,
   IsPayment            int                  null,
   IsAudit              int                  null,
   AuditBy              varchar(200)         null,
   CreatedOn            datetime             null,
   CreatedBy            varchar(200)         null,
   ModifiedOn           datetime             null,
   ModifiedBy           varchar(200)         null,
   constraint PK_TB_FUNDFLOW primary key nonclustered (FlowId)
)
go

declare @CurrentUser sysname
select @CurrentUser = user_name()
execute sys.sp_addextendedproperty 'MS_Description', 
   '财务收支表',
   'user', @CurrentUser, 'table', 'tb_fundflow'
go

declare @CurrentUser sysname
select @CurrentUser = user_name()
execute sp_addextendedproperty 'MS_Description', 
   '主键ID',
   'user', @CurrentUser, 'table', 'tb_fundflow', 'column', 'FlowId'
go

declare @CurrentUser sysname
select @CurrentUser = user_name()
execute sp_addextendedproperty 'MS_Description', 
   '交易日期',
   'user', @CurrentUser, 'table', 'tb_fundflow', 'column', 'Date'
go

declare @CurrentUser sysname
select @CurrentUser = user_name()
execute sp_addextendedproperty 'MS_Description', 
   '交易方式（1：现金，2：银行转账）',
   'user', @CurrentUser, 'table', 'tb_fundflow', 'column', 'PaymentType'
go

declare @CurrentUser sysname
select @CurrentUser = user_name()
execute sp_addextendedproperty 'MS_Description', 
   '银行',
   'user', @CurrentUser, 'table', 'tb_fundflow', 'column', 'Bank'
go

declare @CurrentUser sysname
select @CurrentUser = user_name()
execute sp_addextendedproperty 'MS_Description', 
   '银行账户',
   'user', @CurrentUser, 'table', 'tb_fundflow', 'column', 'Account'
go

declare @CurrentUser sysname
select @CurrentUser = user_name()
execute sp_addextendedproperty 'MS_Description', 
   '交易金额',
   'user', @CurrentUser, 'table', 'tb_fundflow', 'column', 'Price'
go

declare @CurrentUser sysname
select @CurrentUser = user_name()
execute sp_addextendedproperty 'MS_Description', 
   '交易币种',
   'user', @CurrentUser, 'table', 'tb_fundflow', 'column', 'Currency'
go

declare @CurrentUser sysname
select @CurrentUser = user_name()
execute sp_addextendedproperty 'MS_Description', 
   '描述',
   'user', @CurrentUser, 'table', 'tb_fundflow', 'column', 'Description'
go

declare @CurrentUser sysname
select @CurrentUser = user_name()
execute sp_addextendedproperty 'MS_Description', 
   '经手人',
   'user', @CurrentUser, 'table', 'tb_fundflow', 'column', 'Maker'
go

declare @CurrentUser sysname
select @CurrentUser = user_name()
execute sp_addextendedproperty 'MS_Description', 
   '交易类型（1：收款，0：付款）',
   'user', @CurrentUser, 'table', 'tb_fundflow', 'column', 'IsPayment'
go

declare @CurrentUser sysname
select @CurrentUser = user_name()
execute sp_addextendedproperty 'MS_Description', 
   '是否核账(0:未核账,1:已核账)',
   'user', @CurrentUser, 'table', 'tb_fundflow', 'column', 'IsAudit'
go

declare @CurrentUser sysname
select @CurrentUser = user_name()
execute sp_addextendedproperty 'MS_Description', 
   '财务审核人',
   'user', @CurrentUser, 'table', 'tb_fundflow', 'column', 'AuditBy'
go

declare @CurrentUser sysname
select @CurrentUser = user_name()
execute sp_addextendedproperty 'MS_Description', 
   '创建时间',
   'user', @CurrentUser, 'table', 'tb_fundflow', 'column', 'CreatedOn'
go

declare @CurrentUser sysname
select @CurrentUser = user_name()
execute sp_addextendedproperty 'MS_Description', 
   '创建人',
   'user', @CurrentUser, 'table', 'tb_fundflow', 'column', 'CreatedBy'
go

declare @CurrentUser sysname
select @CurrentUser = user_name()
execute sp_addextendedproperty 'MS_Description', 
   '修改时间',
   'user', @CurrentUser, 'table', 'tb_fundflow', 'column', 'ModifiedOn'
go

declare @CurrentUser sysname
select @CurrentUser = user_name()
execute sp_addextendedproperty 'MS_Description', 
   '修改人',
   'user', @CurrentUser, 'table', 'tb_fundflow', 'column', 'ModifiedBy'
go

alter table tb_applydetail
   add constraint FK_ApplyDetail_ApplyRecord foreign key (ApplyId)
      references tb_applyrecord (ApplyId)
go

alter table tb_applydetail
   add constraint FK_ApplyItem_ApplyDetail foreign key (ItemId)
      references tb_applyitem (ItemId)
go

