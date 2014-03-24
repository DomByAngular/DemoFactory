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
   '������ϸ��',
   'user', @CurrentUser, 'table', 'tb_applydetail'
go

declare @CurrentUser sysname
select @CurrentUser = user_name()
execute sp_addextendedproperty 'MS_Description', 
   '��ϸID',
   'user', @CurrentUser, 'table', 'tb_applydetail', 'column', 'DetailId'
go

declare @CurrentUser sysname
select @CurrentUser = user_name()
execute sp_addextendedproperty 'MS_Description', 
   '��Ŀ����Id',
   'user', @CurrentUser, 'table', 'tb_applydetail', 'column', 'ItemId'
go

declare @CurrentUser sysname
select @CurrentUser = user_name()
execute sp_addextendedproperty 'MS_Description', 
   '������ID',
   'user', @CurrentUser, 'table', 'tb_applydetail', 'column', 'ApplyId'
go

declare @CurrentUser sysname
select @CurrentUser = user_name()
execute sp_addextendedproperty 'MS_Description', 
   '��Ŀ����',
   'user', @CurrentUser, 'table', 'tb_applydetail', 'column', 'Count'
go

declare @CurrentUser sysname
select @CurrentUser = user_name()
execute sp_addextendedproperty 'MS_Description', 
   '��Ŀ����',
   'user', @CurrentUser, 'table', 'tb_applydetail', 'column', 'Price'
go

declare @CurrentUser sysname
select @CurrentUser = user_name()
execute sp_addextendedproperty 'MS_Description', 
   '����ʱ��',
   'user', @CurrentUser, 'table', 'tb_applydetail', 'column', 'CreatedOn'
go

declare @CurrentUser sysname
select @CurrentUser = user_name()
execute sp_addextendedproperty 'MS_Description', 
   '������',
   'user', @CurrentUser, 'table', 'tb_applydetail', 'column', 'CreatedBy'
go

declare @CurrentUser sysname
select @CurrentUser = user_name()
execute sp_addextendedproperty 'MS_Description', 
   '�޸�ʱ��',
   'user', @CurrentUser, 'table', 'tb_applydetail', 'column', 'ModifiedOn'
go

declare @CurrentUser sysname
select @CurrentUser = user_name()
execute sp_addextendedproperty 'MS_Description', 
   '�޸���',
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
   '������Ŀ��',
   'user', @CurrentUser, 'table', 'tb_applyitem'
go

declare @CurrentUser sysname
select @CurrentUser = user_name()
execute sp_addextendedproperty 'MS_Description', 
   '������ĿID',
   'user', @CurrentUser, 'table', 'tb_applyitem', 'column', 'ItemId'
go

declare @CurrentUser sysname
select @CurrentUser = user_name()
execute sp_addextendedproperty 'MS_Description', 
   '������Ŀ����',
   'user', @CurrentUser, 'table', 'tb_applyitem', 'column', 'ItemName'
go

declare @CurrentUser sysname
select @CurrentUser = user_name()
execute sp_addextendedproperty 'MS_Description', 
   '����ʱ��',
   'user', @CurrentUser, 'table', 'tb_applyitem', 'column', 'CreatedOn'
go

declare @CurrentUser sysname
select @CurrentUser = user_name()
execute sp_addextendedproperty 'MS_Description', 
   '������',
   'user', @CurrentUser, 'table', 'tb_applyitem', 'column', 'CreatedBy'
go

declare @CurrentUser sysname
select @CurrentUser = user_name()
execute sp_addextendedproperty 'MS_Description', 
   '�޸�ʱ��',
   'user', @CurrentUser, 'table', 'tb_applyitem', 'column', 'ModifiedOn'
go

declare @CurrentUser sysname
select @CurrentUser = user_name()
execute sp_addextendedproperty 'MS_Description', 
   '�޸���',
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
   '������¼��',
   'user', @CurrentUser, 'table', 'tb_applyrecord'
go

declare @CurrentUser sysname
select @CurrentUser = user_name()
execute sp_addextendedproperty 'MS_Description', 
   '������ID',
   'user', @CurrentUser, 'table', 'tb_applyrecord', 'column', 'ApplyId'
go

declare @CurrentUser sysname
select @CurrentUser = user_name()
execute sp_addextendedproperty 'MS_Description', 
   '��������ID',
   'user', @CurrentUser, 'table', 'tb_applyrecord', 'column', 'Or_Id'
go

declare @CurrentUser sysname
select @CurrentUser = user_name()
execute sp_addextendedproperty 'MS_Description', 
   '�������',
   'user', @CurrentUser, 'table', 'tb_applyrecord', 'column', 'Price'
go

declare @CurrentUser sysname
select @CurrentUser = user_name()
execute sp_addextendedproperty 'MS_Description', 
   '��������',
   'user', @CurrentUser, 'table', 'tb_applyrecord', 'column', 'Currency'
go

declare @CurrentUser sysname
select @CurrentUser = user_name()
execute sp_addextendedproperty 'MS_Description', 
   '������',
   'user', @CurrentUser, 'table', 'tb_applyrecord', 'column', 'ApplyBy'
go

declare @CurrentUser sysname
select @CurrentUser = user_name()
execute sp_addextendedproperty 'MS_Description', 
   '��������д����',
   'user', @CurrentUser, 'table', 'tb_applyrecord', 'column', 'ApplyOn'
go

declare @CurrentUser sysname
select @CurrentUser = user_name()
execute sp_addextendedproperty 'MS_Description', 
   '��ע',
   'user', @CurrentUser, 'table', 'tb_applyrecord', 'column', 'Description'
go

declare @CurrentUser sysname
select @CurrentUser = user_name()
execute sp_addextendedproperty 'MS_Description', 
   '�Ƿ��ǳ����ɱ�',
   'user', @CurrentUser, 'table', 'tb_applyrecord', 'column', 'IsCar'
go

declare @CurrentUser sysname
select @CurrentUser = user_name()
execute sp_addextendedproperty 'MS_Description', 
   '���ƺ�',
   'user', @CurrentUser, 'table', 'tb_applyrecord', 'column', 'CarNo'
go

declare @CurrentUser sysname
select @CurrentUser = user_name()
execute sp_addextendedproperty 'MS_Description', 
   '�������״̬��0��������1��������ˣ�2��������ˣ�3��������ˣ�4����֧����',
   'user', @CurrentUser, 'table', 'tb_applyrecord', 'column', 'AuditStatus'
go

declare @CurrentUser sysname
select @CurrentUser = user_name()
execute sp_addextendedproperty 'MS_Description', 
   '���������',
   'user', @CurrentUser, 'table', 'tb_applyrecord', 'column', 'DepAuditBy'
go

declare @CurrentUser sysname
select @CurrentUser = user_name()
execute sp_addextendedproperty 'MS_Description', 
   '���������',
   'user', @CurrentUser, 'table', 'tb_applyrecord', 'column', 'FinanceAuditBy'
go

declare @CurrentUser sysname
select @CurrentUser = user_name()
execute sp_addextendedproperty 'MS_Description', 
   '���������',
   'user', @CurrentUser, 'table', 'tb_applyrecord', 'column', 'FinalAuditBy'
go

declare @CurrentUser sysname
select @CurrentUser = user_name()
execute sp_addextendedproperty 'MS_Description', 
   '��������',
   'user', @CurrentUser, 'table', 'tb_applyrecord', 'column', 'CreatedOn'
go

declare @CurrentUser sysname
select @CurrentUser = user_name()
execute sp_addextendedproperty 'MS_Description', 
   '������',
   'user', @CurrentUser, 'table', 'tb_applyrecord', 'column', 'CreatedBy'
go

declare @CurrentUser sysname
select @CurrentUser = user_name()
execute sp_addextendedproperty 'MS_Description', 
   '�޸�����',
   'user', @CurrentUser, 'table', 'tb_applyrecord', 'column', 'ModifiedOn'
go

declare @CurrentUser sysname
select @CurrentUser = user_name()
execute sp_addextendedproperty 'MS_Description', 
   '�޸���',
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
   '������֧��',
   'user', @CurrentUser, 'table', 'tb_fundflow'
go

declare @CurrentUser sysname
select @CurrentUser = user_name()
execute sp_addextendedproperty 'MS_Description', 
   '����ID',
   'user', @CurrentUser, 'table', 'tb_fundflow', 'column', 'FlowId'
go

declare @CurrentUser sysname
select @CurrentUser = user_name()
execute sp_addextendedproperty 'MS_Description', 
   '��������',
   'user', @CurrentUser, 'table', 'tb_fundflow', 'column', 'Date'
go

declare @CurrentUser sysname
select @CurrentUser = user_name()
execute sp_addextendedproperty 'MS_Description', 
   '���׷�ʽ��1���ֽ�2������ת�ˣ�',
   'user', @CurrentUser, 'table', 'tb_fundflow', 'column', 'PaymentType'
go

declare @CurrentUser sysname
select @CurrentUser = user_name()
execute sp_addextendedproperty 'MS_Description', 
   '����',
   'user', @CurrentUser, 'table', 'tb_fundflow', 'column', 'Bank'
go

declare @CurrentUser sysname
select @CurrentUser = user_name()
execute sp_addextendedproperty 'MS_Description', 
   '�����˻�',
   'user', @CurrentUser, 'table', 'tb_fundflow', 'column', 'Account'
go

declare @CurrentUser sysname
select @CurrentUser = user_name()
execute sp_addextendedproperty 'MS_Description', 
   '���׽��',
   'user', @CurrentUser, 'table', 'tb_fundflow', 'column', 'Price'
go

declare @CurrentUser sysname
select @CurrentUser = user_name()
execute sp_addextendedproperty 'MS_Description', 
   '���ױ���',
   'user', @CurrentUser, 'table', 'tb_fundflow', 'column', 'Currency'
go

declare @CurrentUser sysname
select @CurrentUser = user_name()
execute sp_addextendedproperty 'MS_Description', 
   '����',
   'user', @CurrentUser, 'table', 'tb_fundflow', 'column', 'Description'
go

declare @CurrentUser sysname
select @CurrentUser = user_name()
execute sp_addextendedproperty 'MS_Description', 
   '������',
   'user', @CurrentUser, 'table', 'tb_fundflow', 'column', 'Maker'
go

declare @CurrentUser sysname
select @CurrentUser = user_name()
execute sp_addextendedproperty 'MS_Description', 
   '�������ͣ�1���տ0�����',
   'user', @CurrentUser, 'table', 'tb_fundflow', 'column', 'IsPayment'
go

declare @CurrentUser sysname
select @CurrentUser = user_name()
execute sp_addextendedproperty 'MS_Description', 
   '�Ƿ����(0:δ����,1:�Ѻ���)',
   'user', @CurrentUser, 'table', 'tb_fundflow', 'column', 'IsAudit'
go

declare @CurrentUser sysname
select @CurrentUser = user_name()
execute sp_addextendedproperty 'MS_Description', 
   '���������',
   'user', @CurrentUser, 'table', 'tb_fundflow', 'column', 'AuditBy'
go

declare @CurrentUser sysname
select @CurrentUser = user_name()
execute sp_addextendedproperty 'MS_Description', 
   '����ʱ��',
   'user', @CurrentUser, 'table', 'tb_fundflow', 'column', 'CreatedOn'
go

declare @CurrentUser sysname
select @CurrentUser = user_name()
execute sp_addextendedproperty 'MS_Description', 
   '������',
   'user', @CurrentUser, 'table', 'tb_fundflow', 'column', 'CreatedBy'
go

declare @CurrentUser sysname
select @CurrentUser = user_name()
execute sp_addextendedproperty 'MS_Description', 
   '�޸�ʱ��',
   'user', @CurrentUser, 'table', 'tb_fundflow', 'column', 'ModifiedOn'
go

declare @CurrentUser sysname
select @CurrentUser = user_name()
execute sp_addextendedproperty 'MS_Description', 
   '�޸���',
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

