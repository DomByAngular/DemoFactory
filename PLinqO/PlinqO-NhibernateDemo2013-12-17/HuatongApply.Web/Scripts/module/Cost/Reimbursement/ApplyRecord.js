/*global _comma_separated_list_of_variables_*/
/***********************************
/* 创建人：ys   
/* 修改人：
/* 修改日期：2013-12-03
/* 包含列表的绑定,增删改查
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
    $("#detailViewTemplate").load("Views/Cost/Reimbursement/Records/ApplyRecordrListDetailView.htm", function () {
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
                                    $("#")
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
    //getLatestItemDatas();
    if ($('.window').length == 0) {
        //加载新增表单模版
        panel('formTemplate', {
            href: 'Views/Cost/Reimbursement/Records/ApplyRecordWithDetailForm.htm',
            onLoad: function () {
                //添加验证
            }
        });
        //加载可编辑表单模版
        panel('EditFormTemplate', {
            href: 'Views/Cost/Reimbursement/Records/EditFormModel.htm',
            onLoad: function () {
                //添加验证
            }
        });
        //加载只读表单模版
        panel('ReadonlyFormTemplate', {
            href: 'Views/Cost/Reimbursement/Records/ReadonlyFormModel.htm',
            onLoad: function () {
                //添加验证
            }
        });
    }
}

var moduleName = '报销单-';
var isComponentInit = false; //可编辑父form初始化标志
var isComponentEditInit = false; //只读父form初始化标志
var delayTime = 600;
//点击“新增”按钮
function addData() {
    //填充可编辑模版
    $("#tableTemplate").html($("#EditFormTemplate").html());
    var grid = $("#detailList").datagrid();
    if (grid != null || grid != undefined) {
        $('#detailList').datagrid('loadData', []); //进来干掉所有的历史数据    
    }
    $('#divLoading').show(); //重用模版，重置表单
    $('#tableForm').hide();
    isComponentInit = false;
    openDialog('dlg', {
        title: moduleName + '新增',
        iconCls: 'icon-save',
        onOpen: function () {
            if (!isComponentInit) {
                setTimeout(function () {
                    isComponentInit = initFormControl();
                    if (isComponentInit) {
                        $('#divLoading').hide();
                        $('#tableForm').show();
                    }
                }, delayTime); //end setTimeout()
            } else {
            } //end if
        } //end onOpen
    });
    setTimeout(getLatestItemDatas, 0); //初始化报销项目的combobox;
}

//点击“编辑”按钮
function editData() {
    //填充可编辑模版
    $("#tableTemplate").html($("#ReadonlyFormTemplate").html());
    var row = getSelectedRow('dg');
    if (row == null || row == undefined) {
        msgShow(moduleName + '编辑', '请选择要编辑的一行数据', '');
    } else {
        if (row.ApplyId == null || row.ApplyId == undefined) {
            msgShow(moduleName + '编辑', '数据异常，请重试', '');
        } else {
            $('#divLoading').show(); //重用模版，重置表单
            $('#tableForm').hide();
            isComponentEditInit = false;
            openDialog('dlg', {
                title: moduleName + '编辑',
                iconCls: 'icon-edit',
                onOpen: function () {
                    if (!isComponentEditInit) {
                        setTimeout(function () {
                            isComponentEditInit = initEditFormControl(row.ApplyId);
                            if (isComponentEditInit) {
                                $('#divLoading').hide();
                                $('#tableForm').show();
                            }
                        }, delayTime); //end setTimeout()
                    } else {
                    } //end if
                } //end onOpen
            });

        }
    }
}

//获取JSON数据并填充到相应表单
function fillForm(id) {
    ajaxCRUD({
        url: 'WebServices/CostWebService/ReimbursementWebService/ApplyRecordWebService.asmx/GetApplyRecordById',
        data: "{id:'" + id + "'}",
        success: function (data) {
            //JSON数据填充表单
            bindVal($('.val'), 'id', data);
            $("#HidApplyId").val(data.ApplyId);
        }
    });

}

//保存表单数据
function saveData() {
    if (!formValidate("ff")) return;
    if (!accept()) {
        msgShow('提示', "有报销子项未填写完毕", 'info');
        return;
    }
    var hidValue = $("#HidApplyId").val();
    var basicUrl = 'WebServices/CostWebService/ReimbursementWebService/ApplyRecordWebService.asmx/';

    var wsMethod = '';

    var form2JsonObj = form2Json("ff");
    var sendDatas = {};
    if (hidValue.length > 0) {
        wsMethod = "UpdateApplyRecord"; //修改
        sendDatas = fixListData(form2JsonObj);
    } else {
        wsMethod = "AddApplyRecord"; //新增
        sendDatas = fixFormData(form2JsonObj); //子表数据写入父bo
    }
    var formUrl = basicUrl + wsMethod;
    var form2JsonStr = JSON.stringify(sendDatas);
    var jsonDataStr = "{applyRecordBo:" + form2JsonStr + "}";


    ajaxCRUD({
        url: formUrl,
        data: jsonDataStr,
        success: function (data) {
            var msg = '';
            if (hidValue.length > 0) {
                msg = "修改成功"; //修改
            } else {
                msg = "新增成功"; //新增
            }
            if (data == true) {
                msgShow('提示', msg, 'info');
                closeFormDialog();
                refreshTable('dg');
            } else {
                msgShow('提示', "操作失败", 'info');
            }
        }
    });
} // end saveData()

//批量删除前台提示
function deleteDatas() {
    deleteItems('dg', deleteDatasAjax);
}

//批量删除后台AJAX处理
function deleteDatasAjax(str) {
    ajaxCRUD({
        url: 'WebServices/CostWebService/ReimbursementWebService/ApplyRecordWebService.asmx/DeleteApplyRecordsByIds',
        data: "{ids:'" + str + "'}",
        success: function (data) {
            if (data == true) {
                msgShow('提示', '删除成功', 'info');
                refreshTable('dg');
            } else {
                msgShow('提示', '删除失败', 'info');
            }
        }
    });
}

//简单搜索
function Search() {
    // 列表参数设置
    var dataGridOptions = {
        pageNumber: 1,
        loader: function(param, success, error) {
            var sendData = {
                pageIndex: param.page,
                pageSize: param.rows,
                order: param.order,
                sort: param.sort,
                applyRecordBo: {
                    OrId: $("#ddlOrgForSearch").combobox('getValue'),
                    ApplyBy:$("#txtApplyBy").val().trim(),
                    OrName: $("#ddlOrgForSearch").combobox('getText'),
                }
            };
            var paramStr = JSON.stringify(sendData);
            ajaxCRUD({
                url: 'WebServices/CostWebService/ReimbursementWebService/ApplyRecordWebService.asmx/GetApplyRecords',
                data: paramStr,
                success: function(data) {
                    success(data);
                },
                error: function() {
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

//关闭报销项目详情页面弹出层
function closeDetailFormDialog() {
    closeDialog('dlgDetail');
}

//关闭退订弹出层
function closeCancelDialog() {
    closeDialog('dlgCancel');
}

function clearSearchCriteria() {
    clearForm('advancedSearch');
}

//初始化表表单
function initFormControl() {
    // fillOrgs("ddlOrg", false); //初始化部门下拉框
    $('#ddlOrg').combobox({
        required: true,
        data: itemdatas,
        valueField: 'Id',
        textField: 'Name'
    });
    setTimeout("fillApplyRecordList(" + null + ")", 0); //初始化datafrid列表
    $("#radioHKD").attr("checked", 'checked');
    $("#txtPrice").numberbox({
        min: 0,
        precision: 2
    });
    $("#txtApplyOn").datebox({ required: true });
    return true;
}

//初始化编辑表单
function initEditFormControl(applyId) {
    fillForm(applyId); //填充表单只读字段
    setTimeout("fillApplyRecordList(" + applyId + ")", 50); //填充报销项目子项
    return true;
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

//一次性为多个标签绑定值
function bindVal(classObj, attr, dataVal) {
    // 获取所有的id名
    var idName = [];
    // 遍历所有的id名，存到数组idName中
    classObj.attr(attr, function (i, val) {
        idName.push(val);
    });
    // 遍历data数据，如果data的key值在idName中存在，就绑定相应的值
    for (var key in dataVal) {
        if ($.inArray(key, idName) > -1) {
            var val = dataVal[key];
            if (val == null) val = "";
            $('#' + key).text(val);
        }
    }
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
                    },
                    editor: {
                        type: 'combobox',
                        options: {
                            required: true,
                            valueField: 'Id',
                            textField: 'Name',
                            data: itemdatas,
                            readonly: true,
                            editable: false
                        }
                    }
                },
            {
                field: 'Price', width: 10, title: '单价',
                editor: { type: 'numberbox', options: { required: true, precision: 1} }
            },
            {
                field: 'Count', width: 10, title: '数量',
                editor: { type: 'numberbox', options: { required: true, min: 1} }
            }
              ]],
        toolbar: [{
            text: '添加',
            iconCls: 'icon-add',
            handler: append
        }, {
            text: '编辑',
            iconCls: 'icon-edit',
            handler: function () {
                var row = $('#detailList').datagrid('getSelected');
                if (row == null) {
                    msgShow(moduleName + '编辑', '请选择要编辑的一行数据', '');
                } else {
                    var index = $('#detailList').datagrid('getRowIndex', row);
                    edit(index);
                }
            }
        }, '-', {
            text: '移除',
            iconCls: 'icon-remove',
            handler: function () {
                var row = $('#detailList').datagrid('getSelected');
                if (row == null) {
                    msgShow(moduleName + '删除', '请选择要删除的一行数据', '');
                } else {
                    var index = $('#detailList').datagrid('getRowIndex', row);
                    $('#detailList').datagrid('deleteRow', index);
                }
                accept();
            }
        }],
        onClickRow: function (rowIndex, rowData) {
            onClickRow(rowIndex);
        }, //单击结束编辑
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
    //如果是新增表单下，初始化子list列表，干掉loader
    if (applyRecordId == null || applyRecordId == undefined) {
        detailOptions['loader'] = function (param, success, error) {
            var datas = { total: 0, rows: [] };
            success(datas);
        };
    }
    iniDataGrid('detailList', detailOptions);
}

//报销子项列表是否已结束编辑
function endEditing() {
    if (editIndex == undefined) {
        return true;
    }
    if ($('#detailList').datagrid('validateRow', editIndex)) {
        var ed = $('#detailList').datagrid('getEditor', { index: editIndex, field: 'ItemId' });
        console.log(ed);
        if (ed == undefined || ed == null || ed.target == undefined) {
            return true;
        }
        var itemName = $(ed.target).combobox('getText');
        console.log(itemName);
        var itemname = $(ed.target).combobox('getText');
        $('#detailList').datagrid('getRows')[editIndex]['ItemName'] = itemname;
        $('#detailList').datagrid('endEdit', editIndex);
        editIndex = undefined;
        return true;
    } else {
        return false;
    }
}

//单击结束编辑或者选中行
function onClickRow(index) {
    if (editIndex != index) {
        if (endEditing()) {
            editIndex = undefined;
        } else {
            $('#detailList').datagrid('selectRow', editIndex);
        }
    }
}

//追加行
function append() {
    var currentInsertIndex = undefined;
    if (endEditing()) {
        var rows = $('#detailList').datagrid('getRows');
        if (!rows) {
            $('#detailList').datagrid({ data: [] });
            rows = $('#detailList').datagrid('getRows');
            $('#detailList').datagrid('appendRow', {
            });
        }
        else {
            // rows.length
            $('#detailList').datagrid('appendRow', {
            });
        }
        editIndex = $('#detailList').datagrid('getRows').length - 1;
        $('#detailList').datagrid('selectRow', editIndex)
                        .datagrid('beginEdit', editIndex);
    }
}

//接收行编辑
function accept() {
    if (endEditing()) {
        $('#detailList').datagrid('acceptChanges');
        return true;
    } else {
        return false;
    }
}
function reject() {
    $('#dg').datagrid('rejectChanges');
    editIndex = undefined;
}

function edit(index) {
    if (editIndex != index) {
        if (endEditing()) {
            $('#detailList').datagrid('selectRow', index)
                            .datagrid('beginEdit', index);
            editIndex = index;
        } else {
            $('#detailList').datagrid('selectRow', editIndex);
        }
    }
}

//表单数据修正，填入子项数据进表单Json对象
function fixFormData(basicData) {
    basicData["OrName"] = $("#ddlOrg").combobox('getText'); //写入组织机构名
    basicData["OrId"] = $("#ddlOrg").combobox('getValue'); //写入机构Id
    var data = basicData;
    var totalrows = [];
    var datagrid = $("#detailList").datagrid();
    if (datagrid != null && datagrid != undefined) {
        totalrows = $("#detailList").datagrid('getRows');
        console.log(totalrows);
        if (totalrows != undefined && totalrows != null && totalrows.length >= 1) {
            data["ApplydetailBoList"] = totalrows;
        }
        else {
            msgShow('提示', '您未填写报销单的内容，请填写报销单子项');
        }
    }
    console.log(totalrows);
    return data;
}


//编辑，表单数据修正
function fixListData(basicData) {
    var data = basicData;
    var totalrows = [];
    var datagrid = $("#detailList").datagrid();
    if (datagrid != null && datagrid != undefined) {
        totalrows = $("#detailList").datagrid('getRows');
        console.log(totalrows);
        if (totalrows != undefined && totalrows != null && totalrows.length >= 1) {
            data["ApplydetailBoList"] = totalrows;
        }
        else {
            msgShow('提示', '您未填写报销单的内容，请填写报销单子项');
        }
    }
    return data;
}

function syncLoadItems(editRow, index) {
    $(editRow.target).combobox('reload', webserviceUrl);
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
