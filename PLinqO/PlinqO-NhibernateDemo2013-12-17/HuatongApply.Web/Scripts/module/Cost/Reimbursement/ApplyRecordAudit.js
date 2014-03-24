/***********************************
/* 创建人：ys   
/* 修改人：
/* 修改日期：2013-12-03
/* 包含审核列表的绑定,审核功能
/* 依赖：easyloader.js,easyui.config.js
***********************************/
//easyloader.defaultReferenceModules表示默认引用easyui.public.js,如果当前IE7时会自动附加引用json2.min.js

var itemdatas = [
{"Id":"1","Name":"质量保障部"},
{"Id":"2","Name":"研发部"},
{"Id":"3","Name":"UI部"},
{"Id":"4","Name":"前端技术部"},
{"Id":"5","Name":"质量保障部"},
{"Id":"6","Name":"人力资源部"}
];
//列表显示字段
var colums = [[
            { field: 'ApplyId', checkbox: true },
            { field: 'AuditStatus', title: '审核状态', width: 70,
                formatter: function (value) {
                    if (value == 0) {
                        return '<span style="color:green">未审核</span>';
                    }
                    else if (value == 1) {
                        return '<span style="color:red">部门审核</span>';
                    }
                    else if (value == 2) {
                        return '<span style="color:red">财务审核</span>';
                    }
                    else if (value == 3) {
                        return '<span style="color:red">最终审核</span>';
                    }
                    else if (value == 4) {
                        return '<span style="color:red">已支付</span>';
                    }
                    else {
                        return '<span style="color:red">未知状态</span>';
                    }
                }
            },
            { field: 'OrName', title: '报销部门', width: 150 },
            { field: 'Price', title: '报销金额', width: 100 },
            { field: 'Currency', title: '币种', width: 50 },
            { field: 'ApplyBy', title: '经手人', width: 70 },
            { field: 'ApplyOnLongStr', title: '申请时间', width: 150 },
            { field: 'IsCarStr', title: '车辆成本', width: 60 },
            { field: 'CarNo', title: '车牌号', width: 150 },
            { field: 'DepAuditBy', title: '部门审核人', width: 100 },
            { field: 'FinanceAuditBy', title: '财务审核人', width: 100 },
            { field: 'FinalAuditBy', title: '最终审核人', width: 100 }
        ]];

var referenceModules = $.merge(['datagrid_detailview', 'nano'], easyloader.defaultReferenceModules);
using(referenceModules, function () {
    // 列表参数设置
    var dataGridOptions = {
        title: '报销记录',
        columns: colums,
        singleSelect: false,
        toolbar: '#toolbar',
        sortName: 'CreatedOn',
        sortOrder: 'desc',
        rownumbers: true,
        pagination: true,
        view: detailview,
        detailFormatter: function (rowIndex, row) {
            var detailViewTemplate = $("#detailViewTemplate").html();
            var detailView = '';
            if (detailViewTemplate.length > 0) {
                detailView = detailViewTemplate.replace(/{rowIndex}/g, rowIndex);
            }
            return detailView;
        },
        onExpandRow: function (index, row) {
            console.log(index);
            console.log(row);
            var divCache = $("#divCache");
            if (divCache.length > 0 && divCache.data("lastRowIndex") != undefined && divCache.data("lastRowIndex") != index) {
                collapseRow('dg', divCache.data("lastRowIndex"));
            }
            divCache.data("lastRowIndex", index);
            panel('panle' + index, {
                border: false,
                cache: false
            });
            initListDetailTab(index, row);
        },
        loader: function (param, success, error) {
            var datas = {
                pageIndex: param.page,
                pageSize: param.rows,
                order: param.order,
                sort: param.sort,
                applyRecordBo: {}
            };
            var paramStr = JSON.stringify(datas);
            ajaxCRUD({
                url: 'WebServices/CostWebService/ReimbursementWebService/ApplyRecordWebService.asmx/GetApplyRecords',
                data: paramStr,
                success: function (data) {
                    success(data);
                    $('#ddlOrgForSearch').combobox({
                        required: true,
                        data: itemdatas,
                        valueField: 'Id',
                        textField: 'Name'
                    });
                },
                error: function () {
                    error.apply(this, arguments);
                }
            });
        }
    };
    //初始化列表组件
    iniDataGrid('dg', dataGridOptions);
    //预先加载列表明细结构模板
    $("#detailViewTemplate").load("Views/Cost/Reimbursement/Audit/ApplyAuditListDetailView.htm", function () {
    });
});

//初始化列表明细tab
function initListDetailTab(index, row) {
    $("#listTabs" + index).tabs({
        onSelect: function (title, tabindex) {
            //第一个Tab,直接显示报销项目明细
            switch (tabindex) {
                case 0:
                    var detailOptions = {
                        fit: false,
                        fitColumns: true,
                        singleSelect: true,
                        rownumbers: true,
                        height: 'auto',
                        columns: [[
                                { field: 'DetailId', checkbox: true },
                                { field: 'ItemName', title: '项目名称' },
                                { field: 'Price', title: '单价' },
                                { field: 'Count', title: '数量' },
                                { field: 'TotalPrice', title: '总价' },
                                { field: 'CreatedOnDateStr', title: '填写时间' }
                                 ]],
                        onResize: function () {
                            fixDetailRowHeight('dg', index);
                        },
                        onLoadSuccess: function () {
                            setTimeout(function () {
                                fixDetailRowHeight('dg', index);
                            }, 0);
                        },
                        loader: function (param, success, error) {
                            ajaxCRUD({
                                url: 'WebServices/CostWebService/ReimbursementWebService/ApplyRecordWebService.asmx/GetApplyDetailsByRecordId',
                                data: "{id:'" + row.ApplyId + "'}",
                                success: function (data) {
                                    success(data);
                                },
                                error: function () {
                                    error.apply(this, arguments);
                                }
                            });

                        } //loader
                    };
                    iniDataGrid('ddv-applyRecord-' + index, detailOptions);
                    break;
                default:
                    break;
            }
        }
    });
}

//easyloader.defaultTime为700ms
setTimeout(loadPartialHtml, easyloader.defaultTime);
function loadPartialHtml() {
   // getLatestItemDatas();
    if ($('.window').length == 0) {
        //加载新增表单模版
        panel('formTemplate', {
            href: 'Views/Cost/Reimbursement/Audit/ApplyAuditListDetailView.htm',
            onLoad: function () {
                //添加验证
            }
        });
    }
}
var delayTime = 600;
//点击“审核”按钮
function Audit() {
    auditItems('dg',auditDatasAjax);
}

function auditDatasAjax(str)
{
    ajaxCRUD({
        url: 'WebServices/CostWebService/ReimbursementWebService/ApplyAuditWebService.asmx/AuditApplyRecordByIds',
        data: "{ids:'" + str + "'}",
        success: function (data) {
            debugger;
            if (data.flag == 1) {
                msgShow('提示', '审核成功', 'info');
                refreshTable('dg');
            } else if(data.flag==2) {
                msgShow('提示', '部分审核成功，'+data.fail+'条记录审核失败', 'info');
            } else {
                 msgShow('提示', '审核失败', 'info');
            }
        }
    });
}

//简单搜索
function Search() {
    // 列表参数设置
    var dataGridOptions = {
        pageNumber: 1,
        loader: function (param, success, error) {
            var sendData = {
                pageIndex: param.page,
                pageSize: param.rows,
                order: param.order,
                sort: param.sort,
                applyRecordBo: {
                    OrId: $("#ddlOrgForSearch").combobox('getValue'),
                    ApplyBy: $("#txtApplyBy").val().trim(),
                    OrName: $("#ddlOrgForSearch").combobox('getText'),
                }
            };
            var paramStr = JSON.stringify(sendData);
            ajaxCRUD({
                url: 'WebServices/CostWebService/ReimbursementWebService/ApplyRecordWebService.asmx/GetApplyRecords',
                data: paramStr,
                success: function (data) {
                    success(data);
                },
                error: function () {
                    error.apply(this, arguments);
                }
            });
        } //loader
    };
    //初始化列表组件
    iniDataGrid('dg', dataGridOptions);
}

//关闭表单弹出层
function closeFormDialog() {
    closeDialog('dlg');
}

function clearSearchCriteria() {
    clearForm('advancedSearch');
}


//填充部门
function fillOrgs(ddlOrg, isSimpleSearch) {
    var webserviceUrl = 'WebServices/AdminWebService/OrganizationWebService/OrganizationWebService.asmx/GetAllOrganizations';
    ajaxCRUD({
        async: false,
        url: webserviceUrl,
        data: '{}',
        success: function (data) {
            if (isSimpleSearch) {
                data.unshift({ 'Value': 0, 'Name': '请选择' });
            }
            $("#" + ddlOrg).htCombobox({ data: data, valueField: "OrId", textField: "Name" });
        }
    });
}

//填充报销项目下的子项列表
var editIndex = undefined;
var webserviceUrl = 'WebServices/CostWebService/ReimbursementWebService/ReimbursementWebService.asmx/GetAllApplyItemNameAndIds';
var detailMsg = '报销子项';
function fillApplyRecordList(applyRecordId) {
    var detailOptions = {
        fit: false,
        fitColumns: true,
        singleSelect: true,
        rownumbers: true,
        height: 'auto',
        columns: [[
                { field: 'DetaiId', checkbox: true },
                {
                    field: 'ItemId', width: 20, title: '项目名称',
                    formatter: function (value, row) {
                        return row.ItemName;
                    }
                },
            {
                field: 'Price', width: 10, title: '单价',  
            },
            {
                field: 'Count', width: 10, title: '数量',
            }
              ]],
        loader: function (param, success, error) {
            ajaxCRUD({
                url: 'WebServices/CostWebService/ReimbursementWebService/ApplyRecordWebService.asmx/GetApplyDetailsByRecordId',
                data: "{id:'" + applyRecordId + "'}",
                success: function (data) {
                    if (data == null || data == undefined) {
                        data = { total: 0, rows: [] };
                    }
                    success(data);
                },
                error: function () {
                    error.apply(this, arguments);
                }
            });
        } //loader endsave     
    };
    iniDataGrid('detailList', detailOptions);
}

///获取最新的报销项目名称和id
//填充下拉框使用
function getLatestItemDatas() {
    var webserviceUrl = 'WebServices/CostWebService/ReimbursementWebService/ReimbursementWebService.asmx/GetAllApplyItemNameAndIds';
    ajaxCRUD({
        url: webserviceUrl,
        data: '{}',
        success: function (data) {
            if (data == null || data == undefined) {
                data = [];
            }
            itemdatas = data;
        },
        error: function () {
            error.apply(this, arguments);
        }
    });
}

/** 
* 解析输入的dateStr，返回Date类型。 
* dateStr: XXXX-XX-XX 
*/
function parseDate(dateStr) {
    var strArray = dateStr.split("-");
    if (strArray.length == 3) {
        return new Date(strArray[0], strArray[1], strArray[2]);
    } else {
        return new Date();
    }
} 
